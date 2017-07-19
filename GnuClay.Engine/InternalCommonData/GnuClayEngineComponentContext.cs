using GnuClay.CommonUtils.Tasking;
using GnuClay.Engine.CommonStorages;
using GnuClay.Engine.Inheritance;
using GnuClay.Engine.LogicalStorage;
using GnuClay.Engine.Parser;
using GnuClay.Engine.RemoteEvents;
using GnuClay.Engine.ScriptExecutor;
using GnuClay.Engine.Serialization;
using GnuClay.Engine.StandardLibrary;

namespace GnuClay.Engine.InternalCommonData
{
    public class GnuClayEngineComponentContext
    {
        public ActiveContext ActiveContext = null;
        public SerializationEngine SerializationEngine = null;
        public StorageDataDictionary DataDictionary = null;
        public StandardLibraryEngine StandardLibrary = null;
        public LogicalStorageEngine LogicalStorage = null;
        public ScriptExecutorEngine ScriptExecutor = null;
        public RemoteEventsEngine RemoteEventsEngine = null;
        public GnuClayParserEngine ParserEngine = null;
        public InheritanceEngine InheritanceEngine = null;
    }
}
