using MyNPCLib.NLToCGParsing;
using System;
using System.Collections.Generic;
using System.Text;

namespace MyNPCLib.NLToCGParsing_v2.ATNNodes
{
    public delegate void InitATNConditionQWSubjWillFToHaveBeenV3NoTransNodeAction(ATNConditionQWSubjWillFToHaveBeenV3NoTransNode_v2 item);

    public class ATNConditionQWSubjWillFToHaveBeenV3NoTransNodeFactory_v2: BaseATNNodeFactory_v2
    {
        public ATNConditionQWSubjWillFToHaveBeenV3NoTransNodeFactory_v2(ATNConditionQWSubjWillFToHaveBeenV3TransOrFinNode_v2 parentNode, ATNExtendedToken token)
        {
            mNumberOfConstructor = 1;
            mParentNode = parentNode;
            mToken = token;
        }

        public ATNConditionQWSubjWillFToHaveBeenV3NoTransNodeFactory_v2(ATNConditionQWSubjWillFToHaveBeenV3NoTransNode_v2 sameNode, ATNExtendedToken token, InitATNConditionQWSubjWillFToHaveBeenV3NoTransNodeAction initAction)
        {
            mNumberOfConstructor = 2;
            mSameNode = sameNode;
            mToken = token;
            mInitAction = initAction;
        }

        private int mNumberOfConstructor;
        private ATNConditionQWSubjWillFToHaveBeenV3TransOrFinNode_v2 mParentNode;
        private ATNConditionQWSubjWillFToHaveBeenV3NoTransNode_v2 mSameNode;
        private ATNExtendedToken mToken;
        private InitATNConditionQWSubjWillFToHaveBeenV3NoTransNodeAction mInitAction;

        public override BaseATNNode_v2 Create(ContextOfATNParsing_v2 context)
        {
            switch(mNumberOfConstructor)
            {
                case 1:
                    return new ATNConditionQWSubjWillFToHaveBeenV3NoTransNode_v2(context, mParentNode, mToken);

                case 2:
                    return new ATNConditionQWSubjWillFToHaveBeenV3NoTransNode_v2(context, mSameNode, mInitAction, mToken);

                default:
                    throw new ArgumentOutOfRangeException(nameof(mNumberOfConstructor), mNumberOfConstructor, null);
            }
        }
    }

/*Sub states:
    Condition_QWSubj_Will_FToHave_Been_V3_No_Obj_TransOrFin
*/

    public class ATNConditionQWSubjWillFToHaveBeenV3NoTransNode_v2: BaseATNNode_v2
    {
        public ATNConditionQWSubjWillFToHaveBeenV3NoTransNode_v2(ContextOfATNParsing_v2 context, ATNConditionQWSubjWillFToHaveBeenV3TransOrFinNode_v2 parentNode, ATNExtendedToken token)
            : base(context, token)
        {
            ParentNode = parentNode;
        }

        public ATNConditionQWSubjWillFToHaveBeenV3NoTransNode_v2(ContextOfATNParsing_v2 context, ATNConditionQWSubjWillFToHaveBeenV3NoTransNode_v2 sameNode, InitATNConditionQWSubjWillFToHaveBeenV3NoTransNodeAction initAction, ATNExtendedToken token)
            : base(context, token)
        {
            mSameNode = sameNode;
            mInitAction = initAction;
            ParentNode = mSameNode.ParentNode;
            mInitAction?.Invoke(this);
        }

        public override StateOfATNParsing_v2 GlobalState => StateOfATNParsing_v2.Condition_QWSubj_Will_FToHave_Been_V3_No_Trans;

        public ATNConditionQWSubjWillFToHaveBeenV3TransOrFinNode_v2 ParentNode { get; private set; }
        private ATNConditionQWSubjWillFToHaveBeenV3NoTransNode_v2 mSameNode;
        private InitATNConditionQWSubjWillFToHaveBeenV3NoTransNodeAction mInitAction;

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

