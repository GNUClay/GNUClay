using GnuClay.CommonUtils.Tasking;
using GnuClay.Engine.CommonStorages;
using GnuClay.Engine.Inheritance;
using GnuClay.Engine.InternalBus;
using GnuClay.Engine.LogicalStorage;
using GnuClay.Engine.Parser;
using GnuClay.Engine.RemoteFunctions;
using GnuClay.Engine.ScriptExecutor;
using GnuClay.Engine.ScriptExecutor.Compiler;
using GnuClay.Engine.Serialization;
using GnuClay.Engine.StandardLibrary;
using GnuClay.Engine.Triggers;

namespace GnuClay.Engine.InternalCommonData
{
    public class GnuClayEngineComponentContext
    {
        public ActiveContext ActiveContext = null;
        public SerializationEngine SerializationEngine = null;
        public StorageDataDictionary DataDictionary = null;
        public StandardLibraryEngine StandardLibrary = null;
        public LogicalStorageEngine LogicalStorage = null;
        public GnuClayScriptCompiler ScriptCompiler = null;
        public ScriptExecutorEngine ScriptExecutor = null;
        public RemoteFunctionsEngine RemoteFunctionsEngine = null;
        public GnuClayParserEngine ParserEngine = null;
        public InheritanceEngine InheritanceEngine = null;
        public ErrorsFactory ErrorsFactory = null;
        public ConstTypeProvider ConstTypeProvider = null;
        public FunctionsEngine FunctionsEngine = null;
        public UserDefinedFunctionsStorage UserDefinedFunctionsStorage = null;
        public InternalBusEngine InternalBusEngine = null;
        public TriggersEngine TriggersEngine = null;
        public PropertiesEngine PropertiesEngine = null;
        public CommonValuesFactory CommonValuesFactory = null;
        public CommonKeysEngine CommonKeysEngine = null;
    }
}
