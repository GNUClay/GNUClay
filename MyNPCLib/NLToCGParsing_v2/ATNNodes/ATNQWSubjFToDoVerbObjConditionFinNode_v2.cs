using MyNPCLib.NLToCGParsing;
using System;
using System.Collections.Generic;
using System.Text;

namespace MyNPCLib.NLToCGParsing_v2.ATNNodes
{
    public delegate void InitATNQWSubjFToDoVerbObjConditionFinNodeAction(ATNQWSubjFToDoVerbObjConditionFinNode_v2 item);

    public class ATNQWSubjFToDoVerbObjConditionFinNodeFactory_v2: BaseATNNodeFactory_v2
    {
        public ATNQWSubjFToDoVerbObjConditionFinNodeFactory_v2(ATNQWSubjFToDoVerbObjTransOrFinNode_v2 parentNode, ATNExtendedToken token)
        {
            mNumberOfConstructor = 1;
            mParentNode = parentNode;
            mToken = token;
        }

        public ATNQWSubjFToDoVerbObjConditionFinNodeFactory_v2(ATNQWSubjFToDoVerbObjConditionFinNode_v2 sameNode, ATNExtendedToken token, InitATNQWSubjFToDoVerbObjConditionFinNodeAction initAction)
        {
            mNumberOfConstructor = 2;
            mSameNode = sameNode;
            mToken = token;
            mInitAction = initAction;
        }

        private int mNumberOfConstructor;
        private ATNQWSubjFToDoVerbObjTransOrFinNode_v2 mParentNode;
        private ATNQWSubjFToDoVerbObjConditionFinNode_v2 mSameNode;
        private ATNExtendedToken mToken;
        private InitATNQWSubjFToDoVerbObjConditionFinNodeAction mInitAction;

        public override BaseATNNode_v2 Create(ContextOfATNParsing_v2 context)
        {
            switch(mNumberOfConstructor)
            {
                case 1:
                    return new ATNQWSubjFToDoVerbObjConditionFinNode_v2(context, mParentNode, mToken);

                case 2:
                    return new ATNQWSubjFToDoVerbObjConditionFinNode_v2(context, mSameNode, mInitAction, mToken);

                default:
                    throw new ArgumentOutOfRangeException(nameof(mNumberOfConstructor), mNumberOfConstructor, null);
            }
        }
    }

    public class ATNQWSubjFToDoVerbObjConditionFinNode_v2: BaseATNNode_v2
    {
        public ATNQWSubjFToDoVerbObjConditionFinNode_v2(ContextOfATNParsing_v2 context, ATNQWSubjFToDoVerbObjTransOrFinNode_v2 parentNode, ATNExtendedToken token)
            : base(context, token)
        {
            ParentNode = parentNode;
        }

        public ATNQWSubjFToDoVerbObjConditionFinNode_v2(ContextOfATNParsing_v2 context, ATNQWSubjFToDoVerbObjConditionFinNode_v2 sameNode, InitATNQWSubjFToDoVerbObjConditionFinNodeAction initAction, ATNExtendedToken token)
            : base(context, token)
        {
            mSameNode = sameNode;
            mInitAction = initAction;
            ParentNode = mSameNode.ParentNode;
            mInitAction?.Invoke(this);
        }

        public override StateOfATNParsing_v2 GlobalState => StateOfATNParsing_v2.QWSubj_FToDo_Verb_Obj_Condition_Fin;

        public ATNQWSubjFToDoVerbObjTransOrFinNode_v2 ParentNode { get; private set; }
        private ATNQWSubjFToDoVerbObjConditionFinNode_v2 mSameNode;
        private InitATNQWSubjFToDoVerbObjConditionFinNodeAction mInitAction;

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

