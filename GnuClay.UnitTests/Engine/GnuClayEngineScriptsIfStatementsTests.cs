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
    public class GnuClayEngineScriptsIfStatementsTests
    {
        [Test]
        public void If_WithoutElse_Case1()
        {
            var tmpEngine = new GnuClayEngine();
            var numberKey = tmpEngine.Context.CommonKeysEngine.NumberKey;

            var n = 1;

            tmpEngine.AddLogHandler((IExternalValue value) =>
            {
                Assert.AreEqual(value.Kind, ExternalValueKind.Value);

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

            var code = @"CALL{
                $var1 = true;
                $var2 = 0;
                if($var1){
                    $var2 = 1;
                };

                console.log($var2);
            }";

            tmpEngine.Query(code);

            n = n - 1;

            Assert.AreEqual(n, 1);
        }

        [Test]
        public void If_WithoutElse_Case2()
        {
            var tmpEngine = new GnuClayEngine();
            var numberKey = tmpEngine.Context.CommonKeysEngine.NumberKey;

            var n = 1;

            tmpEngine.AddLogHandler((IExternalValue value) =>
            {
                Assert.AreEqual(value.Kind, ExternalValueKind.Value);

                switch (n)
                {
                    case 1:
                        Assert.AreEqual(value.TypeKey, numberKey);
                        Assert.AreEqual(value.Value, 0);
                        break;

                    default: throw new ArgumentOutOfRangeException(nameof(n), n, null);
                }

                n++;
            });

            var code = @"CALL{
                $var1 = false;
                $var2 = 0;
                if($var1){
                    $var2 = 1;
                };

                console.log($var2);
            }";

            tmpEngine.Query(code);

            n = n - 1;

            Assert.AreEqual(n, 1);
        }

        [Test]
        public void If_Else_Case1()
        {
            var tmpEngine = new GnuClayEngine();

            var numberKey = tmpEngine.Context.CommonKeysEngine.NumberKey;

            var n = 1;

            tmpEngine.AddLogHandler((IExternalValue value) =>
            {
                Assert.AreEqual(value.Kind, ExternalValueKind.Value);

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

            var code = @"CALL{
                $var1 = true;
                if($var1){
                    $var2 = 1;
                }else{
                    $var2 = 2;
                };

                console.log($var2);
            }";

            tmpEngine.Query(code);

            n = n - 1;

            Assert.AreEqual(n, 1);
        }

        [Test]
        public void If_Else_Case2()
        {
            var tmpEngine = new GnuClayEngine();

            var numberKey = tmpEngine.Context.CommonKeysEngine.NumberKey;

            var n = 1;

            tmpEngine.AddLogHandler((IExternalValue value) =>
            {
                Assert.AreEqual(value.Kind, ExternalValueKind.Value);

                switch (n)
                {
                    case 1:
                        Assert.AreEqual(value.TypeKey, numberKey);
                        Assert.AreEqual(value.Value, 2);
                        break;

                    default: throw new ArgumentOutOfRangeException(nameof(n), n, null);
                }

                n++;
            });

            var code = @"CALL{
                $var1 = false;
                if($var1){
                    $var2 = 1;
                }else{
                    $var2 = 2;
                };

                console.log($var2);
            }";

            tmpEngine.Query(code);

            n = n - 1;

            Assert.AreEqual(n, 1);
        }
    }
}
