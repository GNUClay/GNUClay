using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GnuClay.ECG.Test
{
    [TestFixture]
    public class RelationNodeTests
    {
        [Test]
        public void AddInputNode_SomeRelation_LinkTwoRelations()
        {
            var tmpRelation_1 = new RelationNode();

            var tmpRelation_2 = new RelationNode();

            tmpRelation_1.AddInputNode(tmpRelation_2);

            Assert.AreEqual(1, tmpRelation_1.InputNodes.Count(p => p == tmpRelation_2));
            Assert.AreEqual(1, tmpRelation_2.OutputNodes.Count(p => p == tmpRelation_1));
        }

        [Test]
        public void AddOutputNode_SomeRelation_LinkTwoRelations()
        {
            var tmpRelation_1 = new RelationNode();

            var tmpRelation_2 = new RelationNode();

            tmpRelation_1.AddOutputNode(tmpRelation_2);

            Assert.AreEqual(1, tmpRelation_1.OutputNodes.Count(p => p == tmpRelation_2));
            Assert.AreEqual(1, tmpRelation_2.InputNodes.Count(p => p == tmpRelation_1));
        }

        [Test]
        public void Name_Equal_FullName()
        {
            var tmpName = "at";
            var tmpFullName = "at";

            var tmpRelation = new RelationNode();

            tmpRelation.Name = tmpName;

            StringAssert.AreEqualIgnoringCase(tmpFullName, tmpRelation.FullName);
        }
    }
}
