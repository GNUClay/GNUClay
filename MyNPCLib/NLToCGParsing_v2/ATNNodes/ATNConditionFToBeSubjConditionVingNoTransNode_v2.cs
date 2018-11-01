using MyNPCLib.NLToCGParsing;
using System;
using System.Collections.Generic;
using System.Text;

namespace MyNPCLib.NLToCGParsing_v2.ATNNodes
{
    public delegate void InitATNConditionFToBeSubjConditionVingNoTransNodeAction(ATNConditionFToBeSubjConditionVingNoTransNode_v2 item);

    public class ATNConditionFToBeSubjConditionVingNoTransNodeFactory_v2: BaseATNNodeFactory_v2
    {
        public ATNConditionFToBeSubjConditionVingNoTransNodeFactory_v2(ATNConditionFToBeSubjConditionVingTransOrFinNode_v2 parentNode, ATNExtendedToken token)
        {
            mNumberOfConstructor = 1;
            mParentNode = parentNode;
            mToken = token;
        }

        public ATNConditionFToBeSubjConditionVingNoTransNodeFactory_v2(ATNConditionFToBeSubjConditionVingNoTransNode_v2 sameNode, ATNExtendedToken token, InitATNConditionFToBeSubjConditionVingNoTransNodeAction initAction)
        {
            mNumberOfConstructor = 2;
            mSameNode = sameNode;
            mToken = token;
            mInitAction = initAction;
        }

        private int mNumberOfConstructor;
        private ATNConditionFToBeSubjConditionVingTransOrFinNode_v2 mParentNode;
        private ATNConditionFToBeSubjConditionVingNoTransNode_v2 mSameNode;
        private ATNExtendedToken mToken;
        private InitATNConditionFToBeSubjConditionVingNoTransNodeAction mInitAction;

        public override BaseATNNode_v2 Create(ContextOfATNParsing_v2 context)
        {
            switch(mNumberOfConstructor)
            {
                case 1:
                    return new ATNConditionFToBeSubjConditionVingNoTransNode_v2(context, mParentNode, mToken);

                case 2:
                    return new ATNConditionFToBeSubjConditionVingNoTransNode_v2(context, mSameNode, mInitAction, mToken);

                default:
                    throw new ArgumentOutOfRangeException(nameof(mNumberOfConstructor), mNumberOfConstructor, null);
            }
        }
    }

/*Sub states:
    Condition_FToBe_Subj_Condition_Ving_No_Obj_TransOrFin
*/

    public class ATNConditionFToBeSubjConditionVingNoTransNode_v2: BaseATNNode_v2
    {
        public ATNConditionFToBeSubjConditionVingNoTransNode_v2(ContextOfATNParsing_v2 context, ATNConditionFToBeSubjConditionVingTransOrFinNode_v2 parentNode, ATNExtendedToken token)
            : base(context, token)
        {
            ParentNode = parentNode;
        }

        public ATNConditionFToBeSubjConditionVingNoTransNode_v2(ContextOfATNParsing_v2 context, ATNConditionFToBeSubjConditionVingNoTransNode_v2 sameNode, InitATNConditionFToBeSubjConditionVingNoTransNodeAction initAction, ATNExtendedToken token)
            : base(context, token)
        {
            mSameNode = sameNode;
            mInitAction = initAction;
            ParentNode = mSameNode.ParentNode;
            mInitAction?.Invoke(this);
        }

        public override StateOfATNParsing_v2 GlobalState => StateOfATNParsing_v2.Condition_FToBe_Subj_Condition_Ving_No_Trans;

        public ATNConditionFToBeSubjConditionVingTransOrFinNode_v2 ParentNode { get; private set; }
        private ATNConditionFToBeSubjConditionVingNoTransNode_v2 mSameNode;
        private InitATNConditionFToBeSubjConditionVingNoTransNodeAction mInitAction;

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

