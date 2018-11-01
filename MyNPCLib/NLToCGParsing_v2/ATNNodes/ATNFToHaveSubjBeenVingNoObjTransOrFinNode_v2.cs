using MyNPCLib.NLToCGParsing;
using System;
using System.Collections.Generic;
using System.Text;

namespace MyNPCLib.NLToCGParsing_v2.ATNNodes
{
    public delegate void InitATNFToHaveSubjBeenVingNoObjTransOrFinNodeAction(ATNFToHaveSubjBeenVingNoObjTransOrFinNode_v2 item);

    public class ATNFToHaveSubjBeenVingNoObjTransOrFinNodeFactory_v2: BaseATNNodeFactory_v2
    {
        public ATNFToHaveSubjBeenVingNoObjTransOrFinNodeFactory_v2(ATNFToHaveSubjBeenVingNoTransNode_v2 parentNode, ATNExtendedToken token)
        {
            mNumberOfConstructor = 1;
            mParentNode = parentNode;
            mToken = token;
        }

        public ATNFToHaveSubjBeenVingNoObjTransOrFinNodeFactory_v2(ATNFToHaveSubjBeenVingNoObjTransOrFinNode_v2 sameNode, ATNExtendedToken token, InitATNFToHaveSubjBeenVingNoObjTransOrFinNodeAction initAction)
        {
            mNumberOfConstructor = 2;
            mSameNode = sameNode;
            mToken = token;
            mInitAction = initAction;
        }

        private int mNumberOfConstructor;
        private ATNFToHaveSubjBeenVingNoTransNode_v2 mParentNode;
        private ATNFToHaveSubjBeenVingNoObjTransOrFinNode_v2 mSameNode;
        private ATNExtendedToken mToken;
        private InitATNFToHaveSubjBeenVingNoObjTransOrFinNodeAction mInitAction;

        public override BaseATNNode_v2 Create(ContextOfATNParsing_v2 context)
        {
            switch(mNumberOfConstructor)
            {
                case 1:
                    return new ATNFToHaveSubjBeenVingNoObjTransOrFinNode_v2(context, mParentNode, mToken);

                case 2:
                    return new ATNFToHaveSubjBeenVingNoObjTransOrFinNode_v2(context, mSameNode, mInitAction, mToken);

                default:
                    throw new ArgumentOutOfRangeException(nameof(mNumberOfConstructor), mNumberOfConstructor, null);
            }
        }
    }

/*Sub states:
    FToHave_Subj_Been_Ving_No_Obj_Condition_Fin
*/

    public class ATNFToHaveSubjBeenVingNoObjTransOrFinNode_v2: BaseATNNode_v2
    {
        public ATNFToHaveSubjBeenVingNoObjTransOrFinNode_v2(ContextOfATNParsing_v2 context, ATNFToHaveSubjBeenVingNoTransNode_v2 parentNode, ATNExtendedToken token)
            : base(context, token)
        {
            ParentNode = parentNode;
        }

        public ATNFToHaveSubjBeenVingNoObjTransOrFinNode_v2(ContextOfATNParsing_v2 context, ATNFToHaveSubjBeenVingNoObjTransOrFinNode_v2 sameNode, InitATNFToHaveSubjBeenVingNoObjTransOrFinNodeAction initAction, ATNExtendedToken token)
            : base(context, token)
        {
            mSameNode = sameNode;
            mInitAction = initAction;
            ParentNode = mSameNode.ParentNode;
            mInitAction?.Invoke(this);
        }

        public override StateOfATNParsing_v2 GlobalState => StateOfATNParsing_v2.FToHave_Subj_Been_Ving_No_Obj_TransOrFin;

        public ATNFToHaveSubjBeenVingNoTransNode_v2 ParentNode { get; private set; }
        private ATNFToHaveSubjBeenVingNoObjTransOrFinNode_v2 mSameNode;
        private InitATNFToHaveSubjBeenVingNoObjTransOrFinNodeAction mInitAction;

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

