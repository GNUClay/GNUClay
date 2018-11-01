using MyNPCLib.NLToCGParsing;
using System;
using System.Collections.Generic;
using System.Text;

namespace MyNPCLib.NLToCGParsing_v2.ATNNodes
{
    public delegate void InitATNConditionThereModalVerbBeNoTransNodeAction(ATNConditionThereModalVerbBeNoTransNode_v2 item);

    public class ATNConditionThereModalVerbBeNoTransNodeFactory_v2: BaseATNNodeFactory_v2
    {
        public ATNConditionThereModalVerbBeNoTransNodeFactory_v2(ATNConditionThereModalVerbBeTransNode_v2 parentNode, ATNExtendedToken token)
        {
            mNumberOfConstructor = 1;
            mParentNode = parentNode;
            mToken = token;
        }

        public ATNConditionThereModalVerbBeNoTransNodeFactory_v2(ATNConditionThereModalVerbBeNoTransNode_v2 sameNode, ATNExtendedToken token, InitATNConditionThereModalVerbBeNoTransNodeAction initAction)
        {
            mNumberOfConstructor = 2;
            mSameNode = sameNode;
            mToken = token;
            mInitAction = initAction;
        }

        private int mNumberOfConstructor;
        private ATNConditionThereModalVerbBeTransNode_v2 mParentNode;
        private ATNConditionThereModalVerbBeNoTransNode_v2 mSameNode;
        private ATNExtendedToken mToken;
        private InitATNConditionThereModalVerbBeNoTransNodeAction mInitAction;

        public override BaseATNNode_v2 Create(ContextOfATNParsing_v2 context)
        {
            switch(mNumberOfConstructor)
            {
                case 1:
                    return new ATNConditionThereModalVerbBeNoTransNode_v2(context, mParentNode, mToken);

                case 2:
                    return new ATNConditionThereModalVerbBeNoTransNode_v2(context, mSameNode, mInitAction, mToken);

                default:
                    throw new ArgumentOutOfRangeException(nameof(mNumberOfConstructor), mNumberOfConstructor, null);
            }
        }
    }

/*Sub states:
    Condition_There_ModalVerb_Be_No_Obj_TransOrFin
*/

    public class ATNConditionThereModalVerbBeNoTransNode_v2: BaseATNNode_v2
    {
        public ATNConditionThereModalVerbBeNoTransNode_v2(ContextOfATNParsing_v2 context, ATNConditionThereModalVerbBeTransNode_v2 parentNode, ATNExtendedToken token)
            : base(context, token)
        {
            ParentNode = parentNode;
        }

        public ATNConditionThereModalVerbBeNoTransNode_v2(ContextOfATNParsing_v2 context, ATNConditionThereModalVerbBeNoTransNode_v2 sameNode, InitATNConditionThereModalVerbBeNoTransNodeAction initAction, ATNExtendedToken token)
            : base(context, token)
        {
            mSameNode = sameNode;
            mInitAction = initAction;
            ParentNode = mSameNode.ParentNode;
            mInitAction?.Invoke(this);
        }

        public override StateOfATNParsing_v2 GlobalState => StateOfATNParsing_v2.Condition_There_ModalVerb_Be_No_Trans;

        public ATNConditionThereModalVerbBeTransNode_v2 ParentNode { get; private set; }
        private ATNConditionThereModalVerbBeNoTransNode_v2 mSameNode;
        private InitATNConditionThereModalVerbBeNoTransNodeAction mInitAction;

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

