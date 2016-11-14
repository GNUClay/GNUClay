using GnuClay.Engine.LogicalStorage.CommonData;
using GnuClay.Engine.LogicalStorage.InternalStorage;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using GnuClay.CommonUtils.TypeHelpers;
using GnuClay.Engine.CommonStorages;

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
            var tmpLexer = new Lexer(mText);

            var tmpTokensList = tmpLexer.Run();

            var tmpContext = new InternalParserContext(tmpTokensList, mStorageDataDictionary);

            var tmpInternalSelectQueryParser = new InternalSelectQueryParser(tmpContext);

            tmpInternalSelectQueryParser.Run();

            return tmpInternalSelectQueryParser.Result;
        }
    }
}
