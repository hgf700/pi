using System;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using Newtonsoft.Json;

namespace pi
{

    public class Wypozyczenia_zwrot
    {
        //  public int idklienta { get; set; }
        public Klient klient { get; set; }
        public DateTime Datawypozyczenia { get; set; }
        public DateTime Datazwrotu { get; set; }
        // public List<int> idksiazki { get; set; }
        public Ksiazka ksiazka { get; set; }
        public int Ograniczenie = 2;
        public BitArray wypozyczenialiczba;
    }
}