using MyNPCLib.NLToCGParsing;
using System;
using System.Collections.Generic;
using System.Text;

namespace MyNPCLib.NLToCGParsing_v2.ATNNodes
{
    public delegate void InitATNModalVerbThereBeNoTransNodeAction(ATNModalVerbThereBeNoTransNode_v2 item);

    public class ATNModalVerbThereBeNoTransNodeFactory_v2: BaseATNNodeFactory_v2
    {
        public ATNModalVerbThereBeNoTransNodeFactory_v2(ATNModalVerbThereBeTransNode_v2 parentNode, ATNExtendedToken token)
        {
            mNumberOfConstructor = 1;
            mParentNode = parentNode;
            mToken = token;
        }

        public ATNModalVerbThereBeNoTransNodeFactory_v2(ATNModalVerbThereBeNoTransNode_v2 sameNode, ATNExtendedToken token, InitATNModalVerbThereBeNoTransNodeAction initAction)
        {
            mNumberOfConstructor = 2;
            mSameNode = sameNode;
            mToken = token;
            mInitAction = initAction;
        }

        private int mNumberOfConstructor;
        private ATNModalVerbThereBeTransNode_v2 mParentNode;
        private ATNModalVerbThereBeNoTransNode_v2 mSameNode;
        private ATNExtendedToken mToken;
        private InitATNModalVerbThereBeNoTransNodeAction mInitAction;

        public override BaseATNNode_v2 Create(ContextOfATNParsing_v2 context)
        {
            switch(mNumberOfConstructor)
            {
                case 1:
                    return new ATNModalVerbThereBeNoTransNode_v2(context, mParentNode, mToken);

                case 2:
                    return new ATNModalVerbThereBeNoTransNode_v2(context, mSameNode, mInitAction, mToken);

                default:
                    throw new ArgumentOutOfRangeException(nameof(mNumberOfConstructor), mNumberOfConstructor, null);
            }
        }
    }

/*Sub states:
    ModalVerb_There_Be_No_Obj_TransOrFin
*/

    public class ATNModalVerbThereBeNoTransNode_v2: BaseATNNode_v2
    {
        public ATNModalVerbThereBeNoTransNode_v2(ContextOfATNParsing_v2 context, ATNModalVerbThereBeTransNode_v2 parentNode, ATNExtendedToken token)
            : base(context, token)
        {
            ParentNode = parentNode;
        }

        public ATNModalVerbThereBeNoTransNode_v2(ContextOfATNParsing_v2 context, ATNModalVerbThereBeNoTransNode_v2 sameNode, InitATNModalVerbThereBeNoTransNodeAction initAction, ATNExtendedToken token)
            : base(context, token)
        {
            mSameNode = sameNode;
            mInitAction = initAction;
            ParentNode = mSameNode.ParentNode;
            mInitAction?.Invoke(this);
        }

        public override StateOfATNParsing_v2 GlobalState => StateOfATNParsing_v2.ModalVerb_There_Be_No_Trans;

        public ATNModalVerbThereBeTransNode_v2 ParentNode { get; private set; }
        private ATNModalVerbThereBeNoTransNode_v2 mSameNode;
        private InitATNModalVerbThereBeNoTransNodeAction mInitAction;

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

