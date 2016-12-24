using GnuClay.CommonUtils.Tasking;
using GnuClay.Engine.CommonStorages;
using GnuClay.Engine.LogicalStorage;
using GnuClay.Engine.Parser;
using GnuClay.Engine.RemoteEvents;
using GnuClay.Engine.ScriptExecutor;
using GnuClay.Engine.StandardLibrary;
using GnuClay.Engine.StandardLibrary.SupportingMachines;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace GnuClay.Engine.InternalCommonData
{
    public class GnuClayEngineComponentContext
    {
        public ActiveContext ActiveContext = null;
        public StorageDataDictionary DataDictionary = null;
        public StandardLibraryEngine StandardLibrary = null;
        public LogicalStorageEngine LogicalStorage = null;
        public ScriptExecutorEngine ScriptExecutor = null;
        public TypeProcessingContext TypeProcessingContext = null;
        public RemoteEventsEngine RemoteEventsEngine = null;
        public GnuClayParserEngine ParserEngine = null;
    }
}
