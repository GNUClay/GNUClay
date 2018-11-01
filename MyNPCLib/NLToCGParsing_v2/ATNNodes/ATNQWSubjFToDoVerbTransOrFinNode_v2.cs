using MyNPCLib.NLToCGParsing;
using System;
using System.Collections.Generic;
using System.Text;

namespace MyNPCLib.NLToCGParsing_v2.ATNNodes
{
    public delegate void InitATNQWSubjFToDoVerbTransOrFinNodeAction(ATNQWSubjFToDoVerbTransOrFinNode_v2 item);

    public class ATNQWSubjFToDoVerbTransOrFinNodeFactory_v2: BaseATNNodeFactory_v2
    {
        public ATNQWSubjFToDoVerbTransOrFinNodeFactory_v2(ATNQWSubjFToDoTransNode_v2 parentNode, ATNExtendedToken token)
        {
            mNumberOfConstructor = 1;
            mParentNode = parentNode;
            mToken = token;
        }

        public ATNQWSubjFToDoVerbTransOrFinNodeFactory_v2(ATNQWSubjFToDoVerbTransOrFinNode_v2 sameNode, ATNExtendedToken token, InitATNQWSubjFToDoVerbTransOrFinNodeAction initAction)
        {
            mNumberOfConstructor = 2;
            mSameNode = sameNode;
            mToken = token;
            mInitAction = initAction;
        }

        private int mNumberOfConstructor;
        private ATNQWSubjFToDoTransNode_v2 mParentNode;
        private ATNQWSubjFToDoVerbTransOrFinNode_v2 mSameNode;
        private ATNExtendedToken mToken;
        private InitATNQWSubjFToDoVerbTransOrFinNodeAction mInitAction;

        public override BaseATNNode_v2 Create(ContextOfATNParsing_v2 context)
        {
            switch(mNumberOfConstructor)
            {
                case 1:
                    return new ATNQWSubjFToDoVerbTransOrFinNode_v2(context, mParentNode, mToken);

                case 2:
                    return new ATNQWSubjFToDoVerbTransOrFinNode_v2(context, mSameNode, mInitAction, mToken);

                default:
                    throw new ArgumentOutOfRangeException(nameof(mNumberOfConstructor), mNumberOfConstructor, null);
            }
        }
    }

/*Sub states:
    QWSubj_FToDo_Verb_Obj_TransOrFin
    QWSubj_FToDo_Verb_No_Trans
    QWSubj_FToDo_Verb_Condition_Fin
*/

    public class ATNQWSubjFToDoVerbTransOrFinNode_v2: BaseATNNode_v2
    {
        public ATNQWSubjFToDoVerbTransOrFinNode_v2(ContextOfATNParsing_v2 context, ATNQWSubjFToDoTransNode_v2 parentNode, ATNExtendedToken token)
            : base(context, token)
        {
            ParentNode = parentNode;
        }

        public ATNQWSubjFToDoVerbTransOrFinNode_v2(ContextOfATNParsing_v2 context, ATNQWSubjFToDoVerbTransOrFinNode_v2 sameNode, InitATNQWSubjFToDoVerbTransOrFinNodeAction initAction, ATNExtendedToken token)
            : base(context, token)
        {
            mSameNode = sameNode;
            mInitAction = initAction;
            ParentNode = mSameNode.ParentNode;
            mInitAction?.Invoke(this);
        }

        public override StateOfATNParsing_v2 GlobalState => StateOfATNParsing_v2.QWSubj_FToDo_Verb_TransOrFin;

        public ATNQWSubjFToDoTransNode_v2 ParentNode { get; private set; }
        private ATNQWSubjFToDoVerbTransOrFinNode_v2 mSameNode;
        private InitATNQWSubjFToDoVerbTransOrFinNodeAction mInitAction;

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

