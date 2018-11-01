using MyNPCLib.NLToCGParsing;
using System;
using System.Collections.Generic;
using System.Text;

namespace MyNPCLib.NLToCGParsing_v2.ATNNodes
{
    public delegate void InitATNConditionQWSubjFToHaveConditionTransNodeAction(ATNConditionQWSubjFToHaveConditionTransNode_v2 item);

    public class ATNConditionQWSubjFToHaveConditionTransNodeFactory_v2: BaseATNNodeFactory_v2
    {
        public ATNConditionQWSubjFToHaveConditionTransNodeFactory_v2(ATNConditionQWSubjFToHaveTransNode_v2 parentNode, ATNExtendedToken token)
        {
            mNumberOfConstructor = 1;
            mParentNode = parentNode;
            mToken = token;
        }

        public ATNConditionQWSubjFToHaveConditionTransNodeFactory_v2(ATNConditionQWSubjFToHaveConditionTransNode_v2 sameNode, ATNExtendedToken token, InitATNConditionQWSubjFToHaveConditionTransNodeAction initAction)
        {
            mNumberOfConstructor = 2;
            mSameNode = sameNode;
            mToken = token;
            mInitAction = initAction;
        }

        private int mNumberOfConstructor;
        private ATNConditionQWSubjFToHaveTransNode_v2 mParentNode;
        private ATNConditionQWSubjFToHaveConditionTransNode_v2 mSameNode;
        private ATNExtendedToken mToken;
        private InitATNConditionQWSubjFToHaveConditionTransNodeAction mInitAction;

        public override BaseATNNode_v2 Create(ContextOfATNParsing_v2 context)
        {
            switch(mNumberOfConstructor)
            {
                case 1:
                    return new ATNConditionQWSubjFToHaveConditionTransNode_v2(context, mParentNode, mToken);

                case 2:
                    return new ATNConditionQWSubjFToHaveConditionTransNode_v2(context, mSameNode, mInitAction, mToken);

                default:
                    throw new ArgumentOutOfRangeException(nameof(mNumberOfConstructor), mNumberOfConstructor, null);
            }
        }
    }

/*Sub states:
    Condition_QWSubj_FToHave_Condition_V3_TransOrFin
*/

    public class ATNConditionQWSubjFToHaveConditionTransNode_v2: BaseATNNode_v2
    {
        public ATNConditionQWSubjFToHaveConditionTransNode_v2(ContextOfATNParsing_v2 context, ATNConditionQWSubjFToHaveTransNode_v2 parentNode, ATNExtendedToken token)
            : base(context, token)
        {
            ParentNode = parentNode;
        }

        public ATNConditionQWSubjFToHaveConditionTransNode_v2(ContextOfATNParsing_v2 context, ATNConditionQWSubjFToHaveConditionTransNode_v2 sameNode, InitATNConditionQWSubjFToHaveConditionTransNodeAction initAction, ATNExtendedToken token)
            : base(context, token)
        {
            mSameNode = sameNode;
            mInitAction = initAction;
            ParentNode = mSameNode.ParentNode;
            mInitAction?.Invoke(this);
        }

        public override StateOfATNParsing_v2 GlobalState => StateOfATNParsing_v2.Condition_QWSubj_FToHave_Condition_Trans;

        public ATNConditionQWSubjFToHaveTransNode_v2 ParentNode { get; private set; }
        private ATNConditionQWSubjFToHaveConditionTransNode_v2 mSameNode;
        private InitATNConditionQWSubjFToHaveConditionTransNodeAction mInitAction;

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

