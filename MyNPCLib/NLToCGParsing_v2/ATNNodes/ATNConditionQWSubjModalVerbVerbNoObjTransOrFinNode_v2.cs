using MyNPCLib.NLToCGParsing;
using System;
using System.Collections.Generic;
using System.Text;

namespace MyNPCLib.NLToCGParsing_v2.ATNNodes
{
    public delegate void InitATNConditionQWSubjModalVerbVerbNoObjTransOrFinNodeAction(ATNConditionQWSubjModalVerbVerbNoObjTransOrFinNode_v2 item);

    public class ATNConditionQWSubjModalVerbVerbNoObjTransOrFinNodeFactory_v2: BaseATNNodeFactory_v2
    {
        public ATNConditionQWSubjModalVerbVerbNoObjTransOrFinNodeFactory_v2(ATNConditionQWSubjModalVerbVerbNoTransNode_v2 parentNode, ATNExtendedToken token)
        {
            mNumberOfConstructor = 1;
            mParentNode = parentNode;
            mToken = token;
        }

        public ATNConditionQWSubjModalVerbVerbNoObjTransOrFinNodeFactory_v2(ATNConditionQWSubjModalVerbVerbNoObjTransOrFinNode_v2 sameNode, ATNExtendedToken token, InitATNConditionQWSubjModalVerbVerbNoObjTransOrFinNodeAction initAction)
        {
            mNumberOfConstructor = 2;
            mSameNode = sameNode;
            mToken = token;
            mInitAction = initAction;
        }

        private int mNumberOfConstructor;
        private ATNConditionQWSubjModalVerbVerbNoTransNode_v2 mParentNode;
        private ATNConditionQWSubjModalVerbVerbNoObjTransOrFinNode_v2 mSameNode;
        private ATNExtendedToken mToken;
        private InitATNConditionQWSubjModalVerbVerbNoObjTransOrFinNodeAction mInitAction;

        public override BaseATNNode_v2 Create(ContextOfATNParsing_v2 context)
        {
            switch(mNumberOfConstructor)
            {
                case 1:
                    return new ATNConditionQWSubjModalVerbVerbNoObjTransOrFinNode_v2(context, mParentNode, mToken);

                case 2:
                    return new ATNConditionQWSubjModalVerbVerbNoObjTransOrFinNode_v2(context, mSameNode, mInitAction, mToken);

                default:
                    throw new ArgumentOutOfRangeException(nameof(mNumberOfConstructor), mNumberOfConstructor, null);
            }
        }
    }

/*Sub states:
    Condition_QWSubj_ModalVerb_Verb_No_Obj_Condition_Fin
*/

    public class ATNConditionQWSubjModalVerbVerbNoObjTransOrFinNode_v2: BaseATNNode_v2
    {
        public ATNConditionQWSubjModalVerbVerbNoObjTransOrFinNode_v2(ContextOfATNParsing_v2 context, ATNConditionQWSubjModalVerbVerbNoTransNode_v2 parentNode, ATNExtendedToken token)
            : base(context, token)
        {
            ParentNode = parentNode;
        }

        public ATNConditionQWSubjModalVerbVerbNoObjTransOrFinNode_v2(ContextOfATNParsing_v2 context, ATNConditionQWSubjModalVerbVerbNoObjTransOrFinNode_v2 sameNode, InitATNConditionQWSubjModalVerbVerbNoObjTransOrFinNodeAction initAction, ATNExtendedToken token)
            : base(context, token)
        {
            mSameNode = sameNode;
            mInitAction = initAction;
            ParentNode = mSameNode.ParentNode;
            mInitAction?.Invoke(this);
        }

        public override StateOfATNParsing_v2 GlobalState => StateOfATNParsing_v2.Condition_QWSubj_ModalVerb_Verb_No_Obj_TransOrFin;

        public ATNConditionQWSubjModalVerbVerbNoTransNode_v2 ParentNode { get; private set; }
        private ATNConditionQWSubjModalVerbVerbNoObjTransOrFinNode_v2 mSameNode;
        private InitATNConditionQWSubjModalVerbVerbNoObjTransOrFinNodeAction mInitAction;

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

