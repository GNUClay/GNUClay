using MyNPCLib.NLToCGParsing;
using System;
using System.Collections.Generic;
using System.Text;

namespace MyNPCLib.NLToCGParsing_v2.ATNNodes
{
    public delegate void InitATNConditionSubjModalVerbVerbObjTransOrFinNodeAction(ATNConditionSubjModalVerbVerbObjTransOrFinNode_v2 item);

    public class ATNConditionSubjModalVerbVerbObjTransOrFinNodeFactory_v2: BaseATNNodeFactory_v2
    {
        public ATNConditionSubjModalVerbVerbObjTransOrFinNodeFactory_v2(ATNConditionSubjModalVerbVerbTransOrFinNode_v2 parentNode, ATNExtendedToken token)
        {
            mNumberOfConstructor = 1;
            mParentNode = parentNode;
            mToken = token;
        }

        public ATNConditionSubjModalVerbVerbObjTransOrFinNodeFactory_v2(ATNConditionSubjModalVerbVerbObjTransOrFinNode_v2 sameNode, ATNExtendedToken token, InitATNConditionSubjModalVerbVerbObjTransOrFinNodeAction initAction)
        {
            mNumberOfConstructor = 2;
            mSameNode = sameNode;
            mToken = token;
            mInitAction = initAction;
        }

        private int mNumberOfConstructor;
        private ATNConditionSubjModalVerbVerbTransOrFinNode_v2 mParentNode;
        private ATNConditionSubjModalVerbVerbObjTransOrFinNode_v2 mSameNode;
        private ATNExtendedToken mToken;
        private InitATNConditionSubjModalVerbVerbObjTransOrFinNodeAction mInitAction;

        public override BaseATNNode_v2 Create(ContextOfATNParsing_v2 context)
        {
            switch(mNumberOfConstructor)
            {
                case 1:
                    return new ATNConditionSubjModalVerbVerbObjTransOrFinNode_v2(context, mParentNode, mToken);

                case 2:
                    return new ATNConditionSubjModalVerbVerbObjTransOrFinNode_v2(context, mSameNode, mInitAction, mToken);

                default:
                    throw new ArgumentOutOfRangeException(nameof(mNumberOfConstructor), mNumberOfConstructor, null);
            }
        }
    }

/*Sub states:
    Condition_Subj_ModalVerb_Verb_Obj_Condition_Fin
*/

    public class ATNConditionSubjModalVerbVerbObjTransOrFinNode_v2: BaseATNNode_v2
    {
        public ATNConditionSubjModalVerbVerbObjTransOrFinNode_v2(ContextOfATNParsing_v2 context, ATNConditionSubjModalVerbVerbTransOrFinNode_v2 parentNode, ATNExtendedToken token)
            : base(context, token)
        {
            ParentNode = parentNode;
        }

        public ATNConditionSubjModalVerbVerbObjTransOrFinNode_v2(ContextOfATNParsing_v2 context, ATNConditionSubjModalVerbVerbObjTransOrFinNode_v2 sameNode, InitATNConditionSubjModalVerbVerbObjTransOrFinNodeAction initAction, ATNExtendedToken token)
            : base(context, token)
        {
            mSameNode = sameNode;
            mInitAction = initAction;
            ParentNode = mSameNode.ParentNode;
            mInitAction?.Invoke(this);
        }

        public override StateOfATNParsing_v2 GlobalState => StateOfATNParsing_v2.Condition_Subj_ModalVerb_Verb_Obj_TransOrFin;

        public ATNConditionSubjModalVerbVerbTransOrFinNode_v2 ParentNode { get; private set; }
        private ATNConditionSubjModalVerbVerbObjTransOrFinNode_v2 mSameNode;
        private InitATNConditionSubjModalVerbVerbObjTransOrFinNodeAction mInitAction;

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

