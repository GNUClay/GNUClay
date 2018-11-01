using MyNPCLib.NLToCGParsing;
using System;
using System.Collections.Generic;
using System.Text;

namespace MyNPCLib.NLToCGParsing_v2.ATNNodes
{
    public delegate void InitATNSubjFToBeBeingV3TransOrFinNodeAction(ATNSubjFToBeBeingV3TransOrFinNode_v2 item);

    public class ATNSubjFToBeBeingV3TransOrFinNodeFactory_v2: BaseATNNodeFactory_v2
    {
        public ATNSubjFToBeBeingV3TransOrFinNodeFactory_v2(ATNSubjFToBeBeingTransNode_v2 parentNode, ATNExtendedToken token)
        {
            mNumberOfConstructor = 1;
            mParentNode = parentNode;
            mToken = token;
        }

        public ATNSubjFToBeBeingV3TransOrFinNodeFactory_v2(ATNSubjFToBeBeingV3TransOrFinNode_v2 sameNode, ATNExtendedToken token, InitATNSubjFToBeBeingV3TransOrFinNodeAction initAction)
        {
            mNumberOfConstructor = 2;
            mSameNode = sameNode;
            mToken = token;
            mInitAction = initAction;
        }

        private int mNumberOfConstructor;
        private ATNSubjFToBeBeingTransNode_v2 mParentNode;
        private ATNSubjFToBeBeingV3TransOrFinNode_v2 mSameNode;
        private ATNExtendedToken mToken;
        private InitATNSubjFToBeBeingV3TransOrFinNodeAction mInitAction;

        public override BaseATNNode_v2 Create(ContextOfATNParsing_v2 context)
        {
            switch(mNumberOfConstructor)
            {
                case 1:
                    return new ATNSubjFToBeBeingV3TransOrFinNode_v2(context, mParentNode, mToken);

                case 2:
                    return new ATNSubjFToBeBeingV3TransOrFinNode_v2(context, mSameNode, mInitAction, mToken);

                default:
                    throw new ArgumentOutOfRangeException(nameof(mNumberOfConstructor), mNumberOfConstructor, null);
            }
        }
    }

/*Sub states:
    Subj_FToBe_Being_V3_Obj_TransOrFin
    Subj_FToBe_Being_V3_No_Trans
    Subj_FToBe_Being_V3_Condition_Fin
*/

    public class ATNSubjFToBeBeingV3TransOrFinNode_v2: BaseATNNode_v2
    {
        public ATNSubjFToBeBeingV3TransOrFinNode_v2(ContextOfATNParsing_v2 context, ATNSubjFToBeBeingTransNode_v2 parentNode, ATNExtendedToken token)
            : base(context, token)
        {
            ParentNode = parentNode;
        }

        public ATNSubjFToBeBeingV3TransOrFinNode_v2(ContextOfATNParsing_v2 context, ATNSubjFToBeBeingV3TransOrFinNode_v2 sameNode, InitATNSubjFToBeBeingV3TransOrFinNodeAction initAction, ATNExtendedToken token)
            : base(context, token)
        {
            mSameNode = sameNode;
            mInitAction = initAction;
            ParentNode = mSameNode.ParentNode;
            mInitAction?.Invoke(this);
        }

        public override StateOfATNParsing_v2 GlobalState => StateOfATNParsing_v2.Subj_FToBe_Being_V3_TransOrFin;

        public ATNSubjFToBeBeingTransNode_v2 ParentNode { get; private set; }
        private ATNSubjFToBeBeingV3TransOrFinNode_v2 mSameNode;
        private InitATNSubjFToBeBeingV3TransOrFinNodeAction mInitAction;

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

