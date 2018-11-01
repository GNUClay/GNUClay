using MyNPCLib.NLToCGParsing;
using System;
using System.Collections.Generic;
using System.Text;

namespace MyNPCLib.NLToCGParsing_v2.ATNNodes
{
    public delegate void InitATNQWSubjFToDoVerbNoTransNodeAction(ATNQWSubjFToDoVerbNoTransNode_v2 item);

    public class ATNQWSubjFToDoVerbNoTransNodeFactory_v2: BaseATNNodeFactory_v2
    {
        public ATNQWSubjFToDoVerbNoTransNodeFactory_v2(ATNQWSubjFToDoVerbTransOrFinNode_v2 parentNode, ATNExtendedToken token)
        {
            mNumberOfConstructor = 1;
            mParentNode = parentNode;
            mToken = token;
        }

        public ATNQWSubjFToDoVerbNoTransNodeFactory_v2(ATNQWSubjFToDoVerbNoTransNode_v2 sameNode, ATNExtendedToken token, InitATNQWSubjFToDoVerbNoTransNodeAction initAction)
        {
            mNumberOfConstructor = 2;
            mSameNode = sameNode;
            mToken = token;
            mInitAction = initAction;
        }

        private int mNumberOfConstructor;
        private ATNQWSubjFToDoVerbTransOrFinNode_v2 mParentNode;
        private ATNQWSubjFToDoVerbNoTransNode_v2 mSameNode;
        private ATNExtendedToken mToken;
        private InitATNQWSubjFToDoVerbNoTransNodeAction mInitAction;

        public override BaseATNNode_v2 Create(ContextOfATNParsing_v2 context)
        {
            switch(mNumberOfConstructor)
            {
                case 1:
                    return new ATNQWSubjFToDoVerbNoTransNode_v2(context, mParentNode, mToken);

                case 2:
                    return new ATNQWSubjFToDoVerbNoTransNode_v2(context, mSameNode, mInitAction, mToken);

                default:
                    throw new ArgumentOutOfRangeException(nameof(mNumberOfConstructor), mNumberOfConstructor, null);
            }
        }
    }

/*Sub states:
    QWSubj_FToDo_Verb_No_Obj_TransOrFin
*/

    public class ATNQWSubjFToDoVerbNoTransNode_v2: BaseATNNode_v2
    {
        public ATNQWSubjFToDoVerbNoTransNode_v2(ContextOfATNParsing_v2 context, ATNQWSubjFToDoVerbTransOrFinNode_v2 parentNode, ATNExtendedToken token)
            : base(context, token)
        {
            ParentNode = parentNode;
        }

        public ATNQWSubjFToDoVerbNoTransNode_v2(ContextOfATNParsing_v2 context, ATNQWSubjFToDoVerbNoTransNode_v2 sameNode, InitATNQWSubjFToDoVerbNoTransNodeAction initAction, ATNExtendedToken token)
            : base(context, token)
        {
            mSameNode = sameNode;
            mInitAction = initAction;
            ParentNode = mSameNode.ParentNode;
            mInitAction?.Invoke(this);
        }

        public override StateOfATNParsing_v2 GlobalState => StateOfATNParsing_v2.QWSubj_FToDo_Verb_No_Trans;

        public ATNQWSubjFToDoVerbTransOrFinNode_v2 ParentNode { get; private set; }
        private ATNQWSubjFToDoVerbNoTransNode_v2 mSameNode;
        private InitATNQWSubjFToDoVerbNoTransNodeAction mInitAction;

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

