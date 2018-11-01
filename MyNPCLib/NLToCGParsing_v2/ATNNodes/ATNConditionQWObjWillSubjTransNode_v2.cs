using MyNPCLib.NLToCGParsing;
using System;
using System.Collections.Generic;
using System.Text;

namespace MyNPCLib.NLToCGParsing_v2.ATNNodes
{
    public delegate void InitATNConditionQWObjWillSubjTransNodeAction(ATNConditionQWObjWillSubjTransNode_v2 item);

    public class ATNConditionQWObjWillSubjTransNodeFactory_v2: BaseATNNodeFactory_v2
    {
        public ATNConditionQWObjWillSubjTransNodeFactory_v2(ATNConditionQWObjWillTransNode_v2 parentNode, ATNExtendedToken token)
        {
            mNumberOfConstructor = 1;
            mParentNode = parentNode;
            mToken = token;
        }

        public ATNConditionQWObjWillSubjTransNodeFactory_v2(ATNConditionQWObjWillSubjTransNode_v2 sameNode, ATNExtendedToken token, InitATNConditionQWObjWillSubjTransNodeAction initAction)
        {
            mNumberOfConstructor = 2;
            mSameNode = sameNode;
            mToken = token;
            mInitAction = initAction;
        }

        private int mNumberOfConstructor;
        private ATNConditionQWObjWillTransNode_v2 mParentNode;
        private ATNConditionQWObjWillSubjTransNode_v2 mSameNode;
        private ATNExtendedToken mToken;
        private InitATNConditionQWObjWillSubjTransNodeAction mInitAction;

        public override BaseATNNode_v2 Create(ContextOfATNParsing_v2 context)
        {
            switch(mNumberOfConstructor)
            {
                case 1:
                    return new ATNConditionQWObjWillSubjTransNode_v2(context, mParentNode, mToken);

                case 2:
                    return new ATNConditionQWObjWillSubjTransNode_v2(context, mSameNode, mInitAction, mToken);

                default:
                    throw new ArgumentOutOfRangeException(nameof(mNumberOfConstructor), mNumberOfConstructor, null);
            }
        }
    }

/*Sub states:
    Condition_QWObj_Will_Subj_Verb_TransOrFin
    Condition_QWObj_Will_Subj_Be_Trans
    Condition_QWObj_Will_Subj_FToHave_Trans
    Condition_QWObj_Will_Subj_Condition_Trans
*/

    public class ATNConditionQWObjWillSubjTransNode_v2: BaseATNNode_v2
    {
        public ATNConditionQWObjWillSubjTransNode_v2(ContextOfATNParsing_v2 context, ATNConditionQWObjWillTransNode_v2 parentNode, ATNExtendedToken token)
            : base(context, token)
        {
            ParentNode = parentNode;
        }

        public ATNConditionQWObjWillSubjTransNode_v2(ContextOfATNParsing_v2 context, ATNConditionQWObjWillSubjTransNode_v2 sameNode, InitATNConditionQWObjWillSubjTransNodeAction initAction, ATNExtendedToken token)
            : base(context, token)
        {
            mSameNode = sameNode;
            mInitAction = initAction;
            ParentNode = mSameNode.ParentNode;
            mInitAction?.Invoke(this);
        }

        public override StateOfATNParsing_v2 GlobalState => StateOfATNParsing_v2.Condition_QWObj_Will_Subj_Trans;

        public ATNConditionQWObjWillTransNode_v2 ParentNode { get; private set; }
        private ATNConditionQWObjWillSubjTransNode_v2 mSameNode;
        private InitATNConditionQWObjWillSubjTransNodeAction mInitAction;

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

