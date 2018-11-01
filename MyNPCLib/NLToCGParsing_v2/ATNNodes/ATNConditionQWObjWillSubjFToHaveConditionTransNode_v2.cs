using MyNPCLib.NLToCGParsing;
using System;
using System.Collections.Generic;
using System.Text;

namespace MyNPCLib.NLToCGParsing_v2.ATNNodes
{
    public delegate void InitATNConditionQWObjWillSubjFToHaveConditionTransNodeAction(ATNConditionQWObjWillSubjFToHaveConditionTransNode_v2 item);

    public class ATNConditionQWObjWillSubjFToHaveConditionTransNodeFactory_v2: BaseATNNodeFactory_v2
    {
        public ATNConditionQWObjWillSubjFToHaveConditionTransNodeFactory_v2(ATNConditionQWObjWillSubjFToHaveTransNode_v2 parentNode, ATNExtendedToken token)
        {
            mNumberOfConstructor = 1;
            mParentNode = parentNode;
            mToken = token;
        }

        public ATNConditionQWObjWillSubjFToHaveConditionTransNodeFactory_v2(ATNConditionQWObjWillSubjFToHaveConditionTransNode_v2 sameNode, ATNExtendedToken token, InitATNConditionQWObjWillSubjFToHaveConditionTransNodeAction initAction)
        {
            mNumberOfConstructor = 2;
            mSameNode = sameNode;
            mToken = token;
            mInitAction = initAction;
        }

        private int mNumberOfConstructor;
        private ATNConditionQWObjWillSubjFToHaveTransNode_v2 mParentNode;
        private ATNConditionQWObjWillSubjFToHaveConditionTransNode_v2 mSameNode;
        private ATNExtendedToken mToken;
        private InitATNConditionQWObjWillSubjFToHaveConditionTransNodeAction mInitAction;

        public override BaseATNNode_v2 Create(ContextOfATNParsing_v2 context)
        {
            switch(mNumberOfConstructor)
            {
                case 1:
                    return new ATNConditionQWObjWillSubjFToHaveConditionTransNode_v2(context, mParentNode, mToken);

                case 2:
                    return new ATNConditionQWObjWillSubjFToHaveConditionTransNode_v2(context, mSameNode, mInitAction, mToken);

                default:
                    throw new ArgumentOutOfRangeException(nameof(mNumberOfConstructor), mNumberOfConstructor, null);
            }
        }
    }

/*Sub states:
    Condition_QWObj_Will_Subj_FToHave_Condition_V3_TransOrFin
*/

    public class ATNConditionQWObjWillSubjFToHaveConditionTransNode_v2: BaseATNNode_v2
    {
        public ATNConditionQWObjWillSubjFToHaveConditionTransNode_v2(ContextOfATNParsing_v2 context, ATNConditionQWObjWillSubjFToHaveTransNode_v2 parentNode, ATNExtendedToken token)
            : base(context, token)
        {
            ParentNode = parentNode;
        }

        public ATNConditionQWObjWillSubjFToHaveConditionTransNode_v2(ContextOfATNParsing_v2 context, ATNConditionQWObjWillSubjFToHaveConditionTransNode_v2 sameNode, InitATNConditionQWObjWillSubjFToHaveConditionTransNodeAction initAction, ATNExtendedToken token)
            : base(context, token)
        {
            mSameNode = sameNode;
            mInitAction = initAction;
            ParentNode = mSameNode.ParentNode;
            mInitAction?.Invoke(this);
        }

        public override StateOfATNParsing_v2 GlobalState => StateOfATNParsing_v2.Condition_QWObj_Will_Subj_FToHave_Condition_Trans;

        public ATNConditionQWObjWillSubjFToHaveTransNode_v2 ParentNode { get; private set; }
        private ATNConditionQWObjWillSubjFToHaveConditionTransNode_v2 mSameNode;
        private InitATNConditionQWObjWillSubjFToHaveConditionTransNodeAction mInitAction;

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

