using MyNPCLib.NLToCGParsing;
using System;
using System.Collections.Generic;
using System.Text;

namespace MyNPCLib.NLToCGParsing_v2.ATNNodes
{
    public delegate void InitATNConditionQWSubjWillBeConditionVingNoObjTransOrFinNodeAction(ATNConditionQWSubjWillBeConditionVingNoObjTransOrFinNode_v2 item);

    public class ATNConditionQWSubjWillBeConditionVingNoObjTransOrFinNodeFactory_v2: BaseATNNodeFactory_v2
    {
        public ATNConditionQWSubjWillBeConditionVingNoObjTransOrFinNodeFactory_v2(ATNConditionQWSubjWillBeConditionVingNoTransNode_v2 parentNode, ATNExtendedToken token)
        {
            mNumberOfConstructor = 1;
            mParentNode = parentNode;
            mToken = token;
        }

        public ATNConditionQWSubjWillBeConditionVingNoObjTransOrFinNodeFactory_v2(ATNConditionQWSubjWillBeConditionVingNoObjTransOrFinNode_v2 sameNode, ATNExtendedToken token, InitATNConditionQWSubjWillBeConditionVingNoObjTransOrFinNodeAction initAction)
        {
            mNumberOfConstructor = 2;
            mSameNode = sameNode;
            mToken = token;
            mInitAction = initAction;
        }

        private int mNumberOfConstructor;
        private ATNConditionQWSubjWillBeConditionVingNoTransNode_v2 mParentNode;
        private ATNConditionQWSubjWillBeConditionVingNoObjTransOrFinNode_v2 mSameNode;
        private ATNExtendedToken mToken;
        private InitATNConditionQWSubjWillBeConditionVingNoObjTransOrFinNodeAction mInitAction;

        public override BaseATNNode_v2 Create(ContextOfATNParsing_v2 context)
        {
            switch(mNumberOfConstructor)
            {
                case 1:
                    return new ATNConditionQWSubjWillBeConditionVingNoObjTransOrFinNode_v2(context, mParentNode, mToken);

                case 2:
                    return new ATNConditionQWSubjWillBeConditionVingNoObjTransOrFinNode_v2(context, mSameNode, mInitAction, mToken);

                default:
                    throw new ArgumentOutOfRangeException(nameof(mNumberOfConstructor), mNumberOfConstructor, null);
            }
        }
    }

/*Sub states:
    Condition_QWSubj_Will_Be_Condition_Ving_No_Obj_Condition_Fin
*/

    public class ATNConditionQWSubjWillBeConditionVingNoObjTransOrFinNode_v2: BaseATNNode_v2
    {
        public ATNConditionQWSubjWillBeConditionVingNoObjTransOrFinNode_v2(ContextOfATNParsing_v2 context, ATNConditionQWSubjWillBeConditionVingNoTransNode_v2 parentNode, ATNExtendedToken token)
            : base(context, token)
        {
            ParentNode = parentNode;
        }

        public ATNConditionQWSubjWillBeConditionVingNoObjTransOrFinNode_v2(ContextOfATNParsing_v2 context, ATNConditionQWSubjWillBeConditionVingNoObjTransOrFinNode_v2 sameNode, InitATNConditionQWSubjWillBeConditionVingNoObjTransOrFinNodeAction initAction, ATNExtendedToken token)
            : base(context, token)
        {
            mSameNode = sameNode;
            mInitAction = initAction;
            ParentNode = mSameNode.ParentNode;
            mInitAction?.Invoke(this);
        }

        public override StateOfATNParsing_v2 GlobalState => StateOfATNParsing_v2.Condition_QWSubj_Will_Be_Condition_Ving_No_Obj_TransOrFin;

        public ATNConditionQWSubjWillBeConditionVingNoTransNode_v2 ParentNode { get; private set; }
        private ATNConditionQWSubjWillBeConditionVingNoObjTransOrFinNode_v2 mSameNode;
        private InitATNConditionQWSubjWillBeConditionVingNoObjTransOrFinNodeAction mInitAction;

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

