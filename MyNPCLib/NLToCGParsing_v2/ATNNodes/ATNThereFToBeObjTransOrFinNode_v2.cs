using MyNPCLib.NLToCGParsing;
using System;
using System.Collections.Generic;
using System.Text;

namespace MyNPCLib.NLToCGParsing_v2.ATNNodes
{
    public delegate void InitATNThereFToBeObjTransOrFinNodeAction(ATNThereFToBeObjTransOrFinNode_v2 item);

    public class ATNThereFToBeObjTransOrFinNodeFactory_v2: BaseATNNodeFactory_v2
    {
        public ATNThereFToBeObjTransOrFinNodeFactory_v2(ATNThereFToBeTransNode_v2 parentNode, ATNExtendedToken token)
        {
            mNumberOfConstructor = 1;
            mParentNode = parentNode;
            mToken = token;
        }

        public ATNThereFToBeObjTransOrFinNodeFactory_v2(ATNThereFToBeObjTransOrFinNode_v2 sameNode, ATNExtendedToken token, InitATNThereFToBeObjTransOrFinNodeAction initAction)
        {
            mNumberOfConstructor = 2;
            mSameNode = sameNode;
            mToken = token;
            mInitAction = initAction;
        }

        private int mNumberOfConstructor;
        private ATNThereFToBeTransNode_v2 mParentNode;
        private ATNThereFToBeObjTransOrFinNode_v2 mSameNode;
        private ATNExtendedToken mToken;
        private InitATNThereFToBeObjTransOrFinNodeAction mInitAction;

        public override BaseATNNode_v2 Create(ContextOfATNParsing_v2 context)
        {
            switch(mNumberOfConstructor)
            {
                case 1:
                    return new ATNThereFToBeObjTransOrFinNode_v2(context, mParentNode, mToken);

                case 2:
                    return new ATNThereFToBeObjTransOrFinNode_v2(context, mSameNode, mInitAction, mToken);

                default:
                    throw new ArgumentOutOfRangeException(nameof(mNumberOfConstructor), mNumberOfConstructor, null);
            }
        }
    }

/*Sub states:
    There_FToBe_Obj_Condition_Fin
*/

    public class ATNThereFToBeObjTransOrFinNode_v2: BaseATNNode_v2
    {
        public ATNThereFToBeObjTransOrFinNode_v2(ContextOfATNParsing_v2 context, ATNThereFToBeTransNode_v2 parentNode, ATNExtendedToken token)
            : base(context, token)
        {
            ParentNode = parentNode;
        }

        public ATNThereFToBeObjTransOrFinNode_v2(ContextOfATNParsing_v2 context, ATNThereFToBeObjTransOrFinNode_v2 sameNode, InitATNThereFToBeObjTransOrFinNodeAction initAction, ATNExtendedToken token)
            : base(context, token)
        {
            mSameNode = sameNode;
            mInitAction = initAction;
            ParentNode = mSameNode.ParentNode;
            mInitAction?.Invoke(this);
        }

        public override StateOfATNParsing_v2 GlobalState => StateOfATNParsing_v2.There_FToBe_Obj_TransOrFin;

        public ATNThereFToBeTransNode_v2 ParentNode { get; private set; }
        private ATNThereFToBeObjTransOrFinNode_v2 mSameNode;
        private InitATNThereFToBeObjTransOrFinNodeAction mInitAction;

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

