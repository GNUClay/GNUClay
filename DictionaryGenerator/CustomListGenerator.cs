using System;
using System.Collections.Generic;
using System.Text;

namespace DictionaryGenerator
{
    public static class CustomListGenerator
    {
        public static List<string> Get()
        {
            var wordsList = new List<string>() {
                "shower",
                "o'clock",
                "Tom"
            };

            return wordsList;
        }
    }
}
