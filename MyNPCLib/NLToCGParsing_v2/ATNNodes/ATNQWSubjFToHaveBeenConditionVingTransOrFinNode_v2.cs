using MyNPCLib.NLToCGParsing;
using System;
using System.Collections.Generic;
using System.Text;

namespace MyNPCLib.NLToCGParsing_v2.ATNNodes
{
    public delegate void InitATNQWSubjFToHaveBeenConditionVingTransOrFinNodeAction(ATNQWSubjFToHaveBeenConditionVingTransOrFinNode_v2 item);

    public class ATNQWSubjFToHaveBeenConditionVingTransOrFinNodeFactory_v2: BaseATNNodeFactory_v2
    {
        public ATNQWSubjFToHaveBeenConditionVingTransOrFinNodeFactory_v2(ATNQWSubjFToHaveBeenConditionTransNode_v2 parentNode, ATNExtendedToken token)
        {
            mNumberOfConstructor = 1;
            mParentNode = parentNode;
            mToken = token;
        }

        public ATNQWSubjFToHaveBeenConditionVingTransOrFinNodeFactory_v2(ATNQWSubjFToHaveBeenConditionVingTransOrFinNode_v2 sameNode, ATNExtendedToken token, InitATNQWSubjFToHaveBeenConditionVingTransOrFinNodeAction initAction)
        {
            mNumberOfConstructor = 2;
            mSameNode = sameNode;
            mToken = token;
            mInitAction = initAction;
        }

        private int mNumberOfConstructor;
        private ATNQWSubjFToHaveBeenConditionTransNode_v2 mParentNode;
        private ATNQWSubjFToHaveBeenConditionVingTransOrFinNode_v2 mSameNode;
        private ATNExtendedToken mToken;
        private InitATNQWSubjFToHaveBeenConditionVingTransOrFinNodeAction mInitAction;

        public override BaseATNNode_v2 Create(ContextOfATNParsing_v2 context)
        {
            switch(mNumberOfConstructor)
            {
                case 1:
                    return new ATNQWSubjFToHaveBeenConditionVingTransOrFinNode_v2(context, mParentNode, mToken);

                case 2:
                    return new ATNQWSubjFToHaveBeenConditionVingTransOrFinNode_v2(context, mSameNode, mInitAction, mToken);

                default:
                    throw new ArgumentOutOfRangeException(nameof(mNumberOfConstructor), mNumberOfConstructor, null);
            }
        }
    }

/*Sub states:
    QWSubj_FToHave_Been_Condition_Ving_Obj_TransOrFin
    QWSubj_FToHave_Been_Condition_Ving_No_Trans
    QWSubj_FToHave_Been_Condition_Ving_Condition_Fin
*/

    public class ATNQWSubjFToHaveBeenConditionVingTransOrFinNode_v2: BaseATNNode_v2
    {
        public ATNQWSubjFToHaveBeenConditionVingTransOrFinNode_v2(ContextOfATNParsing_v2 context, ATNQWSubjFToHaveBeenConditionTransNode_v2 parentNode, ATNExtendedToken token)
            : base(context, token)
        {
            ParentNode = parentNode;
        }

        public ATNQWSubjFToHaveBeenConditionVingTransOrFinNode_v2(ContextOfATNParsing_v2 context, ATNQWSubjFToHaveBeenConditionVingTransOrFinNode_v2 sameNode, InitATNQWSubjFToHaveBeenConditionVingTransOrFinNodeAction initAction, ATNExtendedToken token)
            : base(context, token)
        {
            mSameNode = sameNode;
            mInitAction = initAction;
            ParentNode = mSameNode.ParentNode;
            mInitAction?.Invoke(this);
        }

        public override StateOfATNParsing_v2 GlobalState => StateOfATNParsing_v2.QWSubj_FToHave_Been_Condition_Ving_TransOrFin;

        public ATNQWSubjFToHaveBeenConditionTransNode_v2 ParentNode { get; private set; }
        private ATNQWSubjFToHaveBeenConditionVingTransOrFinNode_v2 mSameNode;
        private InitATNQWSubjFToHaveBeenConditionVingTransOrFinNodeAction mInitAction;

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

