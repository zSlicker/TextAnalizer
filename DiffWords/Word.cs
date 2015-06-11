using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace DiffWords
{
    public class Word // : IGrouping<string, string>
    {
        private string _word = "";

        public Word(string Word)
        {
            this._word = Word;

            //заглушка
            string[] replace = new string[] { "!", "@", "#", "$", "%", "^", "&", "*", "(", ")", "=", @"\", "/", "<", ">", "?", ".", ",", "_" };

            foreach (string r in replace)
                this._word = this._word.Replace(r, " ");

            this._word = this._word.Trim();
        }

        public string Value
        {
            get { return _word; }
            set { }
        }

        public string PartOfSpeech
        {
            get;
            private set;
        }        
    }
}
