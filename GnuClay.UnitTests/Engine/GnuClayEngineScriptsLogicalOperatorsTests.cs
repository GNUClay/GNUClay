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

            var n = 0;

            tmpEngine.AddLogHandler((IExternalValue value) => {
                n++;

                switch (n)
                {
                    default: throw new ArgumentOutOfRangeException(nameof(n), n, null);
                }
            });

            var code = @"CALL {
                
            }";

            tmpEngine.Query(code);

            //Assert.AreEqual(n, );

            throw new NotImplementedException();
        }

        [Test]
        public void EqualOperatorCase2()
        {
            var tmpEngine = new GnuClayEngine();

            var nullKey = tmpEngine.Context.CommonKeysEngine.NullTypeKey;
            var numberKey = tmpEngine.Context.CommonKeysEngine.NumberKey;

            var n = 0;

            tmpEngine.AddLogHandler((IExternalValue value) => {
                n++;

                switch (n)
                {
                    default: throw new ArgumentOutOfRangeException(nameof(n), n, null);
                }
            });

            var code = @"CALL {
                
            }";

            tmpEngine.Query(code);

            //Assert.AreEqual(n, );

            throw new NotImplementedException();
        }

        [Test]
        public void NotEqualOperatorCase1()
        {
            var tmpEngine = new GnuClayEngine();

            var nullKey = tmpEngine.Context.CommonKeysEngine.NullTypeKey;
            var booleanKey = tmpEngine.Context.CommonKeysEngine.BooleanKey;

            var n = 0;

            tmpEngine.AddLogHandler((IExternalValue value) => {
                n++;

                switch (n)
                {
                    default: throw new ArgumentOutOfRangeException(nameof(n), n, null);
                }
            });


            var code = @"CALL {
            
            }";

            tmpEngine.Query(code);

            //Assert.AreEqual(n, );

            throw new NotImplementedException();
        }

        [Test]
        public void NotEqualOperatorCase2()
        {
            var tmpEngine = new GnuClayEngine();

            var nullKey = tmpEngine.Context.CommonKeysEngine.NullTypeKey;
            var numberKey = tmpEngine.Context.CommonKeysEngine.NumberKey;

            var n = 0;

            tmpEngine.AddLogHandler((IExternalValue value) => {
                n++;

                switch (n)
                {
                    default: throw new ArgumentOutOfRangeException(nameof(n), n, null);
                }
            });


            var code = @"CALL {
            
            }";

            tmpEngine.Query(code);

            //Assert.AreEqual(n, );

            throw new NotImplementedException();
        }

        [Test]
        public void MoreOperatorCase1()
        {
            var tmpEngine = new GnuClayEngine();

            var nullKey = tmpEngine.Context.CommonKeysEngine.NullTypeKey;
            var booleanKey = tmpEngine.Context.CommonKeysEngine.BooleanKey;

            var n = 0;

            tmpEngine.AddLogHandler((IExternalValue value) => {
                n++;

                switch (n)
                {
                    default: throw new ArgumentOutOfRangeException(nameof(n), n, null);
                }
            });


            var code = @"CALL {
            
            }";

            tmpEngine.Query(code);

            //Assert.AreEqual(n, );

            throw new NotImplementedException();
        }

        [Test]
        public void MoreOperatorCase2()
        {
            var tmpEngine = new GnuClayEngine();

            var nullKey = tmpEngine.Context.CommonKeysEngine.NullTypeKey;
            var numberKey = tmpEngine.Context.CommonKeysEngine.NumberKey;

            var n = 0;

            tmpEngine.AddLogHandler((IExternalValue value) => {
                n++;

                switch (n)
                {
                    default: throw new ArgumentOutOfRangeException(nameof(n), n, null);
                }
            });


            var code = @"CALL {
            
            }";

            tmpEngine.Query(code);

            //Assert.AreEqual(n, );

            throw new NotImplementedException();
        }

        [Test]
        public void LessOperatorCase1()
        {
            var tmpEngine = new GnuClayEngine();

            var nullKey = tmpEngine.Context.CommonKeysEngine.NullTypeKey;
            var booleanKey = tmpEngine.Context.CommonKeysEngine.BooleanKey;

            var n = 0;

            tmpEngine.AddLogHandler((IExternalValue value) => {
                n++;

                switch (n)
                {
                    default: throw new ArgumentOutOfRangeException(nameof(n), n, null);
                }
            });


            var code = @"CALL {
            
            }";

            tmpEngine.Query(code);

            //Assert.AreEqual(n, );

            throw new NotImplementedException();
        }

        [Test]
        public void LessOperatorCase2()
        {
            var tmpEngine = new GnuClayEngine();

            var nullKey = tmpEngine.Context.CommonKeysEngine.NullTypeKey;
            var numberKey = tmpEngine.Context.CommonKeysEngine.NumberKey;

            var n = 0;

            tmpEngine.AddLogHandler((IExternalValue value) => {
                n++;

                switch (n)
                {
                    default: throw new ArgumentOutOfRangeException(nameof(n), n, null);
                }
            });


            var code = @"CALL {
            
            }";

            tmpEngine.Query(code);

            //Assert.AreEqual(n, );

            throw new NotImplementedException();
        }

        [Test]
        public void AndOperatorCase1()
        {
            var tmpEngine = new GnuClayEngine();

            var nullKey = tmpEngine.Context.CommonKeysEngine.NullTypeKey;
            var booleanKey = tmpEngine.Context.CommonKeysEngine.BooleanKey;

            var n = 0;

            tmpEngine.AddLogHandler((IExternalValue value) => {
                n++;

                switch (n)
                {
                    default: throw new ArgumentOutOfRangeException(nameof(n), n, null);
                }
            });


            var code = @"CALL {
            
            }";

            tmpEngine.Query(code);

            //Assert.AreEqual(n, );

            throw new NotImplementedException();
        }

        [Test]
        public void OrOperatorCase1()
        {
            var tmpEngine = new GnuClayEngine();

            var nullKey = tmpEngine.Context.CommonKeysEngine.NullTypeKey;
            var booleanKey = tmpEngine.Context.CommonKeysEngine.BooleanKey;

            var n = 0;

            tmpEngine.AddLogHandler((IExternalValue value) => {
                n++;

                switch (n)
                {
                    default: throw new ArgumentOutOfRangeException(nameof(n), n, null);
                }
            });


            var code = @"CALL {
            
            }";

            tmpEngine.Query(code);

            //Assert.AreEqual(n, );

            throw new NotImplementedException();
        }

        [Test]
        public void MoreOrEqualOperatorCase1()
        {
            var tmpEngine = new GnuClayEngine();

            var nullKey = tmpEngine.Context.CommonKeysEngine.NullTypeKey;
            var booleanKey = tmpEngine.Context.CommonKeysEngine.BooleanKey;

            var n = 0;

            tmpEngine.AddLogHandler((IExternalValue value) => {
                n++;

                switch (n)
                {
                    default: throw new ArgumentOutOfRangeException(nameof(n), n, null);
                }
            });


            var code = @"CALL {
            
            }";

            tmpEngine.Query(code);

            //Assert.AreEqual(n, );

            throw new NotImplementedException();
        }

        [Test]
        public void MoreOrEqualOperatorCase2()
        {
            var tmpEngine = new GnuClayEngine();

            var nullKey = tmpEngine.Context.CommonKeysEngine.NullTypeKey;
            var numberKey = tmpEngine.Context.CommonKeysEngine.NumberKey;

            var n = 0;

            tmpEngine.AddLogHandler((IExternalValue value) => {
                n++;

                switch (n)
                {
                    default: throw new ArgumentOutOfRangeException(nameof(n), n, null);
                }
            });


            var code = @"CALL {
            
            }";

            tmpEngine.Query(code);

            //Assert.AreEqual(n, );

            throw new NotImplementedException();
        }

        [Test]
        public void LessOrEqualOperatorCase1()
        {
            var tmpEngine = new GnuClayEngine();

            var nullKey = tmpEngine.Context.CommonKeysEngine.NullTypeKey;
            var booleanKey = tmpEngine.Context.CommonKeysEngine.BooleanKey;

            var n = 0;

            tmpEngine.AddLogHandler((IExternalValue value) => {
                n++;

                switch (n)
                {
                    default: throw new ArgumentOutOfRangeException(nameof(n), n, null);
                }
            });


            var code = @"CALL {
            
            }";

            tmpEngine.Query(code);

            //Assert.AreEqual(n, );

            throw new NotImplementedException();
        }

        [Test]
        public void LessOrEqualOperatorCase2()
        {
            var tmpEngine = new GnuClayEngine();

            var nullKey = tmpEngine.Context.CommonKeysEngine.NullTypeKey;
            var numberKey = tmpEngine.Context.CommonKeysEngine.NumberKey;

            var n = 0;

            tmpEngine.AddLogHandler((IExternalValue value) => {
                n++;

                switch (n)
                {
                    default: throw new ArgumentOutOfRangeException(nameof(n), n, null);
                }
            });


            var code = @"CALL {
            
            }";

            tmpEngine.Query(code);

            //Assert.AreEqual(n, );

            throw new NotImplementedException();
        }
    }
}
