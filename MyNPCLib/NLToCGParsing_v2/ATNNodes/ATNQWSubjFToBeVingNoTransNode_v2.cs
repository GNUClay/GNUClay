using MyNPCLib.NLToCGParsing;
using System;
using System.Collections.Generic;
using System.Text;

namespace MyNPCLib.NLToCGParsing_v2.ATNNodes
{
    public delegate void InitATNQWSubjFToBeVingNoTransNodeAction(ATNQWSubjFToBeVingNoTransNode_v2 item);

    public class ATNQWSubjFToBeVingNoTransNodeFactory_v2: BaseATNNodeFactory_v2
    {
        public ATNQWSubjFToBeVingNoTransNodeFactory_v2(ATNQWSubjFToBeVingTransOrFinNode_v2 parentNode, ATNExtendedToken token)
        {
            mNumberOfConstructor = 1;
            mParentNode = parentNode;
            mToken = token;
        }

        public ATNQWSubjFToBeVingNoTransNodeFactory_v2(ATNQWSubjFToBeVingNoTransNode_v2 sameNode, ATNExtendedToken token, InitATNQWSubjFToBeVingNoTransNodeAction initAction)
        {
            mNumberOfConstructor = 2;
            mSameNode = sameNode;
            mToken = token;
            mInitAction = initAction;
        }

        private int mNumberOfConstructor;
        private ATNQWSubjFToBeVingTransOrFinNode_v2 mParentNode;
        private ATNQWSubjFToBeVingNoTransNode_v2 mSameNode;
        private ATNExtendedToken mToken;
        private InitATNQWSubjFToBeVingNoTransNodeAction mInitAction;

        public override BaseATNNode_v2 Create(ContextOfATNParsing_v2 context)
        {
            switch(mNumberOfConstructor)
            {
                case 1:
                    return new ATNQWSubjFToBeVingNoTransNode_v2(context, mParentNode, mToken);

                case 2:
                    return new ATNQWSubjFToBeVingNoTransNode_v2(context, mSameNode, mInitAction, mToken);

                default:
                    throw new ArgumentOutOfRangeException(nameof(mNumberOfConstructor), mNumberOfConstructor, null);
            }
        }
    }

/*Sub states:
    QWSubj_FToBe_Ving_No_Obj_TransOrFin
*/

    public class ATNQWSubjFToBeVingNoTransNode_v2: BaseATNNode_v2
    {
        public ATNQWSubjFToBeVingNoTransNode_v2(ContextOfATNParsing_v2 context, ATNQWSubjFToBeVingTransOrFinNode_v2 parentNode, ATNExtendedToken token)
            : base(context, token)
        {
            ParentNode = parentNode;
        }

        public ATNQWSubjFToBeVingNoTransNode_v2(ContextOfATNParsing_v2 context, ATNQWSubjFToBeVingNoTransNode_v2 sameNode, InitATNQWSubjFToBeVingNoTransNodeAction initAction, ATNExtendedToken token)
            : base(context, token)
        {
            mSameNode = sameNode;
            mInitAction = initAction;
            ParentNode = mSameNode.ParentNode;
            mInitAction?.Invoke(this);
        }

        public override StateOfATNParsing_v2 GlobalState => StateOfATNParsing_v2.QWSubj_FToBe_Ving_No_Trans;

        public ATNQWSubjFToBeVingTransOrFinNode_v2 ParentNode { get; private set; }
        private ATNQWSubjFToBeVingNoTransNode_v2 mSameNode;
        private InitATNQWSubjFToBeVingNoTransNodeAction mInitAction;

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

