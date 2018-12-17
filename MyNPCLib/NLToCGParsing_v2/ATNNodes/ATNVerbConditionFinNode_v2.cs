using MyNPCLib.NLToCGParsing;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace MyNPCLib.NLToCGParsing_v2.ATNNodes
{
    public delegate void InitATNVerbConditionFinNodeAction(ATNVerbConditionFinNode_v2 item);

    public class ATNVerbConditionFinNodeFactory_v2: BaseATNNodeFactory_v2
    {
        public ATNVerbConditionFinNodeFactory_v2(ATNVerbTransOrFinNode_v2 parentNode, ATNExtendedToken token)
        {
            mNumberOfConstructor = 1;
            mParentNode = parentNode;
            mToken = token;
        }

        public ATNVerbConditionFinNodeFactory_v2(ATNVerbConditionFinNode_v2 sameNode, ATNExtendedToken token, InitATNVerbConditionFinNodeAction initAction)
        {
            mNumberOfConstructor = 2;
            mSameNode = sameNode;
            mToken = token;
            mInitAction = initAction;
        }

        private int mNumberOfConstructor;
        private ATNVerbTransOrFinNode_v2 mParentNode;
        private ATNVerbConditionFinNode_v2 mSameNode;
        private ATNExtendedToken mToken;
        private InitATNVerbConditionFinNodeAction mInitAction;

        public override BaseATNNode_v2 Create(ContextOfATNParsing_v2 context)
        {
            switch(mNumberOfConstructor)
            {
                case 1:
                    return new ATNVerbConditionFinNode_v2(context, mParentNode, mToken);

                case 2:
                    return new ATNVerbConditionFinNode_v2(context, mSameNode, mInitAction, mToken);

                default:
                    throw new ArgumentOutOfRangeException(nameof(mNumberOfConstructor), mNumberOfConstructor, null);
            }
        }
    }

    public class ATNVerbConditionFinNode_v2: BaseATNNode_v2
    {
        public ATNVerbConditionFinNode_v2(ContextOfATNParsing_v2 context, ATNVerbTransOrFinNode_v2 parentNode, ATNExtendedToken token)
            : base(context, token)
        {
            ParentNode = parentNode;
            SlaveNAPNode = new ATNSlaveNAPNode(context, new PrepositionalTargetOfCurrentVerbOfATNSlaveNAPNode(parentNode.VerbPhrase));
            RegATNSlaveNAPNode(SlaveNAPNode);
        }

        public ATNVerbConditionFinNode_v2(ContextOfATNParsing_v2 context, ATNVerbConditionFinNode_v2 sameNode, InitATNVerbConditionFinNodeAction initAction, ATNExtendedToken token)
            : base(context, token)
        {
            mSameNode = sameNode;
            mInitAction = initAction;
            ParentNode = mSameNode.ParentNode;
            SlaveNAPNode = mSameNode.SlaveNAPNode.Fork(context);
            RegATNSlaveNAPNode(SlaveNAPNode);
            mInitAction?.Invoke(this);
        }

        public override StateOfATNParsing_v2 GlobalState => StateOfATNParsing_v2.Verb_Condition_Fin;

        public ATNVerbTransOrFinNode_v2 ParentNode { get; private set; }
        private ATNVerbConditionFinNode_v2 mSameNode;
        private InitATNVerbConditionFinNodeAction mInitAction;

        public ATNSlaveNAPNode SlaveNAPNode { get; set; }
        public CommaInstructionsOfATNSlaveNAPNode CommaInstruction { get; set; } = CommaInstructionsOfATNSlaveNAPNode.None;

        protected override void ImplementGoalToken()
        {
#if DEBUG
            //LogInstance.Log($"Token = {Token}");
            //LogInstance.Log($"Context = {Context}");
            //LogInstance.Log($"CommaInstruction = {CommaInstruction}");
#endif

            SetAsSuccess(SlaveNAPNode.Run(Token, CommaInstruction));
        }

        protected override void ProcessNextToken()
        {
            var extendedTokensList = GetÑlusterOfExtendedTokens();

#if DEBUG
            //LogInstance.Log($"Context = {Context}");
            //LogInstance.Log($"extendedTokensList.Count = {extendedTokensList.Count}");
#endif

            if (extendedTokensList.Count == 0)
            {
                Context.PutSentenceToResult();
                return;
            }

            //var hasObjOrSubj = false;
            //var hasObjOrSubj = false;

            foreach (var item in extendedTokensList)
            {
#if DEBUG
                //LogInstance.Log($"item = {item}");
#endif

                var kindOfItem = item.KindOfItem;

                switch(kindOfItem)
                {
                    case KindOfItemOfSentence.Subj:
                        //if (hasObjOrSubj)
                        //{
                        //    break;
                        //}
                        //hasObjOrSubj = true;
                        AddTask(new ATNVerbConditionFinNodeFactory_v2(this, item, null));
                        break;

                    case KindOfItemOfSentence.Obj:
                        //if (hasObjOrSubj)
                        //{
                        //    break;
                        //}
                        //hasObjOrSubj = true;
                        AddTask(new ATNVerbConditionFinNodeFactory_v2(this, item, null));
                        break;

                    case KindOfItemOfSentence.Verb:
                        if(extendedTokensList.Any(p => p.KindOfItem == KindOfItemOfSentence.Subj || p.KindOfItem == KindOfItemOfSentence.Obj))
                        {
                            break;
                        }
                        throw new NotImplementedException();
                        
                    default:
                        throw new ArgumentOutOfRangeException(nameof(kindOfItem), kindOfItem, null);
                }
            }
        }
    }
}

