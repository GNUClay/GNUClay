using MyNPCLib.NLToCGParsing;
using System;
using System.Collections.Generic;
using System.Text;

namespace MyNPCLib.NLToCGParsing_v2.ATNNodes
{
    public delegate void InitATNConditionQWSubjFToDoConditionTransNodeAction(ATNConditionQWSubjFToDoConditionTransNode_v2 item);

    public class ATNConditionQWSubjFToDoConditionTransNodeFactory_v2: BaseATNNodeFactory_v2
    {
        public ATNConditionQWSubjFToDoConditionTransNodeFactory_v2(ATNConditionQWSubjFToDoTransNode_v2 parentNode, ATNExtendedToken token)
        {
            mNumberOfConstructor = 1;
            mParentNode = parentNode;
            mToken = token;
        }

        public ATNConditionQWSubjFToDoConditionTransNodeFactory_v2(ATNConditionQWSubjFToDoConditionTransNode_v2 sameNode, ATNExtendedToken token, InitATNConditionQWSubjFToDoConditionTransNodeAction initAction)
        {
            mNumberOfConstructor = 2;
            mSameNode = sameNode;
            mToken = token;
            mInitAction = initAction;
        }

        private int mNumberOfConstructor;
        private ATNConditionQWSubjFToDoTransNode_v2 mParentNode;
        private ATNConditionQWSubjFToDoConditionTransNode_v2 mSameNode;
        private ATNExtendedToken mToken;
        private InitATNConditionQWSubjFToDoConditionTransNodeAction mInitAction;

        public override BaseATNNode_v2 Create(ContextOfATNParsing_v2 context)
        {
            switch(mNumberOfConstructor)
            {
                case 1:
                    return new ATNConditionQWSubjFToDoConditionTransNode_v2(context, mParentNode, mToken);

                case 2:
                    return new ATNConditionQWSubjFToDoConditionTransNode_v2(context, mSameNode, mInitAction, mToken);

                default:
                    throw new ArgumentOutOfRangeException(nameof(mNumberOfConstructor), mNumberOfConstructor, null);
            }
        }
    }

/*Sub states:
    Condition_QWSubj_FToDo_Condition_Verb_TransOrFin
*/

    public class ATNConditionQWSubjFToDoConditionTransNode_v2: BaseATNNode_v2
    {
        public ATNConditionQWSubjFToDoConditionTransNode_v2(ContextOfATNParsing_v2 context, ATNConditionQWSubjFToDoTransNode_v2 parentNode, ATNExtendedToken token)
            : base(context, token)
        {
            ParentNode = parentNode;
        }

        public ATNConditionQWSubjFToDoConditionTransNode_v2(ContextOfATNParsing_v2 context, ATNConditionQWSubjFToDoConditionTransNode_v2 sameNode, InitATNConditionQWSubjFToDoConditionTransNodeAction initAction, ATNExtendedToken token)
            : base(context, token)
        {
            mSameNode = sameNode;
            mInitAction = initAction;
            ParentNode = mSameNode.ParentNode;
            mInitAction?.Invoke(this);
        }

        public override StateOfATNParsing_v2 GlobalState => StateOfATNParsing_v2.Condition_QWSubj_FToDo_Condition_Trans;

        public ATNConditionQWSubjFToDoTransNode_v2 ParentNode { get; private set; }
        private ATNConditionQWSubjFToDoConditionTransNode_v2 mSameNode;
        private InitATNConditionQWSubjFToDoConditionTransNodeAction mInitAction;

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

