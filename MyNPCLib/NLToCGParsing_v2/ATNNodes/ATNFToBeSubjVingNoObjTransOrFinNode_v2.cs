using MyNPCLib.NLToCGParsing;
using System;
using System.Collections.Generic;
using System.Text;

namespace MyNPCLib.NLToCGParsing_v2.ATNNodes
{
    public delegate void InitATNFToBeSubjVingNoObjTransOrFinNodeAction(ATNFToBeSubjVingNoObjTransOrFinNode_v2 item);

    public class ATNFToBeSubjVingNoObjTransOrFinNodeFactory_v2: BaseATNNodeFactory_v2
    {
        public ATNFToBeSubjVingNoObjTransOrFinNodeFactory_v2(ATNFToBeSubjVingNoTransNode_v2 parentNode, ATNExtendedToken token)
        {
            mNumberOfConstructor = 1;
            mParentNode = parentNode;
            mToken = token;
        }

        public ATNFToBeSubjVingNoObjTransOrFinNodeFactory_v2(ATNFToBeSubjVingNoObjTransOrFinNode_v2 sameNode, ATNExtendedToken token, InitATNFToBeSubjVingNoObjTransOrFinNodeAction initAction)
        {
            mNumberOfConstructor = 2;
            mSameNode = sameNode;
            mToken = token;
            mInitAction = initAction;
        }

        private int mNumberOfConstructor;
        private ATNFToBeSubjVingNoTransNode_v2 mParentNode;
        private ATNFToBeSubjVingNoObjTransOrFinNode_v2 mSameNode;
        private ATNExtendedToken mToken;
        private InitATNFToBeSubjVingNoObjTransOrFinNodeAction mInitAction;

        public override BaseATNNode_v2 Create(ContextOfATNParsing_v2 context)
        {
            switch(mNumberOfConstructor)
            {
                case 1:
                    return new ATNFToBeSubjVingNoObjTransOrFinNode_v2(context, mParentNode, mToken);

                case 2:
                    return new ATNFToBeSubjVingNoObjTransOrFinNode_v2(context, mSameNode, mInitAction, mToken);

                default:
                    throw new ArgumentOutOfRangeException(nameof(mNumberOfConstructor), mNumberOfConstructor, null);
            }
        }
    }

/*Sub states:
    FToBe_Subj_Ving_No_Obj_Condition_Fin
*/

    public class ATNFToBeSubjVingNoObjTransOrFinNode_v2: BaseATNNode_v2
    {
        public ATNFToBeSubjVingNoObjTransOrFinNode_v2(ContextOfATNParsing_v2 context, ATNFToBeSubjVingNoTransNode_v2 parentNode, ATNExtendedToken token)
            : base(context, token)
        {
            ParentNode = parentNode;
        }

        public ATNFToBeSubjVingNoObjTransOrFinNode_v2(ContextOfATNParsing_v2 context, ATNFToBeSubjVingNoObjTransOrFinNode_v2 sameNode, InitATNFToBeSubjVingNoObjTransOrFinNodeAction initAction, ATNExtendedToken token)
            : base(context, token)
        {
            mSameNode = sameNode;
            mInitAction = initAction;
            ParentNode = mSameNode.ParentNode;
            mInitAction?.Invoke(this);
        }

        public override StateOfATNParsing_v2 GlobalState => StateOfATNParsing_v2.FToBe_Subj_Ving_No_Obj_TransOrFin;

        public ATNFToBeSubjVingNoTransNode_v2 ParentNode { get; private set; }
        private ATNFToBeSubjVingNoObjTransOrFinNode_v2 mSameNode;
        private InitATNFToBeSubjVingNoObjTransOrFinNodeAction mInitAction;

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

