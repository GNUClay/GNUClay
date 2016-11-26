using GnuClay.Engine.CommonStorages;
using GnuClay.Engine.LogicalStorage.QueriesParsers.InternalParsers;
using GnuClay.Engine.Parser.CommonData;

namespace GnuClay.Engine.LogicalStorage.QueriesParsers
{
    public class SelectQueryParser
    {
        public SelectQueryParser(StorageDataDictionary dataDictionary)
        {
            mStorageDataDictionary = dataDictionary;
        }

        private StorageDataDictionary mStorageDataDictionary = null;

        public SelectQuery Run(string text)
        {
            var tmpProcess = new SelectQueryParserProcess(text, mStorageDataDictionary);

            return tmpProcess.Run();
        }
    }
}
