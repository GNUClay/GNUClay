using MyNPCLib.NLToCGParsing;
using System;
using System.Collections.Generic;
using System.Text;

namespace MyNPCLib.NLToCGParsing_v2.ATNNodes
{
    public delegate void InitATNConditionModalVerbSubjVerbObjTransOrFinNodeAction(ATNConditionModalVerbSubjVerbObjTransOrFinNode_v2 item);

    public class ATNConditionModalVerbSubjVerbObjTransOrFinNodeFactory_v2: BaseATNNodeFactory_v2
    {
        public ATNConditionModalVerbSubjVerbObjTransOrFinNodeFactory_v2(ATNConditionModalVerbSubjVerbTransOrFinNode_v2 parentNode, ATNExtendedToken token)
        {
            mNumberOfConstructor = 1;
            mParentNode = parentNode;
            mToken = token;
        }

        public ATNConditionModalVerbSubjVerbObjTransOrFinNodeFactory_v2(ATNConditionModalVerbSubjVerbObjTransOrFinNode_v2 sameNode, ATNExtendedToken token, InitATNConditionModalVerbSubjVerbObjTransOrFinNodeAction initAction)
        {
            mNumberOfConstructor = 2;
            mSameNode = sameNode;
            mToken = token;
            mInitAction = initAction;
        }

        private int mNumberOfConstructor;
        private ATNConditionModalVerbSubjVerbTransOrFinNode_v2 mParentNode;
        private ATNConditionModalVerbSubjVerbObjTransOrFinNode_v2 mSameNode;
        private ATNExtendedToken mToken;
        private InitATNConditionModalVerbSubjVerbObjTransOrFinNodeAction mInitAction;

        public override BaseATNNode_v2 Create(ContextOfATNParsing_v2 context)
        {
            switch(mNumberOfConstructor)
            {
                case 1:
                    return new ATNConditionModalVerbSubjVerbObjTransOrFinNode_v2(context, mParentNode, mToken);

                case 2:
                    return new ATNConditionModalVerbSubjVerbObjTransOrFinNode_v2(context, mSameNode, mInitAction, mToken);

                default:
                    throw new ArgumentOutOfRangeException(nameof(mNumberOfConstructor), mNumberOfConstructor, null);
            }
        }
    }

/*Sub states:
    Condition_ModalVerb_Subj_Verb_Obj_Condition_Fin
*/

    public class ATNConditionModalVerbSubjVerbObjTransOrFinNode_v2: BaseATNNode_v2
    {
        public ATNConditionModalVerbSubjVerbObjTransOrFinNode_v2(ContextOfATNParsing_v2 context, ATNConditionModalVerbSubjVerbTransOrFinNode_v2 parentNode, ATNExtendedToken token)
            : base(context, token)
        {
            ParentNode = parentNode;
        }

        public ATNConditionModalVerbSubjVerbObjTransOrFinNode_v2(ContextOfATNParsing_v2 context, ATNConditionModalVerbSubjVerbObjTransOrFinNode_v2 sameNode, InitATNConditionModalVerbSubjVerbObjTransOrFinNodeAction initAction, ATNExtendedToken token)
            : base(context, token)
        {
            mSameNode = sameNode;
            mInitAction = initAction;
            ParentNode = mSameNode.ParentNode;
            mInitAction?.Invoke(this);
        }

        public override StateOfATNParsing_v2 GlobalState => StateOfATNParsing_v2.Condition_ModalVerb_Subj_Verb_Obj_TransOrFin;

        public ATNConditionModalVerbSubjVerbTransOrFinNode_v2 ParentNode { get; private set; }
        private ATNConditionModalVerbSubjVerbObjTransOrFinNode_v2 mSameNode;
        private InitATNConditionModalVerbSubjVerbObjTransOrFinNodeAction mInitAction;

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

