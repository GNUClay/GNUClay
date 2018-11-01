using MyNPCLib.NLToCGParsing;
using System;
using System.Collections.Generic;
using System.Text;

namespace MyNPCLib.NLToCGParsing_v2.ATNNodes
{
    public delegate void InitATNFToBeSubjConditionVingTransOrFinNodeAction(ATNFToBeSubjConditionVingTransOrFinNode_v2 item);

    public class ATNFToBeSubjConditionVingTransOrFinNodeFactory_v2: BaseATNNodeFactory_v2
    {
        public ATNFToBeSubjConditionVingTransOrFinNodeFactory_v2(ATNFToBeSubjConditionTransNode_v2 parentNode, ATNExtendedToken token)
        {
            mNumberOfConstructor = 1;
            mParentNode = parentNode;
            mToken = token;
        }

        public ATNFToBeSubjConditionVingTransOrFinNodeFactory_v2(ATNFToBeSubjConditionVingTransOrFinNode_v2 sameNode, ATNExtendedToken token, InitATNFToBeSubjConditionVingTransOrFinNodeAction initAction)
        {
            mNumberOfConstructor = 2;
            mSameNode = sameNode;
            mToken = token;
            mInitAction = initAction;
        }

        private int mNumberOfConstructor;
        private ATNFToBeSubjConditionTransNode_v2 mParentNode;
        private ATNFToBeSubjConditionVingTransOrFinNode_v2 mSameNode;
        private ATNExtendedToken mToken;
        private InitATNFToBeSubjConditionVingTransOrFinNodeAction mInitAction;

        public override BaseATNNode_v2 Create(ContextOfATNParsing_v2 context)
        {
            switch(mNumberOfConstructor)
            {
                case 1:
                    return new ATNFToBeSubjConditionVingTransOrFinNode_v2(context, mParentNode, mToken);

                case 2:
                    return new ATNFToBeSubjConditionVingTransOrFinNode_v2(context, mSameNode, mInitAction, mToken);

                default:
                    throw new ArgumentOutOfRangeException(nameof(mNumberOfConstructor), mNumberOfConstructor, null);
            }
        }
    }

/*Sub states:
    FToBe_Subj_Condition_Ving_Obj_TransOrFin
    FToBe_Subj_Condition_Ving_No_Trans
    FToBe_Subj_Condition_Ving_Condition_Fin
*/

    public class ATNFToBeSubjConditionVingTransOrFinNode_v2: BaseATNNode_v2
    {
        public ATNFToBeSubjConditionVingTransOrFinNode_v2(ContextOfATNParsing_v2 context, ATNFToBeSubjConditionTransNode_v2 parentNode, ATNExtendedToken token)
            : base(context, token)
        {
            ParentNode = parentNode;
        }

        public ATNFToBeSubjConditionVingTransOrFinNode_v2(ContextOfATNParsing_v2 context, ATNFToBeSubjConditionVingTransOrFinNode_v2 sameNode, InitATNFToBeSubjConditionVingTransOrFinNodeAction initAction, ATNExtendedToken token)
            : base(context, token)
        {
            mSameNode = sameNode;
            mInitAction = initAction;
            ParentNode = mSameNode.ParentNode;
            mInitAction?.Invoke(this);
        }

        public override StateOfATNParsing_v2 GlobalState => StateOfATNParsing_v2.FToBe_Subj_Condition_Ving_TransOrFin;

        public ATNFToBeSubjConditionTransNode_v2 ParentNode { get; private set; }
        private ATNFToBeSubjConditionVingTransOrFinNode_v2 mSameNode;
        private InitATNFToBeSubjConditionVingTransOrFinNodeAction mInitAction;

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

