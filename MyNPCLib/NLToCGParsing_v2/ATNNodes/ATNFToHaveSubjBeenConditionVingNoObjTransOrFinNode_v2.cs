using MyNPCLib.NLToCGParsing;
using System;
using System.Collections.Generic;
using System.Text;

namespace MyNPCLib.NLToCGParsing_v2.ATNNodes
{
    public delegate void InitATNFToHaveSubjBeenConditionVingNoObjTransOrFinNodeAction(ATNFToHaveSubjBeenConditionVingNoObjTransOrFinNode_v2 item);

    public class ATNFToHaveSubjBeenConditionVingNoObjTransOrFinNodeFactory_v2: BaseATNNodeFactory_v2
    {
        public ATNFToHaveSubjBeenConditionVingNoObjTransOrFinNodeFactory_v2(ATNFToHaveSubjBeenConditionVingNoTransNode_v2 parentNode, ATNExtendedToken token)
        {
            mNumberOfConstructor = 1;
            mParentNode = parentNode;
            mToken = token;
        }

        public ATNFToHaveSubjBeenConditionVingNoObjTransOrFinNodeFactory_v2(ATNFToHaveSubjBeenConditionVingNoObjTransOrFinNode_v2 sameNode, ATNExtendedToken token, InitATNFToHaveSubjBeenConditionVingNoObjTransOrFinNodeAction initAction)
        {
            mNumberOfConstructor = 2;
            mSameNode = sameNode;
            mToken = token;
            mInitAction = initAction;
        }

        private int mNumberOfConstructor;
        private ATNFToHaveSubjBeenConditionVingNoTransNode_v2 mParentNode;
        private ATNFToHaveSubjBeenConditionVingNoObjTransOrFinNode_v2 mSameNode;
        private ATNExtendedToken mToken;
        private InitATNFToHaveSubjBeenConditionVingNoObjTransOrFinNodeAction mInitAction;

        public override BaseATNNode_v2 Create(ContextOfATNParsing_v2 context)
        {
            switch(mNumberOfConstructor)
            {
                case 1:
                    return new ATNFToHaveSubjBeenConditionVingNoObjTransOrFinNode_v2(context, mParentNode, mToken);

                case 2:
                    return new ATNFToHaveSubjBeenConditionVingNoObjTransOrFinNode_v2(context, mSameNode, mInitAction, mToken);

                default:
                    throw new ArgumentOutOfRangeException(nameof(mNumberOfConstructor), mNumberOfConstructor, null);
            }
        }
    }

/*Sub states:
    FToHave_Subj_Been_Condition_Ving_No_Obj_Condition_Fin
*/

    public class ATNFToHaveSubjBeenConditionVingNoObjTransOrFinNode_v2: BaseATNNode_v2
    {
        public ATNFToHaveSubjBeenConditionVingNoObjTransOrFinNode_v2(ContextOfATNParsing_v2 context, ATNFToHaveSubjBeenConditionVingNoTransNode_v2 parentNode, ATNExtendedToken token)
            : base(context, token)
        {
            ParentNode = parentNode;
        }

        public ATNFToHaveSubjBeenConditionVingNoObjTransOrFinNode_v2(ContextOfATNParsing_v2 context, ATNFToHaveSubjBeenConditionVingNoObjTransOrFinNode_v2 sameNode, InitATNFToHaveSubjBeenConditionVingNoObjTransOrFinNodeAction initAction, ATNExtendedToken token)
            : base(context, token)
        {
            mSameNode = sameNode;
            mInitAction = initAction;
            ParentNode = mSameNode.ParentNode;
            mInitAction?.Invoke(this);
        }

        public override StateOfATNParsing_v2 GlobalState => StateOfATNParsing_v2.FToHave_Subj_Been_Condition_Ving_No_Obj_TransOrFin;

        public ATNFToHaveSubjBeenConditionVingNoTransNode_v2 ParentNode { get; private set; }
        private ATNFToHaveSubjBeenConditionVingNoObjTransOrFinNode_v2 mSameNode;
        private InitATNFToHaveSubjBeenConditionVingNoObjTransOrFinNodeAction mInitAction;

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

