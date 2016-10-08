using GnuClay.Engine.LogicalStorage.CommonData;
using GnuClay.Engine.LogicalStorage.InternalStorage;
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
            NLog.LogManager.GetCurrentClassLogger().Info($"Run `{text}`");

            throw new NotImplementedException();
        }
    }
}
