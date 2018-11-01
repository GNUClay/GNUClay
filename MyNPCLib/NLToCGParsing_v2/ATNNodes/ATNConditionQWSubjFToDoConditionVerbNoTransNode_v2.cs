using MyNPCLib.NLToCGParsing;
using System;
using System.Collections.Generic;
using System.Text;

namespace MyNPCLib.NLToCGParsing_v2.ATNNodes
{
    public delegate void InitATNConditionQWSubjFToDoConditionVerbNoTransNodeAction(ATNConditionQWSubjFToDoConditionVerbNoTransNode_v2 item);

    public class ATNConditionQWSubjFToDoConditionVerbNoTransNodeFactory_v2: BaseATNNodeFactory_v2
    {
        public ATNConditionQWSubjFToDoConditionVerbNoTransNodeFactory_v2(ATNConditionQWSubjFToDoConditionVerbTransOrFinNode_v2 parentNode, ATNExtendedToken token)
        {
            mNumberOfConstructor = 1;
            mParentNode = parentNode;
            mToken = token;
        }

        public ATNConditionQWSubjFToDoConditionVerbNoTransNodeFactory_v2(ATNConditionQWSubjFToDoConditionVerbNoTransNode_v2 sameNode, ATNExtendedToken token, InitATNConditionQWSubjFToDoConditionVerbNoTransNodeAction initAction)
        {
            mNumberOfConstructor = 2;
            mSameNode = sameNode;
            mToken = token;
            mInitAction = initAction;
        }

        private int mNumberOfConstructor;
        private ATNConditionQWSubjFToDoConditionVerbTransOrFinNode_v2 mParentNode;
        private ATNConditionQWSubjFToDoConditionVerbNoTransNode_v2 mSameNode;
        private ATNExtendedToken mToken;
        private InitATNConditionQWSubjFToDoConditionVerbNoTransNodeAction mInitAction;

        public override BaseATNNode_v2 Create(ContextOfATNParsing_v2 context)
        {
            switch(mNumberOfConstructor)
            {
                case 1:
                    return new ATNConditionQWSubjFToDoConditionVerbNoTransNode_v2(context, mParentNode, mToken);

                case 2:
                    return new ATNConditionQWSubjFToDoConditionVerbNoTransNode_v2(context, mSameNode, mInitAction, mToken);

                default:
                    throw new ArgumentOutOfRangeException(nameof(mNumberOfConstructor), mNumberOfConstructor, null);
            }
        }
    }

/*Sub states:
    Condition_QWSubj_FToDo_Condition_Verb_No_Obj_TransOrFin
*/

    public class ATNConditionQWSubjFToDoConditionVerbNoTransNode_v2: BaseATNNode_v2
    {
        public ATNConditionQWSubjFToDoConditionVerbNoTransNode_v2(ContextOfATNParsing_v2 context, ATNConditionQWSubjFToDoConditionVerbTransOrFinNode_v2 parentNode, ATNExtendedToken token)
            : base(context, token)
        {
            ParentNode = parentNode;
        }

        public ATNConditionQWSubjFToDoConditionVerbNoTransNode_v2(ContextOfATNParsing_v2 context, ATNConditionQWSubjFToDoConditionVerbNoTransNode_v2 sameNode, InitATNConditionQWSubjFToDoConditionVerbNoTransNodeAction initAction, ATNExtendedToken token)
            : base(context, token)
        {
            mSameNode = sameNode;
            mInitAction = initAction;
            ParentNode = mSameNode.ParentNode;
            mInitAction?.Invoke(this);
        }

        public override StateOfATNParsing_v2 GlobalState => StateOfATNParsing_v2.Condition_QWSubj_FToDo_Condition_Verb_No_Trans;

        public ATNConditionQWSubjFToDoConditionVerbTransOrFinNode_v2 ParentNode { get; private set; }
        private ATNConditionQWSubjFToDoConditionVerbNoTransNode_v2 mSameNode;
        private InitATNConditionQWSubjFToDoConditionVerbNoTransNodeAction mInitAction;

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

