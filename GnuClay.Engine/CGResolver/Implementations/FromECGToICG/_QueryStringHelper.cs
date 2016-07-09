using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GnuClay.Engine.CGResolver.Implementations.FromECGToICG
{
    public static class _QueryStringHelper
    {
        public static NodeNameInfo CreateNodeNameInfo(string name)
        {
            NLog.LogManager.GetCurrentClassLogger().Info("CreateNodeNameInfo name = {0}", name);

            if(string.IsNullOrWhiteSpace(name))
            {
                throw new ArgumentNullException(nameof(name));
            }

            throw new NotImplementedException();
        }
    }
}
