using MyNPCLib.NLToCGParsing;
using System;
using System.Collections.Generic;
using System.Text;

namespace MyNPCLib.NLToCGParsing_v2.ATNNodes
{
    public delegate void InitATNThereFToBeNoObjTransOrFinNodeAction(ATNThereFToBeNoObjTransOrFinNode_v2 item);

    public class ATNThereFToBeNoObjTransOrFinNodeFactory_v2: BaseATNNodeFactory_v2
    {
        public ATNThereFToBeNoObjTransOrFinNodeFactory_v2(ATNThereFToBeNoTransNode_v2 parentNode, ATNExtendedToken token)
        {
            mNumberOfConstructor = 1;
            mParentNode = parentNode;
            mToken = token;
        }

        public ATNThereFToBeNoObjTransOrFinNodeFactory_v2(ATNThereFToBeNoObjTransOrFinNode_v2 sameNode, ATNExtendedToken token, InitATNThereFToBeNoObjTransOrFinNodeAction initAction)
        {
            mNumberOfConstructor = 2;
            mSameNode = sameNode;
            mToken = token;
            mInitAction = initAction;
        }

        private int mNumberOfConstructor;
        private ATNThereFToBeNoTransNode_v2 mParentNode;
        private ATNThereFToBeNoObjTransOrFinNode_v2 mSameNode;
        private ATNExtendedToken mToken;
        private InitATNThereFToBeNoObjTransOrFinNodeAction mInitAction;

        public override BaseATNNode_v2 Create(ContextOfATNParsing_v2 context)
        {
            switch(mNumberOfConstructor)
            {
                case 1:
                    return new ATNThereFToBeNoObjTransOrFinNode_v2(context, mParentNode, mToken);

                case 2:
                    return new ATNThereFToBeNoObjTransOrFinNode_v2(context, mSameNode, mInitAction, mToken);

                default:
                    throw new ArgumentOutOfRangeException(nameof(mNumberOfConstructor), mNumberOfConstructor, null);
            }
        }
    }

/*Sub states:
    There_FToBe_No_Obj_Condition_Fin
*/

    public class ATNThereFToBeNoObjTransOrFinNode_v2: BaseATNNode_v2
    {
        public ATNThereFToBeNoObjTransOrFinNode_v2(ContextOfATNParsing_v2 context, ATNThereFToBeNoTransNode_v2 parentNode, ATNExtendedToken token)
            : base(context, token)
        {
            ParentNode = parentNode;
        }

        public ATNThereFToBeNoObjTransOrFinNode_v2(ContextOfATNParsing_v2 context, ATNThereFToBeNoObjTransOrFinNode_v2 sameNode, InitATNThereFToBeNoObjTransOrFinNodeAction initAction, ATNExtendedToken token)
            : base(context, token)
        {
            mSameNode = sameNode;
            mInitAction = initAction;
            ParentNode = mSameNode.ParentNode;
            mInitAction?.Invoke(this);
        }

        public override StateOfATNParsing_v2 GlobalState => StateOfATNParsing_v2.There_FToBe_No_Obj_TransOrFin;

        public ATNThereFToBeNoTransNode_v2 ParentNode { get; private set; }
        private ATNThereFToBeNoObjTransOrFinNode_v2 mSameNode;
        private InitATNThereFToBeNoObjTransOrFinNodeAction mInitAction;

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

