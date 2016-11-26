using GnuClay.Engine.CommonStorages;
using GnuClay.Engine.LogicalStorage.QueriesParsers.InternalParsers;
using GnuClay.Engine.Parser.CommonData;

namespace GnuClay.Engine.LogicalStorage.QueriesParsers
{
    public class InsertQueryParser
    {
        public InsertQueryParser(StorageDataDictionary dataDictionary)
        {
            mStorageDataDictionary = dataDictionary;
        }

        private StorageDataDictionary mStorageDataDictionary = null;

        public InsertQuery Run(string text)
        {
            var tmpProcess = new InsertQueryParserProcess(text, mStorageDataDictionary);

            return tmpProcess.Run();
        }
    }
}
