using GnuClay.Engine.CGResolver.Implementations.FromECGToICG;
using GnuClay.Engine.ICG;
using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GnuClay.Engine.Tests
{
    [TestFixture]
    public class QueryStringHelperTests
    {
        [Test]
        public void CreateNodeNameInfo_NullOrEmpty_ThrowArgumentNullException()
        {
            var tmpEx = Assert.Catch<ArgumentNullException>(() => { _QueryStringHelper.CreateNodeNameInfo(null); });
            var tmpEx_1 = Assert.Catch<ArgumentNullException>(() => { _QueryStringHelper.CreateNodeNameInfo(string.Empty); });
        }

        [Test]
        public void CreateNodeNameInfo_Case_1()
        {
            var tmpStr = "dog";

            StringAssert.AreNotEqualIgnoringCase(string.Empty, tmpStr);
            StringAssert.AreNotEqualIgnoringCase(null, tmpStr);

            var tmpInfo = _QueryStringHelper.CreateNodeNameInfo(tmpStr);

            Assert.AreEqual(false, tmpInfo.HasQuestion);

            Assert.AreEqual(false, tmpInfo.HasVar);

            Assert.AreEqual(true, tmpInfo.HasClass);

            StringAssert.AreEqualIgnoringCase("dog", tmpInfo.ClassName);

            Assert.AreEqual(false, tmpInfo.HasClassQuestion);

            Assert.AreEqual(false, tmpInfo.HasClassVar);

            Assert.AreEqual(QuantificationInfo.None, tmpInfo.ClassQuantification);

            Assert.AreEqual(false, tmpInfo.HasInstance);

            Assert.AreEqual(false, tmpInfo.HasInstanceQuestion);

            Assert.AreEqual(false, tmpInfo.HasInstanceVar);

            StringAssert.AreEqualIgnoringCase(string.Empty, tmpInfo.InstanceName);

            Assert.AreEqual(QuantificationInfo.Universal, tmpInfo.InstanceQuantification);
        }

        [Test]
        public void CreateNodeNameInfo_Case_2()
        {
            var tmpStr = "dog cat";

            StringAssert.AreNotEqualIgnoringCase(string.Empty, tmpStr);
            StringAssert.AreNotEqualIgnoringCase(null, tmpStr);

            var tmpInfo = _QueryStringHelper.CreateNodeNameInfo(tmpStr);

            Assert.AreEqual(false, tmpInfo.HasQuestion);

            Assert.AreEqual(false, tmpInfo.HasVar);

            Assert.AreEqual(true, tmpInfo.HasClass);

            StringAssert.AreEqualIgnoringCase("dog cat", tmpInfo.ClassName);

            Assert.AreEqual(false, tmpInfo.HasClassQuestion);

            Assert.AreEqual(false, tmpInfo.HasClassVar);

            Assert.AreEqual(QuantificationInfo.None, tmpInfo.ClassQuantification);

            Assert.AreEqual(false, tmpInfo.HasInstance);

            Assert.AreEqual(false, tmpInfo.HasInstanceQuestion);

            Assert.AreEqual(false, tmpInfo.HasInstanceVar);

            StringAssert.AreEqualIgnoringCase(string.Empty, tmpInfo.InstanceName);

            Assert.AreEqual(QuantificationInfo.Universal, tmpInfo.InstanceQuantification);
        }

        [Test]
        public void CreateNodeNameInfo_Case_3()
        {
            var tmpStr = "dog(cat)";

            StringAssert.AreNotEqualIgnoringCase(string.Empty, tmpStr);
            StringAssert.AreNotEqualIgnoringCase(null, tmpStr);

            var tmpInfo = _QueryStringHelper.CreateNodeNameInfo(tmpStr);

            Assert.AreEqual(false, tmpInfo.HasQuestion);

            Assert.AreEqual(false, tmpInfo.HasVar);

            Assert.AreEqual(true, tmpInfo.HasClass);

            StringAssert.AreEqualIgnoringCase("dog(cat)", tmpInfo.ClassName);

            Assert.AreEqual(false, tmpInfo.HasClassQuestion);

            Assert.AreEqual(false, tmpInfo.HasClassVar);

            Assert.AreEqual(QuantificationInfo.None, tmpInfo.ClassQuantification);

            Assert.AreEqual(false, tmpInfo.HasInstance);

            Assert.AreEqual(false, tmpInfo.HasInstanceQuestion);

            Assert.AreEqual(false, tmpInfo.HasInstanceVar);

            StringAssert.AreEqualIgnoringCase(string.Empty, tmpInfo.InstanceName);

            Assert.AreEqual(QuantificationInfo.Universal, tmpInfo.InstanceQuantification);
        }

        [Test]
        public void CreateNodeNameInfo_Case_4()
        {
            var tmpStr = "#123";

            StringAssert.AreNotEqualIgnoringCase(string.Empty, tmpStr);
            StringAssert.AreNotEqualIgnoringCase(null, tmpStr);

            var tmpInfo = _QueryStringHelper.CreateNodeNameInfo(tmpStr);

            Assert.AreEqual(false, tmpInfo.HasQuestion);

            Assert.AreEqual(false, tmpInfo.HasVar);

            Assert.AreEqual(false, tmpInfo.HasClass);

            StringAssert.AreEqualIgnoringCase(string.Empty, tmpInfo.ClassName);

            Assert.AreEqual(false, tmpInfo.HasClassQuestion);

            Assert.AreEqual(false, tmpInfo.HasClassVar);

            Assert.AreEqual(QuantificationInfo.Universal, tmpInfo.ClassQuantification);

            Assert.AreEqual(true, tmpInfo.HasInstance);

            Assert.AreEqual(false, tmpInfo.HasInstanceQuestion);

            Assert.AreEqual(false, tmpInfo.HasInstanceVar);

            StringAssert.AreEqualIgnoringCase("123", tmpInfo.InstanceName);

            Assert.AreEqual(QuantificationInfo.None, tmpInfo.InstanceQuantification);
        }

        [Test]
        public void CreateNodeNameInfo_Case_5()
        {
            var tmpStr = "dog:#123";

            StringAssert.AreNotEqualIgnoringCase(string.Empty, tmpStr);
            StringAssert.AreNotEqualIgnoringCase(null, tmpStr);

            var tmpInfo = _QueryStringHelper.CreateNodeNameInfo(tmpStr);

            Assert.AreEqual(false, tmpInfo.HasQuestion);

            Assert.AreEqual(false, tmpInfo.HasVar);

            Assert.AreEqual(true, tmpInfo.HasClass);

            StringAssert.AreEqualIgnoringCase("dog", tmpInfo.ClassName);

            Assert.AreEqual(false, tmpInfo.HasClassQuestion);

            Assert.AreEqual(false, tmpInfo.HasClassVar);

            Assert.AreEqual(QuantificationInfo.None, tmpInfo.ClassQuantification);

            Assert.AreEqual(true, tmpInfo.HasInstance);

            Assert.AreEqual(false, tmpInfo.HasInstanceQuestion);

            Assert.AreEqual(false, tmpInfo.HasInstanceVar);

            StringAssert.AreEqualIgnoringCase("123", tmpInfo.InstanceName);

            Assert.AreEqual(QuantificationInfo.None, tmpInfo.InstanceQuantification);
        }

        [Test]
        public void CreateNodeNameInfo_Case_6()
        {
            var tmpStr = "dog:*";

            StringAssert.AreNotEqualIgnoringCase(string.Empty, tmpStr);
            StringAssert.AreNotEqualIgnoringCase(null, tmpStr);

            var tmpInfo = _QueryStringHelper.CreateNodeNameInfo(tmpStr);

            Assert.AreEqual(false, tmpInfo.HasQuestion);

            Assert.AreEqual(false, tmpInfo.HasVar);

            Assert.AreEqual(true, tmpInfo.HasClass);

            StringAssert.AreEqualIgnoringCase("dog", tmpInfo.ClassName);

            Assert.AreEqual(false, tmpInfo.HasClassQuestion);

            Assert.AreEqual(false, tmpInfo.HasClassVar);

            Assert.AreEqual(QuantificationInfo.None, tmpInfo.ClassQuantification);

            Assert.AreEqual(false, tmpInfo.HasInstance);

            Assert.AreEqual(false, tmpInfo.HasInstanceQuestion);

            Assert.AreEqual(false, tmpInfo.HasInstanceVar);

            StringAssert.AreEqualIgnoringCase(string.Empty, tmpInfo.InstanceName);

            Assert.AreEqual(QuantificationInfo.Universal, tmpInfo.InstanceQuantification);
        }

        [Test]
        public void CreateNodeNameInfo_Case_7()
        {
            var tmpStr = "dog:∀";

            StringAssert.AreNotEqualIgnoringCase(string.Empty, tmpStr);
            StringAssert.AreNotEqualIgnoringCase(null, tmpStr);

            var tmpInfo = _QueryStringHelper.CreateNodeNameInfo(tmpStr);

            Assert.AreEqual(false, tmpInfo.HasQuestion);

            Assert.AreEqual(false, tmpInfo.HasVar);

            Assert.AreEqual(true, tmpInfo.HasClass);

            StringAssert.AreEqualIgnoringCase("dog", tmpInfo.ClassName);

            Assert.AreEqual(false, tmpInfo.HasClassQuestion);

            Assert.AreEqual(false, tmpInfo.HasClassVar);

            Assert.AreEqual(QuantificationInfo.None, tmpInfo.ClassQuantification);

            Assert.AreEqual(false, tmpInfo.HasInstance);

            Assert.AreEqual(false, tmpInfo.HasInstanceQuestion);

            Assert.AreEqual(false, tmpInfo.HasInstanceVar);

            StringAssert.AreEqualIgnoringCase(string.Empty, tmpInfo.InstanceName);

            Assert.AreEqual(QuantificationInfo.Universal, tmpInfo.InstanceQuantification);
        }

        [Test]
        public void CreateNodeNameInfo_Case_8()
        {
            var tmpStr = "dog:∃";

            StringAssert.AreNotEqualIgnoringCase(string.Empty, tmpStr);
            StringAssert.AreNotEqualIgnoringCase(null, tmpStr);

            var tmpInfo = _QueryStringHelper.CreateNodeNameInfo(tmpStr);

            Assert.AreEqual(false, tmpInfo.HasQuestion);

            Assert.AreEqual(false, tmpInfo.HasVar);

            Assert.AreEqual(true, tmpInfo.HasClass);

            StringAssert.AreEqualIgnoringCase("dog", tmpInfo.ClassName);

            Assert.AreEqual(false, tmpInfo.HasClassQuestion);

            Assert.AreEqual(false, tmpInfo.HasClassVar);

            Assert.AreEqual(QuantificationInfo.None, tmpInfo.ClassQuantification);

            Assert.AreEqual(true, tmpInfo.HasInstance);

            Assert.AreEqual(false, tmpInfo.HasInstanceQuestion);

            Assert.AreEqual(false, tmpInfo.HasInstanceVar);

            StringAssert.AreEqualIgnoringCase(string.Empty, tmpInfo.InstanceName);

            Assert.AreEqual(QuantificationInfo.Existential, tmpInfo.InstanceQuantification);
        }

        [Test]
        public void CreateNodeNameInfo_Case_9()
        {
            var tmpStr = "dog:*X";

            StringAssert.AreNotEqualIgnoringCase(string.Empty, tmpStr);
            StringAssert.AreNotEqualIgnoringCase(null, tmpStr);

            var tmpInfo = _QueryStringHelper.CreateNodeNameInfo(tmpStr);

            Assert.AreEqual(false, tmpInfo.HasQuestion);

            Assert.AreEqual(true, tmpInfo.HasVar);

            Assert.AreEqual(true, tmpInfo.HasClass);

            StringAssert.AreEqualIgnoringCase("dog", tmpInfo.ClassName);

            Assert.AreEqual(false, tmpInfo.HasClassQuestion);

            Assert.AreEqual(false, tmpInfo.HasClassVar);

            Assert.AreEqual(QuantificationInfo.None, tmpInfo.ClassQuantification);

            Assert.AreEqual(true, tmpInfo.HasInstance);

            Assert.AreEqual(false, tmpInfo.HasInstanceQuestion);

            Assert.AreEqual(true, tmpInfo.HasInstanceVar);

            StringAssert.AreEqualIgnoringCase("X", tmpInfo.InstanceName);

            Assert.AreEqual(QuantificationInfo.Universal, tmpInfo.InstanceQuantification);
        }

        [Test]
        public void CreateNodeNameInfo_Case_10()
        {
            var tmpStr = "dog:∀X";

            StringAssert.AreNotEqualIgnoringCase(string.Empty, tmpStr);
            StringAssert.AreNotEqualIgnoringCase(null, tmpStr);

            var tmpInfo = _QueryStringHelper.CreateNodeNameInfo(tmpStr);

            Assert.AreEqual(false, tmpInfo.HasQuestion);

            Assert.AreEqual(true, tmpInfo.HasVar);

            Assert.AreEqual(true, tmpInfo.HasClass);

            StringAssert.AreEqualIgnoringCase("dog", tmpInfo.ClassName);

            Assert.AreEqual(false, tmpInfo.HasClassQuestion);

            Assert.AreEqual(false, tmpInfo.HasClassVar);

            Assert.AreEqual(QuantificationInfo.None, tmpInfo.ClassQuantification);

            Assert.AreEqual(true, tmpInfo.HasInstance);

            Assert.AreEqual(false, tmpInfo.HasInstanceQuestion);

            Assert.AreEqual(true, tmpInfo.HasInstanceVar);

            StringAssert.AreEqualIgnoringCase("X", tmpInfo.InstanceName);

            Assert.AreEqual(QuantificationInfo.Universal, tmpInfo.InstanceQuantification);
        }

        [Test]
        public void CreateNodeNameInfo_Case_11()
        {
            var tmpStr = "dog:∃X";

            StringAssert.AreNotEqualIgnoringCase(string.Empty, tmpStr);
            StringAssert.AreNotEqualIgnoringCase(null, tmpStr);

            var tmpInfo = _QueryStringHelper.CreateNodeNameInfo(tmpStr);

            Assert.AreEqual(false, tmpInfo.HasQuestion);

            Assert.AreEqual(true, tmpInfo.HasVar);

            Assert.AreEqual(true, tmpInfo.HasClass);

            StringAssert.AreEqualIgnoringCase("dog", tmpInfo.ClassName);

            Assert.AreEqual(false, tmpInfo.HasClassQuestion);

            Assert.AreEqual(false, tmpInfo.HasClassVar);

            Assert.AreEqual(QuantificationInfo.None, tmpInfo.ClassQuantification);

            Assert.AreEqual(true, tmpInfo.HasInstance);

            Assert.AreEqual(false, tmpInfo.HasInstanceQuestion);

            Assert.AreEqual(true, tmpInfo.HasInstanceVar);

            StringAssert.AreEqualIgnoringCase("X", tmpInfo.InstanceName);

            Assert.AreEqual(QuantificationInfo.Existential, tmpInfo.InstanceQuantification);
        }

        [Test]
        public void CreateNodeNameInfo_Case_12()
        {
            var tmpStr = "?";

            StringAssert.AreNotEqualIgnoringCase(string.Empty, tmpStr);
            StringAssert.AreNotEqualIgnoringCase(null, tmpStr);

            var tmpInfo = _QueryStringHelper.CreateNodeNameInfo(tmpStr);

            Assert.AreEqual(true, tmpInfo.HasQuestion);

            Assert.AreEqual(false, tmpInfo.HasVar);

            Assert.AreEqual(true, tmpInfo.HasClass);

            StringAssert.AreEqualIgnoringCase(string.Empty, tmpInfo.ClassName);

            Assert.AreEqual(true, tmpInfo.HasClassQuestion);

            Assert.AreEqual(false, tmpInfo.HasClassVar);

            Assert.AreEqual(QuantificationInfo.Universal, tmpInfo.ClassQuantification);

            Assert.AreEqual(false, tmpInfo.HasInstance);

            Assert.AreEqual(false, tmpInfo.HasInstanceQuestion);

            Assert.AreEqual(false, tmpInfo.HasInstanceVar);

            StringAssert.AreEqualIgnoringCase(string.Empty, tmpInfo.InstanceName);

            Assert.AreEqual(QuantificationInfo.Universal, tmpInfo.InstanceQuantification);
        }

        [Test]
        public void CreateNodeNameInfo_Case_13()
        {
            var tmpStr = "?X";

            StringAssert.AreNotEqualIgnoringCase(string.Empty, tmpStr);
            StringAssert.AreNotEqualIgnoringCase(null, tmpStr);

            var tmpInfo = _QueryStringHelper.CreateNodeNameInfo(tmpStr);

            Assert.AreEqual(true, tmpInfo.HasQuestion);

            Assert.AreEqual(true, tmpInfo.HasVar);

            Assert.AreEqual(true, tmpInfo.HasClass);

            StringAssert.AreEqualIgnoringCase("X", tmpInfo.ClassName);

            Assert.AreEqual(true, tmpInfo.HasClassQuestion);

            Assert.AreEqual(true, tmpInfo.HasClassVar);

            Assert.AreEqual(QuantificationInfo.Universal, tmpInfo.ClassQuantification);

            Assert.AreEqual(false, tmpInfo.HasInstance);

            Assert.AreEqual(false, tmpInfo.HasInstanceQuestion);

            Assert.AreEqual(false, tmpInfo.HasInstanceVar);

            StringAssert.AreEqualIgnoringCase(string.Empty, tmpInfo.InstanceName);

            Assert.AreEqual(QuantificationInfo.Universal, tmpInfo.InstanceQuantification);
        }

        [Test]
        public void CreateNodeNameInfo_Case_14()
        {
            var tmpStr = "?X:∀";

            StringAssert.AreNotEqualIgnoringCase(string.Empty, tmpStr);
            StringAssert.AreNotEqualIgnoringCase(null, tmpStr);

            var tmpInfo = _QueryStringHelper.CreateNodeNameInfo(tmpStr);

            Assert.AreEqual(true, tmpInfo.HasQuestion);

            Assert.AreEqual(true, tmpInfo.HasVar);

            Assert.AreEqual(true, tmpInfo.HasClass);

            StringAssert.AreEqualIgnoringCase("X", tmpInfo.ClassName);

            Assert.AreEqual(true, tmpInfo.HasClassQuestion);

            Assert.AreEqual(true, tmpInfo.HasClassVar);

            Assert.AreEqual(QuantificationInfo.Universal, tmpInfo.ClassQuantification);

            Assert.AreEqual(false, tmpInfo.HasInstance);

            Assert.AreEqual(false, tmpInfo.HasInstanceQuestion);

            Assert.AreEqual(false, tmpInfo.HasInstanceVar);

            StringAssert.AreEqualIgnoringCase(string.Empty, tmpInfo.InstanceName);

            Assert.AreEqual(QuantificationInfo.Universal, tmpInfo.InstanceQuantification);
        }

        [Test]
        public void CreateNodeNameInfo_Case_15()
        {
            var tmpStr = "?:∀";

            StringAssert.AreNotEqualIgnoringCase(string.Empty, tmpStr);
            StringAssert.AreNotEqualIgnoringCase(null, tmpStr);

            var tmpInfo = _QueryStringHelper.CreateNodeNameInfo(tmpStr);

            Assert.AreEqual(true, tmpInfo.HasQuestion);

            Assert.AreEqual(false, tmpInfo.HasVar);

            Assert.AreEqual(true, tmpInfo.HasClass);

            StringAssert.AreEqualIgnoringCase(string.Empty, tmpInfo.ClassName);

            Assert.AreEqual(true, tmpInfo.HasClassQuestion);

            Assert.AreEqual(false, tmpInfo.HasClassVar);

            Assert.AreEqual(QuantificationInfo.Universal, tmpInfo.ClassQuantification);

            Assert.AreEqual(false, tmpInfo.HasInstance);

            Assert.AreEqual(false, tmpInfo.HasInstanceQuestion);

            Assert.AreEqual(false, tmpInfo.HasInstanceVar);

            StringAssert.AreEqualIgnoringCase(string.Empty, tmpInfo.InstanceName);

            Assert.AreEqual(QuantificationInfo.Universal, tmpInfo.InstanceQuantification);
        }

        [Test]
        public void CreateNodeNameInfo_Case_16()
        {
            var tmpStr = "dog:#?X";

            StringAssert.AreNotEqualIgnoringCase(string.Empty, tmpStr);
            StringAssert.AreNotEqualIgnoringCase(null, tmpStr);

            var tmpInfo = _QueryStringHelper.CreateNodeNameInfo(tmpStr);

            Assert.AreEqual(true, tmpInfo.HasQuestion);

            Assert.AreEqual(true, tmpInfo.HasVar);

            Assert.AreEqual(true, tmpInfo.HasClass);

            StringAssert.AreEqualIgnoringCase("dog", tmpInfo.ClassName);

            Assert.AreEqual(false, tmpInfo.HasClassQuestion);

            Assert.AreEqual(false, tmpInfo.HasClassVar);

            Assert.AreEqual(QuantificationInfo.None, tmpInfo.ClassQuantification);

            Assert.AreEqual(true, tmpInfo.HasInstance);

            Assert.AreEqual(true, tmpInfo.HasInstanceQuestion);

            Assert.AreEqual(true, tmpInfo.HasInstanceVar);

            StringAssert.AreEqualIgnoringCase("X", tmpInfo.InstanceName);

            Assert.AreEqual(QuantificationInfo.Universal, tmpInfo.InstanceQuantification);
        }

        [Test]
        public void CreateNodeNameInfo_Case_17()
        {
            var tmpStr = "dog:#?";

            StringAssert.AreNotEqualIgnoringCase(string.Empty, tmpStr);
            StringAssert.AreNotEqualIgnoringCase(null, tmpStr);

            var tmpInfo = _QueryStringHelper.CreateNodeNameInfo(tmpStr);

            Assert.AreEqual(true, tmpInfo.HasQuestion);

            Assert.AreEqual(false, tmpInfo.HasVar);

            Assert.AreEqual(true, tmpInfo.HasClass);

            StringAssert.AreEqualIgnoringCase("dog", tmpInfo.ClassName);

            Assert.AreEqual(false, tmpInfo.HasClassQuestion);

            Assert.AreEqual(false, tmpInfo.HasClassVar);

            Assert.AreEqual(QuantificationInfo.None, tmpInfo.ClassQuantification);

            Assert.AreEqual(true, tmpInfo.HasInstance);

            Assert.AreEqual(true, tmpInfo.HasInstanceQuestion);

            Assert.AreEqual(false, tmpInfo.HasInstanceVar);

            StringAssert.AreEqualIgnoringCase(string.Empty, tmpInfo.InstanceName);

            Assert.AreEqual(QuantificationInfo.Universal, tmpInfo.InstanceQuantification);
        }

        [Test]
        public void CreateNodeNameInfo_Case_18()
        {
            var tmpStr = "dog:?";

            StringAssert.AreNotEqualIgnoringCase(string.Empty, tmpStr);
            StringAssert.AreNotEqualIgnoringCase(null, tmpStr);

            var tmpInfo = _QueryStringHelper.CreateNodeNameInfo(tmpStr);

            Assert.AreEqual(true, tmpInfo.HasQuestion);

            Assert.AreEqual(false, tmpInfo.HasVar);

            Assert.AreEqual(true, tmpInfo.HasClass);

            StringAssert.AreEqualIgnoringCase("dog", tmpInfo.ClassName);

            Assert.AreEqual(false, tmpInfo.HasClassQuestion);

            Assert.AreEqual(false, tmpInfo.HasClassVar);

            Assert.AreEqual(QuantificationInfo.None, tmpInfo.ClassQuantification);

            Assert.AreEqual(true, tmpInfo.HasInstance);

            Assert.AreEqual(true, tmpInfo.HasInstanceQuestion);

            Assert.AreEqual(false, tmpInfo.HasInstanceVar);

            StringAssert.AreEqualIgnoringCase(string.Empty, tmpInfo.InstanceName);

            Assert.AreEqual(QuantificationInfo.Universal, tmpInfo.InstanceQuantification);
        }

        [Test]
        public void CreateNodeNameInfo_Case_19()
        {
            var tmpStr = "dog:?X";

            StringAssert.AreNotEqualIgnoringCase(string.Empty, tmpStr);
            StringAssert.AreNotEqualIgnoringCase(null, tmpStr);

            var tmpInfo = _QueryStringHelper.CreateNodeNameInfo(tmpStr);

            Assert.AreEqual(true, tmpInfo.HasQuestion);

            Assert.AreEqual(true, tmpInfo.HasVar);

            Assert.AreEqual(true, tmpInfo.HasClass);

            StringAssert.AreEqualIgnoringCase("dog", tmpInfo.ClassName);

            Assert.AreEqual(false, tmpInfo.HasClassQuestion);

            Assert.AreEqual(false, tmpInfo.HasClassVar);

            Assert.AreEqual(QuantificationInfo.None, tmpInfo.ClassQuantification);

            Assert.AreEqual(true, tmpInfo.HasInstance);

            Assert.AreEqual(true, tmpInfo.HasInstanceQuestion);

            Assert.AreEqual(true, tmpInfo.HasInstanceVar);

            StringAssert.AreEqualIgnoringCase("X", tmpInfo.InstanceName);

            Assert.AreEqual(QuantificationInfo.Universal, tmpInfo.InstanceQuantification);
        }

        [Test]
        public void CreateNodeNameInfo_Case_20()
        {
            var tmpStr = "dog::";

            StringAssert.AreNotEqualIgnoringCase(string.Empty, tmpStr);
            StringAssert.AreNotEqualIgnoringCase(null, tmpStr);

            var tmpEx = Assert.Catch<ArgumentException>(() => { _QueryStringHelper.CreateNodeNameInfo(tmpStr); });
        }

        [Test]
        public void CreateNodeNameInfo_Case_21()
        {
            var tmpStr = "dog:";

            StringAssert.AreNotEqualIgnoringCase(string.Empty, tmpStr);
            StringAssert.AreNotEqualIgnoringCase(null, tmpStr);

            var tmpEx = Assert.Catch<ArgumentException>(() => { _QueryStringHelper.CreateNodeNameInfo(tmpStr); });
        }

        [Test]
        public void CreateNodeNameInfo_Case_22()
        {
            var tmpStr = "dog:cat";

            StringAssert.AreNotEqualIgnoringCase(string.Empty, tmpStr);
            StringAssert.AreNotEqualIgnoringCase(null, tmpStr);

            var tmpEx = Assert.Catch<ArgumentException>(() => { _QueryStringHelper.CreateNodeNameInfo(tmpStr); });
        }

        [Test]
        public void CreateNodeNameInfo_Case_23()
        {
            var tmpStr = "dog:#123#";

            StringAssert.AreNotEqualIgnoringCase(string.Empty, tmpStr);
            StringAssert.AreNotEqualIgnoringCase(null, tmpStr);

            var tmpEx = Assert.Catch<ArgumentException>(() => { _QueryStringHelper.CreateNodeNameInfo(tmpStr); });
        }

        [Test]
        public void CreateNodeNameInfo_Case_24()
        {
            var tmpStr = "dog:#123!";

            StringAssert.AreNotEqualIgnoringCase(string.Empty, tmpStr);
            StringAssert.AreNotEqualIgnoringCase(null, tmpStr);

            var tmpEx = Assert.Catch<ArgumentException>(() => { _QueryStringHelper.CreateNodeNameInfo(tmpStr); });
        }

        [Test]
        public void CreateNodeNameInfo_Case_25()
        {
            var tmpStr = "dog#1";

            StringAssert.AreNotEqualIgnoringCase(string.Empty, tmpStr);
            StringAssert.AreNotEqualIgnoringCase(null, tmpStr);

            var tmpEx = Assert.Catch<ArgumentException>(() => { _QueryStringHelper.CreateNodeNameInfo(tmpStr); });
        }

        [Test]
        public void CreateNodeNameInfo_Case_26()
        {
            var tmpStr = "dog#";

            StringAssert.AreNotEqualIgnoringCase(string.Empty, tmpStr);
            StringAssert.AreNotEqualIgnoringCase(null, tmpStr);

            var tmpEx = Assert.Catch<ArgumentException>(() => { _QueryStringHelper.CreateNodeNameInfo(tmpStr); });
        }

        [Test]
        public void CreateNodeNameInfo_Case_27()
        {
            var tmpStr = "#";

            StringAssert.AreNotEqualIgnoringCase(string.Empty, tmpStr);
            StringAssert.AreNotEqualIgnoringCase(null, tmpStr);

            var tmpEx = Assert.Catch<ArgumentException>(() => { _QueryStringHelper.CreateNodeNameInfo(tmpStr); });
        }

        [Test]
        public void CreateNodeNameInfo_Case_28()
        {
            var tmpStr = ":";

            StringAssert.AreNotEqualIgnoringCase(string.Empty, tmpStr);
            StringAssert.AreNotEqualIgnoringCase(null, tmpStr);

            var tmpEx = Assert.Catch<ArgumentException>(() => { _QueryStringHelper.CreateNodeNameInfo(tmpStr); });
        }

        [Test]
        public void CreateNodeNameInfo_Case_29()
        {
            var tmpStr = "!";

            StringAssert.AreNotEqualIgnoringCase(string.Empty, tmpStr);
            StringAssert.AreNotEqualIgnoringCase(null, tmpStr);

            var tmpEx = Assert.Catch<ArgumentException>(() => { _QueryStringHelper.CreateNodeNameInfo(tmpStr); });
        }

        [Test]
        public void CreateNodeNameInfo_Case_30()
        {
            var tmpStr = "∀";

            StringAssert.AreNotEqualIgnoringCase(string.Empty, tmpStr);
            StringAssert.AreNotEqualIgnoringCase(null, tmpStr);

            var tmpInfo = _QueryStringHelper.CreateNodeNameInfo(tmpStr);

            Assert.AreEqual(false, tmpInfo.HasQuestion);

            Assert.AreEqual(false, tmpInfo.HasVar);

            Assert.AreEqual(false, tmpInfo.HasClass);

            StringAssert.AreEqualIgnoringCase(string.Empty, tmpInfo.ClassName);

            Assert.AreEqual(false, tmpInfo.HasClassQuestion);

            Assert.AreEqual(false, tmpInfo.HasClassVar);

            Assert.AreEqual(QuantificationInfo.Universal, tmpInfo.ClassQuantification);

            Assert.AreEqual(false, tmpInfo.HasInstance);

            Assert.AreEqual(false, tmpInfo.HasInstanceQuestion);

            Assert.AreEqual(false, tmpInfo.HasInstanceVar);

            StringAssert.AreEqualIgnoringCase(string.Empty, tmpInfo.InstanceName);

            Assert.AreEqual(QuantificationInfo.Universal, tmpInfo.InstanceQuantification);
        }

        [Test]
        public void CreateNodeNameInfo_Case_31()
        {
            var tmpStr = "∃";

            StringAssert.AreNotEqualIgnoringCase(string.Empty, tmpStr);
            StringAssert.AreNotEqualIgnoringCase(null, tmpStr);

            var tmpInfo = _QueryStringHelper.CreateNodeNameInfo(tmpStr);

            Assert.AreEqual(false, tmpInfo.HasQuestion);

            Assert.AreEqual(false, tmpInfo.HasVar);

            Assert.AreEqual(true, tmpInfo.HasClass);

            StringAssert.AreEqualIgnoringCase(string.Empty, tmpInfo.ClassName);

            Assert.AreEqual(false, tmpInfo.HasClassQuestion);

            Assert.AreEqual(false, tmpInfo.HasClassVar);

            Assert.AreEqual(QuantificationInfo.Existential, tmpInfo.ClassQuantification);

            Assert.AreEqual(false, tmpInfo.HasInstance);

            Assert.AreEqual(false, tmpInfo.HasInstanceQuestion);

            Assert.AreEqual(false, tmpInfo.HasInstanceVar);

            StringAssert.AreEqualIgnoringCase(string.Empty, tmpInfo.InstanceName);

            Assert.AreEqual(QuantificationInfo.Universal, tmpInfo.InstanceQuantification);
        }

        [Test]
        public void CreateNodeNameInfo_Case_32()
        {
            var tmpStr = "*";

            StringAssert.AreNotEqualIgnoringCase(string.Empty, tmpStr);
            StringAssert.AreNotEqualIgnoringCase(null, tmpStr);

            var tmpInfo = _QueryStringHelper.CreateNodeNameInfo(tmpStr);

            Assert.AreEqual(false, tmpInfo.HasQuestion);

            Assert.AreEqual(false, tmpInfo.HasVar);

            Assert.AreEqual(false, tmpInfo.HasClass);

            StringAssert.AreEqualIgnoringCase(string.Empty, tmpInfo.ClassName);

            Assert.AreEqual(false, tmpInfo.HasClassQuestion);

            Assert.AreEqual(false, tmpInfo.HasClassVar);

            Assert.AreEqual(QuantificationInfo.Universal, tmpInfo.ClassQuantification);

            Assert.AreEqual(false, tmpInfo.HasInstance);

            Assert.AreEqual(false, tmpInfo.HasInstanceQuestion);

            Assert.AreEqual(false, tmpInfo.HasInstanceVar);

            StringAssert.AreEqualIgnoringCase(string.Empty, tmpInfo.InstanceName);

            Assert.AreEqual(QuantificationInfo.Universal, tmpInfo.InstanceQuantification);
        }

        [Test]
        public void CreateNodeNameInfo_Case_33()
        {
            var tmpStr = "dog ∀";

            StringAssert.AreNotEqualIgnoringCase(string.Empty, tmpStr);
            StringAssert.AreNotEqualIgnoringCase(null, tmpStr);

            var tmpEx = Assert.Catch<ArgumentException>(() => { _QueryStringHelper.CreateNodeNameInfo(tmpStr); });
        }

        [Test]
        public void CreateNodeNameInfo_Case_34()
        {
            var tmpStr = "dog ∃";

            StringAssert.AreNotEqualIgnoringCase(string.Empty, tmpStr);
            StringAssert.AreNotEqualIgnoringCase(null, tmpStr);

            var tmpEx = Assert.Catch<ArgumentException>(() => { _QueryStringHelper.CreateNodeNameInfo(tmpStr); });
        }

        [Test]
        public void CreateNodeNameInfo_Case_35()
        {
            var tmpStr = "dog !";

            StringAssert.AreNotEqualIgnoringCase(string.Empty, tmpStr);
            StringAssert.AreNotEqualIgnoringCase(null, tmpStr);

            var tmpEx = Assert.Catch<ArgumentException>(() => { _QueryStringHelper.CreateNodeNameInfo(tmpStr); });
        }

        [Test]
        public void CreateNodeNameInfo_Case_36()
        {
            var tmpStr = "dog *";

            StringAssert.AreNotEqualIgnoringCase(string.Empty, tmpStr);
            StringAssert.AreNotEqualIgnoringCase(null, tmpStr);

            var tmpEx = Assert.Catch<ArgumentException>(() => { _QueryStringHelper.CreateNodeNameInfo(tmpStr); });
        }

        [Test]
        public void CreateNodeNameInfo_Case_37()
        {
            var tmpStr = "∃:∃";

            StringAssert.AreNotEqualIgnoringCase(string.Empty, tmpStr);
            StringAssert.AreNotEqualIgnoringCase(null, tmpStr);

            var tmpInfo = _QueryStringHelper.CreateNodeNameInfo(tmpStr);

            Assert.AreEqual(false, tmpInfo.HasQuestion);

            Assert.AreEqual(false, tmpInfo.HasVar);

            Assert.AreEqual(true, tmpInfo.HasClass);

            StringAssert.AreEqualIgnoringCase(string.Empty, tmpInfo.ClassName);

            Assert.AreEqual(false, tmpInfo.HasClassQuestion);

            Assert.AreEqual(false, tmpInfo.HasClassVar);

            Assert.AreEqual(QuantificationInfo.Existential, tmpInfo.ClassQuantification);

            Assert.AreEqual(true, tmpInfo.HasInstance);

            Assert.AreEqual(false, tmpInfo.HasInstanceQuestion);

            Assert.AreEqual(false, tmpInfo.HasInstanceVar);

            StringAssert.AreEqualIgnoringCase(string.Empty, tmpInfo.InstanceName);

            Assert.AreEqual(QuantificationInfo.Existential, tmpInfo.InstanceQuantification);
        }

        [Test]
        public void CreateNodeNameInfo_Case_38()
        {
            var tmpStr = "∀:∀";

            StringAssert.AreNotEqualIgnoringCase(string.Empty, tmpStr);
            StringAssert.AreNotEqualIgnoringCase(null, tmpStr);

            var tmpInfo = _QueryStringHelper.CreateNodeNameInfo(tmpStr);

            Assert.AreEqual(false, tmpInfo.HasQuestion);

            Assert.AreEqual(false, tmpInfo.HasVar);

            Assert.AreEqual(false, tmpInfo.HasClass);

            StringAssert.AreEqualIgnoringCase(string.Empty, tmpInfo.ClassName);

            Assert.AreEqual(false, tmpInfo.HasClassQuestion);

            Assert.AreEqual(false, tmpInfo.HasClassVar);

            Assert.AreEqual(QuantificationInfo.Universal, tmpInfo.ClassQuantification);

            Assert.AreEqual(false, tmpInfo.HasInstance);

            Assert.AreEqual(false, tmpInfo.HasInstanceQuestion);

            Assert.AreEqual(false, tmpInfo.HasInstanceVar);

            StringAssert.AreEqualIgnoringCase(string.Empty, tmpInfo.InstanceName);

            Assert.AreEqual(QuantificationInfo.Universal, tmpInfo.InstanceQuantification);
        }

        [Test]
        public void CreateNodeNameInfo_Case_39()
        {
            var tmpStr = "∃:∀";

            StringAssert.AreNotEqualIgnoringCase(string.Empty, tmpStr);
            StringAssert.AreNotEqualIgnoringCase(null, tmpStr);

            var tmpInfo = _QueryStringHelper.CreateNodeNameInfo(tmpStr);

            Assert.AreEqual(false, tmpInfo.HasQuestion);

            Assert.AreEqual(false, tmpInfo.HasVar);

            Assert.AreEqual(true, tmpInfo.HasClass);

            StringAssert.AreEqualIgnoringCase(string.Empty, tmpInfo.ClassName);

            Assert.AreEqual(false, tmpInfo.HasClassQuestion);

            Assert.AreEqual(false, tmpInfo.HasClassVar);

            Assert.AreEqual(QuantificationInfo.Existential, tmpInfo.ClassQuantification);

            Assert.AreEqual(false, tmpInfo.HasInstance);

            Assert.AreEqual(false, tmpInfo.HasInstanceQuestion);

            Assert.AreEqual(false, tmpInfo.HasInstanceVar);

            StringAssert.AreEqualIgnoringCase(string.Empty, tmpInfo.InstanceName);

            Assert.AreEqual(QuantificationInfo.Universal, tmpInfo.InstanceQuantification);
        }

        [Test]
        public void CreateNodeNameInfo_Case_40()
        {
            var tmpStr = "∀:*";

            StringAssert.AreNotEqualIgnoringCase(string.Empty, tmpStr);
            StringAssert.AreNotEqualIgnoringCase(null, tmpStr);

            var tmpInfo = _QueryStringHelper.CreateNodeNameInfo(tmpStr);

            Assert.AreEqual(false, tmpInfo.HasQuestion);

            Assert.AreEqual(false, tmpInfo.HasVar);

            Assert.AreEqual(false, tmpInfo.HasClass);

            StringAssert.AreEqualIgnoringCase(string.Empty, tmpInfo.ClassName);

            Assert.AreEqual(false, tmpInfo.HasClassQuestion);

            Assert.AreEqual(false, tmpInfo.HasClassVar);

            Assert.AreEqual(QuantificationInfo.Universal, tmpInfo.ClassQuantification);

            Assert.AreEqual(false, tmpInfo.HasInstance);

            Assert.AreEqual(false, tmpInfo.HasInstanceQuestion);

            Assert.AreEqual(false, tmpInfo.HasInstanceVar);

            StringAssert.AreEqualIgnoringCase(string.Empty, tmpInfo.InstanceName);

            Assert.AreEqual(QuantificationInfo.Universal, tmpInfo.InstanceQuantification);
        }

        [Test]
        public void CreateNodeNameInfo_Case_41()
        {
            var tmpStr = "?∀";

            StringAssert.AreNotEqualIgnoringCase(string.Empty, tmpStr);
            StringAssert.AreNotEqualIgnoringCase(null, tmpStr);

            var tmpInfo = _QueryStringHelper.CreateNodeNameInfo(tmpStr);

            Assert.AreEqual(true, tmpInfo.HasQuestion);

            Assert.AreEqual(false, tmpInfo.HasVar);

            Assert.AreEqual(true, tmpInfo.HasClass);

            StringAssert.AreEqualIgnoringCase(string.Empty, tmpInfo.ClassName);

            Assert.AreEqual(true, tmpInfo.HasClassQuestion);

            Assert.AreEqual(false, tmpInfo.HasClassVar);

            Assert.AreEqual(QuantificationInfo.Universal, tmpInfo.ClassQuantification);

            Assert.AreEqual(false, tmpInfo.HasInstance);

            Assert.AreEqual(false, tmpInfo.HasInstanceQuestion);

            Assert.AreEqual(false, tmpInfo.HasInstanceVar);

            StringAssert.AreEqualIgnoringCase(string.Empty, tmpInfo.InstanceName);

            Assert.AreEqual(QuantificationInfo.Universal, tmpInfo.InstanceQuantification);
        }

        [Test]
        public void CreateNodeNameInfo_Case_42()
        {
            var tmpStr = "?∃";

            StringAssert.AreNotEqualIgnoringCase(string.Empty, tmpStr);
            StringAssert.AreNotEqualIgnoringCase(null, tmpStr);

            var tmpInfo = _QueryStringHelper.CreateNodeNameInfo(tmpStr);

            Assert.AreEqual(true, tmpInfo.HasQuestion);

            Assert.AreEqual(false, tmpInfo.HasVar);

            Assert.AreEqual(true, tmpInfo.HasClass);

            StringAssert.AreEqualIgnoringCase(string.Empty, tmpInfo.ClassName);

            Assert.AreEqual(true, tmpInfo.HasClassQuestion);

            Assert.AreEqual(false, tmpInfo.HasClassVar);

            Assert.AreEqual(QuantificationInfo.Existential, tmpInfo.ClassQuantification);

            Assert.AreEqual(false, tmpInfo.HasInstance);

            Assert.AreEqual(false, tmpInfo.HasInstanceQuestion);

            Assert.AreEqual(false, tmpInfo.HasInstanceVar);

            StringAssert.AreEqualIgnoringCase(string.Empty, tmpInfo.InstanceName);

            Assert.AreEqual(QuantificationInfo.Universal, tmpInfo.InstanceQuantification);
        }

        [Test]
        public void CreateNodeNameInfo_Case_43()
        {
            var tmpStr = "?*";

            StringAssert.AreNotEqualIgnoringCase(string.Empty, tmpStr);
            StringAssert.AreNotEqualIgnoringCase(null, tmpStr);

            var tmpInfo = _QueryStringHelper.CreateNodeNameInfo(tmpStr);

            Assert.AreEqual(true, tmpInfo.HasQuestion);

            Assert.AreEqual(false, tmpInfo.HasVar);

            Assert.AreEqual(true, tmpInfo.HasClass);

            StringAssert.AreEqualIgnoringCase(string.Empty, tmpInfo.ClassName);

            Assert.AreEqual(true, tmpInfo.HasClassQuestion);

            Assert.AreEqual(false, tmpInfo.HasClassVar);

            Assert.AreEqual(QuantificationInfo.Universal, tmpInfo.ClassQuantification);

            Assert.AreEqual(false, tmpInfo.HasInstance);

            Assert.AreEqual(false, tmpInfo.HasInstanceQuestion);

            Assert.AreEqual(false, tmpInfo.HasInstanceVar);

            StringAssert.AreEqualIgnoringCase(string.Empty, tmpInfo.InstanceName);

            Assert.AreEqual(QuantificationInfo.Universal, tmpInfo.InstanceQuantification);
        }

        [Test]
        public void CreateNodeNameInfo_Case_44()
        {
            var tmpStr = "?∀X";

            StringAssert.AreNotEqualIgnoringCase(string.Empty, tmpStr);
            StringAssert.AreNotEqualIgnoringCase(null, tmpStr);

            var tmpInfo = _QueryStringHelper.CreateNodeNameInfo(tmpStr);

            Assert.AreEqual(true, tmpInfo.HasQuestion);

            Assert.AreEqual(true, tmpInfo.HasVar);

            Assert.AreEqual(true, tmpInfo.HasClass);

            StringAssert.AreEqualIgnoringCase("X", tmpInfo.ClassName);

            Assert.AreEqual(true, tmpInfo.HasClassQuestion);

            Assert.AreEqual(true, tmpInfo.HasClassVar);

            Assert.AreEqual(QuantificationInfo.Universal, tmpInfo.ClassQuantification);

            Assert.AreEqual(false, tmpInfo.HasInstance);

            Assert.AreEqual(false, tmpInfo.HasInstanceQuestion);

            Assert.AreEqual(false, tmpInfo.HasInstanceVar);

            StringAssert.AreEqualIgnoringCase(string.Empty, tmpInfo.InstanceName);

            Assert.AreEqual(QuantificationInfo.Universal, tmpInfo.InstanceQuantification);
        }

        [Test]
        public void CreateNodeNameInfo_Case_45()
        {
            var tmpStr = "?∃X";

            StringAssert.AreNotEqualIgnoringCase(string.Empty, tmpStr);
            StringAssert.AreNotEqualIgnoringCase(null, tmpStr);

            var tmpInfo = _QueryStringHelper.CreateNodeNameInfo(tmpStr);

            Assert.AreEqual(true, tmpInfo.HasQuestion);

            Assert.AreEqual(true, tmpInfo.HasVar);

            Assert.AreEqual(true, tmpInfo.HasClass);

            StringAssert.AreEqualIgnoringCase("X", tmpInfo.ClassName);

            Assert.AreEqual(true, tmpInfo.HasClassQuestion);

            Assert.AreEqual(true, tmpInfo.HasClassVar);

            Assert.AreEqual(QuantificationInfo.Existential, tmpInfo.ClassQuantification);

            Assert.AreEqual(false, tmpInfo.HasInstance);

            Assert.AreEqual(false, tmpInfo.HasInstanceQuestion);

            Assert.AreEqual(false, tmpInfo.HasInstanceVar);

            StringAssert.AreEqualIgnoringCase(string.Empty, tmpInfo.InstanceName);

            Assert.AreEqual(QuantificationInfo.Universal, tmpInfo.InstanceQuantification);
        }

        [Test]
        public void CreateNodeNameInfo_Case_46()
        {
            var tmpStr = "?*X";

            StringAssert.AreNotEqualIgnoringCase(string.Empty, tmpStr);
            StringAssert.AreNotEqualIgnoringCase(null, tmpStr);

            var tmpInfo = _QueryStringHelper.CreateNodeNameInfo(tmpStr);

            Assert.AreEqual(true, tmpInfo.HasQuestion);

            Assert.AreEqual(true, tmpInfo.HasVar);

            Assert.AreEqual(true, tmpInfo.HasClass);

            StringAssert.AreEqualIgnoringCase("X", tmpInfo.ClassName);

            Assert.AreEqual(true, tmpInfo.HasClassQuestion);

            Assert.AreEqual(true, tmpInfo.HasClassVar);

            Assert.AreEqual(QuantificationInfo.Universal, tmpInfo.ClassQuantification);

            Assert.AreEqual(false, tmpInfo.HasInstance);

            Assert.AreEqual(false, tmpInfo.HasInstanceQuestion);

            Assert.AreEqual(false, tmpInfo.HasInstanceVar);

            StringAssert.AreEqualIgnoringCase(string.Empty, tmpInfo.InstanceName);

            Assert.AreEqual(QuantificationInfo.Universal, tmpInfo.InstanceQuantification);
        }

        [Test]
        public void CreateNodeNameInfo_Case_47()
        {
            var tmpStr = "dog:#123:";

            StringAssert.AreNotEqualIgnoringCase(string.Empty, tmpStr);
            StringAssert.AreNotEqualIgnoringCase(null, tmpStr);

            var tmpEx = Assert.Catch<ArgumentException>(() => { _QueryStringHelper.CreateNodeNameInfo(tmpStr); });
        }

        [Test]
        public void CreateNodeNameInfo_Case_48()
        {
            var tmpStr = "∃dog";

            StringAssert.AreNotEqualIgnoringCase(string.Empty, tmpStr);
            StringAssert.AreNotEqualIgnoringCase(null, tmpStr);

            var tmpInfo = _QueryStringHelper.CreateNodeNameInfo(tmpStr);

            Assert.AreEqual(false, tmpInfo.HasQuestion);

            Assert.AreEqual(true, tmpInfo.HasVar);

            Assert.AreEqual(true, tmpInfo.HasClass);

            StringAssert.AreEqualIgnoringCase("dog", tmpInfo.ClassName);

            Assert.AreEqual(false, tmpInfo.HasClassQuestion);

            Assert.AreEqual(true, tmpInfo.HasClassVar);

            Assert.AreEqual(QuantificationInfo.Existential, tmpInfo.ClassQuantification);

            Assert.AreEqual(false, tmpInfo.HasInstance);

            Assert.AreEqual(false, tmpInfo.HasInstanceQuestion);

            Assert.AreEqual(false, tmpInfo.HasInstanceVar);

            StringAssert.AreEqualIgnoringCase(string.Empty, tmpInfo.InstanceName);

            Assert.AreEqual(QuantificationInfo.Universal, tmpInfo.InstanceQuantification);
        }

        [Test]
        public void CreateNodeNameInfo_Case_49()
        {
            var tmpStr = "∃ dog";

            StringAssert.AreNotEqualIgnoringCase(string.Empty, tmpStr);
            StringAssert.AreNotEqualIgnoringCase(null, tmpStr);

            var tmpInfo = _QueryStringHelper.CreateNodeNameInfo(tmpStr);

            Assert.AreEqual(false, tmpInfo.HasQuestion);

            Assert.AreEqual(true, tmpInfo.HasVar);

            Assert.AreEqual(true, tmpInfo.HasClass);

            StringAssert.AreEqualIgnoringCase("dog", tmpInfo.ClassName);

            Assert.AreEqual(false, tmpInfo.HasClassQuestion);

            Assert.AreEqual(true, tmpInfo.HasClassVar);

            Assert.AreEqual(QuantificationInfo.Existential, tmpInfo.ClassQuantification);

            Assert.AreEqual(false, tmpInfo.HasInstance);

            Assert.AreEqual(false, tmpInfo.HasInstanceQuestion);

            Assert.AreEqual(false, tmpInfo.HasInstanceVar);

            StringAssert.AreEqualIgnoringCase(string.Empty, tmpInfo.InstanceName);

            Assert.AreEqual(QuantificationInfo.Universal, tmpInfo.InstanceQuantification);
        }

        [Test]
        public void CreateNodeNameInfo_Case_50()
        {
            var tmpStr = "∀dog";

            StringAssert.AreNotEqualIgnoringCase(string.Empty, tmpStr);
            StringAssert.AreNotEqualIgnoringCase(null, tmpStr);

            var tmpInfo = _QueryStringHelper.CreateNodeNameInfo(tmpStr);

            Assert.AreEqual(false, tmpInfo.HasQuestion);

            Assert.AreEqual(true, tmpInfo.HasVar);

            Assert.AreEqual(true, tmpInfo.HasClass);

            StringAssert.AreEqualIgnoringCase("dog", tmpInfo.ClassName);

            Assert.AreEqual(false, tmpInfo.HasClassQuestion);

            Assert.AreEqual(true, tmpInfo.HasClassVar);

            Assert.AreEqual(QuantificationInfo.Universal, tmpInfo.ClassQuantification);

            Assert.AreEqual(false, tmpInfo.HasInstance);

            Assert.AreEqual(false, tmpInfo.HasInstanceQuestion);

            Assert.AreEqual(false, tmpInfo.HasInstanceVar);

            StringAssert.AreEqualIgnoringCase(string.Empty, tmpInfo.InstanceName);

            Assert.AreEqual(QuantificationInfo.Universal, tmpInfo.InstanceQuantification);
        }

        [Test]
        public void CreateNodeNameInfo_Case_51()
        {
            var tmpStr = "∀ dog";

            StringAssert.AreNotEqualIgnoringCase(string.Empty, tmpStr);
            StringAssert.AreNotEqualIgnoringCase(null, tmpStr);

            var tmpInfo = _QueryStringHelper.CreateNodeNameInfo(tmpStr);

            Assert.AreEqual(false, tmpInfo.HasQuestion);

            Assert.AreEqual(true, tmpInfo.HasVar);

            Assert.AreEqual(true, tmpInfo.HasClass);

            StringAssert.AreEqualIgnoringCase("dog", tmpInfo.ClassName);

            Assert.AreEqual(false, tmpInfo.HasClassQuestion);

            Assert.AreEqual(true, tmpInfo.HasClassVar);

            Assert.AreEqual(QuantificationInfo.Universal, tmpInfo.ClassQuantification);

            Assert.AreEqual(false, tmpInfo.HasInstance);

            Assert.AreEqual(false, tmpInfo.HasInstanceQuestion);

            Assert.AreEqual(false, tmpInfo.HasInstanceVar);

            StringAssert.AreEqualIgnoringCase(string.Empty, tmpInfo.InstanceName);

            Assert.AreEqual(QuantificationInfo.Universal, tmpInfo.InstanceQuantification);
        }

        [Test]
        public void CreateNodeNameInfo_Case_52()
        {
            var tmpStr = "*dog";

            StringAssert.AreNotEqualIgnoringCase(string.Empty, tmpStr);
            StringAssert.AreNotEqualIgnoringCase(null, tmpStr);

            var tmpInfo = _QueryStringHelper.CreateNodeNameInfo(tmpStr);

            Assert.AreEqual(false, tmpInfo.HasQuestion);

            Assert.AreEqual(true, tmpInfo.HasVar);

            Assert.AreEqual(true, tmpInfo.HasClass);

            StringAssert.AreEqualIgnoringCase("dog", tmpInfo.ClassName);

            Assert.AreEqual(false, tmpInfo.HasClassQuestion);

            Assert.AreEqual(true, tmpInfo.HasClassVar);

            Assert.AreEqual(QuantificationInfo.Universal, tmpInfo.ClassQuantification);

            Assert.AreEqual(false, tmpInfo.HasInstance);

            Assert.AreEqual(false, tmpInfo.HasInstanceQuestion);

            Assert.AreEqual(false, tmpInfo.HasInstanceVar);

            StringAssert.AreEqualIgnoringCase(string.Empty, tmpInfo.InstanceName);

            Assert.AreEqual(QuantificationInfo.Universal, tmpInfo.InstanceQuantification);
        }

        [Test]
        public void CreateNodeNameInfo_Case_53()
        {
            var tmpStr = "* dog";

            StringAssert.AreNotEqualIgnoringCase(string.Empty, tmpStr);
            StringAssert.AreNotEqualIgnoringCase(null, tmpStr);

            var tmpInfo = _QueryStringHelper.CreateNodeNameInfo(tmpStr);

            Assert.AreEqual(false, tmpInfo.HasQuestion);

            Assert.AreEqual(true, tmpInfo.HasVar);

            Assert.AreEqual(true, tmpInfo.HasClass);

            StringAssert.AreEqualIgnoringCase("dog", tmpInfo.ClassName);

            Assert.AreEqual(false, tmpInfo.HasClassQuestion);

            Assert.AreEqual(true, tmpInfo.HasClassVar);

            Assert.AreEqual(QuantificationInfo.Universal, tmpInfo.ClassQuantification);

            Assert.AreEqual(false, tmpInfo.HasInstance);

            Assert.AreEqual(false, tmpInfo.HasInstanceQuestion);

            Assert.AreEqual(false, tmpInfo.HasInstanceVar);

            StringAssert.AreEqualIgnoringCase(string.Empty, tmpInfo.InstanceName);

            Assert.AreEqual(QuantificationInfo.Universal, tmpInfo.InstanceQuantification);
        }

        [Test]
        public void CreateNodeNameInfo_Case_54()
        {
            var tmpStr = "!dog";

            StringAssert.AreNotEqualIgnoringCase(string.Empty, tmpStr);
            StringAssert.AreNotEqualIgnoringCase(null, tmpStr);

            var tmpEx = Assert.Catch<ArgumentException>(() => { _QueryStringHelper.CreateNodeNameInfo(tmpStr); });
        }

        [Test]
        public void CreateNodeNameInfo_Case_55()
        {
            var tmpStr = "! dog";

            StringAssert.AreNotEqualIgnoringCase(string.Empty, tmpStr);
            StringAssert.AreNotEqualIgnoringCase(null, tmpStr);

            var tmpEx = Assert.Catch<ArgumentException>(() => { _QueryStringHelper.CreateNodeNameInfo(tmpStr); });
        }

        [Test]
        public void CreateNodeNameInfo_Case_56()
        {
            var tmpStr = "#dog";

            StringAssert.AreNotEqualIgnoringCase(string.Empty, tmpStr);
            StringAssert.AreNotEqualIgnoringCase(null, tmpStr);

            var tmpInfo = _QueryStringHelper.CreateNodeNameInfo(tmpStr);

            Assert.AreEqual(false, tmpInfo.HasQuestion);

            Assert.AreEqual(false, tmpInfo.HasVar);

            Assert.AreEqual(false, tmpInfo.HasClass);

            StringAssert.AreEqualIgnoringCase(string.Empty, tmpInfo.ClassName);

            Assert.AreEqual(false, tmpInfo.HasClassQuestion);

            Assert.AreEqual(false, tmpInfo.HasClassVar);

            Assert.AreEqual(QuantificationInfo.Universal, tmpInfo.ClassQuantification);

            Assert.AreEqual(true, tmpInfo.HasInstance);

            Assert.AreEqual(false, tmpInfo.HasInstanceQuestion);

            Assert.AreEqual(false, tmpInfo.HasInstanceVar);

            StringAssert.AreEqualIgnoringCase("dog", tmpInfo.InstanceName);

            Assert.AreEqual(QuantificationInfo.None, tmpInfo.InstanceQuantification);
        }

        [Test]
        public void CreateNodeNameInfo_Case_57()
        {
            var tmpStr = "# dog";

            StringAssert.AreNotEqualIgnoringCase(string.Empty, tmpStr);
            StringAssert.AreNotEqualIgnoringCase(null, tmpStr);

            var tmpInfo = _QueryStringHelper.CreateNodeNameInfo(tmpStr);

            Assert.AreEqual(false, tmpInfo.HasQuestion);

            Assert.AreEqual(false, tmpInfo.HasVar);

            Assert.AreEqual(false, tmpInfo.HasClass);

            StringAssert.AreEqualIgnoringCase(string.Empty, tmpInfo.ClassName);

            Assert.AreEqual(false, tmpInfo.HasClassQuestion);

            Assert.AreEqual(false, tmpInfo.HasClassVar);

            Assert.AreEqual(QuantificationInfo.Universal, tmpInfo.ClassQuantification);

            Assert.AreEqual(true, tmpInfo.HasInstance);

            Assert.AreEqual(false, tmpInfo.HasInstanceQuestion);

            Assert.AreEqual(false, tmpInfo.HasInstanceVar);

            StringAssert.AreEqualIgnoringCase("dog", tmpInfo.InstanceName);

            Assert.AreEqual(QuantificationInfo.None, tmpInfo.InstanceQuantification);
        }

        [Test]
        public void CreateNodeNameInfo_Case_58()
        {
            var tmpStr = "dog∀";

            StringAssert.AreNotEqualIgnoringCase(string.Empty, tmpStr);
            StringAssert.AreNotEqualIgnoringCase(null, tmpStr);

            var tmpEx = Assert.Catch<ArgumentException>(() => { _QueryStringHelper.CreateNodeNameInfo(tmpStr); });
        }

        [Test]
        public void CreateNodeNameInfo_Case_59()
        {
            var tmpStr = "dog∃";

            StringAssert.AreNotEqualIgnoringCase(string.Empty, tmpStr);
            StringAssert.AreNotEqualIgnoringCase(null, tmpStr);

            var tmpEx = Assert.Catch<ArgumentException>(() => { _QueryStringHelper.CreateNodeNameInfo(tmpStr); });
        }

        [Test]
        public void CreateNodeNameInfo_Case_60()
        {
            var tmpStr = "dog!";

            StringAssert.AreNotEqualIgnoringCase(string.Empty, tmpStr);
            StringAssert.AreNotEqualIgnoringCase(null, tmpStr);

            var tmpEx = Assert.Catch<ArgumentException>(() => { _QueryStringHelper.CreateNodeNameInfo(tmpStr); });
        }

        [Test]
        public void CreateNodeNameInfo_Case_61()
        {
            var tmpStr = "dog*";

            StringAssert.AreNotEqualIgnoringCase(string.Empty, tmpStr);
            StringAssert.AreNotEqualIgnoringCase(null, tmpStr);

            var tmpEx = Assert.Catch<ArgumentException>(() => { _QueryStringHelper.CreateNodeNameInfo(tmpStr); });
        }

        [Test]
        public void CreateNodeNameInfo_Case_62()
        {
            var tmpStr = "∃^∃";

            StringAssert.AreNotEqualIgnoringCase(string.Empty, tmpStr);
            StringAssert.AreNotEqualIgnoringCase(null, tmpStr);

            var tmpEx = Assert.Catch<ArgumentException>(() => { _QueryStringHelper.CreateNodeNameInfo(tmpStr); });
        }

        [Test]
        public void CreateNodeNameInfo_Case_63()
        {
            var tmpStr = "`!`";

            StringAssert.AreNotEqualIgnoringCase(string.Empty, tmpStr);
            StringAssert.AreNotEqualIgnoringCase(null, tmpStr);

            var tmpInfo = _QueryStringHelper.CreateNodeNameInfo(tmpStr);

            Assert.AreEqual(false, tmpInfo.HasQuestion);

            Assert.AreEqual(false, tmpInfo.HasVar);

            Assert.AreEqual(true, tmpInfo.HasClass);

            StringAssert.AreEqualIgnoringCase("!", tmpInfo.ClassName);

            Assert.AreEqual(false, tmpInfo.HasClassQuestion);

            Assert.AreEqual(false, tmpInfo.HasClassVar);

            Assert.AreEqual(QuantificationInfo.None, tmpInfo.ClassQuantification);

            Assert.AreEqual(false, tmpInfo.HasInstance);

            Assert.AreEqual(false, tmpInfo.HasInstanceQuestion);

            Assert.AreEqual(false, tmpInfo.HasInstanceVar);

            StringAssert.AreEqualIgnoringCase(string.Empty, tmpInfo.InstanceName);

            Assert.AreEqual(QuantificationInfo.Universal, tmpInfo.InstanceQuantification);
        }

        [Test]
        public void CreateNodeNameInfo_Case_64()
        {
            var tmpStr = "`dog#123#`";

            StringAssert.AreNotEqualIgnoringCase(string.Empty, tmpStr);
            StringAssert.AreNotEqualIgnoringCase(null, tmpStr);

            var tmpInfo = _QueryStringHelper.CreateNodeNameInfo(tmpStr);

            Assert.AreEqual(false, tmpInfo.HasQuestion);

            Assert.AreEqual(false, tmpInfo.HasVar);

            Assert.AreEqual(true, tmpInfo.HasClass);

            StringAssert.AreEqualIgnoringCase("dog#123#", tmpInfo.ClassName);

            Assert.AreEqual(false, tmpInfo.HasClassQuestion);

            Assert.AreEqual(false, tmpInfo.HasClassVar);

            Assert.AreEqual(QuantificationInfo.None, tmpInfo.ClassQuantification);

            Assert.AreEqual(false, tmpInfo.HasInstance);

            Assert.AreEqual(false, tmpInfo.HasInstanceQuestion);

            Assert.AreEqual(false, tmpInfo.HasInstanceVar);

            StringAssert.AreEqualIgnoringCase(string.Empty, tmpInfo.InstanceName);

            Assert.AreEqual(QuantificationInfo.Universal, tmpInfo.InstanceQuantification);
        }

        [Test]
        public void CreateNodeNameInfo_Case_65()
        {
            var tmpStr = "`∀`";

            StringAssert.AreNotEqualIgnoringCase(string.Empty, tmpStr);
            StringAssert.AreNotEqualIgnoringCase(null, tmpStr);

            var tmpInfo = _QueryStringHelper.CreateNodeNameInfo(tmpStr);

            Assert.AreEqual(false, tmpInfo.HasQuestion);

            Assert.AreEqual(false, tmpInfo.HasVar);

            Assert.AreEqual(true, tmpInfo.HasClass);

            StringAssert.AreEqualIgnoringCase("∀", tmpInfo.ClassName);

            Assert.AreEqual(false, tmpInfo.HasClassQuestion);

            Assert.AreEqual(false, tmpInfo.HasClassVar);

            Assert.AreEqual(QuantificationInfo.None, tmpInfo.ClassQuantification);

            Assert.AreEqual(false, tmpInfo.HasInstance);

            Assert.AreEqual(false, tmpInfo.HasInstanceQuestion);

            Assert.AreEqual(false, tmpInfo.HasInstanceVar);

            StringAssert.AreEqualIgnoringCase(string.Empty, tmpInfo.InstanceName);

            Assert.AreEqual(QuantificationInfo.Universal, tmpInfo.InstanceQuantification);
        }

        [Test]
        public void CreateNodeNameInfo_Case_66()
        {
            var tmpStr = "`∃`";

            StringAssert.AreNotEqualIgnoringCase(string.Empty, tmpStr);
            StringAssert.AreNotEqualIgnoringCase(null, tmpStr);

            var tmpInfo = _QueryStringHelper.CreateNodeNameInfo(tmpStr);

            Assert.AreEqual(false, tmpInfo.HasQuestion);

            Assert.AreEqual(false, tmpInfo.HasVar);

            Assert.AreEqual(true, tmpInfo.HasClass);

            StringAssert.AreEqualIgnoringCase("∃", tmpInfo.ClassName);

            Assert.AreEqual(false, tmpInfo.HasClassQuestion);

            Assert.AreEqual(false, tmpInfo.HasClassVar);

            Assert.AreEqual(QuantificationInfo.None, tmpInfo.ClassQuantification);

            Assert.AreEqual(false, tmpInfo.HasInstance);

            Assert.AreEqual(false, tmpInfo.HasInstanceQuestion);

            Assert.AreEqual(false, tmpInfo.HasInstanceVar);

            StringAssert.AreEqualIgnoringCase(string.Empty, tmpInfo.InstanceName);

            Assert.AreEqual(QuantificationInfo.Universal, tmpInfo.InstanceQuantification);
        }

        [Test]
        public void CreateNodeNameInfo_Case_67()
        {
            var tmpStr = "`dog#`";

            StringAssert.AreNotEqualIgnoringCase(string.Empty, tmpStr);
            StringAssert.AreNotEqualIgnoringCase(null, tmpStr);

            var tmpInfo = _QueryStringHelper.CreateNodeNameInfo(tmpStr);

            Assert.AreEqual(false, tmpInfo.HasQuestion);

            Assert.AreEqual(false, tmpInfo.HasVar);

            Assert.AreEqual(true, tmpInfo.HasClass);

            StringAssert.AreEqualIgnoringCase("dog#", tmpInfo.ClassName);

            Assert.AreEqual(false, tmpInfo.HasClassQuestion);

            Assert.AreEqual(false, tmpInfo.HasClassVar);

            Assert.AreEqual(QuantificationInfo.None, tmpInfo.ClassQuantification);

            Assert.AreEqual(false, tmpInfo.HasInstance);

            Assert.AreEqual(false, tmpInfo.HasInstanceQuestion);

            Assert.AreEqual(false, tmpInfo.HasInstanceVar);

            StringAssert.AreEqualIgnoringCase(string.Empty, tmpInfo.InstanceName);

            Assert.AreEqual(QuantificationInfo.Universal, tmpInfo.InstanceQuantification);
        }

        [Test]
        public void CreateNodeNameInfo_Case_68()
        {
            var tmpStr = "`#`";

            StringAssert.AreNotEqualIgnoringCase(string.Empty, tmpStr);
            StringAssert.AreNotEqualIgnoringCase(null, tmpStr);

            var tmpInfo = _QueryStringHelper.CreateNodeNameInfo(tmpStr);

            Assert.AreEqual(false, tmpInfo.HasQuestion);

            Assert.AreEqual(false, tmpInfo.HasVar);

            Assert.AreEqual(true, tmpInfo.HasClass);

            StringAssert.AreEqualIgnoringCase("#", tmpInfo.ClassName);

            Assert.AreEqual(false, tmpInfo.HasClassQuestion);

            Assert.AreEqual(false, tmpInfo.HasClassVar);

            Assert.AreEqual(QuantificationInfo.None, tmpInfo.ClassQuantification);

            Assert.AreEqual(false, tmpInfo.HasInstance);

            Assert.AreEqual(false, tmpInfo.HasInstanceQuestion);

            Assert.AreEqual(false, tmpInfo.HasInstanceVar);

            StringAssert.AreEqualIgnoringCase(string.Empty, tmpInfo.InstanceName);

            Assert.AreEqual(QuantificationInfo.Universal, tmpInfo.InstanceQuantification);
        }

        [Test]
        public void CreateNodeNameInfo_Case_69()
        {
            var tmpStr = "`+`";

            StringAssert.AreNotEqualIgnoringCase(string.Empty, tmpStr);
            StringAssert.AreNotEqualIgnoringCase(null, tmpStr);

            var tmpInfo = _QueryStringHelper.CreateNodeNameInfo(tmpStr);

            Assert.AreEqual(false, tmpInfo.HasQuestion);

            Assert.AreEqual(false, tmpInfo.HasVar);

            Assert.AreEqual(true, tmpInfo.HasClass);

            StringAssert.AreEqualIgnoringCase("+", tmpInfo.ClassName);

            Assert.AreEqual(false, tmpInfo.HasClassQuestion);

            Assert.AreEqual(false, tmpInfo.HasClassVar);

            Assert.AreEqual(QuantificationInfo.None, tmpInfo.ClassQuantification);

            Assert.AreEqual(false, tmpInfo.HasInstance);

            Assert.AreEqual(false, tmpInfo.HasInstanceQuestion);

            Assert.AreEqual(false, tmpInfo.HasInstanceVar);

            StringAssert.AreEqualIgnoringCase(string.Empty, tmpInfo.InstanceName);

            Assert.AreEqual(QuantificationInfo.Universal, tmpInfo.InstanceQuantification);
        }

        [Test]
        public void CreateNodeNameInfo_Case_70()
        {
            var tmpStr = "`=`";

            StringAssert.AreNotEqualIgnoringCase(string.Empty, tmpStr);
            StringAssert.AreNotEqualIgnoringCase(null, tmpStr);

            var tmpInfo = _QueryStringHelper.CreateNodeNameInfo(tmpStr);

            Assert.AreEqual(false, tmpInfo.HasQuestion);

            Assert.AreEqual(false, tmpInfo.HasVar);

            Assert.AreEqual(true, tmpInfo.HasClass);

            StringAssert.AreEqualIgnoringCase("=", tmpInfo.ClassName);

            Assert.AreEqual(false, tmpInfo.HasClassQuestion);

            Assert.AreEqual(false, tmpInfo.HasClassVar);

            Assert.AreEqual(QuantificationInfo.None, tmpInfo.ClassQuantification);

            Assert.AreEqual(false, tmpInfo.HasInstance);

            Assert.AreEqual(false, tmpInfo.HasInstanceQuestion);

            Assert.AreEqual(false, tmpInfo.HasInstanceVar);

            StringAssert.AreEqualIgnoringCase(string.Empty, tmpInfo.InstanceName);

            Assert.AreEqual(QuantificationInfo.Universal, tmpInfo.InstanceQuantification);
        }

        [Test]
        public void CreateNodeNameInfo_Case_71()
        {
            var tmpStr = "∀∃";

            StringAssert.AreNotEqualIgnoringCase(string.Empty, tmpStr);
            StringAssert.AreNotEqualIgnoringCase(null, tmpStr);

            var tmpEx = Assert.Catch<ArgumentException>(() => { _QueryStringHelper.CreateNodeNameInfo(tmpStr); });
        }

        [Test]
        public void CreateNodeNameInfo_Case_72()
        {
            var tmpStr = "dog:∀∃";

            StringAssert.AreNotEqualIgnoringCase(string.Empty, tmpStr);
            StringAssert.AreNotEqualIgnoringCase(null, tmpStr);

            var tmpEx = Assert.Catch<ArgumentException>(() => { _QueryStringHelper.CreateNodeNameInfo(tmpStr); });
        }

        [Test]
        public void CreateNodeNameInfo_Case_73()
        {
            var tmpStr = "dog:∃∀";

            StringAssert.AreNotEqualIgnoringCase(string.Empty, tmpStr);
            StringAssert.AreNotEqualIgnoringCase(null, tmpStr);

            var tmpEx = Assert.Catch<ArgumentException>(() => { _QueryStringHelper.CreateNodeNameInfo(tmpStr); });
        }
    }
}
