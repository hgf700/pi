//using System;
//using System.Drawing;
//using System.IO;

//namespace pi
//{
//    public class Wykres
//    {
//        private static string zapiszwykres = "..\wykres.txt"; // Replace with the actual file path

//        public static void Main()
//        {
//            Bitmap bm = new Bitmap(800, 400);

//            using (Graphics g = Graphics.FromImage(bm))
//            {
//                Brush[] br = { new SolidBrush(Color.Blue), new SolidBrush(Color.Red), new SolidBrush(Color.Green) };

//                if (!File.Exists(zapiszwykres))
//                {
//                    Console.WriteLine("Nie ma pliku");
//                }
//                else
//                {
//                    try
//                    {
//                        using (StreamReader sr = new StreamReader(zapiszwykres))
//                        {
//                            string str;
//                            int wx = 30;

//                            while ((str = sr.ReadLine()) != null)
//                            {
//                                string str2 = str.Substring(str.IndexOf(":") + 1);
//                                string[] str3 = str2.Split(new[] { ';' }, StringSplitOptions.RemoveEmptyEntries);

//                                for (int j = 0; j < str3.Length; j++)
//                                {
//                                    g.FillRectangle(br[j], wx, 370 - 10 * Convert.ToInt32(str3[j]), 3, 10 * Convert.ToInt32(str3[j]));
//                                    wx += 6;
//                                }

//                                g.DrawString(str.Substring(0, Math.Min(4, str.Length)), new Font(FontFamily.GenericSerif, 12), br[0], wx - 40, 375);
//                                wx += 80;
//                            }
//                        }
//                    }
//                    catch (Exception ex)
//                    {
//                        Console.WriteLine($"Błąd {ex.Message}");
//                    }
//                }
//            }
//            bm.Save(@"C:\Users\USER098\Documents\GitHub\PI\PI\bin\Debug\net6.0\output.png", System.Drawing.Imaging.ImageFormat.Png);
//        }
//    }
//}



//Dictionary<int, Wypozyczenia_zwrot> D = new Dictionary<int, Wypozyczenia_zwrot>();
//Hashtable H = new Hashtable();
//SortedList SL1 = new SortedList();
//SortedList<int, Wypozyczenia_zwrot> SL2 = new SortedList<int, Wypozyczenia_zwrot>();
//Wypozyczenia_zwrot[] A = new Wypozyczenia_zwrot[10];
//Wypozyczenia_zwrot[] B = new Wypozyczenia_zwrot[10];
//for (int i = 0; i < A.Length; i++)
//{


//    A[i] = new Wypozyczenia_zwrot() { wypozyczenialiczba = new BitArray(new bool[2] { true, true }) };

//    B[i] = new Wypozyczenia_zwrot() { wypozyczenialiczba = new BitArray(new bool[2] { true, true }) };
//}
//for (int i = 0; i < A.Length; i++)

//{

//    A[i] = new Wypozyczenia_zwrot();

//    A[i].wypozyczenialiczba = B[i].wypozyczenialiczba;
//    A[i].klient = B[i].klient;


//}
//Console.WriteLine($"{A[0].klient} ilosc {A[0].wypozyczenialiczba}");
//while ((s1 = sr.ReadLine()) != null)

//{

//    string s2 = s1.Substring(s1.IndexOf(':') + 1);

//    string[] s3 = s2.Split(new string[] { ";" }, StringSplitOptions.RemoveEmptyEntries);

//    Console.ReadLine();

//}
//sr.Close();
