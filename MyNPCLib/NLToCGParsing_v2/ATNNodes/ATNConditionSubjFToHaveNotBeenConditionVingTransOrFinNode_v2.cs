using MyNPCLib.NLToCGParsing;
using System;
using System.Collections.Generic;
using System.Text;

namespace MyNPCLib.NLToCGParsing_v2.ATNNodes
{
    public delegate void InitATNConditionSubjFToHaveNotBeenConditionVingTransOrFinNodeAction(ATNConditionSubjFToHaveNotBeenConditionVingTransOrFinNode_v2 item);

    public class ATNConditionSubjFToHaveNotBeenConditionVingTransOrFinNodeFactory_v2: BaseATNNodeFactory_v2
    {
        public ATNConditionSubjFToHaveNotBeenConditionVingTransOrFinNodeFactory_v2(ATNConditionSubjFToHaveNotBeenConditionTransNode_v2 parentNode, ATNExtendedToken token)
        {
            mNumberOfConstructor = 1;
            mParentNode = parentNode;
            mToken = token;
        }

        public ATNConditionSubjFToHaveNotBeenConditionVingTransOrFinNodeFactory_v2(ATNConditionSubjFToHaveNotBeenConditionVingTransOrFinNode_v2 sameNode, ATNExtendedToken token, InitATNConditionSubjFToHaveNotBeenConditionVingTransOrFinNodeAction initAction)
        {
            mNumberOfConstructor = 2;
            mSameNode = sameNode;
            mToken = token;
            mInitAction = initAction;
        }

        private int mNumberOfConstructor;
        private ATNConditionSubjFToHaveNotBeenConditionTransNode_v2 mParentNode;
        private ATNConditionSubjFToHaveNotBeenConditionVingTransOrFinNode_v2 mSameNode;
        private ATNExtendedToken mToken;
        private InitATNConditionSubjFToHaveNotBeenConditionVingTransOrFinNodeAction mInitAction;

        public override BaseATNNode_v2 Create(ContextOfATNParsing_v2 context)
        {
            switch(mNumberOfConstructor)
            {
                case 1:
                    return new ATNConditionSubjFToHaveNotBeenConditionVingTransOrFinNode_v2(context, mParentNode, mToken);

                case 2:
                    return new ATNConditionSubjFToHaveNotBeenConditionVingTransOrFinNode_v2(context, mSameNode, mInitAction, mToken);

                default:
                    throw new ArgumentOutOfRangeException(nameof(mNumberOfConstructor), mNumberOfConstructor, null);
            }
        }
    }

/*Sub states:
    Condition_Subj_FToHave_Not_Been_Condition_Ving_Obj_TransOrFin
    Condition_Subj_FToHave_Not_Been_Condition_Ving_Condition_Fin
*/

    public class ATNConditionSubjFToHaveNotBeenConditionVingTransOrFinNode_v2: BaseATNNode_v2
    {
        public ATNConditionSubjFToHaveNotBeenConditionVingTransOrFinNode_v2(ContextOfATNParsing_v2 context, ATNConditionSubjFToHaveNotBeenConditionTransNode_v2 parentNode, ATNExtendedToken token)
            : base(context, token)
        {
            ParentNode = parentNode;
        }

        public ATNConditionSubjFToHaveNotBeenConditionVingTransOrFinNode_v2(ContextOfATNParsing_v2 context, ATNConditionSubjFToHaveNotBeenConditionVingTransOrFinNode_v2 sameNode, InitATNConditionSubjFToHaveNotBeenConditionVingTransOrFinNodeAction initAction, ATNExtendedToken token)
            : base(context, token)
        {
            mSameNode = sameNode;
            mInitAction = initAction;
            ParentNode = mSameNode.ParentNode;
            mInitAction?.Invoke(this);
        }

        public override StateOfATNParsing_v2 GlobalState => StateOfATNParsing_v2.Condition_Subj_FToHave_Not_Been_Condition_Ving_TransOrFin;

        public ATNConditionSubjFToHaveNotBeenConditionTransNode_v2 ParentNode { get; private set; }
        private ATNConditionSubjFToHaveNotBeenConditionVingTransOrFinNode_v2 mSameNode;
        private InitATNConditionSubjFToHaveNotBeenConditionVingTransOrFinNodeAction mInitAction;

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

