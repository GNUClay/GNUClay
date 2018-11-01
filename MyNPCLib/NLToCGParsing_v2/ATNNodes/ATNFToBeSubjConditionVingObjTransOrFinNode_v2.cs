using MyNPCLib.NLToCGParsing;
using System;
using System.Collections.Generic;
using System.Text;

namespace MyNPCLib.NLToCGParsing_v2.ATNNodes
{
    public delegate void InitATNFToBeSubjConditionVingObjTransOrFinNodeAction(ATNFToBeSubjConditionVingObjTransOrFinNode_v2 item);

    public class ATNFToBeSubjConditionVingObjTransOrFinNodeFactory_v2: BaseATNNodeFactory_v2
    {
        public ATNFToBeSubjConditionVingObjTransOrFinNodeFactory_v2(ATNFToBeSubjConditionVingTransOrFinNode_v2 parentNode, ATNExtendedToken token)
        {
            mNumberOfConstructor = 1;
            mParentNode = parentNode;
            mToken = token;
        }

        public ATNFToBeSubjConditionVingObjTransOrFinNodeFactory_v2(ATNFToBeSubjConditionVingObjTransOrFinNode_v2 sameNode, ATNExtendedToken token, InitATNFToBeSubjConditionVingObjTransOrFinNodeAction initAction)
        {
            mNumberOfConstructor = 2;
            mSameNode = sameNode;
            mToken = token;
            mInitAction = initAction;
        }

        private int mNumberOfConstructor;
        private ATNFToBeSubjConditionVingTransOrFinNode_v2 mParentNode;
        private ATNFToBeSubjConditionVingObjTransOrFinNode_v2 mSameNode;
        private ATNExtendedToken mToken;
        private InitATNFToBeSubjConditionVingObjTransOrFinNodeAction mInitAction;

        public override BaseATNNode_v2 Create(ContextOfATNParsing_v2 context)
        {
            switch(mNumberOfConstructor)
            {
                case 1:
                    return new ATNFToBeSubjConditionVingObjTransOrFinNode_v2(context, mParentNode, mToken);

                case 2:
                    return new ATNFToBeSubjConditionVingObjTransOrFinNode_v2(context, mSameNode, mInitAction, mToken);

                default:
                    throw new ArgumentOutOfRangeException(nameof(mNumberOfConstructor), mNumberOfConstructor, null);
            }
        }
    }

/*Sub states:
    FToBe_Subj_Condition_Ving_Obj_Condition_Fin
*/

    public class ATNFToBeSubjConditionVingObjTransOrFinNode_v2: BaseATNNode_v2
    {
        public ATNFToBeSubjConditionVingObjTransOrFinNode_v2(ContextOfATNParsing_v2 context, ATNFToBeSubjConditionVingTransOrFinNode_v2 parentNode, ATNExtendedToken token)
            : base(context, token)
        {
            ParentNode = parentNode;
        }

        public ATNFToBeSubjConditionVingObjTransOrFinNode_v2(ContextOfATNParsing_v2 context, ATNFToBeSubjConditionVingObjTransOrFinNode_v2 sameNode, InitATNFToBeSubjConditionVingObjTransOrFinNodeAction initAction, ATNExtendedToken token)
            : base(context, token)
        {
            mSameNode = sameNode;
            mInitAction = initAction;
            ParentNode = mSameNode.ParentNode;
            mInitAction?.Invoke(this);
        }

        public override StateOfATNParsing_v2 GlobalState => StateOfATNParsing_v2.FToBe_Subj_Condition_Ving_Obj_TransOrFin;

        public ATNFToBeSubjConditionVingTransOrFinNode_v2 ParentNode { get; private set; }
        private ATNFToBeSubjConditionVingObjTransOrFinNode_v2 mSameNode;
        private InitATNFToBeSubjConditionVingObjTransOrFinNodeAction mInitAction;

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

