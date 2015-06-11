using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using DiffWords;
using System.IO;

namespace SlickerChatBot
{
    public partial class MainForm : Form
    {
        private WordNet wordNet;
        private OrfoepicDict orfoepic;

        public MainForm()
        {
            InitializeComponent();
        }

        List<string> words = new List<string>();

        private void button1_Click(object sender, EventArgs e)
        {
            Sentence sentence = new Sentence(textBox1.Text);

            foreach (Word w in sentence.Words)
                listBox1.Items.Add(w.Value);

            textBox2.Text = sentence.RuType;
            textBox3.Text = sentence.Length.ToString();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            Word currentWord = new Word(textBox4.Text);
            Word primaryWord = orfoepic.PrimaryForm(currentWord);

            if (primaryWord != null)
            {
                textBox5.Text = primaryWord.Value;
                currentWord = primaryWord; //переводим слово в начальную форму, так проще искать синонимы
            }
            else
            {
                textBox5.Text = "Не обнаружено";
            }

            List<string> synsets = wordNet.FindSynsets(currentWord);

            if (synsets != null)
                foreach (string s in synsets)
                    listBox2.Items.Add(s);
            else
                listBox2.Items.Add("Не обнаружено");

        }

        private void MainForm_Load(object sender, EventArgs e)
        {
            wordNet = new WordNet();
            orfoepic = new OrfoepicDict();
        }
    }
}
