using MyNPCLib.NLToCGParsing;
using System;
using System.Collections.Generic;
using System.Text;

namespace MyNPCLib.NLToCGParsing_v2.ATNNodes
{
    public delegate void InitATNThereModalVerbBeNoTransNodeAction(ATNThereModalVerbBeNoTransNode_v2 item);

    public class ATNThereModalVerbBeNoTransNodeFactory_v2: BaseATNNodeFactory_v2
    {
        public ATNThereModalVerbBeNoTransNodeFactory_v2(ATNThereModalVerbBeTransNode_v2 parentNode, ATNExtendedToken token)
        {
            mNumberOfConstructor = 1;
            mParentNode = parentNode;
            mToken = token;
        }

        public ATNThereModalVerbBeNoTransNodeFactory_v2(ATNThereModalVerbBeNoTransNode_v2 sameNode, ATNExtendedToken token, InitATNThereModalVerbBeNoTransNodeAction initAction)
        {
            mNumberOfConstructor = 2;
            mSameNode = sameNode;
            mToken = token;
            mInitAction = initAction;
        }

        private int mNumberOfConstructor;
        private ATNThereModalVerbBeTransNode_v2 mParentNode;
        private ATNThereModalVerbBeNoTransNode_v2 mSameNode;
        private ATNExtendedToken mToken;
        private InitATNThereModalVerbBeNoTransNodeAction mInitAction;

        public override BaseATNNode_v2 Create(ContextOfATNParsing_v2 context)
        {
            switch(mNumberOfConstructor)
            {
                case 1:
                    return new ATNThereModalVerbBeNoTransNode_v2(context, mParentNode, mToken);

                case 2:
                    return new ATNThereModalVerbBeNoTransNode_v2(context, mSameNode, mInitAction, mToken);

                default:
                    throw new ArgumentOutOfRangeException(nameof(mNumberOfConstructor), mNumberOfConstructor, null);
            }
        }
    }

/*Sub states:
    There_ModalVerb_Be_No_Obj_TransOrFin
*/

    public class ATNThereModalVerbBeNoTransNode_v2: BaseATNNode_v2
    {
        public ATNThereModalVerbBeNoTransNode_v2(ContextOfATNParsing_v2 context, ATNThereModalVerbBeTransNode_v2 parentNode, ATNExtendedToken token)
            : base(context, token)
        {
            ParentNode = parentNode;
        }

        public ATNThereModalVerbBeNoTransNode_v2(ContextOfATNParsing_v2 context, ATNThereModalVerbBeNoTransNode_v2 sameNode, InitATNThereModalVerbBeNoTransNodeAction initAction, ATNExtendedToken token)
            : base(context, token)
        {
            mSameNode = sameNode;
            mInitAction = initAction;
            ParentNode = mSameNode.ParentNode;
            mInitAction?.Invoke(this);
        }

        public override StateOfATNParsing_v2 GlobalState => StateOfATNParsing_v2.There_ModalVerb_Be_No_Trans;

        public ATNThereModalVerbBeTransNode_v2 ParentNode { get; private set; }
        private ATNThereModalVerbBeNoTransNode_v2 mSameNode;
        private InitATNThereModalVerbBeNoTransNodeAction mInitAction;

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

