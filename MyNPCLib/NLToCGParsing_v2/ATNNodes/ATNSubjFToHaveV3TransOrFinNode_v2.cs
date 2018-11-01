using MyNPCLib.NLToCGParsing;
using System;
using System.Collections.Generic;
using System.Text;

namespace MyNPCLib.NLToCGParsing_v2.ATNNodes
{
    public delegate void InitATNSubjFToHaveV3TransOrFinNodeAction(ATNSubjFToHaveV3TransOrFinNode_v2 item);

    public class ATNSubjFToHaveV3TransOrFinNodeFactory_v2: BaseATNNodeFactory_v2
    {
        public ATNSubjFToHaveV3TransOrFinNodeFactory_v2(ATNSubjFToHaveTransNode_v2 parentNode, ATNExtendedToken token)
        {
            mNumberOfConstructor = 1;
            mParentNode = parentNode;
            mToken = token;
        }

        public ATNSubjFToHaveV3TransOrFinNodeFactory_v2(ATNSubjFToHaveV3TransOrFinNode_v2 sameNode, ATNExtendedToken token, InitATNSubjFToHaveV3TransOrFinNodeAction initAction)
        {
            mNumberOfConstructor = 2;
            mSameNode = sameNode;
            mToken = token;
            mInitAction = initAction;
        }

        private int mNumberOfConstructor;
        private ATNSubjFToHaveTransNode_v2 mParentNode;
        private ATNSubjFToHaveV3TransOrFinNode_v2 mSameNode;
        private ATNExtendedToken mToken;
        private InitATNSubjFToHaveV3TransOrFinNodeAction mInitAction;

        public override BaseATNNode_v2 Create(ContextOfATNParsing_v2 context)
        {
            switch(mNumberOfConstructor)
            {
                case 1:
                    return new ATNSubjFToHaveV3TransOrFinNode_v2(context, mParentNode, mToken);

                case 2:
                    return new ATNSubjFToHaveV3TransOrFinNode_v2(context, mSameNode, mInitAction, mToken);

                default:
                    throw new ArgumentOutOfRangeException(nameof(mNumberOfConstructor), mNumberOfConstructor, null);
            }
        }
    }

/*Sub states:
    Subj_FToHave_V3_Obj_TransOrFin
    Subj_FToHave_V3_No_Trans
    Subj_FToHave_V3_Condition_Fin
*/

    public class ATNSubjFToHaveV3TransOrFinNode_v2: BaseATNNode_v2
    {
        public ATNSubjFToHaveV3TransOrFinNode_v2(ContextOfATNParsing_v2 context, ATNSubjFToHaveTransNode_v2 parentNode, ATNExtendedToken token)
            : base(context, token)
        {
            ParentNode = parentNode;
        }

        public ATNSubjFToHaveV3TransOrFinNode_v2(ContextOfATNParsing_v2 context, ATNSubjFToHaveV3TransOrFinNode_v2 sameNode, InitATNSubjFToHaveV3TransOrFinNodeAction initAction, ATNExtendedToken token)
            : base(context, token)
        {
            mSameNode = sameNode;
            mInitAction = initAction;
            ParentNode = mSameNode.ParentNode;
            mInitAction?.Invoke(this);
        }

        public override StateOfATNParsing_v2 GlobalState => StateOfATNParsing_v2.Subj_FToHave_V3_TransOrFin;

        public ATNSubjFToHaveTransNode_v2 ParentNode { get; private set; }
        private ATNSubjFToHaveV3TransOrFinNode_v2 mSameNode;
        private InitATNSubjFToHaveV3TransOrFinNodeAction mInitAction;

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

