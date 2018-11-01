using MyNPCLib.NLToCGParsing;
using System;
using System.Collections.Generic;
using System.Text;

namespace MyNPCLib.NLToCGParsing_v2.ATNNodes
{
    public delegate void InitATNConditionSubjFToHaveBeenConditionVingNoObjTransOrFinNodeAction(ATNConditionSubjFToHaveBeenConditionVingNoObjTransOrFinNode_v2 item);

    public class ATNConditionSubjFToHaveBeenConditionVingNoObjTransOrFinNodeFactory_v2: BaseATNNodeFactory_v2
    {
        public ATNConditionSubjFToHaveBeenConditionVingNoObjTransOrFinNodeFactory_v2(ATNConditionSubjFToHaveBeenConditionVingNoTransNode_v2 parentNode, ATNExtendedToken token)
        {
            mNumberOfConstructor = 1;
            mParentNode = parentNode;
            mToken = token;
        }

        public ATNConditionSubjFToHaveBeenConditionVingNoObjTransOrFinNodeFactory_v2(ATNConditionSubjFToHaveBeenConditionVingNoObjTransOrFinNode_v2 sameNode, ATNExtendedToken token, InitATNConditionSubjFToHaveBeenConditionVingNoObjTransOrFinNodeAction initAction)
        {
            mNumberOfConstructor = 2;
            mSameNode = sameNode;
            mToken = token;
            mInitAction = initAction;
        }

        private int mNumberOfConstructor;
        private ATNConditionSubjFToHaveBeenConditionVingNoTransNode_v2 mParentNode;
        private ATNConditionSubjFToHaveBeenConditionVingNoObjTransOrFinNode_v2 mSameNode;
        private ATNExtendedToken mToken;
        private InitATNConditionSubjFToHaveBeenConditionVingNoObjTransOrFinNodeAction mInitAction;

        public override BaseATNNode_v2 Create(ContextOfATNParsing_v2 context)
        {
            switch(mNumberOfConstructor)
            {
                case 1:
                    return new ATNConditionSubjFToHaveBeenConditionVingNoObjTransOrFinNode_v2(context, mParentNode, mToken);

                case 2:
                    return new ATNConditionSubjFToHaveBeenConditionVingNoObjTransOrFinNode_v2(context, mSameNode, mInitAction, mToken);

                default:
                    throw new ArgumentOutOfRangeException(nameof(mNumberOfConstructor), mNumberOfConstructor, null);
            }
        }
    }

/*Sub states:
    Condition_Subj_FToHave_Been_Condition_Ving_No_Obj_Condition_Fin
*/

    public class ATNConditionSubjFToHaveBeenConditionVingNoObjTransOrFinNode_v2: BaseATNNode_v2
    {
        public ATNConditionSubjFToHaveBeenConditionVingNoObjTransOrFinNode_v2(ContextOfATNParsing_v2 context, ATNConditionSubjFToHaveBeenConditionVingNoTransNode_v2 parentNode, ATNExtendedToken token)
            : base(context, token)
        {
            ParentNode = parentNode;
        }

        public ATNConditionSubjFToHaveBeenConditionVingNoObjTransOrFinNode_v2(ContextOfATNParsing_v2 context, ATNConditionSubjFToHaveBeenConditionVingNoObjTransOrFinNode_v2 sameNode, InitATNConditionSubjFToHaveBeenConditionVingNoObjTransOrFinNodeAction initAction, ATNExtendedToken token)
            : base(context, token)
        {
            mSameNode = sameNode;
            mInitAction = initAction;
            ParentNode = mSameNode.ParentNode;
            mInitAction?.Invoke(this);
        }

        public override StateOfATNParsing_v2 GlobalState => StateOfATNParsing_v2.Condition_Subj_FToHave_Been_Condition_Ving_No_Obj_TransOrFin;

        public ATNConditionSubjFToHaveBeenConditionVingNoTransNode_v2 ParentNode { get; private set; }
        private ATNConditionSubjFToHaveBeenConditionVingNoObjTransOrFinNode_v2 mSameNode;
        private InitATNConditionSubjFToHaveBeenConditionVingNoObjTransOrFinNodeAction mInitAction;

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

