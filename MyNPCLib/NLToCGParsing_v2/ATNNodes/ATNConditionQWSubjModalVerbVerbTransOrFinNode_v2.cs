using MyNPCLib.NLToCGParsing;
using System;
using System.Collections.Generic;
using System.Text;

namespace MyNPCLib.NLToCGParsing_v2.ATNNodes
{
    public delegate void InitATNConditionQWSubjModalVerbVerbTransOrFinNodeAction(ATNConditionQWSubjModalVerbVerbTransOrFinNode_v2 item);

    public class ATNConditionQWSubjModalVerbVerbTransOrFinNodeFactory_v2: BaseATNNodeFactory_v2
    {
        public ATNConditionQWSubjModalVerbVerbTransOrFinNodeFactory_v2(ATNConditionQWSubjModalVerbTransNode_v2 parentNode, ATNExtendedToken token)
        {
            mNumberOfConstructor = 1;
            mParentNode = parentNode;
            mToken = token;
        }

        public ATNConditionQWSubjModalVerbVerbTransOrFinNodeFactory_v2(ATNConditionQWSubjModalVerbVerbTransOrFinNode_v2 sameNode, ATNExtendedToken token, InitATNConditionQWSubjModalVerbVerbTransOrFinNodeAction initAction)
        {
            mNumberOfConstructor = 2;
            mSameNode = sameNode;
            mToken = token;
            mInitAction = initAction;
        }

        private int mNumberOfConstructor;
        private ATNConditionQWSubjModalVerbTransNode_v2 mParentNode;
        private ATNConditionQWSubjModalVerbVerbTransOrFinNode_v2 mSameNode;
        private ATNExtendedToken mToken;
        private InitATNConditionQWSubjModalVerbVerbTransOrFinNodeAction mInitAction;

        public override BaseATNNode_v2 Create(ContextOfATNParsing_v2 context)
        {
            switch(mNumberOfConstructor)
            {
                case 1:
                    return new ATNConditionQWSubjModalVerbVerbTransOrFinNode_v2(context, mParentNode, mToken);

                case 2:
                    return new ATNConditionQWSubjModalVerbVerbTransOrFinNode_v2(context, mSameNode, mInitAction, mToken);

                default:
                    throw new ArgumentOutOfRangeException(nameof(mNumberOfConstructor), mNumberOfConstructor, null);
            }
        }
    }

/*Sub states:
    Condition_QWSubj_ModalVerb_Verb_Obj_TransOrFin
    Condition_QWSubj_ModalVerb_Verb_No_Trans
    Condition_QWSubj_ModalVerb_Verb_Condition_Fin
*/

    public class ATNConditionQWSubjModalVerbVerbTransOrFinNode_v2: BaseATNNode_v2
    {
        public ATNConditionQWSubjModalVerbVerbTransOrFinNode_v2(ContextOfATNParsing_v2 context, ATNConditionQWSubjModalVerbTransNode_v2 parentNode, ATNExtendedToken token)
            : base(context, token)
        {
            ParentNode = parentNode;
        }

        public ATNConditionQWSubjModalVerbVerbTransOrFinNode_v2(ContextOfATNParsing_v2 context, ATNConditionQWSubjModalVerbVerbTransOrFinNode_v2 sameNode, InitATNConditionQWSubjModalVerbVerbTransOrFinNodeAction initAction, ATNExtendedToken token)
            : base(context, token)
        {
            mSameNode = sameNode;
            mInitAction = initAction;
            ParentNode = mSameNode.ParentNode;
            mInitAction?.Invoke(this);
        }

        public override StateOfATNParsing_v2 GlobalState => StateOfATNParsing_v2.Condition_QWSubj_ModalVerb_Verb_TransOrFin;

        public ATNConditionQWSubjModalVerbTransNode_v2 ParentNode { get; private set; }
        private ATNConditionQWSubjModalVerbVerbTransOrFinNode_v2 mSameNode;
        private InitATNConditionQWSubjModalVerbVerbTransOrFinNodeAction mInitAction;

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

