using GnuClay.CommonUtils.CG;
using GnuClay.TextCGParser;
using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GnuClay.UnitTests.TextCGParser
{
    [TestFixture]
    public class TextCGEngineTests
    {
        [Test]
        public void The_Dog_Likes_Man()
        {
            var targetPhrase = "The dog likes man.";

            var parser = new TextCGEngine();

            var cgNodes = parser.Run(targetPhrase);

            Assert.NotNull(cgNodes);
            Assert.AreEqual(cgNodes.Count, 1);

            var result = cgNodes.Single();

            var rootNode = new CGNode();
            rootNode.Kind = CGNodeKind.Concept;

            var sentenceNode = new CGNode(rootNode);
            sentenceNode.Kind = CGNodeKind.Concept;

            var subjectNode = new CGNode(sentenceNode);
            subjectNode.Kind = CGNodeKind.Concept;

            subjectNode.ClassName = "dog";
            subjectNode.InstanceName = "#1";

            var verb = new CGNode(sentenceNode);
            verb.Kind = CGNodeKind.Concept;

            verb.ClassName = "like";

            var _object = new CGNode(sentenceNode);
            _object.Kind = CGNodeKind.Concept;

            _object.ClassName = "man";
            _object.InstanceName = "#2";

            var stateRelation = new CGNode(sentenceNode);
            stateRelation.Kind = CGNodeKind.Relation;

            stateRelation.ClassName = "state";

            var expensierRelation = new CGNode(sentenceNode);
            expensierRelation.Kind = CGNodeKind.Relation;

            expensierRelation.ClassName = "expensier";

            var objectRelation = new CGNode(sentenceNode);
            objectRelation.Kind = CGNodeKind.Relation;

            objectRelation.ClassName = "object";

            stateRelation.AddInputNode(subjectNode);
            stateRelation.AddOutputNode(verb);

            expensierRelation.AddInputNode(verb);
            expensierRelation.AddOutputNode(subjectNode);

            objectRelation.AddInputNode(verb);
            objectRelation.AddOutputNode(_object);

            var tenseNode = new CGNode(rootNode);
            tenseNode.Kind = CGNodeKind.Concept;

            tenseNode.ClassName = "present";

            var tenseRelation = new CGNode(rootNode);
            tenseRelation.Kind = CGNodeKind.Relation;
            tenseRelation.ClassName = "tense";

            tenseRelation.AddInputNode(sentenceNode);
            tenseRelation.AddOutputNode(tenseNode);

            var aspectNode = new CGNode(rootNode);
            aspectNode.Kind = CGNodeKind.Concept;
            aspectNode.ClassName = "simple";

            var aspectRelation = new CGNode(rootNode);
            aspectRelation.Kind = CGNodeKind.Relation;
            aspectRelation.ClassName = "aspect";

            aspectRelation.AddInputNode(sentenceNode);
            aspectRelation.AddOutputNode(aspectNode);

            Assert.AreEqual(result.IsEquals(rootNode), true);
        }
    }
}
