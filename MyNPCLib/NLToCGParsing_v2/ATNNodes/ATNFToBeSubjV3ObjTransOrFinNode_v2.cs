using MyNPCLib.NLToCGParsing;
using System;
using System.Collections.Generic;
using System.Text;

namespace MyNPCLib.NLToCGParsing_v2.ATNNodes
{
    public delegate void InitATNFToBeSubjV3ObjTransOrFinNodeAction(ATNFToBeSubjV3ObjTransOrFinNode_v2 item);

    public class ATNFToBeSubjV3ObjTransOrFinNodeFactory_v2: BaseATNNodeFactory_v2
    {
        public ATNFToBeSubjV3ObjTransOrFinNodeFactory_v2(ATNFToBeSubjV3TransOrFinNode_v2 parentNode, ATNExtendedToken token)
        {
            mNumberOfConstructor = 1;
            mParentNode = parentNode;
            mToken = token;
        }

        public ATNFToBeSubjV3ObjTransOrFinNodeFactory_v2(ATNFToBeSubjV3ObjTransOrFinNode_v2 sameNode, ATNExtendedToken token, InitATNFToBeSubjV3ObjTransOrFinNodeAction initAction)
        {
            mNumberOfConstructor = 2;
            mSameNode = sameNode;
            mToken = token;
            mInitAction = initAction;
        }

        private int mNumberOfConstructor;
        private ATNFToBeSubjV3TransOrFinNode_v2 mParentNode;
        private ATNFToBeSubjV3ObjTransOrFinNode_v2 mSameNode;
        private ATNExtendedToken mToken;
        private InitATNFToBeSubjV3ObjTransOrFinNodeAction mInitAction;

        public override BaseATNNode_v2 Create(ContextOfATNParsing_v2 context)
        {
            switch(mNumberOfConstructor)
            {
                case 1:
                    return new ATNFToBeSubjV3ObjTransOrFinNode_v2(context, mParentNode, mToken);

                case 2:
                    return new ATNFToBeSubjV3ObjTransOrFinNode_v2(context, mSameNode, mInitAction, mToken);

                default:
                    throw new ArgumentOutOfRangeException(nameof(mNumberOfConstructor), mNumberOfConstructor, null);
            }
        }
    }

/*Sub states:
    FToBe_Subj_V3_Obj_Condition_Fin
*/

    public class ATNFToBeSubjV3ObjTransOrFinNode_v2: BaseATNNode_v2
    {
        public ATNFToBeSubjV3ObjTransOrFinNode_v2(ContextOfATNParsing_v2 context, ATNFToBeSubjV3TransOrFinNode_v2 parentNode, ATNExtendedToken token)
            : base(context, token)
        {
            ParentNode = parentNode;
        }

        public ATNFToBeSubjV3ObjTransOrFinNode_v2(ContextOfATNParsing_v2 context, ATNFToBeSubjV3ObjTransOrFinNode_v2 sameNode, InitATNFToBeSubjV3ObjTransOrFinNodeAction initAction, ATNExtendedToken token)
            : base(context, token)
        {
            mSameNode = sameNode;
            mInitAction = initAction;
            ParentNode = mSameNode.ParentNode;
            mInitAction?.Invoke(this);
        }

        public override StateOfATNParsing_v2 GlobalState => StateOfATNParsing_v2.FToBe_Subj_V3_Obj_TransOrFin;

        public ATNFToBeSubjV3TransOrFinNode_v2 ParentNode { get; private set; }
        private ATNFToBeSubjV3ObjTransOrFinNode_v2 mSameNode;
        private InitATNFToBeSubjV3ObjTransOrFinNodeAction mInitAction;

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

