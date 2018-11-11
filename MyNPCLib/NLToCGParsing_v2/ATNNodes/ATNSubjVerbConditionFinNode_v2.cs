using MyNPCLib.NLToCGParsing;
using MyNPCLib.NLToCGParsing_v2.PhraseTree;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace MyNPCLib.NLToCGParsing_v2.ATNNodes
{
    public delegate void InitATNSubjVerbConditionFinNodeAction(ATNSubjVerbConditionFinNode_v2 item);

    public class ATNSubjVerbConditionFinNodeFactory_v2: BaseATNNodeFactory_v2
    {
        public ATNSubjVerbConditionFinNodeFactory_v2(ATNSubjVerbTransOrFinNode_v2 parentNode, ATNExtendedToken token)
        {
            mNumberOfConstructor = 1;
            mParentNode = parentNode;
            mToken = token;
        }

        public ATNSubjVerbConditionFinNodeFactory_v2(ATNSubjVerbConditionFinNode_v2 sameNode, ATNExtendedToken token, InitATNSubjVerbConditionFinNodeAction initAction)
        {
            mNumberOfConstructor = 2;
            mSameNode = sameNode;
            mToken = token;
            mInitAction = initAction;
        }

        private int mNumberOfConstructor;
        private ATNSubjVerbTransOrFinNode_v2 mParentNode;
        private ATNSubjVerbConditionFinNode_v2 mSameNode;
        private ATNExtendedToken mToken;
        private InitATNSubjVerbConditionFinNodeAction mInitAction;

        public override BaseATNNode_v2 Create(ContextOfATNParsing_v2 context)
        {
            switch(mNumberOfConstructor)
            {
                case 1:
                    return new ATNSubjVerbConditionFinNode_v2(context, mParentNode, mToken);

                case 2:
                    return new ATNSubjVerbConditionFinNode_v2(context, mSameNode, mInitAction, mToken);

                default:
                    throw new ArgumentOutOfRangeException(nameof(mNumberOfConstructor), mNumberOfConstructor, null);
            }
        }
    }

    public class ATNSubjVerbConditionFinNode_v2: BaseATNNode_v2
    {
        public ATNSubjVerbConditionFinNode_v2(ContextOfATNParsing_v2 context, ATNSubjVerbTransOrFinNode_v2 parentNode, ATNExtendedToken token)
            : base(context, token)
        {
            ParentNode = parentNode;
            SlaveNAPNode = new ATNSlaveNAPNode(context, new MainConditionTargetOfATNSlaveNAPNode());
        }

        public ATNSubjVerbConditionFinNode_v2(ContextOfATNParsing_v2 context, ATNSubjVerbConditionFinNode_v2 sameNode, InitATNSubjVerbConditionFinNodeAction initAction, ATNExtendedToken token)
            : base(context, token)
        {
            mSameNode = sameNode;
            mInitAction = initAction;
            ParentNode = mSameNode.ParentNode;
            SlaveNAPNode = mSameNode.SlaveNAPNode.Fork(context);
            mInitAction?.Invoke(this);
        }

        public override StateOfATNParsing_v2 GlobalState => StateOfATNParsing_v2.Subj_Verb_Condition_Fin;

        public ATNSubjVerbTransOrFinNode_v2 ParentNode { get; private set; }
        private ATNSubjVerbConditionFinNode_v2 mSameNode;
        private InitATNSubjVerbConditionFinNodeAction mInitAction;

        public ATNSlaveNAPNode SlaveNAPNode { get; set; }

        protected override void ImplementGoalToken()
        {
#if DEBUG
            LogInstance.Log($"Token = {Token}");
            LogInstance.Log($"Context = {Context}");
#endif

            SetAsSuccess(SlaveNAPNode.Run(Token);
        }

        protected override void ProcessNextToken()
        {
            var extendedTokensList = Get—lusterOfExtendedTokens();

#if DEBUG
            LogInstance.Log($"extendedTokensList.Count = {extendedTokensList.Count}");
#endif

            if (extendedTokensList.Count == 0)
            {
                Context.PutSentenceToResult();
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
                    case KindOfItemOfSentence.Number:
                        AddTask(new ATNSubjVerbConditionFinNodeFactory_v2(this, item, null));
                        break;

                    case KindOfItemOfSentence.Obj:
                        if(hasObjOrSubj)
                        {
                            break;
                        }

                        hasObjOrSubj = true;
                        AddTask(new ATNSubjVerbConditionFinNodeFactory_v2(this, item, null));
                        break;

                    case KindOfItemOfSentence.Subj:
                        if (hasObjOrSubj)
                        {
                            break;
                        }

                        hasObjOrSubj = true;
                        AddTask(new ATNSubjVerbConditionFinNodeFactory_v2(this, item, null));
                        break;

                    case KindOfItemOfSentence.Condition:
                        AddTask(new ATNSubjVerbConditionFinNodeFactory_v2(this, item, null));
                        break;

                    case KindOfItemOfSentence.Point:
                        Context.PutSentenceToResult();
                        break;

                    default:
                        throw new ArgumentOutOfRangeException(nameof(kindOfItem), kindOfItem, null);
                }
            }
        }
    }
}

