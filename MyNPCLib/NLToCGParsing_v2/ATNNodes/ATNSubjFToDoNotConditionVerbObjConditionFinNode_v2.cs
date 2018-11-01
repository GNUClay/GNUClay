using MyNPCLib.NLToCGParsing;
using System;
using System.Collections.Generic;
using System.Text;

namespace MyNPCLib.NLToCGParsing_v2.ATNNodes
{
    public delegate void InitATNSubjFToDoNotConditionVerbObjConditionFinNodeAction(ATNSubjFToDoNotConditionVerbObjConditionFinNode_v2 item);

    public class ATNSubjFToDoNotConditionVerbObjConditionFinNodeFactory_v2: BaseATNNodeFactory_v2
    {
        public ATNSubjFToDoNotConditionVerbObjConditionFinNodeFactory_v2(ATNSubjFToDoNotConditionVerbObjTransOrFinNode_v2 parentNode, ATNExtendedToken token)
        {
            mNumberOfConstructor = 1;
            mParentNode = parentNode;
            mToken = token;
        }

        public ATNSubjFToDoNotConditionVerbObjConditionFinNodeFactory_v2(ATNSubjFToDoNotConditionVerbObjConditionFinNode_v2 sameNode, ATNExtendedToken token, InitATNSubjFToDoNotConditionVerbObjConditionFinNodeAction initAction)
        {
            mNumberOfConstructor = 2;
            mSameNode = sameNode;
            mToken = token;
            mInitAction = initAction;
        }

        private int mNumberOfConstructor;
        private ATNSubjFToDoNotConditionVerbObjTransOrFinNode_v2 mParentNode;
        private ATNSubjFToDoNotConditionVerbObjConditionFinNode_v2 mSameNode;
        private ATNExtendedToken mToken;
        private InitATNSubjFToDoNotConditionVerbObjConditionFinNodeAction mInitAction;

        public override BaseATNNode_v2 Create(ContextOfATNParsing_v2 context)
        {
            switch(mNumberOfConstructor)
            {
                case 1:
                    return new ATNSubjFToDoNotConditionVerbObjConditionFinNode_v2(context, mParentNode, mToken);

                case 2:
                    return new ATNSubjFToDoNotConditionVerbObjConditionFinNode_v2(context, mSameNode, mInitAction, mToken);

                default:
                    throw new ArgumentOutOfRangeException(nameof(mNumberOfConstructor), mNumberOfConstructor, null);
            }
        }
    }

    public class ATNSubjFToDoNotConditionVerbObjConditionFinNode_v2: BaseATNNode_v2
    {
        public ATNSubjFToDoNotConditionVerbObjConditionFinNode_v2(ContextOfATNParsing_v2 context, ATNSubjFToDoNotConditionVerbObjTransOrFinNode_v2 parentNode, ATNExtendedToken token)
            : base(context, token)
        {
            ParentNode = parentNode;
        }

        public ATNSubjFToDoNotConditionVerbObjConditionFinNode_v2(ContextOfATNParsing_v2 context, ATNSubjFToDoNotConditionVerbObjConditionFinNode_v2 sameNode, InitATNSubjFToDoNotConditionVerbObjConditionFinNodeAction initAction, ATNExtendedToken token)
            : base(context, token)
        {
            mSameNode = sameNode;
            mInitAction = initAction;
            ParentNode = mSameNode.ParentNode;
            mInitAction?.Invoke(this);
        }

        public override StateOfATNParsing_v2 GlobalState => StateOfATNParsing_v2.Subj_FToDo_Not_Condition_Verb_Obj_Condition_Fin;

        public ATNSubjFToDoNotConditionVerbObjTransOrFinNode_v2 ParentNode { get; private set; }
        private ATNSubjFToDoNotConditionVerbObjConditionFinNode_v2 mSameNode;
        private InitATNSubjFToDoNotConditionVerbObjConditionFinNodeAction mInitAction;

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

