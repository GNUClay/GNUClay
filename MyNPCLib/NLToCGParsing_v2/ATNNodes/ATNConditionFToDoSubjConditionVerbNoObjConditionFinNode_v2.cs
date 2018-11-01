using MyNPCLib.NLToCGParsing;
using System;
using System.Collections.Generic;
using System.Text;

namespace MyNPCLib.NLToCGParsing_v2.ATNNodes
{
    public delegate void InitATNConditionFToDoSubjConditionVerbNoObjConditionFinNodeAction(ATNConditionFToDoSubjConditionVerbNoObjConditionFinNode_v2 item);

    public class ATNConditionFToDoSubjConditionVerbNoObjConditionFinNodeFactory_v2: BaseATNNodeFactory_v2
    {
        public ATNConditionFToDoSubjConditionVerbNoObjConditionFinNodeFactory_v2(ATNConditionFToDoSubjConditionVerbNoObjTransOrFinNode_v2 parentNode, ATNExtendedToken token)
        {
            mNumberOfConstructor = 1;
            mParentNode = parentNode;
            mToken = token;
        }

        public ATNConditionFToDoSubjConditionVerbNoObjConditionFinNodeFactory_v2(ATNConditionFToDoSubjConditionVerbNoObjConditionFinNode_v2 sameNode, ATNExtendedToken token, InitATNConditionFToDoSubjConditionVerbNoObjConditionFinNodeAction initAction)
        {
            mNumberOfConstructor = 2;
            mSameNode = sameNode;
            mToken = token;
            mInitAction = initAction;
        }

        private int mNumberOfConstructor;
        private ATNConditionFToDoSubjConditionVerbNoObjTransOrFinNode_v2 mParentNode;
        private ATNConditionFToDoSubjConditionVerbNoObjConditionFinNode_v2 mSameNode;
        private ATNExtendedToken mToken;
        private InitATNConditionFToDoSubjConditionVerbNoObjConditionFinNodeAction mInitAction;

        public override BaseATNNode_v2 Create(ContextOfATNParsing_v2 context)
        {
            switch(mNumberOfConstructor)
            {
                case 1:
                    return new ATNConditionFToDoSubjConditionVerbNoObjConditionFinNode_v2(context, mParentNode, mToken);

                case 2:
                    return new ATNConditionFToDoSubjConditionVerbNoObjConditionFinNode_v2(context, mSameNode, mInitAction, mToken);

                default:
                    throw new ArgumentOutOfRangeException(nameof(mNumberOfConstructor), mNumberOfConstructor, null);
            }
        }
    }

    public class ATNConditionFToDoSubjConditionVerbNoObjConditionFinNode_v2: BaseATNNode_v2
    {
        public ATNConditionFToDoSubjConditionVerbNoObjConditionFinNode_v2(ContextOfATNParsing_v2 context, ATNConditionFToDoSubjConditionVerbNoObjTransOrFinNode_v2 parentNode, ATNExtendedToken token)
            : base(context, token)
        {
            ParentNode = parentNode;
        }

        public ATNConditionFToDoSubjConditionVerbNoObjConditionFinNode_v2(ContextOfATNParsing_v2 context, ATNConditionFToDoSubjConditionVerbNoObjConditionFinNode_v2 sameNode, InitATNConditionFToDoSubjConditionVerbNoObjConditionFinNodeAction initAction, ATNExtendedToken token)
            : base(context, token)
        {
            mSameNode = sameNode;
            mInitAction = initAction;
            ParentNode = mSameNode.ParentNode;
            mInitAction?.Invoke(this);
        }

        public override StateOfATNParsing_v2 GlobalState => StateOfATNParsing_v2.Condition_FToDo_Subj_Condition_Verb_No_Obj_Condition_Fin;

        public ATNConditionFToDoSubjConditionVerbNoObjTransOrFinNode_v2 ParentNode { get; private set; }
        private ATNConditionFToDoSubjConditionVerbNoObjConditionFinNode_v2 mSameNode;
        private InitATNConditionFToDoSubjConditionVerbNoObjConditionFinNodeAction mInitAction;

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

