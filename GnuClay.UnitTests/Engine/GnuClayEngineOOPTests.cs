using GnuClay.CommonClientTypes;
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

            var numberKey = tmpEngine.DataDictionary.GetKey("number");
            var xVarKey = tmpEngine.DataDictionary.GetKey("$X");

            queryString = "SELECT { >:{`count of feet`(#957B6203_D200_47E0_B51E_0E8DEF869B3D,$X)}}";
            var qr_4 = tmpEngine.Query(queryString);

            Assert.AreNotEqual(qr_4, null);
            Assert.AreEqual(qr_4.Success, true);
            Assert.AreEqual(qr_4.HaveBeenFound, true);

            Assert.AreEqual(qr_4.Items.Count, 1);

            var targetItem = qr_4.Items.Single();

            Assert.AreEqual(targetItem.Params.Count, 1);

            var targetVarItem = targetItem.Params.Single();

            Assert.AreEqual(targetVarItem.Kind, ExpressionNodeKind.Value);
            Assert.AreEqual(targetVarItem.Value, 2);
            Assert.AreEqual(targetVarItem.EntityKey, numberKey);
            Assert.AreEqual(targetVarItem.ParamKey, xVarKey);

            queryString = "SELECT {>: {is(#957B6203_D200_47E0_B51E_0E8DEF869B3D,biped)}}";
            var tmpSelectResult = tmpEngine.Query(queryString);

            Assert.AreNotEqual(tmpSelectResult, null);
            Assert.AreEqual(tmpSelectResult.Success, true);
            Assert.AreEqual(tmpSelectResult.HaveBeenFound, true);

            Assert.AreEqual(tmpSelectResult.Items.Count, 0);

            var tKey = tmpEngine.DataDictionary.GetKey("⊤");
            var humanKey = tmpEngine.DataDictionary.GetKey("human");
            var bipedKey = tmpEngine.DataDictionary.GetKey("biped");

            queryString = "SELECT {>: {is(#957B6203_D200_47E0_B51E_0E8DEF869B3D,$X)}}";
            tmpSelectResult = tmpEngine.Query(queryString);

            Assert.AreNotEqual(tmpSelectResult, null);
            Assert.AreEqual(tmpSelectResult.Success, true);
            Assert.AreEqual(tmpSelectResult.HaveBeenFound, true);

            Assert.AreEqual(tmpSelectResult.Items.Count, 3);

            targetItem = tmpSelectResult.Items[0];
            Assert.AreEqual(targetItem.Params.Count, 1);
            targetVarItem = targetItem.Params.Single();

            Assert.AreEqual(targetVarItem.Kind, ExpressionNodeKind.Entity);
            Assert.AreEqual(targetVarItem.Value, null);
            Assert.AreEqual(targetVarItem.EntityKey, humanKey);
            Assert.AreEqual(targetVarItem.ParamKey, xVarKey);

            targetItem = tmpSelectResult.Items[1];
            Assert.AreEqual(targetItem.Params.Count, 1);
            targetVarItem = targetItem.Params.Single();

            Assert.AreEqual(targetVarItem.Kind, ExpressionNodeKind.Entity);
            Assert.AreEqual(targetVarItem.Value, null);
            Assert.AreEqual(targetVarItem.EntityKey, tKey);
            Assert.AreEqual(targetVarItem.ParamKey, xVarKey);

            targetItem = tmpSelectResult.Items[2];
            Assert.AreEqual(targetItem.Params.Count, 1);
            targetVarItem = targetItem.Params.Single();

            Assert.AreEqual(targetVarItem.Kind, ExpressionNodeKind.Entity);
            Assert.AreEqual(targetVarItem.Value, null);
            Assert.AreEqual(targetVarItem.EntityKey, bipedKey);
            Assert.AreEqual(targetVarItem.ParamKey, xVarKey);

            var robotKey = tmpEngine.DataDictionary.GetKey("robot");
            var instanceKey = tmpEngine.DataDictionary.GetKey("#957b6203_d200_47e0_b51e_0e8def869b3d");

            queryString = "SELECT {>: {is($X ,biped)}}";
            tmpSelectResult = tmpEngine.Query(queryString);

            Assert.AreNotEqual(tmpSelectResult, null);
            Assert.AreEqual(tmpSelectResult.Success, true);
            Assert.AreEqual(tmpSelectResult.HaveBeenFound, true);

            Assert.AreEqual(tmpSelectResult.Items.Count, 3);

            targetItem = tmpSelectResult.Items[0];
            Assert.AreEqual(targetItem.Params.Count, 1);
            targetVarItem = targetItem.Params.Single();

            Assert.AreEqual(targetVarItem.Kind, ExpressionNodeKind.Entity);
            Assert.AreEqual(targetVarItem.Value, null);
            Assert.AreEqual(targetVarItem.EntityKey, robotKey);
            Assert.AreEqual(targetVarItem.ParamKey, xVarKey);

            targetItem = tmpSelectResult.Items[1];
            Assert.AreEqual(targetItem.Params.Count, 1);
            targetVarItem = targetItem.Params.Single();

            Assert.AreEqual(targetVarItem.Kind, ExpressionNodeKind.Entity);
            Assert.AreEqual(targetVarItem.Value, null);
            Assert.AreEqual(targetVarItem.EntityKey, humanKey);
            Assert.AreEqual(targetVarItem.ParamKey, xVarKey);

            targetItem = tmpSelectResult.Items[2];
            Assert.AreEqual(targetItem.Params.Count, 1);
            targetVarItem = targetItem.Params.Single();

            Assert.AreEqual(targetVarItem.Kind, ExpressionNodeKind.Entity);
            Assert.AreEqual(targetVarItem.Value, null);
            Assert.AreEqual(targetVarItem.EntityKey, instanceKey);
            Assert.AreEqual(targetVarItem.ParamKey, xVarKey);


            queryString = "SELECT {>: {biped($X)}}";
            tmpSelectResult = tmpEngine.Query(queryString);

            Assert.AreNotEqual(tmpSelectResult, null);
            Assert.AreEqual(tmpSelectResult.Success, true);
            Assert.AreEqual(tmpSelectResult.HaveBeenFound, true);

            Assert.AreEqual(tmpSelectResult.Items.Count, 3);

            targetItem = tmpSelectResult.Items[0];
            Assert.AreEqual(targetItem.Params.Count, 1);
            targetVarItem = targetItem.Params.Single();

            Assert.AreEqual(targetVarItem.Kind, ExpressionNodeKind.Entity);
            Assert.AreEqual(targetVarItem.Value, null);
            Assert.AreEqual(targetVarItem.EntityKey, robotKey);
            Assert.AreEqual(targetVarItem.ParamKey, xVarKey);

            targetItem = tmpSelectResult.Items[1];
            Assert.AreEqual(targetItem.Params.Count, 1);
            targetVarItem = targetItem.Params.Single();

            Assert.AreEqual(targetVarItem.Kind, ExpressionNodeKind.Entity);
            Assert.AreEqual(targetVarItem.Value, null);
            Assert.AreEqual(targetVarItem.EntityKey, humanKey);
            Assert.AreEqual(targetVarItem.ParamKey, xVarKey);

            targetItem = tmpSelectResult.Items[2];
            Assert.AreEqual(targetItem.Params.Count, 1);
            targetVarItem = targetItem.Params.Single();

            Assert.AreEqual(targetVarItem.Kind, ExpressionNodeKind.Entity);
            Assert.AreEqual(targetVarItem.Value, null);
            Assert.AreEqual(targetVarItem.EntityKey, instanceKey);
            Assert.AreEqual(targetVarItem.ParamKey, xVarKey);


            queryString = "SELECT {>: {is($X ,$Y)}}";
            tmpSelectResult = tmpEngine.Query(queryString);

            Assert.AreNotEqual(tmpSelectResult, null);
            Assert.AreEqual(tmpSelectResult.Success, true);
            Assert.AreEqual(tmpSelectResult.HaveBeenFound, true);

            Assert.AreEqual(tmpSelectResult.Items.Count, 11);

            NLog.LogManager.GetCurrentClassLogger().Info($"queryString (2) = `{queryString}`");
            NLog.LogManager.GetCurrentClassLogger().Info($"tmpSelectResult = {tmpSelectResult.ToJson()}");
            NLog.LogManager.GetCurrentClassLogger().Info($"tmpSelectResult = {SelectResultDebugHelper.ConvertToString(tmpSelectResult, tmpEngine.DataDictionary)}");
            NLog.LogManager.GetCurrentClassLogger().Info($"{nameof(tmpSelectResult)} = {tmpSelectResult}");

            queryString = "SELECT {>: {is($X ,$X)}}";
            tmpSelectResult = tmpEngine.Query(queryString);
            NLog.LogManager.GetCurrentClassLogger().Info($"queryString (2) = `{queryString}`");
            NLog.LogManager.GetCurrentClassLogger().Info($"tmpSelectResult = {tmpSelectResult.ToJson()}");
            NLog.LogManager.GetCurrentClassLogger().Info($"tmpSelectResult = {SelectResultDebugHelper.ConvertToString(tmpSelectResult, tmpEngine.DataDictionary)}");
            NLog.LogManager.GetCurrentClassLogger().Info($"{nameof(tmpSelectResult)} = {tmpSelectResult}");

            throw new NotImplementedException();
        }
    }
}
