using MyNPCLib.NLToCGParsing;
using System;
using System.Collections.Generic;
using System.Text;

namespace MyNPCLib.NLToCGParsing_v2.ATNNodes
{
    public delegate void InitATNConditionFToDoSubjConditionVerbTransOrFinNodeAction(ATNConditionFToDoSubjConditionVerbTransOrFinNode_v2 item);

    public class ATNConditionFToDoSubjConditionVerbTransOrFinNodeFactory_v2: BaseATNNodeFactory_v2
    {
        public ATNConditionFToDoSubjConditionVerbTransOrFinNodeFactory_v2(ATNConditionFToDoSubjConditionTransNode_v2 parentNode, ATNExtendedToken token)
        {
            mNumberOfConstructor = 1;
            mParentNode = parentNode;
            mToken = token;
        }

        public ATNConditionFToDoSubjConditionVerbTransOrFinNodeFactory_v2(ATNConditionFToDoSubjConditionVerbTransOrFinNode_v2 sameNode, ATNExtendedToken token, InitATNConditionFToDoSubjConditionVerbTransOrFinNodeAction initAction)
        {
            mNumberOfConstructor = 2;
            mSameNode = sameNode;
            mToken = token;
            mInitAction = initAction;
        }

        private int mNumberOfConstructor;
        private ATNConditionFToDoSubjConditionTransNode_v2 mParentNode;
        private ATNConditionFToDoSubjConditionVerbTransOrFinNode_v2 mSameNode;
        private ATNExtendedToken mToken;
        private InitATNConditionFToDoSubjConditionVerbTransOrFinNodeAction mInitAction;

        public override BaseATNNode_v2 Create(ContextOfATNParsing_v2 context)
        {
            switch(mNumberOfConstructor)
            {
                case 1:
                    return new ATNConditionFToDoSubjConditionVerbTransOrFinNode_v2(context, mParentNode, mToken);

                case 2:
                    return new ATNConditionFToDoSubjConditionVerbTransOrFinNode_v2(context, mSameNode, mInitAction, mToken);

                default:
                    throw new ArgumentOutOfRangeException(nameof(mNumberOfConstructor), mNumberOfConstructor, null);
            }
        }
    }

/*Sub states:
    Condition_FToDo_Subj_Condition_Verb_Obj_TransOrFin
    Condition_FToDo_Subj_Condition_Verb_No_Trans
    Condition_FToDo_Subj_Condition_Verb_Condition_Fin
*/

    public class ATNConditionFToDoSubjConditionVerbTransOrFinNode_v2: BaseATNNode_v2
    {
        public ATNConditionFToDoSubjConditionVerbTransOrFinNode_v2(ContextOfATNParsing_v2 context, ATNConditionFToDoSubjConditionTransNode_v2 parentNode, ATNExtendedToken token)
            : base(context, token)
        {
            ParentNode = parentNode;
        }

        public ATNConditionFToDoSubjConditionVerbTransOrFinNode_v2(ContextOfATNParsing_v2 context, ATNConditionFToDoSubjConditionVerbTransOrFinNode_v2 sameNode, InitATNConditionFToDoSubjConditionVerbTransOrFinNodeAction initAction, ATNExtendedToken token)
            : base(context, token)
        {
            mSameNode = sameNode;
            mInitAction = initAction;
            ParentNode = mSameNode.ParentNode;
            mInitAction?.Invoke(this);
        }

        public override StateOfATNParsing_v2 GlobalState => StateOfATNParsing_v2.Condition_FToDo_Subj_Condition_Verb_TransOrFin;

        public ATNConditionFToDoSubjConditionTransNode_v2 ParentNode { get; private set; }
        private ATNConditionFToDoSubjConditionVerbTransOrFinNode_v2 mSameNode;
        private InitATNConditionFToDoSubjConditionVerbTransOrFinNodeAction mInitAction;

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

