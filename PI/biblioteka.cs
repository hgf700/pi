
using System;
using System.Collections.Generic;
using System.IO;
using System.Text;
using Newtonsoft.Json;

namespace pi
{

    public class Biblioteka
    {

        public List<Klient> klienci;
        public List<Wypozyczenia_zwrot> idwypozyczen;
        public List<Ksiazka> ksiazki;

        public int IloscKsiazek { get; set; }
        public int IloscWypozyczen { get; set; }
        public int IloscKlientow { get; set; }

        public Biblioteka()
        {

            IloscKlientow = 0;
            IloscKsiazek = 0;
            IloscWypozyczen = 0;
            klienci = new List<Klient>();
            idwypozyczen = new List<Wypozyczenia_zwrot>();
            ksiazki = new List<Ksiazka>();
        }

        public void dodajksiazke(Ksiazka ksiazka)
        {
            ksiazki.Add(ksiazka);
            IloscKsiazek++;
        }


        public void DodajKlienta(Klient klient)
        {
            klienci.Add(klient);
            IloscKlientow++;
        }
        public void DodajWypozyczenie(Wypozyczenia_zwrot wypozyczenie, Ksiazka ksiazki)
        {
            idwypozyczen.Add(wypozyczenie);
            IloscWypozyczen++;
            //moze kiedys jak nie bede wiedzial co robic ze soba
            // Dodaj warunek sprawdzający, czy książka istnieje w słowniku przed próbą usunięcia
            //if (ksiazki.ContainsKey(wypozyczenie.ksiazka))
            //{
            //    ksiazki.Remove(wypozyczenie.ksiazka, out _); // Usuń książkę na podstawie klucza
            //}
        }

        public void zwrotwypozyczenie(Wypozyczenia_zwrot wypozyczenie)
        {
            idwypozyczen.Remove(wypozyczenie);

        }

        public void ZapiszDoPlikuTekstowego(string nazwaPliku)
        {
            try
            {
                StringBuilder sb = new StringBuilder();

                // Dodaj informacje o klientach
                foreach (var klient in klienci)
                {
                    sb.AppendLine($"Klient: ID={klient.Id}, Imię={klient.imie}, Nazwisko={klient.nazwisko} dodano przez program");
                }

                // Dodaj informacje o książkach
                foreach (var ksiazka in ksiazki)
                {
                    sb.AppendLine($"Książka: ID={ksiazka.Id}, Tytuł={ksiazka.tytul}, Autor={ksiazka.autor} dodano przez program");
                }

                foreach (var wypozyczenie in idwypozyczen)
                {
                    sb.AppendLine($"Id klienta={wypozyczenie.klient}, Dat awypozyczenia={wypozyczenie.Datawypozyczenia}, Data zwrotu={wypozyczenie.Datazwrotu}, Id ksiazki={wypozyczenie.ksiazka}");
                }
                // Zapisz do pliku (lub dopisz, jeśli plik już istnieje)
                File.AppendAllText(nazwaPliku, sb.ToString());

                Console.WriteLine("Dane zostały pomyślnie zapisane do pliku.");
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Wystąpił błąd podczas zapisu do pliku: {ex.Message}");
            }
        }


        public static Biblioteka OdczytajZPlikuTekstowego(string nazwaPliku)
        {
            //try
            //{
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

                    // Sprawdź, czy dane są poprawne, zanim zaczniesz odwoływać się do indeksów
                    if (klientData.Length >= 6)
                    {
                        int id = int.Parse(klientData[1]);
                        string imie = klientData[3];
                        string nazwisko = klientData[5];

                        // Utwórz obiekt klienta i dodaj do listy
                        Klient klient = new Klient { Id = id, imie = imie, nazwisko = nazwisko };
                        biblioteka.klienci.Add(klient);
                        biblioteka.IloscKlientow++;
                    }
                }
                else if (line.StartsWith("Książka:"))
                {
                    // Analogicznie dla książki

                    string[] ksiazkaData = line.Split(new char[] { '=', ',' }, StringSplitOptions.RemoveEmptyEntries);
                    int id = int.Parse(ksiazkaData[1]);
                    string tytul = ksiazkaData[3];
                    string autor = ksiazkaData[5];

                    Ksiazka ksiazka = new Ksiazka { Id = id, tytul = tytul, autor = autor };
                    biblioteka.ksiazki.Add(ksiazka);
                    biblioteka.IloscKsiazek++;
                }
                else if (line.StartsWith("Id klienta:"))
                {
                    string[] wypozyczeniekaData = line.Split(new char[] { '=', ',' }, StringSplitOptions.RemoveEmptyEntries);

                    // Pobierz identyfikator klienta
                    int idKlienta = int.Parse(wypozyczeniekaData[1]);

                    // Znajdź klienta w liście na podstawie identyfikatora
                    Klient klient = biblioteka.klienci.FirstOrDefault(k => k.Id == idKlienta);

                    // Sprawdź, czy klient został znaleziony
                    if (klient != null)
                    {
                        string Data_wypozyczenia = wypozyczeniekaData[3];
                        string Data_zwrotu = wypozyczeniekaData[5];

                        // Pobierz identyfikator książki
                        int idKsiazki = int.Parse(wypozyczeniekaData[7]);

                        // Znajdź książkę w liście na podstawie identyfikatora
                        Ksiazka ksiazka = biblioteka.ksiazki.FirstOrDefault(k => k.Id == idKsiazki);
                        if (ksiazka != null)
                        {
                            DateTime dataWypozyczenia = DateTime.Parse(Data_wypozyczenia);
                            DateTime dataZwrotu = DateTime.Parse(Data_zwrotu);

                            Wypozyczenia_zwrot wypozyczenie = new Wypozyczenia_zwrot
                            {
                                klient = klient,
                                Datawypozyczenia = dataWypozyczenia,
                                Datazwrotu = dataZwrotu,
                                ksiazka = ksiazka
                            };
                            Console.WriteLine($"Id klienta={wypozyczenie.klient?.Id}, Dat awypozyczenia={wypozyczenie.Datawypozyczenia}, Data zwrotu={wypozyczenie.Datazwrotu}, Id ksiazki={wypozyczenie.ksiazka?.Id}");
                            biblioteka.idwypozyczen.Add(wypozyczenie);
                            biblioteka.IloscWypozyczen++;
                        }
                        else
                        {
                            Console.WriteLine($"Błąd: Nie znaleziono książki o ID {idKsiazki}");
                        }
                    }
                    else
                    {
                        Console.WriteLine($"Błąd: Nie znaleziono klienta o ID {idKlienta}");
                    }
                }


            }

            return biblioteka;

        }
        //catch (Exception ex)
        //{
        //    Console.WriteLine($"Wystąpił błąd podczas zapisu do pliku: {ex.Message}");
        //}

        //}
    }
}


//https://kordos.com/ath/drawing_collections.html