using MyNPCLib.NLToCGParsing;
using System;
using System.Collections.Generic;
using System.Text;

namespace MyNPCLib.NLToCGParsing_v2.ATNNodes
{
    public delegate void InitATNFToDoSubjVerbTransOrFinNodeAction(ATNFToDoSubjVerbTransOrFinNode_v2 item);

    public class ATNFToDoSubjVerbTransOrFinNodeFactory_v2: BaseATNNodeFactory_v2
    {
        public ATNFToDoSubjVerbTransOrFinNodeFactory_v2(ATNFToDoSubjTransNode_v2 parentNode, ATNExtendedToken token)
        {
            mNumberOfConstructor = 1;
            mParentNode = parentNode;
            mToken = token;
        }

        public ATNFToDoSubjVerbTransOrFinNodeFactory_v2(ATNFToDoSubjVerbTransOrFinNode_v2 sameNode, ATNExtendedToken token, InitATNFToDoSubjVerbTransOrFinNodeAction initAction)
        {
            mNumberOfConstructor = 2;
            mSameNode = sameNode;
            mToken = token;
            mInitAction = initAction;
        }

        private int mNumberOfConstructor;
        private ATNFToDoSubjTransNode_v2 mParentNode;
        private ATNFToDoSubjVerbTransOrFinNode_v2 mSameNode;
        private ATNExtendedToken mToken;
        private InitATNFToDoSubjVerbTransOrFinNodeAction mInitAction;

        public override BaseATNNode_v2 Create(ContextOfATNParsing_v2 context)
        {
            switch(mNumberOfConstructor)
            {
                case 1:
                    return new ATNFToDoSubjVerbTransOrFinNode_v2(context, mParentNode, mToken);

                case 2:
                    return new ATNFToDoSubjVerbTransOrFinNode_v2(context, mSameNode, mInitAction, mToken);

                default:
                    throw new ArgumentOutOfRangeException(nameof(mNumberOfConstructor), mNumberOfConstructor, null);
            }
        }
    }

/*Sub states:
    FToDo_Subj_Verb_Obj_TransOrFin
    FToDo_Subj_Verb_No_Trans
    FToDo_Subj_Verb_Condition_Fin
*/

    public class ATNFToDoSubjVerbTransOrFinNode_v2: BaseATNNode_v2
    {
        public ATNFToDoSubjVerbTransOrFinNode_v2(ContextOfATNParsing_v2 context, ATNFToDoSubjTransNode_v2 parentNode, ATNExtendedToken token)
            : base(context, token)
        {
            ParentNode = parentNode;
        }

        public ATNFToDoSubjVerbTransOrFinNode_v2(ContextOfATNParsing_v2 context, ATNFToDoSubjVerbTransOrFinNode_v2 sameNode, InitATNFToDoSubjVerbTransOrFinNodeAction initAction, ATNExtendedToken token)
            : base(context, token)
        {
            mSameNode = sameNode;
            mInitAction = initAction;
            ParentNode = mSameNode.ParentNode;
            mInitAction?.Invoke(this);
        }

        public override StateOfATNParsing_v2 GlobalState => StateOfATNParsing_v2.FToDo_Subj_Verb_TransOrFin;

        public ATNFToDoSubjTransNode_v2 ParentNode { get; private set; }
        private ATNFToDoSubjVerbTransOrFinNode_v2 mSameNode;
        private InitATNFToDoSubjVerbTransOrFinNodeAction mInitAction;

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

