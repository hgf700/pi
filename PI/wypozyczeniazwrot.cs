using System;
using System.Collections.Generic;
using System.IO;
using Newtonsoft.Json;

namespace pi
{

    public class Wypozyczenia_zwrot
    {
        public int idklienta { get; set; }
        public DateTime Datawypozyczenia { get; set; }
        public DateTime Datazwrotu { get; set; }
        public List<int> idksiazki { get; set; }
        public int Ograniczenie = 2;
    }
}
