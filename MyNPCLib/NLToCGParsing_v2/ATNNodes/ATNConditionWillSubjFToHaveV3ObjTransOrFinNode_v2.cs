using MyNPCLib.NLToCGParsing;
using System;
using System.Collections.Generic;
using System.Text;

namespace MyNPCLib.NLToCGParsing_v2.ATNNodes
{
    public delegate void InitATNConditionWillSubjFToHaveV3ObjTransOrFinNodeAction(ATNConditionWillSubjFToHaveV3ObjTransOrFinNode_v2 item);

    public class ATNConditionWillSubjFToHaveV3ObjTransOrFinNodeFactory_v2: BaseATNNodeFactory_v2
    {
        public ATNConditionWillSubjFToHaveV3ObjTransOrFinNodeFactory_v2(ATNConditionWillSubjFToHaveV3TransOrFinNode_v2 parentNode, ATNExtendedToken token)
        {
            mNumberOfConstructor = 1;
            mParentNode = parentNode;
            mToken = token;
        }

        public ATNConditionWillSubjFToHaveV3ObjTransOrFinNodeFactory_v2(ATNConditionWillSubjFToHaveV3ObjTransOrFinNode_v2 sameNode, ATNExtendedToken token, InitATNConditionWillSubjFToHaveV3ObjTransOrFinNodeAction initAction)
        {
            mNumberOfConstructor = 2;
            mSameNode = sameNode;
            mToken = token;
            mInitAction = initAction;
        }

        private int mNumberOfConstructor;
        private ATNConditionWillSubjFToHaveV3TransOrFinNode_v2 mParentNode;
        private ATNConditionWillSubjFToHaveV3ObjTransOrFinNode_v2 mSameNode;
        private ATNExtendedToken mToken;
        private InitATNConditionWillSubjFToHaveV3ObjTransOrFinNodeAction mInitAction;

        public override BaseATNNode_v2 Create(ContextOfATNParsing_v2 context)
        {
            switch(mNumberOfConstructor)
            {
                case 1:
                    return new ATNConditionWillSubjFToHaveV3ObjTransOrFinNode_v2(context, mParentNode, mToken);

                case 2:
                    return new ATNConditionWillSubjFToHaveV3ObjTransOrFinNode_v2(context, mSameNode, mInitAction, mToken);

                default:
                    throw new ArgumentOutOfRangeException(nameof(mNumberOfConstructor), mNumberOfConstructor, null);
            }
        }
    }

/*Sub states:
    Condition_Will_Subj_FToHave_V3_Obj_Condition_Fin
*/

    public class ATNConditionWillSubjFToHaveV3ObjTransOrFinNode_v2: BaseATNNode_v2
    {
        public ATNConditionWillSubjFToHaveV3ObjTransOrFinNode_v2(ContextOfATNParsing_v2 context, ATNConditionWillSubjFToHaveV3TransOrFinNode_v2 parentNode, ATNExtendedToken token)
            : base(context, token)
        {
            ParentNode = parentNode;
        }

        public ATNConditionWillSubjFToHaveV3ObjTransOrFinNode_v2(ContextOfATNParsing_v2 context, ATNConditionWillSubjFToHaveV3ObjTransOrFinNode_v2 sameNode, InitATNConditionWillSubjFToHaveV3ObjTransOrFinNodeAction initAction, ATNExtendedToken token)
            : base(context, token)
        {
            mSameNode = sameNode;
            mInitAction = initAction;
            ParentNode = mSameNode.ParentNode;
            mInitAction?.Invoke(this);
        }

        public override StateOfATNParsing_v2 GlobalState => StateOfATNParsing_v2.Condition_Will_Subj_FToHave_V3_Obj_TransOrFin;

        public ATNConditionWillSubjFToHaveV3TransOrFinNode_v2 ParentNode { get; private set; }
        private ATNConditionWillSubjFToHaveV3ObjTransOrFinNode_v2 mSameNode;
        private InitATNConditionWillSubjFToHaveV3ObjTransOrFinNodeAction mInitAction;

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

