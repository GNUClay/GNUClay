using MyNPCLib.NLToCGParsing;
using System;
using System.Collections.Generic;
using System.Text;

namespace MyNPCLib.NLToCGParsing_v2.ATNNodes
{
    public delegate void InitATNThereModalVerbBeNoObjTransOrFinNodeAction(ATNThereModalVerbBeNoObjTransOrFinNode_v2 item);

    public class ATNThereModalVerbBeNoObjTransOrFinNodeFactory_v2: BaseATNNodeFactory_v2
    {
        public ATNThereModalVerbBeNoObjTransOrFinNodeFactory_v2(ATNThereModalVerbBeNoTransNode_v2 parentNode, ATNExtendedToken token)
        {
            mNumberOfConstructor = 1;
            mParentNode = parentNode;
            mToken = token;
        }

        public ATNThereModalVerbBeNoObjTransOrFinNodeFactory_v2(ATNThereModalVerbBeNoObjTransOrFinNode_v2 sameNode, ATNExtendedToken token, InitATNThereModalVerbBeNoObjTransOrFinNodeAction initAction)
        {
            mNumberOfConstructor = 2;
            mSameNode = sameNode;
            mToken = token;
            mInitAction = initAction;
        }

        private int mNumberOfConstructor;
        private ATNThereModalVerbBeNoTransNode_v2 mParentNode;
        private ATNThereModalVerbBeNoObjTransOrFinNode_v2 mSameNode;
        private ATNExtendedToken mToken;
        private InitATNThereModalVerbBeNoObjTransOrFinNodeAction mInitAction;

        public override BaseATNNode_v2 Create(ContextOfATNParsing_v2 context)
        {
            switch(mNumberOfConstructor)
            {
                case 1:
                    return new ATNThereModalVerbBeNoObjTransOrFinNode_v2(context, mParentNode, mToken);

                case 2:
                    return new ATNThereModalVerbBeNoObjTransOrFinNode_v2(context, mSameNode, mInitAction, mToken);

                default:
                    throw new ArgumentOutOfRangeException(nameof(mNumberOfConstructor), mNumberOfConstructor, null);
            }
        }
    }

/*Sub states:
    There_ModalVerb_Be_No_Obj_Condition_Fin
*/

    public class ATNThereModalVerbBeNoObjTransOrFinNode_v2: BaseATNNode_v2
    {
        public ATNThereModalVerbBeNoObjTransOrFinNode_v2(ContextOfATNParsing_v2 context, ATNThereModalVerbBeNoTransNode_v2 parentNode, ATNExtendedToken token)
            : base(context, token)
        {
            ParentNode = parentNode;
        }

        public ATNThereModalVerbBeNoObjTransOrFinNode_v2(ContextOfATNParsing_v2 context, ATNThereModalVerbBeNoObjTransOrFinNode_v2 sameNode, InitATNThereModalVerbBeNoObjTransOrFinNodeAction initAction, ATNExtendedToken token)
            : base(context, token)
        {
            mSameNode = sameNode;
            mInitAction = initAction;
            ParentNode = mSameNode.ParentNode;
            mInitAction?.Invoke(this);
        }

        public override StateOfATNParsing_v2 GlobalState => StateOfATNParsing_v2.There_ModalVerb_Be_No_Obj_TransOrFin;

        public ATNThereModalVerbBeNoTransNode_v2 ParentNode { get; private set; }
        private ATNThereModalVerbBeNoObjTransOrFinNode_v2 mSameNode;
        private InitATNThereModalVerbBeNoObjTransOrFinNodeAction mInitAction;

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

