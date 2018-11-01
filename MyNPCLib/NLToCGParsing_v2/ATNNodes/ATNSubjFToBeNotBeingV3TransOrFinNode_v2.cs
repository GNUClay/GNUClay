using MyNPCLib.NLToCGParsing;
using System;
using System.Collections.Generic;
using System.Text;

namespace MyNPCLib.NLToCGParsing_v2.ATNNodes
{
    public delegate void InitATNSubjFToBeNotBeingV3TransOrFinNodeAction(ATNSubjFToBeNotBeingV3TransOrFinNode_v2 item);

    public class ATNSubjFToBeNotBeingV3TransOrFinNodeFactory_v2: BaseATNNodeFactory_v2
    {
        public ATNSubjFToBeNotBeingV3TransOrFinNodeFactory_v2(ATNSubjFToBeNotBeingTransNode_v2 parentNode, ATNExtendedToken token)
        {
            mNumberOfConstructor = 1;
            mParentNode = parentNode;
            mToken = token;
        }

        public ATNSubjFToBeNotBeingV3TransOrFinNodeFactory_v2(ATNSubjFToBeNotBeingV3TransOrFinNode_v2 sameNode, ATNExtendedToken token, InitATNSubjFToBeNotBeingV3TransOrFinNodeAction initAction)
        {
            mNumberOfConstructor = 2;
            mSameNode = sameNode;
            mToken = token;
            mInitAction = initAction;
        }

        private int mNumberOfConstructor;
        private ATNSubjFToBeNotBeingTransNode_v2 mParentNode;
        private ATNSubjFToBeNotBeingV3TransOrFinNode_v2 mSameNode;
        private ATNExtendedToken mToken;
        private InitATNSubjFToBeNotBeingV3TransOrFinNodeAction mInitAction;

        public override BaseATNNode_v2 Create(ContextOfATNParsing_v2 context)
        {
            switch(mNumberOfConstructor)
            {
                case 1:
                    return new ATNSubjFToBeNotBeingV3TransOrFinNode_v2(context, mParentNode, mToken);

                case 2:
                    return new ATNSubjFToBeNotBeingV3TransOrFinNode_v2(context, mSameNode, mInitAction, mToken);

                default:
                    throw new ArgumentOutOfRangeException(nameof(mNumberOfConstructor), mNumberOfConstructor, null);
            }
        }
    }

/*Sub states:
    Subj_FToBe_Not_Being_V3_Obj_TransOrFin
    Subj_FToBe_Not_Being_V3_Condition_Fin
*/

    public class ATNSubjFToBeNotBeingV3TransOrFinNode_v2: BaseATNNode_v2
    {
        public ATNSubjFToBeNotBeingV3TransOrFinNode_v2(ContextOfATNParsing_v2 context, ATNSubjFToBeNotBeingTransNode_v2 parentNode, ATNExtendedToken token)
            : base(context, token)
        {
            ParentNode = parentNode;
        }

        public ATNSubjFToBeNotBeingV3TransOrFinNode_v2(ContextOfATNParsing_v2 context, ATNSubjFToBeNotBeingV3TransOrFinNode_v2 sameNode, InitATNSubjFToBeNotBeingV3TransOrFinNodeAction initAction, ATNExtendedToken token)
            : base(context, token)
        {
            mSameNode = sameNode;
            mInitAction = initAction;
            ParentNode = mSameNode.ParentNode;
            mInitAction?.Invoke(this);
        }

        public override StateOfATNParsing_v2 GlobalState => StateOfATNParsing_v2.Subj_FToBe_Not_Being_V3_TransOrFin;

        public ATNSubjFToBeNotBeingTransNode_v2 ParentNode { get; private set; }
        private ATNSubjFToBeNotBeingV3TransOrFinNode_v2 mSameNode;
        private InitATNSubjFToBeNotBeingV3TransOrFinNodeAction mInitAction;

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

