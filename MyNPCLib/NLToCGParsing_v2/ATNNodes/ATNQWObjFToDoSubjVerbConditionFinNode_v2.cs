using MyNPCLib.NLToCGParsing;
using System;
using System.Collections.Generic;
using System.Text;

namespace MyNPCLib.NLToCGParsing_v2.ATNNodes
{
    public delegate void InitATNQWObjFToDoSubjVerbConditionFinNodeAction(ATNQWObjFToDoSubjVerbConditionFinNode_v2 item);

    public class ATNQWObjFToDoSubjVerbConditionFinNodeFactory_v2: BaseATNNodeFactory_v2
    {
        public ATNQWObjFToDoSubjVerbConditionFinNodeFactory_v2(ATNQWObjFToDoSubjVerbTransOrFinNode_v2 parentNode, ATNExtendedToken token)
        {
            mNumberOfConstructor = 1;
            mParentNode = parentNode;
            mToken = token;
        }

        public ATNQWObjFToDoSubjVerbConditionFinNodeFactory_v2(ATNQWObjFToDoSubjVerbConditionFinNode_v2 sameNode, ATNExtendedToken token, InitATNQWObjFToDoSubjVerbConditionFinNodeAction initAction)
        {
            mNumberOfConstructor = 2;
            mSameNode = sameNode;
            mToken = token;
            mInitAction = initAction;
        }

        private int mNumberOfConstructor;
        private ATNQWObjFToDoSubjVerbTransOrFinNode_v2 mParentNode;
        private ATNQWObjFToDoSubjVerbConditionFinNode_v2 mSameNode;
        private ATNExtendedToken mToken;
        private InitATNQWObjFToDoSubjVerbConditionFinNodeAction mInitAction;

        public override BaseATNNode_v2 Create(ContextOfATNParsing_v2 context)
        {
            switch(mNumberOfConstructor)
            {
                case 1:
                    return new ATNQWObjFToDoSubjVerbConditionFinNode_v2(context, mParentNode, mToken);

                case 2:
                    return new ATNQWObjFToDoSubjVerbConditionFinNode_v2(context, mSameNode, mInitAction, mToken);

                default:
                    throw new ArgumentOutOfRangeException(nameof(mNumberOfConstructor), mNumberOfConstructor, null);
            }
        }
    }

    public class ATNQWObjFToDoSubjVerbConditionFinNode_v2: BaseATNNode_v2
    {
        public ATNQWObjFToDoSubjVerbConditionFinNode_v2(ContextOfATNParsing_v2 context, ATNQWObjFToDoSubjVerbTransOrFinNode_v2 parentNode, ATNExtendedToken token)
            : base(context, token)
        {
            ParentNode = parentNode;
        }

        public ATNQWObjFToDoSubjVerbConditionFinNode_v2(ContextOfATNParsing_v2 context, ATNQWObjFToDoSubjVerbConditionFinNode_v2 sameNode, InitATNQWObjFToDoSubjVerbConditionFinNodeAction initAction, ATNExtendedToken token)
            : base(context, token)
        {
            mSameNode = sameNode;
            mInitAction = initAction;
            ParentNode = mSameNode.ParentNode;
            mInitAction?.Invoke(this);
        }

        public override StateOfATNParsing_v2 GlobalState => StateOfATNParsing_v2.QWObj_FToDo_Subj_Verb_Condition_Fin;

        public ATNQWObjFToDoSubjVerbTransOrFinNode_v2 ParentNode { get; private set; }
        private ATNQWObjFToDoSubjVerbConditionFinNode_v2 mSameNode;
        private InitATNQWObjFToDoSubjVerbConditionFinNodeAction mInitAction;

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

