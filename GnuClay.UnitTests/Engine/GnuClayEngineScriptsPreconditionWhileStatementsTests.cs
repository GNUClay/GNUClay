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
    public class GnuClayEngineScriptsPreconditionWhileStatementsTests
    {
        [Test]
        public void OneLoop()
        {
            var tmpEngine = new GnuClayEngine();

            var numberKey = tmpEngine.Context.CommonKeysEngine.NumberKey;
            var booleanKey = tmpEngine.Context.CommonKeysEngine.BooleanKey;

            var n = 1;

            tmpEngine.AddLogHandler((IExternalValue value) =>
            {
                Assert.AreEqual(value.Kind, ExternalValueKind.Value);

                switch (n)
                {
                    case 1:
                        Assert.AreEqual(value.TypeKey, booleanKey);
                        Assert.AreEqual(value.Value, 1);
                        break;

                    case 2:
                        Assert.AreEqual(value.TypeKey, numberKey);
                        Assert.AreEqual(value.Value, 1);
                        break;

                    case 3:
                        Assert.AreEqual(value.TypeKey, booleanKey);
                        Assert.AreEqual(value.Value, 0);
                        break;

                    default: throw new ArgumentOutOfRangeException(nameof(n), n, null);
                }

                n++;
            });

            var code = @"CALL{
                $var1 = true;

                $var2 = 0;

                console.log($var1);

                while($var1)
                {
                    $var2 += 1;
                    $var1 = false;

                    console.log($var2);
                };

                console.log($var1);
            }";

            tmpEngine.Query(code);

            n = n - 1;

            Assert.AreEqual(n, 3);
        }

        [Test]
        public void SeveralLoops()
        {
            var tmpEngine = new GnuClayEngine();

            var numberKey = tmpEngine.Context.CommonKeysEngine.NumberKey;
            var booleanKey = tmpEngine.Context.CommonKeysEngine.BooleanKey;

            var n = 1;

            tmpEngine.AddLogHandler((IExternalValue value) =>
            {
                Assert.AreEqual(value.Kind, ExternalValueKind.Value);

                switch (n)
                {
                    case 1:
                        Assert.AreEqual(value.TypeKey, booleanKey);
                        Assert.AreEqual(value.Value, 1);
                        break;

                    case 2:
                        Assert.AreEqual(value.TypeKey, numberKey);
                        Assert.AreEqual(value.Value, 1);
                        break;

                    case 3:
                        Assert.AreEqual(value.TypeKey, numberKey);
                        Assert.AreEqual(value.Value, 2);
                        break;

                    case 4:
                        Assert.AreEqual(value.TypeKey, numberKey);
                        Assert.AreEqual(value.Value, 3);
                        break;

                    case 5:
                        Assert.AreEqual(value.TypeKey, booleanKey);
                        Assert.AreEqual(value.Value, 0);
                        break;

                    default: throw new ArgumentOutOfRangeException(nameof(n), n, null);
                }

                n++;
            });

            var code = @"CALL{
                $var1 = true;

                $var2 = 0;

                console.log($var1);

                while($var1)
                {
                    $var2 += 1;

                    if($var2 == 3)
                    {
                         $var1 = false;
                    };
                    
                    console.log($var2);
                };

                console.log($var1);
            }";

            tmpEngine.Query(code);

            n = n - 1;

            Assert.AreEqual(n, 5);
        }

        [Test]
        public void NoneLoops()
        {
            var tmpEngine = new GnuClayEngine();

            var numberKey = tmpEngine.Context.CommonKeysEngine.NumberKey;
            var booleanKey = tmpEngine.Context.CommonKeysEngine.BooleanKey;

            var n = 1;

            tmpEngine.AddLogHandler((IExternalValue value) =>
            {
                Assert.AreEqual(value.Kind, ExternalValueKind.Value);

                switch (n)
                {
                    case 1:
                        Assert.AreEqual(value.TypeKey, booleanKey);
                        Assert.AreEqual(value.Value, 0);
                        break;

                    case 2:
                        Assert.AreEqual(value.TypeKey, booleanKey);
                        Assert.AreEqual(value.Value, 0);
                        break;

                    default: throw new ArgumentOutOfRangeException(nameof(n), n, null);
                }

                n++;
            });

            var code = @"CALL{
                $var1 = false;

                $var2 = 0;

                console.log($var1);

                while($var1)
                {
                    $var2 += 1;
                    $var1 = false;

                    console.log($var2);
                };

                console.log($var1);
            }";

            tmpEngine.Query(code);

            n = n - 1;

            Assert.AreEqual(n, 2);
        }
    }
}
