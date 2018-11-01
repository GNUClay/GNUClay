using MyNPCLib.NLToCGParsing;
using System;
using System.Collections.Generic;
using System.Text;

namespace MyNPCLib.NLToCGParsing_v2.ATNNodes
{
    public delegate void InitATNConditionThereModalVerbNotBeTransNodeAction(ATNConditionThereModalVerbNotBeTransNode_v2 item);

    public class ATNConditionThereModalVerbNotBeTransNodeFactory_v2: BaseATNNodeFactory_v2
    {
        public ATNConditionThereModalVerbNotBeTransNodeFactory_v2(ATNConditionThereModalVerbNotTransNode_v2 parentNode, ATNExtendedToken token)
        {
            mNumberOfConstructor = 1;
            mParentNode = parentNode;
            mToken = token;
        }

        public ATNConditionThereModalVerbNotBeTransNodeFactory_v2(ATNConditionThereModalVerbNotBeTransNode_v2 sameNode, ATNExtendedToken token, InitATNConditionThereModalVerbNotBeTransNodeAction initAction)
        {
            mNumberOfConstructor = 2;
            mSameNode = sameNode;
            mToken = token;
            mInitAction = initAction;
        }

        private int mNumberOfConstructor;
        private ATNConditionThereModalVerbNotTransNode_v2 mParentNode;
        private ATNConditionThereModalVerbNotBeTransNode_v2 mSameNode;
        private ATNExtendedToken mToken;
        private InitATNConditionThereModalVerbNotBeTransNodeAction mInitAction;

        public override BaseATNNode_v2 Create(ContextOfATNParsing_v2 context)
        {
            switch(mNumberOfConstructor)
            {
                case 1:
                    return new ATNConditionThereModalVerbNotBeTransNode_v2(context, mParentNode, mToken);

                case 2:
                    return new ATNConditionThereModalVerbNotBeTransNode_v2(context, mSameNode, mInitAction, mToken);

                default:
                    throw new ArgumentOutOfRangeException(nameof(mNumberOfConstructor), mNumberOfConstructor, null);
            }
        }
    }

/*Sub states:
    Condition_There_ModalVerb_Not_Be_Obj_TransOrFin
*/

    public class ATNConditionThereModalVerbNotBeTransNode_v2: BaseATNNode_v2
    {
        public ATNConditionThereModalVerbNotBeTransNode_v2(ContextOfATNParsing_v2 context, ATNConditionThereModalVerbNotTransNode_v2 parentNode, ATNExtendedToken token)
            : base(context, token)
        {
            ParentNode = parentNode;
        }

        public ATNConditionThereModalVerbNotBeTransNode_v2(ContextOfATNParsing_v2 context, ATNConditionThereModalVerbNotBeTransNode_v2 sameNode, InitATNConditionThereModalVerbNotBeTransNodeAction initAction, ATNExtendedToken token)
            : base(context, token)
        {
            mSameNode = sameNode;
            mInitAction = initAction;
            ParentNode = mSameNode.ParentNode;
            mInitAction?.Invoke(this);
        }

        public override StateOfATNParsing_v2 GlobalState => StateOfATNParsing_v2.Condition_There_ModalVerb_Not_Be_Trans;

        public ATNConditionThereModalVerbNotTransNode_v2 ParentNode { get; private set; }
        private ATNConditionThereModalVerbNotBeTransNode_v2 mSameNode;
        private InitATNConditionThereModalVerbNotBeTransNodeAction mInitAction;

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

