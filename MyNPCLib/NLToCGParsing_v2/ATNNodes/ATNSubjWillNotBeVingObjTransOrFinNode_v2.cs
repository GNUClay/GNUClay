using MyNPCLib.NLToCGParsing;
using System;
using System.Collections.Generic;
using System.Text;

namespace MyNPCLib.NLToCGParsing_v2.ATNNodes
{
    public delegate void InitATNSubjWillNotBeVingObjTransOrFinNodeAction(ATNSubjWillNotBeVingObjTransOrFinNode_v2 item);

    public class ATNSubjWillNotBeVingObjTransOrFinNodeFactory_v2: BaseATNNodeFactory_v2
    {
        public ATNSubjWillNotBeVingObjTransOrFinNodeFactory_v2(ATNSubjWillNotBeVingTransOrFinNode_v2 parentNode, ATNExtendedToken token)
        {
            mNumberOfConstructor = 1;
            mParentNode = parentNode;
            mToken = token;
        }

        public ATNSubjWillNotBeVingObjTransOrFinNodeFactory_v2(ATNSubjWillNotBeVingObjTransOrFinNode_v2 sameNode, ATNExtendedToken token, InitATNSubjWillNotBeVingObjTransOrFinNodeAction initAction)
        {
            mNumberOfConstructor = 2;
            mSameNode = sameNode;
            mToken = token;
            mInitAction = initAction;
        }

        private int mNumberOfConstructor;
        private ATNSubjWillNotBeVingTransOrFinNode_v2 mParentNode;
        private ATNSubjWillNotBeVingObjTransOrFinNode_v2 mSameNode;
        private ATNExtendedToken mToken;
        private InitATNSubjWillNotBeVingObjTransOrFinNodeAction mInitAction;

        public override BaseATNNode_v2 Create(ContextOfATNParsing_v2 context)
        {
            switch(mNumberOfConstructor)
            {
                case 1:
                    return new ATNSubjWillNotBeVingObjTransOrFinNode_v2(context, mParentNode, mToken);

                case 2:
                    return new ATNSubjWillNotBeVingObjTransOrFinNode_v2(context, mSameNode, mInitAction, mToken);

                default:
                    throw new ArgumentOutOfRangeException(nameof(mNumberOfConstructor), mNumberOfConstructor, null);
            }
        }
    }

/*Sub states:
    Subj_Will_Not_Be_Ving_Obj_Condition_Fin
*/

    public class ATNSubjWillNotBeVingObjTransOrFinNode_v2: BaseATNNode_v2
    {
        public ATNSubjWillNotBeVingObjTransOrFinNode_v2(ContextOfATNParsing_v2 context, ATNSubjWillNotBeVingTransOrFinNode_v2 parentNode, ATNExtendedToken token)
            : base(context, token)
        {
            ParentNode = parentNode;
        }

        public ATNSubjWillNotBeVingObjTransOrFinNode_v2(ContextOfATNParsing_v2 context, ATNSubjWillNotBeVingObjTransOrFinNode_v2 sameNode, InitATNSubjWillNotBeVingObjTransOrFinNodeAction initAction, ATNExtendedToken token)
            : base(context, token)
        {
            mSameNode = sameNode;
            mInitAction = initAction;
            ParentNode = mSameNode.ParentNode;
            mInitAction?.Invoke(this);
        }

        public override StateOfATNParsing_v2 GlobalState => StateOfATNParsing_v2.Subj_Will_Not_Be_Ving_Obj_TransOrFin;

        public ATNSubjWillNotBeVingTransOrFinNode_v2 ParentNode { get; private set; }
        private ATNSubjWillNotBeVingObjTransOrFinNode_v2 mSameNode;
        private InitATNSubjWillNotBeVingObjTransOrFinNodeAction mInitAction;

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

