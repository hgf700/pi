using projektpi;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace projektpi
{
    
    internal class Wypozyczenia_zwrot: /*Klient,*/Ilosc_ksiazek
    {
        public DateTime Datawypozyczenia;
        public DateTime Datazwrotu;
        public string Tytul;
        public int iloscksiazek;
        //public Wypozyczenia_zwrot(DateTime dw, DateTime dz, string t, string il, int ik)
        //{
        //    Datawypozyczenia = dw;
        //    Datazwrotu = dz;
        //    Tytul = t;
        //    iloscksiazek = ik;
        //}
    }
}
