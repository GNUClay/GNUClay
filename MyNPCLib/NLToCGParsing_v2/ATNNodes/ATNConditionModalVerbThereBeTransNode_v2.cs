using MyNPCLib.NLToCGParsing;
using System;
using System.Collections.Generic;
using System.Text;

namespace MyNPCLib.NLToCGParsing_v2.ATNNodes
{
    public delegate void InitATNConditionModalVerbThereBeTransNodeAction(ATNConditionModalVerbThereBeTransNode_v2 item);

    public class ATNConditionModalVerbThereBeTransNodeFactory_v2: BaseATNNodeFactory_v2
    {
        public ATNConditionModalVerbThereBeTransNodeFactory_v2(ATNConditionModalVerbThereTransNode_v2 parentNode, ATNExtendedToken token)
        {
            mNumberOfConstructor = 1;
            mParentNode = parentNode;
            mToken = token;
        }

        public ATNConditionModalVerbThereBeTransNodeFactory_v2(ATNConditionModalVerbThereBeTransNode_v2 sameNode, ATNExtendedToken token, InitATNConditionModalVerbThereBeTransNodeAction initAction)
        {
            mNumberOfConstructor = 2;
            mSameNode = sameNode;
            mToken = token;
            mInitAction = initAction;
        }

        private int mNumberOfConstructor;
        private ATNConditionModalVerbThereTransNode_v2 mParentNode;
        private ATNConditionModalVerbThereBeTransNode_v2 mSameNode;
        private ATNExtendedToken mToken;
        private InitATNConditionModalVerbThereBeTransNodeAction mInitAction;

        public override BaseATNNode_v2 Create(ContextOfATNParsing_v2 context)
        {
            switch(mNumberOfConstructor)
            {
                case 1:
                    return new ATNConditionModalVerbThereBeTransNode_v2(context, mParentNode, mToken);

                case 2:
                    return new ATNConditionModalVerbThereBeTransNode_v2(context, mSameNode, mInitAction, mToken);

                default:
                    throw new ArgumentOutOfRangeException(nameof(mNumberOfConstructor), mNumberOfConstructor, null);
            }
        }
    }

/*Sub states:
    Condition_ModalVerb_There_Be_Obj_TransOrFin
    Condition_ModalVerb_There_Be_No_Trans
*/

    public class ATNConditionModalVerbThereBeTransNode_v2: BaseATNNode_v2
    {
        public ATNConditionModalVerbThereBeTransNode_v2(ContextOfATNParsing_v2 context, ATNConditionModalVerbThereTransNode_v2 parentNode, ATNExtendedToken token)
            : base(context, token)
        {
            ParentNode = parentNode;
        }

        public ATNConditionModalVerbThereBeTransNode_v2(ContextOfATNParsing_v2 context, ATNConditionModalVerbThereBeTransNode_v2 sameNode, InitATNConditionModalVerbThereBeTransNodeAction initAction, ATNExtendedToken token)
            : base(context, token)
        {
            mSameNode = sameNode;
            mInitAction = initAction;
            ParentNode = mSameNode.ParentNode;
            mInitAction?.Invoke(this);
        }

        public override StateOfATNParsing_v2 GlobalState => StateOfATNParsing_v2.Condition_ModalVerb_There_Be_Trans;

        public ATNConditionModalVerbThereTransNode_v2 ParentNode { get; private set; }
        private ATNConditionModalVerbThereBeTransNode_v2 mSameNode;
        private InitATNConditionModalVerbThereBeTransNodeAction mInitAction;

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

