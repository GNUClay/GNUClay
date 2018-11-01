using MyNPCLib.NLToCGParsing;
using System;
using System.Collections.Generic;
using System.Text;

namespace MyNPCLib.NLToCGParsing_v2.ATNNodes
{
    public delegate void InitATNQWSubjWillFToHaveBeenConditionVingTransOrFinNodeAction(ATNQWSubjWillFToHaveBeenConditionVingTransOrFinNode_v2 item);

    public class ATNQWSubjWillFToHaveBeenConditionVingTransOrFinNodeFactory_v2: BaseATNNodeFactory_v2
    {
        public ATNQWSubjWillFToHaveBeenConditionVingTransOrFinNodeFactory_v2(ATNQWSubjWillFToHaveBeenConditionTransNode_v2 parentNode, ATNExtendedToken token)
        {
            mNumberOfConstructor = 1;
            mParentNode = parentNode;
            mToken = token;
        }

        public ATNQWSubjWillFToHaveBeenConditionVingTransOrFinNodeFactory_v2(ATNQWSubjWillFToHaveBeenConditionVingTransOrFinNode_v2 sameNode, ATNExtendedToken token, InitATNQWSubjWillFToHaveBeenConditionVingTransOrFinNodeAction initAction)
        {
            mNumberOfConstructor = 2;
            mSameNode = sameNode;
            mToken = token;
            mInitAction = initAction;
        }

        private int mNumberOfConstructor;
        private ATNQWSubjWillFToHaveBeenConditionTransNode_v2 mParentNode;
        private ATNQWSubjWillFToHaveBeenConditionVingTransOrFinNode_v2 mSameNode;
        private ATNExtendedToken mToken;
        private InitATNQWSubjWillFToHaveBeenConditionVingTransOrFinNodeAction mInitAction;

        public override BaseATNNode_v2 Create(ContextOfATNParsing_v2 context)
        {
            switch(mNumberOfConstructor)
            {
                case 1:
                    return new ATNQWSubjWillFToHaveBeenConditionVingTransOrFinNode_v2(context, mParentNode, mToken);

                case 2:
                    return new ATNQWSubjWillFToHaveBeenConditionVingTransOrFinNode_v2(context, mSameNode, mInitAction, mToken);

                default:
                    throw new ArgumentOutOfRangeException(nameof(mNumberOfConstructor), mNumberOfConstructor, null);
            }
        }
    }

/*Sub states:
    QWSubj_Will_FToHave_Been_Condition_Ving_Obj_TransOrFin
    QWSubj_Will_FToHave_Been_Condition_Ving_No_Trans
    QWSubj_Will_FToHave_Been_Condition_Ving_Condition_Fin
*/

    public class ATNQWSubjWillFToHaveBeenConditionVingTransOrFinNode_v2: BaseATNNode_v2
    {
        public ATNQWSubjWillFToHaveBeenConditionVingTransOrFinNode_v2(ContextOfATNParsing_v2 context, ATNQWSubjWillFToHaveBeenConditionTransNode_v2 parentNode, ATNExtendedToken token)
            : base(context, token)
        {
            ParentNode = parentNode;
        }

        public ATNQWSubjWillFToHaveBeenConditionVingTransOrFinNode_v2(ContextOfATNParsing_v2 context, ATNQWSubjWillFToHaveBeenConditionVingTransOrFinNode_v2 sameNode, InitATNQWSubjWillFToHaveBeenConditionVingTransOrFinNodeAction initAction, ATNExtendedToken token)
            : base(context, token)
        {
            mSameNode = sameNode;
            mInitAction = initAction;
            ParentNode = mSameNode.ParentNode;
            mInitAction?.Invoke(this);
        }

        public override StateOfATNParsing_v2 GlobalState => StateOfATNParsing_v2.QWSubj_Will_FToHave_Been_Condition_Ving_TransOrFin;

        public ATNQWSubjWillFToHaveBeenConditionTransNode_v2 ParentNode { get; private set; }
        private ATNQWSubjWillFToHaveBeenConditionVingTransOrFinNode_v2 mSameNode;
        private InitATNQWSubjWillFToHaveBeenConditionVingTransOrFinNodeAction mInitAction;

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

