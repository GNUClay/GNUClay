using MyNPCLib.NLToCGParsing;
using System;
using System.Collections.Generic;
using System.Text;

namespace MyNPCLib.NLToCGParsing_v2.ATNNodes
{
    public delegate void InitATNConditionSubjFToHaveNotBeenConditionV3TransOrFinNodeAction(ATNConditionSubjFToHaveNotBeenConditionV3TransOrFinNode_v2 item);

    public class ATNConditionSubjFToHaveNotBeenConditionV3TransOrFinNodeFactory_v2: BaseATNNodeFactory_v2
    {
        public ATNConditionSubjFToHaveNotBeenConditionV3TransOrFinNodeFactory_v2(ATNConditionSubjFToHaveNotBeenConditionTransNode_v2 parentNode, ATNExtendedToken token)
        {
            mNumberOfConstructor = 1;
            mParentNode = parentNode;
            mToken = token;
        }

        public ATNConditionSubjFToHaveNotBeenConditionV3TransOrFinNodeFactory_v2(ATNConditionSubjFToHaveNotBeenConditionV3TransOrFinNode_v2 sameNode, ATNExtendedToken token, InitATNConditionSubjFToHaveNotBeenConditionV3TransOrFinNodeAction initAction)
        {
            mNumberOfConstructor = 2;
            mSameNode = sameNode;
            mToken = token;
            mInitAction = initAction;
        }

        private int mNumberOfConstructor;
        private ATNConditionSubjFToHaveNotBeenConditionTransNode_v2 mParentNode;
        private ATNConditionSubjFToHaveNotBeenConditionV3TransOrFinNode_v2 mSameNode;
        private ATNExtendedToken mToken;
        private InitATNConditionSubjFToHaveNotBeenConditionV3TransOrFinNodeAction mInitAction;

        public override BaseATNNode_v2 Create(ContextOfATNParsing_v2 context)
        {
            switch(mNumberOfConstructor)
            {
                case 1:
                    return new ATNConditionSubjFToHaveNotBeenConditionV3TransOrFinNode_v2(context, mParentNode, mToken);

                case 2:
                    return new ATNConditionSubjFToHaveNotBeenConditionV3TransOrFinNode_v2(context, mSameNode, mInitAction, mToken);

                default:
                    throw new ArgumentOutOfRangeException(nameof(mNumberOfConstructor), mNumberOfConstructor, null);
            }
        }
    }

/*Sub states:
    Condition_Subj_FToHave_Not_Been_Condition_V3_Obj_TransOrFin
    Condition_Subj_FToHave_Not_Been_Condition_V3_Condition_Fin
*/

    public class ATNConditionSubjFToHaveNotBeenConditionV3TransOrFinNode_v2: BaseATNNode_v2
    {
        public ATNConditionSubjFToHaveNotBeenConditionV3TransOrFinNode_v2(ContextOfATNParsing_v2 context, ATNConditionSubjFToHaveNotBeenConditionTransNode_v2 parentNode, ATNExtendedToken token)
            : base(context, token)
        {
            ParentNode = parentNode;
        }

        public ATNConditionSubjFToHaveNotBeenConditionV3TransOrFinNode_v2(ContextOfATNParsing_v2 context, ATNConditionSubjFToHaveNotBeenConditionV3TransOrFinNode_v2 sameNode, InitATNConditionSubjFToHaveNotBeenConditionV3TransOrFinNodeAction initAction, ATNExtendedToken token)
            : base(context, token)
        {
            mSameNode = sameNode;
            mInitAction = initAction;
            ParentNode = mSameNode.ParentNode;
            mInitAction?.Invoke(this);
        }

        public override StateOfATNParsing_v2 GlobalState => StateOfATNParsing_v2.Condition_Subj_FToHave_Not_Been_Condition_V3_TransOrFin;

        public ATNConditionSubjFToHaveNotBeenConditionTransNode_v2 ParentNode { get; private set; }
        private ATNConditionSubjFToHaveNotBeenConditionV3TransOrFinNode_v2 mSameNode;
        private InitATNConditionSubjFToHaveNotBeenConditionV3TransOrFinNodeAction mInitAction;

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

