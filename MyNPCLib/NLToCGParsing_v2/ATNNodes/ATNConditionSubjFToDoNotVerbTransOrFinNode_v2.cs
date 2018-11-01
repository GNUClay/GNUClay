using MyNPCLib.NLToCGParsing;
using System;
using System.Collections.Generic;
using System.Text;

namespace MyNPCLib.NLToCGParsing_v2.ATNNodes
{
    public delegate void InitATNConditionSubjFToDoNotVerbTransOrFinNodeAction(ATNConditionSubjFToDoNotVerbTransOrFinNode_v2 item);

    public class ATNConditionSubjFToDoNotVerbTransOrFinNodeFactory_v2: BaseATNNodeFactory_v2
    {
        public ATNConditionSubjFToDoNotVerbTransOrFinNodeFactory_v2(ATNConditionSubjFToDoNotTransNode_v2 parentNode, ATNExtendedToken token)
        {
            mNumberOfConstructor = 1;
            mParentNode = parentNode;
            mToken = token;
        }

        public ATNConditionSubjFToDoNotVerbTransOrFinNodeFactory_v2(ATNConditionSubjFToDoNotVerbTransOrFinNode_v2 sameNode, ATNExtendedToken token, InitATNConditionSubjFToDoNotVerbTransOrFinNodeAction initAction)
        {
            mNumberOfConstructor = 2;
            mSameNode = sameNode;
            mToken = token;
            mInitAction = initAction;
        }

        private int mNumberOfConstructor;
        private ATNConditionSubjFToDoNotTransNode_v2 mParentNode;
        private ATNConditionSubjFToDoNotVerbTransOrFinNode_v2 mSameNode;
        private ATNExtendedToken mToken;
        private InitATNConditionSubjFToDoNotVerbTransOrFinNodeAction mInitAction;

        public override BaseATNNode_v2 Create(ContextOfATNParsing_v2 context)
        {
            switch(mNumberOfConstructor)
            {
                case 1:
                    return new ATNConditionSubjFToDoNotVerbTransOrFinNode_v2(context, mParentNode, mToken);

                case 2:
                    return new ATNConditionSubjFToDoNotVerbTransOrFinNode_v2(context, mSameNode, mInitAction, mToken);

                default:
                    throw new ArgumentOutOfRangeException(nameof(mNumberOfConstructor), mNumberOfConstructor, null);
            }
        }
    }

/*Sub states:
    Condition_Subj_FToDo_Not_Verb_Obj_TransOrFin
    Condition_Subj_FToDo_Not_Verb_Condition_Fin
*/

    public class ATNConditionSubjFToDoNotVerbTransOrFinNode_v2: BaseATNNode_v2
    {
        public ATNConditionSubjFToDoNotVerbTransOrFinNode_v2(ContextOfATNParsing_v2 context, ATNConditionSubjFToDoNotTransNode_v2 parentNode, ATNExtendedToken token)
            : base(context, token)
        {
            ParentNode = parentNode;
        }

        public ATNConditionSubjFToDoNotVerbTransOrFinNode_v2(ContextOfATNParsing_v2 context, ATNConditionSubjFToDoNotVerbTransOrFinNode_v2 sameNode, InitATNConditionSubjFToDoNotVerbTransOrFinNodeAction initAction, ATNExtendedToken token)
            : base(context, token)
        {
            mSameNode = sameNode;
            mInitAction = initAction;
            ParentNode = mSameNode.ParentNode;
            mInitAction?.Invoke(this);
        }

        public override StateOfATNParsing_v2 GlobalState => StateOfATNParsing_v2.Condition_Subj_FToDo_Not_Verb_TransOrFin;

        public ATNConditionSubjFToDoNotTransNode_v2 ParentNode { get; private set; }
        private ATNConditionSubjFToDoNotVerbTransOrFinNode_v2 mSameNode;
        private InitATNConditionSubjFToDoNotVerbTransOrFinNodeAction mInitAction;

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

