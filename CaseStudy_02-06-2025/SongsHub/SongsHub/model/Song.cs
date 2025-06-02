using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SongsHub.model
{
    public class Song
    {
        public int SongID { get; set; }
        public string SongName { get; set; }
        public string SongGenre { get; set; }

        public override string ToString()
        {
            return $"ID: {SongID}, Name: {SongName}, Genre: {SongGenre}";
        }

    }
}
