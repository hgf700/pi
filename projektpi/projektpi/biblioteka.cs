using System;
using System.Collections.Generic;
using System.IO;
using Newtonsoft.Json;

namespace projektpi
{
    internal class Biblioteka
    {
        public List<Klient> klienci;
        public List<Wypozyczenia_zwrot> idwypozyczen;
        public List<Ksiazka> ksiazki;

        public Biblioteka()
        {
            klienci = new List<Klient>();
            idwypozyczen = new List<Wypozyczenia_zwrot>();
            ksiazki = new List<Ksiazka>();
        }

        public void dodajklienta(Klient klient)
        {
            klienci.Add(klient);
        }

        public void dodajksiazke(Ksiazka ksiazka)
        {
            ksiazki.Add(ksiazka);
        }

        public void dodajwypozyczenie(Wypozyczenia_zwrot wypozyczenia_)
        {
            idwypozyczen.Add(wypozyczenia_);
        }

        public void ZapiszDoPliku(string nazwaPliku)
        {
            string json = JsonConvert.SerializeObject(this, Formatting.Indented);
            File.WriteAllText(nazwaPliku, json);
        }

        public static Biblioteka OdczytajZPliku(string nazwaPliku)
        {
            string json = File.ReadAllText(nazwaPliku);
            return JsonConvert.DeserializeObject<Biblioteka>(json);
        }

        class Program
        {
            static void Main()
            {
                bool kontynuuj = true;
                do
                {
                    Console.WriteLine("Wybierz 1 z opcji");
                    Console.WriteLine("1. Tworzenie klienta lub ksiazki");
                    Console.WriteLine("2. wypozyczenie");
                    Console.WriteLine("3. Wyświetlenie");
                    Console.WriteLine("4. Zakończ program\n");

                    int n = int.Parse(Console.ReadLine());
                    switch (n)
                    {
                        case 1:
                            Console.WriteLine("Podaj nazwę pliku do zapisu:");
                            string nazwaPliku = Console.ReadLine();

                            Biblioteka biblioteka = new Biblioteka();

                            Console.WriteLine("Co chcesz zrobic");
                            Console.WriteLine("1. Dodac ksiazke");
                            Console.WriteLine("2. Dodac klienta");
                            Console.WriteLine("3. Zakoncz program");
                            int n1 = int.Parse(Console.ReadLine());
                            bool kontynuuj1 = true;

                            switch (n1)
                            {
                                case 1:
                                    Console.Write("Dodajesz ksiazke");
                                    Console.Write("ID: ");
                                    int idKsiazki = int.Parse(Console.ReadLine());
                                    Console.Write("Tytuł: ");
                                    string tytul = Console.ReadLine();
                                    Console.Write("Autor: ");
                                    string autor = Console.ReadLine();
                                    Console.Write("Wydawca: ");
                                    string wydawca = Console.ReadLine();
                                    Console.Write("Gatunek: ");
                                    string gatunek = Console.ReadLine();
                                    Ksiazka nowaKsiazka = new Ksiazka
                                    {
                                        id = idKsiazki,
                                        tytul = tytul,
                                        autor = autor,
                                        wydawca = wydawca,
                                        gatunek = gatunek,
                                        datawydania = new DateTime(1999, 1, 1)
                                    };
                                    biblioteka.dodajksiazke(nowaKsiazka);
                                    Ksiazka ksiazka = new Ksiazka
                                    {
                                        id = 9,
                                        tytul = "a",
                                        autor = "a",
                                        wydawca = "a",
                                        gatunek = "a",
                                        datawydania = new DateTime(2020, 1, 1)
                                    };
                                    biblioteka.dodajksiazke(ksiazka);

                                    break;
                                case 2:
                                    Console.Write("Dodajesz klienta");
                                    Console.Write("ID: ");
                                    int idklienta = int.Parse(Console.ReadLine());
                                    Console.Write("Imie: ");
                                    string imie = Console.ReadLine();
                                    Console.Write("Nazwisko: ");
                                    string nazwisko = Console.ReadLine();
                                    Console.Write("Rok urodzenia: ");
                                    string dataUrodzenia = Console.ReadLine();
                                    Console.Write("Miejsce zamieszkania: ");
                                    string miejsceZamieszkania = Console.ReadLine();
                                    Klient nowyKlient = new Klient
                                    {
                                        id = idklienta,
                                        imie = imie,
                                        nazwisko = nazwisko,
                                        rok_urodzenia = new DateTime(1990, 1, 1),
                                        miejsce_zamieszkania = miejsceZamieszkania
                                    };
                                    biblioteka.dodajklienta(nowyKlient);
                                    Klient klient1 = new Klient
                                    {
                                        id = 9,
                                        imie = "a",
                                        nazwisko = "a",
                                        rok_urodzenia = new DateTime(1990, 1, 1),
                                        miejsce_zamieszkania = "a"
                                    };
                                    biblioteka.dodajklienta(klient1);

                                    break;
                                case 3:
                                    kontynuuj1 = false;
                                    break;
                                default:
                                    Console.WriteLine("Nie ma tylu opcji");
                                    break;
                            }
                            break;

                        case 2:
                            Console.Write("Wypozyczasz");
                            Console.Write("ID klienta, który wypozycza: ");
                            int idklienta1 = int.Parse(Console.ReadLine());
                            Wypozyczenia_zwrot wypozyczenie = new Wypozyczenia_zwrot
                            {
                                idklienta = idklienta1,
                                Datawypozyczenia = DateTime.Now,
                                Datazwrotu = DateTime.Now.AddDays(30)
                            };
                            //wypozyczenie.dodajidksiazki(1);
                            //biblioteka.dodajwypozyczenie(wypozyczenie);
                            //biblioteka.ZapiszDoPliku(nazwaPliku);
                            //Console.WriteLine($"Dane zostały zapisane do pliku o nazwie: {nazwaPliku}\n");
                            //break;
                            break;
                        case 3:
                            Console.WriteLine("Co chcesz wyswietlic\n");
                            Console.WriteLine("1. Klientow\n");
                            Console.WriteLine("2. Dostepne ksiazki\n");
                            Console.WriteLine("3. Koniec\n");
                            string nazwaPliku1 = Console.ReadLine();
                            Console.WriteLine("Informacje o klientach:\n");
                            Biblioteka odczytanaBiblioteka1 = Biblioteka.OdczytajZPliku(nazwaPliku1);
                            Console.WriteLine("Odczytane dane z pliku JSON:\n");
                            foreach (var klientOdczytany in odczytanaBiblioteka1.klienci)
                            {
                                Console.WriteLine($"Id: {klientOdczytany.id}, Imię: {klientOdczytany.imie}, Nazwisko: {klientOdczytany.nazwisko}");
                            }
                            int n2 = int.Parse(Console.ReadLine());
                            bool kontynuuj2 = true;

                            switch (n2)
                            {
                                case 1:
                                    Console.WriteLine("Wyswietl klientow:\n");
                                    string nazwaPliku2 = Console.ReadLine();
                                    Biblioteka odczytanaBiblioteka2 = Biblioteka.OdczytajZPliku(nazwaPliku2);
                                    Console.WriteLine("Odczytane dane z pliku JSON:\n");
                                    foreach (var klientOdczytany in odczytanaBiblioteka1.klienci)
                                    {
                                        Console.WriteLine($"Id: {klientOdczytany.id}, Imię: {klientOdczytany.imie}, Nazwisko: {klientOdczytany.nazwisko}");
                                    }
                                    break;

                                case 2:
                                    Console.WriteLine("Wyswietl dostepne ksiazki:\n");
                                    string nazwaPliku3 = Console.ReadLine();
                                    Biblioteka odczytanaBiblioteka3 = Biblioteka.OdczytajZPliku(nazwaPliku3);
                                    Console.WriteLine("Odczytane dane z pliku JSON:\n");
                                    foreach (var ksiazkaOdczytany in odczytanaBiblioteka3.ksiazki)
                                    {
                                        Console.WriteLine($"Id: {ksiazkaOdczytany.id}, Tytul: {ksiazkaOdczytany.tytul}, Autor: {ksiazkaOdczytany.autor}");
                                    }
                                    break;

                                case 3:
                                    kontynuuj2 = false;
                                    break;

                                default:
                                    Console.WriteLine("Nie ma takiej opcji\n");
                                    break;
                            }
                            break;

                        case 4:
                            kontynuuj = false;
                            break;

                        default:
                            Console.WriteLine("Nie ma takiej opcji\n");
                            break;
                    }
                } while (kontynuuj);
            }
        }
    }
}
