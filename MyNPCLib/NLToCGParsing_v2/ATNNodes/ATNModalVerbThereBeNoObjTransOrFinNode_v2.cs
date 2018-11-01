using MyNPCLib.NLToCGParsing;
using System;
using System.Collections.Generic;
using System.Text;

namespace MyNPCLib.NLToCGParsing_v2.ATNNodes
{
    public delegate void InitATNModalVerbThereBeNoObjTransOrFinNodeAction(ATNModalVerbThereBeNoObjTransOrFinNode_v2 item);

    public class ATNModalVerbThereBeNoObjTransOrFinNodeFactory_v2: BaseATNNodeFactory_v2
    {
        public ATNModalVerbThereBeNoObjTransOrFinNodeFactory_v2(ATNModalVerbThereBeNoTransNode_v2 parentNode, ATNExtendedToken token)
        {
            mNumberOfConstructor = 1;
            mParentNode = parentNode;
            mToken = token;
        }

        public ATNModalVerbThereBeNoObjTransOrFinNodeFactory_v2(ATNModalVerbThereBeNoObjTransOrFinNode_v2 sameNode, ATNExtendedToken token, InitATNModalVerbThereBeNoObjTransOrFinNodeAction initAction)
        {
            mNumberOfConstructor = 2;
            mSameNode = sameNode;
            mToken = token;
            mInitAction = initAction;
        }

        private int mNumberOfConstructor;
        private ATNModalVerbThereBeNoTransNode_v2 mParentNode;
        private ATNModalVerbThereBeNoObjTransOrFinNode_v2 mSameNode;
        private ATNExtendedToken mToken;
        private InitATNModalVerbThereBeNoObjTransOrFinNodeAction mInitAction;

        public override BaseATNNode_v2 Create(ContextOfATNParsing_v2 context)
        {
            switch(mNumberOfConstructor)
            {
                case 1:
                    return new ATNModalVerbThereBeNoObjTransOrFinNode_v2(context, mParentNode, mToken);

                case 2:
                    return new ATNModalVerbThereBeNoObjTransOrFinNode_v2(context, mSameNode, mInitAction, mToken);

                default:
                    throw new ArgumentOutOfRangeException(nameof(mNumberOfConstructor), mNumberOfConstructor, null);
            }
        }
    }

/*Sub states:
    ModalVerb_There_Be_No_Obj_Condition_Fin
*/

    public class ATNModalVerbThereBeNoObjTransOrFinNode_v2: BaseATNNode_v2
    {
        public ATNModalVerbThereBeNoObjTransOrFinNode_v2(ContextOfATNParsing_v2 context, ATNModalVerbThereBeNoTransNode_v2 parentNode, ATNExtendedToken token)
            : base(context, token)
        {
            ParentNode = parentNode;
        }

        public ATNModalVerbThereBeNoObjTransOrFinNode_v2(ContextOfATNParsing_v2 context, ATNModalVerbThereBeNoObjTransOrFinNode_v2 sameNode, InitATNModalVerbThereBeNoObjTransOrFinNodeAction initAction, ATNExtendedToken token)
            : base(context, token)
        {
            mSameNode = sameNode;
            mInitAction = initAction;
            ParentNode = mSameNode.ParentNode;
            mInitAction?.Invoke(this);
        }

        public override StateOfATNParsing_v2 GlobalState => StateOfATNParsing_v2.ModalVerb_There_Be_No_Obj_TransOrFin;

        public ATNModalVerbThereBeNoTransNode_v2 ParentNode { get; private set; }
        private ATNModalVerbThereBeNoObjTransOrFinNode_v2 mSameNode;
        private InitATNModalVerbThereBeNoObjTransOrFinNodeAction mInitAction;

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

