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
        void Add(Dictionary<string, string> dic, FileStream file, StreamWriter sw);
        void Edit(Dictionary<string, string> dic, string file);
        void Delete(Dictionary<string, string> dic, string file);
        void Find(Dictionary<string, string> dic);
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
            FileStream file = new FileStream(type + ".txt", FileMode.OpenOrCreate);
            //StreamWriter sw = new StreamWriter(file);
            file.Close();
        }

        public void Add(Dictionary<string, string> dic, FileStream file, StreamWriter sw) {
            Console.Write("Enter word: ");
            string word = Console.ReadLine();
            Console.Write("Enter translate word: ");
            string t_word = Console.ReadLine();
            dic.Add(word, t_word);
            sw.WriteLine($"{word} - {t_word}");
        }

        public void Edit(Dictionary<string, string> dic, string file) {
            Console.Write("Enter word to change it: ");
            string find = Console.ReadLine();
            if (dic.ContainsKey(find)) {
                var lines = File.ReadAllLines(file).ToList();
                int index = lines.IndexOf(find + " - " + dic[find]);

                Console.Write("Enter new word: ");
                string word = Console.ReadLine();
                Console.Write("Enter new translate: ");
                string translate = Console.ReadLine();
                dic.Remove(find);
                lines.RemoveAt(index);

                string save = null;
                foreach (var i in dic) {
                    save += $"{i.Key} - {i.Value}\n";
                }
                File.WriteAllLines($"{file}", lines);
                dic.Add(word, translate);
                string text = null;
                foreach(var i in dic) {
                    text += $"{i.Key} - {i.Value}\n";
                }
                File.WriteAllText(file, text);
            }
            else { Console.WriteLine("Didn't find this word!"); }
        }

        public void Delete(Dictionary<string, string> dic, string file) {
            Console.Write("Enter word to delete: ");
            string word = Console.ReadLine();
            var lines = File.ReadAllLines(file).ToList();
            int index = lines.IndexOf(word + " - " + dic[word]);

            if (dic.ContainsKey(word)) {
                dic.Remove(word);
                lines.RemoveAt(index);
                File.WriteAllLines(file, lines);
            }
        }

        public void Find(Dictionary<string, string> dic) { 
            if(dic != null) {
                Console.Write("Enter word to find it: ");
                string word = Console.ReadLine();
                if (dic.ContainsKey(word)) {
                    Console.WriteLine($"{word} - {dic[word]}");
                }
                else {
                    foreach (var key in dic.Keys) {
                        if (dic[key] == word) {
                            Console.WriteLine($"{key} - {dic[key]}");
                        }
                    } 
                }
            }
        }

        public void Print() {
            Console.WriteLine($"  Type: {type}");
            /*foreach(var a in dictionary) {
                Console.WriteLine($"\t{a.Key} - {a.Value}");
            }*/
            StreamReader sr = new StreamReader(type + ".txt", Encoding.UTF8);
            Console.WriteLine(sr.ReadToEnd());
            sr.Close();
        }

    }
}
