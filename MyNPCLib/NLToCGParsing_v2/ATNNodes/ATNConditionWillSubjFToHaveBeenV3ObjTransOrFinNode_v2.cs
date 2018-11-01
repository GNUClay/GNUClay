using MyNPCLib.NLToCGParsing;
using System;
using System.Collections.Generic;
using System.Text;

namespace MyNPCLib.NLToCGParsing_v2.ATNNodes
{
    public delegate void InitATNConditionWillSubjFToHaveBeenV3ObjTransOrFinNodeAction(ATNConditionWillSubjFToHaveBeenV3ObjTransOrFinNode_v2 item);

    public class ATNConditionWillSubjFToHaveBeenV3ObjTransOrFinNodeFactory_v2: BaseATNNodeFactory_v2
    {
        public ATNConditionWillSubjFToHaveBeenV3ObjTransOrFinNodeFactory_v2(ATNConditionWillSubjFToHaveBeenV3TransOrFinNode_v2 parentNode, ATNExtendedToken token)
        {
            mNumberOfConstructor = 1;
            mParentNode = parentNode;
            mToken = token;
        }

        public ATNConditionWillSubjFToHaveBeenV3ObjTransOrFinNodeFactory_v2(ATNConditionWillSubjFToHaveBeenV3ObjTransOrFinNode_v2 sameNode, ATNExtendedToken token, InitATNConditionWillSubjFToHaveBeenV3ObjTransOrFinNodeAction initAction)
        {
            mNumberOfConstructor = 2;
            mSameNode = sameNode;
            mToken = token;
            mInitAction = initAction;
        }

        private int mNumberOfConstructor;
        private ATNConditionWillSubjFToHaveBeenV3TransOrFinNode_v2 mParentNode;
        private ATNConditionWillSubjFToHaveBeenV3ObjTransOrFinNode_v2 mSameNode;
        private ATNExtendedToken mToken;
        private InitATNConditionWillSubjFToHaveBeenV3ObjTransOrFinNodeAction mInitAction;

        public override BaseATNNode_v2 Create(ContextOfATNParsing_v2 context)
        {
            switch(mNumberOfConstructor)
            {
                case 1:
                    return new ATNConditionWillSubjFToHaveBeenV3ObjTransOrFinNode_v2(context, mParentNode, mToken);

                case 2:
                    return new ATNConditionWillSubjFToHaveBeenV3ObjTransOrFinNode_v2(context, mSameNode, mInitAction, mToken);

                default:
                    throw new ArgumentOutOfRangeException(nameof(mNumberOfConstructor), mNumberOfConstructor, null);
            }
        }
    }

/*Sub states:
    Condition_Will_Subj_FToHave_Been_V3_Obj_Condition_Fin
*/

    public class ATNConditionWillSubjFToHaveBeenV3ObjTransOrFinNode_v2: BaseATNNode_v2
    {
        public ATNConditionWillSubjFToHaveBeenV3ObjTransOrFinNode_v2(ContextOfATNParsing_v2 context, ATNConditionWillSubjFToHaveBeenV3TransOrFinNode_v2 parentNode, ATNExtendedToken token)
            : base(context, token)
        {
            ParentNode = parentNode;
        }

        public ATNConditionWillSubjFToHaveBeenV3ObjTransOrFinNode_v2(ContextOfATNParsing_v2 context, ATNConditionWillSubjFToHaveBeenV3ObjTransOrFinNode_v2 sameNode, InitATNConditionWillSubjFToHaveBeenV3ObjTransOrFinNodeAction initAction, ATNExtendedToken token)
            : base(context, token)
        {
            mSameNode = sameNode;
            mInitAction = initAction;
            ParentNode = mSameNode.ParentNode;
            mInitAction?.Invoke(this);
        }

        public override StateOfATNParsing_v2 GlobalState => StateOfATNParsing_v2.Condition_Will_Subj_FToHave_Been_V3_Obj_TransOrFin;

        public ATNConditionWillSubjFToHaveBeenV3TransOrFinNode_v2 ParentNode { get; private set; }
        private ATNConditionWillSubjFToHaveBeenV3ObjTransOrFinNode_v2 mSameNode;
        private InitATNConditionWillSubjFToHaveBeenV3ObjTransOrFinNodeAction mInitAction;

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

