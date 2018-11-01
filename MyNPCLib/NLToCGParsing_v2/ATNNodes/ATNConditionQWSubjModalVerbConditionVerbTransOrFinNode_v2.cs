using MyNPCLib.NLToCGParsing;
using System;
using System.Collections.Generic;
using System.Text;

namespace MyNPCLib.NLToCGParsing_v2.ATNNodes
{
    public delegate void InitATNConditionQWSubjModalVerbConditionVerbTransOrFinNodeAction(ATNConditionQWSubjModalVerbConditionVerbTransOrFinNode_v2 item);

    public class ATNConditionQWSubjModalVerbConditionVerbTransOrFinNodeFactory_v2: BaseATNNodeFactory_v2
    {
        public ATNConditionQWSubjModalVerbConditionVerbTransOrFinNodeFactory_v2(ATNConditionQWSubjModalVerbConditionTransNode_v2 parentNode, ATNExtendedToken token)
        {
            mNumberOfConstructor = 1;
            mParentNode = parentNode;
            mToken = token;
        }

        public ATNConditionQWSubjModalVerbConditionVerbTransOrFinNodeFactory_v2(ATNConditionQWSubjModalVerbConditionVerbTransOrFinNode_v2 sameNode, ATNExtendedToken token, InitATNConditionQWSubjModalVerbConditionVerbTransOrFinNodeAction initAction)
        {
            mNumberOfConstructor = 2;
            mSameNode = sameNode;
            mToken = token;
            mInitAction = initAction;
        }

        private int mNumberOfConstructor;
        private ATNConditionQWSubjModalVerbConditionTransNode_v2 mParentNode;
        private ATNConditionQWSubjModalVerbConditionVerbTransOrFinNode_v2 mSameNode;
        private ATNExtendedToken mToken;
        private InitATNConditionQWSubjModalVerbConditionVerbTransOrFinNodeAction mInitAction;

        public override BaseATNNode_v2 Create(ContextOfATNParsing_v2 context)
        {
            switch(mNumberOfConstructor)
            {
                case 1:
                    return new ATNConditionQWSubjModalVerbConditionVerbTransOrFinNode_v2(context, mParentNode, mToken);

                case 2:
                    return new ATNConditionQWSubjModalVerbConditionVerbTransOrFinNode_v2(context, mSameNode, mInitAction, mToken);

                default:
                    throw new ArgumentOutOfRangeException(nameof(mNumberOfConstructor), mNumberOfConstructor, null);
            }
        }
    }

/*Sub states:
    Condition_QWSubj_ModalVerb_Condition_Verb_Obj_TransOrFin
    Condition_QWSubj_ModalVerb_Condition_Verb_No_Trans
    Condition_QWSubj_ModalVerb_Condition_Verb_Condition_Fin
*/

    public class ATNConditionQWSubjModalVerbConditionVerbTransOrFinNode_v2: BaseATNNode_v2
    {
        public ATNConditionQWSubjModalVerbConditionVerbTransOrFinNode_v2(ContextOfATNParsing_v2 context, ATNConditionQWSubjModalVerbConditionTransNode_v2 parentNode, ATNExtendedToken token)
            : base(context, token)
        {
            ParentNode = parentNode;
        }

        public ATNConditionQWSubjModalVerbConditionVerbTransOrFinNode_v2(ContextOfATNParsing_v2 context, ATNConditionQWSubjModalVerbConditionVerbTransOrFinNode_v2 sameNode, InitATNConditionQWSubjModalVerbConditionVerbTransOrFinNodeAction initAction, ATNExtendedToken token)
            : base(context, token)
        {
            mSameNode = sameNode;
            mInitAction = initAction;
            ParentNode = mSameNode.ParentNode;
            mInitAction?.Invoke(this);
        }

        public override StateOfATNParsing_v2 GlobalState => StateOfATNParsing_v2.Condition_QWSubj_ModalVerb_Condition_Verb_TransOrFin;

        public ATNConditionQWSubjModalVerbConditionTransNode_v2 ParentNode { get; private set; }
        private ATNConditionQWSubjModalVerbConditionVerbTransOrFinNode_v2 mSameNode;
        private InitATNConditionQWSubjModalVerbConditionVerbTransOrFinNodeAction mInitAction;

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

