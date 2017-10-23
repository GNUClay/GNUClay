using GnuClay.CommonClientTypes.CommonData;
using GnuClay.Engine;
using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GnuClay.UnitTests.Engine
{
    [TestFixture]
    public class GnuClayEngineScriptsCallRemoteFunctionTests
    {
        [Test]
        public void Case1()
        {
            var tmpEngine = new GnuClayEngine();

            var dogKey = tmpEngine.GetKey("dog");
            var remoteKey = tmpEngine.GetKey("remote");
            var doorKey = tmpEngine.GetKey("door");
            var keyKey = tmpEngine.GetKey("$key");

            var externalFilter = new ExternalCommandFilter();
            externalFilter.HolderKey = dogKey;
            externalFilter.FunctionKey = remoteKey;
            externalFilter.TargetKey = doorKey;

            externalFilter.Params.Add(keyKey, new ExternalCommandFilterParam()
            {
            });

            var n = 1;

            externalFilter.Handler = (IExternalEntityAction action) =>
            {
                n++;
            };

            tmpEngine.AddRemoteFunction(externalFilter);

            var code = @"CALL {
                dog.remote<!door!>(1);
            }";

            tmpEngine.Query(code);

            n = n - 1;

            Assert.AreEqual(n, 1);
        }
    }
}
