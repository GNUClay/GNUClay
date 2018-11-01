using MyNPCLib.NLToCGParsing;
using System;
using System.Collections.Generic;
using System.Text;

namespace MyNPCLib.NLToCGParsing_v2.ATNNodes
{
    public delegate void InitATNConditionSubjFToHaveBeenV3NoTransNodeAction(ATNConditionSubjFToHaveBeenV3NoTransNode_v2 item);

    public class ATNConditionSubjFToHaveBeenV3NoTransNodeFactory_v2: BaseATNNodeFactory_v2
    {
        public ATNConditionSubjFToHaveBeenV3NoTransNodeFactory_v2(ATNConditionSubjFToHaveBeenV3TransOrFinNode_v2 parentNode, ATNExtendedToken token)
        {
            mNumberOfConstructor = 1;
            mParentNode = parentNode;
            mToken = token;
        }

        public ATNConditionSubjFToHaveBeenV3NoTransNodeFactory_v2(ATNConditionSubjFToHaveBeenV3NoTransNode_v2 sameNode, ATNExtendedToken token, InitATNConditionSubjFToHaveBeenV3NoTransNodeAction initAction)
        {
            mNumberOfConstructor = 2;
            mSameNode = sameNode;
            mToken = token;
            mInitAction = initAction;
        }

        private int mNumberOfConstructor;
        private ATNConditionSubjFToHaveBeenV3TransOrFinNode_v2 mParentNode;
        private ATNConditionSubjFToHaveBeenV3NoTransNode_v2 mSameNode;
        private ATNExtendedToken mToken;
        private InitATNConditionSubjFToHaveBeenV3NoTransNodeAction mInitAction;

        public override BaseATNNode_v2 Create(ContextOfATNParsing_v2 context)
        {
            switch(mNumberOfConstructor)
            {
                case 1:
                    return new ATNConditionSubjFToHaveBeenV3NoTransNode_v2(context, mParentNode, mToken);

                case 2:
                    return new ATNConditionSubjFToHaveBeenV3NoTransNode_v2(context, mSameNode, mInitAction, mToken);

                default:
                    throw new ArgumentOutOfRangeException(nameof(mNumberOfConstructor), mNumberOfConstructor, null);
            }
        }
    }

/*Sub states:
    Condition_Subj_FToHave_Been_V3_No_Obj_TransOrFin
*/

    public class ATNConditionSubjFToHaveBeenV3NoTransNode_v2: BaseATNNode_v2
    {
        public ATNConditionSubjFToHaveBeenV3NoTransNode_v2(ContextOfATNParsing_v2 context, ATNConditionSubjFToHaveBeenV3TransOrFinNode_v2 parentNode, ATNExtendedToken token)
            : base(context, token)
        {
            ParentNode = parentNode;
        }

        public ATNConditionSubjFToHaveBeenV3NoTransNode_v2(ContextOfATNParsing_v2 context, ATNConditionSubjFToHaveBeenV3NoTransNode_v2 sameNode, InitATNConditionSubjFToHaveBeenV3NoTransNodeAction initAction, ATNExtendedToken token)
            : base(context, token)
        {
            mSameNode = sameNode;
            mInitAction = initAction;
            ParentNode = mSameNode.ParentNode;
            mInitAction?.Invoke(this);
        }

        public override StateOfATNParsing_v2 GlobalState => StateOfATNParsing_v2.Condition_Subj_FToHave_Been_V3_No_Trans;

        public ATNConditionSubjFToHaveBeenV3TransOrFinNode_v2 ParentNode { get; private set; }
        private ATNConditionSubjFToHaveBeenV3NoTransNode_v2 mSameNode;
        private InitATNConditionSubjFToHaveBeenV3NoTransNodeAction mInitAction;

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

