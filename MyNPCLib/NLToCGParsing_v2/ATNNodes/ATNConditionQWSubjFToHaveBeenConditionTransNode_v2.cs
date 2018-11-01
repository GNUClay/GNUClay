using MyNPCLib.NLToCGParsing;
using System;
using System.Collections.Generic;
using System.Text;

namespace MyNPCLib.NLToCGParsing_v2.ATNNodes
{
    public delegate void InitATNConditionQWSubjFToHaveBeenConditionTransNodeAction(ATNConditionQWSubjFToHaveBeenConditionTransNode_v2 item);

    public class ATNConditionQWSubjFToHaveBeenConditionTransNodeFactory_v2: BaseATNNodeFactory_v2
    {
        public ATNConditionQWSubjFToHaveBeenConditionTransNodeFactory_v2(ATNConditionQWSubjFToHaveBeenTransNode_v2 parentNode, ATNExtendedToken token)
        {
            mNumberOfConstructor = 1;
            mParentNode = parentNode;
            mToken = token;
        }

        public ATNConditionQWSubjFToHaveBeenConditionTransNodeFactory_v2(ATNConditionQWSubjFToHaveBeenConditionTransNode_v2 sameNode, ATNExtendedToken token, InitATNConditionQWSubjFToHaveBeenConditionTransNodeAction initAction)
        {
            mNumberOfConstructor = 2;
            mSameNode = sameNode;
            mToken = token;
            mInitAction = initAction;
        }

        private int mNumberOfConstructor;
        private ATNConditionQWSubjFToHaveBeenTransNode_v2 mParentNode;
        private ATNConditionQWSubjFToHaveBeenConditionTransNode_v2 mSameNode;
        private ATNExtendedToken mToken;
        private InitATNConditionQWSubjFToHaveBeenConditionTransNodeAction mInitAction;

        public override BaseATNNode_v2 Create(ContextOfATNParsing_v2 context)
        {
            switch(mNumberOfConstructor)
            {
                case 1:
                    return new ATNConditionQWSubjFToHaveBeenConditionTransNode_v2(context, mParentNode, mToken);

                case 2:
                    return new ATNConditionQWSubjFToHaveBeenConditionTransNode_v2(context, mSameNode, mInitAction, mToken);

                default:
                    throw new ArgumentOutOfRangeException(nameof(mNumberOfConstructor), mNumberOfConstructor, null);
            }
        }
    }

/*Sub states:
    Condition_QWSubj_FToHave_Been_Condition_Ving_TransOrFin
    Condition_QWSubj_FToHave_Been_Condition_V3_TransOrFin
*/

    public class ATNConditionQWSubjFToHaveBeenConditionTransNode_v2: BaseATNNode_v2
    {
        public ATNConditionQWSubjFToHaveBeenConditionTransNode_v2(ContextOfATNParsing_v2 context, ATNConditionQWSubjFToHaveBeenTransNode_v2 parentNode, ATNExtendedToken token)
            : base(context, token)
        {
            ParentNode = parentNode;
        }

        public ATNConditionQWSubjFToHaveBeenConditionTransNode_v2(ContextOfATNParsing_v2 context, ATNConditionQWSubjFToHaveBeenConditionTransNode_v2 sameNode, InitATNConditionQWSubjFToHaveBeenConditionTransNodeAction initAction, ATNExtendedToken token)
            : base(context, token)
        {
            mSameNode = sameNode;
            mInitAction = initAction;
            ParentNode = mSameNode.ParentNode;
            mInitAction?.Invoke(this);
        }

        public override StateOfATNParsing_v2 GlobalState => StateOfATNParsing_v2.Condition_QWSubj_FToHave_Been_Condition_Trans;

        public ATNConditionQWSubjFToHaveBeenTransNode_v2 ParentNode { get; private set; }
        private ATNConditionQWSubjFToHaveBeenConditionTransNode_v2 mSameNode;
        private InitATNConditionQWSubjFToHaveBeenConditionTransNodeAction mInitAction;

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

