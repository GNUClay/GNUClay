using MyNPCLib.NLToCGParsing;
using System;
using System.Collections.Generic;
using System.Text;

namespace MyNPCLib.NLToCGParsing_v2.ATNNodes
{
    public delegate void InitATNFToHaveSubjConditionV3NoObjTransOrFinNodeAction(ATNFToHaveSubjConditionV3NoObjTransOrFinNode_v2 item);

    public class ATNFToHaveSubjConditionV3NoObjTransOrFinNodeFactory_v2: BaseATNNodeFactory_v2
    {
        public ATNFToHaveSubjConditionV3NoObjTransOrFinNodeFactory_v2(ATNFToHaveSubjConditionV3NoTransNode_v2 parentNode, ATNExtendedToken token)
        {
            mNumberOfConstructor = 1;
            mParentNode = parentNode;
            mToken = token;
        }

        public ATNFToHaveSubjConditionV3NoObjTransOrFinNodeFactory_v2(ATNFToHaveSubjConditionV3NoObjTransOrFinNode_v2 sameNode, ATNExtendedToken token, InitATNFToHaveSubjConditionV3NoObjTransOrFinNodeAction initAction)
        {
            mNumberOfConstructor = 2;
            mSameNode = sameNode;
            mToken = token;
            mInitAction = initAction;
        }

        private int mNumberOfConstructor;
        private ATNFToHaveSubjConditionV3NoTransNode_v2 mParentNode;
        private ATNFToHaveSubjConditionV3NoObjTransOrFinNode_v2 mSameNode;
        private ATNExtendedToken mToken;
        private InitATNFToHaveSubjConditionV3NoObjTransOrFinNodeAction mInitAction;

        public override BaseATNNode_v2 Create(ContextOfATNParsing_v2 context)
        {
            switch(mNumberOfConstructor)
            {
                case 1:
                    return new ATNFToHaveSubjConditionV3NoObjTransOrFinNode_v2(context, mParentNode, mToken);

                case 2:
                    return new ATNFToHaveSubjConditionV3NoObjTransOrFinNode_v2(context, mSameNode, mInitAction, mToken);

                default:
                    throw new ArgumentOutOfRangeException(nameof(mNumberOfConstructor), mNumberOfConstructor, null);
            }
        }
    }

/*Sub states:
    FToHave_Subj_Condition_V3_No_Obj_Condition_Fin
*/

    public class ATNFToHaveSubjConditionV3NoObjTransOrFinNode_v2: BaseATNNode_v2
    {
        public ATNFToHaveSubjConditionV3NoObjTransOrFinNode_v2(ContextOfATNParsing_v2 context, ATNFToHaveSubjConditionV3NoTransNode_v2 parentNode, ATNExtendedToken token)
            : base(context, token)
        {
            ParentNode = parentNode;
        }

        public ATNFToHaveSubjConditionV3NoObjTransOrFinNode_v2(ContextOfATNParsing_v2 context, ATNFToHaveSubjConditionV3NoObjTransOrFinNode_v2 sameNode, InitATNFToHaveSubjConditionV3NoObjTransOrFinNodeAction initAction, ATNExtendedToken token)
            : base(context, token)
        {
            mSameNode = sameNode;
            mInitAction = initAction;
            ParentNode = mSameNode.ParentNode;
            mInitAction?.Invoke(this);
        }

        public override StateOfATNParsing_v2 GlobalState => StateOfATNParsing_v2.FToHave_Subj_Condition_V3_No_Obj_TransOrFin;

        public ATNFToHaveSubjConditionV3NoTransNode_v2 ParentNode { get; private set; }
        private ATNFToHaveSubjConditionV3NoObjTransOrFinNode_v2 mSameNode;
        private InitATNFToHaveSubjConditionV3NoObjTransOrFinNodeAction mInitAction;

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

