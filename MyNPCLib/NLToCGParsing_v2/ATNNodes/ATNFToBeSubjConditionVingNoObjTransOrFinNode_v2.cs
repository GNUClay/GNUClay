using MyNPCLib.NLToCGParsing;
using System;
using System.Collections.Generic;
using System.Text;

namespace MyNPCLib.NLToCGParsing_v2.ATNNodes
{
    public delegate void InitATNFToBeSubjConditionVingNoObjTransOrFinNodeAction(ATNFToBeSubjConditionVingNoObjTransOrFinNode_v2 item);

    public class ATNFToBeSubjConditionVingNoObjTransOrFinNodeFactory_v2: BaseATNNodeFactory_v2
    {
        public ATNFToBeSubjConditionVingNoObjTransOrFinNodeFactory_v2(ATNFToBeSubjConditionVingNoTransNode_v2 parentNode, ATNExtendedToken token)
        {
            mNumberOfConstructor = 1;
            mParentNode = parentNode;
            mToken = token;
        }

        public ATNFToBeSubjConditionVingNoObjTransOrFinNodeFactory_v2(ATNFToBeSubjConditionVingNoObjTransOrFinNode_v2 sameNode, ATNExtendedToken token, InitATNFToBeSubjConditionVingNoObjTransOrFinNodeAction initAction)
        {
            mNumberOfConstructor = 2;
            mSameNode = sameNode;
            mToken = token;
            mInitAction = initAction;
        }

        private int mNumberOfConstructor;
        private ATNFToBeSubjConditionVingNoTransNode_v2 mParentNode;
        private ATNFToBeSubjConditionVingNoObjTransOrFinNode_v2 mSameNode;
        private ATNExtendedToken mToken;
        private InitATNFToBeSubjConditionVingNoObjTransOrFinNodeAction mInitAction;

        public override BaseATNNode_v2 Create(ContextOfATNParsing_v2 context)
        {
            switch(mNumberOfConstructor)
            {
                case 1:
                    return new ATNFToBeSubjConditionVingNoObjTransOrFinNode_v2(context, mParentNode, mToken);

                case 2:
                    return new ATNFToBeSubjConditionVingNoObjTransOrFinNode_v2(context, mSameNode, mInitAction, mToken);

                default:
                    throw new ArgumentOutOfRangeException(nameof(mNumberOfConstructor), mNumberOfConstructor, null);
            }
        }
    }

/*Sub states:
    FToBe_Subj_Condition_Ving_No_Obj_Condition_Fin
*/

    public class ATNFToBeSubjConditionVingNoObjTransOrFinNode_v2: BaseATNNode_v2
    {
        public ATNFToBeSubjConditionVingNoObjTransOrFinNode_v2(ContextOfATNParsing_v2 context, ATNFToBeSubjConditionVingNoTransNode_v2 parentNode, ATNExtendedToken token)
            : base(context, token)
        {
            ParentNode = parentNode;
        }

        public ATNFToBeSubjConditionVingNoObjTransOrFinNode_v2(ContextOfATNParsing_v2 context, ATNFToBeSubjConditionVingNoObjTransOrFinNode_v2 sameNode, InitATNFToBeSubjConditionVingNoObjTransOrFinNodeAction initAction, ATNExtendedToken token)
            : base(context, token)
        {
            mSameNode = sameNode;
            mInitAction = initAction;
            ParentNode = mSameNode.ParentNode;
            mInitAction?.Invoke(this);
        }

        public override StateOfATNParsing_v2 GlobalState => StateOfATNParsing_v2.FToBe_Subj_Condition_Ving_No_Obj_TransOrFin;

        public ATNFToBeSubjConditionVingNoTransNode_v2 ParentNode { get; private set; }
        private ATNFToBeSubjConditionVingNoObjTransOrFinNode_v2 mSameNode;
        private InitATNFToBeSubjConditionVingNoObjTransOrFinNodeAction mInitAction;

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

