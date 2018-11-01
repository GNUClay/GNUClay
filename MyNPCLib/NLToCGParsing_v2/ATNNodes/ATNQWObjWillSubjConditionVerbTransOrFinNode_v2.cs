using MyNPCLib.NLToCGParsing;
using System;
using System.Collections.Generic;
using System.Text;

namespace MyNPCLib.NLToCGParsing_v2.ATNNodes
{
    public delegate void InitATNQWObjWillSubjConditionVerbTransOrFinNodeAction(ATNQWObjWillSubjConditionVerbTransOrFinNode_v2 item);

    public class ATNQWObjWillSubjConditionVerbTransOrFinNodeFactory_v2: BaseATNNodeFactory_v2
    {
        public ATNQWObjWillSubjConditionVerbTransOrFinNodeFactory_v2(ATNQWObjWillSubjConditionTransNode_v2 parentNode, ATNExtendedToken token)
        {
            mNumberOfConstructor = 1;
            mParentNode = parentNode;
            mToken = token;
        }

        public ATNQWObjWillSubjConditionVerbTransOrFinNodeFactory_v2(ATNQWObjWillSubjConditionVerbTransOrFinNode_v2 sameNode, ATNExtendedToken token, InitATNQWObjWillSubjConditionVerbTransOrFinNodeAction initAction)
        {
            mNumberOfConstructor = 2;
            mSameNode = sameNode;
            mToken = token;
            mInitAction = initAction;
        }

        private int mNumberOfConstructor;
        private ATNQWObjWillSubjConditionTransNode_v2 mParentNode;
        private ATNQWObjWillSubjConditionVerbTransOrFinNode_v2 mSameNode;
        private ATNExtendedToken mToken;
        private InitATNQWObjWillSubjConditionVerbTransOrFinNodeAction mInitAction;

        public override BaseATNNode_v2 Create(ContextOfATNParsing_v2 context)
        {
            switch(mNumberOfConstructor)
            {
                case 1:
                    return new ATNQWObjWillSubjConditionVerbTransOrFinNode_v2(context, mParentNode, mToken);

                case 2:
                    return new ATNQWObjWillSubjConditionVerbTransOrFinNode_v2(context, mSameNode, mInitAction, mToken);

                default:
                    throw new ArgumentOutOfRangeException(nameof(mNumberOfConstructor), mNumberOfConstructor, null);
            }
        }
    }

/*Sub states:
    QWObj_Will_Subj_Condition_Verb_Condition_Fin
*/

    public class ATNQWObjWillSubjConditionVerbTransOrFinNode_v2: BaseATNNode_v2
    {
        public ATNQWObjWillSubjConditionVerbTransOrFinNode_v2(ContextOfATNParsing_v2 context, ATNQWObjWillSubjConditionTransNode_v2 parentNode, ATNExtendedToken token)
            : base(context, token)
        {
            ParentNode = parentNode;
        }

        public ATNQWObjWillSubjConditionVerbTransOrFinNode_v2(ContextOfATNParsing_v2 context, ATNQWObjWillSubjConditionVerbTransOrFinNode_v2 sameNode, InitATNQWObjWillSubjConditionVerbTransOrFinNodeAction initAction, ATNExtendedToken token)
            : base(context, token)
        {
            mSameNode = sameNode;
            mInitAction = initAction;
            ParentNode = mSameNode.ParentNode;
            mInitAction?.Invoke(this);
        }

        public override StateOfATNParsing_v2 GlobalState => StateOfATNParsing_v2.QWObj_Will_Subj_Condition_Verb_TransOrFin;

        public ATNQWObjWillSubjConditionTransNode_v2 ParentNode { get; private set; }
        private ATNQWObjWillSubjConditionVerbTransOrFinNode_v2 mSameNode;
        private InitATNQWObjWillSubjConditionVerbTransOrFinNodeAction mInitAction;

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

