using MyNPCLib.NLToCGParsing;
using System;
using System.Collections.Generic;
using System.Text;

namespace MyNPCLib.NLToCGParsing_v2.ATNNodes
{
    public delegate void InitATNConditionThereFToBeTransNodeAction(ATNConditionThereFToBeTransNode_v2 item);

    public class ATNConditionThereFToBeTransNodeFactory_v2: BaseATNNodeFactory_v2
    {
        public ATNConditionThereFToBeTransNodeFactory_v2(ATNConditionThereTransNode_v2 parentNode, ATNExtendedToken token)
        {
            mNumberOfConstructor = 1;
            mParentNode = parentNode;
            mToken = token;
        }

        public ATNConditionThereFToBeTransNodeFactory_v2(ATNConditionThereFToBeTransNode_v2 sameNode, ATNExtendedToken token, InitATNConditionThereFToBeTransNodeAction initAction)
        {
            mNumberOfConstructor = 2;
            mSameNode = sameNode;
            mToken = token;
            mInitAction = initAction;
        }

        private int mNumberOfConstructor;
        private ATNConditionThereTransNode_v2 mParentNode;
        private ATNConditionThereFToBeTransNode_v2 mSameNode;
        private ATNExtendedToken mToken;
        private InitATNConditionThereFToBeTransNodeAction mInitAction;

        public override BaseATNNode_v2 Create(ContextOfATNParsing_v2 context)
        {
            switch(mNumberOfConstructor)
            {
                case 1:
                    return new ATNConditionThereFToBeTransNode_v2(context, mParentNode, mToken);

                case 2:
                    return new ATNConditionThereFToBeTransNode_v2(context, mSameNode, mInitAction, mToken);

                default:
                    throw new ArgumentOutOfRangeException(nameof(mNumberOfConstructor), mNumberOfConstructor, null);
            }
        }
    }

/*Sub states:
    Condition_There_FToBe_Obj_TransOrFin
    Condition_There_FToBe_No_Trans
*/

    public class ATNConditionThereFToBeTransNode_v2: BaseATNNode_v2
    {
        public ATNConditionThereFToBeTransNode_v2(ContextOfATNParsing_v2 context, ATNConditionThereTransNode_v2 parentNode, ATNExtendedToken token)
            : base(context, token)
        {
            ParentNode = parentNode;
        }

        public ATNConditionThereFToBeTransNode_v2(ContextOfATNParsing_v2 context, ATNConditionThereFToBeTransNode_v2 sameNode, InitATNConditionThereFToBeTransNodeAction initAction, ATNExtendedToken token)
            : base(context, token)
        {
            mSameNode = sameNode;
            mInitAction = initAction;
            ParentNode = mSameNode.ParentNode;
            mInitAction?.Invoke(this);
        }

        public override StateOfATNParsing_v2 GlobalState => StateOfATNParsing_v2.Condition_There_FToBe_Trans;

        public ATNConditionThereTransNode_v2 ParentNode { get; private set; }
        private ATNConditionThereFToBeTransNode_v2 mSameNode;
        private InitATNConditionThereFToBeTransNodeAction mInitAction;

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

