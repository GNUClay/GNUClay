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
        public void Case_1()
        {
            var tmpEngine = new GnuClayEngine();

            var queryString = "SELECT{ >:{son(Piter,$X1)}}";

            var qr_1 = tmpEngine.Query(queryString);

            Assert.AreNotEqual(qr_1, null);
            Assert.AreEqual(qr_1.ErrorText, string.Empty);
            Assert.AreEqual(qr_1.Success, true);
            Assert.AreEqual(qr_1.HaveBeenFound, false);
            Assert.AreNotEqual(qr_1.Items, null);
            Assert.AreEqual(qr_1.Items.Count, 0);

            queryString = "SELECT{>:{son(Piter,Tom)}}";

            var qr_2 = tmpEngine.Query(queryString);

            Assert.AreNotEqual(qr_2, null);
            Assert.AreEqual(qr_2.ErrorText, string.Empty);
            Assert.AreEqual(qr_2.Success, true);
            Assert.AreEqual(qr_2.HaveBeenFound, false);
            Assert.AreNotEqual(qr_2.Items, null);
            Assert.AreEqual(qr_2.Items.Count, 0);

            queryString = "INSERT{>: {parent($X1,$X2)} -> {child($X2,$X1)}},{>: {son($X1,$X2)} -> {child($X1,$X2) & male($X1)}},{>: {parent(Tom,Piter)}},{>: {parent(Tom,Mary)}},{>: {male(Piter)}},{>: {female(Mary)}},{>: {male(Bob)}}";

            var insert_result = tmpEngine.Query(queryString);

            Assert.AreNotEqual(insert_result, null);
            Assert.AreEqual(insert_result.ErrorText, string.Empty);
            Assert.AreEqual(insert_result.Success, true);
            Assert.AreEqual(insert_result.HaveBeenFound, false);
            Assert.AreNotEqual(insert_result.Items, null);
            Assert.AreEqual(insert_result.Items.Count, 0);

            queryString = "SELECT{ >: {son(Piter,$X1)}}";

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

            queryString = "SELECT{ >: {son(Piter,Tom)}}";

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

            queryString = "SELECT{ >:{son(Piter,$X1)}}";

            var qr_5 = tmpEngine.Query(queryString);

            Assert.AreNotEqual(qr_5, null);
            Assert.AreEqual(qr_5.ErrorText, string.Empty);
            Assert.AreEqual(qr_5.Success, true);
            Assert.AreEqual(qr_5.HaveBeenFound, false);
            Assert.AreNotEqual(qr_5.Items, null);
            Assert.AreEqual(qr_5.Items.Count, 0);

            queryString = "SELECT{ >:{son(Piter,Tom)}}";

            var qr_6 = tmpEngine.Query(queryString);

            Assert.AreNotEqual(qr_6, null);
            Assert.AreEqual(qr_6.ErrorText, string.Empty);
            Assert.AreEqual(qr_6.Success, true);
            Assert.AreEqual(qr_6.HaveBeenFound, false);
            Assert.AreNotEqual(qr_6.Items, null);
            Assert.AreEqual(qr_6.Items.Count, 0);
        }
    }
}
