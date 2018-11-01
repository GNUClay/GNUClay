using MyNPCLib.NLToCGParsing;
using System;
using System.Collections.Generic;
using System.Text;

namespace MyNPCLib.NLToCGParsing_v2.ATNNodes
{
    public delegate void InitATNQWSubjWillFToHaveBeenConditionV3NoTransNodeAction(ATNQWSubjWillFToHaveBeenConditionV3NoTransNode_v2 item);

    public class ATNQWSubjWillFToHaveBeenConditionV3NoTransNodeFactory_v2: BaseATNNodeFactory_v2
    {
        public ATNQWSubjWillFToHaveBeenConditionV3NoTransNodeFactory_v2(ATNQWSubjWillFToHaveBeenConditionV3TransOrFinNode_v2 parentNode, ATNExtendedToken token)
        {
            mNumberOfConstructor = 1;
            mParentNode = parentNode;
            mToken = token;
        }

        public ATNQWSubjWillFToHaveBeenConditionV3NoTransNodeFactory_v2(ATNQWSubjWillFToHaveBeenConditionV3NoTransNode_v2 sameNode, ATNExtendedToken token, InitATNQWSubjWillFToHaveBeenConditionV3NoTransNodeAction initAction)
        {
            mNumberOfConstructor = 2;
            mSameNode = sameNode;
            mToken = token;
            mInitAction = initAction;
        }

        private int mNumberOfConstructor;
        private ATNQWSubjWillFToHaveBeenConditionV3TransOrFinNode_v2 mParentNode;
        private ATNQWSubjWillFToHaveBeenConditionV3NoTransNode_v2 mSameNode;
        private ATNExtendedToken mToken;
        private InitATNQWSubjWillFToHaveBeenConditionV3NoTransNodeAction mInitAction;

        public override BaseATNNode_v2 Create(ContextOfATNParsing_v2 context)
        {
            switch(mNumberOfConstructor)
            {
                case 1:
                    return new ATNQWSubjWillFToHaveBeenConditionV3NoTransNode_v2(context, mParentNode, mToken);

                case 2:
                    return new ATNQWSubjWillFToHaveBeenConditionV3NoTransNode_v2(context, mSameNode, mInitAction, mToken);

                default:
                    throw new ArgumentOutOfRangeException(nameof(mNumberOfConstructor), mNumberOfConstructor, null);
            }
        }
    }

/*Sub states:
    QWSubj_Will_FToHave_Been_Condition_V3_No_Obj_TransOrFin
*/

    public class ATNQWSubjWillFToHaveBeenConditionV3NoTransNode_v2: BaseATNNode_v2
    {
        public ATNQWSubjWillFToHaveBeenConditionV3NoTransNode_v2(ContextOfATNParsing_v2 context, ATNQWSubjWillFToHaveBeenConditionV3TransOrFinNode_v2 parentNode, ATNExtendedToken token)
            : base(context, token)
        {
            ParentNode = parentNode;
        }

        public ATNQWSubjWillFToHaveBeenConditionV3NoTransNode_v2(ContextOfATNParsing_v2 context, ATNQWSubjWillFToHaveBeenConditionV3NoTransNode_v2 sameNode, InitATNQWSubjWillFToHaveBeenConditionV3NoTransNodeAction initAction, ATNExtendedToken token)
            : base(context, token)
        {
            mSameNode = sameNode;
            mInitAction = initAction;
            ParentNode = mSameNode.ParentNode;
            mInitAction?.Invoke(this);
        }

        public override StateOfATNParsing_v2 GlobalState => StateOfATNParsing_v2.QWSubj_Will_FToHave_Been_Condition_V3_No_Trans;

        public ATNQWSubjWillFToHaveBeenConditionV3TransOrFinNode_v2 ParentNode { get; private set; }
        private ATNQWSubjWillFToHaveBeenConditionV3NoTransNode_v2 mSameNode;
        private InitATNQWSubjWillFToHaveBeenConditionV3NoTransNodeAction mInitAction;

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

