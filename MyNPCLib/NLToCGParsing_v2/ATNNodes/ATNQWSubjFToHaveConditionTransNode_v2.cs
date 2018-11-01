using MyNPCLib.NLToCGParsing;
using System;
using System.Collections.Generic;
using System.Text;

namespace MyNPCLib.NLToCGParsing_v2.ATNNodes
{
    public delegate void InitATNQWSubjFToHaveConditionTransNodeAction(ATNQWSubjFToHaveConditionTransNode_v2 item);

    public class ATNQWSubjFToHaveConditionTransNodeFactory_v2: BaseATNNodeFactory_v2
    {
        public ATNQWSubjFToHaveConditionTransNodeFactory_v2(ATNQWSubjFToHaveTransNode_v2 parentNode, ATNExtendedToken token)
        {
            mNumberOfConstructor = 1;
            mParentNode = parentNode;
            mToken = token;
        }

        public ATNQWSubjFToHaveConditionTransNodeFactory_v2(ATNQWSubjFToHaveConditionTransNode_v2 sameNode, ATNExtendedToken token, InitATNQWSubjFToHaveConditionTransNodeAction initAction)
        {
            mNumberOfConstructor = 2;
            mSameNode = sameNode;
            mToken = token;
            mInitAction = initAction;
        }

        private int mNumberOfConstructor;
        private ATNQWSubjFToHaveTransNode_v2 mParentNode;
        private ATNQWSubjFToHaveConditionTransNode_v2 mSameNode;
        private ATNExtendedToken mToken;
        private InitATNQWSubjFToHaveConditionTransNodeAction mInitAction;

        public override BaseATNNode_v2 Create(ContextOfATNParsing_v2 context)
        {
            switch(mNumberOfConstructor)
            {
                case 1:
                    return new ATNQWSubjFToHaveConditionTransNode_v2(context, mParentNode, mToken);

                case 2:
                    return new ATNQWSubjFToHaveConditionTransNode_v2(context, mSameNode, mInitAction, mToken);

                default:
                    throw new ArgumentOutOfRangeException(nameof(mNumberOfConstructor), mNumberOfConstructor, null);
            }
        }
    }

/*Sub states:
    QWSubj_FToHave_Condition_V3_TransOrFin
*/

    public class ATNQWSubjFToHaveConditionTransNode_v2: BaseATNNode_v2
    {
        public ATNQWSubjFToHaveConditionTransNode_v2(ContextOfATNParsing_v2 context, ATNQWSubjFToHaveTransNode_v2 parentNode, ATNExtendedToken token)
            : base(context, token)
        {
            ParentNode = parentNode;
        }

        public ATNQWSubjFToHaveConditionTransNode_v2(ContextOfATNParsing_v2 context, ATNQWSubjFToHaveConditionTransNode_v2 sameNode, InitATNQWSubjFToHaveConditionTransNodeAction initAction, ATNExtendedToken token)
            : base(context, token)
        {
            mSameNode = sameNode;
            mInitAction = initAction;
            ParentNode = mSameNode.ParentNode;
            mInitAction?.Invoke(this);
        }

        public override StateOfATNParsing_v2 GlobalState => StateOfATNParsing_v2.QWSubj_FToHave_Condition_Trans;

        public ATNQWSubjFToHaveTransNode_v2 ParentNode { get; private set; }
        private ATNQWSubjFToHaveConditionTransNode_v2 mSameNode;
        private InitATNQWSubjFToHaveConditionTransNodeAction mInitAction;

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

