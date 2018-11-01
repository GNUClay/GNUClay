using MyNPCLib.NLToCGParsing;
using System;
using System.Collections.Generic;
using System.Text;

namespace MyNPCLib.NLToCGParsing_v2.ATNNodes
{
    public delegate void InitATNWillSubjFToHaveBeenConditionV3TransOrFinNodeAction(ATNWillSubjFToHaveBeenConditionV3TransOrFinNode_v2 item);

    public class ATNWillSubjFToHaveBeenConditionV3TransOrFinNodeFactory_v2: BaseATNNodeFactory_v2
    {
        public ATNWillSubjFToHaveBeenConditionV3TransOrFinNodeFactory_v2(ATNWillSubjFToHaveBeenConditionTransNode_v2 parentNode, ATNExtendedToken token)
        {
            mNumberOfConstructor = 1;
            mParentNode = parentNode;
            mToken = token;
        }

        public ATNWillSubjFToHaveBeenConditionV3TransOrFinNodeFactory_v2(ATNWillSubjFToHaveBeenConditionV3TransOrFinNode_v2 sameNode, ATNExtendedToken token, InitATNWillSubjFToHaveBeenConditionV3TransOrFinNodeAction initAction)
        {
            mNumberOfConstructor = 2;
            mSameNode = sameNode;
            mToken = token;
            mInitAction = initAction;
        }

        private int mNumberOfConstructor;
        private ATNWillSubjFToHaveBeenConditionTransNode_v2 mParentNode;
        private ATNWillSubjFToHaveBeenConditionV3TransOrFinNode_v2 mSameNode;
        private ATNExtendedToken mToken;
        private InitATNWillSubjFToHaveBeenConditionV3TransOrFinNodeAction mInitAction;

        public override BaseATNNode_v2 Create(ContextOfATNParsing_v2 context)
        {
            switch(mNumberOfConstructor)
            {
                case 1:
                    return new ATNWillSubjFToHaveBeenConditionV3TransOrFinNode_v2(context, mParentNode, mToken);

                case 2:
                    return new ATNWillSubjFToHaveBeenConditionV3TransOrFinNode_v2(context, mSameNode, mInitAction, mToken);

                default:
                    throw new ArgumentOutOfRangeException(nameof(mNumberOfConstructor), mNumberOfConstructor, null);
            }
        }
    }

/*Sub states:
    Will_Subj_FToHave_Been_Condition_V3_Obj_TransOrFin
    Will_Subj_FToHave_Been_Condition_V3_No_Trans
    Will_Subj_FToHave_Been_Condition_V3_Condition_Fin
*/

    public class ATNWillSubjFToHaveBeenConditionV3TransOrFinNode_v2: BaseATNNode_v2
    {
        public ATNWillSubjFToHaveBeenConditionV3TransOrFinNode_v2(ContextOfATNParsing_v2 context, ATNWillSubjFToHaveBeenConditionTransNode_v2 parentNode, ATNExtendedToken token)
            : base(context, token)
        {
            ParentNode = parentNode;
        }

        public ATNWillSubjFToHaveBeenConditionV3TransOrFinNode_v2(ContextOfATNParsing_v2 context, ATNWillSubjFToHaveBeenConditionV3TransOrFinNode_v2 sameNode, InitATNWillSubjFToHaveBeenConditionV3TransOrFinNodeAction initAction, ATNExtendedToken token)
            : base(context, token)
        {
            mSameNode = sameNode;
            mInitAction = initAction;
            ParentNode = mSameNode.ParentNode;
            mInitAction?.Invoke(this);
        }

        public override StateOfATNParsing_v2 GlobalState => StateOfATNParsing_v2.Will_Subj_FToHave_Been_Condition_V3_TransOrFin;

        public ATNWillSubjFToHaveBeenConditionTransNode_v2 ParentNode { get; private set; }
        private ATNWillSubjFToHaveBeenConditionV3TransOrFinNode_v2 mSameNode;
        private InitATNWillSubjFToHaveBeenConditionV3TransOrFinNodeAction mInitAction;

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

