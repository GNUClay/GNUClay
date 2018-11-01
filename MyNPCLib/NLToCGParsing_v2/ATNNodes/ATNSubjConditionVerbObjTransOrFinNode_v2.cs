using MyNPCLib.NLToCGParsing;
using System;
using System.Collections.Generic;
using System.Text;

namespace MyNPCLib.NLToCGParsing_v2.ATNNodes
{
    public delegate void InitATNSubjConditionVerbObjTransOrFinNodeAction(ATNSubjConditionVerbObjTransOrFinNode_v2 item);

    public class ATNSubjConditionVerbObjTransOrFinNodeFactory_v2: BaseATNNodeFactory_v2
    {
        public ATNSubjConditionVerbObjTransOrFinNodeFactory_v2(ATNSubjConditionVerbTransOrFinNode_v2 parentNode, ATNExtendedToken token)
        {
            mNumberOfConstructor = 1;
            mParentNode = parentNode;
            mToken = token;
        }

        public ATNSubjConditionVerbObjTransOrFinNodeFactory_v2(ATNSubjConditionVerbObjTransOrFinNode_v2 sameNode, ATNExtendedToken token, InitATNSubjConditionVerbObjTransOrFinNodeAction initAction)
        {
            mNumberOfConstructor = 2;
            mSameNode = sameNode;
            mToken = token;
            mInitAction = initAction;
        }

        private int mNumberOfConstructor;
        private ATNSubjConditionVerbTransOrFinNode_v2 mParentNode;
        private ATNSubjConditionVerbObjTransOrFinNode_v2 mSameNode;
        private ATNExtendedToken mToken;
        private InitATNSubjConditionVerbObjTransOrFinNodeAction mInitAction;

        public override BaseATNNode_v2 Create(ContextOfATNParsing_v2 context)
        {
            switch(mNumberOfConstructor)
            {
                case 1:
                    return new ATNSubjConditionVerbObjTransOrFinNode_v2(context, mParentNode, mToken);

                case 2:
                    return new ATNSubjConditionVerbObjTransOrFinNode_v2(context, mSameNode, mInitAction, mToken);

                default:
                    throw new ArgumentOutOfRangeException(nameof(mNumberOfConstructor), mNumberOfConstructor, null);
            }
        }
    }

/*Sub states:
    Subj_Condition_Verb_Obj_Condition_Fin
*/

    public class ATNSubjConditionVerbObjTransOrFinNode_v2: BaseATNNode_v2
    {
        public ATNSubjConditionVerbObjTransOrFinNode_v2(ContextOfATNParsing_v2 context, ATNSubjConditionVerbTransOrFinNode_v2 parentNode, ATNExtendedToken token)
            : base(context, token)
        {
            ParentNode = parentNode;
        }

        public ATNSubjConditionVerbObjTransOrFinNode_v2(ContextOfATNParsing_v2 context, ATNSubjConditionVerbObjTransOrFinNode_v2 sameNode, InitATNSubjConditionVerbObjTransOrFinNodeAction initAction, ATNExtendedToken token)
            : base(context, token)
        {
            mSameNode = sameNode;
            mInitAction = initAction;
            ParentNode = mSameNode.ParentNode;
            mInitAction?.Invoke(this);
        }

        public override StateOfATNParsing_v2 GlobalState => StateOfATNParsing_v2.Subj_Condition_Verb_Obj_TransOrFin;

        public ATNSubjConditionVerbTransOrFinNode_v2 ParentNode { get; private set; }
        private ATNSubjConditionVerbObjTransOrFinNode_v2 mSameNode;
        private InitATNSubjConditionVerbObjTransOrFinNodeAction mInitAction;

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

