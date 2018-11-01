using MyNPCLib.NLToCGParsing;
using System;
using System.Collections.Generic;
using System.Text;

namespace MyNPCLib.NLToCGParsing_v2.ATNNodes
{
    public delegate void InitATNConditionFToDoTransNodeAction(ATNConditionFToDoTransNode_v2 item);

    public class ATNConditionFToDoTransNodeFactory_v2: BaseATNNodeFactory_v2
    {
        public ATNConditionFToDoTransNodeFactory_v2(ATNConditionTransNode_v2 parentNode, ATNExtendedToken token)
        {
            mNumberOfConstructor = 1;
            mParentNode = parentNode;
            mToken = token;
        }

        public ATNConditionFToDoTransNodeFactory_v2(ATNConditionFToDoTransNode_v2 sameNode, ATNExtendedToken token, InitATNConditionFToDoTransNodeAction initAction)
        {
            mNumberOfConstructor = 2;
            mSameNode = sameNode;
            mToken = token;
            mInitAction = initAction;
        }

        private int mNumberOfConstructor;
        private ATNConditionTransNode_v2 mParentNode;
        private ATNConditionFToDoTransNode_v2 mSameNode;
        private ATNExtendedToken mToken;
        private InitATNConditionFToDoTransNodeAction mInitAction;

        public override BaseATNNode_v2 Create(ContextOfATNParsing_v2 context)
        {
            switch(mNumberOfConstructor)
            {
                case 1:
                    return new ATNConditionFToDoTransNode_v2(context, mParentNode, mToken);

                case 2:
                    return new ATNConditionFToDoTransNode_v2(context, mSameNode, mInitAction, mToken);

                default:
                    throw new ArgumentOutOfRangeException(nameof(mNumberOfConstructor), mNumberOfConstructor, null);
            }
        }
    }

/*Sub states:
    Condition_FToDo_Subj_Trans
    Condition_FToDo_Not_Trans
*/

    public class ATNConditionFToDoTransNode_v2: BaseATNNode_v2
    {
        public ATNConditionFToDoTransNode_v2(ContextOfATNParsing_v2 context, ATNConditionTransNode_v2 parentNode, ATNExtendedToken token)
            : base(context, token)
        {
            ParentNode = parentNode;
        }

        public ATNConditionFToDoTransNode_v2(ContextOfATNParsing_v2 context, ATNConditionFToDoTransNode_v2 sameNode, InitATNConditionFToDoTransNodeAction initAction, ATNExtendedToken token)
            : base(context, token)
        {
            mSameNode = sameNode;
            mInitAction = initAction;
            ParentNode = mSameNode.ParentNode;
            mInitAction?.Invoke(this);
        }

        public override StateOfATNParsing_v2 GlobalState => StateOfATNParsing_v2.Condition_FToDo_Trans;

        public ATNConditionTransNode_v2 ParentNode { get; private set; }
        private ATNConditionFToDoTransNode_v2 mSameNode;
        private InitATNConditionFToDoTransNodeAction mInitAction;

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

