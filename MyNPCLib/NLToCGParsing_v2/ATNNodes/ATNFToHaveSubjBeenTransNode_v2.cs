using MyNPCLib.NLToCGParsing;
using System;
using System.Collections.Generic;
using System.Text;

namespace MyNPCLib.NLToCGParsing_v2.ATNNodes
{
    public delegate void InitATNFToHaveSubjBeenTransNodeAction(ATNFToHaveSubjBeenTransNode_v2 item);

    public class ATNFToHaveSubjBeenTransNodeFactory_v2: BaseATNNodeFactory_v2
    {
        public ATNFToHaveSubjBeenTransNodeFactory_v2(ATNFToHaveSubjTransNode_v2 parentNode, ATNExtendedToken token)
        {
            mNumberOfConstructor = 1;
            mParentNode = parentNode;
            mToken = token;
        }

        public ATNFToHaveSubjBeenTransNodeFactory_v2(ATNFToHaveSubjBeenTransNode_v2 sameNode, ATNExtendedToken token, InitATNFToHaveSubjBeenTransNodeAction initAction)
        {
            mNumberOfConstructor = 2;
            mSameNode = sameNode;
            mToken = token;
            mInitAction = initAction;
        }

        private int mNumberOfConstructor;
        private ATNFToHaveSubjTransNode_v2 mParentNode;
        private ATNFToHaveSubjBeenTransNode_v2 mSameNode;
        private ATNExtendedToken mToken;
        private InitATNFToHaveSubjBeenTransNodeAction mInitAction;

        public override BaseATNNode_v2 Create(ContextOfATNParsing_v2 context)
        {
            switch(mNumberOfConstructor)
            {
                case 1:
                    return new ATNFToHaveSubjBeenTransNode_v2(context, mParentNode, mToken);

                case 2:
                    return new ATNFToHaveSubjBeenTransNode_v2(context, mSameNode, mInitAction, mToken);

                default:
                    throw new ArgumentOutOfRangeException(nameof(mNumberOfConstructor), mNumberOfConstructor, null);
            }
        }
    }

/*Sub states:
    FToHave_Subj_Been_Ving_TransOrFin
    FToHave_Subj_Been_V3_TransOrFin
    FToHave_Subj_Been_Condition_Trans
*/

    public class ATNFToHaveSubjBeenTransNode_v2: BaseATNNode_v2
    {
        public ATNFToHaveSubjBeenTransNode_v2(ContextOfATNParsing_v2 context, ATNFToHaveSubjTransNode_v2 parentNode, ATNExtendedToken token)
            : base(context, token)
        {
            ParentNode = parentNode;
        }

        public ATNFToHaveSubjBeenTransNode_v2(ContextOfATNParsing_v2 context, ATNFToHaveSubjBeenTransNode_v2 sameNode, InitATNFToHaveSubjBeenTransNodeAction initAction, ATNExtendedToken token)
            : base(context, token)
        {
            mSameNode = sameNode;
            mInitAction = initAction;
            ParentNode = mSameNode.ParentNode;
            mInitAction?.Invoke(this);
        }

        public override StateOfATNParsing_v2 GlobalState => StateOfATNParsing_v2.FToHave_Subj_Been_Trans;

        public ATNFToHaveSubjTransNode_v2 ParentNode { get; private set; }
        private ATNFToHaveSubjBeenTransNode_v2 mSameNode;
        private InitATNFToHaveSubjBeenTransNodeAction mInitAction;

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

