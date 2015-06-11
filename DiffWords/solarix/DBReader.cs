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

        public DataSet GetWords()
        {
            OdbcConnection con = connect();
            con.Open();

            OdbcDataAdapter da = new OdbcDataAdapter();
            DataSet ds = new DataSet();
            da.SelectCommand = new OdbcCommand();
            OdbcCommandBuilder myCommandBuilder_DoubleBase = new OdbcCommandBuilder(da);
            da.SelectCommand.Connection = con;
            da.SelectCommand.CommandText = string.Format(@"Select * from `sg_form`");
            da.Fill(ds);
            return ds;
        }
    }
}
