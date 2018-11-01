using MyNPCLib.NLToCGParsing;
using System;
using System.Collections.Generic;
using System.Text;

namespace MyNPCLib.NLToCGParsing_v2.ATNNodes
{
    public delegate void InitATNFToBeSubjConditionVingNoTransNodeAction(ATNFToBeSubjConditionVingNoTransNode_v2 item);

    public class ATNFToBeSubjConditionVingNoTransNodeFactory_v2: BaseATNNodeFactory_v2
    {
        public ATNFToBeSubjConditionVingNoTransNodeFactory_v2(ATNFToBeSubjConditionVingTransOrFinNode_v2 parentNode, ATNExtendedToken token)
        {
            mNumberOfConstructor = 1;
            mParentNode = parentNode;
            mToken = token;
        }

        public ATNFToBeSubjConditionVingNoTransNodeFactory_v2(ATNFToBeSubjConditionVingNoTransNode_v2 sameNode, ATNExtendedToken token, InitATNFToBeSubjConditionVingNoTransNodeAction initAction)
        {
            mNumberOfConstructor = 2;
            mSameNode = sameNode;
            mToken = token;
            mInitAction = initAction;
        }

        private int mNumberOfConstructor;
        private ATNFToBeSubjConditionVingTransOrFinNode_v2 mParentNode;
        private ATNFToBeSubjConditionVingNoTransNode_v2 mSameNode;
        private ATNExtendedToken mToken;
        private InitATNFToBeSubjConditionVingNoTransNodeAction mInitAction;

        public override BaseATNNode_v2 Create(ContextOfATNParsing_v2 context)
        {
            switch(mNumberOfConstructor)
            {
                case 1:
                    return new ATNFToBeSubjConditionVingNoTransNode_v2(context, mParentNode, mToken);

                case 2:
                    return new ATNFToBeSubjConditionVingNoTransNode_v2(context, mSameNode, mInitAction, mToken);

                default:
                    throw new ArgumentOutOfRangeException(nameof(mNumberOfConstructor), mNumberOfConstructor, null);
            }
        }
    }

/*Sub states:
    FToBe_Subj_Condition_Ving_No_Obj_TransOrFin
*/

    public class ATNFToBeSubjConditionVingNoTransNode_v2: BaseATNNode_v2
    {
        public ATNFToBeSubjConditionVingNoTransNode_v2(ContextOfATNParsing_v2 context, ATNFToBeSubjConditionVingTransOrFinNode_v2 parentNode, ATNExtendedToken token)
            : base(context, token)
        {
            ParentNode = parentNode;
        }

        public ATNFToBeSubjConditionVingNoTransNode_v2(ContextOfATNParsing_v2 context, ATNFToBeSubjConditionVingNoTransNode_v2 sameNode, InitATNFToBeSubjConditionVingNoTransNodeAction initAction, ATNExtendedToken token)
            : base(context, token)
        {
            mSameNode = sameNode;
            mInitAction = initAction;
            ParentNode = mSameNode.ParentNode;
            mInitAction?.Invoke(this);
        }

        public override StateOfATNParsing_v2 GlobalState => StateOfATNParsing_v2.FToBe_Subj_Condition_Ving_No_Trans;

        public ATNFToBeSubjConditionVingTransOrFinNode_v2 ParentNode { get; private set; }
        private ATNFToBeSubjConditionVingNoTransNode_v2 mSameNode;
        private InitATNFToBeSubjConditionVingNoTransNodeAction mInitAction;

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

