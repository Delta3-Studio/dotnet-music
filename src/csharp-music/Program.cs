Console.WriteLine(
    $"""
     Choose a song:
     {
         string.Join(
             Environment.NewLine,
             Enum.GetValues<PlayList.SongName>().Select(m => $"{(int)m}: {Enum.GetName(m)}")
         )
     }
     """
);

Console.Write("=> ");

if (!Enum.TryParse<PlayList.SongName>(Console.ReadKey().KeyChar.ToString(), out var chosen) || !Enum.IsDefined(chosen))
{
    Console.Error.WriteLine("\nInvalid song name");
    return;
}

Console.WriteLine($"\nSelected: {Enum.GetName(chosen)}");

var song = PlayList.GetSong(chosen);
SongPlayer.Play(song, 0.5f);