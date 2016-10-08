using GnuClay.Engine.LogicalStorage.CommonData;
using GnuClay.Engine.LogicalStorage.InternalStorage;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using GnuClay.CommonUtils.TypeHelpers;

namespace GnuClay.Engine.LogicalStorage.QueriesParsers.InternalParsers
{
    public class SelectQueryParserProcess
    {
        public SelectQueryParserProcess(string text, StorageDataDictionary dataDictionary)
        {
            if (string.IsNullOrWhiteSpace(text))
            {
                throw new ArgumentNullException(nameof(text));
            }

            mText = text;
            mStorageDataDictionary = dataDictionary;
        }

        private StorageDataDictionary mStorageDataDictionary = null;
        private string mText = string.Empty;

        public SelectQuery Run()
        {
            NLog.LogManager.GetCurrentClassLogger().Info($"Run `{mText}`");

            var tmpLexer = new Lexer(mText);

            try
            {
                var tmpTokensList = tmpLexer.Run();

                NLog.LogManager.GetCurrentClassLogger().Info(_ListHelper._ToString(tmpTokensList, nameof(tmpTokensList)));
            }
            catch(Exception e)
            {
                NLog.LogManager.GetCurrentClassLogger().Info(e.ToString());
            }

            return null;
            //throw new NotImplementedException();
        }
    }
}
