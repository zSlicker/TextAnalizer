using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DiffWords
{
    public class Sentence
    {
        private string Text = null;

        public Sentence(string Text)
        {
            this.Text = Text;
        }

        public Types.SenteceType Type
        {
            get { return DetectSentenceType(); }
            //  private set;
        }

        public int Length
        {
            get { return Text.Length; }
            //  private set;
        }

        public string RuType
        {
            get { return GetSentenceType(); }
            //  private set;
        }

        public List<Word> AllWords
        {
            get
            {
                List<Word> result = new List<Word>();

                string[] replace = new string[] { ",", ".", "?", ":", ";", "!", "_" };

                string tempText = "";

                foreach (string s in replace)
                    tempText = Text.Replace(s, " ");

                result = tempText.Split(' ').Where(str => !String.IsNullOrEmpty(str)).Select(str => new Word(str.Trim())).ToList();

                return result;
            }
        }

        private Types.SenteceType DetectSentenceType()
        {
            Types.SenteceType type = Types.SenteceType.None;

            if (!String.IsNullOrEmpty(Text))
            {
                Text = Text.Replace(")", "");
                Text = Text.Replace(":", "");
                Text = Text.Replace("=", "");
                Text = Text.Replace("^", "");
                Text = Text.Replace("_", "");

                int lastIndex = Text.Length - 1;

                if (lastIndex >= 1)
                {
                    switch (Text[lastIndex].ToString())
                    {
                        case "?":
                            type = Types.SenteceType.Interrogative;
                            break;
                        case "!":
                            type = Types.SenteceType.Exclamation;
                            break;
                        case ".":
                            type = Types.SenteceType.Narrative;
                            break;
                        /*  default:
                              type = Types.SenteceType.Narrative;
                              break;*/
                    }
                }
                //Если предложение неизвестно то проверяем на вопросительность
                if (type == Types.SenteceType.None)
                {
                    foreach (string word in Enum.GetNames(typeof(Constants.VerbWords)))
                        foreach (Word w in this.AllWords)
                            if (w.Value == word)
                                type = Types.SenteceType.Interrogative;
                }

                //Если предложение неизвестно или повеств. или восклиц. то проверяем на побудительность
                if (type == Types.SenteceType.Narrative ||
                   type == Types.SenteceType.Exclamation ||
                   type == Types.SenteceType.None)
                {
                    foreach (string word in Enum.GetNames(typeof(Constants.IncentiveWords)))
                        foreach (Word w in this.AllWords)
                            if (w.Value == word)
                                type = Types.SenteceType.Incentive;
                }

                if (type == Types.SenteceType.None)
                {
                    type = Types.SenteceType.Narrative;
                }
            }

            return type;
        }

        private string GetSentenceType()
        {
            return Types.ruSentenceType(Type);
        }
    }
}
