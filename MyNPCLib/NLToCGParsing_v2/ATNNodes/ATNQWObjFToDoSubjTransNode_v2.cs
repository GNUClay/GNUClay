using MyNPCLib.NLToCGParsing;
using System;
using System.Collections.Generic;
using System.Text;

namespace MyNPCLib.NLToCGParsing_v2.ATNNodes
{
    public delegate void InitATNQWObjFToDoSubjTransNodeAction(ATNQWObjFToDoSubjTransNode_v2 item);

    public class ATNQWObjFToDoSubjTransNodeFactory_v2: BaseATNNodeFactory_v2
    {
        public ATNQWObjFToDoSubjTransNodeFactory_v2(ATNQWObjFToDoTransNode_v2 parentNode, ATNExtendedToken token)
        {
            mNumberOfConstructor = 1;
            mParentNode = parentNode;
            mToken = token;
        }

        public ATNQWObjFToDoSubjTransNodeFactory_v2(ATNQWObjFToDoSubjTransNode_v2 sameNode, ATNExtendedToken token, InitATNQWObjFToDoSubjTransNodeAction initAction)
        {
            mNumberOfConstructor = 2;
            mSameNode = sameNode;
            mToken = token;
            mInitAction = initAction;
        }

        private int mNumberOfConstructor;
        private ATNQWObjFToDoTransNode_v2 mParentNode;
        private ATNQWObjFToDoSubjTransNode_v2 mSameNode;
        private ATNExtendedToken mToken;
        private InitATNQWObjFToDoSubjTransNodeAction mInitAction;

        public override BaseATNNode_v2 Create(ContextOfATNParsing_v2 context)
        {
            switch(mNumberOfConstructor)
            {
                case 1:
                    return new ATNQWObjFToDoSubjTransNode_v2(context, mParentNode, mToken);

                case 2:
                    return new ATNQWObjFToDoSubjTransNode_v2(context, mSameNode, mInitAction, mToken);

                default:
                    throw new ArgumentOutOfRangeException(nameof(mNumberOfConstructor), mNumberOfConstructor, null);
            }
        }
    }

/*Sub states:
    QWObj_FToDo_Subj_Verb_TransOrFin
    QWObj_FToDo_Subj_Condition_Trans
*/

    public class ATNQWObjFToDoSubjTransNode_v2: BaseATNNode_v2
    {
        public ATNQWObjFToDoSubjTransNode_v2(ContextOfATNParsing_v2 context, ATNQWObjFToDoTransNode_v2 parentNode, ATNExtendedToken token)
            : base(context, token)
        {
            ParentNode = parentNode;
        }

        public ATNQWObjFToDoSubjTransNode_v2(ContextOfATNParsing_v2 context, ATNQWObjFToDoSubjTransNode_v2 sameNode, InitATNQWObjFToDoSubjTransNodeAction initAction, ATNExtendedToken token)
            : base(context, token)
        {
            mSameNode = sameNode;
            mInitAction = initAction;
            ParentNode = mSameNode.ParentNode;
            mInitAction?.Invoke(this);
        }

        public override StateOfATNParsing_v2 GlobalState => StateOfATNParsing_v2.QWObj_FToDo_Subj_Trans;

        public ATNQWObjFToDoTransNode_v2 ParentNode { get; private set; }
        private ATNQWObjFToDoSubjTransNode_v2 mSameNode;
        private InitATNQWObjFToDoSubjTransNodeAction mInitAction;

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

