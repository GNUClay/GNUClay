using GnuClay.CommonClientTypes;
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

            var nullKey = tmpEngine.Context.CommonKeysEngine.NullTypeKey;
            var redKey = tmpEngine.GetKey("red");
            var greenKey = tmpEngine.GetKey("green");

            var n = 1;

            tmpEngine.AddLogHandler((IExternalValue value) => {
                switch (n)
                {
                    case 1:
                        Assert.AreEqual(value.Kind, ExternalValueKind.Value);
                        Assert.AreEqual(value.TypeKey, nullKey);
                        Assert.AreEqual(value.Value, null);
                        break;

                    case 2:
                    case 3:
                        Assert.AreEqual(value.Kind, ExternalValueKind.Entity);
                        Assert.AreEqual(value.TypeKey, redKey);
                        Assert.AreEqual(value.Value, null);
                        break;

                    case 4:
                    case 5:
                        Assert.AreEqual(value.Kind, ExternalValueKind.Entity);
                        Assert.AreEqual(value.TypeKey, greenKey);
                        Assert.AreEqual(value.Value, null);
                        break;

                    default: throw new ArgumentOutOfRangeException(nameof(n), n, null);
                }

                n++;
            });

            var queryString = "READ {>: {color(dog,$X1)}}";

            var qr_1 = tmpEngine.Query(queryString);

            Assert.AreNotEqual(qr_1, null);
            Assert.AreEqual(qr_1.ErrorText, string.Empty);
            Assert.AreEqual(qr_1.Success, true);
            Assert.AreEqual(qr_1.HaveBeenFound, false);
            Assert.AreNotEqual(qr_1.Items, null);
            Assert.AreEqual(qr_1.Items.Count, 0);

            var code = @"CALL {
                console.log(dog.color);

                $var1 = dog.color = red;

                console.log($var1);
                console.log(dog.color);

                $var1 = dog.color = green;

                console.log($var1);
                console.log(dog.color);
            }";

            tmpEngine.Query(code);

            n = n - 1;

            Assert.AreEqual(n, 5);

            var x1VarKey = tmpEngine.GetKey("$X1");
            
            queryString = "READ {>: {color(dog,$X1)}}";

            var qr_2 = tmpEngine.Query(queryString);

            Assert.AreNotEqual(qr_2, null);
            Assert.AreEqual(qr_2.ErrorText, string.Empty);
            Assert.AreEqual(qr_2.Success, true);
            Assert.AreEqual(qr_2.HaveBeenFound, true);

            Assert.AreEqual(qr_2.Items.Count, 1);

            var targetItem = qr_2.Items.Single();

            Assert.AreEqual(targetItem.Params.Count, 1);

            var targetVarItem = targetItem.Params.Single();

            Assert.AreEqual(targetVarItem.Kind, ExpressionNodeKind.Entity);
            Assert.AreEqual(targetVarItem.EntityKey, greenKey);
            Assert.AreEqual(targetVarItem.ParamKey, x1VarKey);
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

            var nullKey = tmpEngine.Context.CommonKeysEngine.NullTypeKey;
            var redKey = tmpEngine.GetKey("red");
            var greenKey = tmpEngine.GetKey("green");

            var n = 1;

            tmpEngine.AddLogHandler((IExternalValue value) => {
                switch (n)
                {
                    case 1:
                        Assert.AreEqual(value.Kind, ExternalValueKind.Value);
                        Assert.AreEqual(value.TypeKey, nullKey);
                        Assert.AreEqual(value.Value, null);
                        break;

                    case 2:
                    case 3:
                        Assert.AreEqual(value.Kind, ExternalValueKind.Entity);
                        Assert.AreEqual(value.TypeKey, redKey);
                        Assert.AreEqual(value.Value, null);
                        break;

                    case 4:
                        Assert.AreEqual(value.Kind, ExternalValueKind.Entity);
                        Assert.AreEqual(value.TypeKey, greenKey);
                        Assert.AreEqual(value.Value, null);
                        break;

                    case 5:
                        Assert.AreEqual(value.Kind, ExternalValueKind.Entity);
                        Assert.AreEqual(value.TypeKey, redKey);
                        Assert.AreEqual(value.Value, null);
                        break;

                    default: throw new ArgumentOutOfRangeException(nameof(n), n, null);
                }

                n++;
            });

            var queryString = "READ {>: {color(dog,$X1)}}";

            var qr_1 = tmpEngine.Query(queryString);

            Assert.AreNotEqual(qr_1, null);
            Assert.AreEqual(qr_1.ErrorText, string.Empty);
            Assert.AreEqual(qr_1.Success, true);
            Assert.AreEqual(qr_1.HaveBeenFound, false);
            Assert.AreNotEqual(qr_1.Items, null);
            Assert.AreEqual(qr_1.Items.Count, 0);

            var code = @"CALL {
                console.log(dog.color);

                $var1 = dog.color = red;

                console.log($var1);
                console.log(dog.color);

                $var1 = dog.color += green;

                console.log($var1);
                console.log(dog.color);
            }";

            tmpEngine.Query(code);

            n = n - 1;

            Assert.AreEqual(n, 5);

            var x1VarKey = tmpEngine.GetKey("$X1");

            queryString = "READ {>: {color(dog,$X1)}}";

            var qr_2 = tmpEngine.Query(queryString);

            Assert.AreNotEqual(qr_2, null);
            Assert.AreEqual(qr_2.ErrorText, string.Empty);
            Assert.AreEqual(qr_2.Success, true);
            Assert.AreEqual(qr_2.HaveBeenFound, true);

            Assert.AreEqual(qr_2.Items.Count, 2);

            var targetItem = qr_2.Items[0];

            Assert.AreEqual(targetItem.Params.Count, 1);

            var targetVarItem = targetItem.Params.Single();

            Assert.AreEqual(targetVarItem.Kind, ExpressionNodeKind.Entity);
            Assert.AreEqual(targetVarItem.EntityKey, redKey);
            Assert.AreEqual(targetVarItem.ParamKey, x1VarKey);

            targetItem = qr_2.Items[1];

            Assert.AreEqual(targetItem.Params.Count, 1);

            targetVarItem = targetItem.Params.Single();

            Assert.AreEqual(targetVarItem.Kind, ExpressionNodeKind.Entity);
            Assert.AreEqual(targetVarItem.EntityKey, greenKey);
            Assert.AreEqual(targetVarItem.ParamKey, x1VarKey);
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

            var nullKey = tmpEngine.Context.CommonKeysEngine.NullTypeKey;
            var redKey = tmpEngine.GetKey("red");
            var greenKey = tmpEngine.GetKey("green");

            var n = 1;

            tmpEngine.AddLogHandler((IExternalValue value) => {
                switch (n)
                {
                    case 1:
                        Assert.AreEqual(value.Kind, ExternalValueKind.Value);
                        Assert.AreEqual(value.TypeKey, nullKey);
                        Assert.AreEqual(value.Value, null);
                        break;

                    case 2:
                    case 3:
                        Assert.AreEqual(value.Kind, ExternalValueKind.Entity);
                        Assert.AreEqual(value.TypeKey, redKey);
                        Assert.AreEqual(value.Value, null);
                        break;

                    case 4:
                        Assert.AreEqual(value.Kind, ExternalValueKind.Entity);
                        Assert.AreEqual(value.TypeKey, greenKey);
                        Assert.AreEqual(value.Value, null);
                        break;

                    case 5:
                        Assert.AreEqual(value.Kind, ExternalValueKind.Entity);
                        Assert.AreEqual(value.TypeKey, redKey);
                        Assert.AreEqual(value.Value, null);
                        break;

                    default: throw new ArgumentOutOfRangeException(nameof(n), n, null);
                }

                n++;
            });

            var queryString = "READ {>: {color(dog,$X1)}}";

            var qr_1 = tmpEngine.Query(queryString);

            Assert.AreNotEqual(qr_1, null);
            Assert.AreEqual(qr_1.ErrorText, string.Empty);
            Assert.AreEqual(qr_1.Success, true);
            Assert.AreEqual(qr_1.HaveBeenFound, false);
            Assert.AreNotEqual(qr_1.Items, null);
            Assert.AreEqual(qr_1.Items.Count, 0);

            var code = @"CALL {
                console.log(dog.color);

                $var1 = dog.color = red;

                console.log($var1);
                console.log(dog.color);

                $var1 = dog.color *= green;

                console.log($var1);
                console.log(dog.color);
            }";

            tmpEngine.Query(code);

            n = n - 1;

            Assert.AreEqual(n, 5);

            var x1VarKey = tmpEngine.GetKey("$X1");

            queryString = "READ {>: {color(dog,$X1)}}";

            var qr_2 = tmpEngine.Query(queryString);

            Assert.AreNotEqual(qr_2, null);
            Assert.AreEqual(qr_2.ErrorText, string.Empty);
            Assert.AreEqual(qr_2.Success, true);
            Assert.AreEqual(qr_2.HaveBeenFound, true);

            Assert.AreEqual(qr_2.Items.Count, 2);

            var targetItem = qr_2.Items[0];

            Assert.AreEqual(targetItem.Params.Count, 1);

            var targetVarItem = targetItem.Params.Single();

            Assert.AreEqual(targetVarItem.Kind, ExpressionNodeKind.Entity);
            Assert.AreEqual(targetVarItem.EntityKey, redKey);
            Assert.AreEqual(targetVarItem.ParamKey, x1VarKey);

            targetItem = qr_2.Items[1];

            Assert.AreEqual(targetItem.Params.Count, 1);

            targetVarItem = targetItem.Params.Single();

            Assert.AreEqual(targetVarItem.Kind, ExpressionNodeKind.Entity);
            Assert.AreEqual(targetVarItem.EntityKey, greenKey);
            Assert.AreEqual(targetVarItem.ParamKey, x1VarKey);
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

            var nullKey = tmpEngine.Context.CommonKeysEngine.NullTypeKey;
            var redKey = tmpEngine.GetKey("red");
            var greenKey = tmpEngine.GetKey("green");

            var n = 1;

            tmpEngine.AddLogHandler((IExternalValue value) => {
                switch (n)
                {
                    case 1:
                        Assert.AreEqual(value.Kind, ExternalValueKind.Value);
                        Assert.AreEqual(value.TypeKey, nullKey);
                        Assert.AreEqual(value.Value, null);
                        break;

                    case 2:
                    case 3:
                        Assert.AreEqual(value.Kind, ExternalValueKind.Entity);
                        Assert.AreEqual(value.TypeKey, redKey);
                        Assert.AreEqual(value.Value, null);
                        break;

                    case 4:
                        Assert.AreEqual(value.Kind, ExternalValueKind.Entity);
                        Assert.AreNotEqual(value.TypeKey, greenKey);
                        Assert.AreNotEqual(value.TypeKey, redKey);
                        Assert.AreEqual(value.Value, null);
                        break;

                    case 5:
                        Assert.AreEqual(value.Kind, ExternalValueKind.Entity);
                        Assert.AreEqual(value.TypeKey, greenKey);
                        Assert.AreEqual(value.Value, null);
                        break;

                    default: throw new ArgumentOutOfRangeException(nameof(n), n, null);
                }

                n++;
            });

            var queryString = "READ {>: {color(dog,$X1)}}";

            var qr_1 = tmpEngine.Query(queryString);

            Assert.AreNotEqual(qr_1, null);
            Assert.AreEqual(qr_1.ErrorText, string.Empty);
            Assert.AreEqual(qr_1.Success, true);
            Assert.AreEqual(qr_1.HaveBeenFound, false);
            Assert.AreNotEqual(qr_1.Items, null);
            Assert.AreEqual(qr_1.Items.Count, 0);

            var code = @"CALL {
                console.log(dog.color);

                $var1 = dog.color = red;

                console.log($var1);
                console.log(dog.color);

                $var1 = dog.color << green;

                console.log($var1);
                console.log(dog.color);
            }";

            tmpEngine.Query(code);

            n = n - 1;

            Assert.AreEqual(n, 5);

            var x1VarKey = tmpEngine.GetKey("$X1");

            queryString = "READ {>: {color(dog,$X1)}}";

            var qr_2 = tmpEngine.Query(queryString);

            Assert.AreNotEqual(qr_2, null);
            Assert.AreEqual(qr_2.ErrorText, string.Empty);
            Assert.AreEqual(qr_2.Success, true);
            Assert.AreEqual(qr_2.HaveBeenFound, true);

            Assert.AreEqual(qr_2.Items.Count, 1);

            var targetItem = qr_2.Items.Single();

            Assert.AreEqual(targetItem.Params.Count, 1);

            var targetVarItem = targetItem.Params.Single();

            Assert.AreEqual(targetVarItem.Kind, ExpressionNodeKind.Entity);
            Assert.AreEqual(targetVarItem.EntityKey, greenKey);
            Assert.AreEqual(targetVarItem.ParamKey, x1VarKey);
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

            var nullKey = tmpEngine.Context.CommonKeysEngine.NullTypeKey;
            var redKey = tmpEngine.GetKey("red");
            var greenKey = tmpEngine.GetKey("green");

            var n = 1;

            tmpEngine.AddLogHandler((IExternalValue value) => {
                switch (n)
                {
                    case 1:
                        Assert.AreEqual(value.Kind, ExternalValueKind.Value);
                        Assert.AreEqual(value.TypeKey, nullKey);
                        Assert.AreEqual(value.Value, null);
                        break;

                    case 2:
                    case 3:
                        Assert.AreEqual(value.Kind, ExternalValueKind.Entity);
                        Assert.AreEqual(value.TypeKey, redKey);
                        Assert.AreEqual(value.Value, null);
                        break;

                    case 4:
                        Assert.AreEqual(value.Kind, ExternalValueKind.Entity);
                        Assert.AreNotEqual(value.TypeKey, greenKey);
                        Assert.AreNotEqual(value.TypeKey, redKey);
                        Assert.AreEqual(value.Value, null);
                        break;

                    case 5:
                        Assert.AreEqual(value.Kind, ExternalValueKind.Entity);
                        Assert.AreEqual(value.TypeKey, redKey);
                        Assert.AreEqual(value.Value, null);
                        break;

                    default: throw new ArgumentOutOfRangeException(nameof(n), n, null);
                }

                n++;
            });

            var queryString = "READ {>: {color(dog,$X1)}}";

            var qr_1 = tmpEngine.Query(queryString);

            Assert.AreNotEqual(qr_1, null);
            Assert.AreEqual(qr_1.ErrorText, string.Empty);
            Assert.AreEqual(qr_1.Success, true);
            Assert.AreEqual(qr_1.HaveBeenFound, false);
            Assert.AreNotEqual(qr_1.Items, null);
            Assert.AreEqual(qr_1.Items.Count, 0);

            var code = @"CALL {
                console.log(dog.color);

                $var1 = dog.color = red;

                console.log($var1);
                console.log(dog.color);

                $var1 = dog.color +<< green;

                console.log($var1);
                console.log(dog.color);
            }";

            tmpEngine.Query(code);

            n = n - 1;

            Assert.AreEqual(n, 5);

            var x1VarKey = tmpEngine.GetKey("$X1");

            queryString = "READ {>: {color(dog,$X1)}}";

            var qr_2 = tmpEngine.Query(queryString);

            Assert.AreNotEqual(qr_2, null);
            Assert.AreEqual(qr_2.ErrorText, string.Empty);
            Assert.AreEqual(qr_2.Success, true);
            Assert.AreEqual(qr_2.HaveBeenFound, true);

            Assert.AreEqual(qr_2.Items.Count, 2);

            var targetItem = qr_2.Items[0];

            Assert.AreEqual(targetItem.Params.Count, 1);

            var targetVarItem = targetItem.Params.Single();

            Assert.AreEqual(targetVarItem.Kind, ExpressionNodeKind.Entity);
            Assert.AreEqual(targetVarItem.EntityKey, redKey);
            Assert.AreEqual(targetVarItem.ParamKey, x1VarKey);

            targetItem = qr_2.Items[1];

            Assert.AreEqual(targetItem.Params.Count, 1);

            targetVarItem = targetItem.Params.Single();

            Assert.AreEqual(targetVarItem.Kind, ExpressionNodeKind.Entity);
            Assert.AreEqual(targetVarItem.EntityKey, greenKey);
            Assert.AreEqual(targetVarItem.ParamKey, x1VarKey);
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
