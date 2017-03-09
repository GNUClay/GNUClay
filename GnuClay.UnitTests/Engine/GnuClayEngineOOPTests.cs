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
    public class GnuClayEngineOOPTests
    {
        [Test]
        public void Case_1()
        {
            var tmpEngine = new GnuClayEngine();

            var queryString = "INSERT {>: {is(Dog, Animal)}}";

            var insert_result = tmpEngine.Query(queryString);

            Assert.AreNotEqual(insert_result, null);
            Assert.AreEqual(insert_result.ErrorText, string.Empty);
            Assert.AreEqual(insert_result.Success, true);
            Assert.AreEqual(insert_result.HaveBeenFound, false);
            Assert.AreNotEqual(insert_result.Items, null);
            Assert.AreEqual(insert_result.Items.Count, 0);

            var tmpAnimalKey = tmpEngine.DataDictionary.GetKey("Animal");
            var tmpDogKey = tmpEngine.DataDictionary.GetKey("Dog");

            var tmpRank = tmpEngine.Context.InheritanceEngine.GetRank(tmpDogKey, tmpAnimalKey);

            Assert.AreEqual(tmpRank, 1);

            var tmpListOfInheritance = tmpEngine.Context.InheritanceEngine.LoadListOfSuperClasses(tmpDogKey);

            Assert.AreEqual(tmpListOfInheritance.Any(p => p.SuperKey == tmpAnimalKey), true);

            var tmpListOfSubClasses = tmpEngine.Context.InheritanceEngine.LoadListOfSubClasses(tmpAnimalKey);

            Assert.AreEqual(tmpListOfSubClasses.Any(p => p.SubKey == tmpDogKey), true);

            queryString = "INSERT {>: {!is(Dog, Animal)}}";

            insert_result = tmpEngine.Query(queryString);

            Assert.AreNotEqual(insert_result, null);
            Assert.AreEqual(insert_result.ErrorText, string.Empty);
            Assert.AreEqual(insert_result.Success, true);
            Assert.AreEqual(insert_result.HaveBeenFound, false);
            Assert.AreNotEqual(insert_result.Items, null);
            Assert.AreEqual(insert_result.Items.Count, 0);

            tmpRank = tmpEngine.Context.InheritanceEngine.GetRank(tmpDogKey, tmpAnimalKey);

            Assert.AreEqual(tmpRank, 0);

            Assert.AreEqual(tmpListOfInheritance.Any(p => p.SuperKey == tmpAnimalKey), true);

            Assert.AreEqual(tmpListOfSubClasses.Any(p => p.SubKey == tmpDogKey), true);
        }
    }
}
