using MyNPCLib.NLToCGParsing;
using System;
using System.Collections.Generic;
using System.Text;

namespace MyNPCLib.NLToCGParsing_v2.ATNNodes
{
    public delegate void InitATNThereModalVerbNotBeObjTransOrFinNodeAction(ATNThereModalVerbNotBeObjTransOrFinNode_v2 item);

    public class ATNThereModalVerbNotBeObjTransOrFinNodeFactory_v2: BaseATNNodeFactory_v2
    {
        public ATNThereModalVerbNotBeObjTransOrFinNodeFactory_v2(ATNThereModalVerbNotBeTransNode_v2 parentNode, ATNExtendedToken token)
        {
            mNumberOfConstructor = 1;
            mParentNode = parentNode;
            mToken = token;
        }

        public ATNThereModalVerbNotBeObjTransOrFinNodeFactory_v2(ATNThereModalVerbNotBeObjTransOrFinNode_v2 sameNode, ATNExtendedToken token, InitATNThereModalVerbNotBeObjTransOrFinNodeAction initAction)
        {
            mNumberOfConstructor = 2;
            mSameNode = sameNode;
            mToken = token;
            mInitAction = initAction;
        }

        private int mNumberOfConstructor;
        private ATNThereModalVerbNotBeTransNode_v2 mParentNode;
        private ATNThereModalVerbNotBeObjTransOrFinNode_v2 mSameNode;
        private ATNExtendedToken mToken;
        private InitATNThereModalVerbNotBeObjTransOrFinNodeAction mInitAction;

        public override BaseATNNode_v2 Create(ContextOfATNParsing_v2 context)
        {
            switch(mNumberOfConstructor)
            {
                case 1:
                    return new ATNThereModalVerbNotBeObjTransOrFinNode_v2(context, mParentNode, mToken);

                case 2:
                    return new ATNThereModalVerbNotBeObjTransOrFinNode_v2(context, mSameNode, mInitAction, mToken);

                default:
                    throw new ArgumentOutOfRangeException(nameof(mNumberOfConstructor), mNumberOfConstructor, null);
            }
        }
    }

/*Sub states:
    There_ModalVerb_Not_Be_Obj_Condition_Fin
*/

    public class ATNThereModalVerbNotBeObjTransOrFinNode_v2: BaseATNNode_v2
    {
        public ATNThereModalVerbNotBeObjTransOrFinNode_v2(ContextOfATNParsing_v2 context, ATNThereModalVerbNotBeTransNode_v2 parentNode, ATNExtendedToken token)
            : base(context, token)
        {
            ParentNode = parentNode;
        }

        public ATNThereModalVerbNotBeObjTransOrFinNode_v2(ContextOfATNParsing_v2 context, ATNThereModalVerbNotBeObjTransOrFinNode_v2 sameNode, InitATNThereModalVerbNotBeObjTransOrFinNodeAction initAction, ATNExtendedToken token)
            : base(context, token)
        {
            mSameNode = sameNode;
            mInitAction = initAction;
            ParentNode = mSameNode.ParentNode;
            mInitAction?.Invoke(this);
        }

        public override StateOfATNParsing_v2 GlobalState => StateOfATNParsing_v2.There_ModalVerb_Not_Be_Obj_TransOrFin;

        public ATNThereModalVerbNotBeTransNode_v2 ParentNode { get; private set; }
        private ATNThereModalVerbNotBeObjTransOrFinNode_v2 mSameNode;
        private InitATNThereModalVerbNotBeObjTransOrFinNodeAction mInitAction;

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

