using MyNPCLib.NLToCGParsing;
using System;
using System.Collections.Generic;
using System.Text;

namespace MyNPCLib.NLToCGParsing_v2.ATNNodes
{
    public delegate void InitATNSubjFToBeNotBeingTransNodeAction(ATNSubjFToBeNotBeingTransNode_v2 item);

    public class ATNSubjFToBeNotBeingTransNodeFactory_v2: BaseATNNodeFactory_v2
    {
        public ATNSubjFToBeNotBeingTransNodeFactory_v2(ATNSubjFToBeNotTransNode_v2 parentNode, ATNExtendedToken token)
        {
            mNumberOfConstructor = 1;
            mParentNode = parentNode;
            mToken = token;
        }

        public ATNSubjFToBeNotBeingTransNodeFactory_v2(ATNSubjFToBeNotBeingTransNode_v2 sameNode, ATNExtendedToken token, InitATNSubjFToBeNotBeingTransNodeAction initAction)
        {
            mNumberOfConstructor = 2;
            mSameNode = sameNode;
            mToken = token;
            mInitAction = initAction;
        }

        private int mNumberOfConstructor;
        private ATNSubjFToBeNotTransNode_v2 mParentNode;
        private ATNSubjFToBeNotBeingTransNode_v2 mSameNode;
        private ATNExtendedToken mToken;
        private InitATNSubjFToBeNotBeingTransNodeAction mInitAction;

        public override BaseATNNode_v2 Create(ContextOfATNParsing_v2 context)
        {
            switch(mNumberOfConstructor)
            {
                case 1:
                    return new ATNSubjFToBeNotBeingTransNode_v2(context, mParentNode, mToken);

                case 2:
                    return new ATNSubjFToBeNotBeingTransNode_v2(context, mSameNode, mInitAction, mToken);

                default:
                    throw new ArgumentOutOfRangeException(nameof(mNumberOfConstructor), mNumberOfConstructor, null);
            }
        }
    }

/*Sub states:
    Subj_FToBe_Not_Being_V3_TransOrFin
    Subj_FToBe_Not_Being_Condition_Trans
*/

    public class ATNSubjFToBeNotBeingTransNode_v2: BaseATNNode_v2
    {
        public ATNSubjFToBeNotBeingTransNode_v2(ContextOfATNParsing_v2 context, ATNSubjFToBeNotTransNode_v2 parentNode, ATNExtendedToken token)
            : base(context, token)
        {
            ParentNode = parentNode;
        }

        public ATNSubjFToBeNotBeingTransNode_v2(ContextOfATNParsing_v2 context, ATNSubjFToBeNotBeingTransNode_v2 sameNode, InitATNSubjFToBeNotBeingTransNodeAction initAction, ATNExtendedToken token)
            : base(context, token)
        {
            mSameNode = sameNode;
            mInitAction = initAction;
            ParentNode = mSameNode.ParentNode;
            mInitAction?.Invoke(this);
        }

        public override StateOfATNParsing_v2 GlobalState => StateOfATNParsing_v2.Subj_FToBe_Not_Being_Trans;

        public ATNSubjFToBeNotTransNode_v2 ParentNode { get; private set; }
        private ATNSubjFToBeNotBeingTransNode_v2 mSameNode;
        private InitATNSubjFToBeNotBeingTransNodeAction mInitAction;

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

