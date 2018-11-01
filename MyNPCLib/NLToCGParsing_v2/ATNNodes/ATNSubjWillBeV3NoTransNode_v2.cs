using MyNPCLib.NLToCGParsing;
using System;
using System.Collections.Generic;
using System.Text;

namespace MyNPCLib.NLToCGParsing_v2.ATNNodes
{
    public delegate void InitATNSubjWillBeV3NoTransNodeAction(ATNSubjWillBeV3NoTransNode_v2 item);

    public class ATNSubjWillBeV3NoTransNodeFactory_v2: BaseATNNodeFactory_v2
    {
        public ATNSubjWillBeV3NoTransNodeFactory_v2(ATNSubjWillBeV3TransOrFinNode_v2 parentNode, ATNExtendedToken token)
        {
            mNumberOfConstructor = 1;
            mParentNode = parentNode;
            mToken = token;
        }

        public ATNSubjWillBeV3NoTransNodeFactory_v2(ATNSubjWillBeV3NoTransNode_v2 sameNode, ATNExtendedToken token, InitATNSubjWillBeV3NoTransNodeAction initAction)
        {
            mNumberOfConstructor = 2;
            mSameNode = sameNode;
            mToken = token;
            mInitAction = initAction;
        }

        private int mNumberOfConstructor;
        private ATNSubjWillBeV3TransOrFinNode_v2 mParentNode;
        private ATNSubjWillBeV3NoTransNode_v2 mSameNode;
        private ATNExtendedToken mToken;
        private InitATNSubjWillBeV3NoTransNodeAction mInitAction;

        public override BaseATNNode_v2 Create(ContextOfATNParsing_v2 context)
        {
            switch(mNumberOfConstructor)
            {
                case 1:
                    return new ATNSubjWillBeV3NoTransNode_v2(context, mParentNode, mToken);

                case 2:
                    return new ATNSubjWillBeV3NoTransNode_v2(context, mSameNode, mInitAction, mToken);

                default:
                    throw new ArgumentOutOfRangeException(nameof(mNumberOfConstructor), mNumberOfConstructor, null);
            }
        }
    }

/*Sub states:
    Subj_Will_Be_V3_No_Obj_TransOrFin
*/

    public class ATNSubjWillBeV3NoTransNode_v2: BaseATNNode_v2
    {
        public ATNSubjWillBeV3NoTransNode_v2(ContextOfATNParsing_v2 context, ATNSubjWillBeV3TransOrFinNode_v2 parentNode, ATNExtendedToken token)
            : base(context, token)
        {
            ParentNode = parentNode;
        }

        public ATNSubjWillBeV3NoTransNode_v2(ContextOfATNParsing_v2 context, ATNSubjWillBeV3NoTransNode_v2 sameNode, InitATNSubjWillBeV3NoTransNodeAction initAction, ATNExtendedToken token)
            : base(context, token)
        {
            mSameNode = sameNode;
            mInitAction = initAction;
            ParentNode = mSameNode.ParentNode;
            mInitAction?.Invoke(this);
        }

        public override StateOfATNParsing_v2 GlobalState => StateOfATNParsing_v2.Subj_Will_Be_V3_No_Trans;

        public ATNSubjWillBeV3TransOrFinNode_v2 ParentNode { get; private set; }
        private ATNSubjWillBeV3NoTransNode_v2 mSameNode;
        private InitATNSubjWillBeV3NoTransNodeAction mInitAction;

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

