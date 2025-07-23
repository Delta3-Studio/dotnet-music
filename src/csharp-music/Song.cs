global using Seconds = float;
global using Pulse = float;
global using Hz = float;
global using Semitons = float;
global using Beats = float;
global using N = Note;

public enum Note
{
    C,
    Cs,
    D,
    Ds,
    E,
    F,
    Fs,
    G,
    Gs,
    A,
    As,
    B
}


public sealed class Song(params Song.Track[] tracks)
{
    public Track[] Tracks { get; } = tracks;

    public Pulse[] GetWave()
    {
        return Tracks.Select(x => x.GetWave()).Aggregate(CombineWaves);

        static Pulse[] CombineWaves(Pulse[] left, Pulse[] right)
        {
            var result = new Pulse[Math.Max(left.Length, right.Length)];

            for (var i = 0; i < result.Length; i++)
            {
                if (i >= left.Length && i < right.Length)
                    result[i] = right[i];
                else if (i >= right.Length && i < left.Length)
                    result[i] = left[i];
                else if (i < right.Length && i < left.Length)
                    result[i] = (left[i] + right[i]);
                else
                    result[i] = 0;
            }

            return result;
        }
    }

    public record Track(Sample[] Samples, float Bpm, float Volume = 1)
    {
        public float Volume { get; set; } = Volume;
        float Bps => 60f / Bpm;

        public Pulse[] GetWave() => Samples.SelectMany(s => s.GetWave(Bps, Volume)).ToArray();
    }
}

public readonly record struct Sample(N Note, Beats Beats, int Octave = 0)
{
    const float PitchStandard = 440; // https://www.youtube.com/watch?v=ifZ0k9agUKY
    public const float Rate = 48_000;

    public Seconds Duration(float bps) => Beats * bps;

    public Semitons Semitons => (int)Note - (int)N.A + Octave * Enum.GetNames<N>().Length;
    public Hz Hertz => (float)(PitchStandard * Math.Pow(Math.Pow(2, 1.0 / 12.0), Semitons));

    public Pulse[] GetWave(float bps, float volume = 1)
    {
        var step = Hertz * 2 * MathF.PI / Rate;

        var wave =
            Enumerable
                .Range(0, (int)(Rate * Duration(bps)))
                .Select(x => x * step)
                .Select(MathF.Sin)
                .Select(x => x * volume)
                .ToArray();

        var attack = Enumerable.Range(0, wave.Length)
            .Select(x => MathF.Min(1, x / 1000f))
            .ToArray();

        var release = attack.Reverse();

        var output = wave
            .Zip(attack, (w, v) => w * v)
            .Zip(release, (w, v) => w * v)
            .ToArray();

        return output;
    }
}