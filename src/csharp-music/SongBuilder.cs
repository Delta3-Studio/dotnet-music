public sealed class SongBuilder
{
    readonly List<TrackBuilder> tracks = [new()];
    public int CurrentTrackIndex { get; private set; }

    public TrackBuilder CurrentTrack => tracks[CurrentTrackIndex];

    public void SetTrack(int index, float? volume = null)
    {
        if (tracks.Count <= index)
            tracks.Add(new());

        CurrentTrackIndex = Math.Clamp(index, 0, tracks.Count - 1);

        if (volume.HasValue)
            CurrentTrack.Volume = volume.Value;
    }

    public void SetBpm(float bpm)
    {
        foreach (var track in tracks)
            track.Bpm = bpm;
    }

    public void Add(params Sample[] samples) => CurrentTrack.Add(samples);

    public void Repeat(int times, params Sample[] samples) => CurrentTrack.Repeat(times, samples);

    public void Loop(int times)
    {
        foreach (var track in tracks)
            track.Repeat(times);
    }

    public Song ToSong() => new(tracks.Select(t => t.ToTrack()).ToArray());

    public sealed class TrackBuilder
    {
        readonly List<Sample> song = [];

        public float Bpm { get; set; } = 60f;
        public float Volume { get; set; } = 1;

        public Song.Track ToTrack() => new(song.ToArray(), Bpm, Volume);

        public void Add(params Sample[] samples) => song.AddRange(samples);

        public void Repeat(int times, params Sample[] samples)
        {
            if (samples is null or [])
                samples = song.ToArray();

            for (var i = 0; i < times; i++)
                Add(samples);
        }
    }
}