using MyNPCLib.NLToCGParsing;
using System;
using System.Collections.Generic;
using System.Text;

namespace MyNPCLib.NLToCGParsing_v2.ATNNodes
{
    public delegate void InitATNConditionSubjWillBeConditionVingNoObjTransOrFinNodeAction(ATNConditionSubjWillBeConditionVingNoObjTransOrFinNode_v2 item);

    public class ATNConditionSubjWillBeConditionVingNoObjTransOrFinNodeFactory_v2: BaseATNNodeFactory_v2
    {
        public ATNConditionSubjWillBeConditionVingNoObjTransOrFinNodeFactory_v2(ATNConditionSubjWillBeConditionVingNoTransNode_v2 parentNode, ATNExtendedToken token)
        {
            mNumberOfConstructor = 1;
            mParentNode = parentNode;
            mToken = token;
        }

        public ATNConditionSubjWillBeConditionVingNoObjTransOrFinNodeFactory_v2(ATNConditionSubjWillBeConditionVingNoObjTransOrFinNode_v2 sameNode, ATNExtendedToken token, InitATNConditionSubjWillBeConditionVingNoObjTransOrFinNodeAction initAction)
        {
            mNumberOfConstructor = 2;
            mSameNode = sameNode;
            mToken = token;
            mInitAction = initAction;
        }

        private int mNumberOfConstructor;
        private ATNConditionSubjWillBeConditionVingNoTransNode_v2 mParentNode;
        private ATNConditionSubjWillBeConditionVingNoObjTransOrFinNode_v2 mSameNode;
        private ATNExtendedToken mToken;
        private InitATNConditionSubjWillBeConditionVingNoObjTransOrFinNodeAction mInitAction;

        public override BaseATNNode_v2 Create(ContextOfATNParsing_v2 context)
        {
            switch(mNumberOfConstructor)
            {
                case 1:
                    return new ATNConditionSubjWillBeConditionVingNoObjTransOrFinNode_v2(context, mParentNode, mToken);

                case 2:
                    return new ATNConditionSubjWillBeConditionVingNoObjTransOrFinNode_v2(context, mSameNode, mInitAction, mToken);

                default:
                    throw new ArgumentOutOfRangeException(nameof(mNumberOfConstructor), mNumberOfConstructor, null);
            }
        }
    }

/*Sub states:
    Condition_Subj_Will_Be_Condition_Ving_No_Obj_Condition_Fin
*/

    public class ATNConditionSubjWillBeConditionVingNoObjTransOrFinNode_v2: BaseATNNode_v2
    {
        public ATNConditionSubjWillBeConditionVingNoObjTransOrFinNode_v2(ContextOfATNParsing_v2 context, ATNConditionSubjWillBeConditionVingNoTransNode_v2 parentNode, ATNExtendedToken token)
            : base(context, token)
        {
            ParentNode = parentNode;
        }

        public ATNConditionSubjWillBeConditionVingNoObjTransOrFinNode_v2(ContextOfATNParsing_v2 context, ATNConditionSubjWillBeConditionVingNoObjTransOrFinNode_v2 sameNode, InitATNConditionSubjWillBeConditionVingNoObjTransOrFinNodeAction initAction, ATNExtendedToken token)
            : base(context, token)
        {
            mSameNode = sameNode;
            mInitAction = initAction;
            ParentNode = mSameNode.ParentNode;
            mInitAction?.Invoke(this);
        }

        public override StateOfATNParsing_v2 GlobalState => StateOfATNParsing_v2.Condition_Subj_Will_Be_Condition_Ving_No_Obj_TransOrFin;

        public ATNConditionSubjWillBeConditionVingNoTransNode_v2 ParentNode { get; private set; }
        private ATNConditionSubjWillBeConditionVingNoObjTransOrFinNode_v2 mSameNode;
        private InitATNConditionSubjWillBeConditionVingNoObjTransOrFinNodeAction mInitAction;

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

