using MyNPCLib.NLToCGParsing;
using System;
using System.Collections.Generic;
using System.Text;

namespace MyNPCLib.NLToCGParsing_v2.ATNNodes
{
    public delegate void InitATNFToDoNotConditionVerbTransOrFinNodeAction(ATNFToDoNotConditionVerbTransOrFinNode_v2 item);

    public class ATNFToDoNotConditionVerbTransOrFinNodeFactory_v2: BaseATNNodeFactory_v2
    {
        public ATNFToDoNotConditionVerbTransOrFinNodeFactory_v2(ATNFToDoNotConditionTransNode_v2 parentNode, ATNExtendedToken token)
        {
            mNumberOfConstructor = 1;
            mParentNode = parentNode;
            mToken = token;
        }

        public ATNFToDoNotConditionVerbTransOrFinNodeFactory_v2(ATNFToDoNotConditionVerbTransOrFinNode_v2 sameNode, ATNExtendedToken token, InitATNFToDoNotConditionVerbTransOrFinNodeAction initAction)
        {
            mNumberOfConstructor = 2;
            mSameNode = sameNode;
            mToken = token;
            mInitAction = initAction;
        }

        private int mNumberOfConstructor;
        private ATNFToDoNotConditionTransNode_v2 mParentNode;
        private ATNFToDoNotConditionVerbTransOrFinNode_v2 mSameNode;
        private ATNExtendedToken mToken;
        private InitATNFToDoNotConditionVerbTransOrFinNodeAction mInitAction;

        public override BaseATNNode_v2 Create(ContextOfATNParsing_v2 context)
        {
            switch(mNumberOfConstructor)
            {
                case 1:
                    return new ATNFToDoNotConditionVerbTransOrFinNode_v2(context, mParentNode, mToken);

                case 2:
                    return new ATNFToDoNotConditionVerbTransOrFinNode_v2(context, mSameNode, mInitAction, mToken);

                default:
                    throw new ArgumentOutOfRangeException(nameof(mNumberOfConstructor), mNumberOfConstructor, null);
            }
        }
    }

/*Sub states:
    FToDo_Not_Condition_Verb_Obj_TransOrFin
    FToDo_Not_Condition_Verb_Condition_Fin
*/

    public class ATNFToDoNotConditionVerbTransOrFinNode_v2: BaseATNNode_v2
    {
        public ATNFToDoNotConditionVerbTransOrFinNode_v2(ContextOfATNParsing_v2 context, ATNFToDoNotConditionTransNode_v2 parentNode, ATNExtendedToken token)
            : base(context, token)
        {
            ParentNode = parentNode;
        }

        public ATNFToDoNotConditionVerbTransOrFinNode_v2(ContextOfATNParsing_v2 context, ATNFToDoNotConditionVerbTransOrFinNode_v2 sameNode, InitATNFToDoNotConditionVerbTransOrFinNodeAction initAction, ATNExtendedToken token)
            : base(context, token)
        {
            mSameNode = sameNode;
            mInitAction = initAction;
            ParentNode = mSameNode.ParentNode;
            mInitAction?.Invoke(this);
        }

        public override StateOfATNParsing_v2 GlobalState => StateOfATNParsing_v2.FToDo_Not_Condition_Verb_TransOrFin;

        public ATNFToDoNotConditionTransNode_v2 ParentNode { get; private set; }
        private ATNFToDoNotConditionVerbTransOrFinNode_v2 mSameNode;
        private InitATNFToDoNotConditionVerbTransOrFinNodeAction mInitAction;

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

