using MyNPCLib.NLToCGParsing;
using System;
using System.Collections.Generic;
using System.Text;

namespace MyNPCLib.NLToCGParsing_v2.ATNNodes
{
    public delegate void InitATNModalVerbSubjConditionVerbObjTransOrFinNodeAction(ATNModalVerbSubjConditionVerbObjTransOrFinNode_v2 item);

    public class ATNModalVerbSubjConditionVerbObjTransOrFinNodeFactory_v2: BaseATNNodeFactory_v2
    {
        public ATNModalVerbSubjConditionVerbObjTransOrFinNodeFactory_v2(ATNModalVerbSubjConditionVerbTransOrFinNode_v2 parentNode, ATNExtendedToken token)
        {
            mNumberOfConstructor = 1;
            mParentNode = parentNode;
            mToken = token;
        }

        public ATNModalVerbSubjConditionVerbObjTransOrFinNodeFactory_v2(ATNModalVerbSubjConditionVerbObjTransOrFinNode_v2 sameNode, ATNExtendedToken token, InitATNModalVerbSubjConditionVerbObjTransOrFinNodeAction initAction)
        {
            mNumberOfConstructor = 2;
            mSameNode = sameNode;
            mToken = token;
            mInitAction = initAction;
        }

        private int mNumberOfConstructor;
        private ATNModalVerbSubjConditionVerbTransOrFinNode_v2 mParentNode;
        private ATNModalVerbSubjConditionVerbObjTransOrFinNode_v2 mSameNode;
        private ATNExtendedToken mToken;
        private InitATNModalVerbSubjConditionVerbObjTransOrFinNodeAction mInitAction;

        public override BaseATNNode_v2 Create(ContextOfATNParsing_v2 context)
        {
            switch(mNumberOfConstructor)
            {
                case 1:
                    return new ATNModalVerbSubjConditionVerbObjTransOrFinNode_v2(context, mParentNode, mToken);

                case 2:
                    return new ATNModalVerbSubjConditionVerbObjTransOrFinNode_v2(context, mSameNode, mInitAction, mToken);

                default:
                    throw new ArgumentOutOfRangeException(nameof(mNumberOfConstructor), mNumberOfConstructor, null);
            }
        }
    }

/*Sub states:
    ModalVerb_Subj_Condition_Verb_Obj_Condition_Fin
*/

    public class ATNModalVerbSubjConditionVerbObjTransOrFinNode_v2: BaseATNNode_v2
    {
        public ATNModalVerbSubjConditionVerbObjTransOrFinNode_v2(ContextOfATNParsing_v2 context, ATNModalVerbSubjConditionVerbTransOrFinNode_v2 parentNode, ATNExtendedToken token)
            : base(context, token)
        {
            ParentNode = parentNode;
        }

        public ATNModalVerbSubjConditionVerbObjTransOrFinNode_v2(ContextOfATNParsing_v2 context, ATNModalVerbSubjConditionVerbObjTransOrFinNode_v2 sameNode, InitATNModalVerbSubjConditionVerbObjTransOrFinNodeAction initAction, ATNExtendedToken token)
            : base(context, token)
        {
            mSameNode = sameNode;
            mInitAction = initAction;
            ParentNode = mSameNode.ParentNode;
            mInitAction?.Invoke(this);
        }

        public override StateOfATNParsing_v2 GlobalState => StateOfATNParsing_v2.ModalVerb_Subj_Condition_Verb_Obj_TransOrFin;

        public ATNModalVerbSubjConditionVerbTransOrFinNode_v2 ParentNode { get; private set; }
        private ATNModalVerbSubjConditionVerbObjTransOrFinNode_v2 mSameNode;
        private InitATNModalVerbSubjConditionVerbObjTransOrFinNodeAction mInitAction;

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

