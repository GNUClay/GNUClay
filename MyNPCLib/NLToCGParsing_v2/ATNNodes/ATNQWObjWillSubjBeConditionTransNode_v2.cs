using MyNPCLib.NLToCGParsing;
using System;
using System.Collections.Generic;
using System.Text;

namespace MyNPCLib.NLToCGParsing_v2.ATNNodes
{
    public delegate void InitATNQWObjWillSubjBeConditionTransNodeAction(ATNQWObjWillSubjBeConditionTransNode_v2 item);

    public class ATNQWObjWillSubjBeConditionTransNodeFactory_v2: BaseATNNodeFactory_v2
    {
        public ATNQWObjWillSubjBeConditionTransNodeFactory_v2(ATNQWObjWillSubjBeTransNode_v2 parentNode, ATNExtendedToken token)
        {
            mNumberOfConstructor = 1;
            mParentNode = parentNode;
            mToken = token;
        }

        public ATNQWObjWillSubjBeConditionTransNodeFactory_v2(ATNQWObjWillSubjBeConditionTransNode_v2 sameNode, ATNExtendedToken token, InitATNQWObjWillSubjBeConditionTransNodeAction initAction)
        {
            mNumberOfConstructor = 2;
            mSameNode = sameNode;
            mToken = token;
            mInitAction = initAction;
        }

        private int mNumberOfConstructor;
        private ATNQWObjWillSubjBeTransNode_v2 mParentNode;
        private ATNQWObjWillSubjBeConditionTransNode_v2 mSameNode;
        private ATNExtendedToken mToken;
        private InitATNQWObjWillSubjBeConditionTransNodeAction mInitAction;

        public override BaseATNNode_v2 Create(ContextOfATNParsing_v2 context)
        {
            switch(mNumberOfConstructor)
            {
                case 1:
                    return new ATNQWObjWillSubjBeConditionTransNode_v2(context, mParentNode, mToken);

                case 2:
                    return new ATNQWObjWillSubjBeConditionTransNode_v2(context, mSameNode, mInitAction, mToken);

                default:
                    throw new ArgumentOutOfRangeException(nameof(mNumberOfConstructor), mNumberOfConstructor, null);
            }
        }
    }

/*Sub states:
    QWObj_Will_Subj_Be_Condition_Ving_TransOrFin
    QWObj_Will_Subj_Be_Condition_V3_TransOrFin
*/

    public class ATNQWObjWillSubjBeConditionTransNode_v2: BaseATNNode_v2
    {
        public ATNQWObjWillSubjBeConditionTransNode_v2(ContextOfATNParsing_v2 context, ATNQWObjWillSubjBeTransNode_v2 parentNode, ATNExtendedToken token)
            : base(context, token)
        {
            ParentNode = parentNode;
        }

        public ATNQWObjWillSubjBeConditionTransNode_v2(ContextOfATNParsing_v2 context, ATNQWObjWillSubjBeConditionTransNode_v2 sameNode, InitATNQWObjWillSubjBeConditionTransNodeAction initAction, ATNExtendedToken token)
            : base(context, token)
        {
            mSameNode = sameNode;
            mInitAction = initAction;
            ParentNode = mSameNode.ParentNode;
            mInitAction?.Invoke(this);
        }

        public override StateOfATNParsing_v2 GlobalState => StateOfATNParsing_v2.QWObj_Will_Subj_Be_Condition_Trans;

        public ATNQWObjWillSubjBeTransNode_v2 ParentNode { get; private set; }
        private ATNQWObjWillSubjBeConditionTransNode_v2 mSameNode;
        private InitATNQWObjWillSubjBeConditionTransNodeAction mInitAction;

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

