using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Exam_task_Dictionary
{
    interface CreateDictionary {
        void Create();
    }
    interface EditDictionary {
        void Add(Dictionary<string, string> dic, FileStream fs);
        
    }
    interface PrintDictionary {
        void Print();
    }

    class Dictionary : CreateDictionary, EditDictionary, PrintDictionary
    {
        public Dictionary<string, string> dictionary;
        public string type;

        public Dictionary() { }    
        public Dictionary(Dictionary<string, string> word) {
            dictionary = word;
        }

        public void Create() {
            dictionary = new Dictionary<string, string>();
            Console.Write("Enter type of dictionary: ");
            type = Console.ReadLine();
        }

        public void Add(Dictionary<string, string> dic, FileStream fs) {
            Console.Write("Enter word: ");
            string word = Console.ReadLine();
            Console.Write("Enter translate word: ");
            string t_word = Console.ReadLine();
            dic.Add(word, t_word);
            /*StreamWriter write_file = new StreamWriter(fs);
            write_file.WriteLine(dic);
            foreach(var item in dic) {
                write_file.Write($"{item.Key} - {item.Value}");
            }*/
        }

        public void Print() {
            Console.WriteLine($"Type: {type}");
            foreach(var a in dictionary) {
                Console.WriteLine($"{a.Key} - {a.Value}");
            }
        }

    }
}
