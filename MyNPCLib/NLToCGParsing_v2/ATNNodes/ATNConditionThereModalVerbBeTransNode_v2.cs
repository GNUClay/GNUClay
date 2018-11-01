using MyNPCLib.NLToCGParsing;
using System;
using System.Collections.Generic;
using System.Text;

namespace MyNPCLib.NLToCGParsing_v2.ATNNodes
{
    public delegate void InitATNConditionThereModalVerbBeTransNodeAction(ATNConditionThereModalVerbBeTransNode_v2 item);

    public class ATNConditionThereModalVerbBeTransNodeFactory_v2: BaseATNNodeFactory_v2
    {
        public ATNConditionThereModalVerbBeTransNodeFactory_v2(ATNConditionThereModalVerbTransNode_v2 parentNode, ATNExtendedToken token)
        {
            mNumberOfConstructor = 1;
            mParentNode = parentNode;
            mToken = token;
        }

        public ATNConditionThereModalVerbBeTransNodeFactory_v2(ATNConditionThereModalVerbBeTransNode_v2 sameNode, ATNExtendedToken token, InitATNConditionThereModalVerbBeTransNodeAction initAction)
        {
            mNumberOfConstructor = 2;
            mSameNode = sameNode;
            mToken = token;
            mInitAction = initAction;
        }

        private int mNumberOfConstructor;
        private ATNConditionThereModalVerbTransNode_v2 mParentNode;
        private ATNConditionThereModalVerbBeTransNode_v2 mSameNode;
        private ATNExtendedToken mToken;
        private InitATNConditionThereModalVerbBeTransNodeAction mInitAction;

        public override BaseATNNode_v2 Create(ContextOfATNParsing_v2 context)
        {
            switch(mNumberOfConstructor)
            {
                case 1:
                    return new ATNConditionThereModalVerbBeTransNode_v2(context, mParentNode, mToken);

                case 2:
                    return new ATNConditionThereModalVerbBeTransNode_v2(context, mSameNode, mInitAction, mToken);

                default:
                    throw new ArgumentOutOfRangeException(nameof(mNumberOfConstructor), mNumberOfConstructor, null);
            }
        }
    }

/*Sub states:
    Condition_There_ModalVerb_Be_Obj_TransOrFin
    Condition_There_ModalVerb_Be_No_Trans
*/

    public class ATNConditionThereModalVerbBeTransNode_v2: BaseATNNode_v2
    {
        public ATNConditionThereModalVerbBeTransNode_v2(ContextOfATNParsing_v2 context, ATNConditionThereModalVerbTransNode_v2 parentNode, ATNExtendedToken token)
            : base(context, token)
        {
            ParentNode = parentNode;
        }

        public ATNConditionThereModalVerbBeTransNode_v2(ContextOfATNParsing_v2 context, ATNConditionThereModalVerbBeTransNode_v2 sameNode, InitATNConditionThereModalVerbBeTransNodeAction initAction, ATNExtendedToken token)
            : base(context, token)
        {
            mSameNode = sameNode;
            mInitAction = initAction;
            ParentNode = mSameNode.ParentNode;
            mInitAction?.Invoke(this);
        }

        public override StateOfATNParsing_v2 GlobalState => StateOfATNParsing_v2.Condition_There_ModalVerb_Be_Trans;

        public ATNConditionThereModalVerbTransNode_v2 ParentNode { get; private set; }
        private ATNConditionThereModalVerbBeTransNode_v2 mSameNode;
        private InitATNConditionThereModalVerbBeTransNodeAction mInitAction;

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

