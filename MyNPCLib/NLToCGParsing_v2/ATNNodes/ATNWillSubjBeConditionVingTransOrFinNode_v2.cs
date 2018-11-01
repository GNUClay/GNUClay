using MyNPCLib.NLToCGParsing;
using System;
using System.Collections.Generic;
using System.Text;

namespace MyNPCLib.NLToCGParsing_v2.ATNNodes
{
    public delegate void InitATNWillSubjBeConditionVingTransOrFinNodeAction(ATNWillSubjBeConditionVingTransOrFinNode_v2 item);

    public class ATNWillSubjBeConditionVingTransOrFinNodeFactory_v2: BaseATNNodeFactory_v2
    {
        public ATNWillSubjBeConditionVingTransOrFinNodeFactory_v2(ATNWillSubjBeConditionTransNode_v2 parentNode, ATNExtendedToken token)
        {
            mNumberOfConstructor = 1;
            mParentNode = parentNode;
            mToken = token;
        }

        public ATNWillSubjBeConditionVingTransOrFinNodeFactory_v2(ATNWillSubjBeConditionVingTransOrFinNode_v2 sameNode, ATNExtendedToken token, InitATNWillSubjBeConditionVingTransOrFinNodeAction initAction)
        {
            mNumberOfConstructor = 2;
            mSameNode = sameNode;
            mToken = token;
            mInitAction = initAction;
        }

        private int mNumberOfConstructor;
        private ATNWillSubjBeConditionTransNode_v2 mParentNode;
        private ATNWillSubjBeConditionVingTransOrFinNode_v2 mSameNode;
        private ATNExtendedToken mToken;
        private InitATNWillSubjBeConditionVingTransOrFinNodeAction mInitAction;

        public override BaseATNNode_v2 Create(ContextOfATNParsing_v2 context)
        {
            switch(mNumberOfConstructor)
            {
                case 1:
                    return new ATNWillSubjBeConditionVingTransOrFinNode_v2(context, mParentNode, mToken);

                case 2:
                    return new ATNWillSubjBeConditionVingTransOrFinNode_v2(context, mSameNode, mInitAction, mToken);

                default:
                    throw new ArgumentOutOfRangeException(nameof(mNumberOfConstructor), mNumberOfConstructor, null);
            }
        }
    }

/*Sub states:
    Will_Subj_Be_Condition_Ving_Obj_TransOrFin
    Will_Subj_Be_Condition_Ving_No_Trans
    Will_Subj_Be_Condition_Ving_Condition_Fin
*/

    public class ATNWillSubjBeConditionVingTransOrFinNode_v2: BaseATNNode_v2
    {
        public ATNWillSubjBeConditionVingTransOrFinNode_v2(ContextOfATNParsing_v2 context, ATNWillSubjBeConditionTransNode_v2 parentNode, ATNExtendedToken token)
            : base(context, token)
        {
            ParentNode = parentNode;
        }

        public ATNWillSubjBeConditionVingTransOrFinNode_v2(ContextOfATNParsing_v2 context, ATNWillSubjBeConditionVingTransOrFinNode_v2 sameNode, InitATNWillSubjBeConditionVingTransOrFinNodeAction initAction, ATNExtendedToken token)
            : base(context, token)
        {
            mSameNode = sameNode;
            mInitAction = initAction;
            ParentNode = mSameNode.ParentNode;
            mInitAction?.Invoke(this);
        }

        public override StateOfATNParsing_v2 GlobalState => StateOfATNParsing_v2.Will_Subj_Be_Condition_Ving_TransOrFin;

        public ATNWillSubjBeConditionTransNode_v2 ParentNode { get; private set; }
        private ATNWillSubjBeConditionVingTransOrFinNode_v2 mSameNode;
        private InitATNWillSubjBeConditionVingTransOrFinNodeAction mInitAction;

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

