using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SongsHub.model;

namespace SongsHub.dao
{
    public class MyPlayList : IPlaylist
    {
        public static List<Song> myPlayList = new List<Song>();
        private int capacity;

        public MyPlayList()
        {
            capacity = 20;
        }

        public void Add(Song song)
        {
            if (myPlayList.Count >= capacity)
            {
                Console.WriteLine("Playlist is full. Cannot add more songs.");
                return;
            }
            myPlayList.Add(song);
            Console.WriteLine("Song added successfully.");
        }

        public void Remove(int songId)
        {
            Song songToRemove = GetSongById(songId);
            if (songToRemove != null)
            {
                myPlayList.Remove(songToRemove);
                Console.WriteLine("Song removed successfully.");
            }
            else
            {
                Console.WriteLine("Song not found.");
            }
        }

        public Song GetSongById(int songId)
        {
            return myPlayList.Find(s => s.SongID == songId);
        }

        public Song GetSongByName(string songName)
        {
            return myPlayList.Find(s => string.Equals(s.SongName, songName, StringComparison.OrdinalIgnoreCase));
        }

        public List<Song> GetAllSongs()
        {
            return new List<Song>(myPlayList);
        }
    }
}
