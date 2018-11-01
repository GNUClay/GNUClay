using MyNPCLib.NLToCGParsing;
using System;
using System.Collections.Generic;
using System.Text;

namespace MyNPCLib.NLToCGParsing_v2.ATNNodes
{
    public delegate void InitATNSubjFToBeVingObjTransOrFinNodeAction(ATNSubjFToBeVingObjTransOrFinNode_v2 item);

    public class ATNSubjFToBeVingObjTransOrFinNodeFactory_v2: BaseATNNodeFactory_v2
    {
        public ATNSubjFToBeVingObjTransOrFinNodeFactory_v2(ATNSubjFToBeVingTransOrFinNode_v2 parentNode, ATNExtendedToken token)
        {
            mNumberOfConstructor = 1;
            mParentNode = parentNode;
            mToken = token;
        }

        public ATNSubjFToBeVingObjTransOrFinNodeFactory_v2(ATNSubjFToBeVingObjTransOrFinNode_v2 sameNode, ATNExtendedToken token, InitATNSubjFToBeVingObjTransOrFinNodeAction initAction)
        {
            mNumberOfConstructor = 2;
            mSameNode = sameNode;
            mToken = token;
            mInitAction = initAction;
        }

        private int mNumberOfConstructor;
        private ATNSubjFToBeVingTransOrFinNode_v2 mParentNode;
        private ATNSubjFToBeVingObjTransOrFinNode_v2 mSameNode;
        private ATNExtendedToken mToken;
        private InitATNSubjFToBeVingObjTransOrFinNodeAction mInitAction;

        public override BaseATNNode_v2 Create(ContextOfATNParsing_v2 context)
        {
            switch(mNumberOfConstructor)
            {
                case 1:
                    return new ATNSubjFToBeVingObjTransOrFinNode_v2(context, mParentNode, mToken);

                case 2:
                    return new ATNSubjFToBeVingObjTransOrFinNode_v2(context, mSameNode, mInitAction, mToken);

                default:
                    throw new ArgumentOutOfRangeException(nameof(mNumberOfConstructor), mNumberOfConstructor, null);
            }
        }
    }

/*Sub states:
    Subj_FToBe_Ving_Obj_Condition_Fin
*/

    public class ATNSubjFToBeVingObjTransOrFinNode_v2: BaseATNNode_v2
    {
        public ATNSubjFToBeVingObjTransOrFinNode_v2(ContextOfATNParsing_v2 context, ATNSubjFToBeVingTransOrFinNode_v2 parentNode, ATNExtendedToken token)
            : base(context, token)
        {
            ParentNode = parentNode;
        }

        public ATNSubjFToBeVingObjTransOrFinNode_v2(ContextOfATNParsing_v2 context, ATNSubjFToBeVingObjTransOrFinNode_v2 sameNode, InitATNSubjFToBeVingObjTransOrFinNodeAction initAction, ATNExtendedToken token)
            : base(context, token)
        {
            mSameNode = sameNode;
            mInitAction = initAction;
            ParentNode = mSameNode.ParentNode;
            mInitAction?.Invoke(this);
        }

        public override StateOfATNParsing_v2 GlobalState => StateOfATNParsing_v2.Subj_FToBe_Ving_Obj_TransOrFin;

        public ATNSubjFToBeVingTransOrFinNode_v2 ParentNode { get; private set; }
        private ATNSubjFToBeVingObjTransOrFinNode_v2 mSameNode;
        private InitATNSubjFToBeVingObjTransOrFinNodeAction mInitAction;

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

