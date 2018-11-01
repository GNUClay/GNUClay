using MyNPCLib.NLToCGParsing;
using System;
using System.Collections.Generic;
using System.Text;

namespace MyNPCLib.NLToCGParsing_v2.ATNNodes
{
    public delegate void InitATNQWSubjFToDoConditionVerbNoTransNodeAction(ATNQWSubjFToDoConditionVerbNoTransNode_v2 item);

    public class ATNQWSubjFToDoConditionVerbNoTransNodeFactory_v2: BaseATNNodeFactory_v2
    {
        public ATNQWSubjFToDoConditionVerbNoTransNodeFactory_v2(ATNQWSubjFToDoConditionVerbTransOrFinNode_v2 parentNode, ATNExtendedToken token)
        {
            mNumberOfConstructor = 1;
            mParentNode = parentNode;
            mToken = token;
        }

        public ATNQWSubjFToDoConditionVerbNoTransNodeFactory_v2(ATNQWSubjFToDoConditionVerbNoTransNode_v2 sameNode, ATNExtendedToken token, InitATNQWSubjFToDoConditionVerbNoTransNodeAction initAction)
        {
            mNumberOfConstructor = 2;
            mSameNode = sameNode;
            mToken = token;
            mInitAction = initAction;
        }

        private int mNumberOfConstructor;
        private ATNQWSubjFToDoConditionVerbTransOrFinNode_v2 mParentNode;
        private ATNQWSubjFToDoConditionVerbNoTransNode_v2 mSameNode;
        private ATNExtendedToken mToken;
        private InitATNQWSubjFToDoConditionVerbNoTransNodeAction mInitAction;

        public override BaseATNNode_v2 Create(ContextOfATNParsing_v2 context)
        {
            switch(mNumberOfConstructor)
            {
                case 1:
                    return new ATNQWSubjFToDoConditionVerbNoTransNode_v2(context, mParentNode, mToken);

                case 2:
                    return new ATNQWSubjFToDoConditionVerbNoTransNode_v2(context, mSameNode, mInitAction, mToken);

                default:
                    throw new ArgumentOutOfRangeException(nameof(mNumberOfConstructor), mNumberOfConstructor, null);
            }
        }
    }

/*Sub states:
    QWSubj_FToDo_Condition_Verb_No_Obj_TransOrFin
*/

    public class ATNQWSubjFToDoConditionVerbNoTransNode_v2: BaseATNNode_v2
    {
        public ATNQWSubjFToDoConditionVerbNoTransNode_v2(ContextOfATNParsing_v2 context, ATNQWSubjFToDoConditionVerbTransOrFinNode_v2 parentNode, ATNExtendedToken token)
            : base(context, token)
        {
            ParentNode = parentNode;
        }

        public ATNQWSubjFToDoConditionVerbNoTransNode_v2(ContextOfATNParsing_v2 context, ATNQWSubjFToDoConditionVerbNoTransNode_v2 sameNode, InitATNQWSubjFToDoConditionVerbNoTransNodeAction initAction, ATNExtendedToken token)
            : base(context, token)
        {
            mSameNode = sameNode;
            mInitAction = initAction;
            ParentNode = mSameNode.ParentNode;
            mInitAction?.Invoke(this);
        }

        public override StateOfATNParsing_v2 GlobalState => StateOfATNParsing_v2.QWSubj_FToDo_Condition_Verb_No_Trans;

        public ATNQWSubjFToDoConditionVerbTransOrFinNode_v2 ParentNode { get; private set; }
        private ATNQWSubjFToDoConditionVerbNoTransNode_v2 mSameNode;
        private InitATNQWSubjFToDoConditionVerbNoTransNodeAction mInitAction;

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

