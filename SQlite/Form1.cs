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

        private void Form1_Load(object sender, EventArgs e)
        {
            //DiffWords.DBReader db = new DiffWords.DBReader();
           // DataSet d = db.GetWords();
            DiffWords.GetPrimaryForm ft = new DiffWords.GetPrimaryForm();
            DiffWords.Word w = ft.PrimaryForm(new DiffWords.Word("петь"));
            
        }

       
    }
}
