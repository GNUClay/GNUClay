using MyNPCLib.NLToCGParsing;
using System;
using System.Collections.Generic;
using System.Text;

namespace MyNPCLib.NLToCGParsing_v2.ATNNodes
{
    public delegate void InitATNQWSubjModalVerbConditionVerbTransOrFinNodeAction(ATNQWSubjModalVerbConditionVerbTransOrFinNode_v2 item);

    public class ATNQWSubjModalVerbConditionVerbTransOrFinNodeFactory_v2: BaseATNNodeFactory_v2
    {
        public ATNQWSubjModalVerbConditionVerbTransOrFinNodeFactory_v2(ATNQWSubjModalVerbConditionTransNode_v2 parentNode, ATNExtendedToken token)
        {
            mNumberOfConstructor = 1;
            mParentNode = parentNode;
            mToken = token;
        }

        public ATNQWSubjModalVerbConditionVerbTransOrFinNodeFactory_v2(ATNQWSubjModalVerbConditionVerbTransOrFinNode_v2 sameNode, ATNExtendedToken token, InitATNQWSubjModalVerbConditionVerbTransOrFinNodeAction initAction)
        {
            mNumberOfConstructor = 2;
            mSameNode = sameNode;
            mToken = token;
            mInitAction = initAction;
        }

        private int mNumberOfConstructor;
        private ATNQWSubjModalVerbConditionTransNode_v2 mParentNode;
        private ATNQWSubjModalVerbConditionVerbTransOrFinNode_v2 mSameNode;
        private ATNExtendedToken mToken;
        private InitATNQWSubjModalVerbConditionVerbTransOrFinNodeAction mInitAction;

        public override BaseATNNode_v2 Create(ContextOfATNParsing_v2 context)
        {
            switch(mNumberOfConstructor)
            {
                case 1:
                    return new ATNQWSubjModalVerbConditionVerbTransOrFinNode_v2(context, mParentNode, mToken);

                case 2:
                    return new ATNQWSubjModalVerbConditionVerbTransOrFinNode_v2(context, mSameNode, mInitAction, mToken);

                default:
                    throw new ArgumentOutOfRangeException(nameof(mNumberOfConstructor), mNumberOfConstructor, null);
            }
        }
    }

/*Sub states:
    QWSubj_ModalVerb_Condition_Verb_Obj_TransOrFin
    QWSubj_ModalVerb_Condition_Verb_No_Trans
    QWSubj_ModalVerb_Condition_Verb_Condition_Fin
*/

    public class ATNQWSubjModalVerbConditionVerbTransOrFinNode_v2: BaseATNNode_v2
    {
        public ATNQWSubjModalVerbConditionVerbTransOrFinNode_v2(ContextOfATNParsing_v2 context, ATNQWSubjModalVerbConditionTransNode_v2 parentNode, ATNExtendedToken token)
            : base(context, token)
        {
            ParentNode = parentNode;
        }

        public ATNQWSubjModalVerbConditionVerbTransOrFinNode_v2(ContextOfATNParsing_v2 context, ATNQWSubjModalVerbConditionVerbTransOrFinNode_v2 sameNode, InitATNQWSubjModalVerbConditionVerbTransOrFinNodeAction initAction, ATNExtendedToken token)
            : base(context, token)
        {
            mSameNode = sameNode;
            mInitAction = initAction;
            ParentNode = mSameNode.ParentNode;
            mInitAction?.Invoke(this);
        }

        public override StateOfATNParsing_v2 GlobalState => StateOfATNParsing_v2.QWSubj_ModalVerb_Condition_Verb_TransOrFin;

        public ATNQWSubjModalVerbConditionTransNode_v2 ParentNode { get; private set; }
        private ATNQWSubjModalVerbConditionVerbTransOrFinNode_v2 mSameNode;
        private InitATNQWSubjModalVerbConditionVerbTransOrFinNodeAction mInitAction;

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

