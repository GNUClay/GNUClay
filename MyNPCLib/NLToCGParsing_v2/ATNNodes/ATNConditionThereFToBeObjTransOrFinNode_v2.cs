using MyNPCLib.NLToCGParsing;
using System;
using System.Collections.Generic;
using System.Text;

namespace MyNPCLib.NLToCGParsing_v2.ATNNodes
{
    public delegate void InitATNConditionThereFToBeObjTransOrFinNodeAction(ATNConditionThereFToBeObjTransOrFinNode_v2 item);

    public class ATNConditionThereFToBeObjTransOrFinNodeFactory_v2: BaseATNNodeFactory_v2
    {
        public ATNConditionThereFToBeObjTransOrFinNodeFactory_v2(ATNConditionThereFToBeTransNode_v2 parentNode, ATNExtendedToken token)
        {
            mNumberOfConstructor = 1;
            mParentNode = parentNode;
            mToken = token;
        }

        public ATNConditionThereFToBeObjTransOrFinNodeFactory_v2(ATNConditionThereFToBeObjTransOrFinNode_v2 sameNode, ATNExtendedToken token, InitATNConditionThereFToBeObjTransOrFinNodeAction initAction)
        {
            mNumberOfConstructor = 2;
            mSameNode = sameNode;
            mToken = token;
            mInitAction = initAction;
        }

        private int mNumberOfConstructor;
        private ATNConditionThereFToBeTransNode_v2 mParentNode;
        private ATNConditionThereFToBeObjTransOrFinNode_v2 mSameNode;
        private ATNExtendedToken mToken;
        private InitATNConditionThereFToBeObjTransOrFinNodeAction mInitAction;

        public override BaseATNNode_v2 Create(ContextOfATNParsing_v2 context)
        {
            switch(mNumberOfConstructor)
            {
                case 1:
                    return new ATNConditionThereFToBeObjTransOrFinNode_v2(context, mParentNode, mToken);

                case 2:
                    return new ATNConditionThereFToBeObjTransOrFinNode_v2(context, mSameNode, mInitAction, mToken);

                default:
                    throw new ArgumentOutOfRangeException(nameof(mNumberOfConstructor), mNumberOfConstructor, null);
            }
        }
    }

/*Sub states:
    Condition_There_FToBe_Obj_Condition_Fin
*/

    public class ATNConditionThereFToBeObjTransOrFinNode_v2: BaseATNNode_v2
    {
        public ATNConditionThereFToBeObjTransOrFinNode_v2(ContextOfATNParsing_v2 context, ATNConditionThereFToBeTransNode_v2 parentNode, ATNExtendedToken token)
            : base(context, token)
        {
            ParentNode = parentNode;
        }

        public ATNConditionThereFToBeObjTransOrFinNode_v2(ContextOfATNParsing_v2 context, ATNConditionThereFToBeObjTransOrFinNode_v2 sameNode, InitATNConditionThereFToBeObjTransOrFinNodeAction initAction, ATNExtendedToken token)
            : base(context, token)
        {
            mSameNode = sameNode;
            mInitAction = initAction;
            ParentNode = mSameNode.ParentNode;
            mInitAction?.Invoke(this);
        }

        public override StateOfATNParsing_v2 GlobalState => StateOfATNParsing_v2.Condition_There_FToBe_Obj_TransOrFin;

        public ATNConditionThereFToBeTransNode_v2 ParentNode { get; private set; }
        private ATNConditionThereFToBeObjTransOrFinNode_v2 mSameNode;
        private InitATNConditionThereFToBeObjTransOrFinNodeAction mInitAction;

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

