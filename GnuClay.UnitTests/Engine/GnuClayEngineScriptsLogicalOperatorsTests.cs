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
                        Assert.AreEqual(value.Value, 0);
                        break;

                    case 4:
                        Assert.AreEqual(value.TypeKey, booleanKey);
                        Assert.AreEqual(value.Value, 0);
                        break;

                    case 5:
                        Assert.AreEqual(value.TypeKey, booleanKey);
                        Assert.AreEqual(value.Value, 1);
                        break;

                    case 6:
                        Assert.AreEqual(value.TypeKey, booleanKey);
                        Assert.AreEqual(value.Value, 1);
                        break;

                    case 7:
                        Assert.AreEqual(value.TypeKey, booleanKey);
                        Assert.AreEqual(value.Value, 1);
                        break;

                    case 8:
                        Assert.AreEqual(value.TypeKey, booleanKey);
                        Assert.AreEqual(value.Value, 0);
                        break;

                    case 9:
                        Assert.AreEqual(value.TypeKey, booleanKey);
                        Assert.AreEqual(value.Value, 0);
                        break;

                    case 10:
                        Assert.AreEqual(value.TypeKey, booleanKey);
                        Assert.AreEqual(value.Value, 0);
                        break;

                    case 11:
                        Assert.AreEqual(value.TypeKey, booleanKey);
                        Assert.AreEqual(value.Value, 0);
                        break;

                    case 12:
                        Assert.AreEqual(value.TypeKey, booleanKey);
                        Assert.AreEqual(value.Value, 0);
                        break;

                    case 13:
                        Assert.AreEqual(value.TypeKey, booleanKey);
                        Assert.AreEqual(value.Value, 0);
                        break;

                    case 14:
                        Assert.AreEqual(value.TypeKey, booleanKey);
                        Assert.AreEqual(value.Value, 0);
                        break;

                    case 15:
                        Assert.AreEqual(value.TypeKey, booleanKey);
                        Assert.AreEqual(value.Value, 0);
                        break;

                    case 16:
                        Assert.AreEqual(value.TypeKey, booleanKey);
                        Assert.AreEqual(value.Value, 0);
                        break;

                    default: throw new ArgumentOutOfRangeException(nameof(n), n, null);
                }

                n++;
            });

            var code = @"CALL {
                console.log(null == true);
                console.log(null == false);
                console.log(true == null);
                console.log(false == null);
                console.log(null == null);
                console.log(true == true);
                console.log(false == false);
                console.log(true == false);
                console.log(false == true);
                console.log(1 == true);
                console.log(1 == false);
                console.log(0 == true);
                console.log(0 == false);
                console.log(2 == true);
                console.log(2 == false);
                console.log(0 == null);
            }";

            tmpEngine.Query(code);

            n = n - 1;

            Assert.AreEqual(n, 16);
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

                    case 6:
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
                console.log(0 == null);
            }";

            tmpEngine.Query(code);

            n = n - 1;

            Assert.AreEqual(n, 6);
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
                    case 1:
                        Assert.AreEqual(value.TypeKey, booleanKey);
                        Assert.AreEqual(value.Value, 1);
                        break;

                    case 2:
                        Assert.AreEqual(value.TypeKey, booleanKey);
                        Assert.AreEqual(value.Value, 1);
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

                    case 6:
                        Assert.AreEqual(value.TypeKey, booleanKey);
                        Assert.AreEqual(value.Value, 0);
                        break;

                    case 7:
                        Assert.AreEqual(value.TypeKey, booleanKey);
                        Assert.AreEqual(value.Value, 0);
                        break;

                    case 8:
                        Assert.AreEqual(value.TypeKey, booleanKey);
                        Assert.AreEqual(value.Value, 1);
                        break;

                    case 9:
                        Assert.AreEqual(value.TypeKey, booleanKey);
                        Assert.AreEqual(value.Value, 1);
                        break;

                    case 10:
                        Assert.AreEqual(value.TypeKey, booleanKey);
                        Assert.AreEqual(value.Value, 1);
                        break;

                    case 11:
                        Assert.AreEqual(value.TypeKey, booleanKey);
                        Assert.AreEqual(value.Value, 1);
                        break;

                    case 12:
                        Assert.AreEqual(value.TypeKey, booleanKey);
                        Assert.AreEqual(value.Value, 1);
                        break;

                    case 13:
                        Assert.AreEqual(value.TypeKey, booleanKey);
                        Assert.AreEqual(value.Value, 1);
                        break;

                    case 14:
                        Assert.AreEqual(value.TypeKey, booleanKey);
                        Assert.AreEqual(value.Value, 1);
                        break;

                    case 15:
                        Assert.AreEqual(value.TypeKey, booleanKey);
                        Assert.AreEqual(value.Value, 1);
                        break;

                    case 16:
                        Assert.AreEqual(value.TypeKey, booleanKey);
                        Assert.AreEqual(value.Value, 1);
                        break;

                    default: throw new ArgumentOutOfRangeException(nameof(n), n, null);
                }

                n++;
            });


            var code = @"CALL {
                console.log(null != true);
                console.log(null != false);
                console.log(true != null);
                console.log(false != null);
                console.log(null != null);
                console.log(true != true);
                console.log(false != false);
                console.log(true != false);
                console.log(false != true);
                console.log(1 != true);
                console.log(1 != false);
                console.log(0 != true);
                console.log(0 != false);
                console.log(2 != true);
                console.log(2 != false);
                console.log(0 != null);
            }";

            tmpEngine.Query(code);

            n = n - 1;

            Assert.AreEqual(n, 16);
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
                    case 1:
                        Assert.AreEqual(value.TypeKey, booleanKey);
                        Assert.AreEqual(value.Value, 1);
                        break;

                    case 2:
                        Assert.AreEqual(value.TypeKey, booleanKey);
                        Assert.AreEqual(value.Value, 1);
                        break;

                    case 3:
                        Assert.AreEqual(value.TypeKey, booleanKey);
                        Assert.AreEqual(value.Value, 0);
                        break;

                    case 4:
                        Assert.AreEqual(value.TypeKey, booleanKey);
                        Assert.AreEqual(value.Value, 0);
                        break;

                    case 5:
                        Assert.AreEqual(value.TypeKey, booleanKey);
                        Assert.AreEqual(value.Value, 1);
                        break;

                    case 6:
                        Assert.AreEqual(value.TypeKey, booleanKey);
                        Assert.AreEqual(value.Value, 1);
                        break;

                    default: throw new ArgumentOutOfRangeException(nameof(n), n, null);
                }

                n++;
            });


            var code = @"CALL {
                console.log(null != 2);
                console.log(1 != null);
                console.log(null != null);
                console.log(1 != 1);
                console.log(1 != 2);
                console.log(0 != null);
            }";

            tmpEngine.Query(code);

            n = n - 1;

            Assert.AreEqual(n, 6);
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
                    case 1:
                        Assert.AreEqual(value.TypeKey, booleanKey);
                        Assert.AreEqual(value.Value, 1);
                        break;

                    case 2:
                        Assert.AreEqual(value.TypeKey, nullKey);
                        Assert.AreEqual(value.Value, null);
                        break;

                    case 3:
                        Assert.AreEqual(value.TypeKey, booleanKey);
                        Assert.AreEqual(value.Value, 0);
                        break;

                    case 4:
                        Assert.AreEqual(value.TypeKey, nullKey);
                        Assert.AreEqual(value.Value, null);
                        break;

                    case 5:
                        Assert.AreEqual(value.TypeKey, nullKey);
                        Assert.AreEqual(value.Value, null);
                        break;

                    case 6:
                        Assert.AreEqual(value.TypeKey, booleanKey);
                        Assert.AreEqual(value.Value, 0);
                        break;

                    case 7:
                        Assert.AreEqual(value.TypeKey, booleanKey);
                        Assert.AreEqual(value.Value, 0);
                        break;

                    default: throw new ArgumentOutOfRangeException(nameof(n), n, null);
                }

                n++;
            });

            var code = @"CALL {
                console.log(true > false);
                console.log(true > null);
                console.log(false > true);
                console.log(false > null);
                console.log(null > null);
                console.log(true > true);
                console.log(false > false);
            }";

            tmpEngine.Query(code);

            n = n - 1;

            Assert.AreEqual(n, 7);
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
                    case 1:
                        Assert.AreEqual(value.TypeKey, booleanKey);
                        Assert.AreEqual(value.Value, 0);
                        break;

                    case 2:
                        Assert.AreEqual(value.TypeKey, booleanKey);
                        Assert.AreEqual(value.Value, 1);
                        break;

                    case 3:
                        Assert.AreEqual(value.TypeKey, booleanKey);
                        Assert.AreEqual(value.Value, 1);
                        break;

                    case 4:
                        Assert.AreEqual(value.TypeKey, booleanKey);
                        Assert.AreEqual(value.Value, 0);
                        break;

                    case 5:
                        Assert.AreEqual(value.TypeKey, booleanKey);
                        Assert.AreEqual(value.Value, 1);
                        break;

                    case 6:
                        Assert.AreEqual(value.TypeKey, booleanKey);
                        Assert.AreEqual(value.Value, 0);
                        break;

                    case 7:
                        Assert.AreEqual(value.TypeKey, booleanKey);
                        Assert.AreEqual(value.Value, 1);
                        break;

                    case 8:
                        Assert.AreEqual(value.TypeKey, booleanKey);
                        Assert.AreEqual(value.Value, 0);
                        break;

                    case 9:
                        Assert.AreEqual(value.TypeKey, booleanKey);
                        Assert.AreEqual(value.Value, 0);
                        break;

                    case 10:
                        Assert.AreEqual(value.TypeKey, booleanKey);
                        Assert.AreEqual(value.Value, 1);
                        break;

                    case 11:
                        Assert.AreEqual(value.TypeKey, nullKey);
                        Assert.AreEqual(value.Value, null);
                        break;

                    case 12:
                        Assert.AreEqual(value.TypeKey, nullKey);
                        Assert.AreEqual(value.Value, null);
                        break;

                    case 13:
                        Assert.AreEqual(value.TypeKey, nullKey);
                        Assert.AreEqual(value.Value, null);
                        break;

                    case 14:
                        Assert.AreEqual(value.TypeKey, nullKey);
                        Assert.AreEqual(value.Value, null);
                        break;

                    case 15:
                        Assert.AreEqual(value.TypeKey, nullKey);
                        Assert.AreEqual(value.Value, null);
                        break;

                    case 16:
                        Assert.AreEqual(value.TypeKey, nullKey);
                        Assert.AreEqual(value.Value, null);
                        break;

                    default: throw new ArgumentOutOfRangeException(nameof(n), n, null);
                }

                n++;
            });

            var code = @"CALL {
                console.log(1 > 2);
                console.log(2 > 1);
                console.log(1 > 0);
                console.log(0 > 1);
                console.log(0 > -1);
                console.log(-1 > 0);
                console.log(-1 > -2);
                console.log(-2 > -1);
                console.log(-1 > 1);
                console.log(1 > -1);
                console.log(1 > null);
                console.log(null > 1);
                console.log(0 > null);
                console.log(null > 0);
                console.log(-1 > null);
                console.log(null > -1);
            }";

            tmpEngine.Query(code);

            n = n - 1;

            Assert.AreEqual(n, 16);
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
                    case 1:
                        Assert.AreEqual(value.TypeKey, booleanKey);
                        Assert.AreEqual(value.Value, 0);
                        break;

                    case 2:
                        Assert.AreEqual(value.TypeKey, nullKey);
                        Assert.AreEqual(value.Value, null);
                        break;

                    case 3:
                        Assert.AreEqual(value.TypeKey, booleanKey);
                        Assert.AreEqual(value.Value, 1);
                        break;

                    case 4:
                        Assert.AreEqual(value.TypeKey, nullKey);
                        Assert.AreEqual(value.Value, null);
                        break;

                    case 5:
                        Assert.AreEqual(value.TypeKey, nullKey);
                        Assert.AreEqual(value.Value, null);
                        break;

                    case 6:
                        Assert.AreEqual(value.TypeKey, booleanKey);
                        Assert.AreEqual(value.Value, 0);
                        break;

                    case 7:
                        Assert.AreEqual(value.TypeKey, booleanKey);
                        Assert.AreEqual(value.Value, 0);
                        break;

                    default: throw new ArgumentOutOfRangeException(nameof(n), n, null);
                }

                n++;
            });

            var code = @"CALL {
                console.log(true < false);
                console.log(true < null);
                console.log(false < true);
                console.log(false < null);
                console.log(null < null);
                console.log(true < true);
                console.log(false < false);
            }";

            tmpEngine.Query(code);

            n = n - 1;

            Assert.AreEqual(n, 7);
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
                    case 1:
                        Assert.AreEqual(value.TypeKey, booleanKey);
                        Assert.AreEqual(value.Value, 1);
                        break;

                    case 2:
                        Assert.AreEqual(value.TypeKey, booleanKey);
                        Assert.AreEqual(value.Value, 0);
                        break;

                    case 3:
                        Assert.AreEqual(value.TypeKey, booleanKey);
                        Assert.AreEqual(value.Value, 0);
                        break;

                    case 4:
                        Assert.AreEqual(value.TypeKey, booleanKey);
                        Assert.AreEqual(value.Value, 1);
                        break;

                    case 5:
                        Assert.AreEqual(value.TypeKey, booleanKey);
                        Assert.AreEqual(value.Value, 0);
                        break;

                    case 6:
                        Assert.AreEqual(value.TypeKey, booleanKey);
                        Assert.AreEqual(value.Value, 1);
                        break;

                    case 7:
                        Assert.AreEqual(value.TypeKey, booleanKey);
                        Assert.AreEqual(value.Value, 0);
                        break;

                    case 8:
                        Assert.AreEqual(value.TypeKey, booleanKey);
                        Assert.AreEqual(value.Value, 1);
                        break;

                    case 9:
                        Assert.AreEqual(value.TypeKey, booleanKey);
                        Assert.AreEqual(value.Value, 1);
                        break;

                    case 10:
                        Assert.AreEqual(value.TypeKey, booleanKey);
                        Assert.AreEqual(value.Value, 0);
                        break;

                    case 11:
                        Assert.AreEqual(value.TypeKey, nullKey);
                        Assert.AreEqual(value.Value, null);
                        break;

                    case 12:
                        Assert.AreEqual(value.TypeKey, nullKey);
                        Assert.AreEqual(value.Value, null);
                        break;

                    case 13:
                        Assert.AreEqual(value.TypeKey, nullKey);
                        Assert.AreEqual(value.Value, null);
                        break;

                    case 14:
                        Assert.AreEqual(value.TypeKey, nullKey);
                        Assert.AreEqual(value.Value, null);
                        break;

                    case 15:
                        Assert.AreEqual(value.TypeKey, nullKey);
                        Assert.AreEqual(value.Value, null);
                        break;

                    case 16:
                        Assert.AreEqual(value.TypeKey, nullKey);
                        Assert.AreEqual(value.Value, null);
                        break;

                    default: throw new ArgumentOutOfRangeException(nameof(n), n, null);
                }

                n++;
            });

            var code = @"CALL {
                console.log(1 < 2);
                console.log(2 < 1);
                console.log(1 < 0);
                console.log(0 < 1);
                console.log(0 < -1);
                console.log(-1 < 0);
                console.log(-1 < -2);
                console.log(-2 < -1);
                console.log(-1 < 1);
                console.log(1 < -1);
                console.log(1 < null);
                console.log(null < 1);
                console.log(0 < null);
                console.log(null < 0);
                console.log(-1 < null);
                console.log(null < -1);
            }";

            tmpEngine.Query(code);

            n = n - 1;

            Assert.AreEqual(n, 16);
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
                    case 1:
                        Assert.AreEqual(value.TypeKey, booleanKey);
                        Assert.AreEqual(value.Value, 0);
                        break;

                    case 2:
                        Assert.AreEqual(value.TypeKey, nullKey);
                        Assert.AreEqual(value.Value, null);
                        break;

                    case 3:
                        Assert.AreEqual(value.TypeKey, booleanKey);
                        Assert.AreEqual(value.Value, 0);
                        break;

                    case 4:
                        Assert.AreEqual(value.TypeKey, nullKey);
                        Assert.AreEqual(value.Value, null);
                        break;

                    case 5:
                        Assert.AreEqual(value.TypeKey, nullKey);
                        Assert.AreEqual(value.Value, null);
                        break;

                    case 6:
                        Assert.AreEqual(value.TypeKey, booleanKey);
                        Assert.AreEqual(value.Value, 1);
                        break;

                    case 7:
                        Assert.AreEqual(value.TypeKey, booleanKey);
                        Assert.AreEqual(value.Value, 0);
                        break;

                    default: throw new ArgumentOutOfRangeException(nameof(n), n, null);
                }

                n++;
            });

            var code = @"CALL {
                console.log(true & false);
                console.log(true & null);
                console.log(false & true);
                console.log(false & null);
                console.log(null & null);
                console.log(true & true);
                console.log(false & false);
            }";

            tmpEngine.Query(code);

            n = n - 1;

            Assert.AreEqual(n, 7);
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
                    case 1:
                        Assert.AreEqual(value.TypeKey, booleanKey);
                        Assert.AreEqual(value.Value, 1);
                        break;

                    case 2:
                        Assert.AreEqual(value.TypeKey, nullKey);
                        Assert.AreEqual(value.Value, null);
                        break;

                    case 3:
                        Assert.AreEqual(value.TypeKey, booleanKey);
                        Assert.AreEqual(value.Value, 1);
                        break;

                    case 4:
                        Assert.AreEqual(value.TypeKey, nullKey);
                        Assert.AreEqual(value.Value, null);
                        break;

                    case 5:
                        Assert.AreEqual(value.TypeKey, nullKey);
                        Assert.AreEqual(value.Value, null);
                        break;

                    case 6:
                        Assert.AreEqual(value.TypeKey, booleanKey);
                        Assert.AreEqual(value.Value, 1);
                        break;

                    case 7:
                        Assert.AreEqual(value.TypeKey, booleanKey);
                        Assert.AreEqual(value.Value, 0);
                        break;

                    default: throw new ArgumentOutOfRangeException(nameof(n), n, null);
                }

                n++;
            });

            var code = @"CALL {
                console.log(true | false);
                console.log(true | null);
                console.log(false | true);
                console.log(false | null);
                console.log(null | null);
                console.log(true | true);
                console.log(false | false);
            }";

            tmpEngine.Query(code);

            n = n - 1;

            Assert.AreEqual(n, 7);
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
                    case 1:
                        Assert.AreEqual(value.TypeKey, booleanKey);
                        Assert.AreEqual(value.Value, 1);
                        break;

                    case 2:
                        Assert.AreEqual(value.TypeKey, nullKey);
                        Assert.AreEqual(value.Value, null);
                        break;

                    case 3:
                        Assert.AreEqual(value.TypeKey, booleanKey);
                        Assert.AreEqual(value.Value, 0);
                        break;

                    case 4:
                        Assert.AreEqual(value.TypeKey, nullKey);
                        Assert.AreEqual(value.Value, null);
                        break;

                    case 5:
                        Assert.AreEqual(value.TypeKey, nullKey);
                        Assert.AreEqual(value.Value, null);
                        break;

                    case 6:
                        Assert.AreEqual(value.TypeKey, booleanKey);
                        Assert.AreEqual(value.Value, 1);
                        break;

                    case 7:
                        Assert.AreEqual(value.TypeKey, booleanKey);
                        Assert.AreEqual(value.Value, 1);
                        break;

                    default: throw new ArgumentOutOfRangeException(nameof(n), n, null);
                }

                n++;
            });

            var code = @"CALL {
                console.log(true >= false);
                console.log(true >= null);
                console.log(false >= true);
                console.log(false >= null);
                console.log(null >= null);
                console.log(true >= true);
                console.log(false >= false);
            }";

            tmpEngine.Query(code);

            n = n - 1;

            Assert.AreEqual(n, 7);
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
                    case 1:
                        Assert.AreEqual(value.TypeKey, booleanKey);
                        Assert.AreEqual(value.Value, 0);
                        break;

                    case 2:
                        Assert.AreEqual(value.TypeKey, booleanKey);
                        Assert.AreEqual(value.Value, 1);
                        break;

                    case 3:
                        Assert.AreEqual(value.TypeKey, booleanKey);
                        Assert.AreEqual(value.Value, 1);
                        break;

                    case 4:
                        Assert.AreEqual(value.TypeKey, booleanKey);
                        Assert.AreEqual(value.Value, 0);
                        break;

                    case 5:
                        Assert.AreEqual(value.TypeKey, booleanKey);
                        Assert.AreEqual(value.Value, 1);
                        break;

                    case 6:
                        Assert.AreEqual(value.TypeKey, booleanKey);
                        Assert.AreEqual(value.Value, 0);
                        break;

                    case 7:
                        Assert.AreEqual(value.TypeKey, booleanKey);
                        Assert.AreEqual(value.Value, 1);
                        break;

                    case 8:
                        Assert.AreEqual(value.TypeKey, booleanKey);
                        Assert.AreEqual(value.Value, 0);
                        break;

                    case 9:
                        Assert.AreEqual(value.TypeKey, booleanKey);
                        Assert.AreEqual(value.Value, 0);
                        break;

                    case 10:
                        Assert.AreEqual(value.TypeKey, booleanKey);
                        Assert.AreEqual(value.Value, 1);
                        break;

                    case 11:
                        Assert.AreEqual(value.TypeKey, nullKey);
                        Assert.AreEqual(value.Value, null);
                        break;

                    case 12:
                        Assert.AreEqual(value.TypeKey, nullKey);
                        Assert.AreEqual(value.Value, null);
                        break;

                    case 13:
                        Assert.AreEqual(value.TypeKey, nullKey);
                        Assert.AreEqual(value.Value, null);
                        break;

                    case 14:
                        Assert.AreEqual(value.TypeKey, nullKey);
                        Assert.AreEqual(value.Value, null);
                        break;

                    case 15:
                        Assert.AreEqual(value.TypeKey, nullKey);
                        Assert.AreEqual(value.Value, null);
                        break;

                    case 16:
                        Assert.AreEqual(value.TypeKey, nullKey);
                        Assert.AreEqual(value.Value, null);
                        break;

                    default: throw new ArgumentOutOfRangeException(nameof(n), n, null);
                }

                n++;
            });

            var code = @"CALL {
                console.log(1 >= 2);
                console.log(2 >= 1);
                console.log(1 >= 0);
                console.log(0 >= 1);
                console.log(0 >= -1);
                console.log(-1 >= 0);
                console.log(-1 >= -2);
                console.log(-2 >= -1);
                console.log(-1 >= 1);
                console.log(1 >= -1);
                console.log(1 >= null);
                console.log(null >= 1);
                console.log(0 >= null);
                console.log(null >= 0);
                console.log(-1 >= null);
                console.log(null >= -1);
            }";

            tmpEngine.Query(code);

            n = n - 1;

            Assert.AreEqual(n, 16);
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
                    case 1:
                        Assert.AreEqual(value.TypeKey, booleanKey);
                        Assert.AreEqual(value.Value, 0);
                        break;

                    case 2:
                        Assert.AreEqual(value.TypeKey, nullKey);
                        Assert.AreEqual(value.Value, null);
                        break;

                    case 3:
                        Assert.AreEqual(value.TypeKey, booleanKey);
                        Assert.AreEqual(value.Value, 1);
                        break;

                    case 4:
                        Assert.AreEqual(value.TypeKey, nullKey);
                        Assert.AreEqual(value.Value, null);
                        break;

                    case 5:
                        Assert.AreEqual(value.TypeKey, nullKey);
                        Assert.AreEqual(value.Value, null);
                        break;

                    case 6:
                        Assert.AreEqual(value.TypeKey, booleanKey);
                        Assert.AreEqual(value.Value, 1);
                        break;

                    case 7:
                        Assert.AreEqual(value.TypeKey, booleanKey);
                        Assert.AreEqual(value.Value, 1);
                        break;

                    default: throw new ArgumentOutOfRangeException(nameof(n), n, null);
                }

                n++;
            });

            var code = @"CALL {
                console.log(true <= false);
                console.log(true <= null);
                console.log(false <= true);
                console.log(false <= null);
                console.log(null <= null);
                console.log(true <= true);
                console.log(false <= false);
            }";

            tmpEngine.Query(code);

            n = n - 1;

            Assert.AreEqual(n, 7);
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
                    case 1:
                        Assert.AreEqual(value.TypeKey, booleanKey);
                        Assert.AreEqual(value.Value, 1);
                        break;

                    case 2:
                        Assert.AreEqual(value.TypeKey, booleanKey);
                        Assert.AreEqual(value.Value, 0);
                        break;

                    case 3:
                        Assert.AreEqual(value.TypeKey, booleanKey);
                        Assert.AreEqual(value.Value, 0);
                        break;

                    case 4:
                        Assert.AreEqual(value.TypeKey, booleanKey);
                        Assert.AreEqual(value.Value, 1);
                        break;

                    case 5:
                        Assert.AreEqual(value.TypeKey, booleanKey);
                        Assert.AreEqual(value.Value, 0);
                        break;

                    case 6:
                        Assert.AreEqual(value.TypeKey, booleanKey);
                        Assert.AreEqual(value.Value, 1);
                        break;

                    case 7:
                        Assert.AreEqual(value.TypeKey, booleanKey);
                        Assert.AreEqual(value.Value, 0);
                        break;

                    case 8:
                        Assert.AreEqual(value.TypeKey, booleanKey);
                        Assert.AreEqual(value.Value, 1);
                        break;

                    case 9:
                        Assert.AreEqual(value.TypeKey, booleanKey);
                        Assert.AreEqual(value.Value, 1);
                        break;

                    case 10:
                        Assert.AreEqual(value.TypeKey, booleanKey);
                        Assert.AreEqual(value.Value, 0);
                        break;

                    case 11:
                        Assert.AreEqual(value.TypeKey, nullKey);
                        Assert.AreEqual(value.Value, null);
                        break;

                    case 12:
                        Assert.AreEqual(value.TypeKey, nullKey);
                        Assert.AreEqual(value.Value, null);
                        break;

                    case 13:
                        Assert.AreEqual(value.TypeKey, nullKey);
                        Assert.AreEqual(value.Value, null);
                        break;

                    case 14:
                        Assert.AreEqual(value.TypeKey, nullKey);
                        Assert.AreEqual(value.Value, null);
                        break;

                    case 15:
                        Assert.AreEqual(value.TypeKey, nullKey);
                        Assert.AreEqual(value.Value, null);
                        break;

                    case 16:
                        Assert.AreEqual(value.TypeKey, nullKey);
                        Assert.AreEqual(value.Value, null);
                        break;

                    default: throw new ArgumentOutOfRangeException(nameof(n), n, null);
                }

                n++;
            });

            var code = @"CALL {
                console.log(1 <= 2);
                console.log(2 <= 1);
                console.log(1 <= 0);
                console.log(0 <= 1);
                console.log(0 <= -1);
                console.log(-1 <= 0);
                console.log(-1 <= -2);
                console.log(-2 <= -1);
                console.log(-1 <= 1);
                console.log(1 <= -1);
                console.log(1 <= null);
                console.log(null <= 1);
                console.log(0 <= null);
                console.log(null <= 0);
                console.log(-1 <= null);
                console.log(null <= -1);
            }";

            tmpEngine.Query(code);

            n = n - 1;

            Assert.AreEqual(n, 16);
        }
    }
}
