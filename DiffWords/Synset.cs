using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DiffWords
{
    public class Synset
    {
        public List<string> FindSynset(Word _word)
        {
            List<string> list = new List<string>();

            list = FindVerbSynset(_word);
            if (list == null)
                list = FindAdvSynset(_word);
            if (list == null)
                list = FindNounSynset(_word);
            if (list == null)
                list = FindAdjSynset(_word);

            return list;
        }
    }
}
