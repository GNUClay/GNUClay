using MyNPCLib.NLToCGParsing;
using System;
using System.Collections.Generic;
using System.Text;

namespace MyNPCLib.NLToCGParsing_v2.ATNNodes
{
    public delegate void InitATNWillSubjFToHaveBeenConditionV3ObjTransOrFinNodeAction(ATNWillSubjFToHaveBeenConditionV3ObjTransOrFinNode_v2 item);

    public class ATNWillSubjFToHaveBeenConditionV3ObjTransOrFinNodeFactory_v2: BaseATNNodeFactory_v2
    {
        public ATNWillSubjFToHaveBeenConditionV3ObjTransOrFinNodeFactory_v2(ATNWillSubjFToHaveBeenConditionV3TransOrFinNode_v2 parentNode, ATNExtendedToken token)
        {
            mNumberOfConstructor = 1;
            mParentNode = parentNode;
            mToken = token;
        }

        public ATNWillSubjFToHaveBeenConditionV3ObjTransOrFinNodeFactory_v2(ATNWillSubjFToHaveBeenConditionV3ObjTransOrFinNode_v2 sameNode, ATNExtendedToken token, InitATNWillSubjFToHaveBeenConditionV3ObjTransOrFinNodeAction initAction)
        {
            mNumberOfConstructor = 2;
            mSameNode = sameNode;
            mToken = token;
            mInitAction = initAction;
        }

        private int mNumberOfConstructor;
        private ATNWillSubjFToHaveBeenConditionV3TransOrFinNode_v2 mParentNode;
        private ATNWillSubjFToHaveBeenConditionV3ObjTransOrFinNode_v2 mSameNode;
        private ATNExtendedToken mToken;
        private InitATNWillSubjFToHaveBeenConditionV3ObjTransOrFinNodeAction mInitAction;

        public override BaseATNNode_v2 Create(ContextOfATNParsing_v2 context)
        {
            switch(mNumberOfConstructor)
            {
                case 1:
                    return new ATNWillSubjFToHaveBeenConditionV3ObjTransOrFinNode_v2(context, mParentNode, mToken);

                case 2:
                    return new ATNWillSubjFToHaveBeenConditionV3ObjTransOrFinNode_v2(context, mSameNode, mInitAction, mToken);

                default:
                    throw new ArgumentOutOfRangeException(nameof(mNumberOfConstructor), mNumberOfConstructor, null);
            }
        }
    }

/*Sub states:
    Will_Subj_FToHave_Been_Condition_V3_Obj_Condition_Fin
*/

    public class ATNWillSubjFToHaveBeenConditionV3ObjTransOrFinNode_v2: BaseATNNode_v2
    {
        public ATNWillSubjFToHaveBeenConditionV3ObjTransOrFinNode_v2(ContextOfATNParsing_v2 context, ATNWillSubjFToHaveBeenConditionV3TransOrFinNode_v2 parentNode, ATNExtendedToken token)
            : base(context, token)
        {
            ParentNode = parentNode;
        }

        public ATNWillSubjFToHaveBeenConditionV3ObjTransOrFinNode_v2(ContextOfATNParsing_v2 context, ATNWillSubjFToHaveBeenConditionV3ObjTransOrFinNode_v2 sameNode, InitATNWillSubjFToHaveBeenConditionV3ObjTransOrFinNodeAction initAction, ATNExtendedToken token)
            : base(context, token)
        {
            mSameNode = sameNode;
            mInitAction = initAction;
            ParentNode = mSameNode.ParentNode;
            mInitAction?.Invoke(this);
        }

        public override StateOfATNParsing_v2 GlobalState => StateOfATNParsing_v2.Will_Subj_FToHave_Been_Condition_V3_Obj_TransOrFin;

        public ATNWillSubjFToHaveBeenConditionV3TransOrFinNode_v2 ParentNode { get; private set; }
        private ATNWillSubjFToHaveBeenConditionV3ObjTransOrFinNode_v2 mSameNode;
        private InitATNWillSubjFToHaveBeenConditionV3ObjTransOrFinNodeAction mInitAction;

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

