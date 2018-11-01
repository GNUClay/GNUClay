using MyNPCLib.NLToCGParsing;
using System;
using System.Collections.Generic;
using System.Text;

namespace MyNPCLib.NLToCGParsing_v2.ATNNodes
{
    public delegate void InitATNWillSubjFToHaveBeenConditionTransNodeAction(ATNWillSubjFToHaveBeenConditionTransNode_v2 item);

    public class ATNWillSubjFToHaveBeenConditionTransNodeFactory_v2: BaseATNNodeFactory_v2
    {
        public ATNWillSubjFToHaveBeenConditionTransNodeFactory_v2(ATNWillSubjFToHaveBeenTransNode_v2 parentNode, ATNExtendedToken token)
        {
            mNumberOfConstructor = 1;
            mParentNode = parentNode;
            mToken = token;
        }

        public ATNWillSubjFToHaveBeenConditionTransNodeFactory_v2(ATNWillSubjFToHaveBeenConditionTransNode_v2 sameNode, ATNExtendedToken token, InitATNWillSubjFToHaveBeenConditionTransNodeAction initAction)
        {
            mNumberOfConstructor = 2;
            mSameNode = sameNode;
            mToken = token;
            mInitAction = initAction;
        }

        private int mNumberOfConstructor;
        private ATNWillSubjFToHaveBeenTransNode_v2 mParentNode;
        private ATNWillSubjFToHaveBeenConditionTransNode_v2 mSameNode;
        private ATNExtendedToken mToken;
        private InitATNWillSubjFToHaveBeenConditionTransNodeAction mInitAction;

        public override BaseATNNode_v2 Create(ContextOfATNParsing_v2 context)
        {
            switch(mNumberOfConstructor)
            {
                case 1:
                    return new ATNWillSubjFToHaveBeenConditionTransNode_v2(context, mParentNode, mToken);

                case 2:
                    return new ATNWillSubjFToHaveBeenConditionTransNode_v2(context, mSameNode, mInitAction, mToken);

                default:
                    throw new ArgumentOutOfRangeException(nameof(mNumberOfConstructor), mNumberOfConstructor, null);
            }
        }
    }

/*Sub states:
    Will_Subj_FToHave_Been_Condition_Ving_TransOrFin
    Will_Subj_FToHave_Been_Condition_V3_TransOrFin
*/

    public class ATNWillSubjFToHaveBeenConditionTransNode_v2: BaseATNNode_v2
    {
        public ATNWillSubjFToHaveBeenConditionTransNode_v2(ContextOfATNParsing_v2 context, ATNWillSubjFToHaveBeenTransNode_v2 parentNode, ATNExtendedToken token)
            : base(context, token)
        {
            ParentNode = parentNode;
        }

        public ATNWillSubjFToHaveBeenConditionTransNode_v2(ContextOfATNParsing_v2 context, ATNWillSubjFToHaveBeenConditionTransNode_v2 sameNode, InitATNWillSubjFToHaveBeenConditionTransNodeAction initAction, ATNExtendedToken token)
            : base(context, token)
        {
            mSameNode = sameNode;
            mInitAction = initAction;
            ParentNode = mSameNode.ParentNode;
            mInitAction?.Invoke(this);
        }

        public override StateOfATNParsing_v2 GlobalState => StateOfATNParsing_v2.Will_Subj_FToHave_Been_Condition_Trans;

        public ATNWillSubjFToHaveBeenTransNode_v2 ParentNode { get; private set; }
        private ATNWillSubjFToHaveBeenConditionTransNode_v2 mSameNode;
        private InitATNWillSubjFToHaveBeenConditionTransNodeAction mInitAction;

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

