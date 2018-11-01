using MyNPCLib.NLToCGParsing;
using System;
using System.Collections.Generic;
using System.Text;

namespace MyNPCLib.NLToCGParsing_v2.ATNNodes
{
    public delegate void InitATNQWSubjFToDoConditionVerbNoObjConditionFinNodeAction(ATNQWSubjFToDoConditionVerbNoObjConditionFinNode_v2 item);

    public class ATNQWSubjFToDoConditionVerbNoObjConditionFinNodeFactory_v2: BaseATNNodeFactory_v2
    {
        public ATNQWSubjFToDoConditionVerbNoObjConditionFinNodeFactory_v2(ATNQWSubjFToDoConditionVerbNoObjTransOrFinNode_v2 parentNode, ATNExtendedToken token)
        {
            mNumberOfConstructor = 1;
            mParentNode = parentNode;
            mToken = token;
        }

        public ATNQWSubjFToDoConditionVerbNoObjConditionFinNodeFactory_v2(ATNQWSubjFToDoConditionVerbNoObjConditionFinNode_v2 sameNode, ATNExtendedToken token, InitATNQWSubjFToDoConditionVerbNoObjConditionFinNodeAction initAction)
        {
            mNumberOfConstructor = 2;
            mSameNode = sameNode;
            mToken = token;
            mInitAction = initAction;
        }

        private int mNumberOfConstructor;
        private ATNQWSubjFToDoConditionVerbNoObjTransOrFinNode_v2 mParentNode;
        private ATNQWSubjFToDoConditionVerbNoObjConditionFinNode_v2 mSameNode;
        private ATNExtendedToken mToken;
        private InitATNQWSubjFToDoConditionVerbNoObjConditionFinNodeAction mInitAction;

        public override BaseATNNode_v2 Create(ContextOfATNParsing_v2 context)
        {
            switch(mNumberOfConstructor)
            {
                case 1:
                    return new ATNQWSubjFToDoConditionVerbNoObjConditionFinNode_v2(context, mParentNode, mToken);

                case 2:
                    return new ATNQWSubjFToDoConditionVerbNoObjConditionFinNode_v2(context, mSameNode, mInitAction, mToken);

                default:
                    throw new ArgumentOutOfRangeException(nameof(mNumberOfConstructor), mNumberOfConstructor, null);
            }
        }
    }

    public class ATNQWSubjFToDoConditionVerbNoObjConditionFinNode_v2: BaseATNNode_v2
    {
        public ATNQWSubjFToDoConditionVerbNoObjConditionFinNode_v2(ContextOfATNParsing_v2 context, ATNQWSubjFToDoConditionVerbNoObjTransOrFinNode_v2 parentNode, ATNExtendedToken token)
            : base(context, token)
        {
            ParentNode = parentNode;
        }

        public ATNQWSubjFToDoConditionVerbNoObjConditionFinNode_v2(ContextOfATNParsing_v2 context, ATNQWSubjFToDoConditionVerbNoObjConditionFinNode_v2 sameNode, InitATNQWSubjFToDoConditionVerbNoObjConditionFinNodeAction initAction, ATNExtendedToken token)
            : base(context, token)
        {
            mSameNode = sameNode;
            mInitAction = initAction;
            ParentNode = mSameNode.ParentNode;
            mInitAction?.Invoke(this);
        }

        public override StateOfATNParsing_v2 GlobalState => StateOfATNParsing_v2.QWSubj_FToDo_Condition_Verb_No_Obj_Condition_Fin;

        public ATNQWSubjFToDoConditionVerbNoObjTransOrFinNode_v2 ParentNode { get; private set; }
        private ATNQWSubjFToDoConditionVerbNoObjConditionFinNode_v2 mSameNode;
        private InitATNQWSubjFToDoConditionVerbNoObjConditionFinNodeAction mInitAction;

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

