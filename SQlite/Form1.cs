using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.SQLite;
using System.Data.Sql;
using System.IO;
using System.Data.Odbc;

namespace SQlite
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        DiffWords.AnalizeWord aw;

        private void Form1_Load(object sender, EventArgs e)
        {
            aw = new DiffWords.AnalizeWord();  
        }

        private void button1_Click(object sender, EventArgs e)
        {
            DiffWords.Sentence sentence = new DiffWords.Sentence(textBox1.Text);

            foreach (DiffWords.Word s in sentence.AllWords)
            {
                DiffWords.Word w = aw.Analize(s);

                listBox1.Items.Add(w.Value);
                listBox2.Items.Add(w.FirstForm);
                listBox3.Items.Add(w.PartOfSpeech);
            }
        }
    }
}
