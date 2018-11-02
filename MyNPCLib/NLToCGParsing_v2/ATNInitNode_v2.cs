using MyNPCLib.NLToCGParsing;
using MyNPCLib.NLToCGParsing.PhraseTree;
using MyNPCLib.NLToCGParsing_v2.ATNNodes;
using System;
using System.Collections.Generic;
using System.Text;

namespace MyNPCLib.NLToCGParsing_v2
{
    public class ATNInitNode_v2: BaseATNNode_v2
    {
        public ATNInitNode_v2(ContextOfATNParsing_v2 context)
            : base(context, null)
        {
        }

        public override StateOfATNParsing_v2 GlobalState => StateOfATNParsing_v2.Init;

        protected override void ImplementGoalToken()
        {
            Context.Sentence = new Sentence();
        }

        protected override void ProcessNextToken()
        {
            var extendedTokensList = GetСlusterOfExtendedTokens();

#if DEBUG
            LogInstance.Log($"extendedTokensList.Count = {extendedTokensList.Count}");
#endif

            if(extendedTokensList.Count == 0)
            {
                throw new NotImplementedException();
            }

            foreach (var item in extendedTokensList)
            {
#if DEBUG           
                LogInstance.Log($"item = {item}");
#endif

                var kindOfItem = item.KindOfItem;

                switch(kindOfItem)
                {
                    case KindOfItemOfSentence.Subj:
                        AddTask(new ATNSubjTransNodeFactory_v2(this, item));
                        break;

                    case KindOfItemOfSentence.Verb:
                        AddTask(new ATNVerbTransOrFinNodeFactory_v2(this, item));
                        break;

                    case KindOfItemOfSentence.FToDo:
                        AddTask(new ATNFToDoTransNodeFactory_v2(this, item));
                        break;

                    default:
                        throw new ArgumentOutOfRangeException(nameof(kindOfItem), kindOfItem, null);
                }
            }
        }
    }
}
