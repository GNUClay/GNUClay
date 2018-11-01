using MyNPCLib.NLToCGParsing;
using System;
using System.Collections.Generic;
using System.Text;

namespace MyNPCLib.NLToCGParsing_v2.ATNNodes
{
    public delegate void InitATNSubjFToBeBeingTransNodeAction(ATNSubjFToBeBeingTransNode_v2 item);

    public class ATNSubjFToBeBeingTransNodeFactory_v2: BaseATNNodeFactory_v2
    {
        public ATNSubjFToBeBeingTransNodeFactory_v2(ATNSubjFToBeTransNode_v2 parentNode, ATNExtendedToken token)
        {
            mNumberOfConstructor = 1;
            mParentNode = parentNode;
            mToken = token;
        }

        public ATNSubjFToBeBeingTransNodeFactory_v2(ATNSubjFToBeBeingTransNode_v2 sameNode, ATNExtendedToken token, InitATNSubjFToBeBeingTransNodeAction initAction)
        {
            mNumberOfConstructor = 2;
            mSameNode = sameNode;
            mToken = token;
            mInitAction = initAction;
        }

        private int mNumberOfConstructor;
        private ATNSubjFToBeTransNode_v2 mParentNode;
        private ATNSubjFToBeBeingTransNode_v2 mSameNode;
        private ATNExtendedToken mToken;
        private InitATNSubjFToBeBeingTransNodeAction mInitAction;

        public override BaseATNNode_v2 Create(ContextOfATNParsing_v2 context)
        {
            switch(mNumberOfConstructor)
            {
                case 1:
                    return new ATNSubjFToBeBeingTransNode_v2(context, mParentNode, mToken);

                case 2:
                    return new ATNSubjFToBeBeingTransNode_v2(context, mSameNode, mInitAction, mToken);

                default:
                    throw new ArgumentOutOfRangeException(nameof(mNumberOfConstructor), mNumberOfConstructor, null);
            }
        }
    }

/*Sub states:
    Subj_FToBe_Being_V3_TransOrFin
    Subj_FToBe_Being_Condition_Trans
*/

    public class ATNSubjFToBeBeingTransNode_v2: BaseATNNode_v2
    {
        public ATNSubjFToBeBeingTransNode_v2(ContextOfATNParsing_v2 context, ATNSubjFToBeTransNode_v2 parentNode, ATNExtendedToken token)
            : base(context, token)
        {
            ParentNode = parentNode;
        }

        public ATNSubjFToBeBeingTransNode_v2(ContextOfATNParsing_v2 context, ATNSubjFToBeBeingTransNode_v2 sameNode, InitATNSubjFToBeBeingTransNodeAction initAction, ATNExtendedToken token)
            : base(context, token)
        {
            mSameNode = sameNode;
            mInitAction = initAction;
            ParentNode = mSameNode.ParentNode;
            mInitAction?.Invoke(this);
        }

        public override StateOfATNParsing_v2 GlobalState => StateOfATNParsing_v2.Subj_FToBe_Being_Trans;

        public ATNSubjFToBeTransNode_v2 ParentNode { get; private set; }
        private ATNSubjFToBeBeingTransNode_v2 mSameNode;
        private InitATNSubjFToBeBeingTransNodeAction mInitAction;

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

