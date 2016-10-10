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
            mLogicalStorageEngine = new LogicalStorageEngine();
            mSelectQueryParser = new SelectQueryParser(mLogicalStorageEngine.DataDictionary);
            mInsertQueryParser = new InsertQueryParser(mLogicalStorageEngine.DataDictionary);
        }

        private LogicalStorageEngine mLogicalStorageEngine = null;
        private SelectQueryParser mSelectQueryParser = null;
        private InsertQueryParser mInsertQueryParser = null;

        public IReadOnlyStorageDataDictionary DataDictionary
        {
            get
            {
                return mLogicalStorageEngine.DataDictionary;
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

                mLogicalStorageEngine.InsertQuery(tmpInsertQuery);

                return null;
            }

            if(tmpFirstChars.StartsWith("select"))
            {
                var tmpSelectQuery = mSelectQueryParser.Run(text);
                
                return mLogicalStorageEngine.SelectQuery(tmpSelectQuery);
            }

            throw new NotImplementedException();
        }
    }
}
