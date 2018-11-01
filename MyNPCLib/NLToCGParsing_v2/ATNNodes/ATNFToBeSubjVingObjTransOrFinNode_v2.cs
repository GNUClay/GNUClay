using MyNPCLib.NLToCGParsing;
using System;
using System.Collections.Generic;
using System.Text;

namespace MyNPCLib.NLToCGParsing_v2.ATNNodes
{
    public delegate void InitATNFToBeSubjVingObjTransOrFinNodeAction(ATNFToBeSubjVingObjTransOrFinNode_v2 item);

    public class ATNFToBeSubjVingObjTransOrFinNodeFactory_v2: BaseATNNodeFactory_v2
    {
        public ATNFToBeSubjVingObjTransOrFinNodeFactory_v2(ATNFToBeSubjVingTransOrFinNode_v2 parentNode, ATNExtendedToken token)
        {
            mNumberOfConstructor = 1;
            mParentNode = parentNode;
            mToken = token;
        }

        public ATNFToBeSubjVingObjTransOrFinNodeFactory_v2(ATNFToBeSubjVingObjTransOrFinNode_v2 sameNode, ATNExtendedToken token, InitATNFToBeSubjVingObjTransOrFinNodeAction initAction)
        {
            mNumberOfConstructor = 2;
            mSameNode = sameNode;
            mToken = token;
            mInitAction = initAction;
        }

        private int mNumberOfConstructor;
        private ATNFToBeSubjVingTransOrFinNode_v2 mParentNode;
        private ATNFToBeSubjVingObjTransOrFinNode_v2 mSameNode;
        private ATNExtendedToken mToken;
        private InitATNFToBeSubjVingObjTransOrFinNodeAction mInitAction;

        public override BaseATNNode_v2 Create(ContextOfATNParsing_v2 context)
        {
            switch(mNumberOfConstructor)
            {
                case 1:
                    return new ATNFToBeSubjVingObjTransOrFinNode_v2(context, mParentNode, mToken);

                case 2:
                    return new ATNFToBeSubjVingObjTransOrFinNode_v2(context, mSameNode, mInitAction, mToken);

                default:
                    throw new ArgumentOutOfRangeException(nameof(mNumberOfConstructor), mNumberOfConstructor, null);
            }
        }
    }

/*Sub states:
    FToBe_Subj_Ving_Obj_Condition_Fin
*/

    public class ATNFToBeSubjVingObjTransOrFinNode_v2: BaseATNNode_v2
    {
        public ATNFToBeSubjVingObjTransOrFinNode_v2(ContextOfATNParsing_v2 context, ATNFToBeSubjVingTransOrFinNode_v2 parentNode, ATNExtendedToken token)
            : base(context, token)
        {
            ParentNode = parentNode;
        }

        public ATNFToBeSubjVingObjTransOrFinNode_v2(ContextOfATNParsing_v2 context, ATNFToBeSubjVingObjTransOrFinNode_v2 sameNode, InitATNFToBeSubjVingObjTransOrFinNodeAction initAction, ATNExtendedToken token)
            : base(context, token)
        {
            mSameNode = sameNode;
            mInitAction = initAction;
            ParentNode = mSameNode.ParentNode;
            mInitAction?.Invoke(this);
        }

        public override StateOfATNParsing_v2 GlobalState => StateOfATNParsing_v2.FToBe_Subj_Ving_Obj_TransOrFin;

        public ATNFToBeSubjVingTransOrFinNode_v2 ParentNode { get; private set; }
        private ATNFToBeSubjVingObjTransOrFinNode_v2 mSameNode;
        private InitATNFToBeSubjVingObjTransOrFinNodeAction mInitAction;

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

