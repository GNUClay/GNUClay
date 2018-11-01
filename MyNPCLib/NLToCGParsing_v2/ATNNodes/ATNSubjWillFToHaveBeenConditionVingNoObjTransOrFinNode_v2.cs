using MyNPCLib.NLToCGParsing;
using System;
using System.Collections.Generic;
using System.Text;

namespace MyNPCLib.NLToCGParsing_v2.ATNNodes
{
    public delegate void InitATNSubjWillFToHaveBeenConditionVingNoObjTransOrFinNodeAction(ATNSubjWillFToHaveBeenConditionVingNoObjTransOrFinNode_v2 item);

    public class ATNSubjWillFToHaveBeenConditionVingNoObjTransOrFinNodeFactory_v2: BaseATNNodeFactory_v2
    {
        public ATNSubjWillFToHaveBeenConditionVingNoObjTransOrFinNodeFactory_v2(ATNSubjWillFToHaveBeenConditionVingNoTransNode_v2 parentNode, ATNExtendedToken token)
        {
            mNumberOfConstructor = 1;
            mParentNode = parentNode;
            mToken = token;
        }

        public ATNSubjWillFToHaveBeenConditionVingNoObjTransOrFinNodeFactory_v2(ATNSubjWillFToHaveBeenConditionVingNoObjTransOrFinNode_v2 sameNode, ATNExtendedToken token, InitATNSubjWillFToHaveBeenConditionVingNoObjTransOrFinNodeAction initAction)
        {
            mNumberOfConstructor = 2;
            mSameNode = sameNode;
            mToken = token;
            mInitAction = initAction;
        }

        private int mNumberOfConstructor;
        private ATNSubjWillFToHaveBeenConditionVingNoTransNode_v2 mParentNode;
        private ATNSubjWillFToHaveBeenConditionVingNoObjTransOrFinNode_v2 mSameNode;
        private ATNExtendedToken mToken;
        private InitATNSubjWillFToHaveBeenConditionVingNoObjTransOrFinNodeAction mInitAction;

        public override BaseATNNode_v2 Create(ContextOfATNParsing_v2 context)
        {
            switch(mNumberOfConstructor)
            {
                case 1:
                    return new ATNSubjWillFToHaveBeenConditionVingNoObjTransOrFinNode_v2(context, mParentNode, mToken);

                case 2:
                    return new ATNSubjWillFToHaveBeenConditionVingNoObjTransOrFinNode_v2(context, mSameNode, mInitAction, mToken);

                default:
                    throw new ArgumentOutOfRangeException(nameof(mNumberOfConstructor), mNumberOfConstructor, null);
            }
        }
    }

/*Sub states:
    Subj_Will_FToHave_Been_Condition_Ving_No_Obj_Condition_Fin
*/

    public class ATNSubjWillFToHaveBeenConditionVingNoObjTransOrFinNode_v2: BaseATNNode_v2
    {
        public ATNSubjWillFToHaveBeenConditionVingNoObjTransOrFinNode_v2(ContextOfATNParsing_v2 context, ATNSubjWillFToHaveBeenConditionVingNoTransNode_v2 parentNode, ATNExtendedToken token)
            : base(context, token)
        {
            ParentNode = parentNode;
        }

        public ATNSubjWillFToHaveBeenConditionVingNoObjTransOrFinNode_v2(ContextOfATNParsing_v2 context, ATNSubjWillFToHaveBeenConditionVingNoObjTransOrFinNode_v2 sameNode, InitATNSubjWillFToHaveBeenConditionVingNoObjTransOrFinNodeAction initAction, ATNExtendedToken token)
            : base(context, token)
        {
            mSameNode = sameNode;
            mInitAction = initAction;
            ParentNode = mSameNode.ParentNode;
            mInitAction?.Invoke(this);
        }

        public override StateOfATNParsing_v2 GlobalState => StateOfATNParsing_v2.Subj_Will_FToHave_Been_Condition_Ving_No_Obj_TransOrFin;

        public ATNSubjWillFToHaveBeenConditionVingNoTransNode_v2 ParentNode { get; private set; }
        private ATNSubjWillFToHaveBeenConditionVingNoObjTransOrFinNode_v2 mSameNode;
        private InitATNSubjWillFToHaveBeenConditionVingNoObjTransOrFinNodeAction mInitAction;

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

