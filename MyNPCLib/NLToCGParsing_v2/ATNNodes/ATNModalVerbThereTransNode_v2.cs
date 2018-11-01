using MyNPCLib.NLToCGParsing;
using System;
using System.Collections.Generic;
using System.Text;

namespace MyNPCLib.NLToCGParsing_v2.ATNNodes
{
    public delegate void InitATNModalVerbThereTransNodeAction(ATNModalVerbThereTransNode_v2 item);

    public class ATNModalVerbThereTransNodeFactory_v2: BaseATNNodeFactory_v2
    {
        public ATNModalVerbThereTransNodeFactory_v2(ATNModalVerbTransNode_v2 parentNode, ATNExtendedToken token)
        {
            mNumberOfConstructor = 1;
            mParentNode = parentNode;
            mToken = token;
        }

        public ATNModalVerbThereTransNodeFactory_v2(ATNModalVerbThereTransNode_v2 sameNode, ATNExtendedToken token, InitATNModalVerbThereTransNodeAction initAction)
        {
            mNumberOfConstructor = 2;
            mSameNode = sameNode;
            mToken = token;
            mInitAction = initAction;
        }

        private int mNumberOfConstructor;
        private ATNModalVerbTransNode_v2 mParentNode;
        private ATNModalVerbThereTransNode_v2 mSameNode;
        private ATNExtendedToken mToken;
        private InitATNModalVerbThereTransNodeAction mInitAction;

        public override BaseATNNode_v2 Create(ContextOfATNParsing_v2 context)
        {
            switch(mNumberOfConstructor)
            {
                case 1:
                    return new ATNModalVerbThereTransNode_v2(context, mParentNode, mToken);

                case 2:
                    return new ATNModalVerbThereTransNode_v2(context, mSameNode, mInitAction, mToken);

                default:
                    throw new ArgumentOutOfRangeException(nameof(mNumberOfConstructor), mNumberOfConstructor, null);
            }
        }
    }

/*Sub states:
    ModalVerb_There_Be_Trans
*/

    public class ATNModalVerbThereTransNode_v2: BaseATNNode_v2
    {
        public ATNModalVerbThereTransNode_v2(ContextOfATNParsing_v2 context, ATNModalVerbTransNode_v2 parentNode, ATNExtendedToken token)
            : base(context, token)
        {
            ParentNode = parentNode;
        }

        public ATNModalVerbThereTransNode_v2(ContextOfATNParsing_v2 context, ATNModalVerbThereTransNode_v2 sameNode, InitATNModalVerbThereTransNodeAction initAction, ATNExtendedToken token)
            : base(context, token)
        {
            mSameNode = sameNode;
            mInitAction = initAction;
            ParentNode = mSameNode.ParentNode;
            mInitAction?.Invoke(this);
        }

        public override StateOfATNParsing_v2 GlobalState => StateOfATNParsing_v2.ModalVerb_There_Trans;

        public ATNModalVerbTransNode_v2 ParentNode { get; private set; }
        private ATNModalVerbThereTransNode_v2 mSameNode;
        private InitATNModalVerbThereTransNodeAction mInitAction;

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

