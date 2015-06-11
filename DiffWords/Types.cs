using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DiffWords
{
    public class Types
    {
        public enum SenteceType
        {
            Interrogative, //вопросительное
            Exclamation, //восклицательное
            Narrative, //повествовательное
            Incentive, //побудительное
            None //Не известно
        }
        
        public static string ruSentenceType(SenteceType sentenceType)
        {
            Dictionary<SenteceType, string> ruSentenceTypes = new Dictionary<SenteceType, string>();
       
            ruSentenceTypes.Add(SenteceType.Exclamation, "Восклицательное");
            ruSentenceTypes.Add(SenteceType.Incentive, "Побудительное");
            ruSentenceTypes.Add(SenteceType.Interrogative, "Вопросительное");
            ruSentenceTypes.Add(SenteceType.Narrative, "Повествовательное");
            ruSentenceTypes.Add(SenteceType.None, "Не понятно");

            return ruSentenceTypes[sentenceType];
        }

    }
}
