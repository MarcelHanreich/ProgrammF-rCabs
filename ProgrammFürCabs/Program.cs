using System.Diagnostics;
using System.Globalization;
using System.IO.Compression;
using System.Media;
using System.Net.Http.Headers;
using System.Runtime.Intrinsics.X86;
using System.Text;

namespace ProgrammFürCabs
{
    internal class Program
    {
        static void PrintCWS()
        {
            for (int i = 0; i < 20; i++)
            {
                Console.WriteLine();
            }
        }
        static ZITATE[] ReadCSVFile(string fileName)
        {
            string[] lines = File.ReadAllLines(fileName, Encoding.Default);
            ZITATE[] zitate = new ZITATE[lines.Length];

            for (int i = 0; i < zitate.Length; i++)
            {
                ZITATE zitat = new ZITATE();

                string[] line = lines[i].Split(';');

                zitat.SetZitat(line[0]);
                zitat.SetErgebnis(line[1]);
                zitat.SetAnswer1(line[2]);
                zitat.SetAnswer2(line[3]);

                zitate[i] = zitat;
            }

            return zitate;
        }

        static int PrintGame(ZITATE[] zitate)
        {
            string[] lines = File.ReadAllLines("filmzitatecabsss.csv", Encoding.Default);
            int[] numbers = GenerateRandomNumbers(9);
            int count = 0;
           
            for (int i = 0; i < zitate.Length; i++)
            {
                PrintCWS();
                Console.SetCursorPosition(120, Console.CursorTop);
                Console.WriteLine($"{zitate[numbers[i]].GetZitat()}");
                int cl = 0;
                
                int[] lala = GenerateRandomNumbers(3);

                for (int j = 0; j < 3; j++)
                {
                    
                    Console.SetCursorPosition(120 + cl, Console.CursorTop);
                    if (lala[j] == 0)
                    {
                        Console.Write($"({j + 1}) {zitate[numbers[i]].GetAnswer1()} ");
                    }
                    else if (lala[j] == 1)
                    {
                        Console.Write($"({j + 1}) {zitate[numbers[i]].GetAnswer2()} ");
                    }
                    else if (lala[j] == 2)
                    {
                        Console.Write($"({j + 1}) {zitate[numbers[i]].GetErgebnis()} ");
                    }

                    cl = cl + 20;
                }

                Console.WriteLine();
                Console.SetCursorPosition(120, Console.CursorTop);
                Console.Write("Antwort: ");
                string answer = Console.ReadLine()!;

                Console.Clear();

                if (answer == "ENDE")
                {
                    break;
                }

                else if (answer == zitate[numbers[i]].GetErgebnis())
                {
                    count++;
                    int c = 0;
                    PrintCWS();
                    Console.SetCursorPosition(120, Console.CursorTop);
                    Console.WriteLine($"{zitate[numbers[i]].GetZitat()}");

                    for (int j = 0; j < 3; j++)
                    {
                        Console.SetCursorPosition(120 + c, Console.CursorTop);
                        if (lala[j] == 0)
                        {
                            Console.Write($"({j + 1}) {zitate[numbers[i]].GetAnswer1()} ");
                        }
                        else if (lala[j] == 1)
                        {
                            Console.Write($"({j + 1}) {zitate[numbers[i]].GetAnswer2()} ");
                        }
                        else if (lala[j] == 2)
                        {
                            Console.ForegroundColor = ConsoleColor.Yellow;
                            Console.Write($"({j + 1}) {zitate[numbers[i]].GetErgebnis()} ");
                            Console.ForegroundColor = ConsoleColor.Gray;
                        }

                        c = c + 20;
                    }

                }

                else
                {
                    PrintCWS();
                    Console.SetCursorPosition(120, Console.CursorTop);
                    Console.WriteLine($"{zitate[numbers[i]].GetZitat()}");
                    int c = 0;

                    for (int j = 0; j < 3; j++)
                    {
                        Console.SetCursorPosition(120 + c, Console.CursorTop);
                        if (lala[j] == 0)
                        {
                            
                            Console.ForegroundColor = ConsoleColor.Red;
                            Console.Write($"({j + 1}) {zitate[numbers[i]].GetAnswer1()} ");
                            Console.ForegroundColor = ConsoleColor.Gray;
                        }
                        else if (lala[j] == 1)
                        {
                            
                            Console.ForegroundColor = ConsoleColor.Red;
                            Console.Write($"({j + 1}) {zitate[numbers[i]].GetAnswer2()} ");
                            Console.ForegroundColor = ConsoleColor.Gray;
                        }
                        else if (lala[j] == 2)
                        {
                            Console.ForegroundColor = ConsoleColor.Yellow;
                            Console.Write($"({j + 1}) {zitate[numbers[i]].GetErgebnis()} ");
                            Console.ForegroundColor = ConsoleColor.Gray;
                        }

                        c = c + 20;
                    }
                }

                Thread.Sleep(5000);
                Console.Clear();
                
            }

            return count;

        }
        static int[] GenerateRandomNumbers(int count)
        {
            Random random = new Random();
            int[] randomNumbers = new int[count];

            for (int i = 0; i < count; i++)
            {
                randomNumbers[i] = i;
            }

            for (int i = 0; i < count - 1; i++)
            {
                int randomIndex = random.Next(i, count);
                int temp = randomNumbers[i];
                randomNumbers[i] = randomNumbers[randomIndex];
                randomNumbers[randomIndex] = temp;
            }

            return randomNumbers;
        }

        static void PrintFilm()
        {
            string[] lines = File.ReadAllLines("film.txt", Encoding.Default);
            int startLine = 5;

            for (int i = 0; i < startLine; i++)
            {
                Console.WriteLine();
            }

            foreach (string line in lines)
            {
                int leftPadding = 100;
                Console.SetCursorPosition(leftPadding, Console.CursorTop);
                Console.WriteLine(line);
            }

        }

        static void PrintGamerTag()
        {
            string[] lines = File.ReadAllLines("game.txt", Encoding.Default);
            int startLine = 12;

            for (int i = 0; i < startLine; i++)
            {
                Console.WriteLine();
            }

            foreach (string line in lines)
            {
                int leftPadding = 100;
                Console.SetCursorPosition(leftPadding, Console.CursorTop);
                Console.WriteLine(line);
            }
        }
        static void Main(string[] args)
        {
            Console.OutputEncoding = Encoding.UTF8;
            string fileName = "filmzitatecabsss.csv";
            ZITATE[] zitate = ReadCSVFile(fileName);
            SoundPlayer musik = new SoundPlayer("Kahoot.wav");
            musik.PlayLooping();

            PrintFilm();

            Console.CursorVisible = false;
            Console.ReadKey();
            PrintGamerTag();
            Console.Clear();

            int count = PrintGame(zitate);
            Console.SetCursorPosition(120, Console.CursorTop);
            Console.WriteLine($"Sie haben {count} von 9 Fragen richtig beantwortet.");

        }

    }
}