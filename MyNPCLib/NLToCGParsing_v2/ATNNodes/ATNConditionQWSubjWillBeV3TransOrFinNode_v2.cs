using MyNPCLib.NLToCGParsing;
using System;
using System.Collections.Generic;
using System.Text;

namespace MyNPCLib.NLToCGParsing_v2.ATNNodes
{
    public delegate void InitATNConditionQWSubjWillBeV3TransOrFinNodeAction(ATNConditionQWSubjWillBeV3TransOrFinNode_v2 item);

    public class ATNConditionQWSubjWillBeV3TransOrFinNodeFactory_v2: BaseATNNodeFactory_v2
    {
        public ATNConditionQWSubjWillBeV3TransOrFinNodeFactory_v2(ATNConditionQWSubjWillBeTransNode_v2 parentNode, ATNExtendedToken token)
        {
            mNumberOfConstructor = 1;
            mParentNode = parentNode;
            mToken = token;
        }

        public ATNConditionQWSubjWillBeV3TransOrFinNodeFactory_v2(ATNConditionQWSubjWillBeV3TransOrFinNode_v2 sameNode, ATNExtendedToken token, InitATNConditionQWSubjWillBeV3TransOrFinNodeAction initAction)
        {
            mNumberOfConstructor = 2;
            mSameNode = sameNode;
            mToken = token;
            mInitAction = initAction;
        }

        private int mNumberOfConstructor;
        private ATNConditionQWSubjWillBeTransNode_v2 mParentNode;
        private ATNConditionQWSubjWillBeV3TransOrFinNode_v2 mSameNode;
        private ATNExtendedToken mToken;
        private InitATNConditionQWSubjWillBeV3TransOrFinNodeAction mInitAction;

        public override BaseATNNode_v2 Create(ContextOfATNParsing_v2 context)
        {
            switch(mNumberOfConstructor)
            {
                case 1:
                    return new ATNConditionQWSubjWillBeV3TransOrFinNode_v2(context, mParentNode, mToken);

                case 2:
                    return new ATNConditionQWSubjWillBeV3TransOrFinNode_v2(context, mSameNode, mInitAction, mToken);

                default:
                    throw new ArgumentOutOfRangeException(nameof(mNumberOfConstructor), mNumberOfConstructor, null);
            }
        }
    }

/*Sub states:
    Condition_QWSubj_Will_Be_V3_Obj_TransOrFin
    Condition_QWSubj_Will_Be_V3_No_Trans
    Condition_QWSubj_Will_Be_V3_Condition_Fin
*/

    public class ATNConditionQWSubjWillBeV3TransOrFinNode_v2: BaseATNNode_v2
    {
        public ATNConditionQWSubjWillBeV3TransOrFinNode_v2(ContextOfATNParsing_v2 context, ATNConditionQWSubjWillBeTransNode_v2 parentNode, ATNExtendedToken token)
            : base(context, token)
        {
            ParentNode = parentNode;
        }

        public ATNConditionQWSubjWillBeV3TransOrFinNode_v2(ContextOfATNParsing_v2 context, ATNConditionQWSubjWillBeV3TransOrFinNode_v2 sameNode, InitATNConditionQWSubjWillBeV3TransOrFinNodeAction initAction, ATNExtendedToken token)
            : base(context, token)
        {
            mSameNode = sameNode;
            mInitAction = initAction;
            ParentNode = mSameNode.ParentNode;
            mInitAction?.Invoke(this);
        }

        public override StateOfATNParsing_v2 GlobalState => StateOfATNParsing_v2.Condition_QWSubj_Will_Be_V3_TransOrFin;

        public ATNConditionQWSubjWillBeTransNode_v2 ParentNode { get; private set; }
        private ATNConditionQWSubjWillBeV3TransOrFinNode_v2 mSameNode;
        private InitATNConditionQWSubjWillBeV3TransOrFinNodeAction mInitAction;

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

