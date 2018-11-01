using MyNPCLib.NLToCGParsing;
using System;
using System.Collections.Generic;
using System.Text;

namespace MyNPCLib.NLToCGParsing_v2.ATNNodes
{
    public delegate void InitATNThereModalVerbTransNodeAction(ATNThereModalVerbTransNode_v2 item);

    public class ATNThereModalVerbTransNodeFactory_v2: BaseATNNodeFactory_v2
    {
        public ATNThereModalVerbTransNodeFactory_v2(ATNThereTransNode_v2 parentNode, ATNExtendedToken token)
        {
            mNumberOfConstructor = 1;
            mParentNode = parentNode;
            mToken = token;
        }

        public ATNThereModalVerbTransNodeFactory_v2(ATNThereModalVerbTransNode_v2 sameNode, ATNExtendedToken token, InitATNThereModalVerbTransNodeAction initAction)
        {
            mNumberOfConstructor = 2;
            mSameNode = sameNode;
            mToken = token;
            mInitAction = initAction;
        }

        private int mNumberOfConstructor;
        private ATNThereTransNode_v2 mParentNode;
        private ATNThereModalVerbTransNode_v2 mSameNode;
        private ATNExtendedToken mToken;
        private InitATNThereModalVerbTransNodeAction mInitAction;

        public override BaseATNNode_v2 Create(ContextOfATNParsing_v2 context)
        {
            switch(mNumberOfConstructor)
            {
                case 1:
                    return new ATNThereModalVerbTransNode_v2(context, mParentNode, mToken);

                case 2:
                    return new ATNThereModalVerbTransNode_v2(context, mSameNode, mInitAction, mToken);

                default:
                    throw new ArgumentOutOfRangeException(nameof(mNumberOfConstructor), mNumberOfConstructor, null);
            }
        }
    }

/*Sub states:
    There_ModalVerb_Be_Trans
    There_ModalVerb_Not_Trans
*/

    public class ATNThereModalVerbTransNode_v2: BaseATNNode_v2
    {
        public ATNThereModalVerbTransNode_v2(ContextOfATNParsing_v2 context, ATNThereTransNode_v2 parentNode, ATNExtendedToken token)
            : base(context, token)
        {
            ParentNode = parentNode;
        }

        public ATNThereModalVerbTransNode_v2(ContextOfATNParsing_v2 context, ATNThereModalVerbTransNode_v2 sameNode, InitATNThereModalVerbTransNodeAction initAction, ATNExtendedToken token)
            : base(context, token)
        {
            mSameNode = sameNode;
            mInitAction = initAction;
            ParentNode = mSameNode.ParentNode;
            mInitAction?.Invoke(this);
        }

        public override StateOfATNParsing_v2 GlobalState => StateOfATNParsing_v2.There_ModalVerb_Trans;

        public ATNThereTransNode_v2 ParentNode { get; private set; }
        private ATNThereModalVerbTransNode_v2 mSameNode;
        private InitATNThereModalVerbTransNodeAction mInitAction;

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

