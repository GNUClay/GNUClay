using MyNPCLib.NLToCGParsing;
using System;
using System.Collections.Generic;
using System.Text;

namespace MyNPCLib.NLToCGParsing_v2.ATNNodes
{
    public delegate void InitATNSubjWillNotFToHaveV3TransOrFinNodeAction(ATNSubjWillNotFToHaveV3TransOrFinNode_v2 item);

    public class ATNSubjWillNotFToHaveV3TransOrFinNodeFactory_v2: BaseATNNodeFactory_v2
    {
        public ATNSubjWillNotFToHaveV3TransOrFinNodeFactory_v2(ATNSubjWillNotFToHaveTransNode_v2 parentNode, ATNExtendedToken token)
        {
            mNumberOfConstructor = 1;
            mParentNode = parentNode;
            mToken = token;
        }

        public ATNSubjWillNotFToHaveV3TransOrFinNodeFactory_v2(ATNSubjWillNotFToHaveV3TransOrFinNode_v2 sameNode, ATNExtendedToken token, InitATNSubjWillNotFToHaveV3TransOrFinNodeAction initAction)
        {
            mNumberOfConstructor = 2;
            mSameNode = sameNode;
            mToken = token;
            mInitAction = initAction;
        }

        private int mNumberOfConstructor;
        private ATNSubjWillNotFToHaveTransNode_v2 mParentNode;
        private ATNSubjWillNotFToHaveV3TransOrFinNode_v2 mSameNode;
        private ATNExtendedToken mToken;
        private InitATNSubjWillNotFToHaveV3TransOrFinNodeAction mInitAction;

        public override BaseATNNode_v2 Create(ContextOfATNParsing_v2 context)
        {
            switch(mNumberOfConstructor)
            {
                case 1:
                    return new ATNSubjWillNotFToHaveV3TransOrFinNode_v2(context, mParentNode, mToken);

                case 2:
                    return new ATNSubjWillNotFToHaveV3TransOrFinNode_v2(context, mSameNode, mInitAction, mToken);

                default:
                    throw new ArgumentOutOfRangeException(nameof(mNumberOfConstructor), mNumberOfConstructor, null);
            }
        }
    }

/*Sub states:
    Subj_Will_Not_FToHave_V3_Obj_TransOrFin
    Subj_Will_Not_FToHave_V3_Condition_Fin
*/

    public class ATNSubjWillNotFToHaveV3TransOrFinNode_v2: BaseATNNode_v2
    {
        public ATNSubjWillNotFToHaveV3TransOrFinNode_v2(ContextOfATNParsing_v2 context, ATNSubjWillNotFToHaveTransNode_v2 parentNode, ATNExtendedToken token)
            : base(context, token)
        {
            ParentNode = parentNode;
        }

        public ATNSubjWillNotFToHaveV3TransOrFinNode_v2(ContextOfATNParsing_v2 context, ATNSubjWillNotFToHaveV3TransOrFinNode_v2 sameNode, InitATNSubjWillNotFToHaveV3TransOrFinNodeAction initAction, ATNExtendedToken token)
            : base(context, token)
        {
            mSameNode = sameNode;
            mInitAction = initAction;
            ParentNode = mSameNode.ParentNode;
            mInitAction?.Invoke(this);
        }

        public override StateOfATNParsing_v2 GlobalState => StateOfATNParsing_v2.Subj_Will_Not_FToHave_V3_TransOrFin;

        public ATNSubjWillNotFToHaveTransNode_v2 ParentNode { get; private set; }
        private ATNSubjWillNotFToHaveV3TransOrFinNode_v2 mSameNode;
        private InitATNSubjWillNotFToHaveV3TransOrFinNodeAction mInitAction;

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

