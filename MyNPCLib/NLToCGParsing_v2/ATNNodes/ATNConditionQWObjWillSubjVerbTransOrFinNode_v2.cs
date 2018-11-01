using MyNPCLib.NLToCGParsing;
using System;
using System.Collections.Generic;
using System.Text;

namespace MyNPCLib.NLToCGParsing_v2.ATNNodes
{
    public delegate void InitATNConditionQWObjWillSubjVerbTransOrFinNodeAction(ATNConditionQWObjWillSubjVerbTransOrFinNode_v2 item);

    public class ATNConditionQWObjWillSubjVerbTransOrFinNodeFactory_v2: BaseATNNodeFactory_v2
    {
        public ATNConditionQWObjWillSubjVerbTransOrFinNodeFactory_v2(ATNConditionQWObjWillSubjTransNode_v2 parentNode, ATNExtendedToken token)
        {
            mNumberOfConstructor = 1;
            mParentNode = parentNode;
            mToken = token;
        }

        public ATNConditionQWObjWillSubjVerbTransOrFinNodeFactory_v2(ATNConditionQWObjWillSubjVerbTransOrFinNode_v2 sameNode, ATNExtendedToken token, InitATNConditionQWObjWillSubjVerbTransOrFinNodeAction initAction)
        {
            mNumberOfConstructor = 2;
            mSameNode = sameNode;
            mToken = token;
            mInitAction = initAction;
        }

        private int mNumberOfConstructor;
        private ATNConditionQWObjWillSubjTransNode_v2 mParentNode;
        private ATNConditionQWObjWillSubjVerbTransOrFinNode_v2 mSameNode;
        private ATNExtendedToken mToken;
        private InitATNConditionQWObjWillSubjVerbTransOrFinNodeAction mInitAction;

        public override BaseATNNode_v2 Create(ContextOfATNParsing_v2 context)
        {
            switch(mNumberOfConstructor)
            {
                case 1:
                    return new ATNConditionQWObjWillSubjVerbTransOrFinNode_v2(context, mParentNode, mToken);

                case 2:
                    return new ATNConditionQWObjWillSubjVerbTransOrFinNode_v2(context, mSameNode, mInitAction, mToken);

                default:
                    throw new ArgumentOutOfRangeException(nameof(mNumberOfConstructor), mNumberOfConstructor, null);
            }
        }
    }

/*Sub states:
    Condition_QWObj_Will_Subj_Verb_Condition_Fin
*/

    public class ATNConditionQWObjWillSubjVerbTransOrFinNode_v2: BaseATNNode_v2
    {
        public ATNConditionQWObjWillSubjVerbTransOrFinNode_v2(ContextOfATNParsing_v2 context, ATNConditionQWObjWillSubjTransNode_v2 parentNode, ATNExtendedToken token)
            : base(context, token)
        {
            ParentNode = parentNode;
        }

        public ATNConditionQWObjWillSubjVerbTransOrFinNode_v2(ContextOfATNParsing_v2 context, ATNConditionQWObjWillSubjVerbTransOrFinNode_v2 sameNode, InitATNConditionQWObjWillSubjVerbTransOrFinNodeAction initAction, ATNExtendedToken token)
            : base(context, token)
        {
            mSameNode = sameNode;
            mInitAction = initAction;
            ParentNode = mSameNode.ParentNode;
            mInitAction?.Invoke(this);
        }

        public override StateOfATNParsing_v2 GlobalState => StateOfATNParsing_v2.Condition_QWObj_Will_Subj_Verb_TransOrFin;

        public ATNConditionQWObjWillSubjTransNode_v2 ParentNode { get; private set; }
        private ATNConditionQWObjWillSubjVerbTransOrFinNode_v2 mSameNode;
        private InitATNConditionQWObjWillSubjVerbTransOrFinNodeAction mInitAction;

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

