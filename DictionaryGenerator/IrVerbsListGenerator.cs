using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace DictionaryGenerator
{
    public static class IrVerbsListGenerator
    {
        public static List<string> Get()
        {
            var irregularVerbsSource = new IrregularVerbsSource();
            var irregularItemsList = irregularVerbsSource.ReadAll();

            return irregularItemsList.Select(p => p.RootWord).Distinct().ToList();
        }
    }
}
