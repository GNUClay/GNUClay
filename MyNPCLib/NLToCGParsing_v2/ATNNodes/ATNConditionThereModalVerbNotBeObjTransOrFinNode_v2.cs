using MyNPCLib.NLToCGParsing;
using System;
using System.Collections.Generic;
using System.Text;

namespace MyNPCLib.NLToCGParsing_v2.ATNNodes
{
    public delegate void InitATNConditionThereModalVerbNotBeObjTransOrFinNodeAction(ATNConditionThereModalVerbNotBeObjTransOrFinNode_v2 item);

    public class ATNConditionThereModalVerbNotBeObjTransOrFinNodeFactory_v2: BaseATNNodeFactory_v2
    {
        public ATNConditionThereModalVerbNotBeObjTransOrFinNodeFactory_v2(ATNConditionThereModalVerbNotBeTransNode_v2 parentNode, ATNExtendedToken token)
        {
            mNumberOfConstructor = 1;
            mParentNode = parentNode;
            mToken = token;
        }

        public ATNConditionThereModalVerbNotBeObjTransOrFinNodeFactory_v2(ATNConditionThereModalVerbNotBeObjTransOrFinNode_v2 sameNode, ATNExtendedToken token, InitATNConditionThereModalVerbNotBeObjTransOrFinNodeAction initAction)
        {
            mNumberOfConstructor = 2;
            mSameNode = sameNode;
            mToken = token;
            mInitAction = initAction;
        }

        private int mNumberOfConstructor;
        private ATNConditionThereModalVerbNotBeTransNode_v2 mParentNode;
        private ATNConditionThereModalVerbNotBeObjTransOrFinNode_v2 mSameNode;
        private ATNExtendedToken mToken;
        private InitATNConditionThereModalVerbNotBeObjTransOrFinNodeAction mInitAction;

        public override BaseATNNode_v2 Create(ContextOfATNParsing_v2 context)
        {
            switch(mNumberOfConstructor)
            {
                case 1:
                    return new ATNConditionThereModalVerbNotBeObjTransOrFinNode_v2(context, mParentNode, mToken);

                case 2:
                    return new ATNConditionThereModalVerbNotBeObjTransOrFinNode_v2(context, mSameNode, mInitAction, mToken);

                default:
                    throw new ArgumentOutOfRangeException(nameof(mNumberOfConstructor), mNumberOfConstructor, null);
            }
        }
    }

/*Sub states:
    Condition_There_ModalVerb_Not_Be_Obj_Condition_Fin
*/

    public class ATNConditionThereModalVerbNotBeObjTransOrFinNode_v2: BaseATNNode_v2
    {
        public ATNConditionThereModalVerbNotBeObjTransOrFinNode_v2(ContextOfATNParsing_v2 context, ATNConditionThereModalVerbNotBeTransNode_v2 parentNode, ATNExtendedToken token)
            : base(context, token)
        {
            ParentNode = parentNode;
        }

        public ATNConditionThereModalVerbNotBeObjTransOrFinNode_v2(ContextOfATNParsing_v2 context, ATNConditionThereModalVerbNotBeObjTransOrFinNode_v2 sameNode, InitATNConditionThereModalVerbNotBeObjTransOrFinNodeAction initAction, ATNExtendedToken token)
            : base(context, token)
        {
            mSameNode = sameNode;
            mInitAction = initAction;
            ParentNode = mSameNode.ParentNode;
            mInitAction?.Invoke(this);
        }

        public override StateOfATNParsing_v2 GlobalState => StateOfATNParsing_v2.Condition_There_ModalVerb_Not_Be_Obj_TransOrFin;

        public ATNConditionThereModalVerbNotBeTransNode_v2 ParentNode { get; private set; }
        private ATNConditionThereModalVerbNotBeObjTransOrFinNode_v2 mSameNode;
        private InitATNConditionThereModalVerbNotBeObjTransOrFinNodeAction mInitAction;

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

