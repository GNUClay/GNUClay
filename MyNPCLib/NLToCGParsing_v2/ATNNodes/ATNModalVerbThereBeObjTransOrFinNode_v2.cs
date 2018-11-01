using MyNPCLib.NLToCGParsing;
using System;
using System.Collections.Generic;
using System.Text;

namespace MyNPCLib.NLToCGParsing_v2.ATNNodes
{
    public delegate void InitATNModalVerbThereBeObjTransOrFinNodeAction(ATNModalVerbThereBeObjTransOrFinNode_v2 item);

    public class ATNModalVerbThereBeObjTransOrFinNodeFactory_v2: BaseATNNodeFactory_v2
    {
        public ATNModalVerbThereBeObjTransOrFinNodeFactory_v2(ATNModalVerbThereBeTransNode_v2 parentNode, ATNExtendedToken token)
        {
            mNumberOfConstructor = 1;
            mParentNode = parentNode;
            mToken = token;
        }

        public ATNModalVerbThereBeObjTransOrFinNodeFactory_v2(ATNModalVerbThereBeObjTransOrFinNode_v2 sameNode, ATNExtendedToken token, InitATNModalVerbThereBeObjTransOrFinNodeAction initAction)
        {
            mNumberOfConstructor = 2;
            mSameNode = sameNode;
            mToken = token;
            mInitAction = initAction;
        }

        private int mNumberOfConstructor;
        private ATNModalVerbThereBeTransNode_v2 mParentNode;
        private ATNModalVerbThereBeObjTransOrFinNode_v2 mSameNode;
        private ATNExtendedToken mToken;
        private InitATNModalVerbThereBeObjTransOrFinNodeAction mInitAction;

        public override BaseATNNode_v2 Create(ContextOfATNParsing_v2 context)
        {
            switch(mNumberOfConstructor)
            {
                case 1:
                    return new ATNModalVerbThereBeObjTransOrFinNode_v2(context, mParentNode, mToken);

                case 2:
                    return new ATNModalVerbThereBeObjTransOrFinNode_v2(context, mSameNode, mInitAction, mToken);

                default:
                    throw new ArgumentOutOfRangeException(nameof(mNumberOfConstructor), mNumberOfConstructor, null);
            }
        }
    }

/*Sub states:
    ModalVerb_There_Be_Obj_Condition_Fin
*/

    public class ATNModalVerbThereBeObjTransOrFinNode_v2: BaseATNNode_v2
    {
        public ATNModalVerbThereBeObjTransOrFinNode_v2(ContextOfATNParsing_v2 context, ATNModalVerbThereBeTransNode_v2 parentNode, ATNExtendedToken token)
            : base(context, token)
        {
            ParentNode = parentNode;
        }

        public ATNModalVerbThereBeObjTransOrFinNode_v2(ContextOfATNParsing_v2 context, ATNModalVerbThereBeObjTransOrFinNode_v2 sameNode, InitATNModalVerbThereBeObjTransOrFinNodeAction initAction, ATNExtendedToken token)
            : base(context, token)
        {
            mSameNode = sameNode;
            mInitAction = initAction;
            ParentNode = mSameNode.ParentNode;
            mInitAction?.Invoke(this);
        }

        public override StateOfATNParsing_v2 GlobalState => StateOfATNParsing_v2.ModalVerb_There_Be_Obj_TransOrFin;

        public ATNModalVerbThereBeTransNode_v2 ParentNode { get; private set; }
        private ATNModalVerbThereBeObjTransOrFinNode_v2 mSameNode;
        private InitATNModalVerbThereBeObjTransOrFinNodeAction mInitAction;

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

