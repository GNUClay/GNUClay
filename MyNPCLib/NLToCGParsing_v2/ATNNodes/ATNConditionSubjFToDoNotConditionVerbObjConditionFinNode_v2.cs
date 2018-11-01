using MyNPCLib.NLToCGParsing;
using System;
using System.Collections.Generic;
using System.Text;

namespace MyNPCLib.NLToCGParsing_v2.ATNNodes
{
    public delegate void InitATNConditionSubjFToDoNotConditionVerbObjConditionFinNodeAction(ATNConditionSubjFToDoNotConditionVerbObjConditionFinNode_v2 item);

    public class ATNConditionSubjFToDoNotConditionVerbObjConditionFinNodeFactory_v2: BaseATNNodeFactory_v2
    {
        public ATNConditionSubjFToDoNotConditionVerbObjConditionFinNodeFactory_v2(ATNConditionSubjFToDoNotConditionVerbObjTransOrFinNode_v2 parentNode, ATNExtendedToken token)
        {
            mNumberOfConstructor = 1;
            mParentNode = parentNode;
            mToken = token;
        }

        public ATNConditionSubjFToDoNotConditionVerbObjConditionFinNodeFactory_v2(ATNConditionSubjFToDoNotConditionVerbObjConditionFinNode_v2 sameNode, ATNExtendedToken token, InitATNConditionSubjFToDoNotConditionVerbObjConditionFinNodeAction initAction)
        {
            mNumberOfConstructor = 2;
            mSameNode = sameNode;
            mToken = token;
            mInitAction = initAction;
        }

        private int mNumberOfConstructor;
        private ATNConditionSubjFToDoNotConditionVerbObjTransOrFinNode_v2 mParentNode;
        private ATNConditionSubjFToDoNotConditionVerbObjConditionFinNode_v2 mSameNode;
        private ATNExtendedToken mToken;
        private InitATNConditionSubjFToDoNotConditionVerbObjConditionFinNodeAction mInitAction;

        public override BaseATNNode_v2 Create(ContextOfATNParsing_v2 context)
        {
            switch(mNumberOfConstructor)
            {
                case 1:
                    return new ATNConditionSubjFToDoNotConditionVerbObjConditionFinNode_v2(context, mParentNode, mToken);

                case 2:
                    return new ATNConditionSubjFToDoNotConditionVerbObjConditionFinNode_v2(context, mSameNode, mInitAction, mToken);

                default:
                    throw new ArgumentOutOfRangeException(nameof(mNumberOfConstructor), mNumberOfConstructor, null);
            }
        }
    }

    public class ATNConditionSubjFToDoNotConditionVerbObjConditionFinNode_v2: BaseATNNode_v2
    {
        public ATNConditionSubjFToDoNotConditionVerbObjConditionFinNode_v2(ContextOfATNParsing_v2 context, ATNConditionSubjFToDoNotConditionVerbObjTransOrFinNode_v2 parentNode, ATNExtendedToken token)
            : base(context, token)
        {
            ParentNode = parentNode;
        }

        public ATNConditionSubjFToDoNotConditionVerbObjConditionFinNode_v2(ContextOfATNParsing_v2 context, ATNConditionSubjFToDoNotConditionVerbObjConditionFinNode_v2 sameNode, InitATNConditionSubjFToDoNotConditionVerbObjConditionFinNodeAction initAction, ATNExtendedToken token)
            : base(context, token)
        {
            mSameNode = sameNode;
            mInitAction = initAction;
            ParentNode = mSameNode.ParentNode;
            mInitAction?.Invoke(this);
        }

        public override StateOfATNParsing_v2 GlobalState => StateOfATNParsing_v2.Condition_Subj_FToDo_Not_Condition_Verb_Obj_Condition_Fin;

        public ATNConditionSubjFToDoNotConditionVerbObjTransOrFinNode_v2 ParentNode { get; private set; }
        private ATNConditionSubjFToDoNotConditionVerbObjConditionFinNode_v2 mSameNode;
        private InitATNConditionSubjFToDoNotConditionVerbObjConditionFinNodeAction mInitAction;

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

