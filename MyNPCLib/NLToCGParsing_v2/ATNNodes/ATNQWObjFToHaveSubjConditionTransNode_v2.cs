using MyNPCLib.NLToCGParsing;
using System;
using System.Collections.Generic;
using System.Text;

namespace MyNPCLib.NLToCGParsing_v2.ATNNodes
{
    public delegate void InitATNQWObjFToHaveSubjConditionTransNodeAction(ATNQWObjFToHaveSubjConditionTransNode_v2 item);

    public class ATNQWObjFToHaveSubjConditionTransNodeFactory_v2: BaseATNNodeFactory_v2
    {
        public ATNQWObjFToHaveSubjConditionTransNodeFactory_v2(ATNQWObjFToHaveSubjTransNode_v2 parentNode, ATNExtendedToken token)
        {
            mNumberOfConstructor = 1;
            mParentNode = parentNode;
            mToken = token;
        }

        public ATNQWObjFToHaveSubjConditionTransNodeFactory_v2(ATNQWObjFToHaveSubjConditionTransNode_v2 sameNode, ATNExtendedToken token, InitATNQWObjFToHaveSubjConditionTransNodeAction initAction)
        {
            mNumberOfConstructor = 2;
            mSameNode = sameNode;
            mToken = token;
            mInitAction = initAction;
        }

        private int mNumberOfConstructor;
        private ATNQWObjFToHaveSubjTransNode_v2 mParentNode;
        private ATNQWObjFToHaveSubjConditionTransNode_v2 mSameNode;
        private ATNExtendedToken mToken;
        private InitATNQWObjFToHaveSubjConditionTransNodeAction mInitAction;

        public override BaseATNNode_v2 Create(ContextOfATNParsing_v2 context)
        {
            switch(mNumberOfConstructor)
            {
                case 1:
                    return new ATNQWObjFToHaveSubjConditionTransNode_v2(context, mParentNode, mToken);

                case 2:
                    return new ATNQWObjFToHaveSubjConditionTransNode_v2(context, mSameNode, mInitAction, mToken);

                default:
                    throw new ArgumentOutOfRangeException(nameof(mNumberOfConstructor), mNumberOfConstructor, null);
            }
        }
    }

/*Sub states:
    QWObj_FToHave_Subj_Condition_V3_TransOrFin
*/

    public class ATNQWObjFToHaveSubjConditionTransNode_v2: BaseATNNode_v2
    {
        public ATNQWObjFToHaveSubjConditionTransNode_v2(ContextOfATNParsing_v2 context, ATNQWObjFToHaveSubjTransNode_v2 parentNode, ATNExtendedToken token)
            : base(context, token)
        {
            ParentNode = parentNode;
        }

        public ATNQWObjFToHaveSubjConditionTransNode_v2(ContextOfATNParsing_v2 context, ATNQWObjFToHaveSubjConditionTransNode_v2 sameNode, InitATNQWObjFToHaveSubjConditionTransNodeAction initAction, ATNExtendedToken token)
            : base(context, token)
        {
            mSameNode = sameNode;
            mInitAction = initAction;
            ParentNode = mSameNode.ParentNode;
            mInitAction?.Invoke(this);
        }

        public override StateOfATNParsing_v2 GlobalState => StateOfATNParsing_v2.QWObj_FToHave_Subj_Condition_Trans;

        public ATNQWObjFToHaveSubjTransNode_v2 ParentNode { get; private set; }
        private ATNQWObjFToHaveSubjConditionTransNode_v2 mSameNode;
        private InitATNQWObjFToHaveSubjConditionTransNodeAction mInitAction;

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

