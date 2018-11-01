using MyNPCLib.NLToCGParsing;
using System;
using System.Collections.Generic;
using System.Text;

namespace MyNPCLib.NLToCGParsing_v2.ATNNodes
{
    public delegate void InitATNThereModalVerbBeObjTransOrFinNodeAction(ATNThereModalVerbBeObjTransOrFinNode_v2 item);

    public class ATNThereModalVerbBeObjTransOrFinNodeFactory_v2: BaseATNNodeFactory_v2
    {
        public ATNThereModalVerbBeObjTransOrFinNodeFactory_v2(ATNThereModalVerbBeTransNode_v2 parentNode, ATNExtendedToken token)
        {
            mNumberOfConstructor = 1;
            mParentNode = parentNode;
            mToken = token;
        }

        public ATNThereModalVerbBeObjTransOrFinNodeFactory_v2(ATNThereModalVerbBeObjTransOrFinNode_v2 sameNode, ATNExtendedToken token, InitATNThereModalVerbBeObjTransOrFinNodeAction initAction)
        {
            mNumberOfConstructor = 2;
            mSameNode = sameNode;
            mToken = token;
            mInitAction = initAction;
        }

        private int mNumberOfConstructor;
        private ATNThereModalVerbBeTransNode_v2 mParentNode;
        private ATNThereModalVerbBeObjTransOrFinNode_v2 mSameNode;
        private ATNExtendedToken mToken;
        private InitATNThereModalVerbBeObjTransOrFinNodeAction mInitAction;

        public override BaseATNNode_v2 Create(ContextOfATNParsing_v2 context)
        {
            switch(mNumberOfConstructor)
            {
                case 1:
                    return new ATNThereModalVerbBeObjTransOrFinNode_v2(context, mParentNode, mToken);

                case 2:
                    return new ATNThereModalVerbBeObjTransOrFinNode_v2(context, mSameNode, mInitAction, mToken);

                default:
                    throw new ArgumentOutOfRangeException(nameof(mNumberOfConstructor), mNumberOfConstructor, null);
            }
        }
    }

/*Sub states:
    There_ModalVerb_Be_Obj_Condition_Fin
*/

    public class ATNThereModalVerbBeObjTransOrFinNode_v2: BaseATNNode_v2
    {
        public ATNThereModalVerbBeObjTransOrFinNode_v2(ContextOfATNParsing_v2 context, ATNThereModalVerbBeTransNode_v2 parentNode, ATNExtendedToken token)
            : base(context, token)
        {
            ParentNode = parentNode;
        }

        public ATNThereModalVerbBeObjTransOrFinNode_v2(ContextOfATNParsing_v2 context, ATNThereModalVerbBeObjTransOrFinNode_v2 sameNode, InitATNThereModalVerbBeObjTransOrFinNodeAction initAction, ATNExtendedToken token)
            : base(context, token)
        {
            mSameNode = sameNode;
            mInitAction = initAction;
            ParentNode = mSameNode.ParentNode;
            mInitAction?.Invoke(this);
        }

        public override StateOfATNParsing_v2 GlobalState => StateOfATNParsing_v2.There_ModalVerb_Be_Obj_TransOrFin;

        public ATNThereModalVerbBeTransNode_v2 ParentNode { get; private set; }
        private ATNThereModalVerbBeObjTransOrFinNode_v2 mSameNode;
        private InitATNThereModalVerbBeObjTransOrFinNodeAction mInitAction;

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

