using MyNPCLib.NLToCGParsing;
using System;
using System.Collections.Generic;
using System.Text;

namespace MyNPCLib.NLToCGParsing_v2.ATNNodes
{
    public delegate void InitATNFToBeSubjTransNodeAction(ATNFToBeSubjTransNode_v2 item);

    public class ATNFToBeSubjTransNodeFactory_v2: BaseATNNodeFactory_v2
    {
        public ATNFToBeSubjTransNodeFactory_v2(ATNFToBeTransNode_v2 parentNode, ATNExtendedToken token)
        {
            mNumberOfConstructor = 1;
            mParentNode = parentNode;
            mToken = token;
        }

        public ATNFToBeSubjTransNodeFactory_v2(ATNFToBeSubjTransNode_v2 sameNode, ATNExtendedToken token, InitATNFToBeSubjTransNodeAction initAction)
        {
            mNumberOfConstructor = 2;
            mSameNode = sameNode;
            mToken = token;
            mInitAction = initAction;
        }

        private int mNumberOfConstructor;
        private ATNFToBeTransNode_v2 mParentNode;
        private ATNFToBeSubjTransNode_v2 mSameNode;
        private ATNExtendedToken mToken;
        private InitATNFToBeSubjTransNodeAction mInitAction;

        public override BaseATNNode_v2 Create(ContextOfATNParsing_v2 context)
        {
            switch(mNumberOfConstructor)
            {
                case 1:
                    return new ATNFToBeSubjTransNode_v2(context, mParentNode, mToken);

                case 2:
                    return new ATNFToBeSubjTransNode_v2(context, mSameNode, mInitAction, mToken);

                default:
                    throw new ArgumentOutOfRangeException(nameof(mNumberOfConstructor), mNumberOfConstructor, null);
            }
        }
    }

/*Sub states:
    FToBe_Subj_Ving_TransOrFin
    FToBe_Subj_V3_TransOrFin
    FToBe_Subj_Being_Trans
    FToBe_Subj_Condition_Trans
*/

    public class ATNFToBeSubjTransNode_v2: BaseATNNode_v2
    {
        public ATNFToBeSubjTransNode_v2(ContextOfATNParsing_v2 context, ATNFToBeTransNode_v2 parentNode, ATNExtendedToken token)
            : base(context, token)
        {
            ParentNode = parentNode;
        }

        public ATNFToBeSubjTransNode_v2(ContextOfATNParsing_v2 context, ATNFToBeSubjTransNode_v2 sameNode, InitATNFToBeSubjTransNodeAction initAction, ATNExtendedToken token)
            : base(context, token)
        {
            mSameNode = sameNode;
            mInitAction = initAction;
            ParentNode = mSameNode.ParentNode;
            mInitAction?.Invoke(this);
        }

        public override StateOfATNParsing_v2 GlobalState => StateOfATNParsing_v2.FToBe_Subj_Trans;

        public ATNFToBeTransNode_v2 ParentNode { get; private set; }
        private ATNFToBeSubjTransNode_v2 mSameNode;
        private InitATNFToBeSubjTransNodeAction mInitAction;

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

