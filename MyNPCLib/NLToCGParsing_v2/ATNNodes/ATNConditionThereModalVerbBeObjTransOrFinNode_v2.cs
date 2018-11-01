using MyNPCLib.NLToCGParsing;
using System;
using System.Collections.Generic;
using System.Text;

namespace MyNPCLib.NLToCGParsing_v2.ATNNodes
{
    public delegate void InitATNConditionThereModalVerbBeObjTransOrFinNodeAction(ATNConditionThereModalVerbBeObjTransOrFinNode_v2 item);

    public class ATNConditionThereModalVerbBeObjTransOrFinNodeFactory_v2: BaseATNNodeFactory_v2
    {
        public ATNConditionThereModalVerbBeObjTransOrFinNodeFactory_v2(ATNConditionThereModalVerbBeTransNode_v2 parentNode, ATNExtendedToken token)
        {
            mNumberOfConstructor = 1;
            mParentNode = parentNode;
            mToken = token;
        }

        public ATNConditionThereModalVerbBeObjTransOrFinNodeFactory_v2(ATNConditionThereModalVerbBeObjTransOrFinNode_v2 sameNode, ATNExtendedToken token, InitATNConditionThereModalVerbBeObjTransOrFinNodeAction initAction)
        {
            mNumberOfConstructor = 2;
            mSameNode = sameNode;
            mToken = token;
            mInitAction = initAction;
        }

        private int mNumberOfConstructor;
        private ATNConditionThereModalVerbBeTransNode_v2 mParentNode;
        private ATNConditionThereModalVerbBeObjTransOrFinNode_v2 mSameNode;
        private ATNExtendedToken mToken;
        private InitATNConditionThereModalVerbBeObjTransOrFinNodeAction mInitAction;

        public override BaseATNNode_v2 Create(ContextOfATNParsing_v2 context)
        {
            switch(mNumberOfConstructor)
            {
                case 1:
                    return new ATNConditionThereModalVerbBeObjTransOrFinNode_v2(context, mParentNode, mToken);

                case 2:
                    return new ATNConditionThereModalVerbBeObjTransOrFinNode_v2(context, mSameNode, mInitAction, mToken);

                default:
                    throw new ArgumentOutOfRangeException(nameof(mNumberOfConstructor), mNumberOfConstructor, null);
            }
        }
    }

/*Sub states:
    Condition_There_ModalVerb_Be_Obj_Condition_Fin
*/

    public class ATNConditionThereModalVerbBeObjTransOrFinNode_v2: BaseATNNode_v2
    {
        public ATNConditionThereModalVerbBeObjTransOrFinNode_v2(ContextOfATNParsing_v2 context, ATNConditionThereModalVerbBeTransNode_v2 parentNode, ATNExtendedToken token)
            : base(context, token)
        {
            ParentNode = parentNode;
        }

        public ATNConditionThereModalVerbBeObjTransOrFinNode_v2(ContextOfATNParsing_v2 context, ATNConditionThereModalVerbBeObjTransOrFinNode_v2 sameNode, InitATNConditionThereModalVerbBeObjTransOrFinNodeAction initAction, ATNExtendedToken token)
            : base(context, token)
        {
            mSameNode = sameNode;
            mInitAction = initAction;
            ParentNode = mSameNode.ParentNode;
            mInitAction?.Invoke(this);
        }

        public override StateOfATNParsing_v2 GlobalState => StateOfATNParsing_v2.Condition_There_ModalVerb_Be_Obj_TransOrFin;

        public ATNConditionThereModalVerbBeTransNode_v2 ParentNode { get; private set; }
        private ATNConditionThereModalVerbBeObjTransOrFinNode_v2 mSameNode;
        private InitATNConditionThereModalVerbBeObjTransOrFinNodeAction mInitAction;

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

