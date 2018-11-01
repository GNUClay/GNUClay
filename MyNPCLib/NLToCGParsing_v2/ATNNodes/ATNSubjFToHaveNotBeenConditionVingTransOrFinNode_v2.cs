using MyNPCLib.NLToCGParsing;
using System;
using System.Collections.Generic;
using System.Text;

namespace MyNPCLib.NLToCGParsing_v2.ATNNodes
{
    public delegate void InitATNSubjFToHaveNotBeenConditionVingTransOrFinNodeAction(ATNSubjFToHaveNotBeenConditionVingTransOrFinNode_v2 item);

    public class ATNSubjFToHaveNotBeenConditionVingTransOrFinNodeFactory_v2: BaseATNNodeFactory_v2
    {
        public ATNSubjFToHaveNotBeenConditionVingTransOrFinNodeFactory_v2(ATNSubjFToHaveNotBeenConditionTransNode_v2 parentNode, ATNExtendedToken token)
        {
            mNumberOfConstructor = 1;
            mParentNode = parentNode;
            mToken = token;
        }

        public ATNSubjFToHaveNotBeenConditionVingTransOrFinNodeFactory_v2(ATNSubjFToHaveNotBeenConditionVingTransOrFinNode_v2 sameNode, ATNExtendedToken token, InitATNSubjFToHaveNotBeenConditionVingTransOrFinNodeAction initAction)
        {
            mNumberOfConstructor = 2;
            mSameNode = sameNode;
            mToken = token;
            mInitAction = initAction;
        }

        private int mNumberOfConstructor;
        private ATNSubjFToHaveNotBeenConditionTransNode_v2 mParentNode;
        private ATNSubjFToHaveNotBeenConditionVingTransOrFinNode_v2 mSameNode;
        private ATNExtendedToken mToken;
        private InitATNSubjFToHaveNotBeenConditionVingTransOrFinNodeAction mInitAction;

        public override BaseATNNode_v2 Create(ContextOfATNParsing_v2 context)
        {
            switch(mNumberOfConstructor)
            {
                case 1:
                    return new ATNSubjFToHaveNotBeenConditionVingTransOrFinNode_v2(context, mParentNode, mToken);

                case 2:
                    return new ATNSubjFToHaveNotBeenConditionVingTransOrFinNode_v2(context, mSameNode, mInitAction, mToken);

                default:
                    throw new ArgumentOutOfRangeException(nameof(mNumberOfConstructor), mNumberOfConstructor, null);
            }
        }
    }

/*Sub states:
    Subj_FToHave_Not_Been_Condition_Ving_Obj_TransOrFin
    Subj_FToHave_Not_Been_Condition_Ving_Condition_Fin
*/

    public class ATNSubjFToHaveNotBeenConditionVingTransOrFinNode_v2: BaseATNNode_v2
    {
        public ATNSubjFToHaveNotBeenConditionVingTransOrFinNode_v2(ContextOfATNParsing_v2 context, ATNSubjFToHaveNotBeenConditionTransNode_v2 parentNode, ATNExtendedToken token)
            : base(context, token)
        {
            ParentNode = parentNode;
        }

        public ATNSubjFToHaveNotBeenConditionVingTransOrFinNode_v2(ContextOfATNParsing_v2 context, ATNSubjFToHaveNotBeenConditionVingTransOrFinNode_v2 sameNode, InitATNSubjFToHaveNotBeenConditionVingTransOrFinNodeAction initAction, ATNExtendedToken token)
            : base(context, token)
        {
            mSameNode = sameNode;
            mInitAction = initAction;
            ParentNode = mSameNode.ParentNode;
            mInitAction?.Invoke(this);
        }

        public override StateOfATNParsing_v2 GlobalState => StateOfATNParsing_v2.Subj_FToHave_Not_Been_Condition_Ving_TransOrFin;

        public ATNSubjFToHaveNotBeenConditionTransNode_v2 ParentNode { get; private set; }
        private ATNSubjFToHaveNotBeenConditionVingTransOrFinNode_v2 mSameNode;
        private InitATNSubjFToHaveNotBeenConditionVingTransOrFinNodeAction mInitAction;

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

