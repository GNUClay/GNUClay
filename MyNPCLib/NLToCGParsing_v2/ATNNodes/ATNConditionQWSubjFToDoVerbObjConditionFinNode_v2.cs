using MyNPCLib.NLToCGParsing;
using System;
using System.Collections.Generic;
using System.Text;

namespace MyNPCLib.NLToCGParsing_v2.ATNNodes
{
    public delegate void InitATNConditionQWSubjFToDoVerbObjConditionFinNodeAction(ATNConditionQWSubjFToDoVerbObjConditionFinNode_v2 item);

    public class ATNConditionQWSubjFToDoVerbObjConditionFinNodeFactory_v2: BaseATNNodeFactory_v2
    {
        public ATNConditionQWSubjFToDoVerbObjConditionFinNodeFactory_v2(ATNConditionQWSubjFToDoVerbObjTransOrFinNode_v2 parentNode, ATNExtendedToken token)
        {
            mNumberOfConstructor = 1;
            mParentNode = parentNode;
            mToken = token;
        }

        public ATNConditionQWSubjFToDoVerbObjConditionFinNodeFactory_v2(ATNConditionQWSubjFToDoVerbObjConditionFinNode_v2 sameNode, ATNExtendedToken token, InitATNConditionQWSubjFToDoVerbObjConditionFinNodeAction initAction)
        {
            mNumberOfConstructor = 2;
            mSameNode = sameNode;
            mToken = token;
            mInitAction = initAction;
        }

        private int mNumberOfConstructor;
        private ATNConditionQWSubjFToDoVerbObjTransOrFinNode_v2 mParentNode;
        private ATNConditionQWSubjFToDoVerbObjConditionFinNode_v2 mSameNode;
        private ATNExtendedToken mToken;
        private InitATNConditionQWSubjFToDoVerbObjConditionFinNodeAction mInitAction;

        public override BaseATNNode_v2 Create(ContextOfATNParsing_v2 context)
        {
            switch(mNumberOfConstructor)
            {
                case 1:
                    return new ATNConditionQWSubjFToDoVerbObjConditionFinNode_v2(context, mParentNode, mToken);

                case 2:
                    return new ATNConditionQWSubjFToDoVerbObjConditionFinNode_v2(context, mSameNode, mInitAction, mToken);

                default:
                    throw new ArgumentOutOfRangeException(nameof(mNumberOfConstructor), mNumberOfConstructor, null);
            }
        }
    }

    public class ATNConditionQWSubjFToDoVerbObjConditionFinNode_v2: BaseATNNode_v2
    {
        public ATNConditionQWSubjFToDoVerbObjConditionFinNode_v2(ContextOfATNParsing_v2 context, ATNConditionQWSubjFToDoVerbObjTransOrFinNode_v2 parentNode, ATNExtendedToken token)
            : base(context, token)
        {
            ParentNode = parentNode;
        }

        public ATNConditionQWSubjFToDoVerbObjConditionFinNode_v2(ContextOfATNParsing_v2 context, ATNConditionQWSubjFToDoVerbObjConditionFinNode_v2 sameNode, InitATNConditionQWSubjFToDoVerbObjConditionFinNodeAction initAction, ATNExtendedToken token)
            : base(context, token)
        {
            mSameNode = sameNode;
            mInitAction = initAction;
            ParentNode = mSameNode.ParentNode;
            mInitAction?.Invoke(this);
        }

        public override StateOfATNParsing_v2 GlobalState => StateOfATNParsing_v2.Condition_QWSubj_FToDo_Verb_Obj_Condition_Fin;

        public ATNConditionQWSubjFToDoVerbObjTransOrFinNode_v2 ParentNode { get; private set; }
        private ATNConditionQWSubjFToDoVerbObjConditionFinNode_v2 mSameNode;
        private InitATNConditionQWSubjFToDoVerbObjConditionFinNodeAction mInitAction;

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

