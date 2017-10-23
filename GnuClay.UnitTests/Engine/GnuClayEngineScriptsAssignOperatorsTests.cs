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
    public class GnuClayEngineScriptsAssignOperatorsTests
    {
        [Test]
        public void AssignOperatorCase1()
        {
            var tmpEngine = new GnuClayEngine();

            var n = 1;

            tmpEngine.AddLogHandler((IExternalValue value) => {
                switch (n)
                {
                    default: throw new ArgumentOutOfRangeException(nameof(n), n, null);
                }

                n++;
            });


            var code = @"CALL {
            
            }";

            tmpEngine.Query(code);

            n = n - 1;

            //Assert.AreEqual(n, );

            throw new NotImplementedException();
        }

        [Test]
        public void AssignOperatorCase2()
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


            var code = @"CALL {
                $var1 = 1;

                console.log($var1);
            }";

            tmpEngine.Query(code);

            n = n - 1;

            Assert.AreEqual(n, 1);
        }

        [Test]
        public void PlusAssingOperatorCase1()
        {
            var tmpEngine = new GnuClayEngine();

            var n = 1;

            tmpEngine.AddLogHandler((IExternalValue value) => {
                switch (n)
                {
                    default: throw new ArgumentOutOfRangeException(nameof(n), n, null);
                }

                n++;
            });


            var code = @"CALL {
            
            }";

            tmpEngine.Query(code);

            n = n - 1;

            //Assert.AreEqual(n, );

            throw new NotImplementedException();
        }

        [Test]
        public void PlusAssingOperatorCase2()
        {
            var tmpEngine = new GnuClayEngine();

            var numberKey = tmpEngine.Context.CommonKeysEngine.NumberKey;

            var n = 1;

            tmpEngine.AddLogHandler((IExternalValue value) => {
                switch (n)
                {
                    case 1:
                        Assert.AreEqual(value.TypeKey, numberKey);
                        Assert.AreEqual(value.Value, 3);
                        break;

                    default: throw new ArgumentOutOfRangeException(nameof(n), n, null);
                }

                n++;
            });


            var code = @"CALL {
                $var1 = 1;
                $var1 += 2;

                console.log($var1);
            }";

            tmpEngine.Query(code);

            n = n - 1;

            Assert.AreEqual(n, 1);
        }

        [Test]
        public void MinusAssingOperatorCase1()
        {
            var tmpEngine = new GnuClayEngine();

            var n = 1;

            tmpEngine.AddLogHandler((IExternalValue value) => {
                switch (n)
                {
                    default: throw new ArgumentOutOfRangeException(nameof(n), n, null);
                }

                n++;
            });


            var code = @"CALL {
            
            }";

            tmpEngine.Query(code);

            n = n - 1;

            //Assert.AreEqual(n, );

            throw new NotImplementedException();
        }

        [Test]
        public void MinusAssingOperatorCase2()
        {
            var tmpEngine = new GnuClayEngine();

            var numberKey = tmpEngine.Context.CommonKeysEngine.NumberKey;

            var n = 1;

            tmpEngine.AddLogHandler((IExternalValue value) => {
                switch (n)
                {
                    case 1:
                        Assert.AreEqual(value.TypeKey, numberKey);
                        Assert.AreEqual(value.Value, -1);
                        break;

                    default: throw new ArgumentOutOfRangeException(nameof(n), n, null);
                }

                n++;
            });


            var code = @"CALL {
                $var1 = 1;
                $var1 -= 2;

                console.log($var1);
            }";

            tmpEngine.Query(code);

            n = n - 1;

            Assert.AreEqual(n, 1);
        }

        [Test]
        public void MulAssingOperatorCase1()
        {
            var tmpEngine = new GnuClayEngine();

            var n = 1;

            tmpEngine.AddLogHandler((IExternalValue value) => {
                switch (n)
                {
                    default: throw new ArgumentOutOfRangeException(nameof(n), n, null);
                }

                n++;
            });


            var code = @"CALL {
            
            }";

            tmpEngine.Query(code);

            n = n - 1;

            //Assert.AreEqual(n, );

            throw new NotImplementedException();
        }

        [Test]
        public void MulAssingOperatorCase2()
        {
            var tmpEngine = new GnuClayEngine();

            var numberKey = tmpEngine.Context.CommonKeysEngine.NumberKey;

            var n = 1;

            tmpEngine.AddLogHandler((IExternalValue value) => {
                switch (n)
                {
                    case 1:
                        Assert.AreEqual(value.TypeKey, numberKey);
                        Assert.AreEqual(value.Value, 6);
                        break;

                    default: throw new ArgumentOutOfRangeException(nameof(n), n, null);
                }

                n++;
            });


            var code = @"CALL {
                $var1 = 3;
                $var1 *= 2;

                console.log($var1);
            }";

            tmpEngine.Query(code);

            n = n - 1;

            Assert.AreEqual(n, 1);
        }

        [Test]
        public void DivAssingOperatorCase1()
        {
            var tmpEngine = new GnuClayEngine();

            var n = 1;

            tmpEngine.AddLogHandler((IExternalValue value) => {
                switch (n)
                {
                    default: throw new ArgumentOutOfRangeException(nameof(n), n, null);
                }

                n++;
            });


            var code = @"CALL {
            
            }";

            tmpEngine.Query(code);

            n = n - 1;

            //Assert.AreEqual(n, );

            throw new NotImplementedException();
        }

        [Test]
        public void DivAssingOperatorCase2()
        {
            var tmpEngine = new GnuClayEngine();

            var numberKey = tmpEngine.Context.CommonKeysEngine.NumberKey;

            var n = 1;

            tmpEngine.AddLogHandler((IExternalValue value) => {
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


            var code = @"CALL {
                $var1 = 4;
                $var1 /= 2;

                console.log($var1);
            }";

            tmpEngine.Query(code);

            n = n - 1;

            Assert.AreEqual(n, 1);
        }

        [Test]
        public void AssingFactOperatorCase1()
        {
            var tmpEngine = new GnuClayEngine();

            var n = 1;

            tmpEngine.AddLogHandler((IExternalValue value) => {
                switch (n)
                {
                    default: throw new ArgumentOutOfRangeException(nameof(n), n, null);
                }

                n++;
            });


            var code = @"CALL {
            
            }";

            tmpEngine.Query(code);

            n = n - 1;

            //Assert.AreEqual(n, );

            throw new NotImplementedException();
        }

        [Test]
        public void AssingFactOperatorCase2()
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

                    case 2:
                        Assert.AreEqual(value.TypeKey, numberKey);
                        Assert.AreEqual(value.Value, 1);
                        break;

                    default: throw new ArgumentOutOfRangeException(nameof(n), n, null);
                }

                n++;
            });


            var code = @"CALL {
                $var2 = $var1 << 1;
                console.log($var1);
                console.log($var2);
            }";

            tmpEngine.Query(code);

            n = n - 1;

            Assert.AreEqual(n, 2);
        }

        [Test]
        public void PlusAssingFactOperatorCase1()
        {
            var tmpEngine = new GnuClayEngine();

            var n = 1;

            tmpEngine.AddLogHandler((IExternalValue value) => {
                switch (n)
                {
                    default: throw new ArgumentOutOfRangeException(nameof(n), n, null);
                }

                n++;
            });


            var code = @"CALL {
            
            }";

            tmpEngine.Query(code);

            n = n - 1;

            //Assert.AreEqual(n, );

            throw new NotImplementedException();
        }

        [Test]
        public void PlusAssingFactOperatorCase2()
        {
            var tmpEngine = new GnuClayEngine();
            var numberKey = tmpEngine.Context.CommonKeysEngine.NumberKey;
            var n = 1;

            tmpEngine.AddLogHandler((IExternalValue value) => {
                switch (n)
                {
                    case 1:
                        Assert.AreEqual(value.TypeKey, numberKey);
                        Assert.AreEqual(value.Value, 2);
                        break;

                    case 2:
                        Assert.AreEqual(value.TypeKey, numberKey);
                        Assert.AreEqual(value.Value, 2);
                        break;

                    default: throw new ArgumentOutOfRangeException(nameof(n), n, null);
                }

                n++;
            });


            var code = @"CALL {
                $var1 = 1;
                $var2 = $var1 +<< 1;
                console.log($var1);
                console.log($var2);
            }";

            tmpEngine.Query(code);

            n = n - 1;

            Assert.AreEqual(n, 2);
        }
    }
}
