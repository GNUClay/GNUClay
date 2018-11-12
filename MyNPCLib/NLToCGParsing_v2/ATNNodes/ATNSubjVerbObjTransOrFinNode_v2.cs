using MyNPCLib.NLToCGParsing;
using MyNPCLib.NLToCGParsing.PhraseTree;
using MyNPCLib.SimpleWordsDict;
using System;
using System.Collections.Generic;
using System.Text;

namespace MyNPCLib.NLToCGParsing_v2.ATNNodes
{
    public delegate void InitATNSubjVerbObjTransOrFinNodeAction(ATNSubjVerbObjTransOrFinNode_v2 item);

    public class ATNSubjVerbObjTransOrFinNodeFactory_v2: BaseATNNodeFactory_v2
    {
        public ATNSubjVerbObjTransOrFinNodeFactory_v2(ATNSubjVerbTransOrFinNode_v2 parentNode, ATNExtendedToken token)
        {
            mNumberOfConstructor = 1;
            mParentNode = parentNode;
            mToken = token;
        }

        public ATNSubjVerbObjTransOrFinNodeFactory_v2(ATNSubjVerbObjTransOrFinNode_v2 sameNode, ATNExtendedToken token, InitATNSubjVerbObjTransOrFinNodeAction initAction)
        {
            mNumberOfConstructor = 2;
            mSameNode = sameNode;
            mToken = token;
            mInitAction = initAction;
        }

        private int mNumberOfConstructor;
        private ATNSubjVerbTransOrFinNode_v2 mParentNode;
        private ATNSubjVerbObjTransOrFinNode_v2 mSameNode;
        private ATNExtendedToken mToken;
        private InitATNSubjVerbObjTransOrFinNodeAction mInitAction;

        public override BaseATNNode_v2 Create(ContextOfATNParsing_v2 context)
        {
            switch(mNumberOfConstructor)
            {
                case 1:
                    return new ATNSubjVerbObjTransOrFinNode_v2(context, mParentNode, mToken);

                case 2:
                    return new ATNSubjVerbObjTransOrFinNode_v2(context, mSameNode, mInitAction, mToken);

                default:
                    throw new ArgumentOutOfRangeException(nameof(mNumberOfConstructor), mNumberOfConstructor, null);
            }
        }
    }

/*Sub states:
    Subj_Verb_Obj_Condition_Fin
*/

    public class ATNSubjVerbObjTransOrFinNode_v2: BaseATNNode_v2
    {
        public ATNSubjVerbObjTransOrFinNode_v2(ContextOfATNParsing_v2 context, ATNSubjVerbTransOrFinNode_v2 parentNode, ATNExtendedToken token)
            : base(context, token)
        {
            ParentNode = parentNode;
            SlaveNAPNode = new ATNSlaveNAPNode(context, new ObjectTargetOfATNSlaveNAPNode());
            RegATNSlaveNAPNode(SlaveNAPNode);
        }

        public ATNSubjVerbObjTransOrFinNode_v2(ContextOfATNParsing_v2 context, ATNSubjVerbObjTransOrFinNode_v2 sameNode, InitATNSubjVerbObjTransOrFinNodeAction initAction, ATNExtendedToken token)
            : base(context, token)
        {
            mSameNode = sameNode;
            mInitAction = initAction;
            ParentNode = mSameNode.ParentNode;
            SlaveNAPNode = mSameNode.SlaveNAPNode.Fork(context);
            RegATNSlaveNAPNode(SlaveNAPNode);
            mInitAction?.Invoke(this);
        }

        public override StateOfATNParsing_v2 GlobalState => StateOfATNParsing_v2.Subj_Verb_Obj_TransOrFin;

        public ATNSubjVerbTransOrFinNode_v2 ParentNode { get; private set; }
        private ATNSubjVerbObjTransOrFinNode_v2 mSameNode;
        private InitATNSubjVerbObjTransOrFinNodeAction mInitAction;

        public ATNSlaveNAPNode SlaveNAPNode { get; set; }

        protected override void ImplementGoalToken()
        {
#if DEBUG
            LogInstance.Log($"Token = {Token}");
            LogInstance.Log($"Context = {Context}");

            //var tmpParentVerbPhrase = ParentNode.Context.Sentence.VerbPhrase;

            //LogInstance.Log($"tmpParentVerbPhrase = {tmpParentVerbPhrase}");

            //var tmpCurrentVerbPhrase = Context.Sentence.VerbPhrase;

            //LogInstance.Log($"tmpCurrentVerbPhrase = {tmpCurrentVerbPhrase}");

            //var tmpSecondCurrentVerbPhrase = Context.Sentence.GetByRunTimeSessionKey<VerbPhrase>(tmpParentVerbPhrase);

            //LogInstance.Log($"tmpSecondCurrentVerbPhrase = {tmpSecondCurrentVerbPhrase}");

            //LogInstance.Log($"(tmpSecondCurrentVerbPhrase == tmpCurrentVerbPhrase) = {tmpSecondCurrentVerbPhrase == tmpCurrentVerbPhrase}");

            //LogInstance.Log($"(tmpSecondCurrentVerbPhrase == tmpParentVerbPhrase) = {tmpSecondCurrentVerbPhrase == tmpParentVerbPhrase}");
#endif

            SetAsSuccess(SlaveNAPNode.Run(Token));
        }

        protected override void ProcessNextToken()
        {
            var extendedTokensList = Get—lusterOfExtendedTokens();

#if DEBUG
            LogInstance.Log($"extendedTokensList.Count = {extendedTokensList.Count}");
#endif

            if (extendedTokensList.Count == 0)
            {
#if DEBUG
                //LogInstance.Log($"Context = {Context}");
#endif

                Context.PutSentenceToResult();
                return;
            }

            var hasObjOrSubj = false;

            foreach (var item in extendedTokensList)
            {
#if DEBUG
                LogInstance.Log($"item = {item}");
#endif

                var kindOfItem = item.KindOfItem;

                switch (kindOfItem)
                {
                    case KindOfItemOfSentence.Subj:
                        if (hasObjOrSubj)
                        {
                            break;
                        }

                        hasObjOrSubj = true;
                        AddTask(new ATNSubjVerbObjTransOrFinNodeFactory_v2(this, item, null));
                        break;

                    case KindOfItemOfSentence.Obj:
                        if (hasObjOrSubj)
                        {
                            break;
                        }

                        hasObjOrSubj = true;
                        AddTask(new ATNSubjVerbObjTransOrFinNodeFactory_v2(this, item, null));
                        break;

                    case KindOfItemOfSentence.Condition:
                        if(item.PartOfSpeech == GrammaticalPartOfSpeech.Preposition)
                        {
                            AddTask(new ATNSubjVerbObjConditionFinNodeFactory_v2(this, item));
                        }                    
                        break;

                    default:
                        throw new ArgumentOutOfRangeException(nameof(kindOfItem), kindOfItem, null);
                }
            }
        }
    }
}

