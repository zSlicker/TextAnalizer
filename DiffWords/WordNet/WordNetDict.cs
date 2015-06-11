using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using System.Collections;
using System.Collections.ObjectModel;

namespace DiffWords
{
    public class WordNetDict
    {
        Dictionary<PartOfSpeech.Type, List<List<List<string>>>> _dict = new Dictionary<PartOfSpeech.Type, List<List<List<string>>>>();

        public WordNetDict()
        {
            Loading();
        }

        private static List<List<string>> ReadDict(PartOfSpeech.Type _type, string name)
        {
            List<List<string>> temp = new List<List<string>>();
            using (StreamReader sr = new StreamReader(@"C:\dict\wordnet\" + name + "." + _type.ToString().ToLower()))
            {
                while (!sr.EndOfStream)
                {
                    temp.Add(sr.ReadLine().Split(' ').ToList());
                }
            }
            return temp;
        }

        private void Loading()
        {
            foreach (PartOfSpeech.Type t in Enum.GetValues(typeof(PartOfSpeech.Type)))
                _dict.Add(t, new List<List<List<string>>>() { ReadDict(t, "index"), ReadDict(t, "data") });
        }

        //Коллекция листа листов листов по ключу с типом части речи. 
        //Хранит коллекцию коллекций с парами баз (база слов с кодами синонимов и база синонимов с доступом по коду)
        public Dictionary<PartOfSpeech.Type, List<List<List<string>>>> Dict
        {
            get
            {
                return _dict;
            }
        }
    }
}
