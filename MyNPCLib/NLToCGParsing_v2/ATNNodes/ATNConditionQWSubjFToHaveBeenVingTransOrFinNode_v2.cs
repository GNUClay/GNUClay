using MyNPCLib.NLToCGParsing;
using System;
using System.Collections.Generic;
using System.Text;

namespace MyNPCLib.NLToCGParsing_v2.ATNNodes
{
    public delegate void InitATNConditionQWSubjFToHaveBeenVingTransOrFinNodeAction(ATNConditionQWSubjFToHaveBeenVingTransOrFinNode_v2 item);

    public class ATNConditionQWSubjFToHaveBeenVingTransOrFinNodeFactory_v2: BaseATNNodeFactory_v2
    {
        public ATNConditionQWSubjFToHaveBeenVingTransOrFinNodeFactory_v2(ATNConditionQWSubjFToHaveBeenTransNode_v2 parentNode, ATNExtendedToken token)
        {
            mNumberOfConstructor = 1;
            mParentNode = parentNode;
            mToken = token;
        }

        public ATNConditionQWSubjFToHaveBeenVingTransOrFinNodeFactory_v2(ATNConditionQWSubjFToHaveBeenVingTransOrFinNode_v2 sameNode, ATNExtendedToken token, InitATNConditionQWSubjFToHaveBeenVingTransOrFinNodeAction initAction)
        {
            mNumberOfConstructor = 2;
            mSameNode = sameNode;
            mToken = token;
            mInitAction = initAction;
        }

        private int mNumberOfConstructor;
        private ATNConditionQWSubjFToHaveBeenTransNode_v2 mParentNode;
        private ATNConditionQWSubjFToHaveBeenVingTransOrFinNode_v2 mSameNode;
        private ATNExtendedToken mToken;
        private InitATNConditionQWSubjFToHaveBeenVingTransOrFinNodeAction mInitAction;

        public override BaseATNNode_v2 Create(ContextOfATNParsing_v2 context)
        {
            switch(mNumberOfConstructor)
            {
                case 1:
                    return new ATNConditionQWSubjFToHaveBeenVingTransOrFinNode_v2(context, mParentNode, mToken);

                case 2:
                    return new ATNConditionQWSubjFToHaveBeenVingTransOrFinNode_v2(context, mSameNode, mInitAction, mToken);

                default:
                    throw new ArgumentOutOfRangeException(nameof(mNumberOfConstructor), mNumberOfConstructor, null);
            }
        }
    }

/*Sub states:
    Condition_QWSubj_FToHave_Been_Ving_Obj_TransOrFin
    Condition_QWSubj_FToHave_Been_Ving_No_Trans
    Condition_QWSubj_FToHave_Been_Ving_Condition_Fin
*/

    public class ATNConditionQWSubjFToHaveBeenVingTransOrFinNode_v2: BaseATNNode_v2
    {
        public ATNConditionQWSubjFToHaveBeenVingTransOrFinNode_v2(ContextOfATNParsing_v2 context, ATNConditionQWSubjFToHaveBeenTransNode_v2 parentNode, ATNExtendedToken token)
            : base(context, token)
        {
            ParentNode = parentNode;
        }

        public ATNConditionQWSubjFToHaveBeenVingTransOrFinNode_v2(ContextOfATNParsing_v2 context, ATNConditionQWSubjFToHaveBeenVingTransOrFinNode_v2 sameNode, InitATNConditionQWSubjFToHaveBeenVingTransOrFinNodeAction initAction, ATNExtendedToken token)
            : base(context, token)
        {
            mSameNode = sameNode;
            mInitAction = initAction;
            ParentNode = mSameNode.ParentNode;
            mInitAction?.Invoke(this);
        }

        public override StateOfATNParsing_v2 GlobalState => StateOfATNParsing_v2.Condition_QWSubj_FToHave_Been_Ving_TransOrFin;

        public ATNConditionQWSubjFToHaveBeenTransNode_v2 ParentNode { get; private set; }
        private ATNConditionQWSubjFToHaveBeenVingTransOrFinNode_v2 mSameNode;
        private InitATNConditionQWSubjFToHaveBeenVingTransOrFinNodeAction mInitAction;

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

