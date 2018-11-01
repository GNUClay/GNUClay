using MyNPCLib.NLToCGParsing;
using System;
using System.Collections.Generic;
using System.Text;

namespace MyNPCLib.NLToCGParsing_v2.ATNNodes
{
    public delegate void InitATNConditionQWObjWillSubjBeV3TransOrFinNodeAction(ATNConditionQWObjWillSubjBeV3TransOrFinNode_v2 item);

    public class ATNConditionQWObjWillSubjBeV3TransOrFinNodeFactory_v2: BaseATNNodeFactory_v2
    {
        public ATNConditionQWObjWillSubjBeV3TransOrFinNodeFactory_v2(ATNConditionQWObjWillSubjBeTransNode_v2 parentNode, ATNExtendedToken token)
        {
            mNumberOfConstructor = 1;
            mParentNode = parentNode;
            mToken = token;
        }

        public ATNConditionQWObjWillSubjBeV3TransOrFinNodeFactory_v2(ATNConditionQWObjWillSubjBeV3TransOrFinNode_v2 sameNode, ATNExtendedToken token, InitATNConditionQWObjWillSubjBeV3TransOrFinNodeAction initAction)
        {
            mNumberOfConstructor = 2;
            mSameNode = sameNode;
            mToken = token;
            mInitAction = initAction;
        }

        private int mNumberOfConstructor;
        private ATNConditionQWObjWillSubjBeTransNode_v2 mParentNode;
        private ATNConditionQWObjWillSubjBeV3TransOrFinNode_v2 mSameNode;
        private ATNExtendedToken mToken;
        private InitATNConditionQWObjWillSubjBeV3TransOrFinNodeAction mInitAction;

        public override BaseATNNode_v2 Create(ContextOfATNParsing_v2 context)
        {
            switch(mNumberOfConstructor)
            {
                case 1:
                    return new ATNConditionQWObjWillSubjBeV3TransOrFinNode_v2(context, mParentNode, mToken);

                case 2:
                    return new ATNConditionQWObjWillSubjBeV3TransOrFinNode_v2(context, mSameNode, mInitAction, mToken);

                default:
                    throw new ArgumentOutOfRangeException(nameof(mNumberOfConstructor), mNumberOfConstructor, null);
            }
        }
    }

/*Sub states:
    Condition_QWObj_Will_Subj_Be_V3_Condition_Fin
*/

    public class ATNConditionQWObjWillSubjBeV3TransOrFinNode_v2: BaseATNNode_v2
    {
        public ATNConditionQWObjWillSubjBeV3TransOrFinNode_v2(ContextOfATNParsing_v2 context, ATNConditionQWObjWillSubjBeTransNode_v2 parentNode, ATNExtendedToken token)
            : base(context, token)
        {
            ParentNode = parentNode;
        }

        public ATNConditionQWObjWillSubjBeV3TransOrFinNode_v2(ContextOfATNParsing_v2 context, ATNConditionQWObjWillSubjBeV3TransOrFinNode_v2 sameNode, InitATNConditionQWObjWillSubjBeV3TransOrFinNodeAction initAction, ATNExtendedToken token)
            : base(context, token)
        {
            mSameNode = sameNode;
            mInitAction = initAction;
            ParentNode = mSameNode.ParentNode;
            mInitAction?.Invoke(this);
        }

        public override StateOfATNParsing_v2 GlobalState => StateOfATNParsing_v2.Condition_QWObj_Will_Subj_Be_V3_TransOrFin;

        public ATNConditionQWObjWillSubjBeTransNode_v2 ParentNode { get; private set; }
        private ATNConditionQWObjWillSubjBeV3TransOrFinNode_v2 mSameNode;
        private InitATNConditionQWObjWillSubjBeV3TransOrFinNodeAction mInitAction;

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

