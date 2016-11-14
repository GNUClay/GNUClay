using GnuClay.Engine.CommonStorages;
using GnuClay.Engine.LogicalStorage.CommonData;
using GnuClay.Engine.LogicalStorage.DebugHelpers;
using GnuClay.Engine.LogicalStorage.InternalStorage;
using GnuClay.Engine.LogicalStorage.QueriesParsers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GnuClay.Engine.LogicalStorage
{
    public class LogicalStorageExampleWrapper
    {
        public LogicalStorageExampleWrapper()
        {
            mGnuClayEngine = new GnuClayEngine();
            mSelectQueryParser = new SelectQueryParser(mGnuClayEngine.DataDictionary);
            mInsertQueryParser = new InsertQueryParser(mGnuClayEngine.DataDictionary);
        }

        private GnuClayEngine mGnuClayEngine = null;
        private SelectQueryParser mSelectQueryParser = null;
        private InsertQueryParser mInsertQueryParser = null;

        public IReadOnlyStorageDataDictionary DataDictionary
        {
            get
            {
                return mGnuClayEngine.DataDictionary;
            }
        }

        public SelectResult Query(string text)
        {
            if (string.IsNullOrWhiteSpace(text))
            {
                throw new ArgumentNullException(nameof(text));
            }

            var tmpFirstChars = text.Substring(0, 6).ToLower();

            if (tmpFirstChars.StartsWith("insert"))
            {
                var tmpInsertQuery = mInsertQueryParser.Run(text);

                mGnuClayEngine.LogicalStorage.InsertQuery(tmpInsertQuery);

                return null;
            }

            if(tmpFirstChars.StartsWith("select"))
            {
                var tmpSelectQuery = mSelectQueryParser.Run(text);
                
                return mGnuClayEngine.LogicalStorage.SelectQuery(tmpSelectQuery);
            }

            throw new NotImplementedException();
        }
    }
}
