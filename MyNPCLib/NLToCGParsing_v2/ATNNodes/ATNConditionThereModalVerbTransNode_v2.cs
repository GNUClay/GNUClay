using MyNPCLib.NLToCGParsing;
using System;
using System.Collections.Generic;
using System.Text;

namespace MyNPCLib.NLToCGParsing_v2.ATNNodes
{
    public delegate void InitATNConditionThereModalVerbTransNodeAction(ATNConditionThereModalVerbTransNode_v2 item);

    public class ATNConditionThereModalVerbTransNodeFactory_v2: BaseATNNodeFactory_v2
    {
        public ATNConditionThereModalVerbTransNodeFactory_v2(ATNConditionThereTransNode_v2 parentNode, ATNExtendedToken token)
        {
            mNumberOfConstructor = 1;
            mParentNode = parentNode;
            mToken = token;
        }

        public ATNConditionThereModalVerbTransNodeFactory_v2(ATNConditionThereModalVerbTransNode_v2 sameNode, ATNExtendedToken token, InitATNConditionThereModalVerbTransNodeAction initAction)
        {
            mNumberOfConstructor = 2;
            mSameNode = sameNode;
            mToken = token;
            mInitAction = initAction;
        }

        private int mNumberOfConstructor;
        private ATNConditionThereTransNode_v2 mParentNode;
        private ATNConditionThereModalVerbTransNode_v2 mSameNode;
        private ATNExtendedToken mToken;
        private InitATNConditionThereModalVerbTransNodeAction mInitAction;

        public override BaseATNNode_v2 Create(ContextOfATNParsing_v2 context)
        {
            switch(mNumberOfConstructor)
            {
                case 1:
                    return new ATNConditionThereModalVerbTransNode_v2(context, mParentNode, mToken);

                case 2:
                    return new ATNConditionThereModalVerbTransNode_v2(context, mSameNode, mInitAction, mToken);

                default:
                    throw new ArgumentOutOfRangeException(nameof(mNumberOfConstructor), mNumberOfConstructor, null);
            }
        }
    }

/*Sub states:
    Condition_There_ModalVerb_Be_Trans
    Condition_There_ModalVerb_Not_Trans
*/

    public class ATNConditionThereModalVerbTransNode_v2: BaseATNNode_v2
    {
        public ATNConditionThereModalVerbTransNode_v2(ContextOfATNParsing_v2 context, ATNConditionThereTransNode_v2 parentNode, ATNExtendedToken token)
            : base(context, token)
        {
            ParentNode = parentNode;
        }

        public ATNConditionThereModalVerbTransNode_v2(ContextOfATNParsing_v2 context, ATNConditionThereModalVerbTransNode_v2 sameNode, InitATNConditionThereModalVerbTransNodeAction initAction, ATNExtendedToken token)
            : base(context, token)
        {
            mSameNode = sameNode;
            mInitAction = initAction;
            ParentNode = mSameNode.ParentNode;
            mInitAction?.Invoke(this);
        }

        public override StateOfATNParsing_v2 GlobalState => StateOfATNParsing_v2.Condition_There_ModalVerb_Trans;

        public ATNConditionThereTransNode_v2 ParentNode { get; private set; }
        private ATNConditionThereModalVerbTransNode_v2 mSameNode;
        private InitATNConditionThereModalVerbTransNodeAction mInitAction;

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

