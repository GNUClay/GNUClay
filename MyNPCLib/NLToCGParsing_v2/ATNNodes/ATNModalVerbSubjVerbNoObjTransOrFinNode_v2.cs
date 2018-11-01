using MyNPCLib.NLToCGParsing;
using System;
using System.Collections.Generic;
using System.Text;

namespace MyNPCLib.NLToCGParsing_v2.ATNNodes
{
    public delegate void InitATNModalVerbSubjVerbNoObjTransOrFinNodeAction(ATNModalVerbSubjVerbNoObjTransOrFinNode_v2 item);

    public class ATNModalVerbSubjVerbNoObjTransOrFinNodeFactory_v2: BaseATNNodeFactory_v2
    {
        public ATNModalVerbSubjVerbNoObjTransOrFinNodeFactory_v2(ATNModalVerbSubjVerbNoTransNode_v2 parentNode, ATNExtendedToken token)
        {
            mNumberOfConstructor = 1;
            mParentNode = parentNode;
            mToken = token;
        }

        public ATNModalVerbSubjVerbNoObjTransOrFinNodeFactory_v2(ATNModalVerbSubjVerbNoObjTransOrFinNode_v2 sameNode, ATNExtendedToken token, InitATNModalVerbSubjVerbNoObjTransOrFinNodeAction initAction)
        {
            mNumberOfConstructor = 2;
            mSameNode = sameNode;
            mToken = token;
            mInitAction = initAction;
        }

        private int mNumberOfConstructor;
        private ATNModalVerbSubjVerbNoTransNode_v2 mParentNode;
        private ATNModalVerbSubjVerbNoObjTransOrFinNode_v2 mSameNode;
        private ATNExtendedToken mToken;
        private InitATNModalVerbSubjVerbNoObjTransOrFinNodeAction mInitAction;

        public override BaseATNNode_v2 Create(ContextOfATNParsing_v2 context)
        {
            switch(mNumberOfConstructor)
            {
                case 1:
                    return new ATNModalVerbSubjVerbNoObjTransOrFinNode_v2(context, mParentNode, mToken);

                case 2:
                    return new ATNModalVerbSubjVerbNoObjTransOrFinNode_v2(context, mSameNode, mInitAction, mToken);

                default:
                    throw new ArgumentOutOfRangeException(nameof(mNumberOfConstructor), mNumberOfConstructor, null);
            }
        }
    }

/*Sub states:
    ModalVerb_Subj_Verb_No_Obj_Condition_Fin
*/

    public class ATNModalVerbSubjVerbNoObjTransOrFinNode_v2: BaseATNNode_v2
    {
        public ATNModalVerbSubjVerbNoObjTransOrFinNode_v2(ContextOfATNParsing_v2 context, ATNModalVerbSubjVerbNoTransNode_v2 parentNode, ATNExtendedToken token)
            : base(context, token)
        {
            ParentNode = parentNode;
        }

        public ATNModalVerbSubjVerbNoObjTransOrFinNode_v2(ContextOfATNParsing_v2 context, ATNModalVerbSubjVerbNoObjTransOrFinNode_v2 sameNode, InitATNModalVerbSubjVerbNoObjTransOrFinNodeAction initAction, ATNExtendedToken token)
            : base(context, token)
        {
            mSameNode = sameNode;
            mInitAction = initAction;
            ParentNode = mSameNode.ParentNode;
            mInitAction?.Invoke(this);
        }

        public override StateOfATNParsing_v2 GlobalState => StateOfATNParsing_v2.ModalVerb_Subj_Verb_No_Obj_TransOrFin;

        public ATNModalVerbSubjVerbNoTransNode_v2 ParentNode { get; private set; }
        private ATNModalVerbSubjVerbNoObjTransOrFinNode_v2 mSameNode;
        private InitATNModalVerbSubjVerbNoObjTransOrFinNodeAction mInitAction;

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

