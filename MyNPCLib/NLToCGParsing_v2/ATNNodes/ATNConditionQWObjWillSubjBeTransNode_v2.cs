using MyNPCLib.NLToCGParsing;
using System;
using System.Collections.Generic;
using System.Text;

namespace MyNPCLib.NLToCGParsing_v2.ATNNodes
{
    public delegate void InitATNConditionQWObjWillSubjBeTransNodeAction(ATNConditionQWObjWillSubjBeTransNode_v2 item);

    public class ATNConditionQWObjWillSubjBeTransNodeFactory_v2: BaseATNNodeFactory_v2
    {
        public ATNConditionQWObjWillSubjBeTransNodeFactory_v2(ATNConditionQWObjWillSubjTransNode_v2 parentNode, ATNExtendedToken token)
        {
            mNumberOfConstructor = 1;
            mParentNode = parentNode;
            mToken = token;
        }

        public ATNConditionQWObjWillSubjBeTransNodeFactory_v2(ATNConditionQWObjWillSubjBeTransNode_v2 sameNode, ATNExtendedToken token, InitATNConditionQWObjWillSubjBeTransNodeAction initAction)
        {
            mNumberOfConstructor = 2;
            mSameNode = sameNode;
            mToken = token;
            mInitAction = initAction;
        }

        private int mNumberOfConstructor;
        private ATNConditionQWObjWillSubjTransNode_v2 mParentNode;
        private ATNConditionQWObjWillSubjBeTransNode_v2 mSameNode;
        private ATNExtendedToken mToken;
        private InitATNConditionQWObjWillSubjBeTransNodeAction mInitAction;

        public override BaseATNNode_v2 Create(ContextOfATNParsing_v2 context)
        {
            switch(mNumberOfConstructor)
            {
                case 1:
                    return new ATNConditionQWObjWillSubjBeTransNode_v2(context, mParentNode, mToken);

                case 2:
                    return new ATNConditionQWObjWillSubjBeTransNode_v2(context, mSameNode, mInitAction, mToken);

                default:
                    throw new ArgumentOutOfRangeException(nameof(mNumberOfConstructor), mNumberOfConstructor, null);
            }
        }
    }

/*Sub states:
    Condition_QWObj_Will_Subj_Be_Ving_TransOrFin
    Condition_QWObj_Will_Subj_Be_V3_TransOrFin
    Condition_QWObj_Will_Subj_Be_Condition_Trans
*/

    public class ATNConditionQWObjWillSubjBeTransNode_v2: BaseATNNode_v2
    {
        public ATNConditionQWObjWillSubjBeTransNode_v2(ContextOfATNParsing_v2 context, ATNConditionQWObjWillSubjTransNode_v2 parentNode, ATNExtendedToken token)
            : base(context, token)
        {
            ParentNode = parentNode;
        }

        public ATNConditionQWObjWillSubjBeTransNode_v2(ContextOfATNParsing_v2 context, ATNConditionQWObjWillSubjBeTransNode_v2 sameNode, InitATNConditionQWObjWillSubjBeTransNodeAction initAction, ATNExtendedToken token)
            : base(context, token)
        {
            mSameNode = sameNode;
            mInitAction = initAction;
            ParentNode = mSameNode.ParentNode;
            mInitAction?.Invoke(this);
        }

        public override StateOfATNParsing_v2 GlobalState => StateOfATNParsing_v2.Condition_QWObj_Will_Subj_Be_Trans;

        public ATNConditionQWObjWillSubjTransNode_v2 ParentNode { get; private set; }
        private ATNConditionQWObjWillSubjBeTransNode_v2 mSameNode;
        private InitATNConditionQWObjWillSubjBeTransNodeAction mInitAction;

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

