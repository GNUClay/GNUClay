using MyNPCLib.NLToCGParsing;
using System;
using System.Collections.Generic;
using System.Text;

namespace MyNPCLib.NLToCGParsing_v2.ATNNodes
{
    public delegate void InitATNQWSubjWillConditionVerbTransOrFinNodeAction(ATNQWSubjWillConditionVerbTransOrFinNode_v2 item);

    public class ATNQWSubjWillConditionVerbTransOrFinNodeFactory_v2: BaseATNNodeFactory_v2
    {
        public ATNQWSubjWillConditionVerbTransOrFinNodeFactory_v2(ATNQWSubjWillConditionTransNode_v2 parentNode, ATNExtendedToken token)
        {
            mNumberOfConstructor = 1;
            mParentNode = parentNode;
            mToken = token;
        }

        public ATNQWSubjWillConditionVerbTransOrFinNodeFactory_v2(ATNQWSubjWillConditionVerbTransOrFinNode_v2 sameNode, ATNExtendedToken token, InitATNQWSubjWillConditionVerbTransOrFinNodeAction initAction)
        {
            mNumberOfConstructor = 2;
            mSameNode = sameNode;
            mToken = token;
            mInitAction = initAction;
        }

        private int mNumberOfConstructor;
        private ATNQWSubjWillConditionTransNode_v2 mParentNode;
        private ATNQWSubjWillConditionVerbTransOrFinNode_v2 mSameNode;
        private ATNExtendedToken mToken;
        private InitATNQWSubjWillConditionVerbTransOrFinNodeAction mInitAction;

        public override BaseATNNode_v2 Create(ContextOfATNParsing_v2 context)
        {
            switch(mNumberOfConstructor)
            {
                case 1:
                    return new ATNQWSubjWillConditionVerbTransOrFinNode_v2(context, mParentNode, mToken);

                case 2:
                    return new ATNQWSubjWillConditionVerbTransOrFinNode_v2(context, mSameNode, mInitAction, mToken);

                default:
                    throw new ArgumentOutOfRangeException(nameof(mNumberOfConstructor), mNumberOfConstructor, null);
            }
        }
    }

/*Sub states:
    QWSubj_Will_Condition_Verb_Obj_TransOrFin
    QWSubj_Will_Condition_Verb_No_Trans
    QWSubj_Will_Condition_Verb_Condition_Fin
*/

    public class ATNQWSubjWillConditionVerbTransOrFinNode_v2: BaseATNNode_v2
    {
        public ATNQWSubjWillConditionVerbTransOrFinNode_v2(ContextOfATNParsing_v2 context, ATNQWSubjWillConditionTransNode_v2 parentNode, ATNExtendedToken token)
            : base(context, token)
        {
            ParentNode = parentNode;
        }

        public ATNQWSubjWillConditionVerbTransOrFinNode_v2(ContextOfATNParsing_v2 context, ATNQWSubjWillConditionVerbTransOrFinNode_v2 sameNode, InitATNQWSubjWillConditionVerbTransOrFinNodeAction initAction, ATNExtendedToken token)
            : base(context, token)
        {
            mSameNode = sameNode;
            mInitAction = initAction;
            ParentNode = mSameNode.ParentNode;
            mInitAction?.Invoke(this);
        }

        public override StateOfATNParsing_v2 GlobalState => StateOfATNParsing_v2.QWSubj_Will_Condition_Verb_TransOrFin;

        public ATNQWSubjWillConditionTransNode_v2 ParentNode { get; private set; }
        private ATNQWSubjWillConditionVerbTransOrFinNode_v2 mSameNode;
        private InitATNQWSubjWillConditionVerbTransOrFinNodeAction mInitAction;

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

