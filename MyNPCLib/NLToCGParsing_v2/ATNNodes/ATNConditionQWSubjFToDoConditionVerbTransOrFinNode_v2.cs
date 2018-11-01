using MyNPCLib.NLToCGParsing;
using System;
using System.Collections.Generic;
using System.Text;

namespace MyNPCLib.NLToCGParsing_v2.ATNNodes
{
    public delegate void InitATNConditionQWSubjFToDoConditionVerbTransOrFinNodeAction(ATNConditionQWSubjFToDoConditionVerbTransOrFinNode_v2 item);

    public class ATNConditionQWSubjFToDoConditionVerbTransOrFinNodeFactory_v2: BaseATNNodeFactory_v2
    {
        public ATNConditionQWSubjFToDoConditionVerbTransOrFinNodeFactory_v2(ATNConditionQWSubjFToDoConditionTransNode_v2 parentNode, ATNExtendedToken token)
        {
            mNumberOfConstructor = 1;
            mParentNode = parentNode;
            mToken = token;
        }

        public ATNConditionQWSubjFToDoConditionVerbTransOrFinNodeFactory_v2(ATNConditionQWSubjFToDoConditionVerbTransOrFinNode_v2 sameNode, ATNExtendedToken token, InitATNConditionQWSubjFToDoConditionVerbTransOrFinNodeAction initAction)
        {
            mNumberOfConstructor = 2;
            mSameNode = sameNode;
            mToken = token;
            mInitAction = initAction;
        }

        private int mNumberOfConstructor;
        private ATNConditionQWSubjFToDoConditionTransNode_v2 mParentNode;
        private ATNConditionQWSubjFToDoConditionVerbTransOrFinNode_v2 mSameNode;
        private ATNExtendedToken mToken;
        private InitATNConditionQWSubjFToDoConditionVerbTransOrFinNodeAction mInitAction;

        public override BaseATNNode_v2 Create(ContextOfATNParsing_v2 context)
        {
            switch(mNumberOfConstructor)
            {
                case 1:
                    return new ATNConditionQWSubjFToDoConditionVerbTransOrFinNode_v2(context, mParentNode, mToken);

                case 2:
                    return new ATNConditionQWSubjFToDoConditionVerbTransOrFinNode_v2(context, mSameNode, mInitAction, mToken);

                default:
                    throw new ArgumentOutOfRangeException(nameof(mNumberOfConstructor), mNumberOfConstructor, null);
            }
        }
    }

/*Sub states:
    Condition_QWSubj_FToDo_Condition_Verb_Obj_TransOrFin
    Condition_QWSubj_FToDo_Condition_Verb_No_Trans
    Condition_QWSubj_FToDo_Condition_Verb_Condition_Fin
*/

    public class ATNConditionQWSubjFToDoConditionVerbTransOrFinNode_v2: BaseATNNode_v2
    {
        public ATNConditionQWSubjFToDoConditionVerbTransOrFinNode_v2(ContextOfATNParsing_v2 context, ATNConditionQWSubjFToDoConditionTransNode_v2 parentNode, ATNExtendedToken token)
            : base(context, token)
        {
            ParentNode = parentNode;
        }

        public ATNConditionQWSubjFToDoConditionVerbTransOrFinNode_v2(ContextOfATNParsing_v2 context, ATNConditionQWSubjFToDoConditionVerbTransOrFinNode_v2 sameNode, InitATNConditionQWSubjFToDoConditionVerbTransOrFinNodeAction initAction, ATNExtendedToken token)
            : base(context, token)
        {
            mSameNode = sameNode;
            mInitAction = initAction;
            ParentNode = mSameNode.ParentNode;
            mInitAction?.Invoke(this);
        }

        public override StateOfATNParsing_v2 GlobalState => StateOfATNParsing_v2.Condition_QWSubj_FToDo_Condition_Verb_TransOrFin;

        public ATNConditionQWSubjFToDoConditionTransNode_v2 ParentNode { get; private set; }
        private ATNConditionQWSubjFToDoConditionVerbTransOrFinNode_v2 mSameNode;
        private InitATNConditionQWSubjFToDoConditionVerbTransOrFinNodeAction mInitAction;

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

