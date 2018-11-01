using MyNPCLib.NLToCGParsing;
using System;
using System.Collections.Generic;
using System.Text;

namespace MyNPCLib.NLToCGParsing_v2.ATNNodes
{
    public delegate void InitATNSubjWillBeVingObjTransOrFinNodeAction(ATNSubjWillBeVingObjTransOrFinNode_v2 item);

    public class ATNSubjWillBeVingObjTransOrFinNodeFactory_v2: BaseATNNodeFactory_v2
    {
        public ATNSubjWillBeVingObjTransOrFinNodeFactory_v2(ATNSubjWillBeVingTransOrFinNode_v2 parentNode, ATNExtendedToken token)
        {
            mNumberOfConstructor = 1;
            mParentNode = parentNode;
            mToken = token;
        }

        public ATNSubjWillBeVingObjTransOrFinNodeFactory_v2(ATNSubjWillBeVingObjTransOrFinNode_v2 sameNode, ATNExtendedToken token, InitATNSubjWillBeVingObjTransOrFinNodeAction initAction)
        {
            mNumberOfConstructor = 2;
            mSameNode = sameNode;
            mToken = token;
            mInitAction = initAction;
        }

        private int mNumberOfConstructor;
        private ATNSubjWillBeVingTransOrFinNode_v2 mParentNode;
        private ATNSubjWillBeVingObjTransOrFinNode_v2 mSameNode;
        private ATNExtendedToken mToken;
        private InitATNSubjWillBeVingObjTransOrFinNodeAction mInitAction;

        public override BaseATNNode_v2 Create(ContextOfATNParsing_v2 context)
        {
            switch(mNumberOfConstructor)
            {
                case 1:
                    return new ATNSubjWillBeVingObjTransOrFinNode_v2(context, mParentNode, mToken);

                case 2:
                    return new ATNSubjWillBeVingObjTransOrFinNode_v2(context, mSameNode, mInitAction, mToken);

                default:
                    throw new ArgumentOutOfRangeException(nameof(mNumberOfConstructor), mNumberOfConstructor, null);
            }
        }
    }

/*Sub states:
    Subj_Will_Be_Ving_Obj_Condition_Fin
*/

    public class ATNSubjWillBeVingObjTransOrFinNode_v2: BaseATNNode_v2
    {
        public ATNSubjWillBeVingObjTransOrFinNode_v2(ContextOfATNParsing_v2 context, ATNSubjWillBeVingTransOrFinNode_v2 parentNode, ATNExtendedToken token)
            : base(context, token)
        {
            ParentNode = parentNode;
        }

        public ATNSubjWillBeVingObjTransOrFinNode_v2(ContextOfATNParsing_v2 context, ATNSubjWillBeVingObjTransOrFinNode_v2 sameNode, InitATNSubjWillBeVingObjTransOrFinNodeAction initAction, ATNExtendedToken token)
            : base(context, token)
        {
            mSameNode = sameNode;
            mInitAction = initAction;
            ParentNode = mSameNode.ParentNode;
            mInitAction?.Invoke(this);
        }

        public override StateOfATNParsing_v2 GlobalState => StateOfATNParsing_v2.Subj_Will_Be_Ving_Obj_TransOrFin;

        public ATNSubjWillBeVingTransOrFinNode_v2 ParentNode { get; private set; }
        private ATNSubjWillBeVingObjTransOrFinNode_v2 mSameNode;
        private InitATNSubjWillBeVingObjTransOrFinNodeAction mInitAction;

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

