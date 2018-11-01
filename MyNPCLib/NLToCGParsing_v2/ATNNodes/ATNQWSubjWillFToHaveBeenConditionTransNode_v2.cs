using MyNPCLib.NLToCGParsing;
using System;
using System.Collections.Generic;
using System.Text;

namespace MyNPCLib.NLToCGParsing_v2.ATNNodes
{
    public delegate void InitATNQWSubjWillFToHaveBeenConditionTransNodeAction(ATNQWSubjWillFToHaveBeenConditionTransNode_v2 item);

    public class ATNQWSubjWillFToHaveBeenConditionTransNodeFactory_v2: BaseATNNodeFactory_v2
    {
        public ATNQWSubjWillFToHaveBeenConditionTransNodeFactory_v2(ATNQWSubjWillFToHaveBeenTransNode_v2 parentNode, ATNExtendedToken token)
        {
            mNumberOfConstructor = 1;
            mParentNode = parentNode;
            mToken = token;
        }

        public ATNQWSubjWillFToHaveBeenConditionTransNodeFactory_v2(ATNQWSubjWillFToHaveBeenConditionTransNode_v2 sameNode, ATNExtendedToken token, InitATNQWSubjWillFToHaveBeenConditionTransNodeAction initAction)
        {
            mNumberOfConstructor = 2;
            mSameNode = sameNode;
            mToken = token;
            mInitAction = initAction;
        }

        private int mNumberOfConstructor;
        private ATNQWSubjWillFToHaveBeenTransNode_v2 mParentNode;
        private ATNQWSubjWillFToHaveBeenConditionTransNode_v2 mSameNode;
        private ATNExtendedToken mToken;
        private InitATNQWSubjWillFToHaveBeenConditionTransNodeAction mInitAction;

        public override BaseATNNode_v2 Create(ContextOfATNParsing_v2 context)
        {
            switch(mNumberOfConstructor)
            {
                case 1:
                    return new ATNQWSubjWillFToHaveBeenConditionTransNode_v2(context, mParentNode, mToken);

                case 2:
                    return new ATNQWSubjWillFToHaveBeenConditionTransNode_v2(context, mSameNode, mInitAction, mToken);

                default:
                    throw new ArgumentOutOfRangeException(nameof(mNumberOfConstructor), mNumberOfConstructor, null);
            }
        }
    }

/*Sub states:
    QWSubj_Will_FToHave_Been_Condition_Ving_TransOrFin
    QWSubj_Will_FToHave_Been_Condition_V3_TransOrFin
*/

    public class ATNQWSubjWillFToHaveBeenConditionTransNode_v2: BaseATNNode_v2
    {
        public ATNQWSubjWillFToHaveBeenConditionTransNode_v2(ContextOfATNParsing_v2 context, ATNQWSubjWillFToHaveBeenTransNode_v2 parentNode, ATNExtendedToken token)
            : base(context, token)
        {
            ParentNode = parentNode;
        }

        public ATNQWSubjWillFToHaveBeenConditionTransNode_v2(ContextOfATNParsing_v2 context, ATNQWSubjWillFToHaveBeenConditionTransNode_v2 sameNode, InitATNQWSubjWillFToHaveBeenConditionTransNodeAction initAction, ATNExtendedToken token)
            : base(context, token)
        {
            mSameNode = sameNode;
            mInitAction = initAction;
            ParentNode = mSameNode.ParentNode;
            mInitAction?.Invoke(this);
        }

        public override StateOfATNParsing_v2 GlobalState => StateOfATNParsing_v2.QWSubj_Will_FToHave_Been_Condition_Trans;

        public ATNQWSubjWillFToHaveBeenTransNode_v2 ParentNode { get; private set; }
        private ATNQWSubjWillFToHaveBeenConditionTransNode_v2 mSameNode;
        private InitATNQWSubjWillFToHaveBeenConditionTransNodeAction mInitAction;

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

