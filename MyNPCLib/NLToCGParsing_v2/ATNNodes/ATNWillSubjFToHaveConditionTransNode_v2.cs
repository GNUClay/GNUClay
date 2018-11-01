using MyNPCLib.NLToCGParsing;
using System;
using System.Collections.Generic;
using System.Text;

namespace MyNPCLib.NLToCGParsing_v2.ATNNodes
{
    public delegate void InitATNWillSubjFToHaveConditionTransNodeAction(ATNWillSubjFToHaveConditionTransNode_v2 item);

    public class ATNWillSubjFToHaveConditionTransNodeFactory_v2: BaseATNNodeFactory_v2
    {
        public ATNWillSubjFToHaveConditionTransNodeFactory_v2(ATNWillSubjFToHaveTransNode_v2 parentNode, ATNExtendedToken token)
        {
            mNumberOfConstructor = 1;
            mParentNode = parentNode;
            mToken = token;
        }

        public ATNWillSubjFToHaveConditionTransNodeFactory_v2(ATNWillSubjFToHaveConditionTransNode_v2 sameNode, ATNExtendedToken token, InitATNWillSubjFToHaveConditionTransNodeAction initAction)
        {
            mNumberOfConstructor = 2;
            mSameNode = sameNode;
            mToken = token;
            mInitAction = initAction;
        }

        private int mNumberOfConstructor;
        private ATNWillSubjFToHaveTransNode_v2 mParentNode;
        private ATNWillSubjFToHaveConditionTransNode_v2 mSameNode;
        private ATNExtendedToken mToken;
        private InitATNWillSubjFToHaveConditionTransNodeAction mInitAction;

        public override BaseATNNode_v2 Create(ContextOfATNParsing_v2 context)
        {
            switch(mNumberOfConstructor)
            {
                case 1:
                    return new ATNWillSubjFToHaveConditionTransNode_v2(context, mParentNode, mToken);

                case 2:
                    return new ATNWillSubjFToHaveConditionTransNode_v2(context, mSameNode, mInitAction, mToken);

                default:
                    throw new ArgumentOutOfRangeException(nameof(mNumberOfConstructor), mNumberOfConstructor, null);
            }
        }
    }

/*Sub states:
    Will_Subj_FToHave_Condition_V3_TransOrFin
*/

    public class ATNWillSubjFToHaveConditionTransNode_v2: BaseATNNode_v2
    {
        public ATNWillSubjFToHaveConditionTransNode_v2(ContextOfATNParsing_v2 context, ATNWillSubjFToHaveTransNode_v2 parentNode, ATNExtendedToken token)
            : base(context, token)
        {
            ParentNode = parentNode;
        }

        public ATNWillSubjFToHaveConditionTransNode_v2(ContextOfATNParsing_v2 context, ATNWillSubjFToHaveConditionTransNode_v2 sameNode, InitATNWillSubjFToHaveConditionTransNodeAction initAction, ATNExtendedToken token)
            : base(context, token)
        {
            mSameNode = sameNode;
            mInitAction = initAction;
            ParentNode = mSameNode.ParentNode;
            mInitAction?.Invoke(this);
        }

        public override StateOfATNParsing_v2 GlobalState => StateOfATNParsing_v2.Will_Subj_FToHave_Condition_Trans;

        public ATNWillSubjFToHaveTransNode_v2 ParentNode { get; private set; }
        private ATNWillSubjFToHaveConditionTransNode_v2 mSameNode;
        private InitATNWillSubjFToHaveConditionTransNodeAction mInitAction;

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

