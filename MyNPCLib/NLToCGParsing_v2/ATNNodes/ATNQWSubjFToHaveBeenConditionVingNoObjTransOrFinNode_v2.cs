using MyNPCLib.NLToCGParsing;
using System;
using System.Collections.Generic;
using System.Text;

namespace MyNPCLib.NLToCGParsing_v2.ATNNodes
{
    public delegate void InitATNQWSubjFToHaveBeenConditionVingNoObjTransOrFinNodeAction(ATNQWSubjFToHaveBeenConditionVingNoObjTransOrFinNode_v2 item);

    public class ATNQWSubjFToHaveBeenConditionVingNoObjTransOrFinNodeFactory_v2: BaseATNNodeFactory_v2
    {
        public ATNQWSubjFToHaveBeenConditionVingNoObjTransOrFinNodeFactory_v2(ATNQWSubjFToHaveBeenConditionVingNoTransNode_v2 parentNode, ATNExtendedToken token)
        {
            mNumberOfConstructor = 1;
            mParentNode = parentNode;
            mToken = token;
        }

        public ATNQWSubjFToHaveBeenConditionVingNoObjTransOrFinNodeFactory_v2(ATNQWSubjFToHaveBeenConditionVingNoObjTransOrFinNode_v2 sameNode, ATNExtendedToken token, InitATNQWSubjFToHaveBeenConditionVingNoObjTransOrFinNodeAction initAction)
        {
            mNumberOfConstructor = 2;
            mSameNode = sameNode;
            mToken = token;
            mInitAction = initAction;
        }

        private int mNumberOfConstructor;
        private ATNQWSubjFToHaveBeenConditionVingNoTransNode_v2 mParentNode;
        private ATNQWSubjFToHaveBeenConditionVingNoObjTransOrFinNode_v2 mSameNode;
        private ATNExtendedToken mToken;
        private InitATNQWSubjFToHaveBeenConditionVingNoObjTransOrFinNodeAction mInitAction;

        public override BaseATNNode_v2 Create(ContextOfATNParsing_v2 context)
        {
            switch(mNumberOfConstructor)
            {
                case 1:
                    return new ATNQWSubjFToHaveBeenConditionVingNoObjTransOrFinNode_v2(context, mParentNode, mToken);

                case 2:
                    return new ATNQWSubjFToHaveBeenConditionVingNoObjTransOrFinNode_v2(context, mSameNode, mInitAction, mToken);

                default:
                    throw new ArgumentOutOfRangeException(nameof(mNumberOfConstructor), mNumberOfConstructor, null);
            }
        }
    }

/*Sub states:
    QWSubj_FToHave_Been_Condition_Ving_No_Obj_Condition_Fin
*/

    public class ATNQWSubjFToHaveBeenConditionVingNoObjTransOrFinNode_v2: BaseATNNode_v2
    {
        public ATNQWSubjFToHaveBeenConditionVingNoObjTransOrFinNode_v2(ContextOfATNParsing_v2 context, ATNQWSubjFToHaveBeenConditionVingNoTransNode_v2 parentNode, ATNExtendedToken token)
            : base(context, token)
        {
            ParentNode = parentNode;
        }

        public ATNQWSubjFToHaveBeenConditionVingNoObjTransOrFinNode_v2(ContextOfATNParsing_v2 context, ATNQWSubjFToHaveBeenConditionVingNoObjTransOrFinNode_v2 sameNode, InitATNQWSubjFToHaveBeenConditionVingNoObjTransOrFinNodeAction initAction, ATNExtendedToken token)
            : base(context, token)
        {
            mSameNode = sameNode;
            mInitAction = initAction;
            ParentNode = mSameNode.ParentNode;
            mInitAction?.Invoke(this);
        }

        public override StateOfATNParsing_v2 GlobalState => StateOfATNParsing_v2.QWSubj_FToHave_Been_Condition_Ving_No_Obj_TransOrFin;

        public ATNQWSubjFToHaveBeenConditionVingNoTransNode_v2 ParentNode { get; private set; }
        private ATNQWSubjFToHaveBeenConditionVingNoObjTransOrFinNode_v2 mSameNode;
        private InitATNQWSubjFToHaveBeenConditionVingNoObjTransOrFinNodeAction mInitAction;

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

