using MyNPCLib.NLToCGParsing;
using System;
using System.Collections.Generic;
using System.Text;

namespace MyNPCLib.NLToCGParsing_v2.ATNNodes
{
    public delegate void InitATNQWObjWillSubjFToHaveBeenConditionV3TransOrFinNodeAction(ATNQWObjWillSubjFToHaveBeenConditionV3TransOrFinNode_v2 item);

    public class ATNQWObjWillSubjFToHaveBeenConditionV3TransOrFinNodeFactory_v2: BaseATNNodeFactory_v2
    {
        public ATNQWObjWillSubjFToHaveBeenConditionV3TransOrFinNodeFactory_v2(ATNQWObjWillSubjFToHaveBeenConditionTransNode_v2 parentNode, ATNExtendedToken token)
        {
            mNumberOfConstructor = 1;
            mParentNode = parentNode;
            mToken = token;
        }

        public ATNQWObjWillSubjFToHaveBeenConditionV3TransOrFinNodeFactory_v2(ATNQWObjWillSubjFToHaveBeenConditionV3TransOrFinNode_v2 sameNode, ATNExtendedToken token, InitATNQWObjWillSubjFToHaveBeenConditionV3TransOrFinNodeAction initAction)
        {
            mNumberOfConstructor = 2;
            mSameNode = sameNode;
            mToken = token;
            mInitAction = initAction;
        }

        private int mNumberOfConstructor;
        private ATNQWObjWillSubjFToHaveBeenConditionTransNode_v2 mParentNode;
        private ATNQWObjWillSubjFToHaveBeenConditionV3TransOrFinNode_v2 mSameNode;
        private ATNExtendedToken mToken;
        private InitATNQWObjWillSubjFToHaveBeenConditionV3TransOrFinNodeAction mInitAction;

        public override BaseATNNode_v2 Create(ContextOfATNParsing_v2 context)
        {
            switch(mNumberOfConstructor)
            {
                case 1:
                    return new ATNQWObjWillSubjFToHaveBeenConditionV3TransOrFinNode_v2(context, mParentNode, mToken);

                case 2:
                    return new ATNQWObjWillSubjFToHaveBeenConditionV3TransOrFinNode_v2(context, mSameNode, mInitAction, mToken);

                default:
                    throw new ArgumentOutOfRangeException(nameof(mNumberOfConstructor), mNumberOfConstructor, null);
            }
        }
    }

/*Sub states:
    QWObj_Will_Subj_FToHave_Been_Condition_V3_Condition_Fin
*/

    public class ATNQWObjWillSubjFToHaveBeenConditionV3TransOrFinNode_v2: BaseATNNode_v2
    {
        public ATNQWObjWillSubjFToHaveBeenConditionV3TransOrFinNode_v2(ContextOfATNParsing_v2 context, ATNQWObjWillSubjFToHaveBeenConditionTransNode_v2 parentNode, ATNExtendedToken token)
            : base(context, token)
        {
            ParentNode = parentNode;
        }

        public ATNQWObjWillSubjFToHaveBeenConditionV3TransOrFinNode_v2(ContextOfATNParsing_v2 context, ATNQWObjWillSubjFToHaveBeenConditionV3TransOrFinNode_v2 sameNode, InitATNQWObjWillSubjFToHaveBeenConditionV3TransOrFinNodeAction initAction, ATNExtendedToken token)
            : base(context, token)
        {
            mSameNode = sameNode;
            mInitAction = initAction;
            ParentNode = mSameNode.ParentNode;
            mInitAction?.Invoke(this);
        }

        public override StateOfATNParsing_v2 GlobalState => StateOfATNParsing_v2.QWObj_Will_Subj_FToHave_Been_Condition_V3_TransOrFin;

        public ATNQWObjWillSubjFToHaveBeenConditionTransNode_v2 ParentNode { get; private set; }
        private ATNQWObjWillSubjFToHaveBeenConditionV3TransOrFinNode_v2 mSameNode;
        private InitATNQWObjWillSubjFToHaveBeenConditionV3TransOrFinNodeAction mInitAction;

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

