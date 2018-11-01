using MyNPCLib.NLToCGParsing;
using System;
using System.Collections.Generic;
using System.Text;

namespace MyNPCLib.NLToCGParsing_v2.ATNNodes
{
    public delegate void InitATNThereModalVerbNotTransNodeAction(ATNThereModalVerbNotTransNode_v2 item);

    public class ATNThereModalVerbNotTransNodeFactory_v2: BaseATNNodeFactory_v2
    {
        public ATNThereModalVerbNotTransNodeFactory_v2(ATNThereModalVerbTransNode_v2 parentNode, ATNExtendedToken token)
        {
            mNumberOfConstructor = 1;
            mParentNode = parentNode;
            mToken = token;
        }

        public ATNThereModalVerbNotTransNodeFactory_v2(ATNThereModalVerbNotTransNode_v2 sameNode, ATNExtendedToken token, InitATNThereModalVerbNotTransNodeAction initAction)
        {
            mNumberOfConstructor = 2;
            mSameNode = sameNode;
            mToken = token;
            mInitAction = initAction;
        }

        private int mNumberOfConstructor;
        private ATNThereModalVerbTransNode_v2 mParentNode;
        private ATNThereModalVerbNotTransNode_v2 mSameNode;
        private ATNExtendedToken mToken;
        private InitATNThereModalVerbNotTransNodeAction mInitAction;

        public override BaseATNNode_v2 Create(ContextOfATNParsing_v2 context)
        {
            switch(mNumberOfConstructor)
            {
                case 1:
                    return new ATNThereModalVerbNotTransNode_v2(context, mParentNode, mToken);

                case 2:
                    return new ATNThereModalVerbNotTransNode_v2(context, mSameNode, mInitAction, mToken);

                default:
                    throw new ArgumentOutOfRangeException(nameof(mNumberOfConstructor), mNumberOfConstructor, null);
            }
        }
    }

/*Sub states:
    There_ModalVerb_Not_Be_Trans
*/

    public class ATNThereModalVerbNotTransNode_v2: BaseATNNode_v2
    {
        public ATNThereModalVerbNotTransNode_v2(ContextOfATNParsing_v2 context, ATNThereModalVerbTransNode_v2 parentNode, ATNExtendedToken token)
            : base(context, token)
        {
            ParentNode = parentNode;
        }

        public ATNThereModalVerbNotTransNode_v2(ContextOfATNParsing_v2 context, ATNThereModalVerbNotTransNode_v2 sameNode, InitATNThereModalVerbNotTransNodeAction initAction, ATNExtendedToken token)
            : base(context, token)
        {
            mSameNode = sameNode;
            mInitAction = initAction;
            ParentNode = mSameNode.ParentNode;
            mInitAction?.Invoke(this);
        }

        public override StateOfATNParsing_v2 GlobalState => StateOfATNParsing_v2.There_ModalVerb_Not_Trans;

        public ATNThereModalVerbTransNode_v2 ParentNode { get; private set; }
        private ATNThereModalVerbNotTransNode_v2 mSameNode;
        private InitATNThereModalVerbNotTransNodeAction mInitAction;

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

