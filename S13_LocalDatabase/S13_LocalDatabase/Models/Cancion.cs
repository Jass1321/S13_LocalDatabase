using System;
using System.Collections.Generic;
using System.Text;

namespace S13_LocalDatabase.Models
{
    public class Cancion
    {
         public int CancionID { get; set; }
        public string Name { get; set; }
        public bool Like { get; set; }
        public int FechaEstreno{ get; set; }
        public int Time { get; set; }

        public int AlbumID { get; set; }
        public Album Album { get; set; }

        public int ArtistaID { get; set; }
        public Artista Artista { get; set; }

    }
}
