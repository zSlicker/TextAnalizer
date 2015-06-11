using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;

namespace DiffWords
{
    public class GetPrimaryForm : IPrimaryForm
    {
        DBReader db = new DBReader();
        DataSet d;


        public Word PrimaryForm(Word _word)
        {
            d = db.GetWords();
            foreach (DataRow dr in d.Tables[0].Rows)
            {
                if (dr["name"].ToString().ToLower() == _word.Value.ToLower())
                {
                    string s = d.Tables[0].AsEnumerable().Where(x => x["id_entry"] == dr["id_entry"]).Where(x => x["iform"] == "0").First().ToString();
                    return new Word(s);
                }
            }

            return null;
        }

    }
}
