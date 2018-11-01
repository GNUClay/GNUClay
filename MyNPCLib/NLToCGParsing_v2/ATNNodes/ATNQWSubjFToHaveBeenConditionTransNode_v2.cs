using MyNPCLib.NLToCGParsing;
using System;
using System.Collections.Generic;
using System.Text;

namespace MyNPCLib.NLToCGParsing_v2.ATNNodes
{
    public delegate void InitATNQWSubjFToHaveBeenConditionTransNodeAction(ATNQWSubjFToHaveBeenConditionTransNode_v2 item);

    public class ATNQWSubjFToHaveBeenConditionTransNodeFactory_v2: BaseATNNodeFactory_v2
    {
        public ATNQWSubjFToHaveBeenConditionTransNodeFactory_v2(ATNQWSubjFToHaveBeenTransNode_v2 parentNode, ATNExtendedToken token)
        {
            mNumberOfConstructor = 1;
            mParentNode = parentNode;
            mToken = token;
        }

        public ATNQWSubjFToHaveBeenConditionTransNodeFactory_v2(ATNQWSubjFToHaveBeenConditionTransNode_v2 sameNode, ATNExtendedToken token, InitATNQWSubjFToHaveBeenConditionTransNodeAction initAction)
        {
            mNumberOfConstructor = 2;
            mSameNode = sameNode;
            mToken = token;
            mInitAction = initAction;
        }

        private int mNumberOfConstructor;
        private ATNQWSubjFToHaveBeenTransNode_v2 mParentNode;
        private ATNQWSubjFToHaveBeenConditionTransNode_v2 mSameNode;
        private ATNExtendedToken mToken;
        private InitATNQWSubjFToHaveBeenConditionTransNodeAction mInitAction;

        public override BaseATNNode_v2 Create(ContextOfATNParsing_v2 context)
        {
            switch(mNumberOfConstructor)
            {
                case 1:
                    return new ATNQWSubjFToHaveBeenConditionTransNode_v2(context, mParentNode, mToken);

                case 2:
                    return new ATNQWSubjFToHaveBeenConditionTransNode_v2(context, mSameNode, mInitAction, mToken);

                default:
                    throw new ArgumentOutOfRangeException(nameof(mNumberOfConstructor), mNumberOfConstructor, null);
            }
        }
    }

/*Sub states:
    QWSubj_FToHave_Been_Condition_Ving_TransOrFin
    QWSubj_FToHave_Been_Condition_V3_TransOrFin
*/

    public class ATNQWSubjFToHaveBeenConditionTransNode_v2: BaseATNNode_v2
    {
        public ATNQWSubjFToHaveBeenConditionTransNode_v2(ContextOfATNParsing_v2 context, ATNQWSubjFToHaveBeenTransNode_v2 parentNode, ATNExtendedToken token)
            : base(context, token)
        {
            ParentNode = parentNode;
        }

        public ATNQWSubjFToHaveBeenConditionTransNode_v2(ContextOfATNParsing_v2 context, ATNQWSubjFToHaveBeenConditionTransNode_v2 sameNode, InitATNQWSubjFToHaveBeenConditionTransNodeAction initAction, ATNExtendedToken token)
            : base(context, token)
        {
            mSameNode = sameNode;
            mInitAction = initAction;
            ParentNode = mSameNode.ParentNode;
            mInitAction?.Invoke(this);
        }

        public override StateOfATNParsing_v2 GlobalState => StateOfATNParsing_v2.QWSubj_FToHave_Been_Condition_Trans;

        public ATNQWSubjFToHaveBeenTransNode_v2 ParentNode { get; private set; }
        private ATNQWSubjFToHaveBeenConditionTransNode_v2 mSameNode;
        private InitATNQWSubjFToHaveBeenConditionTransNodeAction mInitAction;

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

