using MyNPCLib.NLToCGParsing;
using System;
using System.Collections.Generic;
using System.Text;

namespace MyNPCLib.NLToCGParsing_v2.ATNNodes
{
    public delegate void InitATNConditionSubjFToDoNotTransNodeAction(ATNConditionSubjFToDoNotTransNode_v2 item);

    public class ATNConditionSubjFToDoNotTransNodeFactory_v2: BaseATNNodeFactory_v2
    {
        public ATNConditionSubjFToDoNotTransNodeFactory_v2(ATNConditionSubjFToDoTransNode_v2 parentNode, ATNExtendedToken token)
        {
            mNumberOfConstructor = 1;
            mParentNode = parentNode;
            mToken = token;
        }

        public ATNConditionSubjFToDoNotTransNodeFactory_v2(ATNConditionSubjFToDoNotTransNode_v2 sameNode, ATNExtendedToken token, InitATNConditionSubjFToDoNotTransNodeAction initAction)
        {
            mNumberOfConstructor = 2;
            mSameNode = sameNode;
            mToken = token;
            mInitAction = initAction;
        }

        private int mNumberOfConstructor;
        private ATNConditionSubjFToDoTransNode_v2 mParentNode;
        private ATNConditionSubjFToDoNotTransNode_v2 mSameNode;
        private ATNExtendedToken mToken;
        private InitATNConditionSubjFToDoNotTransNodeAction mInitAction;

        public override BaseATNNode_v2 Create(ContextOfATNParsing_v2 context)
        {
            switch(mNumberOfConstructor)
            {
                case 1:
                    return new ATNConditionSubjFToDoNotTransNode_v2(context, mParentNode, mToken);

                case 2:
                    return new ATNConditionSubjFToDoNotTransNode_v2(context, mSameNode, mInitAction, mToken);

                default:
                    throw new ArgumentOutOfRangeException(nameof(mNumberOfConstructor), mNumberOfConstructor, null);
            }
        }
    }

/*Sub states:
    Condition_Subj_FToDo_Not_Verb_TransOrFin
    Condition_Subj_FToDo_Not_Condition_Trans
*/

    public class ATNConditionSubjFToDoNotTransNode_v2: BaseATNNode_v2
    {
        public ATNConditionSubjFToDoNotTransNode_v2(ContextOfATNParsing_v2 context, ATNConditionSubjFToDoTransNode_v2 parentNode, ATNExtendedToken token)
            : base(context, token)
        {
            ParentNode = parentNode;
        }

        public ATNConditionSubjFToDoNotTransNode_v2(ContextOfATNParsing_v2 context, ATNConditionSubjFToDoNotTransNode_v2 sameNode, InitATNConditionSubjFToDoNotTransNodeAction initAction, ATNExtendedToken token)
            : base(context, token)
        {
            mSameNode = sameNode;
            mInitAction = initAction;
            ParentNode = mSameNode.ParentNode;
            mInitAction?.Invoke(this);
        }

        public override StateOfATNParsing_v2 GlobalState => StateOfATNParsing_v2.Condition_Subj_FToDo_Not_Trans;

        public ATNConditionSubjFToDoTransNode_v2 ParentNode { get; private set; }
        private ATNConditionSubjFToDoNotTransNode_v2 mSameNode;
        private InitATNConditionSubjFToDoNotTransNodeAction mInitAction;

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

