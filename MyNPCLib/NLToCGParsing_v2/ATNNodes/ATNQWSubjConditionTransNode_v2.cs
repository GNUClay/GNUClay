using MyNPCLib.NLToCGParsing;
using System;
using System.Collections.Generic;
using System.Text;

namespace MyNPCLib.NLToCGParsing_v2.ATNNodes
{
    public delegate void InitATNQWSubjConditionTransNodeAction(ATNQWSubjConditionTransNode_v2 item);

    public class ATNQWSubjConditionTransNodeFactory_v2: BaseATNNodeFactory_v2
    {
        public ATNQWSubjConditionTransNodeFactory_v2(ATNQWSubjTransNode_v2 parentNode, ATNExtendedToken token)
        {
            mNumberOfConstructor = 1;
            mParentNode = parentNode;
            mToken = token;
        }

        public ATNQWSubjConditionTransNodeFactory_v2(ATNQWSubjConditionTransNode_v2 sameNode, ATNExtendedToken token, InitATNQWSubjConditionTransNodeAction initAction)
        {
            mNumberOfConstructor = 2;
            mSameNode = sameNode;
            mToken = token;
            mInitAction = initAction;
        }

        private int mNumberOfConstructor;
        private ATNQWSubjTransNode_v2 mParentNode;
        private ATNQWSubjConditionTransNode_v2 mSameNode;
        private ATNExtendedToken mToken;
        private InitATNQWSubjConditionTransNodeAction mInitAction;

        public override BaseATNNode_v2 Create(ContextOfATNParsing_v2 context)
        {
            switch(mNumberOfConstructor)
            {
                case 1:
                    return new ATNQWSubjConditionTransNode_v2(context, mParentNode, mToken);

                case 2:
                    return new ATNQWSubjConditionTransNode_v2(context, mSameNode, mInitAction, mToken);

                default:
                    throw new ArgumentOutOfRangeException(nameof(mNumberOfConstructor), mNumberOfConstructor, null);
            }
        }
    }

/*Sub states:
    QWSubj_Condition_Verb_TransOrFin
*/

    public class ATNQWSubjConditionTransNode_v2: BaseATNNode_v2
    {
        public ATNQWSubjConditionTransNode_v2(ContextOfATNParsing_v2 context, ATNQWSubjTransNode_v2 parentNode, ATNExtendedToken token)
            : base(context, token)
        {
            ParentNode = parentNode;
        }

        public ATNQWSubjConditionTransNode_v2(ContextOfATNParsing_v2 context, ATNQWSubjConditionTransNode_v2 sameNode, InitATNQWSubjConditionTransNodeAction initAction, ATNExtendedToken token)
            : base(context, token)
        {
            mSameNode = sameNode;
            mInitAction = initAction;
            ParentNode = mSameNode.ParentNode;
            mInitAction?.Invoke(this);
        }

        public override StateOfATNParsing_v2 GlobalState => StateOfATNParsing_v2.QWSubj_Condition_Trans;

        public ATNQWSubjTransNode_v2 ParentNode { get; private set; }
        private ATNQWSubjConditionTransNode_v2 mSameNode;
        private InitATNQWSubjConditionTransNodeAction mInitAction;

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

