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
    public class GnuClayEngineScriptsArithmeticOperatorsTests
    {
        [Test]
        public void AddOperatorCase1()
        {
            var tmpEngine = new GnuClayEngine();

            var nullKey = tmpEngine.Context.CommonKeysEngine.NullTypeKey;
            var numberKey = tmpEngine.Context.CommonKeysEngine.NumberKey;

            var n = 0;

            tmpEngine.AddLogHandler((IExternalValue value) => {
                n++;

                Assert.AreEqual(value.Kind, ExternalValueKind.Value);

                switch (n)
                {
                    case 1:
                    case 2:
                    case 3:              
                        Assert.AreEqual(value.TypeKey, nullKey);
                        Assert.AreEqual(value.Value, null);
                        break;

                    case 4:
                        Assert.AreEqual(value.TypeKey, numberKey);
                        Assert.AreEqual(value.Value, 2);
                        break;

                    default: throw new ArgumentOutOfRangeException(nameof(n), n, null);
                }
            });


            var code = @"CALL {
                console.log(null + 2);
                console.log(1 + null);
                console.log(null + null);
                console.log(1 + 1);
            }";

            tmpEngine.Query(code);

            Assert.AreNotEqual(n, 0);
        }

        [Test]
        public void SubOperatorCase1()
        {
            var tmpEngine = new GnuClayEngine();

            var n = 0;

            tmpEngine.AddLogHandler((IExternalValue value) => {
                n++;

                switch (n)
                {
                    default: throw new ArgumentOutOfRangeException(nameof(n), n, null);
                }
            });


            var code = @"";

            tmpEngine.Query(code);

            Assert.AreNotEqual(n, 0);

            throw new NotImplementedException();
        }

        [Test]
        public void MulOperatorCase1()
        {
            var tmpEngine = new GnuClayEngine();

            throw new NotImplementedException();
        }

        [Test]
        public void DivOperatorCase1()
        {
            var tmpEngine = new GnuClayEngine();

            throw new NotImplementedException();
        }
    }
}
