﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace VirtualArtGallery.Entity
{
    public class Artist
    {
        public int ArtistID { get; set; }
        public string Name { get; set; }
        public string Biography { get; set; }
        public DateTime BirthDate { get; set; }
        public string Nationality { get; set; }
        public string Website { get; set; }
        public string ContactInformation { get; set; }
    }
}
