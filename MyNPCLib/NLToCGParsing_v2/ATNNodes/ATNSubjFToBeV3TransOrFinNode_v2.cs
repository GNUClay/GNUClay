using MyNPCLib.NLToCGParsing;
using System;
using System.Collections.Generic;
using System.Text;

namespace MyNPCLib.NLToCGParsing_v2.ATNNodes
{
    public delegate void InitATNSubjFToBeV3TransOrFinNodeAction(ATNSubjFToBeV3TransOrFinNode_v2 item);

    public class ATNSubjFToBeV3TransOrFinNodeFactory_v2: BaseATNNodeFactory_v2
    {
        public ATNSubjFToBeV3TransOrFinNodeFactory_v2(ATNSubjFToBeTransNode_v2 parentNode, ATNExtendedToken token)
        {
            mNumberOfConstructor = 1;
            mParentNode = parentNode;
            mToken = token;
        }

        public ATNSubjFToBeV3TransOrFinNodeFactory_v2(ATNSubjFToBeV3TransOrFinNode_v2 sameNode, ATNExtendedToken token, InitATNSubjFToBeV3TransOrFinNodeAction initAction)
        {
            mNumberOfConstructor = 2;
            mSameNode = sameNode;
            mToken = token;
            mInitAction = initAction;
        }

        private int mNumberOfConstructor;
        private ATNSubjFToBeTransNode_v2 mParentNode;
        private ATNSubjFToBeV3TransOrFinNode_v2 mSameNode;
        private ATNExtendedToken mToken;
        private InitATNSubjFToBeV3TransOrFinNodeAction mInitAction;

        public override BaseATNNode_v2 Create(ContextOfATNParsing_v2 context)
        {
            switch(mNumberOfConstructor)
            {
                case 1:
                    return new ATNSubjFToBeV3TransOrFinNode_v2(context, mParentNode, mToken);

                case 2:
                    return new ATNSubjFToBeV3TransOrFinNode_v2(context, mSameNode, mInitAction, mToken);

                default:
                    throw new ArgumentOutOfRangeException(nameof(mNumberOfConstructor), mNumberOfConstructor, null);
            }
        }
    }

/*Sub states:
    Subj_FToBe_V3_Obj_TransOrFin
    Subj_FToBe_V3_No_Trans
    Subj_FToBe_V3_Condition_Fin
*/

    public class ATNSubjFToBeV3TransOrFinNode_v2: BaseATNNode_v2
    {
        public ATNSubjFToBeV3TransOrFinNode_v2(ContextOfATNParsing_v2 context, ATNSubjFToBeTransNode_v2 parentNode, ATNExtendedToken token)
            : base(context, token)
        {
            ParentNode = parentNode;
        }

        public ATNSubjFToBeV3TransOrFinNode_v2(ContextOfATNParsing_v2 context, ATNSubjFToBeV3TransOrFinNode_v2 sameNode, InitATNSubjFToBeV3TransOrFinNodeAction initAction, ATNExtendedToken token)
            : base(context, token)
        {
            mSameNode = sameNode;
            mInitAction = initAction;
            ParentNode = mSameNode.ParentNode;
            mInitAction?.Invoke(this);
        }

        public override StateOfATNParsing_v2 GlobalState => StateOfATNParsing_v2.Subj_FToBe_V3_TransOrFin;

        public ATNSubjFToBeTransNode_v2 ParentNode { get; private set; }
        private ATNSubjFToBeV3TransOrFinNode_v2 mSameNode;
        private InitATNSubjFToBeV3TransOrFinNodeAction mInitAction;

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

