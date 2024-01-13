using System;
using System.Collections.Generic;
using System.IO;
using Newtonsoft.Json;

namespace pi
{
    public class Klient
    {
        public int id { get; set; }
        public string imie { get; set; }
        public string nazwisko { get; set; }
        public DateTime rok_urodzenia { get; set; }
        public string miejsce_zamieszkania { get; set; }
        public int Ograniczenie = 15;
        public List<int> idwypozyczen { get; set; }
    }

}
