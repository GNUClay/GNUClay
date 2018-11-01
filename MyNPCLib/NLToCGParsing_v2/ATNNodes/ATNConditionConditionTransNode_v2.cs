using MyNPCLib.NLToCGParsing;
using System;
using System.Collections.Generic;
using System.Text;

namespace MyNPCLib.NLToCGParsing_v2.ATNNodes
{
    public delegate void InitATNConditionConditionTransNodeAction(ATNConditionConditionTransNode_v2 item);

    public class ATNConditionConditionTransNodeFactory_v2: BaseATNNodeFactory_v2
    {
        public ATNConditionConditionTransNodeFactory_v2(ATNConditionTransNode_v2 parentNode, ATNExtendedToken token)
        {
            mNumberOfConstructor = 1;
            mParentNode = parentNode;
            mToken = token;
        }

        public ATNConditionConditionTransNodeFactory_v2(ATNConditionConditionTransNode_v2 sameNode, ATNExtendedToken token, InitATNConditionConditionTransNodeAction initAction)
        {
            mNumberOfConstructor = 2;
            mSameNode = sameNode;
            mToken = token;
            mInitAction = initAction;
        }

        private int mNumberOfConstructor;
        private ATNConditionTransNode_v2 mParentNode;
        private ATNConditionConditionTransNode_v2 mSameNode;
        private ATNExtendedToken mToken;
        private InitATNConditionConditionTransNodeAction mInitAction;

        public override BaseATNNode_v2 Create(ContextOfATNParsing_v2 context)
        {
            switch(mNumberOfConstructor)
            {
                case 1:
                    return new ATNConditionConditionTransNode_v2(context, mParentNode, mToken);

                case 2:
                    return new ATNConditionConditionTransNode_v2(context, mSameNode, mInitAction, mToken);

                default:
                    throw new ArgumentOutOfRangeException(nameof(mNumberOfConstructor), mNumberOfConstructor, null);
            }
        }
    }

/*Sub states:
    Condition_Condition_Verb_TransOrFin
*/

    public class ATNConditionConditionTransNode_v2: BaseATNNode_v2
    {
        public ATNConditionConditionTransNode_v2(ContextOfATNParsing_v2 context, ATNConditionTransNode_v2 parentNode, ATNExtendedToken token)
            : base(context, token)
        {
            ParentNode = parentNode;
        }

        public ATNConditionConditionTransNode_v2(ContextOfATNParsing_v2 context, ATNConditionConditionTransNode_v2 sameNode, InitATNConditionConditionTransNodeAction initAction, ATNExtendedToken token)
            : base(context, token)
        {
            mSameNode = sameNode;
            mInitAction = initAction;
            ParentNode = mSameNode.ParentNode;
            mInitAction?.Invoke(this);
        }

        public override StateOfATNParsing_v2 GlobalState => StateOfATNParsing_v2.Condition_Condition_Trans;

        public ATNConditionTransNode_v2 ParentNode { get; private set; }
        private ATNConditionConditionTransNode_v2 mSameNode;
        private InitATNConditionConditionTransNodeAction mInitAction;

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

