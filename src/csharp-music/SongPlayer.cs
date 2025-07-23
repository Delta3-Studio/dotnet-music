using OpenTK.Audio.OpenAL;

public static class SongPlayer
{
    static void Play(Pulse[] wave, float volume)
    {
        wave = Array.ConvertAll(wave, p => p * volume);

        var deviceName = ALC.GetString(ALDevice.Null, AlcGetString.DefaultDeviceSpecifier);
        var device = ALC.OpenDevice(deviceName);
        var context = ALC.CreateContext(device, null as int[]);
        ALC.MakeContextCurrent(context);
        AL.GenBuffer(out var alBuffer);
        AL.BufferData(alBuffer, ALFormat.MonoFloat32Ext, wave, (int)Sample.Rate);

        AL.Listener(ALListenerf.Gain, 1f);
        AL.GenSource(out var alSource);
        AL.Source(alSource, ALSourcef.Gain, 1f);
        AL.Source(alSource, ALSourcei.Buffer, alBuffer);
        AL.SourcePlay(alSource);

        while ((ALSourceState)AL.GetSource(alSource, ALGetSourcei.SourceState) is ALSourceState.Playing)
            Thread.Sleep(100);

        AL.SourceStop(alSource);
        ALC.MakeContextCurrent(ALContext.Null);
        ALC.DestroyContext(context);
        ALC.CloseDevice(device);
    }

    public static void Play(Song song, float volume = 1) => Play(song.GetWave(), volume);
}