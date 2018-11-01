using MyNPCLib.NLToCGParsing;
using System;
using System.Collections.Generic;
using System.Text;

namespace MyNPCLib.NLToCGParsing_v2.ATNNodes
{
    public delegate void InitATNConditionSubjFToBeVingTransOrFinNodeAction(ATNConditionSubjFToBeVingTransOrFinNode_v2 item);

    public class ATNConditionSubjFToBeVingTransOrFinNodeFactory_v2: BaseATNNodeFactory_v2
    {
        public ATNConditionSubjFToBeVingTransOrFinNodeFactory_v2(ATNConditionSubjFToBeTransNode_v2 parentNode, ATNExtendedToken token)
        {
            mNumberOfConstructor = 1;
            mParentNode = parentNode;
            mToken = token;
        }

        public ATNConditionSubjFToBeVingTransOrFinNodeFactory_v2(ATNConditionSubjFToBeVingTransOrFinNode_v2 sameNode, ATNExtendedToken token, InitATNConditionSubjFToBeVingTransOrFinNodeAction initAction)
        {
            mNumberOfConstructor = 2;
            mSameNode = sameNode;
            mToken = token;
            mInitAction = initAction;
        }

        private int mNumberOfConstructor;
        private ATNConditionSubjFToBeTransNode_v2 mParentNode;
        private ATNConditionSubjFToBeVingTransOrFinNode_v2 mSameNode;
        private ATNExtendedToken mToken;
        private InitATNConditionSubjFToBeVingTransOrFinNodeAction mInitAction;

        public override BaseATNNode_v2 Create(ContextOfATNParsing_v2 context)
        {
            switch(mNumberOfConstructor)
            {
                case 1:
                    return new ATNConditionSubjFToBeVingTransOrFinNode_v2(context, mParentNode, mToken);

                case 2:
                    return new ATNConditionSubjFToBeVingTransOrFinNode_v2(context, mSameNode, mInitAction, mToken);

                default:
                    throw new ArgumentOutOfRangeException(nameof(mNumberOfConstructor), mNumberOfConstructor, null);
            }
        }
    }

/*Sub states:
    Condition_Subj_FToBe_Ving_Obj_TransOrFin
    Condition_Subj_FToBe_Ving_No_Trans
    Condition_Subj_FToBe_Ving_Condition_Fin
*/

    public class ATNConditionSubjFToBeVingTransOrFinNode_v2: BaseATNNode_v2
    {
        public ATNConditionSubjFToBeVingTransOrFinNode_v2(ContextOfATNParsing_v2 context, ATNConditionSubjFToBeTransNode_v2 parentNode, ATNExtendedToken token)
            : base(context, token)
        {
            ParentNode = parentNode;
        }

        public ATNConditionSubjFToBeVingTransOrFinNode_v2(ContextOfATNParsing_v2 context, ATNConditionSubjFToBeVingTransOrFinNode_v2 sameNode, InitATNConditionSubjFToBeVingTransOrFinNodeAction initAction, ATNExtendedToken token)
            : base(context, token)
        {
            mSameNode = sameNode;
            mInitAction = initAction;
            ParentNode = mSameNode.ParentNode;
            mInitAction?.Invoke(this);
        }

        public override StateOfATNParsing_v2 GlobalState => StateOfATNParsing_v2.Condition_Subj_FToBe_Ving_TransOrFin;

        public ATNConditionSubjFToBeTransNode_v2 ParentNode { get; private set; }
        private ATNConditionSubjFToBeVingTransOrFinNode_v2 mSameNode;
        private InitATNConditionSubjFToBeVingTransOrFinNodeAction mInitAction;

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

