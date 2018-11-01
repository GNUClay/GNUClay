using MyNPCLib.NLToCGParsing;
using System;
using System.Collections.Generic;
using System.Text;

namespace MyNPCLib.NLToCGParsing_v2.ATNNodes
{
    public delegate void InitATNConditionModalVerbThereTransNodeAction(ATNConditionModalVerbThereTransNode_v2 item);

    public class ATNConditionModalVerbThereTransNodeFactory_v2: BaseATNNodeFactory_v2
    {
        public ATNConditionModalVerbThereTransNodeFactory_v2(ATNConditionModalVerbTransNode_v2 parentNode, ATNExtendedToken token)
        {
            mNumberOfConstructor = 1;
            mParentNode = parentNode;
            mToken = token;
        }

        public ATNConditionModalVerbThereTransNodeFactory_v2(ATNConditionModalVerbThereTransNode_v2 sameNode, ATNExtendedToken token, InitATNConditionModalVerbThereTransNodeAction initAction)
        {
            mNumberOfConstructor = 2;
            mSameNode = sameNode;
            mToken = token;
            mInitAction = initAction;
        }

        private int mNumberOfConstructor;
        private ATNConditionModalVerbTransNode_v2 mParentNode;
        private ATNConditionModalVerbThereTransNode_v2 mSameNode;
        private ATNExtendedToken mToken;
        private InitATNConditionModalVerbThereTransNodeAction mInitAction;

        public override BaseATNNode_v2 Create(ContextOfATNParsing_v2 context)
        {
            switch(mNumberOfConstructor)
            {
                case 1:
                    return new ATNConditionModalVerbThereTransNode_v2(context, mParentNode, mToken);

                case 2:
                    return new ATNConditionModalVerbThereTransNode_v2(context, mSameNode, mInitAction, mToken);

                default:
                    throw new ArgumentOutOfRangeException(nameof(mNumberOfConstructor), mNumberOfConstructor, null);
            }
        }
    }

/*Sub states:
    Condition_ModalVerb_There_Be_Trans
*/

    public class ATNConditionModalVerbThereTransNode_v2: BaseATNNode_v2
    {
        public ATNConditionModalVerbThereTransNode_v2(ContextOfATNParsing_v2 context, ATNConditionModalVerbTransNode_v2 parentNode, ATNExtendedToken token)
            : base(context, token)
        {
            ParentNode = parentNode;
        }

        public ATNConditionModalVerbThereTransNode_v2(ContextOfATNParsing_v2 context, ATNConditionModalVerbThereTransNode_v2 sameNode, InitATNConditionModalVerbThereTransNodeAction initAction, ATNExtendedToken token)
            : base(context, token)
        {
            mSameNode = sameNode;
            mInitAction = initAction;
            ParentNode = mSameNode.ParentNode;
            mInitAction?.Invoke(this);
        }

        public override StateOfATNParsing_v2 GlobalState => StateOfATNParsing_v2.Condition_ModalVerb_There_Trans;

        public ATNConditionModalVerbTransNode_v2 ParentNode { get; private set; }
        private ATNConditionModalVerbThereTransNode_v2 mSameNode;
        private InitATNConditionModalVerbThereTransNodeAction mInitAction;

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

