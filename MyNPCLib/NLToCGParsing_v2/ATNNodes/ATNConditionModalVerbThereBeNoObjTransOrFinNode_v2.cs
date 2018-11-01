using MyNPCLib.NLToCGParsing;
using System;
using System.Collections.Generic;
using System.Text;

namespace MyNPCLib.NLToCGParsing_v2.ATNNodes
{
    public delegate void InitATNConditionModalVerbThereBeNoObjTransOrFinNodeAction(ATNConditionModalVerbThereBeNoObjTransOrFinNode_v2 item);

    public class ATNConditionModalVerbThereBeNoObjTransOrFinNodeFactory_v2: BaseATNNodeFactory_v2
    {
        public ATNConditionModalVerbThereBeNoObjTransOrFinNodeFactory_v2(ATNConditionModalVerbThereBeNoTransNode_v2 parentNode, ATNExtendedToken token)
        {
            mNumberOfConstructor = 1;
            mParentNode = parentNode;
            mToken = token;
        }

        public ATNConditionModalVerbThereBeNoObjTransOrFinNodeFactory_v2(ATNConditionModalVerbThereBeNoObjTransOrFinNode_v2 sameNode, ATNExtendedToken token, InitATNConditionModalVerbThereBeNoObjTransOrFinNodeAction initAction)
        {
            mNumberOfConstructor = 2;
            mSameNode = sameNode;
            mToken = token;
            mInitAction = initAction;
        }

        private int mNumberOfConstructor;
        private ATNConditionModalVerbThereBeNoTransNode_v2 mParentNode;
        private ATNConditionModalVerbThereBeNoObjTransOrFinNode_v2 mSameNode;
        private ATNExtendedToken mToken;
        private InitATNConditionModalVerbThereBeNoObjTransOrFinNodeAction mInitAction;

        public override BaseATNNode_v2 Create(ContextOfATNParsing_v2 context)
        {
            switch(mNumberOfConstructor)
            {
                case 1:
                    return new ATNConditionModalVerbThereBeNoObjTransOrFinNode_v2(context, mParentNode, mToken);

                case 2:
                    return new ATNConditionModalVerbThereBeNoObjTransOrFinNode_v2(context, mSameNode, mInitAction, mToken);

                default:
                    throw new ArgumentOutOfRangeException(nameof(mNumberOfConstructor), mNumberOfConstructor, null);
            }
        }
    }

/*Sub states:
    Condition_ModalVerb_There_Be_No_Obj_Condition_Fin
*/

    public class ATNConditionModalVerbThereBeNoObjTransOrFinNode_v2: BaseATNNode_v2
    {
        public ATNConditionModalVerbThereBeNoObjTransOrFinNode_v2(ContextOfATNParsing_v2 context, ATNConditionModalVerbThereBeNoTransNode_v2 parentNode, ATNExtendedToken token)
            : base(context, token)
        {
            ParentNode = parentNode;
        }

        public ATNConditionModalVerbThereBeNoObjTransOrFinNode_v2(ContextOfATNParsing_v2 context, ATNConditionModalVerbThereBeNoObjTransOrFinNode_v2 sameNode, InitATNConditionModalVerbThereBeNoObjTransOrFinNodeAction initAction, ATNExtendedToken token)
            : base(context, token)
        {
            mSameNode = sameNode;
            mInitAction = initAction;
            ParentNode = mSameNode.ParentNode;
            mInitAction?.Invoke(this);
        }

        public override StateOfATNParsing_v2 GlobalState => StateOfATNParsing_v2.Condition_ModalVerb_There_Be_No_Obj_TransOrFin;

        public ATNConditionModalVerbThereBeNoTransNode_v2 ParentNode { get; private set; }
        private ATNConditionModalVerbThereBeNoObjTransOrFinNode_v2 mSameNode;
        private InitATNConditionModalVerbThereBeNoObjTransOrFinNodeAction mInitAction;

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

