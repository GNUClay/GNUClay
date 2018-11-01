using MyNPCLib.NLToCGParsing;
using System;
using System.Collections.Generic;
using System.Text;

namespace MyNPCLib.NLToCGParsing_v2.ATNNodes
{
    public delegate void InitATNQWSubjFToDoConditionVerbTransOrFinNodeAction(ATNQWSubjFToDoConditionVerbTransOrFinNode_v2 item);

    public class ATNQWSubjFToDoConditionVerbTransOrFinNodeFactory_v2: BaseATNNodeFactory_v2
    {
        public ATNQWSubjFToDoConditionVerbTransOrFinNodeFactory_v2(ATNQWSubjFToDoConditionTransNode_v2 parentNode, ATNExtendedToken token)
        {
            mNumberOfConstructor = 1;
            mParentNode = parentNode;
            mToken = token;
        }

        public ATNQWSubjFToDoConditionVerbTransOrFinNodeFactory_v2(ATNQWSubjFToDoConditionVerbTransOrFinNode_v2 sameNode, ATNExtendedToken token, InitATNQWSubjFToDoConditionVerbTransOrFinNodeAction initAction)
        {
            mNumberOfConstructor = 2;
            mSameNode = sameNode;
            mToken = token;
            mInitAction = initAction;
        }

        private int mNumberOfConstructor;
        private ATNQWSubjFToDoConditionTransNode_v2 mParentNode;
        private ATNQWSubjFToDoConditionVerbTransOrFinNode_v2 mSameNode;
        private ATNExtendedToken mToken;
        private InitATNQWSubjFToDoConditionVerbTransOrFinNodeAction mInitAction;

        public override BaseATNNode_v2 Create(ContextOfATNParsing_v2 context)
        {
            switch(mNumberOfConstructor)
            {
                case 1:
                    return new ATNQWSubjFToDoConditionVerbTransOrFinNode_v2(context, mParentNode, mToken);

                case 2:
                    return new ATNQWSubjFToDoConditionVerbTransOrFinNode_v2(context, mSameNode, mInitAction, mToken);

                default:
                    throw new ArgumentOutOfRangeException(nameof(mNumberOfConstructor), mNumberOfConstructor, null);
            }
        }
    }

/*Sub states:
    QWSubj_FToDo_Condition_Verb_Obj_TransOrFin
    QWSubj_FToDo_Condition_Verb_No_Trans
    QWSubj_FToDo_Condition_Verb_Condition_Fin
*/

    public class ATNQWSubjFToDoConditionVerbTransOrFinNode_v2: BaseATNNode_v2
    {
        public ATNQWSubjFToDoConditionVerbTransOrFinNode_v2(ContextOfATNParsing_v2 context, ATNQWSubjFToDoConditionTransNode_v2 parentNode, ATNExtendedToken token)
            : base(context, token)
        {
            ParentNode = parentNode;
        }

        public ATNQWSubjFToDoConditionVerbTransOrFinNode_v2(ContextOfATNParsing_v2 context, ATNQWSubjFToDoConditionVerbTransOrFinNode_v2 sameNode, InitATNQWSubjFToDoConditionVerbTransOrFinNodeAction initAction, ATNExtendedToken token)
            : base(context, token)
        {
            mSameNode = sameNode;
            mInitAction = initAction;
            ParentNode = mSameNode.ParentNode;
            mInitAction?.Invoke(this);
        }

        public override StateOfATNParsing_v2 GlobalState => StateOfATNParsing_v2.QWSubj_FToDo_Condition_Verb_TransOrFin;

        public ATNQWSubjFToDoConditionTransNode_v2 ParentNode { get; private set; }
        private ATNQWSubjFToDoConditionVerbTransOrFinNode_v2 mSameNode;
        private InitATNQWSubjFToDoConditionVerbTransOrFinNodeAction mInitAction;

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

