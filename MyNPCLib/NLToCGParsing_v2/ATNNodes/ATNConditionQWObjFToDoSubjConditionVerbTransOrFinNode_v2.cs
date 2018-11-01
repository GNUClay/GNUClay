using MyNPCLib.NLToCGParsing;
using System;
using System.Collections.Generic;
using System.Text;

namespace MyNPCLib.NLToCGParsing_v2.ATNNodes
{
    public delegate void InitATNConditionQWObjFToDoSubjConditionVerbTransOrFinNodeAction(ATNConditionQWObjFToDoSubjConditionVerbTransOrFinNode_v2 item);

    public class ATNConditionQWObjFToDoSubjConditionVerbTransOrFinNodeFactory_v2: BaseATNNodeFactory_v2
    {
        public ATNConditionQWObjFToDoSubjConditionVerbTransOrFinNodeFactory_v2(ATNConditionQWObjFToDoSubjConditionTransNode_v2 parentNode, ATNExtendedToken token)
        {
            mNumberOfConstructor = 1;
            mParentNode = parentNode;
            mToken = token;
        }

        public ATNConditionQWObjFToDoSubjConditionVerbTransOrFinNodeFactory_v2(ATNConditionQWObjFToDoSubjConditionVerbTransOrFinNode_v2 sameNode, ATNExtendedToken token, InitATNConditionQWObjFToDoSubjConditionVerbTransOrFinNodeAction initAction)
        {
            mNumberOfConstructor = 2;
            mSameNode = sameNode;
            mToken = token;
            mInitAction = initAction;
        }

        private int mNumberOfConstructor;
        private ATNConditionQWObjFToDoSubjConditionTransNode_v2 mParentNode;
        private ATNConditionQWObjFToDoSubjConditionVerbTransOrFinNode_v2 mSameNode;
        private ATNExtendedToken mToken;
        private InitATNConditionQWObjFToDoSubjConditionVerbTransOrFinNodeAction mInitAction;

        public override BaseATNNode_v2 Create(ContextOfATNParsing_v2 context)
        {
            switch(mNumberOfConstructor)
            {
                case 1:
                    return new ATNConditionQWObjFToDoSubjConditionVerbTransOrFinNode_v2(context, mParentNode, mToken);

                case 2:
                    return new ATNConditionQWObjFToDoSubjConditionVerbTransOrFinNode_v2(context, mSameNode, mInitAction, mToken);

                default:
                    throw new ArgumentOutOfRangeException(nameof(mNumberOfConstructor), mNumberOfConstructor, null);
            }
        }
    }

/*Sub states:
    Condition_QWObj_FToDo_Subj_Condition_Verb_Condition_Fin
*/

    public class ATNConditionQWObjFToDoSubjConditionVerbTransOrFinNode_v2: BaseATNNode_v2
    {
        public ATNConditionQWObjFToDoSubjConditionVerbTransOrFinNode_v2(ContextOfATNParsing_v2 context, ATNConditionQWObjFToDoSubjConditionTransNode_v2 parentNode, ATNExtendedToken token)
            : base(context, token)
        {
            ParentNode = parentNode;
        }

        public ATNConditionQWObjFToDoSubjConditionVerbTransOrFinNode_v2(ContextOfATNParsing_v2 context, ATNConditionQWObjFToDoSubjConditionVerbTransOrFinNode_v2 sameNode, InitATNConditionQWObjFToDoSubjConditionVerbTransOrFinNodeAction initAction, ATNExtendedToken token)
            : base(context, token)
        {
            mSameNode = sameNode;
            mInitAction = initAction;
            ParentNode = mSameNode.ParentNode;
            mInitAction?.Invoke(this);
        }

        public override StateOfATNParsing_v2 GlobalState => StateOfATNParsing_v2.Condition_QWObj_FToDo_Subj_Condition_Verb_TransOrFin;

        public ATNConditionQWObjFToDoSubjConditionTransNode_v2 ParentNode { get; private set; }
        private ATNConditionQWObjFToDoSubjConditionVerbTransOrFinNode_v2 mSameNode;
        private InitATNConditionQWObjFToDoSubjConditionVerbTransOrFinNodeAction mInitAction;

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

