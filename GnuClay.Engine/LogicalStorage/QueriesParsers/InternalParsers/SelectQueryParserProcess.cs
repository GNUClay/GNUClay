using System;
using GnuClay.Engine.CommonStorages;
using GnuClay.Engine.Parser.CommonData;

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
