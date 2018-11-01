using MyNPCLib.NLToCGParsing;
using System;
using System.Collections.Generic;
using System.Text;

namespace MyNPCLib.NLToCGParsing_v2.ATNNodes
{
    public delegate void InitATNConditionFToBeSubjConditionVingTransOrFinNodeAction(ATNConditionFToBeSubjConditionVingTransOrFinNode_v2 item);

    public class ATNConditionFToBeSubjConditionVingTransOrFinNodeFactory_v2: BaseATNNodeFactory_v2
    {
        public ATNConditionFToBeSubjConditionVingTransOrFinNodeFactory_v2(ATNConditionFToBeSubjConditionTransNode_v2 parentNode, ATNExtendedToken token)
        {
            mNumberOfConstructor = 1;
            mParentNode = parentNode;
            mToken = token;
        }

        public ATNConditionFToBeSubjConditionVingTransOrFinNodeFactory_v2(ATNConditionFToBeSubjConditionVingTransOrFinNode_v2 sameNode, ATNExtendedToken token, InitATNConditionFToBeSubjConditionVingTransOrFinNodeAction initAction)
        {
            mNumberOfConstructor = 2;
            mSameNode = sameNode;
            mToken = token;
            mInitAction = initAction;
        }

        private int mNumberOfConstructor;
        private ATNConditionFToBeSubjConditionTransNode_v2 mParentNode;
        private ATNConditionFToBeSubjConditionVingTransOrFinNode_v2 mSameNode;
        private ATNExtendedToken mToken;
        private InitATNConditionFToBeSubjConditionVingTransOrFinNodeAction mInitAction;

        public override BaseATNNode_v2 Create(ContextOfATNParsing_v2 context)
        {
            switch(mNumberOfConstructor)
            {
                case 1:
                    return new ATNConditionFToBeSubjConditionVingTransOrFinNode_v2(context, mParentNode, mToken);

                case 2:
                    return new ATNConditionFToBeSubjConditionVingTransOrFinNode_v2(context, mSameNode, mInitAction, mToken);

                default:
                    throw new ArgumentOutOfRangeException(nameof(mNumberOfConstructor), mNumberOfConstructor, null);
            }
        }
    }

/*Sub states:
    Condition_FToBe_Subj_Condition_Ving_Obj_TransOrFin
    Condition_FToBe_Subj_Condition_Ving_No_Trans
    Condition_FToBe_Subj_Condition_Ving_Condition_Fin
*/

    public class ATNConditionFToBeSubjConditionVingTransOrFinNode_v2: BaseATNNode_v2
    {
        public ATNConditionFToBeSubjConditionVingTransOrFinNode_v2(ContextOfATNParsing_v2 context, ATNConditionFToBeSubjConditionTransNode_v2 parentNode, ATNExtendedToken token)
            : base(context, token)
        {
            ParentNode = parentNode;
        }

        public ATNConditionFToBeSubjConditionVingTransOrFinNode_v2(ContextOfATNParsing_v2 context, ATNConditionFToBeSubjConditionVingTransOrFinNode_v2 sameNode, InitATNConditionFToBeSubjConditionVingTransOrFinNodeAction initAction, ATNExtendedToken token)
            : base(context, token)
        {
            mSameNode = sameNode;
            mInitAction = initAction;
            ParentNode = mSameNode.ParentNode;
            mInitAction?.Invoke(this);
        }

        public override StateOfATNParsing_v2 GlobalState => StateOfATNParsing_v2.Condition_FToBe_Subj_Condition_Ving_TransOrFin;

        public ATNConditionFToBeSubjConditionTransNode_v2 ParentNode { get; private set; }
        private ATNConditionFToBeSubjConditionVingTransOrFinNode_v2 mSameNode;
        private InitATNConditionFToBeSubjConditionVingTransOrFinNodeAction mInitAction;

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

