using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.Odbc;
using System.Data;

namespace DiffWords
{
    public class DBReader
    {
        private OdbcConnection connect()
        {
            OdbcConnection con = new OdbcConnection("Driver=MySQL ODBC 5.3 Unicode Driver;Server=192.168.1.17;Port=3306;Database=solarix;User=root;Password=noins;Option=0;");
            return con;
        }

        public DataSet ExecQuery(string query)
        {
            OdbcConnection con = connect();
            con.Open();

            OdbcDataAdapter da = new OdbcDataAdapter();
            DataSet ds = new DataSet();
            da.SelectCommand = new OdbcCommand();
            OdbcCommandBuilder myCommandBuilder_DoubleBase = new OdbcCommandBuilder(da);
            da.SelectCommand.Connection = con;
            da.SelectCommand.CommandText = string.Format(query);
            da.Fill(ds);

            con.Close();

            return ds;
        }

        public DataSet GetForm()
        {
            return ExecQuery(string.Format(@"Select * from `sg_form`"));
        }

        public DataSet GetLexem()
        {
            return ExecQuery(string.Format(@"Select * from `sg_lexem`"));
        }

        public DataSet GetEntry()
        {
            return ExecQuery(string.Format(@"Select * from `sg_entry`"));
        }

        public DataSet GetClass()
        {
            return ExecQuery(string.Format(@"Select * from `sg_class`"));
        }
    }
}
