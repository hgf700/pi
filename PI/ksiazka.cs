using System;
using System.Collections.Generic;
using System.IO;
using Newtonsoft.Json;

namespace pi
{
    public class Ksiazka
    {
        public int id { get; set; }
        public string tytul { get; set; }
        public string autor { get; set; }
        public string wydawca { get; set; }
        public string gatunek { get; set; }
        public DateTime datawydania { get; set; }
    }
}



