using MyNPCLib.NLToCGParsing;
using System;
using System.Collections.Generic;
using System.Text;

namespace MyNPCLib.NLToCGParsing_v2.ATNNodes
{
    public delegate void InitATNThereTransNodeAction(ATNThereTransNode_v2 item);

    public class ATNThereTransNodeFactory_v2: BaseATNNodeFactory_v2
    {
        public ATNThereTransNodeFactory_v2(ATNInitNode_v2 parentNode, ATNExtendedToken token)
        {
            mNumberOfConstructor = 1;
            mParentNode = parentNode;
            mToken = token;
        }

        public ATNThereTransNodeFactory_v2(ATNThereTransNode_v2 sameNode, ATNExtendedToken token, InitATNThereTransNodeAction initAction)
        {
            mNumberOfConstructor = 2;
            mSameNode = sameNode;
            mToken = token;
            mInitAction = initAction;
        }

        private int mNumberOfConstructor;
        private ATNInitNode_v2 mParentNode;
        private ATNThereTransNode_v2 mSameNode;
        private ATNExtendedToken mToken;
        private InitATNThereTransNodeAction mInitAction;

        public override BaseATNNode_v2 Create(ContextOfATNParsing_v2 context)
        {
            switch(mNumberOfConstructor)
            {
                case 1:
                    return new ATNThereTransNode_v2(context, mParentNode, mToken);

                case 2:
                    return new ATNThereTransNode_v2(context, mSameNode, mInitAction, mToken);

                default:
                    throw new ArgumentOutOfRangeException(nameof(mNumberOfConstructor), mNumberOfConstructor, null);
            }
        }
    }

/*Sub states:
    There_FToBe_Trans
    There_ModalVerb_Trans
*/

    public class ATNThereTransNode_v2: BaseATNNode_v2
    {
        public ATNThereTransNode_v2(ContextOfATNParsing_v2 context, ATNInitNode_v2 parentNode, ATNExtendedToken token)
            : base(context, token)
        {
            ParentNode = parentNode;
        }

        public ATNThereTransNode_v2(ContextOfATNParsing_v2 context, ATNThereTransNode_v2 sameNode, InitATNThereTransNodeAction initAction, ATNExtendedToken token)
            : base(context, token)
        {
            mSameNode = sameNode;
            mInitAction = initAction;
            ParentNode = mSameNode.ParentNode;
            mInitAction?.Invoke(this);
        }

        public override StateOfATNParsing_v2 GlobalState => StateOfATNParsing_v2.There_Trans;

        public ATNInitNode_v2 ParentNode { get; private set; }
        private ATNThereTransNode_v2 mSameNode;
        private InitATNThereTransNodeAction mInitAction;

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

