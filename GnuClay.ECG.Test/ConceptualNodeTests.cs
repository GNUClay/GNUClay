using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GnuClay.ECG.Test
{
    [TestFixture]
    public class ConceptualNodeTests
    {
        [Test]
        public void AddChild_Null_ThrowArgumentNullException()
        {
            var tmpNode = new ConceptualNode();

            var tmpEx = Assert.Catch<ArgumentNullException>(() => { tmpNode.AddChild(null); });

            StringAssert.AreEqualIgnoringCase("node", tmpEx.ParamName);
        }

        [Test]
        public void RemoveChild_Null_ThrowArgumentNullException()
        {
            var tmpNode = new ConceptualNode();

            var tmpEx = Assert.Catch<ArgumentNullException>(() => { tmpNode.RemoveChild(null); });

            StringAssert.AreEqualIgnoringCase("node", tmpEx.ParamName);
        }

        [Test]
        public void AddInputNode_Null_ThrowArgumentNullException()
        {
            var tmpNode = new ConceptualNode();

            var tmpEx = Assert.Catch<ArgumentNullException>(() => { tmpNode.AddInputNode(null); });

            StringAssert.AreEqualIgnoringCase("node", tmpEx.ParamName);
        }

        [Test]
        public void RemoveInputNode_Null_ThrowArgumentNullException()
        {
            var tmpNode = new ConceptualNode();

            var tmpEx = Assert.Catch<ArgumentNullException>(() => { tmpNode.RemoveInputNode(null); });

            StringAssert.AreEqualIgnoringCase("node", tmpEx.ParamName);
        }

        [Test]
        public void AddOutputNode_Null_ThrowArgumentNullException()
        {
            var tmpNode = new ConceptualNode();

            var tmpEx = Assert.Catch<ArgumentNullException>(() => { tmpNode.AddOutputNode(null); });

            StringAssert.AreEqualIgnoringCase("node", tmpEx.ParamName);
        }

        [Test]
        public void RemoveOutputNode_Null_ThrowArgumentNullException()
        {
            var tmpNode = new ConceptualNode();

            var tmpEx = Assert.Catch<ArgumentNullException>(() => { tmpNode.RemoveOutputNode(null); });

            StringAssert.AreEqualIgnoringCase("node", tmpEx.ParamName);
        }

        [Test]
        public void AddInputNode_OtherConcept_ThrowArgumentException()
        {
            var tmpNode = new ConceptualNode();

            var tmpOtherNode = new ConceptualNode();

            var tmpEx = Assert.Catch<ArgumentException>(() => { tmpNode.AddInputNode(tmpOtherNode); });

            StringAssert.AreEqualIgnoringCase("node", tmpEx.ParamName);
        }

        [Test]
        public void AddOutputNode_OtherConcept_ThrowArgumentException()
        {
            var tmpNode = new ConceptualNode();

            var tmpOtherNode = new ConceptualNode();

            var tmpEx = Assert.Catch<ArgumentException>(() => { tmpNode.AddOutputNode(tmpOtherNode); });

            StringAssert.AreEqualIgnoringCase("node", tmpEx.ParamName);
        }

        [Test]
        public void AddInputNode_SomeRelation_RelationIsAdded()
        {
            var tmpNode = new ConceptualNode();

            var tmpRelation = new RelationNode();

            tmpNode.AddInputNode(tmpRelation);

            Assert.AreEqual(1, tmpNode.InputNodes.Count(p => p == tmpRelation));
            Assert.AreEqual(1, tmpRelation.OutputNodes.Count(p => p == tmpNode));
        }

        [Test]
        public void AddInputNode_SomeRelationTwise_RelationIsAddedSingle()
        {
            var tmpNode = new ConceptualNode();

            var tmpRelation = new RelationNode();

            tmpNode.AddInputNode(tmpRelation);
            tmpNode.AddInputNode(tmpRelation);

            Assert.AreEqual(1, tmpNode.InputNodes.Count(p => p == tmpRelation));
            Assert.AreEqual(1, tmpRelation.OutputNodes.Count(p => p == tmpNode));
        }

        [Test]
        public void RemoveInputNode_SomeRelation_RelationIsRemoved()
        {
            var tmpNode = new ConceptualNode();

            var tmpRelation = new RelationNode();

            tmpNode.AddInputNode(tmpRelation);

            Assert.AreEqual(1, tmpNode.InputNodes.Count(p => p == tmpRelation));
            Assert.AreEqual(1, tmpRelation.OutputNodes.Count(p => p == tmpNode));

            tmpNode.RemoveInputNode(tmpRelation);

            Assert.AreEqual(0, tmpNode.InputNodes.Count(p => p == tmpRelation));
            Assert.AreEqual(0, tmpRelation.OutputNodes.Count(p => p == tmpNode));
        }

        [Test]
        public void RemoveInputNode_SomeRelationTwise_RelationIsRemoved()
        {
            var tmpNode = new ConceptualNode();

            var tmpRelation = new RelationNode();

            tmpNode.AddInputNode(tmpRelation);

            Assert.AreEqual(1, tmpNode.InputNodes.Count(p => p == tmpRelation));
            Assert.AreEqual(1, tmpRelation.OutputNodes.Count(p => p == tmpNode));

            tmpNode.RemoveInputNode(tmpRelation);
            tmpNode.RemoveInputNode(tmpRelation);

            Assert.AreEqual(0, tmpNode.InputNodes.Count(p => p == tmpRelation));
            Assert.AreEqual(0, tmpRelation.OutputNodes.Count(p => p == tmpNode));
        }

        [Test]
        public void AddOutputNode_SomeRelation_RelationIsAdded()
        {
            var tmpNode = new ConceptualNode();

            var tmpRelation = new RelationNode();

            tmpNode.AddOutputNode(tmpRelation);

            Assert.AreEqual(1, tmpNode.OutputNodes.Count(p => p == tmpRelation));
            Assert.AreEqual(1, tmpRelation.InputNodes.Count(p => p == tmpNode));
        }

        [Test]
        public void AddOutputNode_SomeRelationTwise_RelationIsAddedSingle()
        {
            var tmpNode = new ConceptualNode();

            var tmpRelation = new RelationNode();

            tmpNode.AddOutputNode(tmpRelation);
            tmpNode.AddOutputNode(tmpRelation);

            Assert.AreEqual(1, tmpNode.OutputNodes.Count(p => p == tmpRelation));
            Assert.AreEqual(1, tmpRelation.InputNodes.Count(p => p == tmpNode));
        }

        [Test]
        public void RemoveOutputNode_SomeRelation_RelationIsRemoved()
        {
            var tmpNode = new ConceptualNode();

            var tmpRelation = new RelationNode();

            tmpNode.AddOutputNode(tmpRelation);

            Assert.AreEqual(1, tmpNode.OutputNodes.Count(p => p == tmpRelation));
            Assert.AreEqual(1, tmpRelation.InputNodes.Count(p => p == tmpNode));

            tmpNode.RemoveOutputNode(tmpRelation);

            Assert.AreEqual(0, tmpNode.OutputNodes.Count(p => p == tmpRelation));
            Assert.AreEqual(0, tmpRelation.InputNodes.Count(p => p == tmpNode));
        }

        [Test]
        public void RemoveOutputNode_SomeRelationTwise_RelationIsRemoved()
        {
            var tmpNode = new ConceptualNode();

            var tmpRelation = new RelationNode();

            tmpNode.AddOutputNode(tmpRelation);

            Assert.AreEqual(1, tmpNode.OutputNodes.Count(p => p == tmpRelation));
            Assert.AreEqual(1, tmpRelation.InputNodes.Count(p => p == tmpNode));

            tmpNode.RemoveOutputNode(tmpRelation);
            tmpNode.RemoveOutputNode(tmpRelation);

            Assert.AreEqual(0, tmpNode.OutputNodes.Count(p => p == tmpRelation));
            Assert.AreEqual(0, tmpRelation.InputNodes.Count(p => p == tmpNode));
        }

        [Test]
        public void FullName_Contains_Name_And_ClassName()
        {
            var tmpName = "#Spike";
            var tmpClassName = "dog";

            StringAssert.AreNotEqualIgnoringCase(tmpName, tmpClassName);

            var tmpNode = new ConceptualNode();

            tmpNode.Name = tmpName;
            tmpNode.ClassName = tmpClassName;

            StringAssert.Contains(tmpName, tmpNode.FullName);
            StringAssert.Contains(tmpClassName, tmpNode.FullName);
        }

        [Test]
        public void FullName_Contains_ClassNameAndColon_IfNameIsNullOrEmpty()
        {
            var tmpName = string.Empty;
            var tmpClassName = "dog";

            StringAssert.AreNotEqualIgnoringCase(tmpName, tmpClassName);

            var tmpNode = new ConceptualNode();

            tmpNode.Name = tmpName;
            tmpNode.ClassName = tmpClassName;

            StringAssert.Contains(":", tmpNode.FullName);
            StringAssert.Contains(tmpClassName, tmpNode.FullName);
        }
    }
}
