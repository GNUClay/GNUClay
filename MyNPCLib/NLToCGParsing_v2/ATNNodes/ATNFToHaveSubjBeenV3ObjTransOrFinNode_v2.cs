using MyNPCLib.NLToCGParsing;
using System;
using System.Collections.Generic;
using System.Text;

namespace MyNPCLib.NLToCGParsing_v2.ATNNodes
{
    public delegate void InitATNFToHaveSubjBeenV3ObjTransOrFinNodeAction(ATNFToHaveSubjBeenV3ObjTransOrFinNode_v2 item);

    public class ATNFToHaveSubjBeenV3ObjTransOrFinNodeFactory_v2: BaseATNNodeFactory_v2
    {
        public ATNFToHaveSubjBeenV3ObjTransOrFinNodeFactory_v2(ATNFToHaveSubjBeenV3TransOrFinNode_v2 parentNode, ATNExtendedToken token)
        {
            mNumberOfConstructor = 1;
            mParentNode = parentNode;
            mToken = token;
        }

        public ATNFToHaveSubjBeenV3ObjTransOrFinNodeFactory_v2(ATNFToHaveSubjBeenV3ObjTransOrFinNode_v2 sameNode, ATNExtendedToken token, InitATNFToHaveSubjBeenV3ObjTransOrFinNodeAction initAction)
        {
            mNumberOfConstructor = 2;
            mSameNode = sameNode;
            mToken = token;
            mInitAction = initAction;
        }

        private int mNumberOfConstructor;
        private ATNFToHaveSubjBeenV3TransOrFinNode_v2 mParentNode;
        private ATNFToHaveSubjBeenV3ObjTransOrFinNode_v2 mSameNode;
        private ATNExtendedToken mToken;
        private InitATNFToHaveSubjBeenV3ObjTransOrFinNodeAction mInitAction;

        public override BaseATNNode_v2 Create(ContextOfATNParsing_v2 context)
        {
            switch(mNumberOfConstructor)
            {
                case 1:
                    return new ATNFToHaveSubjBeenV3ObjTransOrFinNode_v2(context, mParentNode, mToken);

                case 2:
                    return new ATNFToHaveSubjBeenV3ObjTransOrFinNode_v2(context, mSameNode, mInitAction, mToken);

                default:
                    throw new ArgumentOutOfRangeException(nameof(mNumberOfConstructor), mNumberOfConstructor, null);
            }
        }
    }

/*Sub states:
    FToHave_Subj_Been_V3_Obj_Condition_Fin
*/

    public class ATNFToHaveSubjBeenV3ObjTransOrFinNode_v2: BaseATNNode_v2
    {
        public ATNFToHaveSubjBeenV3ObjTransOrFinNode_v2(ContextOfATNParsing_v2 context, ATNFToHaveSubjBeenV3TransOrFinNode_v2 parentNode, ATNExtendedToken token)
            : base(context, token)
        {
            ParentNode = parentNode;
        }

        public ATNFToHaveSubjBeenV3ObjTransOrFinNode_v2(ContextOfATNParsing_v2 context, ATNFToHaveSubjBeenV3ObjTransOrFinNode_v2 sameNode, InitATNFToHaveSubjBeenV3ObjTransOrFinNodeAction initAction, ATNExtendedToken token)
            : base(context, token)
        {
            mSameNode = sameNode;
            mInitAction = initAction;
            ParentNode = mSameNode.ParentNode;
            mInitAction?.Invoke(this);
        }

        public override StateOfATNParsing_v2 GlobalState => StateOfATNParsing_v2.FToHave_Subj_Been_V3_Obj_TransOrFin;

        public ATNFToHaveSubjBeenV3TransOrFinNode_v2 ParentNode { get; private set; }
        private ATNFToHaveSubjBeenV3ObjTransOrFinNode_v2 mSameNode;
        private InitATNFToHaveSubjBeenV3ObjTransOrFinNodeAction mInitAction;

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

