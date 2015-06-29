using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;

namespace DiffWords
{
    public class AnalizeWord : IPrimaryForm
    {
        DBReader db = new DBReader();
        //  DataSet d;
        DataSet form;
        DataSet entry;
        DataSet TableClass;

        public AnalizeWord()
        {
            form = db.GetForm();
            entry = db.GetEntry();
            TableClass = db.GetClass();
        }

        public Word Analize(Word _word)        
        {
            try
            {
                
                int entryID = 0;
                int lexemID = 0;
                int _class = 0;

                foreach (DataRow dr in form.Tables[0].Rows)
                {
                    if (dr["name"].ToString().ToLower() == _word.Value.ToLower())
                    {
                        entryID = Convert.ToInt32(dr["id_entry"].ToString());
                        lexemID = Convert.ToInt32(dr["id_lexem"].ToString());
                        break;
                    }
                }


                

                _class = entry.Tables[0].AsEnumerable()
                            .Where
                            (dataRow => Convert.ToInt32(dataRow["id"].ToString()) == entryID)
                            .Select
                            (dataRow => Convert.ToInt32(dataRow["id_class"].ToString())).First();

                string firstForm = entry.Tables[0].AsEnumerable()
                            .Where
                            (dataRow => Convert.ToInt32(dataRow["id"].ToString()) == entryID)
                            .Select
                            (dataRow => dataRow["name"].ToString()).First();

                

                string className = TableClass.Tables[0].AsEnumerable()
                            .Where
                            (dataRow => Convert.ToInt32(dataRow["id"].ToString()) == _class)
                            .Select
                            (dataRow => dataRow["name"].ToString()).First();


                _word.PartOfSpeech = className;
                _word.FirstForm = firstForm;
            }
            catch
            {

            }
            return _word;
        }

    }
}
