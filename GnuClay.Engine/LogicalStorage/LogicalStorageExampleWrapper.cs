using GnuClay.Engine.CommonStorages;
using GnuClay.Engine.LogicalStorage.CommonData;
using GnuClay.Engine.Parser.CommonData;
using System;

namespace GnuClay.Engine.LogicalStorage
{
    public class LogicalStorageExampleWrapper
    {
        public LogicalStorageExampleWrapper()
        {
            mGnuClayEngine = new GnuClayEngine();
        }

        private GnuClayEngine mGnuClayEngine = null;

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

            var query = mGnuClayEngine.Context.ParserEngine.Parse(text);

            switch(query.Kind)
            {
                case GnuClayQueryKind.INSERT:
                    mGnuClayEngine.LogicalStorage.InsertQuery(query.InsertQuery);
                    return null;

                case GnuClayQueryKind.SELECT:
                    return mGnuClayEngine.LogicalStorage.SelectQuery(query.SelectQuery);

                default: throw new ArgumentOutOfRangeException(nameof(query.Kind));
            }

            throw new NotImplementedException();
        }
    }
}
