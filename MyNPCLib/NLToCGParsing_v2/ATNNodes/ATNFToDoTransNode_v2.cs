using MyNPCLib.NLToCGParsing;
using System;
using System.Collections.Generic;
using System.Text;

namespace MyNPCLib.NLToCGParsing_v2.ATNNodes
{
    public delegate void InitATNFToDoTransNodeAction(ATNFToDoTransNode_v2 item);

    public class ATNFToDoTransNodeFactory_v2: BaseATNNodeFactory_v2
    {
        public ATNFToDoTransNodeFactory_v2(ATNInitNode_v2 parentNode, ATNExtendedToken token)
        {
            mNumberOfConstructor = 1;
            mParentNode = parentNode;
            mToken = token;
        }

        public ATNFToDoTransNodeFactory_v2(ATNFToDoTransNode_v2 sameNode, ATNExtendedToken token, InitATNFToDoTransNodeAction initAction)
        {
            mNumberOfConstructor = 2;
            mSameNode = sameNode;
            mToken = token;
            mInitAction = initAction;
        }

        private int mNumberOfConstructor;
        private ATNInitNode_v2 mParentNode;
        private ATNFToDoTransNode_v2 mSameNode;
        private ATNExtendedToken mToken;
        private InitATNFToDoTransNodeAction mInitAction;

        public override BaseATNNode_v2 Create(ContextOfATNParsing_v2 context)
        {
            switch(mNumberOfConstructor)
            {
                case 1:
                    return new ATNFToDoTransNode_v2(context, mParentNode, mToken);

                case 2:
                    return new ATNFToDoTransNode_v2(context, mSameNode, mInitAction, mToken);

                default:
                    throw new ArgumentOutOfRangeException(nameof(mNumberOfConstructor), mNumberOfConstructor, null);
            }
        }
    }

/*Sub states:
    FToDo_Subj_Trans
    FToDo_Not_Trans
*/

    public class ATNFToDoTransNode_v2: BaseATNNode_v2
    {
        public ATNFToDoTransNode_v2(ContextOfATNParsing_v2 context, ATNInitNode_v2 parentNode, ATNExtendedToken token)
            : base(context, token)
        {
            ParentNode = parentNode;
        }

        public ATNFToDoTransNode_v2(ContextOfATNParsing_v2 context, ATNFToDoTransNode_v2 sameNode, InitATNFToDoTransNodeAction initAction, ATNExtendedToken token)
            : base(context, token)
        {
            mSameNode = sameNode;
            mInitAction = initAction;
            ParentNode = mSameNode.ParentNode;
            mInitAction?.Invoke(this);
        }

        public override StateOfATNParsing_v2 GlobalState => StateOfATNParsing_v2.FToDo_Trans;

        public ATNInitNode_v2 ParentNode { get; private set; }
        private ATNFToDoTransNode_v2 mSameNode;
        private InitATNFToDoTransNodeAction mInitAction;

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

