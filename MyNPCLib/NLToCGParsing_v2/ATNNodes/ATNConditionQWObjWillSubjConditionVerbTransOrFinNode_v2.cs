using MyNPCLib.NLToCGParsing;
using System;
using System.Collections.Generic;
using System.Text;

namespace MyNPCLib.NLToCGParsing_v2.ATNNodes
{
    public delegate void InitATNConditionQWObjWillSubjConditionVerbTransOrFinNodeAction(ATNConditionQWObjWillSubjConditionVerbTransOrFinNode_v2 item);

    public class ATNConditionQWObjWillSubjConditionVerbTransOrFinNodeFactory_v2: BaseATNNodeFactory_v2
    {
        public ATNConditionQWObjWillSubjConditionVerbTransOrFinNodeFactory_v2(ATNConditionQWObjWillSubjConditionTransNode_v2 parentNode, ATNExtendedToken token)
        {
            mNumberOfConstructor = 1;
            mParentNode = parentNode;
            mToken = token;
        }

        public ATNConditionQWObjWillSubjConditionVerbTransOrFinNodeFactory_v2(ATNConditionQWObjWillSubjConditionVerbTransOrFinNode_v2 sameNode, ATNExtendedToken token, InitATNConditionQWObjWillSubjConditionVerbTransOrFinNodeAction initAction)
        {
            mNumberOfConstructor = 2;
            mSameNode = sameNode;
            mToken = token;
            mInitAction = initAction;
        }

        private int mNumberOfConstructor;
        private ATNConditionQWObjWillSubjConditionTransNode_v2 mParentNode;
        private ATNConditionQWObjWillSubjConditionVerbTransOrFinNode_v2 mSameNode;
        private ATNExtendedToken mToken;
        private InitATNConditionQWObjWillSubjConditionVerbTransOrFinNodeAction mInitAction;

        public override BaseATNNode_v2 Create(ContextOfATNParsing_v2 context)
        {
            switch(mNumberOfConstructor)
            {
                case 1:
                    return new ATNConditionQWObjWillSubjConditionVerbTransOrFinNode_v2(context, mParentNode, mToken);

                case 2:
                    return new ATNConditionQWObjWillSubjConditionVerbTransOrFinNode_v2(context, mSameNode, mInitAction, mToken);

                default:
                    throw new ArgumentOutOfRangeException(nameof(mNumberOfConstructor), mNumberOfConstructor, null);
            }
        }
    }

/*Sub states:
    Condition_QWObj_Will_Subj_Condition_Verb_Condition_Fin
*/

    public class ATNConditionQWObjWillSubjConditionVerbTransOrFinNode_v2: BaseATNNode_v2
    {
        public ATNConditionQWObjWillSubjConditionVerbTransOrFinNode_v2(ContextOfATNParsing_v2 context, ATNConditionQWObjWillSubjConditionTransNode_v2 parentNode, ATNExtendedToken token)
            : base(context, token)
        {
            ParentNode = parentNode;
        }

        public ATNConditionQWObjWillSubjConditionVerbTransOrFinNode_v2(ContextOfATNParsing_v2 context, ATNConditionQWObjWillSubjConditionVerbTransOrFinNode_v2 sameNode, InitATNConditionQWObjWillSubjConditionVerbTransOrFinNodeAction initAction, ATNExtendedToken token)
            : base(context, token)
        {
            mSameNode = sameNode;
            mInitAction = initAction;
            ParentNode = mSameNode.ParentNode;
            mInitAction?.Invoke(this);
        }

        public override StateOfATNParsing_v2 GlobalState => StateOfATNParsing_v2.Condition_QWObj_Will_Subj_Condition_Verb_TransOrFin;

        public ATNConditionQWObjWillSubjConditionTransNode_v2 ParentNode { get; private set; }
        private ATNConditionQWObjWillSubjConditionVerbTransOrFinNode_v2 mSameNode;
        private InitATNConditionQWObjWillSubjConditionVerbTransOrFinNodeAction mInitAction;

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

