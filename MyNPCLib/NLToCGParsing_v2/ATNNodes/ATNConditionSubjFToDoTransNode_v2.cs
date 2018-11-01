using MyNPCLib.NLToCGParsing;
using System;
using System.Collections.Generic;
using System.Text;

namespace MyNPCLib.NLToCGParsing_v2.ATNNodes
{
    public delegate void InitATNConditionSubjFToDoTransNodeAction(ATNConditionSubjFToDoTransNode_v2 item);

    public class ATNConditionSubjFToDoTransNodeFactory_v2: BaseATNNodeFactory_v2
    {
        public ATNConditionSubjFToDoTransNodeFactory_v2(ATNConditionSubjTransNode_v2 parentNode, ATNExtendedToken token)
        {
            mNumberOfConstructor = 1;
            mParentNode = parentNode;
            mToken = token;
        }

        public ATNConditionSubjFToDoTransNodeFactory_v2(ATNConditionSubjFToDoTransNode_v2 sameNode, ATNExtendedToken token, InitATNConditionSubjFToDoTransNodeAction initAction)
        {
            mNumberOfConstructor = 2;
            mSameNode = sameNode;
            mToken = token;
            mInitAction = initAction;
        }

        private int mNumberOfConstructor;
        private ATNConditionSubjTransNode_v2 mParentNode;
        private ATNConditionSubjFToDoTransNode_v2 mSameNode;
        private ATNExtendedToken mToken;
        private InitATNConditionSubjFToDoTransNodeAction mInitAction;

        public override BaseATNNode_v2 Create(ContextOfATNParsing_v2 context)
        {
            switch(mNumberOfConstructor)
            {
                case 1:
                    return new ATNConditionSubjFToDoTransNode_v2(context, mParentNode, mToken);

                case 2:
                    return new ATNConditionSubjFToDoTransNode_v2(context, mSameNode, mInitAction, mToken);

                default:
                    throw new ArgumentOutOfRangeException(nameof(mNumberOfConstructor), mNumberOfConstructor, null);
            }
        }
    }

/*Sub states:
    Condition_Subj_FToDo_Not_Trans
*/

    public class ATNConditionSubjFToDoTransNode_v2: BaseATNNode_v2
    {
        public ATNConditionSubjFToDoTransNode_v2(ContextOfATNParsing_v2 context, ATNConditionSubjTransNode_v2 parentNode, ATNExtendedToken token)
            : base(context, token)
        {
            ParentNode = parentNode;
        }

        public ATNConditionSubjFToDoTransNode_v2(ContextOfATNParsing_v2 context, ATNConditionSubjFToDoTransNode_v2 sameNode, InitATNConditionSubjFToDoTransNodeAction initAction, ATNExtendedToken token)
            : base(context, token)
        {
            mSameNode = sameNode;
            mInitAction = initAction;
            ParentNode = mSameNode.ParentNode;
            mInitAction?.Invoke(this);
        }

        public override StateOfATNParsing_v2 GlobalState => StateOfATNParsing_v2.Condition_Subj_FToDo_Trans;

        public ATNConditionSubjTransNode_v2 ParentNode { get; private set; }
        private ATNConditionSubjFToDoTransNode_v2 mSameNode;
        private InitATNConditionSubjFToDoTransNodeAction mInitAction;

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

