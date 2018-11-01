using MyNPCLib.NLToCGParsing;
using System;
using System.Collections.Generic;
using System.Text;

namespace MyNPCLib.NLToCGParsing_v2.ATNNodes
{
    public delegate void InitATNConditionFToDoSubjConditionTransNodeAction(ATNConditionFToDoSubjConditionTransNode_v2 item);

    public class ATNConditionFToDoSubjConditionTransNodeFactory_v2: BaseATNNodeFactory_v2
    {
        public ATNConditionFToDoSubjConditionTransNodeFactory_v2(ATNConditionFToDoSubjTransNode_v2 parentNode, ATNExtendedToken token)
        {
            mNumberOfConstructor = 1;
            mParentNode = parentNode;
            mToken = token;
        }

        public ATNConditionFToDoSubjConditionTransNodeFactory_v2(ATNConditionFToDoSubjConditionTransNode_v2 sameNode, ATNExtendedToken token, InitATNConditionFToDoSubjConditionTransNodeAction initAction)
        {
            mNumberOfConstructor = 2;
            mSameNode = sameNode;
            mToken = token;
            mInitAction = initAction;
        }

        private int mNumberOfConstructor;
        private ATNConditionFToDoSubjTransNode_v2 mParentNode;
        private ATNConditionFToDoSubjConditionTransNode_v2 mSameNode;
        private ATNExtendedToken mToken;
        private InitATNConditionFToDoSubjConditionTransNodeAction mInitAction;

        public override BaseATNNode_v2 Create(ContextOfATNParsing_v2 context)
        {
            switch(mNumberOfConstructor)
            {
                case 1:
                    return new ATNConditionFToDoSubjConditionTransNode_v2(context, mParentNode, mToken);

                case 2:
                    return new ATNConditionFToDoSubjConditionTransNode_v2(context, mSameNode, mInitAction, mToken);

                default:
                    throw new ArgumentOutOfRangeException(nameof(mNumberOfConstructor), mNumberOfConstructor, null);
            }
        }
    }

/*Sub states:
    Condition_FToDo_Subj_Condition_Verb_TransOrFin
*/

    public class ATNConditionFToDoSubjConditionTransNode_v2: BaseATNNode_v2
    {
        public ATNConditionFToDoSubjConditionTransNode_v2(ContextOfATNParsing_v2 context, ATNConditionFToDoSubjTransNode_v2 parentNode, ATNExtendedToken token)
            : base(context, token)
        {
            ParentNode = parentNode;
        }

        public ATNConditionFToDoSubjConditionTransNode_v2(ContextOfATNParsing_v2 context, ATNConditionFToDoSubjConditionTransNode_v2 sameNode, InitATNConditionFToDoSubjConditionTransNodeAction initAction, ATNExtendedToken token)
            : base(context, token)
        {
            mSameNode = sameNode;
            mInitAction = initAction;
            ParentNode = mSameNode.ParentNode;
            mInitAction?.Invoke(this);
        }

        public override StateOfATNParsing_v2 GlobalState => StateOfATNParsing_v2.Condition_FToDo_Subj_Condition_Trans;

        public ATNConditionFToDoSubjTransNode_v2 ParentNode { get; private set; }
        private ATNConditionFToDoSubjConditionTransNode_v2 mSameNode;
        private InitATNConditionFToDoSubjConditionTransNodeAction mInitAction;

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

