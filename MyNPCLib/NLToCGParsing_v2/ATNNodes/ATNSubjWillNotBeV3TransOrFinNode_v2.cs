using MyNPCLib.NLToCGParsing;
using System;
using System.Collections.Generic;
using System.Text;

namespace MyNPCLib.NLToCGParsing_v2.ATNNodes
{
    public delegate void InitATNSubjWillNotBeV3TransOrFinNodeAction(ATNSubjWillNotBeV3TransOrFinNode_v2 item);

    public class ATNSubjWillNotBeV3TransOrFinNodeFactory_v2: BaseATNNodeFactory_v2
    {
        public ATNSubjWillNotBeV3TransOrFinNodeFactory_v2(ATNSubjWillNotBeTransNode_v2 parentNode, ATNExtendedToken token)
        {
            mNumberOfConstructor = 1;
            mParentNode = parentNode;
            mToken = token;
        }

        public ATNSubjWillNotBeV3TransOrFinNodeFactory_v2(ATNSubjWillNotBeV3TransOrFinNode_v2 sameNode, ATNExtendedToken token, InitATNSubjWillNotBeV3TransOrFinNodeAction initAction)
        {
            mNumberOfConstructor = 2;
            mSameNode = sameNode;
            mToken = token;
            mInitAction = initAction;
        }

        private int mNumberOfConstructor;
        private ATNSubjWillNotBeTransNode_v2 mParentNode;
        private ATNSubjWillNotBeV3TransOrFinNode_v2 mSameNode;
        private ATNExtendedToken mToken;
        private InitATNSubjWillNotBeV3TransOrFinNodeAction mInitAction;

        public override BaseATNNode_v2 Create(ContextOfATNParsing_v2 context)
        {
            switch(mNumberOfConstructor)
            {
                case 1:
                    return new ATNSubjWillNotBeV3TransOrFinNode_v2(context, mParentNode, mToken);

                case 2:
                    return new ATNSubjWillNotBeV3TransOrFinNode_v2(context, mSameNode, mInitAction, mToken);

                default:
                    throw new ArgumentOutOfRangeException(nameof(mNumberOfConstructor), mNumberOfConstructor, null);
            }
        }
    }

/*Sub states:
    Subj_Will_Not_Be_V3_Obj_TransOrFin
    Subj_Will_Not_Be_V3_Condition_Fin
*/

    public class ATNSubjWillNotBeV3TransOrFinNode_v2: BaseATNNode_v2
    {
        public ATNSubjWillNotBeV3TransOrFinNode_v2(ContextOfATNParsing_v2 context, ATNSubjWillNotBeTransNode_v2 parentNode, ATNExtendedToken token)
            : base(context, token)
        {
            ParentNode = parentNode;
        }

        public ATNSubjWillNotBeV3TransOrFinNode_v2(ContextOfATNParsing_v2 context, ATNSubjWillNotBeV3TransOrFinNode_v2 sameNode, InitATNSubjWillNotBeV3TransOrFinNodeAction initAction, ATNExtendedToken token)
            : base(context, token)
        {
            mSameNode = sameNode;
            mInitAction = initAction;
            ParentNode = mSameNode.ParentNode;
            mInitAction?.Invoke(this);
        }

        public override StateOfATNParsing_v2 GlobalState => StateOfATNParsing_v2.Subj_Will_Not_Be_V3_TransOrFin;

        public ATNSubjWillNotBeTransNode_v2 ParentNode { get; private set; }
        private ATNSubjWillNotBeV3TransOrFinNode_v2 mSameNode;
        private InitATNSubjWillNotBeV3TransOrFinNodeAction mInitAction;

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

