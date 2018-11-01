using MyNPCLib.NLToCGParsing;
using System;
using System.Collections.Generic;
using System.Text;

namespace MyNPCLib.NLToCGParsing_v2.ATNNodes
{
    public delegate void InitATNConditionSubjWillNotFToHaveV3ObjTransOrFinNodeAction(ATNConditionSubjWillNotFToHaveV3ObjTransOrFinNode_v2 item);

    public class ATNConditionSubjWillNotFToHaveV3ObjTransOrFinNodeFactory_v2: BaseATNNodeFactory_v2
    {
        public ATNConditionSubjWillNotFToHaveV3ObjTransOrFinNodeFactory_v2(ATNConditionSubjWillNotFToHaveV3TransOrFinNode_v2 parentNode, ATNExtendedToken token)
        {
            mNumberOfConstructor = 1;
            mParentNode = parentNode;
            mToken = token;
        }

        public ATNConditionSubjWillNotFToHaveV3ObjTransOrFinNodeFactory_v2(ATNConditionSubjWillNotFToHaveV3ObjTransOrFinNode_v2 sameNode, ATNExtendedToken token, InitATNConditionSubjWillNotFToHaveV3ObjTransOrFinNodeAction initAction)
        {
            mNumberOfConstructor = 2;
            mSameNode = sameNode;
            mToken = token;
            mInitAction = initAction;
        }

        private int mNumberOfConstructor;
        private ATNConditionSubjWillNotFToHaveV3TransOrFinNode_v2 mParentNode;
        private ATNConditionSubjWillNotFToHaveV3ObjTransOrFinNode_v2 mSameNode;
        private ATNExtendedToken mToken;
        private InitATNConditionSubjWillNotFToHaveV3ObjTransOrFinNodeAction mInitAction;

        public override BaseATNNode_v2 Create(ContextOfATNParsing_v2 context)
        {
            switch(mNumberOfConstructor)
            {
                case 1:
                    return new ATNConditionSubjWillNotFToHaveV3ObjTransOrFinNode_v2(context, mParentNode, mToken);

                case 2:
                    return new ATNConditionSubjWillNotFToHaveV3ObjTransOrFinNode_v2(context, mSameNode, mInitAction, mToken);

                default:
                    throw new ArgumentOutOfRangeException(nameof(mNumberOfConstructor), mNumberOfConstructor, null);
            }
        }
    }

/*Sub states:
    Condition_Subj_Will_Not_FToHave_V3_Obj_Condition_Fin
*/

    public class ATNConditionSubjWillNotFToHaveV3ObjTransOrFinNode_v2: BaseATNNode_v2
    {
        public ATNConditionSubjWillNotFToHaveV3ObjTransOrFinNode_v2(ContextOfATNParsing_v2 context, ATNConditionSubjWillNotFToHaveV3TransOrFinNode_v2 parentNode, ATNExtendedToken token)
            : base(context, token)
        {
            ParentNode = parentNode;
        }

        public ATNConditionSubjWillNotFToHaveV3ObjTransOrFinNode_v2(ContextOfATNParsing_v2 context, ATNConditionSubjWillNotFToHaveV3ObjTransOrFinNode_v2 sameNode, InitATNConditionSubjWillNotFToHaveV3ObjTransOrFinNodeAction initAction, ATNExtendedToken token)
            : base(context, token)
        {
            mSameNode = sameNode;
            mInitAction = initAction;
            ParentNode = mSameNode.ParentNode;
            mInitAction?.Invoke(this);
        }

        public override StateOfATNParsing_v2 GlobalState => StateOfATNParsing_v2.Condition_Subj_Will_Not_FToHave_V3_Obj_TransOrFin;

        public ATNConditionSubjWillNotFToHaveV3TransOrFinNode_v2 ParentNode { get; private set; }
        private ATNConditionSubjWillNotFToHaveV3ObjTransOrFinNode_v2 mSameNode;
        private InitATNConditionSubjWillNotFToHaveV3ObjTransOrFinNodeAction mInitAction;

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

