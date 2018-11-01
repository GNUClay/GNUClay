using MyNPCLib.NLToCGParsing;
using System;
using System.Collections.Generic;
using System.Text;

namespace MyNPCLib.NLToCGParsing_v2.ATNNodes
{
    public delegate void InitATNConditionSubjModalVerbVerbNoTransNodeAction(ATNConditionSubjModalVerbVerbNoTransNode_v2 item);

    public class ATNConditionSubjModalVerbVerbNoTransNodeFactory_v2: BaseATNNodeFactory_v2
    {
        public ATNConditionSubjModalVerbVerbNoTransNodeFactory_v2(ATNConditionSubjModalVerbVerbTransOrFinNode_v2 parentNode, ATNExtendedToken token)
        {
            mNumberOfConstructor = 1;
            mParentNode = parentNode;
            mToken = token;
        }

        public ATNConditionSubjModalVerbVerbNoTransNodeFactory_v2(ATNConditionSubjModalVerbVerbNoTransNode_v2 sameNode, ATNExtendedToken token, InitATNConditionSubjModalVerbVerbNoTransNodeAction initAction)
        {
            mNumberOfConstructor = 2;
            mSameNode = sameNode;
            mToken = token;
            mInitAction = initAction;
        }

        private int mNumberOfConstructor;
        private ATNConditionSubjModalVerbVerbTransOrFinNode_v2 mParentNode;
        private ATNConditionSubjModalVerbVerbNoTransNode_v2 mSameNode;
        private ATNExtendedToken mToken;
        private InitATNConditionSubjModalVerbVerbNoTransNodeAction mInitAction;

        public override BaseATNNode_v2 Create(ContextOfATNParsing_v2 context)
        {
            switch(mNumberOfConstructor)
            {
                case 1:
                    return new ATNConditionSubjModalVerbVerbNoTransNode_v2(context, mParentNode, mToken);

                case 2:
                    return new ATNConditionSubjModalVerbVerbNoTransNode_v2(context, mSameNode, mInitAction, mToken);

                default:
                    throw new ArgumentOutOfRangeException(nameof(mNumberOfConstructor), mNumberOfConstructor, null);
            }
        }
    }

/*Sub states:
    Condition_Subj_ModalVerb_Verb_No_Obj_TransOrFin
*/

    public class ATNConditionSubjModalVerbVerbNoTransNode_v2: BaseATNNode_v2
    {
        public ATNConditionSubjModalVerbVerbNoTransNode_v2(ContextOfATNParsing_v2 context, ATNConditionSubjModalVerbVerbTransOrFinNode_v2 parentNode, ATNExtendedToken token)
            : base(context, token)
        {
            ParentNode = parentNode;
        }

        public ATNConditionSubjModalVerbVerbNoTransNode_v2(ContextOfATNParsing_v2 context, ATNConditionSubjModalVerbVerbNoTransNode_v2 sameNode, InitATNConditionSubjModalVerbVerbNoTransNodeAction initAction, ATNExtendedToken token)
            : base(context, token)
        {
            mSameNode = sameNode;
            mInitAction = initAction;
            ParentNode = mSameNode.ParentNode;
            mInitAction?.Invoke(this);
        }

        public override StateOfATNParsing_v2 GlobalState => StateOfATNParsing_v2.Condition_Subj_ModalVerb_Verb_No_Trans;

        public ATNConditionSubjModalVerbVerbTransOrFinNode_v2 ParentNode { get; private set; }
        private ATNConditionSubjModalVerbVerbNoTransNode_v2 mSameNode;
        private InitATNConditionSubjModalVerbVerbNoTransNodeAction mInitAction;

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

