using MyNPCLib.NLToCGParsing;
using System;
using System.Collections.Generic;
using System.Text;

namespace MyNPCLib.NLToCGParsing_v2.ATNNodes
{
    public delegate void InitATNSubjFToHaveBeenConditionVingTransOrFinNodeAction(ATNSubjFToHaveBeenConditionVingTransOrFinNode_v2 item);

    public class ATNSubjFToHaveBeenConditionVingTransOrFinNodeFactory_v2: BaseATNNodeFactory_v2
    {
        public ATNSubjFToHaveBeenConditionVingTransOrFinNodeFactory_v2(ATNSubjFToHaveBeenConditionTransNode_v2 parentNode, ATNExtendedToken token)
        {
            mNumberOfConstructor = 1;
            mParentNode = parentNode;
            mToken = token;
        }

        public ATNSubjFToHaveBeenConditionVingTransOrFinNodeFactory_v2(ATNSubjFToHaveBeenConditionVingTransOrFinNode_v2 sameNode, ATNExtendedToken token, InitATNSubjFToHaveBeenConditionVingTransOrFinNodeAction initAction)
        {
            mNumberOfConstructor = 2;
            mSameNode = sameNode;
            mToken = token;
            mInitAction = initAction;
        }

        private int mNumberOfConstructor;
        private ATNSubjFToHaveBeenConditionTransNode_v2 mParentNode;
        private ATNSubjFToHaveBeenConditionVingTransOrFinNode_v2 mSameNode;
        private ATNExtendedToken mToken;
        private InitATNSubjFToHaveBeenConditionVingTransOrFinNodeAction mInitAction;

        public override BaseATNNode_v2 Create(ContextOfATNParsing_v2 context)
        {
            switch(mNumberOfConstructor)
            {
                case 1:
                    return new ATNSubjFToHaveBeenConditionVingTransOrFinNode_v2(context, mParentNode, mToken);

                case 2:
                    return new ATNSubjFToHaveBeenConditionVingTransOrFinNode_v2(context, mSameNode, mInitAction, mToken);

                default:
                    throw new ArgumentOutOfRangeException(nameof(mNumberOfConstructor), mNumberOfConstructor, null);
            }
        }
    }

/*Sub states:
    Subj_FToHave_Been_Condition_Ving_Obj_TransOrFin
    Subj_FToHave_Been_Condition_Ving_No_Trans
    Subj_FToHave_Been_Condition_Ving_Condition_Fin
*/

    public class ATNSubjFToHaveBeenConditionVingTransOrFinNode_v2: BaseATNNode_v2
    {
        public ATNSubjFToHaveBeenConditionVingTransOrFinNode_v2(ContextOfATNParsing_v2 context, ATNSubjFToHaveBeenConditionTransNode_v2 parentNode, ATNExtendedToken token)
            : base(context, token)
        {
            ParentNode = parentNode;
        }

        public ATNSubjFToHaveBeenConditionVingTransOrFinNode_v2(ContextOfATNParsing_v2 context, ATNSubjFToHaveBeenConditionVingTransOrFinNode_v2 sameNode, InitATNSubjFToHaveBeenConditionVingTransOrFinNodeAction initAction, ATNExtendedToken token)
            : base(context, token)
        {
            mSameNode = sameNode;
            mInitAction = initAction;
            ParentNode = mSameNode.ParentNode;
            mInitAction?.Invoke(this);
        }

        public override StateOfATNParsing_v2 GlobalState => StateOfATNParsing_v2.Subj_FToHave_Been_Condition_Ving_TransOrFin;

        public ATNSubjFToHaveBeenConditionTransNode_v2 ParentNode { get; private set; }
        private ATNSubjFToHaveBeenConditionVingTransOrFinNode_v2 mSameNode;
        private InitATNSubjFToHaveBeenConditionVingTransOrFinNodeAction mInitAction;

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

