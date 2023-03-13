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
            Dictionary dict = new Dictionary();
            dict.Create();
            FileStream file = new FileStream(dict.type + ".txt", FileMode.OpenOrCreate);

            dict.Add(dict.dictionary, file);
            dict.Print();
            file.Close();


        }
    }
}
