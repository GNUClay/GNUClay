using MyNPCLib.NLToCGParsing;
using System;
using System.Collections.Generic;
using System.Text;

namespace MyNPCLib.NLToCGParsing_v2.ATNNodes
{
    public delegate void InitATNConditionSubjFToBeNotV3TransOrFinNodeAction(ATNConditionSubjFToBeNotV3TransOrFinNode_v2 item);

    public class ATNConditionSubjFToBeNotV3TransOrFinNodeFactory_v2: BaseATNNodeFactory_v2
    {
        public ATNConditionSubjFToBeNotV3TransOrFinNodeFactory_v2(ATNConditionSubjFToBeNotTransNode_v2 parentNode, ATNExtendedToken token)
        {
            mNumberOfConstructor = 1;
            mParentNode = parentNode;
            mToken = token;
        }

        public ATNConditionSubjFToBeNotV3TransOrFinNodeFactory_v2(ATNConditionSubjFToBeNotV3TransOrFinNode_v2 sameNode, ATNExtendedToken token, InitATNConditionSubjFToBeNotV3TransOrFinNodeAction initAction)
        {
            mNumberOfConstructor = 2;
            mSameNode = sameNode;
            mToken = token;
            mInitAction = initAction;
        }

        private int mNumberOfConstructor;
        private ATNConditionSubjFToBeNotTransNode_v2 mParentNode;
        private ATNConditionSubjFToBeNotV3TransOrFinNode_v2 mSameNode;
        private ATNExtendedToken mToken;
        private InitATNConditionSubjFToBeNotV3TransOrFinNodeAction mInitAction;

        public override BaseATNNode_v2 Create(ContextOfATNParsing_v2 context)
        {
            switch(mNumberOfConstructor)
            {
                case 1:
                    return new ATNConditionSubjFToBeNotV3TransOrFinNode_v2(context, mParentNode, mToken);

                case 2:
                    return new ATNConditionSubjFToBeNotV3TransOrFinNode_v2(context, mSameNode, mInitAction, mToken);

                default:
                    throw new ArgumentOutOfRangeException(nameof(mNumberOfConstructor), mNumberOfConstructor, null);
            }
        }
    }

/*Sub states:
    Condition_Subj_FToBe_Not_V3_Obj_TransOrFin
    Condition_Subj_FToBe_Not_V3_Condition_Fin
*/

    public class ATNConditionSubjFToBeNotV3TransOrFinNode_v2: BaseATNNode_v2
    {
        public ATNConditionSubjFToBeNotV3TransOrFinNode_v2(ContextOfATNParsing_v2 context, ATNConditionSubjFToBeNotTransNode_v2 parentNode, ATNExtendedToken token)
            : base(context, token)
        {
            ParentNode = parentNode;
        }

        public ATNConditionSubjFToBeNotV3TransOrFinNode_v2(ContextOfATNParsing_v2 context, ATNConditionSubjFToBeNotV3TransOrFinNode_v2 sameNode, InitATNConditionSubjFToBeNotV3TransOrFinNodeAction initAction, ATNExtendedToken token)
            : base(context, token)
        {
            mSameNode = sameNode;
            mInitAction = initAction;
            ParentNode = mSameNode.ParentNode;
            mInitAction?.Invoke(this);
        }

        public override StateOfATNParsing_v2 GlobalState => StateOfATNParsing_v2.Condition_Subj_FToBe_Not_V3_TransOrFin;

        public ATNConditionSubjFToBeNotTransNode_v2 ParentNode { get; private set; }
        private ATNConditionSubjFToBeNotV3TransOrFinNode_v2 mSameNode;
        private InitATNConditionSubjFToBeNotV3TransOrFinNodeAction mInitAction;

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

