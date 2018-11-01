using MyNPCLib.NLToCGParsing;
using System;
using System.Collections.Generic;
using System.Text;

namespace MyNPCLib.NLToCGParsing_v2.ATNNodes
{
    public delegate void InitATNWillSubjFToHaveBeenConditionVingTransOrFinNodeAction(ATNWillSubjFToHaveBeenConditionVingTransOrFinNode_v2 item);

    public class ATNWillSubjFToHaveBeenConditionVingTransOrFinNodeFactory_v2: BaseATNNodeFactory_v2
    {
        public ATNWillSubjFToHaveBeenConditionVingTransOrFinNodeFactory_v2(ATNWillSubjFToHaveBeenConditionTransNode_v2 parentNode, ATNExtendedToken token)
        {
            mNumberOfConstructor = 1;
            mParentNode = parentNode;
            mToken = token;
        }

        public ATNWillSubjFToHaveBeenConditionVingTransOrFinNodeFactory_v2(ATNWillSubjFToHaveBeenConditionVingTransOrFinNode_v2 sameNode, ATNExtendedToken token, InitATNWillSubjFToHaveBeenConditionVingTransOrFinNodeAction initAction)
        {
            mNumberOfConstructor = 2;
            mSameNode = sameNode;
            mToken = token;
            mInitAction = initAction;
        }

        private int mNumberOfConstructor;
        private ATNWillSubjFToHaveBeenConditionTransNode_v2 mParentNode;
        private ATNWillSubjFToHaveBeenConditionVingTransOrFinNode_v2 mSameNode;
        private ATNExtendedToken mToken;
        private InitATNWillSubjFToHaveBeenConditionVingTransOrFinNodeAction mInitAction;

        public override BaseATNNode_v2 Create(ContextOfATNParsing_v2 context)
        {
            switch(mNumberOfConstructor)
            {
                case 1:
                    return new ATNWillSubjFToHaveBeenConditionVingTransOrFinNode_v2(context, mParentNode, mToken);

                case 2:
                    return new ATNWillSubjFToHaveBeenConditionVingTransOrFinNode_v2(context, mSameNode, mInitAction, mToken);

                default:
                    throw new ArgumentOutOfRangeException(nameof(mNumberOfConstructor), mNumberOfConstructor, null);
            }
        }
    }

/*Sub states:
    Will_Subj_FToHave_Been_Condition_Ving_Obj_TransOrFin
    Will_Subj_FToHave_Been_Condition_Ving_No_Trans
    Will_Subj_FToHave_Been_Condition_Ving_Condition_Fin
*/

    public class ATNWillSubjFToHaveBeenConditionVingTransOrFinNode_v2: BaseATNNode_v2
    {
        public ATNWillSubjFToHaveBeenConditionVingTransOrFinNode_v2(ContextOfATNParsing_v2 context, ATNWillSubjFToHaveBeenConditionTransNode_v2 parentNode, ATNExtendedToken token)
            : base(context, token)
        {
            ParentNode = parentNode;
        }

        public ATNWillSubjFToHaveBeenConditionVingTransOrFinNode_v2(ContextOfATNParsing_v2 context, ATNWillSubjFToHaveBeenConditionVingTransOrFinNode_v2 sameNode, InitATNWillSubjFToHaveBeenConditionVingTransOrFinNodeAction initAction, ATNExtendedToken token)
            : base(context, token)
        {
            mSameNode = sameNode;
            mInitAction = initAction;
            ParentNode = mSameNode.ParentNode;
            mInitAction?.Invoke(this);
        }

        public override StateOfATNParsing_v2 GlobalState => StateOfATNParsing_v2.Will_Subj_FToHave_Been_Condition_Ving_TransOrFin;

        public ATNWillSubjFToHaveBeenConditionTransNode_v2 ParentNode { get; private set; }
        private ATNWillSubjFToHaveBeenConditionVingTransOrFinNode_v2 mSameNode;
        private InitATNWillSubjFToHaveBeenConditionVingTransOrFinNodeAction mInitAction;

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

