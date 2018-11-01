using MyNPCLib.NLToCGParsing;
using System;
using System.Collections.Generic;
using System.Text;

namespace MyNPCLib.NLToCGParsing_v2.ATNNodes
{
    public delegate void InitATNConditionSubjFToHaveNotV3ObjTransOrFinNodeAction(ATNConditionSubjFToHaveNotV3ObjTransOrFinNode_v2 item);

    public class ATNConditionSubjFToHaveNotV3ObjTransOrFinNodeFactory_v2: BaseATNNodeFactory_v2
    {
        public ATNConditionSubjFToHaveNotV3ObjTransOrFinNodeFactory_v2(ATNConditionSubjFToHaveNotV3TransOrFinNode_v2 parentNode, ATNExtendedToken token)
        {
            mNumberOfConstructor = 1;
            mParentNode = parentNode;
            mToken = token;
        }

        public ATNConditionSubjFToHaveNotV3ObjTransOrFinNodeFactory_v2(ATNConditionSubjFToHaveNotV3ObjTransOrFinNode_v2 sameNode, ATNExtendedToken token, InitATNConditionSubjFToHaveNotV3ObjTransOrFinNodeAction initAction)
        {
            mNumberOfConstructor = 2;
            mSameNode = sameNode;
            mToken = token;
            mInitAction = initAction;
        }

        private int mNumberOfConstructor;
        private ATNConditionSubjFToHaveNotV3TransOrFinNode_v2 mParentNode;
        private ATNConditionSubjFToHaveNotV3ObjTransOrFinNode_v2 mSameNode;
        private ATNExtendedToken mToken;
        private InitATNConditionSubjFToHaveNotV3ObjTransOrFinNodeAction mInitAction;

        public override BaseATNNode_v2 Create(ContextOfATNParsing_v2 context)
        {
            switch(mNumberOfConstructor)
            {
                case 1:
                    return new ATNConditionSubjFToHaveNotV3ObjTransOrFinNode_v2(context, mParentNode, mToken);

                case 2:
                    return new ATNConditionSubjFToHaveNotV3ObjTransOrFinNode_v2(context, mSameNode, mInitAction, mToken);

                default:
                    throw new ArgumentOutOfRangeException(nameof(mNumberOfConstructor), mNumberOfConstructor, null);
            }
        }
    }

/*Sub states:
    Condition_Subj_FToHave_Not_V3_Obj_Condition_Fin
*/

    public class ATNConditionSubjFToHaveNotV3ObjTransOrFinNode_v2: BaseATNNode_v2
    {
        public ATNConditionSubjFToHaveNotV3ObjTransOrFinNode_v2(ContextOfATNParsing_v2 context, ATNConditionSubjFToHaveNotV3TransOrFinNode_v2 parentNode, ATNExtendedToken token)
            : base(context, token)
        {
            ParentNode = parentNode;
        }

        public ATNConditionSubjFToHaveNotV3ObjTransOrFinNode_v2(ContextOfATNParsing_v2 context, ATNConditionSubjFToHaveNotV3ObjTransOrFinNode_v2 sameNode, InitATNConditionSubjFToHaveNotV3ObjTransOrFinNodeAction initAction, ATNExtendedToken token)
            : base(context, token)
        {
            mSameNode = sameNode;
            mInitAction = initAction;
            ParentNode = mSameNode.ParentNode;
            mInitAction?.Invoke(this);
        }

        public override StateOfATNParsing_v2 GlobalState => StateOfATNParsing_v2.Condition_Subj_FToHave_Not_V3_Obj_TransOrFin;

        public ATNConditionSubjFToHaveNotV3TransOrFinNode_v2 ParentNode { get; private set; }
        private ATNConditionSubjFToHaveNotV3ObjTransOrFinNode_v2 mSameNode;
        private InitATNConditionSubjFToHaveNotV3ObjTransOrFinNodeAction mInitAction;

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

