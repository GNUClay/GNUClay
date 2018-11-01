using MyNPCLib.NLToCGParsing;
using System;
using System.Collections.Generic;
using System.Text;

namespace MyNPCLib.NLToCGParsing_v2.ATNNodes
{
    public delegate void InitATNConditionSubjFToBeVingNoTransNodeAction(ATNConditionSubjFToBeVingNoTransNode_v2 item);

    public class ATNConditionSubjFToBeVingNoTransNodeFactory_v2: BaseATNNodeFactory_v2
    {
        public ATNConditionSubjFToBeVingNoTransNodeFactory_v2(ATNConditionSubjFToBeVingTransOrFinNode_v2 parentNode, ATNExtendedToken token)
        {
            mNumberOfConstructor = 1;
            mParentNode = parentNode;
            mToken = token;
        }

        public ATNConditionSubjFToBeVingNoTransNodeFactory_v2(ATNConditionSubjFToBeVingNoTransNode_v2 sameNode, ATNExtendedToken token, InitATNConditionSubjFToBeVingNoTransNodeAction initAction)
        {
            mNumberOfConstructor = 2;
            mSameNode = sameNode;
            mToken = token;
            mInitAction = initAction;
        }

        private int mNumberOfConstructor;
        private ATNConditionSubjFToBeVingTransOrFinNode_v2 mParentNode;
        private ATNConditionSubjFToBeVingNoTransNode_v2 mSameNode;
        private ATNExtendedToken mToken;
        private InitATNConditionSubjFToBeVingNoTransNodeAction mInitAction;

        public override BaseATNNode_v2 Create(ContextOfATNParsing_v2 context)
        {
            switch(mNumberOfConstructor)
            {
                case 1:
                    return new ATNConditionSubjFToBeVingNoTransNode_v2(context, mParentNode, mToken);

                case 2:
                    return new ATNConditionSubjFToBeVingNoTransNode_v2(context, mSameNode, mInitAction, mToken);

                default:
                    throw new ArgumentOutOfRangeException(nameof(mNumberOfConstructor), mNumberOfConstructor, null);
            }
        }
    }

/*Sub states:
    Condition_Subj_FToBe_Ving_No_Obj_TransOrFin
*/

    public class ATNConditionSubjFToBeVingNoTransNode_v2: BaseATNNode_v2
    {
        public ATNConditionSubjFToBeVingNoTransNode_v2(ContextOfATNParsing_v2 context, ATNConditionSubjFToBeVingTransOrFinNode_v2 parentNode, ATNExtendedToken token)
            : base(context, token)
        {
            ParentNode = parentNode;
        }

        public ATNConditionSubjFToBeVingNoTransNode_v2(ContextOfATNParsing_v2 context, ATNConditionSubjFToBeVingNoTransNode_v2 sameNode, InitATNConditionSubjFToBeVingNoTransNodeAction initAction, ATNExtendedToken token)
            : base(context, token)
        {
            mSameNode = sameNode;
            mInitAction = initAction;
            ParentNode = mSameNode.ParentNode;
            mInitAction?.Invoke(this);
        }

        public override StateOfATNParsing_v2 GlobalState => StateOfATNParsing_v2.Condition_Subj_FToBe_Ving_No_Trans;

        public ATNConditionSubjFToBeVingTransOrFinNode_v2 ParentNode { get; private set; }
        private ATNConditionSubjFToBeVingNoTransNode_v2 mSameNode;
        private InitATNConditionSubjFToBeVingNoTransNodeAction mInitAction;

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

