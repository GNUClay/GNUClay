using MyNPCLib.NLToCGParsing;
using System;
using System.Collections.Generic;
using System.Text;

namespace MyNPCLib.NLToCGParsing_v2.ATNNodes
{
    public delegate void InitATNSubjWillBeVingNoObjTransOrFinNodeAction(ATNSubjWillBeVingNoObjTransOrFinNode_v2 item);

    public class ATNSubjWillBeVingNoObjTransOrFinNodeFactory_v2: BaseATNNodeFactory_v2
    {
        public ATNSubjWillBeVingNoObjTransOrFinNodeFactory_v2(ATNSubjWillBeVingNoTransNode_v2 parentNode, ATNExtendedToken token)
        {
            mNumberOfConstructor = 1;
            mParentNode = parentNode;
            mToken = token;
        }

        public ATNSubjWillBeVingNoObjTransOrFinNodeFactory_v2(ATNSubjWillBeVingNoObjTransOrFinNode_v2 sameNode, ATNExtendedToken token, InitATNSubjWillBeVingNoObjTransOrFinNodeAction initAction)
        {
            mNumberOfConstructor = 2;
            mSameNode = sameNode;
            mToken = token;
            mInitAction = initAction;
        }

        private int mNumberOfConstructor;
        private ATNSubjWillBeVingNoTransNode_v2 mParentNode;
        private ATNSubjWillBeVingNoObjTransOrFinNode_v2 mSameNode;
        private ATNExtendedToken mToken;
        private InitATNSubjWillBeVingNoObjTransOrFinNodeAction mInitAction;

        public override BaseATNNode_v2 Create(ContextOfATNParsing_v2 context)
        {
            switch(mNumberOfConstructor)
            {
                case 1:
                    return new ATNSubjWillBeVingNoObjTransOrFinNode_v2(context, mParentNode, mToken);

                case 2:
                    return new ATNSubjWillBeVingNoObjTransOrFinNode_v2(context, mSameNode, mInitAction, mToken);

                default:
                    throw new ArgumentOutOfRangeException(nameof(mNumberOfConstructor), mNumberOfConstructor, null);
            }
        }
    }

/*Sub states:
    Subj_Will_Be_Ving_No_Obj_Condition_Fin
*/

    public class ATNSubjWillBeVingNoObjTransOrFinNode_v2: BaseATNNode_v2
    {
        public ATNSubjWillBeVingNoObjTransOrFinNode_v2(ContextOfATNParsing_v2 context, ATNSubjWillBeVingNoTransNode_v2 parentNode, ATNExtendedToken token)
            : base(context, token)
        {
            ParentNode = parentNode;
        }

        public ATNSubjWillBeVingNoObjTransOrFinNode_v2(ContextOfATNParsing_v2 context, ATNSubjWillBeVingNoObjTransOrFinNode_v2 sameNode, InitATNSubjWillBeVingNoObjTransOrFinNodeAction initAction, ATNExtendedToken token)
            : base(context, token)
        {
            mSameNode = sameNode;
            mInitAction = initAction;
            ParentNode = mSameNode.ParentNode;
            mInitAction?.Invoke(this);
        }

        public override StateOfATNParsing_v2 GlobalState => StateOfATNParsing_v2.Subj_Will_Be_Ving_No_Obj_TransOrFin;

        public ATNSubjWillBeVingNoTransNode_v2 ParentNode { get; private set; }
        private ATNSubjWillBeVingNoObjTransOrFinNode_v2 mSameNode;
        private InitATNSubjWillBeVingNoObjTransOrFinNodeAction mInitAction;

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

