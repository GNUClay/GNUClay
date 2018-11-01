using MyNPCLib.NLToCGParsing;
using System;
using System.Collections.Generic;
using System.Text;

namespace MyNPCLib.NLToCGParsing_v2.ATNNodes
{
    public delegate void InitATNConditionThereFToBeNoObjTransOrFinNodeAction(ATNConditionThereFToBeNoObjTransOrFinNode_v2 item);

    public class ATNConditionThereFToBeNoObjTransOrFinNodeFactory_v2: BaseATNNodeFactory_v2
    {
        public ATNConditionThereFToBeNoObjTransOrFinNodeFactory_v2(ATNConditionThereFToBeNoTransNode_v2 parentNode, ATNExtendedToken token)
        {
            mNumberOfConstructor = 1;
            mParentNode = parentNode;
            mToken = token;
        }

        public ATNConditionThereFToBeNoObjTransOrFinNodeFactory_v2(ATNConditionThereFToBeNoObjTransOrFinNode_v2 sameNode, ATNExtendedToken token, InitATNConditionThereFToBeNoObjTransOrFinNodeAction initAction)
        {
            mNumberOfConstructor = 2;
            mSameNode = sameNode;
            mToken = token;
            mInitAction = initAction;
        }

        private int mNumberOfConstructor;
        private ATNConditionThereFToBeNoTransNode_v2 mParentNode;
        private ATNConditionThereFToBeNoObjTransOrFinNode_v2 mSameNode;
        private ATNExtendedToken mToken;
        private InitATNConditionThereFToBeNoObjTransOrFinNodeAction mInitAction;

        public override BaseATNNode_v2 Create(ContextOfATNParsing_v2 context)
        {
            switch(mNumberOfConstructor)
            {
                case 1:
                    return new ATNConditionThereFToBeNoObjTransOrFinNode_v2(context, mParentNode, mToken);

                case 2:
                    return new ATNConditionThereFToBeNoObjTransOrFinNode_v2(context, mSameNode, mInitAction, mToken);

                default:
                    throw new ArgumentOutOfRangeException(nameof(mNumberOfConstructor), mNumberOfConstructor, null);
            }
        }
    }

/*Sub states:
    Condition_There_FToBe_No_Obj_Condition_Fin
*/

    public class ATNConditionThereFToBeNoObjTransOrFinNode_v2: BaseATNNode_v2
    {
        public ATNConditionThereFToBeNoObjTransOrFinNode_v2(ContextOfATNParsing_v2 context, ATNConditionThereFToBeNoTransNode_v2 parentNode, ATNExtendedToken token)
            : base(context, token)
        {
            ParentNode = parentNode;
        }

        public ATNConditionThereFToBeNoObjTransOrFinNode_v2(ContextOfATNParsing_v2 context, ATNConditionThereFToBeNoObjTransOrFinNode_v2 sameNode, InitATNConditionThereFToBeNoObjTransOrFinNodeAction initAction, ATNExtendedToken token)
            : base(context, token)
        {
            mSameNode = sameNode;
            mInitAction = initAction;
            ParentNode = mSameNode.ParentNode;
            mInitAction?.Invoke(this);
        }

        public override StateOfATNParsing_v2 GlobalState => StateOfATNParsing_v2.Condition_There_FToBe_No_Obj_TransOrFin;

        public ATNConditionThereFToBeNoTransNode_v2 ParentNode { get; private set; }
        private ATNConditionThereFToBeNoObjTransOrFinNode_v2 mSameNode;
        private InitATNConditionThereFToBeNoObjTransOrFinNodeAction mInitAction;

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

