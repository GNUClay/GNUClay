using MyNPCLib.NLToCGParsing;
using System;
using System.Collections.Generic;
using System.Text;

namespace MyNPCLib.NLToCGParsing_v2.ATNNodes
{
    public delegate void InitATNConditionQWSubjModalVerbVerbNoTransNodeAction(ATNConditionQWSubjModalVerbVerbNoTransNode_v2 item);

    public class ATNConditionQWSubjModalVerbVerbNoTransNodeFactory_v2: BaseATNNodeFactory_v2
    {
        public ATNConditionQWSubjModalVerbVerbNoTransNodeFactory_v2(ATNConditionQWSubjModalVerbVerbTransOrFinNode_v2 parentNode, ATNExtendedToken token)
        {
            mNumberOfConstructor = 1;
            mParentNode = parentNode;
            mToken = token;
        }

        public ATNConditionQWSubjModalVerbVerbNoTransNodeFactory_v2(ATNConditionQWSubjModalVerbVerbNoTransNode_v2 sameNode, ATNExtendedToken token, InitATNConditionQWSubjModalVerbVerbNoTransNodeAction initAction)
        {
            mNumberOfConstructor = 2;
            mSameNode = sameNode;
            mToken = token;
            mInitAction = initAction;
        }

        private int mNumberOfConstructor;
        private ATNConditionQWSubjModalVerbVerbTransOrFinNode_v2 mParentNode;
        private ATNConditionQWSubjModalVerbVerbNoTransNode_v2 mSameNode;
        private ATNExtendedToken mToken;
        private InitATNConditionQWSubjModalVerbVerbNoTransNodeAction mInitAction;

        public override BaseATNNode_v2 Create(ContextOfATNParsing_v2 context)
        {
            switch(mNumberOfConstructor)
            {
                case 1:
                    return new ATNConditionQWSubjModalVerbVerbNoTransNode_v2(context, mParentNode, mToken);

                case 2:
                    return new ATNConditionQWSubjModalVerbVerbNoTransNode_v2(context, mSameNode, mInitAction, mToken);

                default:
                    throw new ArgumentOutOfRangeException(nameof(mNumberOfConstructor), mNumberOfConstructor, null);
            }
        }
    }

/*Sub states:
    Condition_QWSubj_ModalVerb_Verb_No_Obj_TransOrFin
*/

    public class ATNConditionQWSubjModalVerbVerbNoTransNode_v2: BaseATNNode_v2
    {
        public ATNConditionQWSubjModalVerbVerbNoTransNode_v2(ContextOfATNParsing_v2 context, ATNConditionQWSubjModalVerbVerbTransOrFinNode_v2 parentNode, ATNExtendedToken token)
            : base(context, token)
        {
            ParentNode = parentNode;
        }

        public ATNConditionQWSubjModalVerbVerbNoTransNode_v2(ContextOfATNParsing_v2 context, ATNConditionQWSubjModalVerbVerbNoTransNode_v2 sameNode, InitATNConditionQWSubjModalVerbVerbNoTransNodeAction initAction, ATNExtendedToken token)
            : base(context, token)
        {
            mSameNode = sameNode;
            mInitAction = initAction;
            ParentNode = mSameNode.ParentNode;
            mInitAction?.Invoke(this);
        }

        public override StateOfATNParsing_v2 GlobalState => StateOfATNParsing_v2.Condition_QWSubj_ModalVerb_Verb_No_Trans;

        public ATNConditionQWSubjModalVerbVerbTransOrFinNode_v2 ParentNode { get; private set; }
        private ATNConditionQWSubjModalVerbVerbNoTransNode_v2 mSameNode;
        private InitATNConditionQWSubjModalVerbVerbNoTransNodeAction mInitAction;

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

