using MyNPCLib.NLToCGParsing;
using System;
using System.Collections.Generic;
using System.Text;

namespace MyNPCLib.NLToCGParsing_v2.ATNNodes
{
    public delegate void InitATNConditionFToDoNotConditionVerbObjConditionFinNodeAction(ATNConditionFToDoNotConditionVerbObjConditionFinNode_v2 item);

    public class ATNConditionFToDoNotConditionVerbObjConditionFinNodeFactory_v2: BaseATNNodeFactory_v2
    {
        public ATNConditionFToDoNotConditionVerbObjConditionFinNodeFactory_v2(ATNConditionFToDoNotConditionVerbObjTransOrFinNode_v2 parentNode, ATNExtendedToken token)
        {
            mNumberOfConstructor = 1;
            mParentNode = parentNode;
            mToken = token;
        }

        public ATNConditionFToDoNotConditionVerbObjConditionFinNodeFactory_v2(ATNConditionFToDoNotConditionVerbObjConditionFinNode_v2 sameNode, ATNExtendedToken token, InitATNConditionFToDoNotConditionVerbObjConditionFinNodeAction initAction)
        {
            mNumberOfConstructor = 2;
            mSameNode = sameNode;
            mToken = token;
            mInitAction = initAction;
        }

        private int mNumberOfConstructor;
        private ATNConditionFToDoNotConditionVerbObjTransOrFinNode_v2 mParentNode;
        private ATNConditionFToDoNotConditionVerbObjConditionFinNode_v2 mSameNode;
        private ATNExtendedToken mToken;
        private InitATNConditionFToDoNotConditionVerbObjConditionFinNodeAction mInitAction;

        public override BaseATNNode_v2 Create(ContextOfATNParsing_v2 context)
        {
            switch(mNumberOfConstructor)
            {
                case 1:
                    return new ATNConditionFToDoNotConditionVerbObjConditionFinNode_v2(context, mParentNode, mToken);

                case 2:
                    return new ATNConditionFToDoNotConditionVerbObjConditionFinNode_v2(context, mSameNode, mInitAction, mToken);

                default:
                    throw new ArgumentOutOfRangeException(nameof(mNumberOfConstructor), mNumberOfConstructor, null);
            }
        }
    }

    public class ATNConditionFToDoNotConditionVerbObjConditionFinNode_v2: BaseATNNode_v2
    {
        public ATNConditionFToDoNotConditionVerbObjConditionFinNode_v2(ContextOfATNParsing_v2 context, ATNConditionFToDoNotConditionVerbObjTransOrFinNode_v2 parentNode, ATNExtendedToken token)
            : base(context, token)
        {
            ParentNode = parentNode;
        }

        public ATNConditionFToDoNotConditionVerbObjConditionFinNode_v2(ContextOfATNParsing_v2 context, ATNConditionFToDoNotConditionVerbObjConditionFinNode_v2 sameNode, InitATNConditionFToDoNotConditionVerbObjConditionFinNodeAction initAction, ATNExtendedToken token)
            : base(context, token)
        {
            mSameNode = sameNode;
            mInitAction = initAction;
            ParentNode = mSameNode.ParentNode;
            mInitAction?.Invoke(this);
        }

        public override StateOfATNParsing_v2 GlobalState => StateOfATNParsing_v2.Condition_FToDo_Not_Condition_Verb_Obj_Condition_Fin;

        public ATNConditionFToDoNotConditionVerbObjTransOrFinNode_v2 ParentNode { get; private set; }
        private ATNConditionFToDoNotConditionVerbObjConditionFinNode_v2 mSameNode;
        private InitATNConditionFToDoNotConditionVerbObjConditionFinNodeAction mInitAction;

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

