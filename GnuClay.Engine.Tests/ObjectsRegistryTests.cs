using GnuClay.Engine.StorageOfKnowledges.Implementations;
using GnuClay.Engine.Tests.Stubs;
using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GnuClay.Engine.Tests
{
    [TestFixture]
    public class ObjectsRegistryTests
    {
        [Test]
        public void AddWord_Empty_ThrowArgumentNullException()
        {
            var tmpContext = new GnuClayEngineContextStub();

            var tmpRegistry = new ObjectsRegistry(tmpContext);

            var tmpEx = Assert.Catch<ArgumentNullException>(() => { tmpRegistry.AddWord(null); });
        }

        [Test]
        public void AddWord_SomeWords_Return_1()
        {
            var tmpContext = new GnuClayEngineContextStub();

            var tmpRegistry = new ObjectsRegistry(tmpContext);

            var tmpSomeWord = "dog";

            Assert.AreEqual(1, tmpRegistry.AddWord(tmpSomeWord));
        }

        [Test]
        public void AddWord_SomeWordsTwise_Return_1()
        {
            var tmpContext = new GnuClayEngineContextStub();

            var tmpRegistry = new ObjectsRegistry(tmpContext);

            var tmpSomeWord = "dog";

            tmpRegistry.AddWord(tmpSomeWord);

            Assert.AreEqual(1, tmpRegistry.AddWord(tmpSomeWord));
        }

        [Test]
        public void AddWord_SomeWords_ContainsItsKey()
        {
            var tmpContext = new GnuClayEngineContextStub();

            var tmpRegistry = new ObjectsRegistry(tmpContext);

            var tmpSomeWord = "dog";

            var tmpKey = tmpRegistry.AddWord(tmpSomeWord);

            Assert.AreEqual(true, tmpRegistry.ContainsKey(tmpKey));
        }

        [Test]
        public void ContainsKey_KeyEquv_0_ReturnFalse()
        {
            var tmpContext = new GnuClayEngineContextStub();

            var tmpRegistry = new ObjectsRegistry(tmpContext);

            Assert.AreEqual(false, tmpRegistry.ContainsKey(0));
        }

        [Test]
        public void ContainsKey_NotExistsKey_ReturnFalse()
        {
            var tmpContext = new GnuClayEngineContextStub();

            var tmpRegistry = new ObjectsRegistry(tmpContext);

            Assert.AreEqual(false, tmpRegistry.ContainsKey(0));
        }

        [Test]
        public void ContainsKey_ExistsKey_ReturnTrue()
        {
            var tmpContext = new GnuClayEngineContextStub();

            var tmpRegistry = new ObjectsRegistry(tmpContext);

            var tmpSomeWord = "dog";

            var tmpKey = tmpRegistry.AddWord(tmpSomeWord);

            Assert.AreEqual(true, tmpRegistry.ContainsKey(tmpKey));
        }

        [Test]
        public void ContainsWord_Null_ThrowArgumentNullException()
        {
            var tmpContext = new GnuClayEngineContextStub();

            var tmpRegistry = new ObjectsRegistry(tmpContext);

            var tmpEx = Assert.Catch<ArgumentNullException>(() => { tmpRegistry.ContainsWord(null); });
        }

        [Test]
        public void ContainsWord_ExistsWord_ReturnTrue()
        {
            var tmpContext = new GnuClayEngineContextStub();

            var tmpRegistry = new ObjectsRegistry(tmpContext);

            var tmpSomeWord = "dog";

            StringAssert.AreNotEqualIgnoringCase(null, tmpSomeWord);
            StringAssert.AreNotEqualIgnoringCase(string.Empty, tmpSomeWord);

            var tmpKey = tmpRegistry.AddWord(tmpSomeWord);

            Assert.AreEqual(true, tmpRegistry.ContainsWord(tmpSomeWord));
        }

        [Test]
        public void ContainsWord_NotExistsWord_ReturnFalse()
        {
            var tmpContext = new GnuClayEngineContextStub();

            var tmpRegistry = new ObjectsRegistry(tmpContext);

            var tmpSomeWord = "dog";

            StringAssert.AreNotEqualIgnoringCase(null, tmpSomeWord);
            StringAssert.AreNotEqualIgnoringCase(string.Empty, tmpSomeWord);

            Assert.AreEqual(false, tmpRegistry.ContainsWord(tmpSomeWord));
        }

        [Test]
        public void GetKey_SomeWords_ReturnItsKey()
        {
            var tmpContext = new GnuClayEngineContextStub();

            var tmpRegistry = new ObjectsRegistry(tmpContext);

            var tmpSomeWord = "dog";

            var tmpKey = tmpRegistry.AddWord(tmpSomeWord);

            Assert.AreNotEqual(0, tmpKey);

            Assert.AreEqual(tmpKey, tmpRegistry.GetKey(tmpSomeWord));
        }

        [Test]
        public void GetKey_NullOrEmpty_ThrowArgumentNullException()
        {
            var tmpContext = new GnuClayEngineContextStub();

            var tmpRegistry = new ObjectsRegistry(tmpContext);

            var tmpEx = Assert.Catch<ArgumentNullException>(() => { tmpRegistry.GetKey(null); });
        }

        [Test]
        public void GetKey_NotRegisteredWord_Return_0()
        {
            var tmpContext = new GnuClayEngineContextStub();

            var tmpRegistry = new ObjectsRegistry(tmpContext);

            var tmpSomeWord = "dog";

            Assert.AreEqual(0, tmpRegistry.GetKey(tmpSomeWord));
        }

        [Test]
        public void AddWordToKey_SomeWord_NotExistsKey_ThrowArgumentOutOfRangeException()
        {
            var tmpContext = new GnuClayEngineContextStub();

            var tmpRegistry = new ObjectsRegistry(tmpContext);

            var tmpSomeWord = "dog";

            var tmpEx = Assert.Catch<ArgumentOutOfRangeException>(() => { tmpRegistry.AddWordToKey(tmpSomeWord, 1); });
        }

        [Test]
        public void AddWordToKey_SomeWord_KeyEquv_0_ThrowArgumentOutOfRangeException()
        {
            var tmpContext = new GnuClayEngineContextStub();

            var tmpRegistry = new ObjectsRegistry(tmpContext);

            var tmpSomeWord = "dog";

            var tmpEx = Assert.Catch<ArgumentOutOfRangeException>(() => { tmpRegistry.AddWordToKey(tmpSomeWord, 0); });
        }

        [Test]
        public void AddWordToKey_NullOrEmpty_ExistsKey_ThrowArgumentNullException()
        {
            var tmpContext = new GnuClayEngineContextStub();

            var tmpRegistry = new ObjectsRegistry(tmpContext);

            var tmpSomeWord = "dog";

            var tmpKey = tmpRegistry.AddWord(tmpSomeWord);

            var tmpEx = Assert.Catch<ArgumentNullException>(() => { tmpRegistry.AddWordToKey(null, tmpKey); });
        }

        [Test]
        public void AddWordToKey_NullOrEmpty_NotExistsKey_ThrowArgumentNullException()
        {
            var tmpContext = new GnuClayEngineContextStub();

            var tmpRegistry = new ObjectsRegistry(tmpContext);

            var tmpEx = Assert.Catch<ArgumentNullException>(() => { tmpRegistry.AddWordToKey(null, 1); });
        }

        [Test]
        public void AddWordToKey_SomeWord_ExistsKey_ReturnKeyLikeFirstWord()
        {
            var tmpContext = new GnuClayEngineContextStub();

            var tmpRegistry = new ObjectsRegistry(tmpContext);

            var tmpSomeWord_1 = "dog";

            var tmpSomeWord_2 = "pooch";

            StringAssert.AreNotEqualIgnoringCase(tmpSomeWord_1, tmpSomeWord_2);

            var tmpKey_1 = tmpRegistry.AddWord(tmpSomeWord_1);

            Assert.AreNotEqual(0, tmpKey_1);

            tmpRegistry.AddWordToKey(tmpSomeWord_2, tmpKey_1);

            var tmpKey_2 = tmpRegistry.GetKey(tmpSomeWord_2);

            Assert.AreEqual(tmpKey_1, tmpKey_2);
        }

        [Test]
        public void AddWordToKey_SomeExistsWord_SomeExistsKey_ThrowArgumentOutOfRangeException()
        {
            var tmpContext = new GnuClayEngineContextStub();

            var tmpRegistry = new ObjectsRegistry(tmpContext);

            var tmpSomeWord_1 = "dog";

            var tmpSomeWord_2 = "apple";

            StringAssert.AreNotEqualIgnoringCase(tmpSomeWord_1, tmpSomeWord_2);

            var tmpKey_1 = tmpRegistry.AddWord(tmpSomeWord_1);

            var tmpKey_2 = tmpRegistry.AddWord(tmpSomeWord_2);

            Assert.AreNotEqual(tmpKey_1, tmpKey_2);

            var tmpEx = Assert.Catch<ArgumentOutOfRangeException>(() => { tmpRegistry.AddWordToKey(tmpSomeWord_2, tmpKey_1); });
        }
    }
}
