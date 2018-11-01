using MyNPCLib.NLToCGParsing;
using System;
using System.Collections.Generic;
using System.Text;

namespace MyNPCLib.NLToCGParsing_v2.ATNNodes
{
    public delegate void InitATNWillSubjBeV3NoTransNodeAction(ATNWillSubjBeV3NoTransNode_v2 item);

    public class ATNWillSubjBeV3NoTransNodeFactory_v2: BaseATNNodeFactory_v2
    {
        public ATNWillSubjBeV3NoTransNodeFactory_v2(ATNWillSubjBeV3TransOrFinNode_v2 parentNode, ATNExtendedToken token)
        {
            mNumberOfConstructor = 1;
            mParentNode = parentNode;
            mToken = token;
        }

        public ATNWillSubjBeV3NoTransNodeFactory_v2(ATNWillSubjBeV3NoTransNode_v2 sameNode, ATNExtendedToken token, InitATNWillSubjBeV3NoTransNodeAction initAction)
        {
            mNumberOfConstructor = 2;
            mSameNode = sameNode;
            mToken = token;
            mInitAction = initAction;
        }

        private int mNumberOfConstructor;
        private ATNWillSubjBeV3TransOrFinNode_v2 mParentNode;
        private ATNWillSubjBeV3NoTransNode_v2 mSameNode;
        private ATNExtendedToken mToken;
        private InitATNWillSubjBeV3NoTransNodeAction mInitAction;

        public override BaseATNNode_v2 Create(ContextOfATNParsing_v2 context)
        {
            switch(mNumberOfConstructor)
            {
                case 1:
                    return new ATNWillSubjBeV3NoTransNode_v2(context, mParentNode, mToken);

                case 2:
                    return new ATNWillSubjBeV3NoTransNode_v2(context, mSameNode, mInitAction, mToken);

                default:
                    throw new ArgumentOutOfRangeException(nameof(mNumberOfConstructor), mNumberOfConstructor, null);
            }
        }
    }

/*Sub states:
    Will_Subj_Be_V3_No_Obj_TransOrFin
*/

    public class ATNWillSubjBeV3NoTransNode_v2: BaseATNNode_v2
    {
        public ATNWillSubjBeV3NoTransNode_v2(ContextOfATNParsing_v2 context, ATNWillSubjBeV3TransOrFinNode_v2 parentNode, ATNExtendedToken token)
            : base(context, token)
        {
            ParentNode = parentNode;
        }

        public ATNWillSubjBeV3NoTransNode_v2(ContextOfATNParsing_v2 context, ATNWillSubjBeV3NoTransNode_v2 sameNode, InitATNWillSubjBeV3NoTransNodeAction initAction, ATNExtendedToken token)
            : base(context, token)
        {
            mSameNode = sameNode;
            mInitAction = initAction;
            ParentNode = mSameNode.ParentNode;
            mInitAction?.Invoke(this);
        }

        public override StateOfATNParsing_v2 GlobalState => StateOfATNParsing_v2.Will_Subj_Be_V3_No_Trans;

        public ATNWillSubjBeV3TransOrFinNode_v2 ParentNode { get; private set; }
        private ATNWillSubjBeV3NoTransNode_v2 mSameNode;
        private InitATNWillSubjBeV3NoTransNodeAction mInitAction;

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

