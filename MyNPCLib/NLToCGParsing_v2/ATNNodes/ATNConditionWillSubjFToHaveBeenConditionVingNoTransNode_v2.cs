using MyNPCLib.NLToCGParsing;
using System;
using System.Collections.Generic;
using System.Text;

namespace MyNPCLib.NLToCGParsing_v2.ATNNodes
{
    public delegate void InitATNConditionWillSubjFToHaveBeenConditionVingNoTransNodeAction(ATNConditionWillSubjFToHaveBeenConditionVingNoTransNode_v2 item);

    public class ATNConditionWillSubjFToHaveBeenConditionVingNoTransNodeFactory_v2: BaseATNNodeFactory_v2
    {
        public ATNConditionWillSubjFToHaveBeenConditionVingNoTransNodeFactory_v2(ATNConditionWillSubjFToHaveBeenConditionVingTransOrFinNode_v2 parentNode, ATNExtendedToken token)
        {
            mNumberOfConstructor = 1;
            mParentNode = parentNode;
            mToken = token;
        }

        public ATNConditionWillSubjFToHaveBeenConditionVingNoTransNodeFactory_v2(ATNConditionWillSubjFToHaveBeenConditionVingNoTransNode_v2 sameNode, ATNExtendedToken token, InitATNConditionWillSubjFToHaveBeenConditionVingNoTransNodeAction initAction)
        {
            mNumberOfConstructor = 2;
            mSameNode = sameNode;
            mToken = token;
            mInitAction = initAction;
        }

        private int mNumberOfConstructor;
        private ATNConditionWillSubjFToHaveBeenConditionVingTransOrFinNode_v2 mParentNode;
        private ATNConditionWillSubjFToHaveBeenConditionVingNoTransNode_v2 mSameNode;
        private ATNExtendedToken mToken;
        private InitATNConditionWillSubjFToHaveBeenConditionVingNoTransNodeAction mInitAction;

        public override BaseATNNode_v2 Create(ContextOfATNParsing_v2 context)
        {
            switch(mNumberOfConstructor)
            {
                case 1:
                    return new ATNConditionWillSubjFToHaveBeenConditionVingNoTransNode_v2(context, mParentNode, mToken);

                case 2:
                    return new ATNConditionWillSubjFToHaveBeenConditionVingNoTransNode_v2(context, mSameNode, mInitAction, mToken);

                default:
                    throw new ArgumentOutOfRangeException(nameof(mNumberOfConstructor), mNumberOfConstructor, null);
            }
        }
    }

/*Sub states:
    Condition_Will_Subj_FToHave_Been_Condition_Ving_No_Obj_TransOrFin
*/

    public class ATNConditionWillSubjFToHaveBeenConditionVingNoTransNode_v2: BaseATNNode_v2
    {
        public ATNConditionWillSubjFToHaveBeenConditionVingNoTransNode_v2(ContextOfATNParsing_v2 context, ATNConditionWillSubjFToHaveBeenConditionVingTransOrFinNode_v2 parentNode, ATNExtendedToken token)
            : base(context, token)
        {
            ParentNode = parentNode;
        }

        public ATNConditionWillSubjFToHaveBeenConditionVingNoTransNode_v2(ContextOfATNParsing_v2 context, ATNConditionWillSubjFToHaveBeenConditionVingNoTransNode_v2 sameNode, InitATNConditionWillSubjFToHaveBeenConditionVingNoTransNodeAction initAction, ATNExtendedToken token)
            : base(context, token)
        {
            mSameNode = sameNode;
            mInitAction = initAction;
            ParentNode = mSameNode.ParentNode;
            mInitAction?.Invoke(this);
        }

        public override StateOfATNParsing_v2 GlobalState => StateOfATNParsing_v2.Condition_Will_Subj_FToHave_Been_Condition_Ving_No_Trans;

        public ATNConditionWillSubjFToHaveBeenConditionVingTransOrFinNode_v2 ParentNode { get; private set; }
        private ATNConditionWillSubjFToHaveBeenConditionVingNoTransNode_v2 mSameNode;
        private InitATNConditionWillSubjFToHaveBeenConditionVingNoTransNodeAction mInitAction;

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

