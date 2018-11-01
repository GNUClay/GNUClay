using MyNPCLib.NLToCGParsing;
using System;
using System.Collections.Generic;
using System.Text;

namespace MyNPCLib.NLToCGParsing_v2.ATNNodes
{
    public delegate void InitATNFToBeSubjBeingConditionV3ObjTransOrFinNodeAction(ATNFToBeSubjBeingConditionV3ObjTransOrFinNode_v2 item);

    public class ATNFToBeSubjBeingConditionV3ObjTransOrFinNodeFactory_v2: BaseATNNodeFactory_v2
    {
        public ATNFToBeSubjBeingConditionV3ObjTransOrFinNodeFactory_v2(ATNFToBeSubjBeingConditionV3TransOrFinNode_v2 parentNode, ATNExtendedToken token)
        {
            mNumberOfConstructor = 1;
            mParentNode = parentNode;
            mToken = token;
        }

        public ATNFToBeSubjBeingConditionV3ObjTransOrFinNodeFactory_v2(ATNFToBeSubjBeingConditionV3ObjTransOrFinNode_v2 sameNode, ATNExtendedToken token, InitATNFToBeSubjBeingConditionV3ObjTransOrFinNodeAction initAction)
        {
            mNumberOfConstructor = 2;
            mSameNode = sameNode;
            mToken = token;
            mInitAction = initAction;
        }

        private int mNumberOfConstructor;
        private ATNFToBeSubjBeingConditionV3TransOrFinNode_v2 mParentNode;
        private ATNFToBeSubjBeingConditionV3ObjTransOrFinNode_v2 mSameNode;
        private ATNExtendedToken mToken;
        private InitATNFToBeSubjBeingConditionV3ObjTransOrFinNodeAction mInitAction;

        public override BaseATNNode_v2 Create(ContextOfATNParsing_v2 context)
        {
            switch(mNumberOfConstructor)
            {
                case 1:
                    return new ATNFToBeSubjBeingConditionV3ObjTransOrFinNode_v2(context, mParentNode, mToken);

                case 2:
                    return new ATNFToBeSubjBeingConditionV3ObjTransOrFinNode_v2(context, mSameNode, mInitAction, mToken);

                default:
                    throw new ArgumentOutOfRangeException(nameof(mNumberOfConstructor), mNumberOfConstructor, null);
            }
        }
    }

/*Sub states:
    FToBe_Subj_Being_Condition_V3_Obj_Condition_Fin
*/

    public class ATNFToBeSubjBeingConditionV3ObjTransOrFinNode_v2: BaseATNNode_v2
    {
        public ATNFToBeSubjBeingConditionV3ObjTransOrFinNode_v2(ContextOfATNParsing_v2 context, ATNFToBeSubjBeingConditionV3TransOrFinNode_v2 parentNode, ATNExtendedToken token)
            : base(context, token)
        {
            ParentNode = parentNode;
        }

        public ATNFToBeSubjBeingConditionV3ObjTransOrFinNode_v2(ContextOfATNParsing_v2 context, ATNFToBeSubjBeingConditionV3ObjTransOrFinNode_v2 sameNode, InitATNFToBeSubjBeingConditionV3ObjTransOrFinNodeAction initAction, ATNExtendedToken token)
            : base(context, token)
        {
            mSameNode = sameNode;
            mInitAction = initAction;
            ParentNode = mSameNode.ParentNode;
            mInitAction?.Invoke(this);
        }

        public override StateOfATNParsing_v2 GlobalState => StateOfATNParsing_v2.FToBe_Subj_Being_Condition_V3_Obj_TransOrFin;

        public ATNFToBeSubjBeingConditionV3TransOrFinNode_v2 ParentNode { get; private set; }
        private ATNFToBeSubjBeingConditionV3ObjTransOrFinNode_v2 mSameNode;
        private InitATNFToBeSubjBeingConditionV3ObjTransOrFinNodeAction mInitAction;

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

