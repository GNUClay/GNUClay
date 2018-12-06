using MyNPCLib.CG;
using MyNPCLib.CommonServiceGrammaticalElements;
using MyNPCLib.NLToCGParsing;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace MyNPCLib.NLToCGParsing_v2
{
    public abstract class BaseNodeOfSemanticAnalyzer_v2
    {
        protected BaseNodeOfSemanticAnalyzer_v2(ContextOfSemanticAnalyzer context)
        {
            Context = context;
        }

        protected ContextOfSemanticAnalyzer Context { get; private set; }
        protected RolesStorageOfSemanticAnalyzer PrimaryRolesDict { get; private set; } = new RolesStorageOfSemanticAnalyzer();

        protected string GetName(ATNExtendedToken extendedToken)
        {
            var rootWord = extendedToken.RootWord;

            if (string.IsNullOrWhiteSpace(rootWord))
            {
                return extendedToken.Content;
            }

            return rootWord;
        }

        protected string GetConditionalLogicalMeaning(string word, string conditionalWord)
        {
            var list = Context.WordsDict.GetConditionalLogicalMeaning(word, conditionalWord);
            return list.FirstOrDefault();
        }

        protected void MarkAsEntityCondition(RelationCGNode relation)
        {
            var relationName = CGGramamaticalNamesOfRelations.EntityCondition;
            var conceptualGraph = Context.ConceptualGraph;

            var secondaryRelation = new RelationCGNode();
            secondaryRelation.Parent = conceptualGraph;
            secondaryRelation.Name = relationName;

            secondaryRelation.AddOutputNode(relation);
        }
    }
}
