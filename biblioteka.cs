using System;
using System.Collections.Generic;
using System.IO;
using System.Text;
using Newtonsoft.Json;

namespace pi
{
    public class Biblioteka
    {
        private BibliotekaFactory bibliotekaFactory;
        private List<Klient> klienci;
        private List<Wypozyczenia_zwrot> idwypozyczen;
        private List<Ksiazka> ksiazki;

        public Biblioteka()
        {
            bibliotekaFactory = new BibliotekaFactory();
            klienci = new List<Klient>();
            idwypozyczen = new List<Wypozyczenia_zwrot>();
            ksiazki = new List<Ksiazka>();
        }

        public void dodajksiazke(Ksiazka ksiazka)
        {
            ksiazki.Add(ksiazka);
        }

        public void dodajklienta(Klient klient)
        {
            klienci.Add(klient);
        }

        public void dodajwypozyczenie(Wypozyczenia_zwrot wypozyczenie)
        {
            idwypozyczen.Add(wypozyczenie);
        }
        public void ZapiszDoPlikuTekstowego(string nazwaPliku)
        {
            // Przygotuj tekstową reprezentację danych
            StringBuilder sb = new StringBuilder();

            // Dodaj informacje o klientach
            foreach (var klient in klienci)
            {
                sb.AppendLine($"Klient: ID={klient.id}, Imię={klient.imie}, Nazwisko={klient.nazwisko}");
            }

            // Dodaj informacje o książkach
            foreach (var ksiazka in ksiazki)
            {
                sb.AppendLine($"Książka: ID={ksiazka.id}, Tytuł={ksiazka.tytul}, Autor={ksiazka.autor}");
            }

            // Zapisz do pliku
            File.WriteAllText(nazwaPliku, sb.ToString());
        }

        public static Biblioteka OdczytajZPlikuTekstowego(string nazwaPliku)
        {
            Biblioteka biblioteka = new Biblioteka();

            // Odczytaj dane z pliku
            string[] lines = File.ReadAllLines(nazwaPliku);

            // Parsuj dane i dodawaj do odpowiednich list w obiekcie Biblioteka
            foreach (var line in lines)
            {
                if (line.StartsWith("Klient:"))
                {
                    // Przykład parsowania dla klienta
                    string[] klientData = line.Split(new char[] { '=', ',' }, StringSplitOptions.RemoveEmptyEntries);
                    int id = int.Parse(klientData[1]);
                    string imie = klientData[3];
                    string nazwisko = klientData[5];

                    // Utwórz obiekt klienta i dodaj do listy
                    Klient klient = new Klient { id = id, imie = imie, nazwisko = nazwisko };
                    biblioteka.klienci.Add(klient);
                }
                else if (line.StartsWith("Książka:"))
                {
                    // Analogicznie dla książki
                    string[] ksiazkaData = line.Split(new char[] { '=', ',' }, StringSplitOptions.RemoveEmptyEntries);
                    int id = int.Parse(ksiazkaData[1]);
                    string tytul = ksiazkaData[3];
                    string autor = ksiazkaData[5];

                    Ksiazka ksiazka = new Ksiazka { id = id, tytul = tytul, autor = autor };
                    biblioteka.ksiazki.Add(ksiazka);
                }
            }

            return biblioteka;
        }

    }
}