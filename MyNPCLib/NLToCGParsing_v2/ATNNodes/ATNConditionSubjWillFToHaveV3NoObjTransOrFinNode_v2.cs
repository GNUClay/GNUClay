using MyNPCLib.NLToCGParsing;
using System;
using System.Collections.Generic;
using System.Text;

namespace MyNPCLib.NLToCGParsing_v2.ATNNodes
{
    public delegate void InitATNConditionSubjWillFToHaveV3NoObjTransOrFinNodeAction(ATNConditionSubjWillFToHaveV3NoObjTransOrFinNode_v2 item);

    public class ATNConditionSubjWillFToHaveV3NoObjTransOrFinNodeFactory_v2: BaseATNNodeFactory_v2
    {
        public ATNConditionSubjWillFToHaveV3NoObjTransOrFinNodeFactory_v2(ATNConditionSubjWillFToHaveV3NoTransNode_v2 parentNode, ATNExtendedToken token)
        {
            mNumberOfConstructor = 1;
            mParentNode = parentNode;
            mToken = token;
        }

        public ATNConditionSubjWillFToHaveV3NoObjTransOrFinNodeFactory_v2(ATNConditionSubjWillFToHaveV3NoObjTransOrFinNode_v2 sameNode, ATNExtendedToken token, InitATNConditionSubjWillFToHaveV3NoObjTransOrFinNodeAction initAction)
        {
            mNumberOfConstructor = 2;
            mSameNode = sameNode;
            mToken = token;
            mInitAction = initAction;
        }

        private int mNumberOfConstructor;
        private ATNConditionSubjWillFToHaveV3NoTransNode_v2 mParentNode;
        private ATNConditionSubjWillFToHaveV3NoObjTransOrFinNode_v2 mSameNode;
        private ATNExtendedToken mToken;
        private InitATNConditionSubjWillFToHaveV3NoObjTransOrFinNodeAction mInitAction;

        public override BaseATNNode_v2 Create(ContextOfATNParsing_v2 context)
        {
            switch(mNumberOfConstructor)
            {
                case 1:
                    return new ATNConditionSubjWillFToHaveV3NoObjTransOrFinNode_v2(context, mParentNode, mToken);

                case 2:
                    return new ATNConditionSubjWillFToHaveV3NoObjTransOrFinNode_v2(context, mSameNode, mInitAction, mToken);

                default:
                    throw new ArgumentOutOfRangeException(nameof(mNumberOfConstructor), mNumberOfConstructor, null);
            }
        }
    }

/*Sub states:
    Condition_Subj_Will_FToHave_V3_No_Obj_Condition_Fin
*/

    public class ATNConditionSubjWillFToHaveV3NoObjTransOrFinNode_v2: BaseATNNode_v2
    {
        public ATNConditionSubjWillFToHaveV3NoObjTransOrFinNode_v2(ContextOfATNParsing_v2 context, ATNConditionSubjWillFToHaveV3NoTransNode_v2 parentNode, ATNExtendedToken token)
            : base(context, token)
        {
            ParentNode = parentNode;
        }

        public ATNConditionSubjWillFToHaveV3NoObjTransOrFinNode_v2(ContextOfATNParsing_v2 context, ATNConditionSubjWillFToHaveV3NoObjTransOrFinNode_v2 sameNode, InitATNConditionSubjWillFToHaveV3NoObjTransOrFinNodeAction initAction, ATNExtendedToken token)
            : base(context, token)
        {
            mSameNode = sameNode;
            mInitAction = initAction;
            ParentNode = mSameNode.ParentNode;
            mInitAction?.Invoke(this);
        }

        public override StateOfATNParsing_v2 GlobalState => StateOfATNParsing_v2.Condition_Subj_Will_FToHave_V3_No_Obj_TransOrFin;

        public ATNConditionSubjWillFToHaveV3NoTransNode_v2 ParentNode { get; private set; }
        private ATNConditionSubjWillFToHaveV3NoObjTransOrFinNode_v2 mSameNode;
        private InitATNConditionSubjWillFToHaveV3NoObjTransOrFinNodeAction mInitAction;

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

