using MyNPCLib.NLToCGParsing;
using System;
using System.Collections.Generic;
using System.Text;

namespace MyNPCLib.NLToCGParsing_v2.ATNNodes
{
    public delegate void InitATNConditionFToHaveTransNodeAction(ATNConditionFToHaveTransNode_v2 item);

    public class ATNConditionFToHaveTransNodeFactory_v2: BaseATNNodeFactory_v2
    {
        public ATNConditionFToHaveTransNodeFactory_v2(ATNConditionTransNode_v2 parentNode, ATNExtendedToken token)
        {
            mNumberOfConstructor = 1;
            mParentNode = parentNode;
            mToken = token;
        }

        public ATNConditionFToHaveTransNodeFactory_v2(ATNConditionFToHaveTransNode_v2 sameNode, ATNExtendedToken token, InitATNConditionFToHaveTransNodeAction initAction)
        {
            mNumberOfConstructor = 2;
            mSameNode = sameNode;
            mToken = token;
            mInitAction = initAction;
        }

        private int mNumberOfConstructor;
        private ATNConditionTransNode_v2 mParentNode;
        private ATNConditionFToHaveTransNode_v2 mSameNode;
        private ATNExtendedToken mToken;
        private InitATNConditionFToHaveTransNodeAction mInitAction;

        public override BaseATNNode_v2 Create(ContextOfATNParsing_v2 context)
        {
            switch(mNumberOfConstructor)
            {
                case 1:
                    return new ATNConditionFToHaveTransNode_v2(context, mParentNode, mToken);

                case 2:
                    return new ATNConditionFToHaveTransNode_v2(context, mSameNode, mInitAction, mToken);

                default:
                    throw new ArgumentOutOfRangeException(nameof(mNumberOfConstructor), mNumberOfConstructor, null);
            }
        }
    }

/*Sub states:
    Condition_FToHave_Subj_Trans
*/

    public class ATNConditionFToHaveTransNode_v2: BaseATNNode_v2
    {
        public ATNConditionFToHaveTransNode_v2(ContextOfATNParsing_v2 context, ATNConditionTransNode_v2 parentNode, ATNExtendedToken token)
            : base(context, token)
        {
            ParentNode = parentNode;
        }

        public ATNConditionFToHaveTransNode_v2(ContextOfATNParsing_v2 context, ATNConditionFToHaveTransNode_v2 sameNode, InitATNConditionFToHaveTransNodeAction initAction, ATNExtendedToken token)
            : base(context, token)
        {
            mSameNode = sameNode;
            mInitAction = initAction;
            ParentNode = mSameNode.ParentNode;
            mInitAction?.Invoke(this);
        }

        public override StateOfATNParsing_v2 GlobalState => StateOfATNParsing_v2.Condition_FToHave_Trans;

        public ATNConditionTransNode_v2 ParentNode { get; private set; }
        private ATNConditionFToHaveTransNode_v2 mSameNode;
        private InitATNConditionFToHaveTransNodeAction mInitAction;

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

