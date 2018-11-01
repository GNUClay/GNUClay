using MyNPCLib.NLToCGParsing;
using System;
using System.Collections.Generic;
using System.Text;

namespace MyNPCLib.NLToCGParsing_v2.ATNNodes
{
    public delegate void InitATNConditionQWSubjWillFToHaveBeenConditionV3TransOrFinNodeAction(ATNConditionQWSubjWillFToHaveBeenConditionV3TransOrFinNode_v2 item);

    public class ATNConditionQWSubjWillFToHaveBeenConditionV3TransOrFinNodeFactory_v2: BaseATNNodeFactory_v2
    {
        public ATNConditionQWSubjWillFToHaveBeenConditionV3TransOrFinNodeFactory_v2(ATNConditionQWSubjWillFToHaveBeenConditionTransNode_v2 parentNode, ATNExtendedToken token)
        {
            mNumberOfConstructor = 1;
            mParentNode = parentNode;
            mToken = token;
        }

        public ATNConditionQWSubjWillFToHaveBeenConditionV3TransOrFinNodeFactory_v2(ATNConditionQWSubjWillFToHaveBeenConditionV3TransOrFinNode_v2 sameNode, ATNExtendedToken token, InitATNConditionQWSubjWillFToHaveBeenConditionV3TransOrFinNodeAction initAction)
        {
            mNumberOfConstructor = 2;
            mSameNode = sameNode;
            mToken = token;
            mInitAction = initAction;
        }

        private int mNumberOfConstructor;
        private ATNConditionQWSubjWillFToHaveBeenConditionTransNode_v2 mParentNode;
        private ATNConditionQWSubjWillFToHaveBeenConditionV3TransOrFinNode_v2 mSameNode;
        private ATNExtendedToken mToken;
        private InitATNConditionQWSubjWillFToHaveBeenConditionV3TransOrFinNodeAction mInitAction;

        public override BaseATNNode_v2 Create(ContextOfATNParsing_v2 context)
        {
            switch(mNumberOfConstructor)
            {
                case 1:
                    return new ATNConditionQWSubjWillFToHaveBeenConditionV3TransOrFinNode_v2(context, mParentNode, mToken);

                case 2:
                    return new ATNConditionQWSubjWillFToHaveBeenConditionV3TransOrFinNode_v2(context, mSameNode, mInitAction, mToken);

                default:
                    throw new ArgumentOutOfRangeException(nameof(mNumberOfConstructor), mNumberOfConstructor, null);
            }
        }
    }

/*Sub states:
    Condition_QWSubj_Will_FToHave_Been_Condition_V3_Obj_TransOrFin
    Condition_QWSubj_Will_FToHave_Been_Condition_V3_No_Trans
    Condition_QWSubj_Will_FToHave_Been_Condition_V3_Condition_Fin
*/

    public class ATNConditionQWSubjWillFToHaveBeenConditionV3TransOrFinNode_v2: BaseATNNode_v2
    {
        public ATNConditionQWSubjWillFToHaveBeenConditionV3TransOrFinNode_v2(ContextOfATNParsing_v2 context, ATNConditionQWSubjWillFToHaveBeenConditionTransNode_v2 parentNode, ATNExtendedToken token)
            : base(context, token)
        {
            ParentNode = parentNode;
        }

        public ATNConditionQWSubjWillFToHaveBeenConditionV3TransOrFinNode_v2(ContextOfATNParsing_v2 context, ATNConditionQWSubjWillFToHaveBeenConditionV3TransOrFinNode_v2 sameNode, InitATNConditionQWSubjWillFToHaveBeenConditionV3TransOrFinNodeAction initAction, ATNExtendedToken token)
            : base(context, token)
        {
            mSameNode = sameNode;
            mInitAction = initAction;
            ParentNode = mSameNode.ParentNode;
            mInitAction?.Invoke(this);
        }

        public override StateOfATNParsing_v2 GlobalState => StateOfATNParsing_v2.Condition_QWSubj_Will_FToHave_Been_Condition_V3_TransOrFin;

        public ATNConditionQWSubjWillFToHaveBeenConditionTransNode_v2 ParentNode { get; private set; }
        private ATNConditionQWSubjWillFToHaveBeenConditionV3TransOrFinNode_v2 mSameNode;
        private InitATNConditionQWSubjWillFToHaveBeenConditionV3TransOrFinNodeAction mInitAction;

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

