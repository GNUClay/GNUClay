using MyNPCLib.NLToCGParsing;
using System;
using System.Collections.Generic;
using System.Text;

namespace MyNPCLib.NLToCGParsing_v2.ATNNodes
{
    public delegate void InitATNQWObjWillSubjFToHaveBeenConditionVingTransOrFinNodeAction(ATNQWObjWillSubjFToHaveBeenConditionVingTransOrFinNode_v2 item);

    public class ATNQWObjWillSubjFToHaveBeenConditionVingTransOrFinNodeFactory_v2: BaseATNNodeFactory_v2
    {
        public ATNQWObjWillSubjFToHaveBeenConditionVingTransOrFinNodeFactory_v2(ATNQWObjWillSubjFToHaveBeenConditionTransNode_v2 parentNode, ATNExtendedToken token)
        {
            mNumberOfConstructor = 1;
            mParentNode = parentNode;
            mToken = token;
        }

        public ATNQWObjWillSubjFToHaveBeenConditionVingTransOrFinNodeFactory_v2(ATNQWObjWillSubjFToHaveBeenConditionVingTransOrFinNode_v2 sameNode, ATNExtendedToken token, InitATNQWObjWillSubjFToHaveBeenConditionVingTransOrFinNodeAction initAction)
        {
            mNumberOfConstructor = 2;
            mSameNode = sameNode;
            mToken = token;
            mInitAction = initAction;
        }

        private int mNumberOfConstructor;
        private ATNQWObjWillSubjFToHaveBeenConditionTransNode_v2 mParentNode;
        private ATNQWObjWillSubjFToHaveBeenConditionVingTransOrFinNode_v2 mSameNode;
        private ATNExtendedToken mToken;
        private InitATNQWObjWillSubjFToHaveBeenConditionVingTransOrFinNodeAction mInitAction;

        public override BaseATNNode_v2 Create(ContextOfATNParsing_v2 context)
        {
            switch(mNumberOfConstructor)
            {
                case 1:
                    return new ATNQWObjWillSubjFToHaveBeenConditionVingTransOrFinNode_v2(context, mParentNode, mToken);

                case 2:
                    return new ATNQWObjWillSubjFToHaveBeenConditionVingTransOrFinNode_v2(context, mSameNode, mInitAction, mToken);

                default:
                    throw new ArgumentOutOfRangeException(nameof(mNumberOfConstructor), mNumberOfConstructor, null);
            }
        }
    }

/*Sub states:
    QWObj_Will_Subj_FToHave_Been_Condition_Ving_Condition_Fin
*/

    public class ATNQWObjWillSubjFToHaveBeenConditionVingTransOrFinNode_v2: BaseATNNode_v2
    {
        public ATNQWObjWillSubjFToHaveBeenConditionVingTransOrFinNode_v2(ContextOfATNParsing_v2 context, ATNQWObjWillSubjFToHaveBeenConditionTransNode_v2 parentNode, ATNExtendedToken token)
            : base(context, token)
        {
            ParentNode = parentNode;
        }

        public ATNQWObjWillSubjFToHaveBeenConditionVingTransOrFinNode_v2(ContextOfATNParsing_v2 context, ATNQWObjWillSubjFToHaveBeenConditionVingTransOrFinNode_v2 sameNode, InitATNQWObjWillSubjFToHaveBeenConditionVingTransOrFinNodeAction initAction, ATNExtendedToken token)
            : base(context, token)
        {
            mSameNode = sameNode;
            mInitAction = initAction;
            ParentNode = mSameNode.ParentNode;
            mInitAction?.Invoke(this);
        }

        public override StateOfATNParsing_v2 GlobalState => StateOfATNParsing_v2.QWObj_Will_Subj_FToHave_Been_Condition_Ving_TransOrFin;

        public ATNQWObjWillSubjFToHaveBeenConditionTransNode_v2 ParentNode { get; private set; }
        private ATNQWObjWillSubjFToHaveBeenConditionVingTransOrFinNode_v2 mSameNode;
        private InitATNQWObjWillSubjFToHaveBeenConditionVingTransOrFinNodeAction mInitAction;

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

