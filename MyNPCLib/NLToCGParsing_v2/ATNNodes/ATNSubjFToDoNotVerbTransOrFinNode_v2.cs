using MyNPCLib.NLToCGParsing;
using System;
using System.Collections.Generic;
using System.Text;

namespace MyNPCLib.NLToCGParsing_v2.ATNNodes
{
    public delegate void InitATNSubjFToDoNotVerbTransOrFinNodeAction(ATNSubjFToDoNotVerbTransOrFinNode_v2 item);

    public class ATNSubjFToDoNotVerbTransOrFinNodeFactory_v2: BaseATNNodeFactory_v2
    {
        public ATNSubjFToDoNotVerbTransOrFinNodeFactory_v2(ATNSubjFToDoNotTransNode_v2 parentNode, ATNExtendedToken token)
        {
            mNumberOfConstructor = 1;
            mParentNode = parentNode;
            mToken = token;
        }

        public ATNSubjFToDoNotVerbTransOrFinNodeFactory_v2(ATNSubjFToDoNotVerbTransOrFinNode_v2 sameNode, ATNExtendedToken token, InitATNSubjFToDoNotVerbTransOrFinNodeAction initAction)
        {
            mNumberOfConstructor = 2;
            mSameNode = sameNode;
            mToken = token;
            mInitAction = initAction;
        }

        private int mNumberOfConstructor;
        private ATNSubjFToDoNotTransNode_v2 mParentNode;
        private ATNSubjFToDoNotVerbTransOrFinNode_v2 mSameNode;
        private ATNExtendedToken mToken;
        private InitATNSubjFToDoNotVerbTransOrFinNodeAction mInitAction;

        public override BaseATNNode_v2 Create(ContextOfATNParsing_v2 context)
        {
            switch(mNumberOfConstructor)
            {
                case 1:
                    return new ATNSubjFToDoNotVerbTransOrFinNode_v2(context, mParentNode, mToken);

                case 2:
                    return new ATNSubjFToDoNotVerbTransOrFinNode_v2(context, mSameNode, mInitAction, mToken);

                default:
                    throw new ArgumentOutOfRangeException(nameof(mNumberOfConstructor), mNumberOfConstructor, null);
            }
        }
    }

/*Sub states:
    Subj_FToDo_Not_Verb_Obj_TransOrFin
    Subj_FToDo_Not_Verb_Condition_Fin
*/

    public class ATNSubjFToDoNotVerbTransOrFinNode_v2: BaseATNNode_v2
    {
        public ATNSubjFToDoNotVerbTransOrFinNode_v2(ContextOfATNParsing_v2 context, ATNSubjFToDoNotTransNode_v2 parentNode, ATNExtendedToken token)
            : base(context, token)
        {
            ParentNode = parentNode;
        }

        public ATNSubjFToDoNotVerbTransOrFinNode_v2(ContextOfATNParsing_v2 context, ATNSubjFToDoNotVerbTransOrFinNode_v2 sameNode, InitATNSubjFToDoNotVerbTransOrFinNodeAction initAction, ATNExtendedToken token)
            : base(context, token)
        {
            mSameNode = sameNode;
            mInitAction = initAction;
            ParentNode = mSameNode.ParentNode;
            mInitAction?.Invoke(this);
        }

        public override StateOfATNParsing_v2 GlobalState => StateOfATNParsing_v2.Subj_FToDo_Not_Verb_TransOrFin;

        public ATNSubjFToDoNotTransNode_v2 ParentNode { get; private set; }
        private ATNSubjFToDoNotVerbTransOrFinNode_v2 mSameNode;
        private InitATNSubjFToDoNotVerbTransOrFinNodeAction mInitAction;

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

