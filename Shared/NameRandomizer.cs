using System;
using System.Collections.Generic;
using System.Text;

namespace CryptoApp.Shared
{
    class NameRandomizer
    {
        static string[] adjectives = { "lyonnaise", "vacuous", "herbous", "duodenal", "doubting", "dramaturgic", "ladylike", "overfruitful", "ticklish", "nitrohydrochloric", "disbodied", "editorial", "irresistible", "windward", "controvertible", "colonial", "anopsia", "subfusk", "panderly", "incognitant", "elocutionary", "chargeful", "springall", "alarmable", "finespun", "elapine", "appetible", "gasometric", "ophthalmological", "subquinquefid" };
        static string[] nouns = { "impasting", "dexterity", "epuration", "lection", "nebalia", "pentameran", "arsesmart", "cheiropterygium", "reperusal", "nickeline", "bewrayment", "carronade", "renewing", "triviality", "cosmogonist", "mistrust", "juiciness", "murdress", "dentiscalp", "pyroborate", "subterfuge", "benefactress", "papaphobia", "pennant", "shinning", "clavicornes", "fopling", "biostatics", "compeller", "ostension" };
        public string RandomName()
        {
            string adjectiveName = adjectives[new Random().Next(0, adjectives.Length)];
            string nounName = nouns[new Random().Next(0, nouns.Length)];
            return adjectiveName + "-" + nounName;
        }
    }
}
