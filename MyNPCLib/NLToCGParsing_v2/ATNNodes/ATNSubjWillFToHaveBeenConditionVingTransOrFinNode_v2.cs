using MyNPCLib.NLToCGParsing;
using System;
using System.Collections.Generic;
using System.Text;

namespace MyNPCLib.NLToCGParsing_v2.ATNNodes
{
    public delegate void InitATNSubjWillFToHaveBeenConditionVingTransOrFinNodeAction(ATNSubjWillFToHaveBeenConditionVingTransOrFinNode_v2 item);

    public class ATNSubjWillFToHaveBeenConditionVingTransOrFinNodeFactory_v2: BaseATNNodeFactory_v2
    {
        public ATNSubjWillFToHaveBeenConditionVingTransOrFinNodeFactory_v2(ATNSubjWillFToHaveBeenConditionTransNode_v2 parentNode, ATNExtendedToken token)
        {
            mNumberOfConstructor = 1;
            mParentNode = parentNode;
            mToken = token;
        }

        public ATNSubjWillFToHaveBeenConditionVingTransOrFinNodeFactory_v2(ATNSubjWillFToHaveBeenConditionVingTransOrFinNode_v2 sameNode, ATNExtendedToken token, InitATNSubjWillFToHaveBeenConditionVingTransOrFinNodeAction initAction)
        {
            mNumberOfConstructor = 2;
            mSameNode = sameNode;
            mToken = token;
            mInitAction = initAction;
        }

        private int mNumberOfConstructor;
        private ATNSubjWillFToHaveBeenConditionTransNode_v2 mParentNode;
        private ATNSubjWillFToHaveBeenConditionVingTransOrFinNode_v2 mSameNode;
        private ATNExtendedToken mToken;
        private InitATNSubjWillFToHaveBeenConditionVingTransOrFinNodeAction mInitAction;

        public override BaseATNNode_v2 Create(ContextOfATNParsing_v2 context)
        {
            switch(mNumberOfConstructor)
            {
                case 1:
                    return new ATNSubjWillFToHaveBeenConditionVingTransOrFinNode_v2(context, mParentNode, mToken);

                case 2:
                    return new ATNSubjWillFToHaveBeenConditionVingTransOrFinNode_v2(context, mSameNode, mInitAction, mToken);

                default:
                    throw new ArgumentOutOfRangeException(nameof(mNumberOfConstructor), mNumberOfConstructor, null);
            }
        }
    }

/*Sub states:
    Subj_Will_FToHave_Been_Condition_Ving_Obj_TransOrFin
    Subj_Will_FToHave_Been_Condition_Ving_No_Trans
    Subj_Will_FToHave_Been_Condition_Ving_Condition_Fin
*/

    public class ATNSubjWillFToHaveBeenConditionVingTransOrFinNode_v2: BaseATNNode_v2
    {
        public ATNSubjWillFToHaveBeenConditionVingTransOrFinNode_v2(ContextOfATNParsing_v2 context, ATNSubjWillFToHaveBeenConditionTransNode_v2 parentNode, ATNExtendedToken token)
            : base(context, token)
        {
            ParentNode = parentNode;
        }

        public ATNSubjWillFToHaveBeenConditionVingTransOrFinNode_v2(ContextOfATNParsing_v2 context, ATNSubjWillFToHaveBeenConditionVingTransOrFinNode_v2 sameNode, InitATNSubjWillFToHaveBeenConditionVingTransOrFinNodeAction initAction, ATNExtendedToken token)
            : base(context, token)
        {
            mSameNode = sameNode;
            mInitAction = initAction;
            ParentNode = mSameNode.ParentNode;
            mInitAction?.Invoke(this);
        }

        public override StateOfATNParsing_v2 GlobalState => StateOfATNParsing_v2.Subj_Will_FToHave_Been_Condition_Ving_TransOrFin;

        public ATNSubjWillFToHaveBeenConditionTransNode_v2 ParentNode { get; private set; }
        private ATNSubjWillFToHaveBeenConditionVingTransOrFinNode_v2 mSameNode;
        private InitATNSubjWillFToHaveBeenConditionVingTransOrFinNodeAction mInitAction;

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

