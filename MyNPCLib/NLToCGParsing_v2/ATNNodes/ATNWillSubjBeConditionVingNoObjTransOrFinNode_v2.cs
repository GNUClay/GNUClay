using MyNPCLib.NLToCGParsing;
using System;
using System.Collections.Generic;
using System.Text;

namespace MyNPCLib.NLToCGParsing_v2.ATNNodes
{
    public delegate void InitATNWillSubjBeConditionVingNoObjTransOrFinNodeAction(ATNWillSubjBeConditionVingNoObjTransOrFinNode_v2 item);

    public class ATNWillSubjBeConditionVingNoObjTransOrFinNodeFactory_v2: BaseATNNodeFactory_v2
    {
        public ATNWillSubjBeConditionVingNoObjTransOrFinNodeFactory_v2(ATNWillSubjBeConditionVingNoTransNode_v2 parentNode, ATNExtendedToken token)
        {
            mNumberOfConstructor = 1;
            mParentNode = parentNode;
            mToken = token;
        }

        public ATNWillSubjBeConditionVingNoObjTransOrFinNodeFactory_v2(ATNWillSubjBeConditionVingNoObjTransOrFinNode_v2 sameNode, ATNExtendedToken token, InitATNWillSubjBeConditionVingNoObjTransOrFinNodeAction initAction)
        {
            mNumberOfConstructor = 2;
            mSameNode = sameNode;
            mToken = token;
            mInitAction = initAction;
        }

        private int mNumberOfConstructor;
        private ATNWillSubjBeConditionVingNoTransNode_v2 mParentNode;
        private ATNWillSubjBeConditionVingNoObjTransOrFinNode_v2 mSameNode;
        private ATNExtendedToken mToken;
        private InitATNWillSubjBeConditionVingNoObjTransOrFinNodeAction mInitAction;

        public override BaseATNNode_v2 Create(ContextOfATNParsing_v2 context)
        {
            switch(mNumberOfConstructor)
            {
                case 1:
                    return new ATNWillSubjBeConditionVingNoObjTransOrFinNode_v2(context, mParentNode, mToken);

                case 2:
                    return new ATNWillSubjBeConditionVingNoObjTransOrFinNode_v2(context, mSameNode, mInitAction, mToken);

                default:
                    throw new ArgumentOutOfRangeException(nameof(mNumberOfConstructor), mNumberOfConstructor, null);
            }
        }
    }

/*Sub states:
    Will_Subj_Be_Condition_Ving_No_Obj_Condition_Fin
*/

    public class ATNWillSubjBeConditionVingNoObjTransOrFinNode_v2: BaseATNNode_v2
    {
        public ATNWillSubjBeConditionVingNoObjTransOrFinNode_v2(ContextOfATNParsing_v2 context, ATNWillSubjBeConditionVingNoTransNode_v2 parentNode, ATNExtendedToken token)
            : base(context, token)
        {
            ParentNode = parentNode;
        }

        public ATNWillSubjBeConditionVingNoObjTransOrFinNode_v2(ContextOfATNParsing_v2 context, ATNWillSubjBeConditionVingNoObjTransOrFinNode_v2 sameNode, InitATNWillSubjBeConditionVingNoObjTransOrFinNodeAction initAction, ATNExtendedToken token)
            : base(context, token)
        {
            mSameNode = sameNode;
            mInitAction = initAction;
            ParentNode = mSameNode.ParentNode;
            mInitAction?.Invoke(this);
        }

        public override StateOfATNParsing_v2 GlobalState => StateOfATNParsing_v2.Will_Subj_Be_Condition_Ving_No_Obj_TransOrFin;

        public ATNWillSubjBeConditionVingNoTransNode_v2 ParentNode { get; private set; }
        private ATNWillSubjBeConditionVingNoObjTransOrFinNode_v2 mSameNode;
        private InitATNWillSubjBeConditionVingNoObjTransOrFinNodeAction mInitAction;

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

