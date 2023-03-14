using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Exam_task_Dictionary
{
    internal class Program
    {
        static void Main(string[] args)
        {
            /*Dictionary dict = new Dictionary();
            dict.Create();
            FileStream fs = new FileStream(dict.type + ".txt", FileMode.Open);
            StreamWriter sw = new StreamWriter(fs);
            dict.Add(dict.dictionary, fs, sw);
            dict.Add(dict.dictionary, fs, sw);
            sw.Close();

            //dict.Delete(dict.dictionary, dict.type + ".txt");
            //dict.Edit(dict.dictionary, dict.type + ".txt");
            dict.Print();*/


            Dictionary dict = new Dictionary();

            Console.WriteLine("Welcome to dictionary!");
            bool exit = false;
            while (exit != true) {
                Console.Write("Choose process:   1.Create  2.Add  3.Edit  4.Delete  5.Print  6.Exit\nAnswer: ");
                try {
                    string c = Console.ReadLine();
                    int choose = Convert.ToInt32(c);
                    switch (choose) {
                        case 1:
                            dict.Create();
                            Console.WriteLine();
                            break;

                        case 2:
                            FileStream fs = new FileStream(dict.type + ".txt", FileMode.Append);
                            StreamWriter sw = new StreamWriter(fs);
                            dict.Add(dict.dictionary, fs, sw);
                            sw.Close();
                            
                            break;

                        case 3:
                            dict.Edit(dict.dictionary, dict.type + ".txt");
                            Console.WriteLine();
                            break;

                        case 4:
                            dict.Delete(dict.dictionary, dict.type + ".txt");
                            Console.WriteLine();
                            break;

                        case 5:
                            dict.Print();
                            Console.WriteLine();
                            break;

                        case 6:
                            exit = true;
                            break;
                    }
                }
                catch (Exception ex) { Console.WriteLine($"\nОшибка!\n{ex.Message}\n"); }
            }



        }
    }
}
