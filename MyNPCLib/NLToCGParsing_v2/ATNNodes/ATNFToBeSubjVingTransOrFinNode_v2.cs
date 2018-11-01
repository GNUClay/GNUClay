using MyNPCLib.NLToCGParsing;
using System;
using System.Collections.Generic;
using System.Text;

namespace MyNPCLib.NLToCGParsing_v2.ATNNodes
{
    public delegate void InitATNFToBeSubjVingTransOrFinNodeAction(ATNFToBeSubjVingTransOrFinNode_v2 item);

    public class ATNFToBeSubjVingTransOrFinNodeFactory_v2: BaseATNNodeFactory_v2
    {
        public ATNFToBeSubjVingTransOrFinNodeFactory_v2(ATNFToBeSubjTransNode_v2 parentNode, ATNExtendedToken token)
        {
            mNumberOfConstructor = 1;
            mParentNode = parentNode;
            mToken = token;
        }

        public ATNFToBeSubjVingTransOrFinNodeFactory_v2(ATNFToBeSubjVingTransOrFinNode_v2 sameNode, ATNExtendedToken token, InitATNFToBeSubjVingTransOrFinNodeAction initAction)
        {
            mNumberOfConstructor = 2;
            mSameNode = sameNode;
            mToken = token;
            mInitAction = initAction;
        }

        private int mNumberOfConstructor;
        private ATNFToBeSubjTransNode_v2 mParentNode;
        private ATNFToBeSubjVingTransOrFinNode_v2 mSameNode;
        private ATNExtendedToken mToken;
        private InitATNFToBeSubjVingTransOrFinNodeAction mInitAction;

        public override BaseATNNode_v2 Create(ContextOfATNParsing_v2 context)
        {
            switch(mNumberOfConstructor)
            {
                case 1:
                    return new ATNFToBeSubjVingTransOrFinNode_v2(context, mParentNode, mToken);

                case 2:
                    return new ATNFToBeSubjVingTransOrFinNode_v2(context, mSameNode, mInitAction, mToken);

                default:
                    throw new ArgumentOutOfRangeException(nameof(mNumberOfConstructor), mNumberOfConstructor, null);
            }
        }
    }

/*Sub states:
    FToBe_Subj_Ving_Obj_TransOrFin
    FToBe_Subj_Ving_No_Trans
    FToBe_Subj_Ving_Condition_Fin
*/

    public class ATNFToBeSubjVingTransOrFinNode_v2: BaseATNNode_v2
    {
        public ATNFToBeSubjVingTransOrFinNode_v2(ContextOfATNParsing_v2 context, ATNFToBeSubjTransNode_v2 parentNode, ATNExtendedToken token)
            : base(context, token)
        {
            ParentNode = parentNode;
        }

        public ATNFToBeSubjVingTransOrFinNode_v2(ContextOfATNParsing_v2 context, ATNFToBeSubjVingTransOrFinNode_v2 sameNode, InitATNFToBeSubjVingTransOrFinNodeAction initAction, ATNExtendedToken token)
            : base(context, token)
        {
            mSameNode = sameNode;
            mInitAction = initAction;
            ParentNode = mSameNode.ParentNode;
            mInitAction?.Invoke(this);
        }

        public override StateOfATNParsing_v2 GlobalState => StateOfATNParsing_v2.FToBe_Subj_Ving_TransOrFin;

        public ATNFToBeSubjTransNode_v2 ParentNode { get; private set; }
        private ATNFToBeSubjVingTransOrFinNode_v2 mSameNode;
        private InitATNFToBeSubjVingTransOrFinNodeAction mInitAction;

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

