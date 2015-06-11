using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DiffWords
{
    interface ISynset
    {
        List<string> FindSynsets(Word _word);
    }
}
