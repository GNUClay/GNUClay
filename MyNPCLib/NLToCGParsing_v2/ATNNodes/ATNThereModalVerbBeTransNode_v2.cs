using MyNPCLib.NLToCGParsing;
using System;
using System.Collections.Generic;
using System.Text;

namespace MyNPCLib.NLToCGParsing_v2.ATNNodes
{
    public delegate void InitATNThereModalVerbBeTransNodeAction(ATNThereModalVerbBeTransNode_v2 item);

    public class ATNThereModalVerbBeTransNodeFactory_v2: BaseATNNodeFactory_v2
    {
        public ATNThereModalVerbBeTransNodeFactory_v2(ATNThereModalVerbTransNode_v2 parentNode, ATNExtendedToken token)
        {
            mNumberOfConstructor = 1;
            mParentNode = parentNode;
            mToken = token;
        }

        public ATNThereModalVerbBeTransNodeFactory_v2(ATNThereModalVerbBeTransNode_v2 sameNode, ATNExtendedToken token, InitATNThereModalVerbBeTransNodeAction initAction)
        {
            mNumberOfConstructor = 2;
            mSameNode = sameNode;
            mToken = token;
            mInitAction = initAction;
        }

        private int mNumberOfConstructor;
        private ATNThereModalVerbTransNode_v2 mParentNode;
        private ATNThereModalVerbBeTransNode_v2 mSameNode;
        private ATNExtendedToken mToken;
        private InitATNThereModalVerbBeTransNodeAction mInitAction;

        public override BaseATNNode_v2 Create(ContextOfATNParsing_v2 context)
        {
            switch(mNumberOfConstructor)
            {
                case 1:
                    return new ATNThereModalVerbBeTransNode_v2(context, mParentNode, mToken);

                case 2:
                    return new ATNThereModalVerbBeTransNode_v2(context, mSameNode, mInitAction, mToken);

                default:
                    throw new ArgumentOutOfRangeException(nameof(mNumberOfConstructor), mNumberOfConstructor, null);
            }
        }
    }

/*Sub states:
    There_ModalVerb_Be_Obj_TransOrFin
    There_ModalVerb_Be_No_Trans
*/

    public class ATNThereModalVerbBeTransNode_v2: BaseATNNode_v2
    {
        public ATNThereModalVerbBeTransNode_v2(ContextOfATNParsing_v2 context, ATNThereModalVerbTransNode_v2 parentNode, ATNExtendedToken token)
            : base(context, token)
        {
            ParentNode = parentNode;
        }

        public ATNThereModalVerbBeTransNode_v2(ContextOfATNParsing_v2 context, ATNThereModalVerbBeTransNode_v2 sameNode, InitATNThereModalVerbBeTransNodeAction initAction, ATNExtendedToken token)
            : base(context, token)
        {
            mSameNode = sameNode;
            mInitAction = initAction;
            ParentNode = mSameNode.ParentNode;
            mInitAction?.Invoke(this);
        }

        public override StateOfATNParsing_v2 GlobalState => StateOfATNParsing_v2.There_ModalVerb_Be_Trans;

        public ATNThereModalVerbTransNode_v2 ParentNode { get; private set; }
        private ATNThereModalVerbBeTransNode_v2 mSameNode;
        private InitATNThereModalVerbBeTransNodeAction mInitAction;

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

