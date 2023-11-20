using projektpi;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
namespace projektpi
{
    internal class Klient 
    {
        public int id;
        public string imie;
        public string nazwisko;
        public DateTime rok_urodzenia;
        public string miejsce_zamieszkania;
        public int Ograniczenie =  15;
        List<int> idwypozyczen;
        //public Klient(string i,string n, DateTime ru, string mz,/*Ograniczenie,*/ DateTime dw, DateTime dz)
        //{
        //    Imie = i;
        //    Nazwisko = n;   
        //    Rok_urodzenia = ru;
        //    Miejsce_zamieszkania = mz;
        //    Data_wypozyczenia = dw;
        //    Data_zwrotu = dz;
        //}
        //Klient klient = new Klient("a", "a", new DateTime(2000, 2, 2), "a", new DateTime(2000, 2, 2), new DateTime(2000, 2, 2));
    }

}
