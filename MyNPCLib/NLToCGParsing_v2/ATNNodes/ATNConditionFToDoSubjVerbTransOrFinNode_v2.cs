using MyNPCLib.NLToCGParsing;
using System;
using System.Collections.Generic;
using System.Text;

namespace MyNPCLib.NLToCGParsing_v2.ATNNodes
{
    public delegate void InitATNConditionFToDoSubjVerbTransOrFinNodeAction(ATNConditionFToDoSubjVerbTransOrFinNode_v2 item);

    public class ATNConditionFToDoSubjVerbTransOrFinNodeFactory_v2: BaseATNNodeFactory_v2
    {
        public ATNConditionFToDoSubjVerbTransOrFinNodeFactory_v2(ATNConditionFToDoSubjTransNode_v2 parentNode, ATNExtendedToken token)
        {
            mNumberOfConstructor = 1;
            mParentNode = parentNode;
            mToken = token;
        }

        public ATNConditionFToDoSubjVerbTransOrFinNodeFactory_v2(ATNConditionFToDoSubjVerbTransOrFinNode_v2 sameNode, ATNExtendedToken token, InitATNConditionFToDoSubjVerbTransOrFinNodeAction initAction)
        {
            mNumberOfConstructor = 2;
            mSameNode = sameNode;
            mToken = token;
            mInitAction = initAction;
        }

        private int mNumberOfConstructor;
        private ATNConditionFToDoSubjTransNode_v2 mParentNode;
        private ATNConditionFToDoSubjVerbTransOrFinNode_v2 mSameNode;
        private ATNExtendedToken mToken;
        private InitATNConditionFToDoSubjVerbTransOrFinNodeAction mInitAction;

        public override BaseATNNode_v2 Create(ContextOfATNParsing_v2 context)
        {
            switch(mNumberOfConstructor)
            {
                case 1:
                    return new ATNConditionFToDoSubjVerbTransOrFinNode_v2(context, mParentNode, mToken);

                case 2:
                    return new ATNConditionFToDoSubjVerbTransOrFinNode_v2(context, mSameNode, mInitAction, mToken);

                default:
                    throw new ArgumentOutOfRangeException(nameof(mNumberOfConstructor), mNumberOfConstructor, null);
            }
        }
    }

/*Sub states:
    Condition_FToDo_Subj_Verb_Obj_TransOrFin
    Condition_FToDo_Subj_Verb_No_Trans
    Condition_FToDo_Subj_Verb_Condition_Fin
*/

    public class ATNConditionFToDoSubjVerbTransOrFinNode_v2: BaseATNNode_v2
    {
        public ATNConditionFToDoSubjVerbTransOrFinNode_v2(ContextOfATNParsing_v2 context, ATNConditionFToDoSubjTransNode_v2 parentNode, ATNExtendedToken token)
            : base(context, token)
        {
            ParentNode = parentNode;
        }

        public ATNConditionFToDoSubjVerbTransOrFinNode_v2(ContextOfATNParsing_v2 context, ATNConditionFToDoSubjVerbTransOrFinNode_v2 sameNode, InitATNConditionFToDoSubjVerbTransOrFinNodeAction initAction, ATNExtendedToken token)
            : base(context, token)
        {
            mSameNode = sameNode;
            mInitAction = initAction;
            ParentNode = mSameNode.ParentNode;
            mInitAction?.Invoke(this);
        }

        public override StateOfATNParsing_v2 GlobalState => StateOfATNParsing_v2.Condition_FToDo_Subj_Verb_TransOrFin;

        public ATNConditionFToDoSubjTransNode_v2 ParentNode { get; private set; }
        private ATNConditionFToDoSubjVerbTransOrFinNode_v2 mSameNode;
        private InitATNConditionFToDoSubjVerbTransOrFinNodeAction mInitAction;

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

