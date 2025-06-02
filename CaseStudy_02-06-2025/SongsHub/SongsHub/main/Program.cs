using System;
using SongsHub.dao;
using SongsHub.model;

class Program
{
    static void Main()
    {
        MyPlayList playlist = new MyPlayList();

        while (true)
        {
            Console.WriteLine("\nEnter your choice:");
            Console.WriteLine("1: Add Song");
            Console.WriteLine("2: Remove Song by ID");
            Console.WriteLine("3: Get Song by ID");
            Console.WriteLine("4: Get Song by Name");
            Console.WriteLine("5: Get All Songs from Playlist");
            Console.WriteLine("0: Exit");

            Console.Write("Choice: ");
            string input = Console.ReadLine();

            switch (input)
            {
                case "1":
                    Song newSong = new Song();
                    Console.Write("Enter Song ID: ");
                    newSong.SongID = int.Parse(Console.ReadLine());
                    Console.Write("Enter Song Name: ");
                    newSong.SongName = Console.ReadLine();
                    Console.Write("Enter Song Genre: ");
                    newSong.SongGenre = Console.ReadLine();
                    playlist.Add(newSong);
                    break;

                case "2":
                    Console.Write("Enter Song ID to remove: ");
                    int removeId = int.Parse(Console.ReadLine());
                    playlist.Remove(removeId);
                    break;

                case "3":
                    Console.Write("Enter Song ID to search: ");
                    int searchId = int.Parse(Console.ReadLine());
                    Song songById = playlist.GetSongById(searchId);
                    Console.WriteLine(songById != null ? songById.ToString() : "Song not found.");
                    break;

                case "4":
                    Console.Write("Enter Song Name to search: ");
                    string name = Console.ReadLine();
                    Song songByName = playlist.GetSongByName(name);
                    Console.WriteLine(songByName != null ? songByName.ToString() : "Song not found.");
                    break;

                case "5":
                    var songs = playlist.GetAllSongs();
                    if (songs.Count == 0)
                    {
                        Console.WriteLine("Playlist is empty.");
                    }
                    else
                    {
                        Console.WriteLine("All Songs in Playlist:");
                        foreach (var song in songs)
                        {
                            Console.WriteLine(song);
                        }
                    }
                    break;

                case "0":
                    Console.WriteLine("Exiting...");
                    return;

                default:
                    Console.WriteLine("Invalid choice. Try again.");
                    break;
            }
        }
    }
}
