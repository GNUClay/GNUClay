using MyNPCLib.NLToCGParsing;
using System;
using System.Collections.Generic;
using System.Text;

namespace MyNPCLib.NLToCGParsing_v2.ATNNodes
{
    public delegate void InitATNSubjFToDoTransNodeAction(ATNSubjFToDoTransNode_v2 item);

    public class ATNSubjFToDoTransNodeFactory_v2: BaseATNNodeFactory_v2
    {
        public ATNSubjFToDoTransNodeFactory_v2(ATNSubjTransNode_v2 parentNode, ATNExtendedToken token)
        {
            mNumberOfConstructor = 1;
            mParentNode = parentNode;
            mToken = token;
        }

        public ATNSubjFToDoTransNodeFactory_v2(ATNSubjFToDoTransNode_v2 sameNode, ATNExtendedToken token, InitATNSubjFToDoTransNodeAction initAction)
        {
            mNumberOfConstructor = 2;
            mSameNode = sameNode;
            mToken = token;
            mInitAction = initAction;
        }

        private int mNumberOfConstructor;
        private ATNSubjTransNode_v2 mParentNode;
        private ATNSubjFToDoTransNode_v2 mSameNode;
        private ATNExtendedToken mToken;
        private InitATNSubjFToDoTransNodeAction mInitAction;

        public override BaseATNNode_v2 Create(ContextOfATNParsing_v2 context)
        {
            switch(mNumberOfConstructor)
            {
                case 1:
                    return new ATNSubjFToDoTransNode_v2(context, mParentNode, mToken);

                case 2:
                    return new ATNSubjFToDoTransNode_v2(context, mSameNode, mInitAction, mToken);

                default:
                    throw new ArgumentOutOfRangeException(nameof(mNumberOfConstructor), mNumberOfConstructor, null);
            }
        }
    }

/*Sub states:
    Subj_FToDo_Not_Trans
*/

    public class ATNSubjFToDoTransNode_v2: BaseATNNode_v2
    {
        public ATNSubjFToDoTransNode_v2(ContextOfATNParsing_v2 context, ATNSubjTransNode_v2 parentNode, ATNExtendedToken token)
            : base(context, token)
        {
            ParentNode = parentNode;
        }

        public ATNSubjFToDoTransNode_v2(ContextOfATNParsing_v2 context, ATNSubjFToDoTransNode_v2 sameNode, InitATNSubjFToDoTransNodeAction initAction, ATNExtendedToken token)
            : base(context, token)
        {
            mSameNode = sameNode;
            mInitAction = initAction;
            ParentNode = mSameNode.ParentNode;
            mInitAction?.Invoke(this);
        }

        public override StateOfATNParsing_v2 GlobalState => StateOfATNParsing_v2.Subj_FToDo_Trans;

        public ATNSubjTransNode_v2 ParentNode { get; private set; }
        private ATNSubjFToDoTransNode_v2 mSameNode;
        private InitATNSubjFToDoTransNodeAction mInitAction;

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

