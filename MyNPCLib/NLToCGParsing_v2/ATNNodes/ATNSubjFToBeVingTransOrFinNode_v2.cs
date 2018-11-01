using MyNPCLib.NLToCGParsing;
using System;
using System.Collections.Generic;
using System.Text;

namespace MyNPCLib.NLToCGParsing_v2.ATNNodes
{
    public delegate void InitATNSubjFToBeVingTransOrFinNodeAction(ATNSubjFToBeVingTransOrFinNode_v2 item);

    public class ATNSubjFToBeVingTransOrFinNodeFactory_v2: BaseATNNodeFactory_v2
    {
        public ATNSubjFToBeVingTransOrFinNodeFactory_v2(ATNSubjFToBeTransNode_v2 parentNode, ATNExtendedToken token)
        {
            mNumberOfConstructor = 1;
            mParentNode = parentNode;
            mToken = token;
        }

        public ATNSubjFToBeVingTransOrFinNodeFactory_v2(ATNSubjFToBeVingTransOrFinNode_v2 sameNode, ATNExtendedToken token, InitATNSubjFToBeVingTransOrFinNodeAction initAction)
        {
            mNumberOfConstructor = 2;
            mSameNode = sameNode;
            mToken = token;
            mInitAction = initAction;
        }

        private int mNumberOfConstructor;
        private ATNSubjFToBeTransNode_v2 mParentNode;
        private ATNSubjFToBeVingTransOrFinNode_v2 mSameNode;
        private ATNExtendedToken mToken;
        private InitATNSubjFToBeVingTransOrFinNodeAction mInitAction;

        public override BaseATNNode_v2 Create(ContextOfATNParsing_v2 context)
        {
            switch(mNumberOfConstructor)
            {
                case 1:
                    return new ATNSubjFToBeVingTransOrFinNode_v2(context, mParentNode, mToken);

                case 2:
                    return new ATNSubjFToBeVingTransOrFinNode_v2(context, mSameNode, mInitAction, mToken);

                default:
                    throw new ArgumentOutOfRangeException(nameof(mNumberOfConstructor), mNumberOfConstructor, null);
            }
        }
    }

/*Sub states:
    Subj_FToBe_Ving_Obj_TransOrFin
    Subj_FToBe_Ving_No_Trans
    Subj_FToBe_Ving_Condition_Fin
*/

    public class ATNSubjFToBeVingTransOrFinNode_v2: BaseATNNode_v2
    {
        public ATNSubjFToBeVingTransOrFinNode_v2(ContextOfATNParsing_v2 context, ATNSubjFToBeTransNode_v2 parentNode, ATNExtendedToken token)
            : base(context, token)
        {
            ParentNode = parentNode;
        }

        public ATNSubjFToBeVingTransOrFinNode_v2(ContextOfATNParsing_v2 context, ATNSubjFToBeVingTransOrFinNode_v2 sameNode, InitATNSubjFToBeVingTransOrFinNodeAction initAction, ATNExtendedToken token)
            : base(context, token)
        {
            mSameNode = sameNode;
            mInitAction = initAction;
            ParentNode = mSameNode.ParentNode;
            mInitAction?.Invoke(this);
        }

        public override StateOfATNParsing_v2 GlobalState => StateOfATNParsing_v2.Subj_FToBe_Ving_TransOrFin;

        public ATNSubjFToBeTransNode_v2 ParentNode { get; private set; }
        private ATNSubjFToBeVingTransOrFinNode_v2 mSameNode;
        private InitATNSubjFToBeVingTransOrFinNodeAction mInitAction;

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

