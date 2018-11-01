using MyNPCLib.NLToCGParsing;
using System;
using System.Collections.Generic;
using System.Text;

namespace MyNPCLib.NLToCGParsing_v2.ATNNodes
{
    public delegate void InitATNConditionFToDoSubjVerbNoTransNodeAction(ATNConditionFToDoSubjVerbNoTransNode_v2 item);

    public class ATNConditionFToDoSubjVerbNoTransNodeFactory_v2: BaseATNNodeFactory_v2
    {
        public ATNConditionFToDoSubjVerbNoTransNodeFactory_v2(ATNConditionFToDoSubjVerbTransOrFinNode_v2 parentNode, ATNExtendedToken token)
        {
            mNumberOfConstructor = 1;
            mParentNode = parentNode;
            mToken = token;
        }

        public ATNConditionFToDoSubjVerbNoTransNodeFactory_v2(ATNConditionFToDoSubjVerbNoTransNode_v2 sameNode, ATNExtendedToken token, InitATNConditionFToDoSubjVerbNoTransNodeAction initAction)
        {
            mNumberOfConstructor = 2;
            mSameNode = sameNode;
            mToken = token;
            mInitAction = initAction;
        }

        private int mNumberOfConstructor;
        private ATNConditionFToDoSubjVerbTransOrFinNode_v2 mParentNode;
        private ATNConditionFToDoSubjVerbNoTransNode_v2 mSameNode;
        private ATNExtendedToken mToken;
        private InitATNConditionFToDoSubjVerbNoTransNodeAction mInitAction;

        public override BaseATNNode_v2 Create(ContextOfATNParsing_v2 context)
        {
            switch(mNumberOfConstructor)
            {
                case 1:
                    return new ATNConditionFToDoSubjVerbNoTransNode_v2(context, mParentNode, mToken);

                case 2:
                    return new ATNConditionFToDoSubjVerbNoTransNode_v2(context, mSameNode, mInitAction, mToken);

                default:
                    throw new ArgumentOutOfRangeException(nameof(mNumberOfConstructor), mNumberOfConstructor, null);
            }
        }
    }

/*Sub states:
    Condition_FToDo_Subj_Verb_No_Obj_TransOrFin
*/

    public class ATNConditionFToDoSubjVerbNoTransNode_v2: BaseATNNode_v2
    {
        public ATNConditionFToDoSubjVerbNoTransNode_v2(ContextOfATNParsing_v2 context, ATNConditionFToDoSubjVerbTransOrFinNode_v2 parentNode, ATNExtendedToken token)
            : base(context, token)
        {
            ParentNode = parentNode;
        }

        public ATNConditionFToDoSubjVerbNoTransNode_v2(ContextOfATNParsing_v2 context, ATNConditionFToDoSubjVerbNoTransNode_v2 sameNode, InitATNConditionFToDoSubjVerbNoTransNodeAction initAction, ATNExtendedToken token)
            : base(context, token)
        {
            mSameNode = sameNode;
            mInitAction = initAction;
            ParentNode = mSameNode.ParentNode;
            mInitAction?.Invoke(this);
        }

        public override StateOfATNParsing_v2 GlobalState => StateOfATNParsing_v2.Condition_FToDo_Subj_Verb_No_Trans;

        public ATNConditionFToDoSubjVerbTransOrFinNode_v2 ParentNode { get; private set; }
        private ATNConditionFToDoSubjVerbNoTransNode_v2 mSameNode;
        private InitATNConditionFToDoSubjVerbNoTransNodeAction mInitAction;

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

