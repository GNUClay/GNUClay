using MyNPCLib.NLToCGParsing;
using System;
using System.Collections.Generic;
using System.Text;

namespace MyNPCLib.NLToCGParsing_v2.ATNNodes
{
    public delegate void InitATNQWSubjWillFToHaveBeenConditionVingNoObjTransOrFinNodeAction(ATNQWSubjWillFToHaveBeenConditionVingNoObjTransOrFinNode_v2 item);

    public class ATNQWSubjWillFToHaveBeenConditionVingNoObjTransOrFinNodeFactory_v2: BaseATNNodeFactory_v2
    {
        public ATNQWSubjWillFToHaveBeenConditionVingNoObjTransOrFinNodeFactory_v2(ATNQWSubjWillFToHaveBeenConditionVingNoTransNode_v2 parentNode, ATNExtendedToken token)
        {
            mNumberOfConstructor = 1;
            mParentNode = parentNode;
            mToken = token;
        }

        public ATNQWSubjWillFToHaveBeenConditionVingNoObjTransOrFinNodeFactory_v2(ATNQWSubjWillFToHaveBeenConditionVingNoObjTransOrFinNode_v2 sameNode, ATNExtendedToken token, InitATNQWSubjWillFToHaveBeenConditionVingNoObjTransOrFinNodeAction initAction)
        {
            mNumberOfConstructor = 2;
            mSameNode = sameNode;
            mToken = token;
            mInitAction = initAction;
        }

        private int mNumberOfConstructor;
        private ATNQWSubjWillFToHaveBeenConditionVingNoTransNode_v2 mParentNode;
        private ATNQWSubjWillFToHaveBeenConditionVingNoObjTransOrFinNode_v2 mSameNode;
        private ATNExtendedToken mToken;
        private InitATNQWSubjWillFToHaveBeenConditionVingNoObjTransOrFinNodeAction mInitAction;

        public override BaseATNNode_v2 Create(ContextOfATNParsing_v2 context)
        {
            switch(mNumberOfConstructor)
            {
                case 1:
                    return new ATNQWSubjWillFToHaveBeenConditionVingNoObjTransOrFinNode_v2(context, mParentNode, mToken);

                case 2:
                    return new ATNQWSubjWillFToHaveBeenConditionVingNoObjTransOrFinNode_v2(context, mSameNode, mInitAction, mToken);

                default:
                    throw new ArgumentOutOfRangeException(nameof(mNumberOfConstructor), mNumberOfConstructor, null);
            }
        }
    }

/*Sub states:
    QWSubj_Will_FToHave_Been_Condition_Ving_No_Obj_Condition_Fin
*/

    public class ATNQWSubjWillFToHaveBeenConditionVingNoObjTransOrFinNode_v2: BaseATNNode_v2
    {
        public ATNQWSubjWillFToHaveBeenConditionVingNoObjTransOrFinNode_v2(ContextOfATNParsing_v2 context, ATNQWSubjWillFToHaveBeenConditionVingNoTransNode_v2 parentNode, ATNExtendedToken token)
            : base(context, token)
        {
            ParentNode = parentNode;
        }

        public ATNQWSubjWillFToHaveBeenConditionVingNoObjTransOrFinNode_v2(ContextOfATNParsing_v2 context, ATNQWSubjWillFToHaveBeenConditionVingNoObjTransOrFinNode_v2 sameNode, InitATNQWSubjWillFToHaveBeenConditionVingNoObjTransOrFinNodeAction initAction, ATNExtendedToken token)
            : base(context, token)
        {
            mSameNode = sameNode;
            mInitAction = initAction;
            ParentNode = mSameNode.ParentNode;
            mInitAction?.Invoke(this);
        }

        public override StateOfATNParsing_v2 GlobalState => StateOfATNParsing_v2.QWSubj_Will_FToHave_Been_Condition_Ving_No_Obj_TransOrFin;

        public ATNQWSubjWillFToHaveBeenConditionVingNoTransNode_v2 ParentNode { get; private set; }
        private ATNQWSubjWillFToHaveBeenConditionVingNoObjTransOrFinNode_v2 mSameNode;
        private InitATNQWSubjWillFToHaveBeenConditionVingNoObjTransOrFinNodeAction mInitAction;

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

