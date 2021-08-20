using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Prosjekt_opgave
{
    class Program
    {
        static void Main(string[] args)
        {
            //variabler
            string telefonnr, navn, adrress, postnr, by, email, linje, funktion, søgetekst;
            int tæller = 0;
            
            //læser vær linje fra fillen ind i et string array.
            string[] lines = System.IO.File.ReadAllLines(@"C:\Users\Basse\Desktop\Kartotek.txt");
            do
            {
                //Overskeft/tittel
                Console.SetCursorPosition(3, 1);
                Console.WriteLine("<<<                      Christian Mørk Information System   -   Gæste-registrering  v1.0                      >>>");

                //undskriver menu til skærm
                Console.SetCursorPosition(3, 4);
                Console.WriteLine("Telefon nr. :");

                Console.SetCursorPosition(3, 5);
                Console.WriteLine("Navn        :");

                Console.SetCursorPosition(3, 6);
                Console.WriteLine("Adresse     :");

                Console.SetCursorPosition(3, 7);
                Console.WriteLine("Postnr      :");

                Console.SetCursorPosition(3, 8);
                Console.WriteLine("By          :");

                Console.SetCursorPosition(3, 9);
                Console.WriteLine("Email       :");

                Console.SetCursorPosition(3, 24);
                Console.WriteLine("[O] Opret   [F] Find   [V] Vis Alle   [Q] Afslut :");

                //skriver fra tastatur
                Console.SetCursorPosition(3, 26);
                Console.Write("Vælg funktion: ");
                funktion = Console.ReadLine().ToUpper();

                //undersøger Imput fra tastaturet
                if (funktion == "O")
                {


                    //skriver fra tastatur
                    Console.SetCursorPosition(17, 4);
                    Console.Write("");
                    telefonnr = Console.ReadLine();

                    //undersøger om telefon nr. allerede eksistere
                    if (System.IO.File.ReadLines(@"C:\Users\Basse\Desktop\Kartotek.txt").Any(line => line.Contains(telefonnr)))
                    {
                        Console.Clear();
                        Console.WriteLine("Fejl Telefon nr. eksitere allerede");
                        Console.ReadKey();
                        Console.Clear();
                    }

                    else
                    {
                        //skriver fra tastatur
                        Console.SetCursorPosition(17, 5);
                        Console.Write("");
                        navn = Console.ReadLine();

                        Console.SetCursorPosition(17, 6);
                        Console.Write("");
                        adrress = Console.ReadLine();

                        Console.SetCursorPosition(17, 7);
                        Console.Write("");
                        postnr = Console.ReadLine();

                        Console.SetCursorPosition(17, 8);
                        Console.Write("");
                        by = Console.ReadLine();

                        Console.SetCursorPosition(17, 9);
                        Console.Write("");
                        email = Console.ReadLine();

                        //indskrivning til fill
                        linje = telefonnr + " " + navn + " " + adrress + " " + postnr + " " + by + " " + email;
                        using (System.IO.StreamWriter file = new System.IO.StreamWriter(@"C:\Users\Basse\Desktop\Kartotek.txt", true))
                        {
                            file.WriteLine(linje);
                        }
                        Console.Clear();

                        Console.SetCursorPosition(3, 1);
                        Console.WriteLine("<<<                      Christian Mørk Information System   -   Gæste-registrering  v1.0                      >>>");

                        Console.WriteLine("Dine uplysninger er blevet gemt");
                        Console.ReadKey();
                        Console.Clear();
                    }


                }
                else if (funktion == "F")
                {
                    //clear skærmen
                    Console.Clear();

                    Console.SetCursorPosition(3, 1);
                    Console.WriteLine("<<<                      Christian Mørk Information System   -   Gæste-registrering  v1.0                      >>>");

                    //skriver fra tastatur
                    Console.SetCursorPosition(3, 3);
                    Console.Write("Skriv hvad du søger efter: ");
                    søgetekst = Console.ReadLine();

                    //Viser fillens indhold ved at bruge en fereach løkke
                    Console.SetCursorPosition(3, 5);
                    System.Console.WriteLine("Kartotekets Indhold");
                    Console.WriteLine();
                    foreach (string line in lines)
                    {
                        //undersøger Imput fra tastaturet
                        if (line.Contains(søgetekst))
                        {
                            //sætter * forand dem der inholder det man søger efter
                            Console.Write("*");
                        }

                        tæller++;

                        //udsikriver kartotekets inhold 15 personer af gangen
                        Console.WriteLine("\t" + line);
                        if (tæller == 15)
                        {
                            Console.ReadKey();
                            Console.Clear();
                            tæller = 0;

                            Console.SetCursorPosition(3, 1);
                            Console.WriteLine("<<<                      Christian Mørk Information System   -   Gæste-registrering  v1.0                      >>>");

                            Console.SetCursorPosition(3, 3);
                            System.Console.WriteLine("Kartotekets Indhold");
                            Console.WriteLine(" ");

                        }
                    }
                    Console.ReadKey();
                    Console.Clear();
                    tæller = 0;
                }
                else if (funktion == "V")
                {
                    //clear skærmen
                    Console.Clear();

                    Console.SetCursorPosition(3, 1);
                    Console.WriteLine("<<<                      Christian Mørk Information System   -   Gæste-registrering  v1.0                      >>>");

                    //Viser fillens indhold ved at bruge en fereach løkke
                    Console.SetCursorPosition(3, 3);
                    System.Console.WriteLine("Kartotekets Indhold");
                    Console.WriteLine();
                    foreach (string line in lines)
                    {

                        tæller++;
                        // udsikriver kartotekets inhold 15 personer af gangen
                        Console.WriteLine("\t" + line);
                        if (tæller == 15)
                        {
                            Console.ReadKey();
                            Console.Clear();
                            tæller = 0;

                            Console.SetCursorPosition(3, 1);
                            Console.WriteLine("<<<                      Christian Mørk Information System   -   Gæste-registrering  v1.0                      >>>");

                            Console.SetCursorPosition(3, 3);
                            System.Console.WriteLine("Kartotekets Indhold");
                            Console.WriteLine();
                        }
                    }
                    Console.ReadKey();
                    Console.Clear();
                    tæller = 0;
                }
                else if (funktion == "Q")
                {

                }
                else
                {
                    //clear skærmen
                    Console.Clear();

                    Console.WriteLine("Fejl ved input af funktion!");
                    Console.ReadKey();
                    Console.Clear();
                }

            } while (funktion != "Q");

            Console.ReadKey();


        }
    }
}
