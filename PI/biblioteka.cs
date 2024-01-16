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

        //public int IloscKlientow { get; set; }

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
            // Zwiększ ilość klientów przy dodaniu nowego klienta
            IloscKlientow++;
        }
        public void DodajWypozyczenie(Wypozyczenia_zwrot wypozyczenie)
        {
            idwypozyczen.Add(wypozyczenie);
            IloscWypozyczen++;
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
                    sb.AppendLine($"Klient: ID={klient.id}, Imię={klient.imie}, Nazwisko={klient.nazwisko}");
                }

                // Dodaj informacje o książkach
                foreach (var ksiazka in ksiazki)
                {
                    sb.AppendLine($"Książka: ID={ksiazka.id}, Tytuł={ksiazka.tytul}, Autor={ksiazka.autor}");
                }

                foreach (var wypozyczenie in idwypozyczen)
                {
                    sb.AppendLine($"Id klienta={wypozyczenie.idklienta}, Dat awypozyczenia={wypozyczenie.Datawypozyczenia}, Data zwrotu={wypozyczenie.Datazwrotu}, Id ksiazki={wypozyczenie.idksiazki}");
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
                        Klient klient = new Klient { id = id, imie = imie, nazwisko = nazwisko };
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

                        Ksiazka ksiazka = new Ksiazka { id = id, tytul = tytul, autor = autor };
                        biblioteka.ksiazki.Add(ksiazka);
                    biblioteka.IloscKsiazek++;
                }
                else if (line.StartsWith("Id klienta:"))
                {
                    string[] wypozyczeniekaData = line.Split(new char[] { '=', ',' }, StringSplitOptions.RemoveEmptyEntries);
                    int idklient = int.Parse(wypozyczeniekaData[1]);
                    string Data_wypozyczenia = wypozyczeniekaData[3];
                    string Data_zwrotu = wypozyczeniekaData[5];
                    string id_ksiazkiString = wypozyczeniekaData[7];

                    // Convert 
                    DateTime dataWypozyczenia = DateTime.Parse(Data_wypozyczenia);
                    DateTime dataZwrotu = DateTime.Parse(Data_zwrotu);
                    List<int> id_ksiazki = id_ksiazkiString.Split(',').Select(int.Parse).ToList();


                    Wypozyczenia_zwrot wypozyczenie = new Wypozyczenia_zwrot
                    {
                        idklienta = idklient,
                        Datawypozyczenia = dataWypozyczenia,
                        Datazwrotu = dataZwrotu,
                        idksiazki = id_ksiazki
                    };
                    biblioteka.idwypozyczen.Add(wypozyczenie);
                    biblioteka.IloscWypozyczen++;
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