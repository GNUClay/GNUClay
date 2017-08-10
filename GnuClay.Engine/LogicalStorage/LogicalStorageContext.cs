using GnuClay.Engine.LogicalStorage.InternalResolver;
using GnuClay.Engine.LogicalStorage.InternalStorage;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GnuClay.Engine.LogicalStorage
{
    public class LogicalStorageContext
    {
        public InternalStorageEngine InternalStorageEngine = null;
        public InternalResolverEngine InternalResolverEngine = null;
        public ASTTransformer ASTTransformer = null;
    }
}
