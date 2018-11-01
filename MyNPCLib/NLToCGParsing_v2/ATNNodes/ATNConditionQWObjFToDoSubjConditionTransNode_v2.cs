using MyNPCLib.NLToCGParsing;
using System;
using System.Collections.Generic;
using System.Text;

namespace MyNPCLib.NLToCGParsing_v2.ATNNodes
{
    public delegate void InitATNConditionQWObjFToDoSubjConditionTransNodeAction(ATNConditionQWObjFToDoSubjConditionTransNode_v2 item);

    public class ATNConditionQWObjFToDoSubjConditionTransNodeFactory_v2: BaseATNNodeFactory_v2
    {
        public ATNConditionQWObjFToDoSubjConditionTransNodeFactory_v2(ATNConditionQWObjFToDoSubjTransNode_v2 parentNode, ATNExtendedToken token)
        {
            mNumberOfConstructor = 1;
            mParentNode = parentNode;
            mToken = token;
        }

        public ATNConditionQWObjFToDoSubjConditionTransNodeFactory_v2(ATNConditionQWObjFToDoSubjConditionTransNode_v2 sameNode, ATNExtendedToken token, InitATNConditionQWObjFToDoSubjConditionTransNodeAction initAction)
        {
            mNumberOfConstructor = 2;
            mSameNode = sameNode;
            mToken = token;
            mInitAction = initAction;
        }

        private int mNumberOfConstructor;
        private ATNConditionQWObjFToDoSubjTransNode_v2 mParentNode;
        private ATNConditionQWObjFToDoSubjConditionTransNode_v2 mSameNode;
        private ATNExtendedToken mToken;
        private InitATNConditionQWObjFToDoSubjConditionTransNodeAction mInitAction;

        public override BaseATNNode_v2 Create(ContextOfATNParsing_v2 context)
        {
            switch(mNumberOfConstructor)
            {
                case 1:
                    return new ATNConditionQWObjFToDoSubjConditionTransNode_v2(context, mParentNode, mToken);

                case 2:
                    return new ATNConditionQWObjFToDoSubjConditionTransNode_v2(context, mSameNode, mInitAction, mToken);

                default:
                    throw new ArgumentOutOfRangeException(nameof(mNumberOfConstructor), mNumberOfConstructor, null);
            }
        }
    }

/*Sub states:
    Condition_QWObj_FToDo_Subj_Condition_Verb_TransOrFin
*/

    public class ATNConditionQWObjFToDoSubjConditionTransNode_v2: BaseATNNode_v2
    {
        public ATNConditionQWObjFToDoSubjConditionTransNode_v2(ContextOfATNParsing_v2 context, ATNConditionQWObjFToDoSubjTransNode_v2 parentNode, ATNExtendedToken token)
            : base(context, token)
        {
            ParentNode = parentNode;
        }

        public ATNConditionQWObjFToDoSubjConditionTransNode_v2(ContextOfATNParsing_v2 context, ATNConditionQWObjFToDoSubjConditionTransNode_v2 sameNode, InitATNConditionQWObjFToDoSubjConditionTransNodeAction initAction, ATNExtendedToken token)
            : base(context, token)
        {
            mSameNode = sameNode;
            mInitAction = initAction;
            ParentNode = mSameNode.ParentNode;
            mInitAction?.Invoke(this);
        }

        public override StateOfATNParsing_v2 GlobalState => StateOfATNParsing_v2.Condition_QWObj_FToDo_Subj_Condition_Trans;

        public ATNConditionQWObjFToDoSubjTransNode_v2 ParentNode { get; private set; }
        private ATNConditionQWObjFToDoSubjConditionTransNode_v2 mSameNode;
        private InitATNConditionQWObjFToDoSubjConditionTransNodeAction mInitAction;

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

