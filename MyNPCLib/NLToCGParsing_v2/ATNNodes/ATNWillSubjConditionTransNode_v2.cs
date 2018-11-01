using MyNPCLib.NLToCGParsing;
using System;
using System.Collections.Generic;
using System.Text;

namespace MyNPCLib.NLToCGParsing_v2.ATNNodes
{
    public delegate void InitATNWillSubjConditionTransNodeAction(ATNWillSubjConditionTransNode_v2 item);

    public class ATNWillSubjConditionTransNodeFactory_v2: BaseATNNodeFactory_v2
    {
        public ATNWillSubjConditionTransNodeFactory_v2(ATNWillSubjTransNode_v2 parentNode, ATNExtendedToken token)
        {
            mNumberOfConstructor = 1;
            mParentNode = parentNode;
            mToken = token;
        }

        public ATNWillSubjConditionTransNodeFactory_v2(ATNWillSubjConditionTransNode_v2 sameNode, ATNExtendedToken token, InitATNWillSubjConditionTransNodeAction initAction)
        {
            mNumberOfConstructor = 2;
            mSameNode = sameNode;
            mToken = token;
            mInitAction = initAction;
        }

        private int mNumberOfConstructor;
        private ATNWillSubjTransNode_v2 mParentNode;
        private ATNWillSubjConditionTransNode_v2 mSameNode;
        private ATNExtendedToken mToken;
        private InitATNWillSubjConditionTransNodeAction mInitAction;

        public override BaseATNNode_v2 Create(ContextOfATNParsing_v2 context)
        {
            switch(mNumberOfConstructor)
            {
                case 1:
                    return new ATNWillSubjConditionTransNode_v2(context, mParentNode, mToken);

                case 2:
                    return new ATNWillSubjConditionTransNode_v2(context, mSameNode, mInitAction, mToken);

                default:
                    throw new ArgumentOutOfRangeException(nameof(mNumberOfConstructor), mNumberOfConstructor, null);
            }
        }
    }

/*Sub states:
    Will_Subj_Condition_Verb_TransOrFin
*/

    public class ATNWillSubjConditionTransNode_v2: BaseATNNode_v2
    {
        public ATNWillSubjConditionTransNode_v2(ContextOfATNParsing_v2 context, ATNWillSubjTransNode_v2 parentNode, ATNExtendedToken token)
            : base(context, token)
        {
            ParentNode = parentNode;
        }

        public ATNWillSubjConditionTransNode_v2(ContextOfATNParsing_v2 context, ATNWillSubjConditionTransNode_v2 sameNode, InitATNWillSubjConditionTransNodeAction initAction, ATNExtendedToken token)
            : base(context, token)
        {
            mSameNode = sameNode;
            mInitAction = initAction;
            ParentNode = mSameNode.ParentNode;
            mInitAction?.Invoke(this);
        }

        public override StateOfATNParsing_v2 GlobalState => StateOfATNParsing_v2.Will_Subj_Condition_Trans;

        public ATNWillSubjTransNode_v2 ParentNode { get; private set; }
        private ATNWillSubjConditionTransNode_v2 mSameNode;
        private InitATNWillSubjConditionTransNodeAction mInitAction;

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

