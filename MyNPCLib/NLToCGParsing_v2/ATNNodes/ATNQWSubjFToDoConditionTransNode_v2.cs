using MyNPCLib.NLToCGParsing;
using System;
using System.Collections.Generic;
using System.Text;

namespace MyNPCLib.NLToCGParsing_v2.ATNNodes
{
    public delegate void InitATNQWSubjFToDoConditionTransNodeAction(ATNQWSubjFToDoConditionTransNode_v2 item);

    public class ATNQWSubjFToDoConditionTransNodeFactory_v2: BaseATNNodeFactory_v2
    {
        public ATNQWSubjFToDoConditionTransNodeFactory_v2(ATNQWSubjFToDoTransNode_v2 parentNode, ATNExtendedToken token)
        {
            mNumberOfConstructor = 1;
            mParentNode = parentNode;
            mToken = token;
        }

        public ATNQWSubjFToDoConditionTransNodeFactory_v2(ATNQWSubjFToDoConditionTransNode_v2 sameNode, ATNExtendedToken token, InitATNQWSubjFToDoConditionTransNodeAction initAction)
        {
            mNumberOfConstructor = 2;
            mSameNode = sameNode;
            mToken = token;
            mInitAction = initAction;
        }

        private int mNumberOfConstructor;
        private ATNQWSubjFToDoTransNode_v2 mParentNode;
        private ATNQWSubjFToDoConditionTransNode_v2 mSameNode;
        private ATNExtendedToken mToken;
        private InitATNQWSubjFToDoConditionTransNodeAction mInitAction;

        public override BaseATNNode_v2 Create(ContextOfATNParsing_v2 context)
        {
            switch(mNumberOfConstructor)
            {
                case 1:
                    return new ATNQWSubjFToDoConditionTransNode_v2(context, mParentNode, mToken);

                case 2:
                    return new ATNQWSubjFToDoConditionTransNode_v2(context, mSameNode, mInitAction, mToken);

                default:
                    throw new ArgumentOutOfRangeException(nameof(mNumberOfConstructor), mNumberOfConstructor, null);
            }
        }
    }

/*Sub states:
    QWSubj_FToDo_Condition_Verb_TransOrFin
*/

    public class ATNQWSubjFToDoConditionTransNode_v2: BaseATNNode_v2
    {
        public ATNQWSubjFToDoConditionTransNode_v2(ContextOfATNParsing_v2 context, ATNQWSubjFToDoTransNode_v2 parentNode, ATNExtendedToken token)
            : base(context, token)
        {
            ParentNode = parentNode;
        }

        public ATNQWSubjFToDoConditionTransNode_v2(ContextOfATNParsing_v2 context, ATNQWSubjFToDoConditionTransNode_v2 sameNode, InitATNQWSubjFToDoConditionTransNodeAction initAction, ATNExtendedToken token)
            : base(context, token)
        {
            mSameNode = sameNode;
            mInitAction = initAction;
            ParentNode = mSameNode.ParentNode;
            mInitAction?.Invoke(this);
        }

        public override StateOfATNParsing_v2 GlobalState => StateOfATNParsing_v2.QWSubj_FToDo_Condition_Trans;

        public ATNQWSubjFToDoTransNode_v2 ParentNode { get; private set; }
        private ATNQWSubjFToDoConditionTransNode_v2 mSameNode;
        private InitATNQWSubjFToDoConditionTransNodeAction mInitAction;

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

