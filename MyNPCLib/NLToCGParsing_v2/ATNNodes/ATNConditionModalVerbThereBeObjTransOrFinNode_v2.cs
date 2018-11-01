using MyNPCLib.NLToCGParsing;
using System;
using System.Collections.Generic;
using System.Text;

namespace MyNPCLib.NLToCGParsing_v2.ATNNodes
{
    public delegate void InitATNConditionModalVerbThereBeObjTransOrFinNodeAction(ATNConditionModalVerbThereBeObjTransOrFinNode_v2 item);

    public class ATNConditionModalVerbThereBeObjTransOrFinNodeFactory_v2: BaseATNNodeFactory_v2
    {
        public ATNConditionModalVerbThereBeObjTransOrFinNodeFactory_v2(ATNConditionModalVerbThereBeTransNode_v2 parentNode, ATNExtendedToken token)
        {
            mNumberOfConstructor = 1;
            mParentNode = parentNode;
            mToken = token;
        }

        public ATNConditionModalVerbThereBeObjTransOrFinNodeFactory_v2(ATNConditionModalVerbThereBeObjTransOrFinNode_v2 sameNode, ATNExtendedToken token, InitATNConditionModalVerbThereBeObjTransOrFinNodeAction initAction)
        {
            mNumberOfConstructor = 2;
            mSameNode = sameNode;
            mToken = token;
            mInitAction = initAction;
        }

        private int mNumberOfConstructor;
        private ATNConditionModalVerbThereBeTransNode_v2 mParentNode;
        private ATNConditionModalVerbThereBeObjTransOrFinNode_v2 mSameNode;
        private ATNExtendedToken mToken;
        private InitATNConditionModalVerbThereBeObjTransOrFinNodeAction mInitAction;

        public override BaseATNNode_v2 Create(ContextOfATNParsing_v2 context)
        {
            switch(mNumberOfConstructor)
            {
                case 1:
                    return new ATNConditionModalVerbThereBeObjTransOrFinNode_v2(context, mParentNode, mToken);

                case 2:
                    return new ATNConditionModalVerbThereBeObjTransOrFinNode_v2(context, mSameNode, mInitAction, mToken);

                default:
                    throw new ArgumentOutOfRangeException(nameof(mNumberOfConstructor), mNumberOfConstructor, null);
            }
        }
    }

/*Sub states:
    Condition_ModalVerb_There_Be_Obj_Condition_Fin
*/

    public class ATNConditionModalVerbThereBeObjTransOrFinNode_v2: BaseATNNode_v2
    {
        public ATNConditionModalVerbThereBeObjTransOrFinNode_v2(ContextOfATNParsing_v2 context, ATNConditionModalVerbThereBeTransNode_v2 parentNode, ATNExtendedToken token)
            : base(context, token)
        {
            ParentNode = parentNode;
        }

        public ATNConditionModalVerbThereBeObjTransOrFinNode_v2(ContextOfATNParsing_v2 context, ATNConditionModalVerbThereBeObjTransOrFinNode_v2 sameNode, InitATNConditionModalVerbThereBeObjTransOrFinNodeAction initAction, ATNExtendedToken token)
            : base(context, token)
        {
            mSameNode = sameNode;
            mInitAction = initAction;
            ParentNode = mSameNode.ParentNode;
            mInitAction?.Invoke(this);
        }

        public override StateOfATNParsing_v2 GlobalState => StateOfATNParsing_v2.Condition_ModalVerb_There_Be_Obj_TransOrFin;

        public ATNConditionModalVerbThereBeTransNode_v2 ParentNode { get; private set; }
        private ATNConditionModalVerbThereBeObjTransOrFinNode_v2 mSameNode;
        private InitATNConditionModalVerbThereBeObjTransOrFinNodeAction mInitAction;

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

