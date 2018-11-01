using MyNPCLib.NLToCGParsing;
using System;
using System.Collections.Generic;
using System.Text;

namespace MyNPCLib.NLToCGParsing_v2.ATNNodes
{
    public delegate void InitATNConditionFToHaveSubjBeenVingTransOrFinNodeAction(ATNConditionFToHaveSubjBeenVingTransOrFinNode_v2 item);

    public class ATNConditionFToHaveSubjBeenVingTransOrFinNodeFactory_v2: BaseATNNodeFactory_v2
    {
        public ATNConditionFToHaveSubjBeenVingTransOrFinNodeFactory_v2(ATNConditionFToHaveSubjBeenTransNode_v2 parentNode, ATNExtendedToken token)
        {
            mNumberOfConstructor = 1;
            mParentNode = parentNode;
            mToken = token;
        }

        public ATNConditionFToHaveSubjBeenVingTransOrFinNodeFactory_v2(ATNConditionFToHaveSubjBeenVingTransOrFinNode_v2 sameNode, ATNExtendedToken token, InitATNConditionFToHaveSubjBeenVingTransOrFinNodeAction initAction)
        {
            mNumberOfConstructor = 2;
            mSameNode = sameNode;
            mToken = token;
            mInitAction = initAction;
        }

        private int mNumberOfConstructor;
        private ATNConditionFToHaveSubjBeenTransNode_v2 mParentNode;
        private ATNConditionFToHaveSubjBeenVingTransOrFinNode_v2 mSameNode;
        private ATNExtendedToken mToken;
        private InitATNConditionFToHaveSubjBeenVingTransOrFinNodeAction mInitAction;

        public override BaseATNNode_v2 Create(ContextOfATNParsing_v2 context)
        {
            switch(mNumberOfConstructor)
            {
                case 1:
                    return new ATNConditionFToHaveSubjBeenVingTransOrFinNode_v2(context, mParentNode, mToken);

                case 2:
                    return new ATNConditionFToHaveSubjBeenVingTransOrFinNode_v2(context, mSameNode, mInitAction, mToken);

                default:
                    throw new ArgumentOutOfRangeException(nameof(mNumberOfConstructor), mNumberOfConstructor, null);
            }
        }
    }

/*Sub states:
    Condition_FToHave_Subj_Been_Ving_Obj_TransOrFin
    Condition_FToHave_Subj_Been_Ving_No_Trans
    Condition_FToHave_Subj_Been_Ving_Condition_Fin
*/

    public class ATNConditionFToHaveSubjBeenVingTransOrFinNode_v2: BaseATNNode_v2
    {
        public ATNConditionFToHaveSubjBeenVingTransOrFinNode_v2(ContextOfATNParsing_v2 context, ATNConditionFToHaveSubjBeenTransNode_v2 parentNode, ATNExtendedToken token)
            : base(context, token)
        {
            ParentNode = parentNode;
        }

        public ATNConditionFToHaveSubjBeenVingTransOrFinNode_v2(ContextOfATNParsing_v2 context, ATNConditionFToHaveSubjBeenVingTransOrFinNode_v2 sameNode, InitATNConditionFToHaveSubjBeenVingTransOrFinNodeAction initAction, ATNExtendedToken token)
            : base(context, token)
        {
            mSameNode = sameNode;
            mInitAction = initAction;
            ParentNode = mSameNode.ParentNode;
            mInitAction?.Invoke(this);
        }

        public override StateOfATNParsing_v2 GlobalState => StateOfATNParsing_v2.Condition_FToHave_Subj_Been_Ving_TransOrFin;

        public ATNConditionFToHaveSubjBeenTransNode_v2 ParentNode { get; private set; }
        private ATNConditionFToHaveSubjBeenVingTransOrFinNode_v2 mSameNode;
        private InitATNConditionFToHaveSubjBeenVingTransOrFinNodeAction mInitAction;

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

