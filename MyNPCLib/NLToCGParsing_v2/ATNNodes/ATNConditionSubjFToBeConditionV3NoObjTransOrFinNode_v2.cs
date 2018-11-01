using MyNPCLib.NLToCGParsing;
using System;
using System.Collections.Generic;
using System.Text;

namespace MyNPCLib.NLToCGParsing_v2.ATNNodes
{
    public delegate void InitATNConditionSubjFToBeConditionV3NoObjTransOrFinNodeAction(ATNConditionSubjFToBeConditionV3NoObjTransOrFinNode_v2 item);

    public class ATNConditionSubjFToBeConditionV3NoObjTransOrFinNodeFactory_v2: BaseATNNodeFactory_v2
    {
        public ATNConditionSubjFToBeConditionV3NoObjTransOrFinNodeFactory_v2(ATNConditionSubjFToBeConditionV3NoTransNode_v2 parentNode, ATNExtendedToken token)
        {
            mNumberOfConstructor = 1;
            mParentNode = parentNode;
            mToken = token;
        }

        public ATNConditionSubjFToBeConditionV3NoObjTransOrFinNodeFactory_v2(ATNConditionSubjFToBeConditionV3NoObjTransOrFinNode_v2 sameNode, ATNExtendedToken token, InitATNConditionSubjFToBeConditionV3NoObjTransOrFinNodeAction initAction)
        {
            mNumberOfConstructor = 2;
            mSameNode = sameNode;
            mToken = token;
            mInitAction = initAction;
        }

        private int mNumberOfConstructor;
        private ATNConditionSubjFToBeConditionV3NoTransNode_v2 mParentNode;
        private ATNConditionSubjFToBeConditionV3NoObjTransOrFinNode_v2 mSameNode;
        private ATNExtendedToken mToken;
        private InitATNConditionSubjFToBeConditionV3NoObjTransOrFinNodeAction mInitAction;

        public override BaseATNNode_v2 Create(ContextOfATNParsing_v2 context)
        {
            switch(mNumberOfConstructor)
            {
                case 1:
                    return new ATNConditionSubjFToBeConditionV3NoObjTransOrFinNode_v2(context, mParentNode, mToken);

                case 2:
                    return new ATNConditionSubjFToBeConditionV3NoObjTransOrFinNode_v2(context, mSameNode, mInitAction, mToken);

                default:
                    throw new ArgumentOutOfRangeException(nameof(mNumberOfConstructor), mNumberOfConstructor, null);
            }
        }
    }

/*Sub states:
    Condition_Subj_FToBe_Condition_V3_No_Obj_Condition_Fin
*/

    public class ATNConditionSubjFToBeConditionV3NoObjTransOrFinNode_v2: BaseATNNode_v2
    {
        public ATNConditionSubjFToBeConditionV3NoObjTransOrFinNode_v2(ContextOfATNParsing_v2 context, ATNConditionSubjFToBeConditionV3NoTransNode_v2 parentNode, ATNExtendedToken token)
            : base(context, token)
        {
            ParentNode = parentNode;
        }

        public ATNConditionSubjFToBeConditionV3NoObjTransOrFinNode_v2(ContextOfATNParsing_v2 context, ATNConditionSubjFToBeConditionV3NoObjTransOrFinNode_v2 sameNode, InitATNConditionSubjFToBeConditionV3NoObjTransOrFinNodeAction initAction, ATNExtendedToken token)
            : base(context, token)
        {
            mSameNode = sameNode;
            mInitAction = initAction;
            ParentNode = mSameNode.ParentNode;
            mInitAction?.Invoke(this);
        }

        public override StateOfATNParsing_v2 GlobalState => StateOfATNParsing_v2.Condition_Subj_FToBe_Condition_V3_No_Obj_TransOrFin;

        public ATNConditionSubjFToBeConditionV3NoTransNode_v2 ParentNode { get; private set; }
        private ATNConditionSubjFToBeConditionV3NoObjTransOrFinNode_v2 mSameNode;
        private InitATNConditionSubjFToBeConditionV3NoObjTransOrFinNodeAction mInitAction;

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

