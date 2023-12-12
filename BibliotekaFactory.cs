using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace pi
{
    public class BibliotekaFactory : IBibliotekaFactory
    {
        public Klient CreateKlient(int id, string imie, string nazwisko, DateTime rokUrodzenia, string miejsceZamieszkania)
        {
            return new Klient
            {
                id = id,
                imie = imie,
                nazwisko = nazwisko,
                rok_urodzenia = rokUrodzenia,
                miejsce_zamieszkania = miejsceZamieszkania
            };
        }

        public Ksiazka CreateKsiazka(int id, string tytul, string autor, string wydawca, string gatunek, DateTime dataWydania)
        {
            return new Ksiazka
            {
                id = id,
                tytul = tytul,
                autor = autor,
                wydawca = wydawca,
                gatunek = gatunek,
                datawydania = dataWydania
            };
        }

        public Wypozyczenia_zwrot CreateWypozyczenie(int idKlienta, DateTime dataWypozyczenia, DateTime dataZwrotu)
        {
            return new Wypozyczenia_zwrot
            {
                idklienta = idKlienta,
                Datawypozyczenia = dataWypozyczenia,
                Datazwrotu = dataZwrotu,
                idksiazki = new List<int>()
            };
        }
    }

}
