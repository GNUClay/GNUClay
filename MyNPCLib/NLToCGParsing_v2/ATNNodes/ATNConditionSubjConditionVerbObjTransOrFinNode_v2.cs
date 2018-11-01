using MyNPCLib.NLToCGParsing;
using System;
using System.Collections.Generic;
using System.Text;

namespace MyNPCLib.NLToCGParsing_v2.ATNNodes
{
    public delegate void InitATNConditionSubjConditionVerbObjTransOrFinNodeAction(ATNConditionSubjConditionVerbObjTransOrFinNode_v2 item);

    public class ATNConditionSubjConditionVerbObjTransOrFinNodeFactory_v2: BaseATNNodeFactory_v2
    {
        public ATNConditionSubjConditionVerbObjTransOrFinNodeFactory_v2(ATNConditionSubjConditionVerbTransOrFinNode_v2 parentNode, ATNExtendedToken token)
        {
            mNumberOfConstructor = 1;
            mParentNode = parentNode;
            mToken = token;
        }

        public ATNConditionSubjConditionVerbObjTransOrFinNodeFactory_v2(ATNConditionSubjConditionVerbObjTransOrFinNode_v2 sameNode, ATNExtendedToken token, InitATNConditionSubjConditionVerbObjTransOrFinNodeAction initAction)
        {
            mNumberOfConstructor = 2;
            mSameNode = sameNode;
            mToken = token;
            mInitAction = initAction;
        }

        private int mNumberOfConstructor;
        private ATNConditionSubjConditionVerbTransOrFinNode_v2 mParentNode;
        private ATNConditionSubjConditionVerbObjTransOrFinNode_v2 mSameNode;
        private ATNExtendedToken mToken;
        private InitATNConditionSubjConditionVerbObjTransOrFinNodeAction mInitAction;

        public override BaseATNNode_v2 Create(ContextOfATNParsing_v2 context)
        {
            switch(mNumberOfConstructor)
            {
                case 1:
                    return new ATNConditionSubjConditionVerbObjTransOrFinNode_v2(context, mParentNode, mToken);

                case 2:
                    return new ATNConditionSubjConditionVerbObjTransOrFinNode_v2(context, mSameNode, mInitAction, mToken);

                default:
                    throw new ArgumentOutOfRangeException(nameof(mNumberOfConstructor), mNumberOfConstructor, null);
            }
        }
    }

/*Sub states:
    Condition_Subj_Condition_Verb_Obj_Condition_Fin
*/

    public class ATNConditionSubjConditionVerbObjTransOrFinNode_v2: BaseATNNode_v2
    {
        public ATNConditionSubjConditionVerbObjTransOrFinNode_v2(ContextOfATNParsing_v2 context, ATNConditionSubjConditionVerbTransOrFinNode_v2 parentNode, ATNExtendedToken token)
            : base(context, token)
        {
            ParentNode = parentNode;
        }

        public ATNConditionSubjConditionVerbObjTransOrFinNode_v2(ContextOfATNParsing_v2 context, ATNConditionSubjConditionVerbObjTransOrFinNode_v2 sameNode, InitATNConditionSubjConditionVerbObjTransOrFinNodeAction initAction, ATNExtendedToken token)
            : base(context, token)
        {
            mSameNode = sameNode;
            mInitAction = initAction;
            ParentNode = mSameNode.ParentNode;
            mInitAction?.Invoke(this);
        }

        public override StateOfATNParsing_v2 GlobalState => StateOfATNParsing_v2.Condition_Subj_Condition_Verb_Obj_TransOrFin;

        public ATNConditionSubjConditionVerbTransOrFinNode_v2 ParentNode { get; private set; }
        private ATNConditionSubjConditionVerbObjTransOrFinNode_v2 mSameNode;
        private InitATNConditionSubjConditionVerbObjTransOrFinNodeAction mInitAction;

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

