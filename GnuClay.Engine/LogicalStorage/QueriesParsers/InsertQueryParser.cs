using GnuClay.Engine.CommonStorages;
using GnuClay.Engine.LogicalStorage.CommonData;
using GnuClay.Engine.LogicalStorage.InternalStorage;
using GnuClay.Engine.LogicalStorage.QueriesParsers.InternalParsers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

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
