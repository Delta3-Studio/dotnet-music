public static class PlayList
{
    public enum SongName
    {
        HappyBirthday = 1,
        CoffinDance,
        CatVibing,
    }

    public static Song GetSong(SongName name) => name switch
    {
        SongName.HappyBirthday => HappyBirthday(),
        SongName.CoffinDance => CoffinDance(),
        SongName.CatVibing => CatVibing(),
        _ => throw new ArgumentOutOfRangeException(nameof(name), name, null)
    };

    public static Song HappyBirthday()
    {
        SongBuilder song = new();

        song.Repeat(2,
            new(N.G, 0.5f),
            new(N.G, 0.5f),
            new(N.A, 1f),
            new(N.G, 1f),
            new(N.C, 1f, 1),
            new(N.B, 2f),
            //
            new(N.G, 0.5f),
            new(N.G, 0.5f),
            new(N.A, 1f),
            new(N.G, 1f),
            new(N.D, 1f, 1),
            new(N.C, 2f, 1),
            //
            new(N.G, 0.5f),
            new(N.G, 0.5f),
            new(N.G, 2f, 1),
            new(N.E, 1f, 1),
            new(N.C, 1f, 1),
            new(N.B, 1f),
            new(N.A, 2f),
            //
            new(N.F, 0.5f, 1),
            new(N.F, 0.5f, 1),
            new(N.E, 2f, 1),
            new(N.C, 1f, 1),
            new(N.D, 1f, 1),
            new(N.C, 2f, 1)
        );

        song.SetBpm(100);
        return song.ToSong();
    }

    // from https://www.youtube.com/watch?v=FtWIuFLBrjo
    public static Song CoffinDance()
    {
        SongBuilder song = new();

        song.Add(
            new(N.A, 0.5f),
            new(N.A, 0.5f),
            new(N.A, 0.5f),
            new(N.A, 0.5f),
            new(N.Cs, 0.5f, 1),
            new(N.Cs, 0.5f, 1),
            new(N.Cs, 0.5f, 1),
            new(N.Cs, 0.5f, 1),
            new(N.B, 0.5f),
            new(N.B, 0.5f),
            new(N.B, 0.5f),
            new(N.B, 0.5f),
            new(N.E, 0.5f, 1),
            new(N.E, 0.5f, 1),
            new(N.E, 0.5f, 1),
            new(N.E, 0.5f, 1),
            new(N.Fs, 0.5f, 1),
            new(N.Fs, 0.5f, 1),
            new(N.Fs, 0.5f, 1),
            new(N.Fs, 0.5f, 1),
            new(N.Fs, 0.5f, 1),
            new(N.Fs, 0.5f, 1),
            new(N.Fs, 0.5f, 1),
            new(N.Fs, 0.5f, 1),
            new(N.Fs, 0.5f, 1),
            new(N.Fs, 0.5f, 1),
            new(N.Fs, 0.5f, 1),
            new(N.Fs, 0.5f, 1),
            new(N.B, 0.5f),
            new(N.A, 0.5f),
            new(N.Gs, 0.5f),
            new(N.E, 0.5f)
        );

        song.Repeat(2,
            new(N.Fs, 1f),
            new(N.Fs, 0.5f),
            new(N.Cs, 0.5f, 1),
            new(N.B, 1f),
            new(N.A, 1f),
            new(N.Gs, 1f),
            new(N.Gs, 0.5f),
            new(N.Gs, 0.5f),
            new(N.B, 1),
            new(N.A, 0.5f),
            new(N.Gs, 0.5f),
            new(N.Fs, 1f),
            new(N.Fs, 0.5f),
            new(N.A, 0.5f, 1),
            new(N.Gs, 0.5f, 1),
            new(N.A, 0.5f, 1),
            new(N.Gs, 0.5f, 1),
            new(N.A, 0.5f, 1),
            new(N.Fs, 1f),
            new(N.Fs, 0.5f),
            new(N.A, 0.5f, 1),
            new(N.Gs, 0.5f, 1),
            new(N.A, 0.5f, 1),
            new(N.Gs, 0.5f, 1),
            new(N.A, 0.5f, 1)
        );

        song.Loop(2);
        song.SetBpm(120);
        return song.ToSong();
    }

    public static Song CatVibing()
    {
        SongBuilder song = new();

        song.SetTrack(0, 0.5f);
        song.Repeat(4,
            new(N.Ds, 1f, -2),
            new(N.As, 1f, -3),
            new(N.Ds, 1f, -2),
            new(N.As, 1f, -3),
            new(N.Cs, 1f, -2),
            new(N.As, 1f, -3),
            new(N.Ds, 1f, -2),
            new(N.As, 1f, -3)
        );

        song.SetTrack(1);
        song.Add(
            new(N.As, 0.5f, -1),
            new(N.Ds, 0.5f),
            //
            new(N.Ds, 0.75f),
            new(N.F, 0.25f),
            //
            new(N.Fs, 0.25f),
            new(N.Fs, 0.25f),
            new(N.Ds, 0.25f),
            new(N.Ds, 0.25f),
            //
            new(N.Ds, 0.50f),
            new(N.Ds, 0.25f),
            new(N.Fs, 0.25f),
            //
            new(N.F, 0.50f),
            new(N.Cs, 0.50f),
            //
            new(N.Cs, 0.50f),
            new(N.F, 0.50f),
            //
            new(N.Fs, 0.50f),
            new(N.Ds, 0.50f),
            //
            new(N.Ds, 0.75f),
            new(N.Ds, 0.25f),
            //
            new(N.As, 0.5f, -1),
            new(N.Ds, 0.5f),
            //
            new(N.Ds, 0.75f),
            new(N.F, 0.25f),
            //
            new(N.Fs, 0.5f),
            new(N.Ds, 0.25f),
            new(N.Ds, 0.75f),
            new(N.Ds, 0.25f),
            new(N.Fs, 0.25f),
            //
            new(N.As, 0.25f),
            new(N.As, 0.25f),
            new(N.As, 0.25f),
            new(N.Gs, 0.25f),
            //
            new(N.Fs, 0.25f),
            new(N.Fs, 0.25f),
            new(N.F, 0.25f),
            new(N.F, 0.25f),
            //
            new(N.Fs, 0.5f),
            new(N.Ds, 0.5f),
            //
            new(N.Ds, 0.5f),
            new(N.Ds, 0.25f),
            new(N.Fs, 0.25f)
        );

        song.Repeat(2,
            new(N.As, 0.5f),
            new(N.As, 0.5f),
            //
            new(N.Gs, 0.5f),
            new(N.Fs, 0.5f),
            //
            new(N.F, 0.5f),
            new(N.Cs, 0.25f),
            new(N.Cs, 0.75f),
            new(N.Cs, 0.25f),
            new(N.F, 0.25f),
            //
            new(N.Gs, 0.25f),
            new(N.Gs, 0.25f),
            new(N.Gs, 0.25f),
            new(N.Gs, 0.25f),
            //
            new(N.Fs, 0.25f),
            new(N.Fs, 0.25f),
            new(N.F, 0.25f),
            new(N.F, 0.25f),
            //
            new(N.Fs, 0.5f),
            new(N.Ds, 0.25f),
            new(N.Ds, 0.75f),
            new(N.Ds, 0.25f),
            new(N.Fs, 0.25f)
        );

        song.Loop(2);
        song.SetBpm(100);
        return song.ToSong();
    }
}