using MyNPCLib.NLToCGParsing;
using System;
using System.Collections.Generic;
using System.Text;

namespace MyNPCLib.NLToCGParsing_v2.ATNNodes
{
    public delegate void InitATNConditionQWSubjConditionVerbTransOrFinNodeAction(ATNConditionQWSubjConditionVerbTransOrFinNode_v2 item);

    public class ATNConditionQWSubjConditionVerbTransOrFinNodeFactory_v2: BaseATNNodeFactory_v2
    {
        public ATNConditionQWSubjConditionVerbTransOrFinNodeFactory_v2(ATNConditionQWSubjConditionTransNode_v2 parentNode, ATNExtendedToken token)
        {
            mNumberOfConstructor = 1;
            mParentNode = parentNode;
            mToken = token;
        }

        public ATNConditionQWSubjConditionVerbTransOrFinNodeFactory_v2(ATNConditionQWSubjConditionVerbTransOrFinNode_v2 sameNode, ATNExtendedToken token, InitATNConditionQWSubjConditionVerbTransOrFinNodeAction initAction)
        {
            mNumberOfConstructor = 2;
            mSameNode = sameNode;
            mToken = token;
            mInitAction = initAction;
        }

        private int mNumberOfConstructor;
        private ATNConditionQWSubjConditionTransNode_v2 mParentNode;
        private ATNConditionQWSubjConditionVerbTransOrFinNode_v2 mSameNode;
        private ATNExtendedToken mToken;
        private InitATNConditionQWSubjConditionVerbTransOrFinNodeAction mInitAction;

        public override BaseATNNode_v2 Create(ContextOfATNParsing_v2 context)
        {
            switch(mNumberOfConstructor)
            {
                case 1:
                    return new ATNConditionQWSubjConditionVerbTransOrFinNode_v2(context, mParentNode, mToken);

                case 2:
                    return new ATNConditionQWSubjConditionVerbTransOrFinNode_v2(context, mSameNode, mInitAction, mToken);

                default:
                    throw new ArgumentOutOfRangeException(nameof(mNumberOfConstructor), mNumberOfConstructor, null);
            }
        }
    }

/*Sub states:
    Condition_QWSubj_Condition_Verb_Obj_TransOrFin
    Condition_QWSubj_Condition_Verb_No_Trans
    Condition_QWSubj_Condition_Verb_Condition_Fin
*/

    public class ATNConditionQWSubjConditionVerbTransOrFinNode_v2: BaseATNNode_v2
    {
        public ATNConditionQWSubjConditionVerbTransOrFinNode_v2(ContextOfATNParsing_v2 context, ATNConditionQWSubjConditionTransNode_v2 parentNode, ATNExtendedToken token)
            : base(context, token)
        {
            ParentNode = parentNode;
        }

        public ATNConditionQWSubjConditionVerbTransOrFinNode_v2(ContextOfATNParsing_v2 context, ATNConditionQWSubjConditionVerbTransOrFinNode_v2 sameNode, InitATNConditionQWSubjConditionVerbTransOrFinNodeAction initAction, ATNExtendedToken token)
            : base(context, token)
        {
            mSameNode = sameNode;
            mInitAction = initAction;
            ParentNode = mSameNode.ParentNode;
            mInitAction?.Invoke(this);
        }

        public override StateOfATNParsing_v2 GlobalState => StateOfATNParsing_v2.Condition_QWSubj_Condition_Verb_TransOrFin;

        public ATNConditionQWSubjConditionTransNode_v2 ParentNode { get; private set; }
        private ATNConditionQWSubjConditionVerbTransOrFinNode_v2 mSameNode;
        private InitATNConditionQWSubjConditionVerbTransOrFinNodeAction mInitAction;

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

