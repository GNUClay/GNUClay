using MyNPCLib.NLToCGParsing;
using System;
using System.Collections.Generic;
using System.Text;

namespace MyNPCLib.NLToCGParsing_v2.ATNNodes
{
    public delegate void InitATNWillSubjFToHaveConditionV3ObjTransOrFinNodeAction(ATNWillSubjFToHaveConditionV3ObjTransOrFinNode_v2 item);

    public class ATNWillSubjFToHaveConditionV3ObjTransOrFinNodeFactory_v2: BaseATNNodeFactory_v2
    {
        public ATNWillSubjFToHaveConditionV3ObjTransOrFinNodeFactory_v2(ATNWillSubjFToHaveConditionV3TransOrFinNode_v2 parentNode, ATNExtendedToken token)
        {
            mNumberOfConstructor = 1;
            mParentNode = parentNode;
            mToken = token;
        }

        public ATNWillSubjFToHaveConditionV3ObjTransOrFinNodeFactory_v2(ATNWillSubjFToHaveConditionV3ObjTransOrFinNode_v2 sameNode, ATNExtendedToken token, InitATNWillSubjFToHaveConditionV3ObjTransOrFinNodeAction initAction)
        {
            mNumberOfConstructor = 2;
            mSameNode = sameNode;
            mToken = token;
            mInitAction = initAction;
        }

        private int mNumberOfConstructor;
        private ATNWillSubjFToHaveConditionV3TransOrFinNode_v2 mParentNode;
        private ATNWillSubjFToHaveConditionV3ObjTransOrFinNode_v2 mSameNode;
        private ATNExtendedToken mToken;
        private InitATNWillSubjFToHaveConditionV3ObjTransOrFinNodeAction mInitAction;

        public override BaseATNNode_v2 Create(ContextOfATNParsing_v2 context)
        {
            switch(mNumberOfConstructor)
            {
                case 1:
                    return new ATNWillSubjFToHaveConditionV3ObjTransOrFinNode_v2(context, mParentNode, mToken);

                case 2:
                    return new ATNWillSubjFToHaveConditionV3ObjTransOrFinNode_v2(context, mSameNode, mInitAction, mToken);

                default:
                    throw new ArgumentOutOfRangeException(nameof(mNumberOfConstructor), mNumberOfConstructor, null);
            }
        }
    }

/*Sub states:
    Will_Subj_FToHave_Condition_V3_Obj_Condition_Fin
*/

    public class ATNWillSubjFToHaveConditionV3ObjTransOrFinNode_v2: BaseATNNode_v2
    {
        public ATNWillSubjFToHaveConditionV3ObjTransOrFinNode_v2(ContextOfATNParsing_v2 context, ATNWillSubjFToHaveConditionV3TransOrFinNode_v2 parentNode, ATNExtendedToken token)
            : base(context, token)
        {
            ParentNode = parentNode;
        }

        public ATNWillSubjFToHaveConditionV3ObjTransOrFinNode_v2(ContextOfATNParsing_v2 context, ATNWillSubjFToHaveConditionV3ObjTransOrFinNode_v2 sameNode, InitATNWillSubjFToHaveConditionV3ObjTransOrFinNodeAction initAction, ATNExtendedToken token)
            : base(context, token)
        {
            mSameNode = sameNode;
            mInitAction = initAction;
            ParentNode = mSameNode.ParentNode;
            mInitAction?.Invoke(this);
        }

        public override StateOfATNParsing_v2 GlobalState => StateOfATNParsing_v2.Will_Subj_FToHave_Condition_V3_Obj_TransOrFin;

        public ATNWillSubjFToHaveConditionV3TransOrFinNode_v2 ParentNode { get; private set; }
        private ATNWillSubjFToHaveConditionV3ObjTransOrFinNode_v2 mSameNode;
        private InitATNWillSubjFToHaveConditionV3ObjTransOrFinNodeAction mInitAction;

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

