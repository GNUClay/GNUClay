using MyNPCLib.NLToCGParsing;
using System;
using System.Collections.Generic;
using System.Text;

namespace MyNPCLib.NLToCGParsing_v2.ATNNodes
{
    public delegate void InitATNWillSubjBeV3TransOrFinNodeAction(ATNWillSubjBeV3TransOrFinNode_v2 item);

    public class ATNWillSubjBeV3TransOrFinNodeFactory_v2: BaseATNNodeFactory_v2
    {
        public ATNWillSubjBeV3TransOrFinNodeFactory_v2(ATNWillSubjBeTransNode_v2 parentNode, ATNExtendedToken token)
        {
            mNumberOfConstructor = 1;
            mParentNode = parentNode;
            mToken = token;
        }

        public ATNWillSubjBeV3TransOrFinNodeFactory_v2(ATNWillSubjBeV3TransOrFinNode_v2 sameNode, ATNExtendedToken token, InitATNWillSubjBeV3TransOrFinNodeAction initAction)
        {
            mNumberOfConstructor = 2;
            mSameNode = sameNode;
            mToken = token;
            mInitAction = initAction;
        }

        private int mNumberOfConstructor;
        private ATNWillSubjBeTransNode_v2 mParentNode;
        private ATNWillSubjBeV3TransOrFinNode_v2 mSameNode;
        private ATNExtendedToken mToken;
        private InitATNWillSubjBeV3TransOrFinNodeAction mInitAction;

        public override BaseATNNode_v2 Create(ContextOfATNParsing_v2 context)
        {
            switch(mNumberOfConstructor)
            {
                case 1:
                    return new ATNWillSubjBeV3TransOrFinNode_v2(context, mParentNode, mToken);

                case 2:
                    return new ATNWillSubjBeV3TransOrFinNode_v2(context, mSameNode, mInitAction, mToken);

                default:
                    throw new ArgumentOutOfRangeException(nameof(mNumberOfConstructor), mNumberOfConstructor, null);
            }
        }
    }

/*Sub states:
    Will_Subj_Be_V3_Obj_TransOrFin
    Will_Subj_Be_V3_No_Trans
    Will_Subj_Be_V3_Condition_Fin
*/

    public class ATNWillSubjBeV3TransOrFinNode_v2: BaseATNNode_v2
    {
        public ATNWillSubjBeV3TransOrFinNode_v2(ContextOfATNParsing_v2 context, ATNWillSubjBeTransNode_v2 parentNode, ATNExtendedToken token)
            : base(context, token)
        {
            ParentNode = parentNode;
        }

        public ATNWillSubjBeV3TransOrFinNode_v2(ContextOfATNParsing_v2 context, ATNWillSubjBeV3TransOrFinNode_v2 sameNode, InitATNWillSubjBeV3TransOrFinNodeAction initAction, ATNExtendedToken token)
            : base(context, token)
        {
            mSameNode = sameNode;
            mInitAction = initAction;
            ParentNode = mSameNode.ParentNode;
            mInitAction?.Invoke(this);
        }

        public override StateOfATNParsing_v2 GlobalState => StateOfATNParsing_v2.Will_Subj_Be_V3_TransOrFin;

        public ATNWillSubjBeTransNode_v2 ParentNode { get; private set; }
        private ATNWillSubjBeV3TransOrFinNode_v2 mSameNode;
        private InitATNWillSubjBeV3TransOrFinNodeAction mInitAction;

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

