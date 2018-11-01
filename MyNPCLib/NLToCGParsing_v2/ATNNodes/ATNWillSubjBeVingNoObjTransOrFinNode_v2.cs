using MyNPCLib.NLToCGParsing;
using System;
using System.Collections.Generic;
using System.Text;

namespace MyNPCLib.NLToCGParsing_v2.ATNNodes
{
    public delegate void InitATNWillSubjBeVingNoObjTransOrFinNodeAction(ATNWillSubjBeVingNoObjTransOrFinNode_v2 item);

    public class ATNWillSubjBeVingNoObjTransOrFinNodeFactory_v2: BaseATNNodeFactory_v2
    {
        public ATNWillSubjBeVingNoObjTransOrFinNodeFactory_v2(ATNWillSubjBeVingNoTransNode_v2 parentNode, ATNExtendedToken token)
        {
            mNumberOfConstructor = 1;
            mParentNode = parentNode;
            mToken = token;
        }

        public ATNWillSubjBeVingNoObjTransOrFinNodeFactory_v2(ATNWillSubjBeVingNoObjTransOrFinNode_v2 sameNode, ATNExtendedToken token, InitATNWillSubjBeVingNoObjTransOrFinNodeAction initAction)
        {
            mNumberOfConstructor = 2;
            mSameNode = sameNode;
            mToken = token;
            mInitAction = initAction;
        }

        private int mNumberOfConstructor;
        private ATNWillSubjBeVingNoTransNode_v2 mParentNode;
        private ATNWillSubjBeVingNoObjTransOrFinNode_v2 mSameNode;
        private ATNExtendedToken mToken;
        private InitATNWillSubjBeVingNoObjTransOrFinNodeAction mInitAction;

        public override BaseATNNode_v2 Create(ContextOfATNParsing_v2 context)
        {
            switch(mNumberOfConstructor)
            {
                case 1:
                    return new ATNWillSubjBeVingNoObjTransOrFinNode_v2(context, mParentNode, mToken);

                case 2:
                    return new ATNWillSubjBeVingNoObjTransOrFinNode_v2(context, mSameNode, mInitAction, mToken);

                default:
                    throw new ArgumentOutOfRangeException(nameof(mNumberOfConstructor), mNumberOfConstructor, null);
            }
        }
    }

/*Sub states:
    Will_Subj_Be_Ving_No_Obj_Condition_Fin
*/

    public class ATNWillSubjBeVingNoObjTransOrFinNode_v2: BaseATNNode_v2
    {
        public ATNWillSubjBeVingNoObjTransOrFinNode_v2(ContextOfATNParsing_v2 context, ATNWillSubjBeVingNoTransNode_v2 parentNode, ATNExtendedToken token)
            : base(context, token)
        {
            ParentNode = parentNode;
        }

        public ATNWillSubjBeVingNoObjTransOrFinNode_v2(ContextOfATNParsing_v2 context, ATNWillSubjBeVingNoObjTransOrFinNode_v2 sameNode, InitATNWillSubjBeVingNoObjTransOrFinNodeAction initAction, ATNExtendedToken token)
            : base(context, token)
        {
            mSameNode = sameNode;
            mInitAction = initAction;
            ParentNode = mSameNode.ParentNode;
            mInitAction?.Invoke(this);
        }

        public override StateOfATNParsing_v2 GlobalState => StateOfATNParsing_v2.Will_Subj_Be_Ving_No_Obj_TransOrFin;

        public ATNWillSubjBeVingNoTransNode_v2 ParentNode { get; private set; }
        private ATNWillSubjBeVingNoObjTransOrFinNode_v2 mSameNode;
        private InitATNWillSubjBeVingNoObjTransOrFinNodeAction mInitAction;

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

