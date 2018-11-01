using MyNPCLib.NLToCGParsing;
using System;
using System.Collections.Generic;
using System.Text;

namespace MyNPCLib.NLToCGParsing_v2.ATNNodes
{
    public delegate void InitATNFToDoSubjVerbNoTransNodeAction(ATNFToDoSubjVerbNoTransNode_v2 item);

    public class ATNFToDoSubjVerbNoTransNodeFactory_v2: BaseATNNodeFactory_v2
    {
        public ATNFToDoSubjVerbNoTransNodeFactory_v2(ATNFToDoSubjVerbTransOrFinNode_v2 parentNode, ATNExtendedToken token)
        {
            mNumberOfConstructor = 1;
            mParentNode = parentNode;
            mToken = token;
        }

        public ATNFToDoSubjVerbNoTransNodeFactory_v2(ATNFToDoSubjVerbNoTransNode_v2 sameNode, ATNExtendedToken token, InitATNFToDoSubjVerbNoTransNodeAction initAction)
        {
            mNumberOfConstructor = 2;
            mSameNode = sameNode;
            mToken = token;
            mInitAction = initAction;
        }

        private int mNumberOfConstructor;
        private ATNFToDoSubjVerbTransOrFinNode_v2 mParentNode;
        private ATNFToDoSubjVerbNoTransNode_v2 mSameNode;
        private ATNExtendedToken mToken;
        private InitATNFToDoSubjVerbNoTransNodeAction mInitAction;

        public override BaseATNNode_v2 Create(ContextOfATNParsing_v2 context)
        {
            switch(mNumberOfConstructor)
            {
                case 1:
                    return new ATNFToDoSubjVerbNoTransNode_v2(context, mParentNode, mToken);

                case 2:
                    return new ATNFToDoSubjVerbNoTransNode_v2(context, mSameNode, mInitAction, mToken);

                default:
                    throw new ArgumentOutOfRangeException(nameof(mNumberOfConstructor), mNumberOfConstructor, null);
            }
        }
    }

/*Sub states:
    FToDo_Subj_Verb_No_Obj_TransOrFin
*/

    public class ATNFToDoSubjVerbNoTransNode_v2: BaseATNNode_v2
    {
        public ATNFToDoSubjVerbNoTransNode_v2(ContextOfATNParsing_v2 context, ATNFToDoSubjVerbTransOrFinNode_v2 parentNode, ATNExtendedToken token)
            : base(context, token)
        {
            ParentNode = parentNode;
        }

        public ATNFToDoSubjVerbNoTransNode_v2(ContextOfATNParsing_v2 context, ATNFToDoSubjVerbNoTransNode_v2 sameNode, InitATNFToDoSubjVerbNoTransNodeAction initAction, ATNExtendedToken token)
            : base(context, token)
        {
            mSameNode = sameNode;
            mInitAction = initAction;
            ParentNode = mSameNode.ParentNode;
            mInitAction?.Invoke(this);
        }

        public override StateOfATNParsing_v2 GlobalState => StateOfATNParsing_v2.FToDo_Subj_Verb_No_Trans;

        public ATNFToDoSubjVerbTransOrFinNode_v2 ParentNode { get; private set; }
        private ATNFToDoSubjVerbNoTransNode_v2 mSameNode;
        private InitATNFToDoSubjVerbNoTransNodeAction mInitAction;

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

