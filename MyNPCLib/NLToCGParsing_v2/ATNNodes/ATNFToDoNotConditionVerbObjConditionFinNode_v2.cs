using MyNPCLib.NLToCGParsing;
using System;
using System.Collections.Generic;
using System.Text;

namespace MyNPCLib.NLToCGParsing_v2.ATNNodes
{
    public delegate void InitATNFToDoNotConditionVerbObjConditionFinNodeAction(ATNFToDoNotConditionVerbObjConditionFinNode_v2 item);

    public class ATNFToDoNotConditionVerbObjConditionFinNodeFactory_v2: BaseATNNodeFactory_v2
    {
        public ATNFToDoNotConditionVerbObjConditionFinNodeFactory_v2(ATNFToDoNotConditionVerbObjTransOrFinNode_v2 parentNode, ATNExtendedToken token)
        {
            mNumberOfConstructor = 1;
            mParentNode = parentNode;
            mToken = token;
        }

        public ATNFToDoNotConditionVerbObjConditionFinNodeFactory_v2(ATNFToDoNotConditionVerbObjConditionFinNode_v2 sameNode, ATNExtendedToken token, InitATNFToDoNotConditionVerbObjConditionFinNodeAction initAction)
        {
            mNumberOfConstructor = 2;
            mSameNode = sameNode;
            mToken = token;
            mInitAction = initAction;
        }

        private int mNumberOfConstructor;
        private ATNFToDoNotConditionVerbObjTransOrFinNode_v2 mParentNode;
        private ATNFToDoNotConditionVerbObjConditionFinNode_v2 mSameNode;
        private ATNExtendedToken mToken;
        private InitATNFToDoNotConditionVerbObjConditionFinNodeAction mInitAction;

        public override BaseATNNode_v2 Create(ContextOfATNParsing_v2 context)
        {
            switch(mNumberOfConstructor)
            {
                case 1:
                    return new ATNFToDoNotConditionVerbObjConditionFinNode_v2(context, mParentNode, mToken);

                case 2:
                    return new ATNFToDoNotConditionVerbObjConditionFinNode_v2(context, mSameNode, mInitAction, mToken);

                default:
                    throw new ArgumentOutOfRangeException(nameof(mNumberOfConstructor), mNumberOfConstructor, null);
            }
        }
    }

    public class ATNFToDoNotConditionVerbObjConditionFinNode_v2: BaseATNNode_v2
    {
        public ATNFToDoNotConditionVerbObjConditionFinNode_v2(ContextOfATNParsing_v2 context, ATNFToDoNotConditionVerbObjTransOrFinNode_v2 parentNode, ATNExtendedToken token)
            : base(context, token)
        {
            ParentNode = parentNode;
        }

        public ATNFToDoNotConditionVerbObjConditionFinNode_v2(ContextOfATNParsing_v2 context, ATNFToDoNotConditionVerbObjConditionFinNode_v2 sameNode, InitATNFToDoNotConditionVerbObjConditionFinNodeAction initAction, ATNExtendedToken token)
            : base(context, token)
        {
            mSameNode = sameNode;
            mInitAction = initAction;
            ParentNode = mSameNode.ParentNode;
            mInitAction?.Invoke(this);
        }

        public override StateOfATNParsing_v2 GlobalState => StateOfATNParsing_v2.FToDo_Not_Condition_Verb_Obj_Condition_Fin;

        public ATNFToDoNotConditionVerbObjTransOrFinNode_v2 ParentNode { get; private set; }
        private ATNFToDoNotConditionVerbObjConditionFinNode_v2 mSameNode;
        private InitATNFToDoNotConditionVerbObjConditionFinNodeAction mInitAction;

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

