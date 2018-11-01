using MyNPCLib.NLToCGParsing;
using System;
using System.Collections.Generic;
using System.Text;

namespace MyNPCLib.NLToCGParsing_v2.ATNNodes
{
    public delegate void InitATNFToDoSubjConditionVerbObjConditionFinNodeAction(ATNFToDoSubjConditionVerbObjConditionFinNode_v2 item);

    public class ATNFToDoSubjConditionVerbObjConditionFinNodeFactory_v2: BaseATNNodeFactory_v2
    {
        public ATNFToDoSubjConditionVerbObjConditionFinNodeFactory_v2(ATNFToDoSubjConditionVerbObjTransOrFinNode_v2 parentNode, ATNExtendedToken token)
        {
            mNumberOfConstructor = 1;
            mParentNode = parentNode;
            mToken = token;
        }

        public ATNFToDoSubjConditionVerbObjConditionFinNodeFactory_v2(ATNFToDoSubjConditionVerbObjConditionFinNode_v2 sameNode, ATNExtendedToken token, InitATNFToDoSubjConditionVerbObjConditionFinNodeAction initAction)
        {
            mNumberOfConstructor = 2;
            mSameNode = sameNode;
            mToken = token;
            mInitAction = initAction;
        }

        private int mNumberOfConstructor;
        private ATNFToDoSubjConditionVerbObjTransOrFinNode_v2 mParentNode;
        private ATNFToDoSubjConditionVerbObjConditionFinNode_v2 mSameNode;
        private ATNExtendedToken mToken;
        private InitATNFToDoSubjConditionVerbObjConditionFinNodeAction mInitAction;

        public override BaseATNNode_v2 Create(ContextOfATNParsing_v2 context)
        {
            switch(mNumberOfConstructor)
            {
                case 1:
                    return new ATNFToDoSubjConditionVerbObjConditionFinNode_v2(context, mParentNode, mToken);

                case 2:
                    return new ATNFToDoSubjConditionVerbObjConditionFinNode_v2(context, mSameNode, mInitAction, mToken);

                default:
                    throw new ArgumentOutOfRangeException(nameof(mNumberOfConstructor), mNumberOfConstructor, null);
            }
        }
    }

    public class ATNFToDoSubjConditionVerbObjConditionFinNode_v2: BaseATNNode_v2
    {
        public ATNFToDoSubjConditionVerbObjConditionFinNode_v2(ContextOfATNParsing_v2 context, ATNFToDoSubjConditionVerbObjTransOrFinNode_v2 parentNode, ATNExtendedToken token)
            : base(context, token)
        {
            ParentNode = parentNode;
        }

        public ATNFToDoSubjConditionVerbObjConditionFinNode_v2(ContextOfATNParsing_v2 context, ATNFToDoSubjConditionVerbObjConditionFinNode_v2 sameNode, InitATNFToDoSubjConditionVerbObjConditionFinNodeAction initAction, ATNExtendedToken token)
            : base(context, token)
        {
            mSameNode = sameNode;
            mInitAction = initAction;
            ParentNode = mSameNode.ParentNode;
            mInitAction?.Invoke(this);
        }

        public override StateOfATNParsing_v2 GlobalState => StateOfATNParsing_v2.FToDo_Subj_Condition_Verb_Obj_Condition_Fin;

        public ATNFToDoSubjConditionVerbObjTransOrFinNode_v2 ParentNode { get; private set; }
        private ATNFToDoSubjConditionVerbObjConditionFinNode_v2 mSameNode;
        private InitATNFToDoSubjConditionVerbObjConditionFinNodeAction mInitAction;

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

