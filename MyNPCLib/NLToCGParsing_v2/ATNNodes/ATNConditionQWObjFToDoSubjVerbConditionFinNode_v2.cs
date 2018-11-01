using MyNPCLib.NLToCGParsing;
using System;
using System.Collections.Generic;
using System.Text;

namespace MyNPCLib.NLToCGParsing_v2.ATNNodes
{
    public delegate void InitATNConditionQWObjFToDoSubjVerbConditionFinNodeAction(ATNConditionQWObjFToDoSubjVerbConditionFinNode_v2 item);

    public class ATNConditionQWObjFToDoSubjVerbConditionFinNodeFactory_v2: BaseATNNodeFactory_v2
    {
        public ATNConditionQWObjFToDoSubjVerbConditionFinNodeFactory_v2(ATNConditionQWObjFToDoSubjVerbTransOrFinNode_v2 parentNode, ATNExtendedToken token)
        {
            mNumberOfConstructor = 1;
            mParentNode = parentNode;
            mToken = token;
        }

        public ATNConditionQWObjFToDoSubjVerbConditionFinNodeFactory_v2(ATNConditionQWObjFToDoSubjVerbConditionFinNode_v2 sameNode, ATNExtendedToken token, InitATNConditionQWObjFToDoSubjVerbConditionFinNodeAction initAction)
        {
            mNumberOfConstructor = 2;
            mSameNode = sameNode;
            mToken = token;
            mInitAction = initAction;
        }

        private int mNumberOfConstructor;
        private ATNConditionQWObjFToDoSubjVerbTransOrFinNode_v2 mParentNode;
        private ATNConditionQWObjFToDoSubjVerbConditionFinNode_v2 mSameNode;
        private ATNExtendedToken mToken;
        private InitATNConditionQWObjFToDoSubjVerbConditionFinNodeAction mInitAction;

        public override BaseATNNode_v2 Create(ContextOfATNParsing_v2 context)
        {
            switch(mNumberOfConstructor)
            {
                case 1:
                    return new ATNConditionQWObjFToDoSubjVerbConditionFinNode_v2(context, mParentNode, mToken);

                case 2:
                    return new ATNConditionQWObjFToDoSubjVerbConditionFinNode_v2(context, mSameNode, mInitAction, mToken);

                default:
                    throw new ArgumentOutOfRangeException(nameof(mNumberOfConstructor), mNumberOfConstructor, null);
            }
        }
    }

    public class ATNConditionQWObjFToDoSubjVerbConditionFinNode_v2: BaseATNNode_v2
    {
        public ATNConditionQWObjFToDoSubjVerbConditionFinNode_v2(ContextOfATNParsing_v2 context, ATNConditionQWObjFToDoSubjVerbTransOrFinNode_v2 parentNode, ATNExtendedToken token)
            : base(context, token)
        {
            ParentNode = parentNode;
        }

        public ATNConditionQWObjFToDoSubjVerbConditionFinNode_v2(ContextOfATNParsing_v2 context, ATNConditionQWObjFToDoSubjVerbConditionFinNode_v2 sameNode, InitATNConditionQWObjFToDoSubjVerbConditionFinNodeAction initAction, ATNExtendedToken token)
            : base(context, token)
        {
            mSameNode = sameNode;
            mInitAction = initAction;
            ParentNode = mSameNode.ParentNode;
            mInitAction?.Invoke(this);
        }

        public override StateOfATNParsing_v2 GlobalState => StateOfATNParsing_v2.Condition_QWObj_FToDo_Subj_Verb_Condition_Fin;

        public ATNConditionQWObjFToDoSubjVerbTransOrFinNode_v2 ParentNode { get; private set; }
        private ATNConditionQWObjFToDoSubjVerbConditionFinNode_v2 mSameNode;
        private InitATNConditionQWObjFToDoSubjVerbConditionFinNodeAction mInitAction;

        protected override void ImplementGoalToken()
        {
            throw new NotImplementedException();
        }

        protected override void ProcessNextToken()
        {
            throw new NotImplementedException();
        }
    }
}

