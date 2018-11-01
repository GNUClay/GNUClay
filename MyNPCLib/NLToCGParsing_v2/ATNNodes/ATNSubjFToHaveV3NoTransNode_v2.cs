using MyNPCLib.NLToCGParsing;
using System;
using System.Collections.Generic;
using System.Text;

namespace MyNPCLib.NLToCGParsing_v2.ATNNodes
{
    public delegate void InitATNSubjFToHaveV3NoTransNodeAction(ATNSubjFToHaveV3NoTransNode_v2 item);

    public class ATNSubjFToHaveV3NoTransNodeFactory_v2: BaseATNNodeFactory_v2
    {
        public ATNSubjFToHaveV3NoTransNodeFactory_v2(ATNSubjFToHaveV3TransOrFinNode_v2 parentNode, ATNExtendedToken token)
        {
            mNumberOfConstructor = 1;
            mParentNode = parentNode;
            mToken = token;
        }

        public ATNSubjFToHaveV3NoTransNodeFactory_v2(ATNSubjFToHaveV3NoTransNode_v2 sameNode, ATNExtendedToken token, InitATNSubjFToHaveV3NoTransNodeAction initAction)
        {
            mNumberOfConstructor = 2;
            mSameNode = sameNode;
            mToken = token;
            mInitAction = initAction;
        }

        private int mNumberOfConstructor;
        private ATNSubjFToHaveV3TransOrFinNode_v2 mParentNode;
        private ATNSubjFToHaveV3NoTransNode_v2 mSameNode;
        private ATNExtendedToken mToken;
        private InitATNSubjFToHaveV3NoTransNodeAction mInitAction;

        public override BaseATNNode_v2 Create(ContextOfATNParsing_v2 context)
        {
            switch(mNumberOfConstructor)
            {
                case 1:
                    return new ATNSubjFToHaveV3NoTransNode_v2(context, mParentNode, mToken);

                case 2:
                    return new ATNSubjFToHaveV3NoTransNode_v2(context, mSameNode, mInitAction, mToken);

                default:
                    throw new ArgumentOutOfRangeException(nameof(mNumberOfConstructor), mNumberOfConstructor, null);
            }
        }
    }

/*Sub states:
    Subj_FToHave_V3_No_Obj_TransOrFin
*/

    public class ATNSubjFToHaveV3NoTransNode_v2: BaseATNNode_v2
    {
        public ATNSubjFToHaveV3NoTransNode_v2(ContextOfATNParsing_v2 context, ATNSubjFToHaveV3TransOrFinNode_v2 parentNode, ATNExtendedToken token)
            : base(context, token)
        {
            ParentNode = parentNode;
        }

        public ATNSubjFToHaveV3NoTransNode_v2(ContextOfATNParsing_v2 context, ATNSubjFToHaveV3NoTransNode_v2 sameNode, InitATNSubjFToHaveV3NoTransNodeAction initAction, ATNExtendedToken token)
            : base(context, token)
        {
            mSameNode = sameNode;
            mInitAction = initAction;
            ParentNode = mSameNode.ParentNode;
            mInitAction?.Invoke(this);
        }

        public override StateOfATNParsing_v2 GlobalState => StateOfATNParsing_v2.Subj_FToHave_V3_No_Trans;

        public ATNSubjFToHaveV3TransOrFinNode_v2 ParentNode { get; private set; }
        private ATNSubjFToHaveV3NoTransNode_v2 mSameNode;
        private InitATNSubjFToHaveV3NoTransNodeAction mInitAction;

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

