using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GnuClay.ECG.Test
{
    [TestFixture]
    public class BaseNodeTests
    {
        [Test]
        public void Parent_SetSomeNode_ThisNodeWillBeInHisChildrenOfThisParent()
        {
            var tmpParent = new ConceptualNode();

            var tmpChild = new RelationNode();

            tmpChild.Parent = tmpParent;

            Assert.AreEqual(true, tmpParent.Children.Contains(tmpChild));
        }

        [Test]
        public void ConstructorWithParent_SetSomeNode_ThisNodeWillBeInHisChildrenOfThisParent()
        {
            var tmpParent = new ConceptualNode();

            var tmpChild = new RelationNode(tmpParent);

            Assert.AreEqual(true, tmpParent.Children.Contains(tmpChild));
        }

        [Test]
        public void AddChild_SetSomeNode_TheParentNodeWillBeInParentProperty()
        {
            var tmpParent = new ConceptualNode();

            var tmpChild = new RelationNode();

            tmpParent.AddChild(tmpChild);

            Assert.AreEqual(tmpParent, tmpChild.Parent);

            tmpParent.RemoveChild(tmpChild);

            Assert.AreEqual(null, tmpChild.Parent);

            Assert.AreNotEqual(tmpParent, tmpChild.Parent);
        }

        [Test]
        public void Parent_ChangeParents_TrueParentAsResult()
        {
            var tmpParent_1 = new ConceptualNode();

            var tmpParent_2 = new ConceptualNode();

            var tmpChild = new RelationNode();

            Assert.AreEqual(null, tmpChild.Parent);

            Assert.AreNotEqual(tmpParent_1, tmpChild.Parent);

            Assert.AreNotEqual(tmpParent_2, tmpChild.Parent);

            Assert.AreEqual(false, tmpParent_1.Children.Contains(tmpChild));

            Assert.AreEqual(false, tmpParent_2.Children.Contains(tmpChild));

            tmpChild.Parent = tmpParent_1;

            Assert.AreNotEqual(null, tmpChild.Parent);

            Assert.AreEqual(tmpParent_1, tmpChild.Parent);

            Assert.AreNotEqual(tmpParent_2, tmpChild.Parent);

            Assert.AreEqual(true, tmpParent_1.Children.Contains(tmpChild));

            Assert.AreEqual(false, tmpParent_2.Children.Contains(tmpChild));

            tmpChild.Parent = tmpParent_2;

            Assert.AreNotEqual(null, tmpChild.Parent);

            Assert.AreNotEqual(tmpParent_1, tmpChild.Parent);

            Assert.AreEqual(tmpParent_2, tmpChild.Parent);

            Assert.AreEqual(false, tmpParent_1.Children.Contains(tmpChild));

            Assert.AreEqual(true, tmpParent_2.Children.Contains(tmpChild));

            tmpChild.Parent = null;

            Assert.AreEqual(null, tmpChild.Parent);

            Assert.AreNotEqual(tmpParent_1, tmpChild.Parent);

            Assert.AreNotEqual(tmpParent_2, tmpChild.Parent);

            Assert.AreEqual(false, tmpParent_1.Children.Contains(tmpChild));

            Assert.AreEqual(false, tmpParent_2.Children.Contains(tmpChild));
        }

        [Test]
        public void AddAnnotation_SomeAnnotation_OneAnnotation()
        {
            var tmpNode = new RelationNode();

            var tmpAnnotation = new ConceptualNode();

            tmpNode.AddAnnotation(tmpAnnotation);

            Assert.AreEqual(true, tmpNode.Annotations.Contains(tmpAnnotation));
        }

        [Test]
        public void AddAnnotationTwise_SomeAnnotation_OneAnnotation()
        {
            var tmpNode = new RelationNode();

            var tmpAnnotation = new ConceptualNode();

            tmpNode.AddAnnotation(tmpAnnotation);
            tmpNode.AddAnnotation(tmpAnnotation);

            Assert.AreEqual(1, tmpNode.Annotations.Count(p => p == tmpAnnotation));
        }

        [Test]
        public void RemoveAnnotation_SomeAnnotation_ZeroAnnotations()
        {
            var tmpNode = new RelationNode();

            var tmpAnnotation = new ConceptualNode();

            tmpNode.AddAnnotation(tmpAnnotation);
            tmpNode.RemoveAnnotation(tmpAnnotation);

            Assert.AreEqual(0, tmpNode.Annotations.Count(p => p == tmpAnnotation));
        }

        [Test]
        public void AddAnnotation_SomeAnnotation_And_RemoveAnnotation_SomeLeftAnnotation_OneAnnotation()
        {
            var tmpNode = new RelationNode();

            var tmpAnnotation_1 = new ConceptualNode();

            tmpNode.AddAnnotation(tmpAnnotation_1);

            var tmpAnnotation_2 = new ConceptualNode();

            tmpNode.RemoveAnnotation(tmpAnnotation_2);

            Assert.AreEqual(1, tmpNode.Annotations.Count(p => p == tmpAnnotation_1));
        }

        [Test]
        public void AddAnnotation_Null_ThrowArgumentNullException()
        {
            var tmpNode = new RelationNode();

            var tmpEx = Assert.Catch<ArgumentNullException>(() => { tmpNode.AddAnnotation(null); });

            StringAssert.AreEqualIgnoringCase("annotation", tmpEx.ParamName);
        }

        [Test]
        public void RemoveAnnotation_Null_ThrowArgumentNullException()
        {
            var tmpNode = new RelationNode();

            var tmpEx = Assert.Catch<ArgumentNullException>(() => { tmpNode.RemoveAnnotation(null); });

            StringAssert.AreEqualIgnoringCase("annotation", tmpEx.ParamName);
        }

    }
}
