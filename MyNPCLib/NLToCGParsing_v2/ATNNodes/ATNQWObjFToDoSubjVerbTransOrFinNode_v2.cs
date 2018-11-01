using MyNPCLib.NLToCGParsing;
using System;
using System.Collections.Generic;
using System.Text;

namespace MyNPCLib.NLToCGParsing_v2.ATNNodes
{
    public delegate void InitATNQWObjFToDoSubjVerbTransOrFinNodeAction(ATNQWObjFToDoSubjVerbTransOrFinNode_v2 item);

    public class ATNQWObjFToDoSubjVerbTransOrFinNodeFactory_v2: BaseATNNodeFactory_v2
    {
        public ATNQWObjFToDoSubjVerbTransOrFinNodeFactory_v2(ATNQWObjFToDoSubjTransNode_v2 parentNode, ATNExtendedToken token)
        {
            mNumberOfConstructor = 1;
            mParentNode = parentNode;
            mToken = token;
        }

        public ATNQWObjFToDoSubjVerbTransOrFinNodeFactory_v2(ATNQWObjFToDoSubjVerbTransOrFinNode_v2 sameNode, ATNExtendedToken token, InitATNQWObjFToDoSubjVerbTransOrFinNodeAction initAction)
        {
            mNumberOfConstructor = 2;
            mSameNode = sameNode;
            mToken = token;
            mInitAction = initAction;
        }

        private int mNumberOfConstructor;
        private ATNQWObjFToDoSubjTransNode_v2 mParentNode;
        private ATNQWObjFToDoSubjVerbTransOrFinNode_v2 mSameNode;
        private ATNExtendedToken mToken;
        private InitATNQWObjFToDoSubjVerbTransOrFinNodeAction mInitAction;

        public override BaseATNNode_v2 Create(ContextOfATNParsing_v2 context)
        {
            switch(mNumberOfConstructor)
            {
                case 1:
                    return new ATNQWObjFToDoSubjVerbTransOrFinNode_v2(context, mParentNode, mToken);

                case 2:
                    return new ATNQWObjFToDoSubjVerbTransOrFinNode_v2(context, mSameNode, mInitAction, mToken);

                default:
                    throw new ArgumentOutOfRangeException(nameof(mNumberOfConstructor), mNumberOfConstructor, null);
            }
        }
    }

/*Sub states:
    QWObj_FToDo_Subj_Verb_Condition_Fin
*/

    public class ATNQWObjFToDoSubjVerbTransOrFinNode_v2: BaseATNNode_v2
    {
        public ATNQWObjFToDoSubjVerbTransOrFinNode_v2(ContextOfATNParsing_v2 context, ATNQWObjFToDoSubjTransNode_v2 parentNode, ATNExtendedToken token)
            : base(context, token)
        {
            ParentNode = parentNode;
        }

        public ATNQWObjFToDoSubjVerbTransOrFinNode_v2(ContextOfATNParsing_v2 context, ATNQWObjFToDoSubjVerbTransOrFinNode_v2 sameNode, InitATNQWObjFToDoSubjVerbTransOrFinNodeAction initAction, ATNExtendedToken token)
            : base(context, token)
        {
            mSameNode = sameNode;
            mInitAction = initAction;
            ParentNode = mSameNode.ParentNode;
            mInitAction?.Invoke(this);
        }

        public override StateOfATNParsing_v2 GlobalState => StateOfATNParsing_v2.QWObj_FToDo_Subj_Verb_TransOrFin;

        public ATNQWObjFToDoSubjTransNode_v2 ParentNode { get; private set; }
        private ATNQWObjFToDoSubjVerbTransOrFinNode_v2 mSameNode;
        private InitATNQWObjFToDoSubjVerbTransOrFinNodeAction mInitAction;

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

