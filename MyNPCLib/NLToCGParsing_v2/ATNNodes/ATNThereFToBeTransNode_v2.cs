using MyNPCLib.NLToCGParsing;
using System;
using System.Collections.Generic;
using System.Text;

namespace MyNPCLib.NLToCGParsing_v2.ATNNodes
{
    public delegate void InitATNThereFToBeTransNodeAction(ATNThereFToBeTransNode_v2 item);

    public class ATNThereFToBeTransNodeFactory_v2: BaseATNNodeFactory_v2
    {
        public ATNThereFToBeTransNodeFactory_v2(ATNThereTransNode_v2 parentNode, ATNExtendedToken token)
        {
            mNumberOfConstructor = 1;
            mParentNode = parentNode;
            mToken = token;
        }

        public ATNThereFToBeTransNodeFactory_v2(ATNThereFToBeTransNode_v2 sameNode, ATNExtendedToken token, InitATNThereFToBeTransNodeAction initAction)
        {
            mNumberOfConstructor = 2;
            mSameNode = sameNode;
            mToken = token;
            mInitAction = initAction;
        }

        private int mNumberOfConstructor;
        private ATNThereTransNode_v2 mParentNode;
        private ATNThereFToBeTransNode_v2 mSameNode;
        private ATNExtendedToken mToken;
        private InitATNThereFToBeTransNodeAction mInitAction;

        public override BaseATNNode_v2 Create(ContextOfATNParsing_v2 context)
        {
            switch(mNumberOfConstructor)
            {
                case 1:
                    return new ATNThereFToBeTransNode_v2(context, mParentNode, mToken);

                case 2:
                    return new ATNThereFToBeTransNode_v2(context, mSameNode, mInitAction, mToken);

                default:
                    throw new ArgumentOutOfRangeException(nameof(mNumberOfConstructor), mNumberOfConstructor, null);
            }
        }
    }

/*Sub states:
    There_FToBe_Obj_TransOrFin
    There_FToBe_No_Trans
*/

    public class ATNThereFToBeTransNode_v2: BaseATNNode_v2
    {
        public ATNThereFToBeTransNode_v2(ContextOfATNParsing_v2 context, ATNThereTransNode_v2 parentNode, ATNExtendedToken token)
            : base(context, token)
        {
            ParentNode = parentNode;
        }

        public ATNThereFToBeTransNode_v2(ContextOfATNParsing_v2 context, ATNThereFToBeTransNode_v2 sameNode, InitATNThereFToBeTransNodeAction initAction, ATNExtendedToken token)
            : base(context, token)
        {
            mSameNode = sameNode;
            mInitAction = initAction;
            ParentNode = mSameNode.ParentNode;
            mInitAction?.Invoke(this);
        }

        public override StateOfATNParsing_v2 GlobalState => StateOfATNParsing_v2.There_FToBe_Trans;

        public ATNThereTransNode_v2 ParentNode { get; private set; }
        private ATNThereFToBeTransNode_v2 mSameNode;
        private InitATNThereFToBeTransNodeAction mInitAction;

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

