using MyNPCLib.NLToCGParsing;
using System;
using System.Collections.Generic;
using System.Text;

namespace MyNPCLib.NLToCGParsing_v2.ATNNodes
{
    public delegate void InitATNQWObjFToDoSubjConditionVerbConditionFinNodeAction(ATNQWObjFToDoSubjConditionVerbConditionFinNode_v2 item);

    public class ATNQWObjFToDoSubjConditionVerbConditionFinNodeFactory_v2: BaseATNNodeFactory_v2
    {
        public ATNQWObjFToDoSubjConditionVerbConditionFinNodeFactory_v2(ATNQWObjFToDoSubjConditionVerbTransOrFinNode_v2 parentNode, ATNExtendedToken token)
        {
            mNumberOfConstructor = 1;
            mParentNode = parentNode;
            mToken = token;
        }

        public ATNQWObjFToDoSubjConditionVerbConditionFinNodeFactory_v2(ATNQWObjFToDoSubjConditionVerbConditionFinNode_v2 sameNode, ATNExtendedToken token, InitATNQWObjFToDoSubjConditionVerbConditionFinNodeAction initAction)
        {
            mNumberOfConstructor = 2;
            mSameNode = sameNode;
            mToken = token;
            mInitAction = initAction;
        }

        private int mNumberOfConstructor;
        private ATNQWObjFToDoSubjConditionVerbTransOrFinNode_v2 mParentNode;
        private ATNQWObjFToDoSubjConditionVerbConditionFinNode_v2 mSameNode;
        private ATNExtendedToken mToken;
        private InitATNQWObjFToDoSubjConditionVerbConditionFinNodeAction mInitAction;

        public override BaseATNNode_v2 Create(ContextOfATNParsing_v2 context)
        {
            switch(mNumberOfConstructor)
            {
                case 1:
                    return new ATNQWObjFToDoSubjConditionVerbConditionFinNode_v2(context, mParentNode, mToken);

                case 2:
                    return new ATNQWObjFToDoSubjConditionVerbConditionFinNode_v2(context, mSameNode, mInitAction, mToken);

                default:
                    throw new ArgumentOutOfRangeException(nameof(mNumberOfConstructor), mNumberOfConstructor, null);
            }
        }
    }

    public class ATNQWObjFToDoSubjConditionVerbConditionFinNode_v2: BaseATNNode_v2
    {
        public ATNQWObjFToDoSubjConditionVerbConditionFinNode_v2(ContextOfATNParsing_v2 context, ATNQWObjFToDoSubjConditionVerbTransOrFinNode_v2 parentNode, ATNExtendedToken token)
            : base(context, token)
        {
            ParentNode = parentNode;
        }

        public ATNQWObjFToDoSubjConditionVerbConditionFinNode_v2(ContextOfATNParsing_v2 context, ATNQWObjFToDoSubjConditionVerbConditionFinNode_v2 sameNode, InitATNQWObjFToDoSubjConditionVerbConditionFinNodeAction initAction, ATNExtendedToken token)
            : base(context, token)
        {
            mSameNode = sameNode;
            mInitAction = initAction;
            ParentNode = mSameNode.ParentNode;
            mInitAction?.Invoke(this);
        }

        public override StateOfATNParsing_v2 GlobalState => StateOfATNParsing_v2.QWObj_FToDo_Subj_Condition_Verb_Condition_Fin;

        public ATNQWObjFToDoSubjConditionVerbTransOrFinNode_v2 ParentNode { get; private set; }
        private ATNQWObjFToDoSubjConditionVerbConditionFinNode_v2 mSameNode;
        private InitATNQWObjFToDoSubjConditionVerbConditionFinNodeAction mInitAction;

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

