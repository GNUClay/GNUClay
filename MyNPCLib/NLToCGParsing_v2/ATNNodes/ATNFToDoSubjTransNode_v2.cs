using MyNPCLib.NLToCGParsing;
using System;
using System.Collections.Generic;
using System.Text;

namespace MyNPCLib.NLToCGParsing_v2.ATNNodes
{
    public delegate void InitATNFToDoSubjTransNodeAction(ATNFToDoSubjTransNode_v2 item);

    public class ATNFToDoSubjTransNodeFactory_v2: BaseATNNodeFactory_v2
    {
        public ATNFToDoSubjTransNodeFactory_v2(ATNFToDoTransNode_v2 parentNode, ATNExtendedToken token)
        {
            mNumberOfConstructor = 1;
            mParentNode = parentNode;
            mToken = token;
        }

        public ATNFToDoSubjTransNodeFactory_v2(ATNFToDoSubjTransNode_v2 sameNode, ATNExtendedToken token, InitATNFToDoSubjTransNodeAction initAction)
        {
            mNumberOfConstructor = 2;
            mSameNode = sameNode;
            mToken = token;
            mInitAction = initAction;
        }

        private int mNumberOfConstructor;
        private ATNFToDoTransNode_v2 mParentNode;
        private ATNFToDoSubjTransNode_v2 mSameNode;
        private ATNExtendedToken mToken;
        private InitATNFToDoSubjTransNodeAction mInitAction;

        public override BaseATNNode_v2 Create(ContextOfATNParsing_v2 context)
        {
            switch(mNumberOfConstructor)
            {
                case 1:
                    return new ATNFToDoSubjTransNode_v2(context, mParentNode, mToken);

                case 2:
                    return new ATNFToDoSubjTransNode_v2(context, mSameNode, mInitAction, mToken);

                default:
                    throw new ArgumentOutOfRangeException(nameof(mNumberOfConstructor), mNumberOfConstructor, null);
            }
        }
    }

/*Sub states:
    FToDo_Subj_Verb_TransOrFin
    FToDo_Subj_Condition_Trans
*/

    public class ATNFToDoSubjTransNode_v2: BaseATNNode_v2
    {
        public ATNFToDoSubjTransNode_v2(ContextOfATNParsing_v2 context, ATNFToDoTransNode_v2 parentNode, ATNExtendedToken token)
            : base(context, token)
        {
            ParentNode = parentNode;
        }

        public ATNFToDoSubjTransNode_v2(ContextOfATNParsing_v2 context, ATNFToDoSubjTransNode_v2 sameNode, InitATNFToDoSubjTransNodeAction initAction, ATNExtendedToken token)
            : base(context, token)
        {
            mSameNode = sameNode;
            mInitAction = initAction;
            ParentNode = mSameNode.ParentNode;
            mInitAction?.Invoke(this);
        }

        public override StateOfATNParsing_v2 GlobalState => StateOfATNParsing_v2.FToDo_Subj_Trans;

        public ATNFToDoTransNode_v2 ParentNode { get; private set; }
        private ATNFToDoSubjTransNode_v2 mSameNode;
        private InitATNFToDoSubjTransNodeAction mInitAction;

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

