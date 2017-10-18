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
    public class GnuClayEngineScriptsLogicalOperatorsTests
    {
        [Test]
        public void EqualOperatorCase1()
        {
            var tmpEngine = new GnuClayEngine();

            var nullKey = tmpEngine.Context.CommonKeysEngine.NullTypeKey;
            var booleanKey = tmpEngine.Context.CommonKeysEngine.BooleanKey;

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
        public void EqualOperatorCase2()
        {
            var tmpEngine = new GnuClayEngine();

            var booleanKey = tmpEngine.Context.CommonKeysEngine.BooleanKey;

            var n = 1;

            tmpEngine.AddLogHandler((IExternalValue value) => {
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

                    case 3:
                        Assert.AreEqual(value.TypeKey, booleanKey);
                        Assert.AreEqual(value.Value, 1);
                        break;

                    case 4:
                        Assert.AreEqual(value.TypeKey, booleanKey);
                        Assert.AreEqual(value.Value, 1);
                        break;

                    case 5:
                        Assert.AreEqual(value.TypeKey, booleanKey);
                        Assert.AreEqual(value.Value, 0);
                        break;

                    default: throw new ArgumentOutOfRangeException(nameof(n), n, null);
                }

                n++;
            });

            var code = @"CALL {
                console.log(null == 2);
                console.log(1 == null);
                console.log(null == null);
                console.log(1 == 1);
                console.log(1 == 2);
            }";

            tmpEngine.Query(code);

            n = n - 1;

            Assert.AreEqual(n, 5);
        }

        [Test]
        public void NotEqualOperatorCase1()
        {
            var tmpEngine = new GnuClayEngine();

            var nullKey = tmpEngine.Context.CommonKeysEngine.NullTypeKey;
            var booleanKey = tmpEngine.Context.CommonKeysEngine.BooleanKey;

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
        public void NotEqualOperatorCase2()
        {
            var tmpEngine = new GnuClayEngine();

            var nullKey = tmpEngine.Context.CommonKeysEngine.NullTypeKey;
            var booleanKey = tmpEngine.Context.CommonKeysEngine.BooleanKey;

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
        public void MoreOperatorCase1()
        {
            var tmpEngine = new GnuClayEngine();

            var nullKey = tmpEngine.Context.CommonKeysEngine.NullTypeKey;
            var booleanKey = tmpEngine.Context.CommonKeysEngine.BooleanKey;

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
        public void MoreOperatorCase2()
        {
            var tmpEngine = new GnuClayEngine();

            var nullKey = tmpEngine.Context.CommonKeysEngine.NullTypeKey;
            var booleanKey = tmpEngine.Context.CommonKeysEngine.BooleanKey;

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
        public void LessOperatorCase1()
        {
            var tmpEngine = new GnuClayEngine();

            var nullKey = tmpEngine.Context.CommonKeysEngine.NullTypeKey;
            var booleanKey = tmpEngine.Context.CommonKeysEngine.BooleanKey;

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
        public void LessOperatorCase2()
        {
            var tmpEngine = new GnuClayEngine();

            var nullKey = tmpEngine.Context.CommonKeysEngine.NullTypeKey;
            var booleanKey = tmpEngine.Context.CommonKeysEngine.BooleanKey;

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
        public void AndOperatorCase1()
        {
            var tmpEngine = new GnuClayEngine();

            var nullKey = tmpEngine.Context.CommonKeysEngine.NullTypeKey;
            var booleanKey = tmpEngine.Context.CommonKeysEngine.BooleanKey;

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
        public void OrOperatorCase1()
        {
            var tmpEngine = new GnuClayEngine();

            var nullKey = tmpEngine.Context.CommonKeysEngine.NullTypeKey;
            var booleanKey = tmpEngine.Context.CommonKeysEngine.BooleanKey;

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
        public void MoreOrEqualOperatorCase1()
        {
            var tmpEngine = new GnuClayEngine();

            var nullKey = tmpEngine.Context.CommonKeysEngine.NullTypeKey;
            var booleanKey = tmpEngine.Context.CommonKeysEngine.BooleanKey;

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
        public void MoreOrEqualOperatorCase2()
        {
            var tmpEngine = new GnuClayEngine();

            var nullKey = tmpEngine.Context.CommonKeysEngine.NullTypeKey;
            var booleanKey = tmpEngine.Context.CommonKeysEngine.BooleanKey;

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
        public void LessOrEqualOperatorCase1()
        {
            var tmpEngine = new GnuClayEngine();

            var nullKey = tmpEngine.Context.CommonKeysEngine.NullTypeKey;
            var booleanKey = tmpEngine.Context.CommonKeysEngine.BooleanKey;

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
        public void LessOrEqualOperatorCase2()
        {
            var tmpEngine = new GnuClayEngine();

            var nullKey = tmpEngine.Context.CommonKeysEngine.NullTypeKey;
            var booleanKey = tmpEngine.Context.CommonKeysEngine.BooleanKey;

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
    }
}
