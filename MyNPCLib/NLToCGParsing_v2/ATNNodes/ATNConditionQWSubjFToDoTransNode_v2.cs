using MyNPCLib.NLToCGParsing;
using System;
using System.Collections.Generic;
using System.Text;

namespace MyNPCLib.NLToCGParsing_v2.ATNNodes
{
    public delegate void InitATNConditionQWSubjFToDoTransNodeAction(ATNConditionQWSubjFToDoTransNode_v2 item);

    public class ATNConditionQWSubjFToDoTransNodeFactory_v2: BaseATNNodeFactory_v2
    {
        public ATNConditionQWSubjFToDoTransNodeFactory_v2(ATNConditionQWSubjTransNode_v2 parentNode, ATNExtendedToken token)
        {
            mNumberOfConstructor = 1;
            mParentNode = parentNode;
            mToken = token;
        }

        public ATNConditionQWSubjFToDoTransNodeFactory_v2(ATNConditionQWSubjFToDoTransNode_v2 sameNode, ATNExtendedToken token, InitATNConditionQWSubjFToDoTransNodeAction initAction)
        {
            mNumberOfConstructor = 2;
            mSameNode = sameNode;
            mToken = token;
            mInitAction = initAction;
        }

        private int mNumberOfConstructor;
        private ATNConditionQWSubjTransNode_v2 mParentNode;
        private ATNConditionQWSubjFToDoTransNode_v2 mSameNode;
        private ATNExtendedToken mToken;
        private InitATNConditionQWSubjFToDoTransNodeAction mInitAction;

        public override BaseATNNode_v2 Create(ContextOfATNParsing_v2 context)
        {
            switch(mNumberOfConstructor)
            {
                case 1:
                    return new ATNConditionQWSubjFToDoTransNode_v2(context, mParentNode, mToken);

                case 2:
                    return new ATNConditionQWSubjFToDoTransNode_v2(context, mSameNode, mInitAction, mToken);

                default:
                    throw new ArgumentOutOfRangeException(nameof(mNumberOfConstructor), mNumberOfConstructor, null);
            }
        }
    }

/*Sub states:
    Condition_QWSubj_FToDo_Verb_TransOrFin
    Condition_QWSubj_FToDo_Condition_Trans
*/

    public class ATNConditionQWSubjFToDoTransNode_v2: BaseATNNode_v2
    {
        public ATNConditionQWSubjFToDoTransNode_v2(ContextOfATNParsing_v2 context, ATNConditionQWSubjTransNode_v2 parentNode, ATNExtendedToken token)
            : base(context, token)
        {
            ParentNode = parentNode;
        }

        public ATNConditionQWSubjFToDoTransNode_v2(ContextOfATNParsing_v2 context, ATNConditionQWSubjFToDoTransNode_v2 sameNode, InitATNConditionQWSubjFToDoTransNodeAction initAction, ATNExtendedToken token)
            : base(context, token)
        {
            mSameNode = sameNode;
            mInitAction = initAction;
            ParentNode = mSameNode.ParentNode;
            mInitAction?.Invoke(this);
        }

        public override StateOfATNParsing_v2 GlobalState => StateOfATNParsing_v2.Condition_QWSubj_FToDo_Trans;

        public ATNConditionQWSubjTransNode_v2 ParentNode { get; private set; }
        private ATNConditionQWSubjFToDoTransNode_v2 mSameNode;
        private InitATNConditionQWSubjFToDoTransNodeAction mInitAction;

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

