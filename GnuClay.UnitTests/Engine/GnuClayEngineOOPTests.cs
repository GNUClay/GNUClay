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
        public void OOP_Case_1()
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

        [Test]
        public void OOP_Case_2()
        {
            var tmpEngine = new GnuClayEngine();

            var queryString = "INSERT {>: {`count of feet`(biped, 2)}}";

            var qr_1 = tmpEngine.Query(queryString);

            Assert.AreNotEqual(qr_1, null);
            Assert.AreEqual(qr_1.Success, true);
            Assert.AreEqual(qr_1.HaveBeenFound, false);

            queryString = "INSERT {>: {biped(Robot)}}";
            var qr_1_1 = tmpEngine.Query(queryString);

            Assert.AreNotEqual(qr_1_1, null);
            Assert.AreEqual(qr_1_1.Success, true);
            Assert.AreEqual(qr_1_1.HaveBeenFound, false);

            queryString = "INSERT {>: {is(human, biped)}}";
            var qr_2 = tmpEngine.Query(queryString);

            Assert.AreNotEqual(qr_2, null);
            Assert.AreEqual(qr_2.Success, true);
            Assert.AreEqual(qr_2.HaveBeenFound, false);

            queryString = "INSERT {>: {is(#957B6203_D200_47E0_B51E_0E8DEF869B3D,human)}}";
            var qr_3 = tmpEngine.Query(queryString);

            Assert.AreNotEqual(qr_3, null);
            Assert.AreEqual(qr_3.Success, true);
            Assert.AreEqual(qr_3.HaveBeenFound, false);

            throw new NotImplementedException();
        }
    }
}
