using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace pi
{
    public interface IBibliotekaFactory
    {
        Klient CreateKlient(int id, string imie, string nazwisko, DateTime rokUrodzenia, string miejsceZamieszkania);
        Ksiazka CreateKsiazka(int id, string tytul, string autor, string wydawca, string gatunek, DateTime dataWydania);
        Wypozyczenia_zwrot CreateWypozyczenie(int idKlienta, DateTime dataWypozyczenia, DateTime dataZwrotu);
    }
}
