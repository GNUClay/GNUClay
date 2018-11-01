using MyNPCLib.NLToCGParsing;
using System;
using System.Collections.Generic;
using System.Text;

namespace MyNPCLib.NLToCGParsing_v2.ATNNodes
{
    public delegate void InitATNSubjWillBeConditionVingNoObjTransOrFinNodeAction(ATNSubjWillBeConditionVingNoObjTransOrFinNode_v2 item);

    public class ATNSubjWillBeConditionVingNoObjTransOrFinNodeFactory_v2: BaseATNNodeFactory_v2
    {
        public ATNSubjWillBeConditionVingNoObjTransOrFinNodeFactory_v2(ATNSubjWillBeConditionVingNoTransNode_v2 parentNode, ATNExtendedToken token)
        {
            mNumberOfConstructor = 1;
            mParentNode = parentNode;
            mToken = token;
        }

        public ATNSubjWillBeConditionVingNoObjTransOrFinNodeFactory_v2(ATNSubjWillBeConditionVingNoObjTransOrFinNode_v2 sameNode, ATNExtendedToken token, InitATNSubjWillBeConditionVingNoObjTransOrFinNodeAction initAction)
        {
            mNumberOfConstructor = 2;
            mSameNode = sameNode;
            mToken = token;
            mInitAction = initAction;
        }

        private int mNumberOfConstructor;
        private ATNSubjWillBeConditionVingNoTransNode_v2 mParentNode;
        private ATNSubjWillBeConditionVingNoObjTransOrFinNode_v2 mSameNode;
        private ATNExtendedToken mToken;
        private InitATNSubjWillBeConditionVingNoObjTransOrFinNodeAction mInitAction;

        public override BaseATNNode_v2 Create(ContextOfATNParsing_v2 context)
        {
            switch(mNumberOfConstructor)
            {
                case 1:
                    return new ATNSubjWillBeConditionVingNoObjTransOrFinNode_v2(context, mParentNode, mToken);

                case 2:
                    return new ATNSubjWillBeConditionVingNoObjTransOrFinNode_v2(context, mSameNode, mInitAction, mToken);

                default:
                    throw new ArgumentOutOfRangeException(nameof(mNumberOfConstructor), mNumberOfConstructor, null);
            }
        }
    }

/*Sub states:
    Subj_Will_Be_Condition_Ving_No_Obj_Condition_Fin
*/

    public class ATNSubjWillBeConditionVingNoObjTransOrFinNode_v2: BaseATNNode_v2
    {
        public ATNSubjWillBeConditionVingNoObjTransOrFinNode_v2(ContextOfATNParsing_v2 context, ATNSubjWillBeConditionVingNoTransNode_v2 parentNode, ATNExtendedToken token)
            : base(context, token)
        {
            ParentNode = parentNode;
        }

        public ATNSubjWillBeConditionVingNoObjTransOrFinNode_v2(ContextOfATNParsing_v2 context, ATNSubjWillBeConditionVingNoObjTransOrFinNode_v2 sameNode, InitATNSubjWillBeConditionVingNoObjTransOrFinNodeAction initAction, ATNExtendedToken token)
            : base(context, token)
        {
            mSameNode = sameNode;
            mInitAction = initAction;
            ParentNode = mSameNode.ParentNode;
            mInitAction?.Invoke(this);
        }

        public override StateOfATNParsing_v2 GlobalState => StateOfATNParsing_v2.Subj_Will_Be_Condition_Ving_No_Obj_TransOrFin;

        public ATNSubjWillBeConditionVingNoTransNode_v2 ParentNode { get; private set; }
        private ATNSubjWillBeConditionVingNoObjTransOrFinNode_v2 mSameNode;
        private InitATNSubjWillBeConditionVingNoObjTransOrFinNodeAction mInitAction;

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

