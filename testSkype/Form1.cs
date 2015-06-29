using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using SKYPE4COMLib;
using DiffWords;
using System.Data.SQLite;
using System.Data.Sql;

namespace testSkype
{
    public partial class Form1 : Form
    {
        private WordNet wordNet;
        private OrfoepicDict orfoepic;
        Skype skype_machine;

        DiffWords.AnalizeWord aw;

        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            wordNet = new WordNet();
            orfoepic = new OrfoepicDict();

            skype_machine = new Skype();
            skype_machine.Attach(7, false);
            skype_machine.MessageStatus += new _ISkypeEvents_MessageStatusEventHandler(skype_MessageStatus);

            aw = new DiffWords.AnalizeWord();
        }

        private void skype_MessageStatus(ChatMessage msg, TChatMessageStatus status)
        {

            if (status == TChatMessageStatus.cmsRead)
                msg.Chat.SendMessage(getMessage(msg.Body));

        }

        private string getMessage(string Text)
        {
            string result = "";

            Sentence sentence = new Sentence(Text);

            result += "Тип предложения: " + sentence.RuType + Environment.NewLine;
            // result += "Длина предложения: " + sentence.Length.ToString() + Environment.NewLine;
            result += "Ключевые слова: " + Environment.NewLine;
            foreach (Word s in sentence.AllWords)
            {
                Word currentWord = s;


                currentWord = aw.Analize(currentWord);

                result += currentWord.Value + "" + Environment.NewLine;

                if (currentWord.FirstForm != null)
                {
                    result += "Начальная форма: ";
                    result += " - " + currentWord.FirstForm + "; ";
                    result += Environment.NewLine;

                    result += "Часть речи: ";
                    result += " - " + currentWord.PartOfSpeech + "; ";
                }

                /*Word primaryWord = orfoepic.Analize(currentWord);



                result += s.Value + "" + Environment.NewLine;

                if (primaryWord != null)
                {
                    result += "Начальная форма: ";

                    result += " - " + primaryWord.Value + "; ";
                    currentWord = new Word(primaryWord.Value);

                    result += Environment.NewLine;
                }

              /*   List<string> synsets = wordNet.FindSynsets(currentWord);


               if (synsets != null)
                {
                    result += "Синонимы: ";

                    foreach (string synset in synsets)
                        result += " - " + synset + "; ";
                }*/

                result += Environment.NewLine;
            }

            return result;
        }
    }
}
