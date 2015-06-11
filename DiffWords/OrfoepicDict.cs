using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace DiffWords
{
    public class OrfoepicDict : IPrimaryForm
    {
        private List<List<string>> Nouns;

        public OrfoepicDict()
        {
            Nouns = ReadDict();
        }

        public Word PrimaryForm(Word _word)
        {
            foreach (List<string> n in this.Nouns)
            {
                if (n.Contains(_word.Value))
                {
                    return new Word(n[0]);
                }
            }

            return null;
        }

        private List<List<string>> ReadDict()
        {
            List<List<string>> result = new List<List<string>>();
            List<string> temp = new List<string>();

            foreach (string s in File.ReadLines(@"C:\dict\orfoepic.txt"))
            {
                if (!string.IsNullOrEmpty(s.Trim()))
                    temp.Add(s.Split(new string[] { " | " }, StringSplitOptions.RemoveEmptyEntries)[0].Trim());
                else
                {
                    result.Add(new List<string>(temp));
                    temp = new List<string>();
                }
            }
            return result;
        }
    }
}
