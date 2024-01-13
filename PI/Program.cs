using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using Newtonsoft.Json;

namespace pi
{
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
                string nazwaPliku = @"C:\Users\USER098\source\repos\PI\PI\bin\Debug\net6.0\a.txt";
                switch (n)
                {
                    case 1:
                       
                        

                        Biblioteka biblioteka = new Biblioteka();

                        Console.WriteLine("Co chcesz zrobic");
                        Console.WriteLine("1. Dodac ksiazke");
                        Console.WriteLine("2. Dodac klienta");
                        Console.WriteLine("3. Zakoncz program");
                        int n1 = int.Parse(Console.ReadLine());
                        

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

                                //Ksiazka ksiazka = new Ksiazka
                                //{
                                //    id = 9,
                                //    tytul = "a",
                                //    autor = "a",
                                //    wydawca = "a",
                                //    gatunek = "a",
                                //    datawydania = new DateTime(2020, 1, 1)
                                //};
                                //biblioteka.dodajksiazke(ksiazka);
                                biblioteka.ZapiszDoPlikuTekstowego(nazwaPliku);

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

                                //Klient klient1 = new Klient
                                //{
                                //    id = 9,
                                //    imie = "a",
                                //    nazwisko = "a",
                                //    rok_urodzenia = new DateTime(1990, 1, 1),
                                //    miejsce_zamieszkania = "a"
                                //};
                                //biblioteka.dodajklienta(klient1);
                                biblioteka.ZapiszDoPlikuTekstowego(nazwaPliku);

                                break;
                            case 3:
                                
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

                        //biblioteka.dodajwypozyczenie(wypozyczenie);
                        //biblioteka.ZapiszDoPlikuTekstowego(nazwaPliku);
                        ///*Console.WriteLine($"Dane zostały zapisane do pliku o nazwie: {nazwaPliku1}\n")*/;

                        break;
                        case 3:
                        
                        
                        Console.WriteLine("Co chcesz wyswietlic\n");
                        Console.WriteLine("1. Klientow\n");
                        Console.WriteLine("2. Dostepne ksiazki\n");
                        Console.WriteLine("3. Koniec\n");

                        Biblioteka odczytanaBiblioteka1 = Biblioteka.OdczytajZPlikuTekstowego(nazwaPliku);

                        int n2 = int.Parse(Console.ReadLine());
                        bool kontynuuj2 = true;

                        switch (n2)
                        {
                            case 1:
                                Console.WriteLine("Wyswietl klientow:\n");

                                Biblioteka odczytanaBiblioteka2 = Biblioteka.OdczytajZPlikuTekstowego(nazwaPliku);
                                Console.WriteLine("Odczytane dane z pliku JSON:\n");
                                foreach (var klientOdczytany in odczytanaBiblioteka2.klienci)
                                {
                                    Console.WriteLine($"Id: {klientOdczytany.id}, Imię: {klientOdczytany.imie}, Nazwisko: {klientOdczytany.nazwisko}");
                                }
                                break;

                            case 2:
                                Console.WriteLine("Wyswietl dostepne ksiazki:\n");
                                Biblioteka odczytanaBiblioteka3 = Biblioteka.OdczytajZPlikuTekstowego(nazwaPliku);
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