using MyNPCLib.NLToCGParsing;
using System;
using System.Collections.Generic;
using System.Text;

namespace MyNPCLib.NLToCGParsing_v2.ATNNodes
{
    public delegate void InitATNConditionFToDoNotConditionVerbTransOrFinNodeAction(ATNConditionFToDoNotConditionVerbTransOrFinNode_v2 item);

    public class ATNConditionFToDoNotConditionVerbTransOrFinNodeFactory_v2: BaseATNNodeFactory_v2
    {
        public ATNConditionFToDoNotConditionVerbTransOrFinNodeFactory_v2(ATNConditionFToDoNotConditionTransNode_v2 parentNode, ATNExtendedToken token)
        {
            mNumberOfConstructor = 1;
            mParentNode = parentNode;
            mToken = token;
        }

        public ATNConditionFToDoNotConditionVerbTransOrFinNodeFactory_v2(ATNConditionFToDoNotConditionVerbTransOrFinNode_v2 sameNode, ATNExtendedToken token, InitATNConditionFToDoNotConditionVerbTransOrFinNodeAction initAction)
        {
            mNumberOfConstructor = 2;
            mSameNode = sameNode;
            mToken = token;
            mInitAction = initAction;
        }

        private int mNumberOfConstructor;
        private ATNConditionFToDoNotConditionTransNode_v2 mParentNode;
        private ATNConditionFToDoNotConditionVerbTransOrFinNode_v2 mSameNode;
        private ATNExtendedToken mToken;
        private InitATNConditionFToDoNotConditionVerbTransOrFinNodeAction mInitAction;

        public override BaseATNNode_v2 Create(ContextOfATNParsing_v2 context)
        {
            switch(mNumberOfConstructor)
            {
                case 1:
                    return new ATNConditionFToDoNotConditionVerbTransOrFinNode_v2(context, mParentNode, mToken);

                case 2:
                    return new ATNConditionFToDoNotConditionVerbTransOrFinNode_v2(context, mSameNode, mInitAction, mToken);

                default:
                    throw new ArgumentOutOfRangeException(nameof(mNumberOfConstructor), mNumberOfConstructor, null);
            }
        }
    }

/*Sub states:
    Condition_FToDo_Not_Condition_Verb_Obj_TransOrFin
    Condition_FToDo_Not_Condition_Verb_Condition_Fin
*/

    public class ATNConditionFToDoNotConditionVerbTransOrFinNode_v2: BaseATNNode_v2
    {
        public ATNConditionFToDoNotConditionVerbTransOrFinNode_v2(ContextOfATNParsing_v2 context, ATNConditionFToDoNotConditionTransNode_v2 parentNode, ATNExtendedToken token)
            : base(context, token)
        {
            ParentNode = parentNode;
        }

        public ATNConditionFToDoNotConditionVerbTransOrFinNode_v2(ContextOfATNParsing_v2 context, ATNConditionFToDoNotConditionVerbTransOrFinNode_v2 sameNode, InitATNConditionFToDoNotConditionVerbTransOrFinNodeAction initAction, ATNExtendedToken token)
            : base(context, token)
        {
            mSameNode = sameNode;
            mInitAction = initAction;
            ParentNode = mSameNode.ParentNode;
            mInitAction?.Invoke(this);
        }

        public override StateOfATNParsing_v2 GlobalState => StateOfATNParsing_v2.Condition_FToDo_Not_Condition_Verb_TransOrFin;

        public ATNConditionFToDoNotConditionTransNode_v2 ParentNode { get; private set; }
        private ATNConditionFToDoNotConditionVerbTransOrFinNode_v2 mSameNode;
        private InitATNConditionFToDoNotConditionVerbTransOrFinNodeAction mInitAction;

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

