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
    public class GnuClayEngineScriptsCallFunctionTests
    {
        [Test]
        public void CallUserDefinedFunction()
        {
            var tmpEngine = new GnuClayEngine();

            var numberKey = tmpEngine.Context.CommonKeysEngine.NumberKey;
            var n = 1;

            tmpEngine.AddLogHandler((IExternalValue value) => {
                switch (n)
                {
                    case 1:
                        Assert.AreEqual(value.TypeKey, numberKey);
                        Assert.AreEqual(value.Value, 1);
                        break;

                    default: throw new ArgumentOutOfRangeException(nameof(n), n, null);
                }

                n++;
            });


            var code = @"
            DEFINE { 
            fun run<!door!>($a: number, $b: number, $c: number)
                subj: dog;
                {
                    return 1;
                }
            }

            CALL {
                $var1 = dog.run<!door!>(1,2,3);

                console.log($var1);
            }";

            tmpEngine.Query(code);

            n = n - 1;

            Assert.AreEqual(n, 1);
        }
    }
}
