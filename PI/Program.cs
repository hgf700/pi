
using System;
using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.IO;
using Newtonsoft.Json;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.IO;

namespace pi
{
    class Program
    {
        static void Main()
        {
            bool kontynuuj = true;
            do
            {

                Console.WriteLine("Wybierz 1 z opcji\n");
                Console.WriteLine("1. Tworzenie klienta lub ksiazki");
                Console.WriteLine("2. wypozyczenie");
                Console.WriteLine("3. Wyświetlenie");
                Console.WriteLine("4. Stwórz raport użytkowania biblioteki");
                Console.WriteLine("9. Zakończ program\n");

                int n = int.Parse(Console.ReadLine());
                Biblioteka biblioteka = new Biblioteka();
                //////////////////////////////////////
                string nazwaPliku = @"C:\Users\USER098\Documents\GitHub\PI\PI\zapisanedane.txt";
                //string zapiszwykres = @"C:\Users\USER098\Documents\GitHub\PI\PI\\wykres.txt";
                //string wypozyczoneteraz = @"C:\Users\USER098\Documents\GitHub\PI\PI\wypozyczoneteraz.txt";

                switch (n)
                {
                    case 1:
                        Console.WriteLine("Co chcesz zrobic\n");
                        Console.WriteLine("1. Dodac ksiazke");
                        Console.WriteLine("2. Dodac klienta");
                        Console.WriteLine("3. Zmiana wyboru\n");
                        int n1 = int.Parse(Console.ReadLine());

                        switch (n1)
                        {
                            case 1:
                                Console.Write("Dodajesz ksiazke\n");
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
                                    Id = idKsiazki,
                                    tytul = tytul,
                                    autor = autor,
                                    wydawca = wydawca,
                                    gatunek = gatunek,
                                    datawydania = new DateTime(1999, 1, 1)
                                };
                                biblioteka.dodajksiazke(nowaKsiazka);
                                biblioteka.ZapiszDoPlikuTekstowego(nazwaPliku);

                                break;
                            case 2:
                                Console.Write("Dodajesz klienta\n");
                                Console.Write("ID: ");
                                int idklienta = int.Parse(Console.ReadLine());
                                Console.Write("Imie: ");
                                string imie = Console.ReadLine();
                                Console.Write("Nazwisko: ");
                                string nazwisko = Console.ReadLine();
                                Console.Write("Miejsce zamieszkania: ");
                                string miejsceZamieszkania = Console.ReadLine();
                                Klient nowyKlient = new Klient
                                {
                                    Id = idklienta,
                                    imie = imie,
                                    nazwisko = nazwisko,
                                    rok_urodzenia = new DateTime(1990, 1, 1),
                                    miejsce_zamieszkania = miejsceZamieszkania
                                };
                                biblioteka.DodajKlienta(nowyKlient);
                                biblioteka.ZapiszDoPlikuTekstowego(nazwaPliku);
                                break;
                            case 3:
                                break;
                            default:
                                Console.WriteLine("Nie ma tylu opcji\n");
                                break;
                        }
                        break;

                    case 2:


                        Console.Write("Wypożyczasz\n");
                        Console.Write("ID klienta, który wypożycza: ");
                        int idKlienta = int.Parse(Console.ReadLine());


                        Klient klient = biblioteka.klienci.FirstOrDefault(k => k.Id == idKlienta);

                        if (klient == null)
                        {
                            Console.WriteLine("Nie znaleziono klienta o podanym ID.");
                            return;
                        }

                        Console.Write("Jaka ksiazke chcesz wypożyczyć: ");
                        int idksiazki = int.Parse(Console.ReadLine());
                        Ksiazka ksiazka = biblioteka.ksiazki.FirstOrDefault(ks => ks.Id == idksiazki);

                        if (ksiazka == null)
                        {
                            Console.WriteLine("Nie znaleziono książki o podanym ID.");
                            return;
                        }

                        Wypozyczenia_zwrot wypozyczenie = new Wypozyczenia_zwrot
                        {
                            klient = klient,
                            Datawypozyczenia = DateTime.Now,
                            Datazwrotu = DateTime.Now.AddDays(30),
                            ksiazka = ksiazka
                        };


                        //if (wypozyczenie.klient.WypozyczoneKsiazki.Count >= 3)
                        //{
                        //    Console.WriteLine("Osiągnięto limit wypożyczonych książek.");
                        //}
                        //else
                        //{
                        biblioteka.DodajWypozyczenie(wypozyczenie,ksiazka);
                            biblioteka.ZapiszDoPlikuTekstowego(nazwaPliku);
                        //}

                        break;

                    case 3:


                        Console.WriteLine("Co chcesz wyswietlic\n");
                        Console.WriteLine("1. Klientow");
                        Console.WriteLine("2. Dostepne ksiazki");
                        Console.WriteLine("3. Zmiana wyboru");

                        int n2 = int.Parse(Console.ReadLine());

                        switch (n2)
                        {
                            case 1:
                                Console.WriteLine("Wyswietl klientow:\n");

                                Biblioteka odczytanaBiblioteka2 = Biblioteka.OdczytajZPlikuTekstowego(nazwaPliku);
                                Console.WriteLine("Odczytane dane:\n");
                                foreach (var klientOdczytany in odczytanaBiblioteka2.klienci)
                                {
                                    Console.WriteLine($"Id: {klientOdczytany.Id}, Imię: {klientOdczytany.imie}, Nazwisko: {klientOdczytany.nazwisko}");
                                }
                                break;

                            case 2:
                                Console.WriteLine("Wyswietl dostepne ksiazki:\n");
                                Biblioteka odczytanaBiblioteka3 = Biblioteka.OdczytajZPlikuTekstowego(nazwaPliku);
                                Console.WriteLine("Odczytane dane:\n");
                                foreach (var ksiazkaOdczytany in odczytanaBiblioteka3.ksiazki)
                                {
                                    Console.WriteLine($"Id: {ksiazkaOdczytany.Id}, Tytul: {ksiazkaOdczytany.tytul}, Autor: {ksiazkaOdczytany.autor}");
                                }
                                break;

                            case 3:
                                break;

                            default:
                                Console.WriteLine("Nie ma takiej opcji\n");
                                break;
                        }
                        break;
                    case 4:
                        Console.WriteLine("Wyswietlam raport\n");

                        Console.WriteLine($"Ilosc dodanych ksiazek {biblioteka.IloscKsiazek}");
                        Console.WriteLine($"Ilosc dodanych klientow {biblioteka.IloscKlientow}");
                        Console.WriteLine($"Ilosc dodanych wypozyczen {biblioteka.IloscWypozyczen}\n");

                        

                        break;

                    case 9:
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
//lepsza struktura klass porozdzielane wyswietlanie wykresow stopa wypozyczen na wykresach itd(wykresy moze using p3pr google charts?)
// mam pomysl ze wypozyczenie bede tworzyl w podobny sposob jak wyswietlam i wtedy to powinno chyba dzialac
// czas do lutego