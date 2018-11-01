using MyNPCLib.NLToCGParsing;
using System;
using System.Collections.Generic;
using System.Text;

namespace MyNPCLib.NLToCGParsing_v2.ATNNodes
{
    public delegate void InitATNConditionQWSubjFToHaveTransNodeAction(ATNConditionQWSubjFToHaveTransNode_v2 item);

    public class ATNConditionQWSubjFToHaveTransNodeFactory_v2: BaseATNNodeFactory_v2
    {
        public ATNConditionQWSubjFToHaveTransNodeFactory_v2(ATNConditionQWSubjTransNode_v2 parentNode, ATNExtendedToken token)
        {
            mNumberOfConstructor = 1;
            mParentNode = parentNode;
            mToken = token;
        }

        public ATNConditionQWSubjFToHaveTransNodeFactory_v2(ATNConditionQWSubjFToHaveTransNode_v2 sameNode, ATNExtendedToken token, InitATNConditionQWSubjFToHaveTransNodeAction initAction)
        {
            mNumberOfConstructor = 2;
            mSameNode = sameNode;
            mToken = token;
            mInitAction = initAction;
        }

        private int mNumberOfConstructor;
        private ATNConditionQWSubjTransNode_v2 mParentNode;
        private ATNConditionQWSubjFToHaveTransNode_v2 mSameNode;
        private ATNExtendedToken mToken;
        private InitATNConditionQWSubjFToHaveTransNodeAction mInitAction;

        public override BaseATNNode_v2 Create(ContextOfATNParsing_v2 context)
        {
            switch(mNumberOfConstructor)
            {
                case 1:
                    return new ATNConditionQWSubjFToHaveTransNode_v2(context, mParentNode, mToken);

                case 2:
                    return new ATNConditionQWSubjFToHaveTransNode_v2(context, mSameNode, mInitAction, mToken);

                default:
                    throw new ArgumentOutOfRangeException(nameof(mNumberOfConstructor), mNumberOfConstructor, null);
            }
        }
    }

/*Sub states:
    Condition_QWSubj_FToHave_V3_TransOrFin
    Condition_QWSubj_FToHave_Been_Trans
    Condition_QWSubj_FToHave_Condition_Trans
*/

    public class ATNConditionQWSubjFToHaveTransNode_v2: BaseATNNode_v2
    {
        public ATNConditionQWSubjFToHaveTransNode_v2(ContextOfATNParsing_v2 context, ATNConditionQWSubjTransNode_v2 parentNode, ATNExtendedToken token)
            : base(context, token)
        {
            ParentNode = parentNode;
        }

        public ATNConditionQWSubjFToHaveTransNode_v2(ContextOfATNParsing_v2 context, ATNConditionQWSubjFToHaveTransNode_v2 sameNode, InitATNConditionQWSubjFToHaveTransNodeAction initAction, ATNExtendedToken token)
            : base(context, token)
        {
            mSameNode = sameNode;
            mInitAction = initAction;
            ParentNode = mSameNode.ParentNode;
            mInitAction?.Invoke(this);
        }

        public override StateOfATNParsing_v2 GlobalState => StateOfATNParsing_v2.Condition_QWSubj_FToHave_Trans;

        public ATNConditionQWSubjTransNode_v2 ParentNode { get; private set; }
        private ATNConditionQWSubjFToHaveTransNode_v2 mSameNode;
        private InitATNConditionQWSubjFToHaveTransNodeAction mInitAction;

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

