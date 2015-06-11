using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace DiffWords
{
    public class WordNet : ISynset
    {

        WordNetDict wordNet;

        public WordNet()
        {
            wordNet = new WordNetDict();
            //string s = WordNetDict.Dict[PartOfSpeech.Type.Noun][0][0][0];
            /* WordNetDict(PartOfSpeech.Type.Verb);
             WordNetDict(PartOfSpeech.Type.Noun);
              WordNetDict(PartOfSpeech.Type.Adj);
             WordNetDict(PartOfSpeech.Type.Adv);*/
        }

        public List<string> FindSynsets(Word _word)
        {
            List<string> temp = new List<string>();

            temp = DetectSynsetFromDict(PartOfSpeech.Type.Noun, _word);
            if (temp == null)
                temp = DetectSynsetFromDict(PartOfSpeech.Type.Verb, _word);
            if (temp == null)
                temp = DetectSynsetFromDict(PartOfSpeech.Type.Adv, _word);
            if (temp == null)
                temp = DetectSynsetFromDict(PartOfSpeech.Type.Adj, _word);

            return temp;
        }

        private List<string> DetectSynsetFromDict(PartOfSpeech.Type partOfSpeech, Word _word)
        {
            List<string> synset_int = new List<string>(); //id синонимов для найденного слова
            List<string> synset = new List<string>(); //синонимы

            //Ищем id синонимов для слова
            foreach (List<string> list in wordNet.Dict[partOfSpeech][0])
            {
                if (list.Contains(_word.Value))
                {
                    int count_synset = int.Parse(list[2]);
                    int count_symbols = int.Parse(list[3]);
                    int firstSynset = 4 + count_symbols + 2;

                    for (int i = firstSynset; i < firstSynset + count_synset; i++)
                    {
                        synset_int.Add(list[i]);
                    }
                }
            }

            //по id ищем сами синонимы
            for (int i = 0; i < synset_int.Count; i++)
            {
                foreach (List<string> list in wordNet.Dict[partOfSpeech][1])
                {
                    if (list.Contains(synset_int[i]))
                    {
                        int count_syn = int.Parse(list[3]);

                        for (int j = 4; j < 4 + (count_syn * 2); j += 2)
                        {
                            synset.Add(list[j]);
                        }
                    }
                }
            }

            if (synset.Count > 0)
            {
                synset = synset.Distinct().OrderBy(x => x).ToList();
            }
            else
                synset = null;

            return synset;
        }
    }
}
