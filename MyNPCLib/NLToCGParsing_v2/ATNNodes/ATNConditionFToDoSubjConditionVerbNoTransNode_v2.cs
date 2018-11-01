using MyNPCLib.NLToCGParsing;
using System;
using System.Collections.Generic;
using System.Text;

namespace MyNPCLib.NLToCGParsing_v2.ATNNodes
{
    public delegate void InitATNConditionFToDoSubjConditionVerbNoTransNodeAction(ATNConditionFToDoSubjConditionVerbNoTransNode_v2 item);

    public class ATNConditionFToDoSubjConditionVerbNoTransNodeFactory_v2: BaseATNNodeFactory_v2
    {
        public ATNConditionFToDoSubjConditionVerbNoTransNodeFactory_v2(ATNConditionFToDoSubjConditionVerbTransOrFinNode_v2 parentNode, ATNExtendedToken token)
        {
            mNumberOfConstructor = 1;
            mParentNode = parentNode;
            mToken = token;
        }

        public ATNConditionFToDoSubjConditionVerbNoTransNodeFactory_v2(ATNConditionFToDoSubjConditionVerbNoTransNode_v2 sameNode, ATNExtendedToken token, InitATNConditionFToDoSubjConditionVerbNoTransNodeAction initAction)
        {
            mNumberOfConstructor = 2;
            mSameNode = sameNode;
            mToken = token;
            mInitAction = initAction;
        }

        private int mNumberOfConstructor;
        private ATNConditionFToDoSubjConditionVerbTransOrFinNode_v2 mParentNode;
        private ATNConditionFToDoSubjConditionVerbNoTransNode_v2 mSameNode;
        private ATNExtendedToken mToken;
        private InitATNConditionFToDoSubjConditionVerbNoTransNodeAction mInitAction;

        public override BaseATNNode_v2 Create(ContextOfATNParsing_v2 context)
        {
            switch(mNumberOfConstructor)
            {
                case 1:
                    return new ATNConditionFToDoSubjConditionVerbNoTransNode_v2(context, mParentNode, mToken);

                case 2:
                    return new ATNConditionFToDoSubjConditionVerbNoTransNode_v2(context, mSameNode, mInitAction, mToken);

                default:
                    throw new ArgumentOutOfRangeException(nameof(mNumberOfConstructor), mNumberOfConstructor, null);
            }
        }
    }

/*Sub states:
    Condition_FToDo_Subj_Condition_Verb_No_Obj_TransOrFin
*/

    public class ATNConditionFToDoSubjConditionVerbNoTransNode_v2: BaseATNNode_v2
    {
        public ATNConditionFToDoSubjConditionVerbNoTransNode_v2(ContextOfATNParsing_v2 context, ATNConditionFToDoSubjConditionVerbTransOrFinNode_v2 parentNode, ATNExtendedToken token)
            : base(context, token)
        {
            ParentNode = parentNode;
        }

        public ATNConditionFToDoSubjConditionVerbNoTransNode_v2(ContextOfATNParsing_v2 context, ATNConditionFToDoSubjConditionVerbNoTransNode_v2 sameNode, InitATNConditionFToDoSubjConditionVerbNoTransNodeAction initAction, ATNExtendedToken token)
            : base(context, token)
        {
            mSameNode = sameNode;
            mInitAction = initAction;
            ParentNode = mSameNode.ParentNode;
            mInitAction?.Invoke(this);
        }

        public override StateOfATNParsing_v2 GlobalState => StateOfATNParsing_v2.Condition_FToDo_Subj_Condition_Verb_No_Trans;

        public ATNConditionFToDoSubjConditionVerbTransOrFinNode_v2 ParentNode { get; private set; }
        private ATNConditionFToDoSubjConditionVerbNoTransNode_v2 mSameNode;
        private InitATNConditionFToDoSubjConditionVerbNoTransNodeAction mInitAction;

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

