using MyNPCLib.NLToCGParsing;
using System;
using System.Collections.Generic;
using System.Text;

namespace MyNPCLib.NLToCGParsing_v2.ATNNodes
{
    public delegate void InitATNConditionSubjModalVerbVerbTransOrFinNodeAction(ATNConditionSubjModalVerbVerbTransOrFinNode_v2 item);

    public class ATNConditionSubjModalVerbVerbTransOrFinNodeFactory_v2: BaseATNNodeFactory_v2
    {
        public ATNConditionSubjModalVerbVerbTransOrFinNodeFactory_v2(ATNConditionSubjModalVerbTransNode_v2 parentNode, ATNExtendedToken token)
        {
            mNumberOfConstructor = 1;
            mParentNode = parentNode;
            mToken = token;
        }

        public ATNConditionSubjModalVerbVerbTransOrFinNodeFactory_v2(ATNConditionSubjModalVerbVerbTransOrFinNode_v2 sameNode, ATNExtendedToken token, InitATNConditionSubjModalVerbVerbTransOrFinNodeAction initAction)
        {
            mNumberOfConstructor = 2;
            mSameNode = sameNode;
            mToken = token;
            mInitAction = initAction;
        }

        private int mNumberOfConstructor;
        private ATNConditionSubjModalVerbTransNode_v2 mParentNode;
        private ATNConditionSubjModalVerbVerbTransOrFinNode_v2 mSameNode;
        private ATNExtendedToken mToken;
        private InitATNConditionSubjModalVerbVerbTransOrFinNodeAction mInitAction;

        public override BaseATNNode_v2 Create(ContextOfATNParsing_v2 context)
        {
            switch(mNumberOfConstructor)
            {
                case 1:
                    return new ATNConditionSubjModalVerbVerbTransOrFinNode_v2(context, mParentNode, mToken);

                case 2:
                    return new ATNConditionSubjModalVerbVerbTransOrFinNode_v2(context, mSameNode, mInitAction, mToken);

                default:
                    throw new ArgumentOutOfRangeException(nameof(mNumberOfConstructor), mNumberOfConstructor, null);
            }
        }
    }

/*Sub states:
    Condition_Subj_ModalVerb_Verb_Obj_TransOrFin
    Condition_Subj_ModalVerb_Verb_No_Trans
    Condition_Subj_ModalVerb_Verb_Condition_Fin
*/

    public class ATNConditionSubjModalVerbVerbTransOrFinNode_v2: BaseATNNode_v2
    {
        public ATNConditionSubjModalVerbVerbTransOrFinNode_v2(ContextOfATNParsing_v2 context, ATNConditionSubjModalVerbTransNode_v2 parentNode, ATNExtendedToken token)
            : base(context, token)
        {
            ParentNode = parentNode;
        }

        public ATNConditionSubjModalVerbVerbTransOrFinNode_v2(ContextOfATNParsing_v2 context, ATNConditionSubjModalVerbVerbTransOrFinNode_v2 sameNode, InitATNConditionSubjModalVerbVerbTransOrFinNodeAction initAction, ATNExtendedToken token)
            : base(context, token)
        {
            mSameNode = sameNode;
            mInitAction = initAction;
            ParentNode = mSameNode.ParentNode;
            mInitAction?.Invoke(this);
        }

        public override StateOfATNParsing_v2 GlobalState => StateOfATNParsing_v2.Condition_Subj_ModalVerb_Verb_TransOrFin;

        public ATNConditionSubjModalVerbTransNode_v2 ParentNode { get; private set; }
        private ATNConditionSubjModalVerbVerbTransOrFinNode_v2 mSameNode;
        private InitATNConditionSubjModalVerbVerbTransOrFinNodeAction mInitAction;

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

