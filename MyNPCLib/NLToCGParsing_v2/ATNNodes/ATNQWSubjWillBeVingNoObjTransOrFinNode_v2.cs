using MyNPCLib.NLToCGParsing;
using System;
using System.Collections.Generic;
using System.Text;

namespace MyNPCLib.NLToCGParsing_v2.ATNNodes
{
    public delegate void InitATNQWSubjWillBeVingNoObjTransOrFinNodeAction(ATNQWSubjWillBeVingNoObjTransOrFinNode_v2 item);

    public class ATNQWSubjWillBeVingNoObjTransOrFinNodeFactory_v2: BaseATNNodeFactory_v2
    {
        public ATNQWSubjWillBeVingNoObjTransOrFinNodeFactory_v2(ATNQWSubjWillBeVingNoTransNode_v2 parentNode, ATNExtendedToken token)
        {
            mNumberOfConstructor = 1;
            mParentNode = parentNode;
            mToken = token;
        }

        public ATNQWSubjWillBeVingNoObjTransOrFinNodeFactory_v2(ATNQWSubjWillBeVingNoObjTransOrFinNode_v2 sameNode, ATNExtendedToken token, InitATNQWSubjWillBeVingNoObjTransOrFinNodeAction initAction)
        {
            mNumberOfConstructor = 2;
            mSameNode = sameNode;
            mToken = token;
            mInitAction = initAction;
        }

        private int mNumberOfConstructor;
        private ATNQWSubjWillBeVingNoTransNode_v2 mParentNode;
        private ATNQWSubjWillBeVingNoObjTransOrFinNode_v2 mSameNode;
        private ATNExtendedToken mToken;
        private InitATNQWSubjWillBeVingNoObjTransOrFinNodeAction mInitAction;

        public override BaseATNNode_v2 Create(ContextOfATNParsing_v2 context)
        {
            switch(mNumberOfConstructor)
            {
                case 1:
                    return new ATNQWSubjWillBeVingNoObjTransOrFinNode_v2(context, mParentNode, mToken);

                case 2:
                    return new ATNQWSubjWillBeVingNoObjTransOrFinNode_v2(context, mSameNode, mInitAction, mToken);

                default:
                    throw new ArgumentOutOfRangeException(nameof(mNumberOfConstructor), mNumberOfConstructor, null);
            }
        }
    }

/*Sub states:
    QWSubj_Will_Be_Ving_No_Obj_Condition_Fin
*/

    public class ATNQWSubjWillBeVingNoObjTransOrFinNode_v2: BaseATNNode_v2
    {
        public ATNQWSubjWillBeVingNoObjTransOrFinNode_v2(ContextOfATNParsing_v2 context, ATNQWSubjWillBeVingNoTransNode_v2 parentNode, ATNExtendedToken token)
            : base(context, token)
        {
            ParentNode = parentNode;
        }

        public ATNQWSubjWillBeVingNoObjTransOrFinNode_v2(ContextOfATNParsing_v2 context, ATNQWSubjWillBeVingNoObjTransOrFinNode_v2 sameNode, InitATNQWSubjWillBeVingNoObjTransOrFinNodeAction initAction, ATNExtendedToken token)
            : base(context, token)
        {
            mSameNode = sameNode;
            mInitAction = initAction;
            ParentNode = mSameNode.ParentNode;
            mInitAction?.Invoke(this);
        }

        public override StateOfATNParsing_v2 GlobalState => StateOfATNParsing_v2.QWSubj_Will_Be_Ving_No_Obj_TransOrFin;

        public ATNQWSubjWillBeVingNoTransNode_v2 ParentNode { get; private set; }
        private ATNQWSubjWillBeVingNoObjTransOrFinNode_v2 mSameNode;
        private InitATNQWSubjWillBeVingNoObjTransOrFinNodeAction mInitAction;

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

