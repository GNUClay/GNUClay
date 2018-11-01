using MyNPCLib.NLToCGParsing;
using System;
using System.Collections.Generic;
using System.Text;

namespace MyNPCLib.NLToCGParsing_v2.ATNNodes
{
    public delegate void InitATNQWSubjWillBeConditionVingNoObjTransOrFinNodeAction(ATNQWSubjWillBeConditionVingNoObjTransOrFinNode_v2 item);

    public class ATNQWSubjWillBeConditionVingNoObjTransOrFinNodeFactory_v2: BaseATNNodeFactory_v2
    {
        public ATNQWSubjWillBeConditionVingNoObjTransOrFinNodeFactory_v2(ATNQWSubjWillBeConditionVingNoTransNode_v2 parentNode, ATNExtendedToken token)
        {
            mNumberOfConstructor = 1;
            mParentNode = parentNode;
            mToken = token;
        }

        public ATNQWSubjWillBeConditionVingNoObjTransOrFinNodeFactory_v2(ATNQWSubjWillBeConditionVingNoObjTransOrFinNode_v2 sameNode, ATNExtendedToken token, InitATNQWSubjWillBeConditionVingNoObjTransOrFinNodeAction initAction)
        {
            mNumberOfConstructor = 2;
            mSameNode = sameNode;
            mToken = token;
            mInitAction = initAction;
        }

        private int mNumberOfConstructor;
        private ATNQWSubjWillBeConditionVingNoTransNode_v2 mParentNode;
        private ATNQWSubjWillBeConditionVingNoObjTransOrFinNode_v2 mSameNode;
        private ATNExtendedToken mToken;
        private InitATNQWSubjWillBeConditionVingNoObjTransOrFinNodeAction mInitAction;

        public override BaseATNNode_v2 Create(ContextOfATNParsing_v2 context)
        {
            switch(mNumberOfConstructor)
            {
                case 1:
                    return new ATNQWSubjWillBeConditionVingNoObjTransOrFinNode_v2(context, mParentNode, mToken);

                case 2:
                    return new ATNQWSubjWillBeConditionVingNoObjTransOrFinNode_v2(context, mSameNode, mInitAction, mToken);

                default:
                    throw new ArgumentOutOfRangeException(nameof(mNumberOfConstructor), mNumberOfConstructor, null);
            }
        }
    }

/*Sub states:
    QWSubj_Will_Be_Condition_Ving_No_Obj_Condition_Fin
*/

    public class ATNQWSubjWillBeConditionVingNoObjTransOrFinNode_v2: BaseATNNode_v2
    {
        public ATNQWSubjWillBeConditionVingNoObjTransOrFinNode_v2(ContextOfATNParsing_v2 context, ATNQWSubjWillBeConditionVingNoTransNode_v2 parentNode, ATNExtendedToken token)
            : base(context, token)
        {
            ParentNode = parentNode;
        }

        public ATNQWSubjWillBeConditionVingNoObjTransOrFinNode_v2(ContextOfATNParsing_v2 context, ATNQWSubjWillBeConditionVingNoObjTransOrFinNode_v2 sameNode, InitATNQWSubjWillBeConditionVingNoObjTransOrFinNodeAction initAction, ATNExtendedToken token)
            : base(context, token)
        {
            mSameNode = sameNode;
            mInitAction = initAction;
            ParentNode = mSameNode.ParentNode;
            mInitAction?.Invoke(this);
        }

        public override StateOfATNParsing_v2 GlobalState => StateOfATNParsing_v2.QWSubj_Will_Be_Condition_Ving_No_Obj_TransOrFin;

        public ATNQWSubjWillBeConditionVingNoTransNode_v2 ParentNode { get; private set; }
        private ATNQWSubjWillBeConditionVingNoObjTransOrFinNode_v2 mSameNode;
        private InitATNQWSubjWillBeConditionVingNoObjTransOrFinNodeAction mInitAction;

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

