using projektpi;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
/* {"a","a",DateTime,DateTime(2000, 2, 2)*/
namespace projektpi
{
    internal class Klient : Wypozyczenia_zwrot
    {
        public string Imie;
        public string Nazwisko;
        public DateTime Rok_urodzenia;
        public string Miejsce_zamieszkania;
        //public int Ograniczenie = np 15;
        public DateTime Data_wypozyczenia;
        public DateTime Data_zwrotu;
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
