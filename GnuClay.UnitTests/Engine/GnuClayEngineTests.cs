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
    public class GnuClayEngineTests
    {
        [Test]
        public void Queries_Case_1()
        {
            var tmpEngine = new GnuClayEngine();

            var queryString = "READ{ >:{son(Piter,$X1)}}";

            var qr_1 = tmpEngine.Query(queryString);

            Assert.AreNotEqual(qr_1, null);
            Assert.AreEqual(qr_1.ErrorText, string.Empty);
            Assert.AreEqual(qr_1.Success, true);
            Assert.AreEqual(qr_1.HaveBeenFound, false);
            Assert.AreNotEqual(qr_1.Items, null);
            Assert.AreEqual(qr_1.Items.Count, 0);

            queryString = "READ{>:{son(Piter,Tom)}}";

            var qr_2 = tmpEngine.Query(queryString);

            Assert.AreNotEqual(qr_2, null);
            Assert.AreEqual(qr_2.ErrorText, string.Empty);
            Assert.AreEqual(qr_2.Success, true);
            Assert.AreEqual(qr_2.HaveBeenFound, false);
            Assert.AreNotEqual(qr_2.Items, null);
            Assert.AreEqual(qr_2.Items.Count, 0);

            queryString = "WRITE{>: {parent($X1,$X2)} -> {child($X2,$X1)}},{>: {son($X1,$X2)} -> {child($X1,$X2) & male($X1)}},{>: {parent(Tom,Piter)}},{>: {parent(Tom,Mary)}},{>: {male(Piter)}},{>: {female(Mary)}},{>: {male(Bob)}}";

            var insert_result = tmpEngine.Query(queryString);

            Assert.AreNotEqual(insert_result, null);
            Assert.AreEqual(insert_result.ErrorText, string.Empty);
            Assert.AreEqual(insert_result.Success, true);
            Assert.AreEqual(insert_result.HaveBeenFound, false);
            Assert.AreNotEqual(insert_result.Items, null);
            Assert.AreEqual(insert_result.Items.Count, 0);

            queryString = "READ{ >: {son(Piter,$X1)}}";

            var qr_3 = tmpEngine.Query(queryString);

            Assert.AreNotEqual(qr_3, null);
            Assert.AreEqual(qr_3.ErrorText, string.Empty);
            Assert.AreEqual(qr_3.Success, true);
            Assert.AreEqual(qr_3.HaveBeenFound, true);
            Assert.AreNotEqual(qr_3.Items, null);
            Assert.AreEqual(qr_3.Items.Count, 1);

            var targetItem = qr_3.Items.Single();

            Assert.AreNotEqual(targetItem.Params, null);
            Assert.AreEqual(targetItem.Params.Count, 1);

            var paramKey = tmpEngine.DataDictionary.GetKey("$X1");
            var entityKey = tmpEngine.DataDictionary.GetKey("Tom");
            var targetParam = targetItem.Params.Single();

            Assert.AreEqual(targetParam.ParamKey, paramKey);
            Assert.AreEqual(targetParam.EntityKey, entityKey);
            Assert.AreEqual(targetParam.Kind, ExpressionNodeKind.Entity);
            Assert.AreEqual(targetParam.Value, null);

            queryString = "READ{ >: {son(Piter,Tom)}}";

            var qr_4 = tmpEngine.Query(queryString);

            Assert.AreNotEqual(qr_4, null);
            Assert.AreEqual(qr_4.ErrorText, string.Empty);
            Assert.AreEqual(qr_4.Success, true);
            Assert.AreEqual(qr_4.HaveBeenFound, true);
            Assert.AreNotEqual(qr_4.Items, null);
            Assert.AreEqual(qr_4.Items.Count, 1);

            var targetItem_2 = qr_4.Items.Single();

            Assert.AreNotEqual(targetItem_2.Params, null);
            Assert.AreEqual(targetItem_2.Params.Count, 0);

            tmpEngine.Clear();

            queryString = "READ{ >:{son(Piter,$X1)}}";

            var qr_5 = tmpEngine.Query(queryString);

            Assert.AreNotEqual(qr_5, null);
            Assert.AreEqual(qr_5.ErrorText, string.Empty);
            Assert.AreEqual(qr_5.Success, true);
            Assert.AreEqual(qr_5.HaveBeenFound, false);
            Assert.AreNotEqual(qr_5.Items, null);
            Assert.AreEqual(qr_5.Items.Count, 0);

            queryString = "READ{ >:{son(Piter,Tom)}}";

            var qr_6 = tmpEngine.Query(queryString);

            Assert.AreNotEqual(qr_6, null);
            Assert.AreEqual(qr_6.ErrorText, string.Empty);
            Assert.AreEqual(qr_6.Success, true);
            Assert.AreEqual(qr_6.HaveBeenFound, false);
            Assert.AreNotEqual(qr_6.Items, null);
            Assert.AreEqual(qr_6.Items.Count, 0);
        }

        [Test]
        public void Queries_Case_2_NumberValue()
        {
            var tmpEngine = new GnuClayEngine();

            var queryString = "WRITE {>: {age(Tom, 25)}}";

            var qr_1 = tmpEngine.Query(queryString);

            Assert.AreNotEqual(qr_1, null);
            Assert.AreEqual(qr_1.ErrorText, string.Empty);
            Assert.AreEqual(qr_1.Success, true);
            Assert.AreEqual(qr_1.HaveBeenFound, false);
            Assert.AreNotEqual(qr_1.Items, null);
            Assert.AreEqual(qr_1.Items.Count, 0);

            var numberKey = tmpEngine.DataDictionary.GetKey("number");
            var x1VarKey = tmpEngine.DataDictionary.GetKey("$X1");

            queryString = "READ {>: {age(Tom, $X1)}}";

            var qr_2 = tmpEngine.Query(queryString);

            Assert.AreNotEqual(qr_2, null);
            Assert.AreEqual(qr_2.ErrorText, string.Empty);
            Assert.AreEqual(qr_2.Success, true);
            Assert.AreEqual(qr_2.HaveBeenFound, true);

            Assert.AreEqual(qr_2.Items.Count, 1);

            var targetItem = qr_2.Items.Single();

            Assert.AreEqual(targetItem.Params.Count, 1);

            var targetVarItem = targetItem.Params.Single();

            Assert.AreEqual(targetVarItem.Kind, ExpressionNodeKind.Value);
            Assert.AreEqual(targetVarItem.Value, 25);
            Assert.AreEqual(targetVarItem.EntityKey, numberKey);
            Assert.AreEqual(targetVarItem.ParamKey, x1VarKey);
        }

        [Test]
        public void Queries_Case_2_Write_Rewrite_Remove()
        {
            var tmpEngine = new GnuClayEngine();

            var redKey = tmpEngine.GetKey("red");
            var greenKey = tmpEngine.GetKey("green");
            var yellowKey = tmpEngine.GetKey("yellow");
            var x1VarKey = tmpEngine.GetKey("$X1");

            var tmpQueryText = "READ {>: {color(dog,$X1)}}";
            var qr_1 = tmpEngine.Query(tmpQueryText);

            Assert.AreNotEqual(qr_1, null);
            Assert.AreEqual(qr_1.ErrorText, string.Empty);
            Assert.AreEqual(qr_1.Success, true);
            Assert.AreEqual(qr_1.HaveBeenFound, false);
            Assert.AreNotEqual(qr_1.Items, null);
            Assert.AreEqual(qr_1.Items.Count, 0);

            tmpQueryText = "WRITE {>: {color(dog,red)}}";
            var tmpResult = tmpEngine.Query(tmpQueryText);

            Assert.AreNotEqual(tmpResult, null);
            Assert.AreEqual(tmpResult.ErrorText, string.Empty);
            Assert.AreEqual(tmpResult.Success, true);
            Assert.AreEqual(tmpResult.HaveBeenFound, false);
            Assert.AreNotEqual(tmpResult.Items, null);
            Assert.AreEqual(tmpResult.Items.Count, 0);

            tmpQueryText = "READ {>: {color(dog,$X1)}}";
            tmpResult = tmpEngine.Query(tmpQueryText);

            Assert.AreNotEqual(tmpResult, null);
            Assert.AreEqual(tmpResult.ErrorText, string.Empty);
            Assert.AreEqual(tmpResult.Success, true);
            Assert.AreEqual(tmpResult.HaveBeenFound, true);

            Assert.AreEqual(tmpResult.Items.Count, 1);

            var targetItem = tmpResult.Items.Single();

            Assert.AreEqual(targetItem.Params.Count, 1);

            var targetVarItem = targetItem.Params.Single();

            Assert.AreEqual(targetVarItem.Kind, ExpressionNodeKind.Entity);
            Assert.AreEqual(targetVarItem.EntityKey, redKey);
            Assert.AreEqual(targetVarItem.ParamKey, x1VarKey);

            tmpQueryText = "WRITE {>: {color(dog,yellow)}}";
            tmpResult = tmpEngine.Query(tmpQueryText);

            Assert.AreNotEqual(tmpResult, null);
            Assert.AreEqual(tmpResult.ErrorText, string.Empty);
            Assert.AreEqual(tmpResult.Success, true);
            Assert.AreEqual(tmpResult.HaveBeenFound, false);
            Assert.AreNotEqual(tmpResult.Items, null);
            Assert.AreEqual(tmpResult.Items.Count, 0);

            tmpQueryText = "READ {>: {color(dog,$X1)}}";
            var qr_2 = tmpEngine.Query(tmpQueryText);

            Assert.AreNotEqual(qr_2, null);
            Assert.AreEqual(qr_2.ErrorText, string.Empty);
            Assert.AreEqual(qr_2.Success, true);
            Assert.AreEqual(qr_2.HaveBeenFound, true);

            Assert.AreEqual(qr_2.Items.Count, 2);

            targetItem = qr_2.Items[0];

            Assert.AreEqual(targetItem.Params.Count, 1);

            targetVarItem = targetItem.Params.Single();

            Assert.AreEqual(targetVarItem.Kind, ExpressionNodeKind.Entity);
            Assert.AreEqual(targetVarItem.EntityKey, redKey);
            Assert.AreEqual(targetVarItem.ParamKey, x1VarKey);

            targetItem = qr_2.Items[1];

            Assert.AreEqual(targetItem.Params.Count, 1);

            targetVarItem = targetItem.Params.Single();

            Assert.AreEqual(targetVarItem.Kind, ExpressionNodeKind.Entity);
            Assert.AreEqual(targetVarItem.EntityKey, yellowKey);
            Assert.AreEqual(targetVarItem.ParamKey, x1VarKey);

            tmpQueryText = "REWRITE {>: {color(dog,green)}}";
            tmpResult = tmpEngine.Query(tmpQueryText);

            Assert.AreNotEqual(tmpResult, null);
            Assert.AreEqual(tmpResult.ErrorText, string.Empty);
            Assert.AreEqual(tmpResult.Success, true);
            Assert.AreEqual(tmpResult.HaveBeenFound, false);
            Assert.AreNotEqual(tmpResult.Items, null);
            Assert.AreEqual(tmpResult.Items.Count, 0);

            tmpQueryText = "READ {>: {color(dog,$X1)}}";
            tmpResult = tmpEngine.Query(tmpQueryText);

            Assert.AreNotEqual(tmpResult, null);
            Assert.AreEqual(tmpResult.ErrorText, string.Empty);
            Assert.AreEqual(tmpResult.Success, true);
            Assert.AreEqual(tmpResult.HaveBeenFound, true);

            Assert.AreEqual(tmpResult.Items.Count, 1);

            targetItem = tmpResult.Items.Single();

            Assert.AreEqual(targetItem.Params.Count, 1);

            targetVarItem = targetItem.Params.Single();

            Assert.AreEqual(targetVarItem.Kind, ExpressionNodeKind.Entity);
            Assert.AreEqual(targetVarItem.EntityKey, greenKey);
            Assert.AreEqual(targetVarItem.ParamKey, x1VarKey);

            tmpQueryText = "DELETE {>: {color(dog,$X1)}}";
            tmpResult = tmpEngine.Query(tmpQueryText);

            Assert.AreNotEqual(tmpResult, null);
            Assert.AreEqual(tmpResult.ErrorText, string.Empty);
            Assert.AreEqual(tmpResult.Success, true);
            Assert.AreEqual(tmpResult.HaveBeenFound, false);
            Assert.AreNotEqual(tmpResult.Items, null);
            Assert.AreEqual(tmpResult.Items.Count, 0);

            tmpQueryText = "READ {>: {color(dog,$X1)}}";
            tmpResult = tmpEngine.Query(tmpQueryText);

            Assert.AreNotEqual(tmpResult, null);
            Assert.AreEqual(tmpResult.ErrorText, string.Empty);
            Assert.AreEqual(tmpResult.Success, true);
            Assert.AreEqual(tmpResult.HaveBeenFound, false);
            Assert.AreNotEqual(tmpResult.Items, null);
            Assert.AreEqual(tmpResult.Items.Count, 0);
        }
    }
}
