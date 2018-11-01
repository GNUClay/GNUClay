using MyNPCLib.NLToCGParsing;
using System;
using System.Collections.Generic;
using System.Text;

namespace MyNPCLib.NLToCGParsing_v2.ATNNodes
{
    public delegate void InitATNConditionWillSubjConditionVerbObjTransOrFinNodeAction(ATNConditionWillSubjConditionVerbObjTransOrFinNode_v2 item);

    public class ATNConditionWillSubjConditionVerbObjTransOrFinNodeFactory_v2: BaseATNNodeFactory_v2
    {
        public ATNConditionWillSubjConditionVerbObjTransOrFinNodeFactory_v2(ATNConditionWillSubjConditionVerbTransOrFinNode_v2 parentNode, ATNExtendedToken token)
        {
            mNumberOfConstructor = 1;
            mParentNode = parentNode;
            mToken = token;
        }

        public ATNConditionWillSubjConditionVerbObjTransOrFinNodeFactory_v2(ATNConditionWillSubjConditionVerbObjTransOrFinNode_v2 sameNode, ATNExtendedToken token, InitATNConditionWillSubjConditionVerbObjTransOrFinNodeAction initAction)
        {
            mNumberOfConstructor = 2;
            mSameNode = sameNode;
            mToken = token;
            mInitAction = initAction;
        }

        private int mNumberOfConstructor;
        private ATNConditionWillSubjConditionVerbTransOrFinNode_v2 mParentNode;
        private ATNConditionWillSubjConditionVerbObjTransOrFinNode_v2 mSameNode;
        private ATNExtendedToken mToken;
        private InitATNConditionWillSubjConditionVerbObjTransOrFinNodeAction mInitAction;

        public override BaseATNNode_v2 Create(ContextOfATNParsing_v2 context)
        {
            switch(mNumberOfConstructor)
            {
                case 1:
                    return new ATNConditionWillSubjConditionVerbObjTransOrFinNode_v2(context, mParentNode, mToken);

                case 2:
                    return new ATNConditionWillSubjConditionVerbObjTransOrFinNode_v2(context, mSameNode, mInitAction, mToken);

                default:
                    throw new ArgumentOutOfRangeException(nameof(mNumberOfConstructor), mNumberOfConstructor, null);
            }
        }
    }

/*Sub states:
    Condition_Will_Subj_Condition_Verb_Obj_Condition_Fin
*/

    public class ATNConditionWillSubjConditionVerbObjTransOrFinNode_v2: BaseATNNode_v2
    {
        public ATNConditionWillSubjConditionVerbObjTransOrFinNode_v2(ContextOfATNParsing_v2 context, ATNConditionWillSubjConditionVerbTransOrFinNode_v2 parentNode, ATNExtendedToken token)
            : base(context, token)
        {
            ParentNode = parentNode;
        }

        public ATNConditionWillSubjConditionVerbObjTransOrFinNode_v2(ContextOfATNParsing_v2 context, ATNConditionWillSubjConditionVerbObjTransOrFinNode_v2 sameNode, InitATNConditionWillSubjConditionVerbObjTransOrFinNodeAction initAction, ATNExtendedToken token)
            : base(context, token)
        {
            mSameNode = sameNode;
            mInitAction = initAction;
            ParentNode = mSameNode.ParentNode;
            mInitAction?.Invoke(this);
        }

        public override StateOfATNParsing_v2 GlobalState => StateOfATNParsing_v2.Condition_Will_Subj_Condition_Verb_Obj_TransOrFin;

        public ATNConditionWillSubjConditionVerbTransOrFinNode_v2 ParentNode { get; private set; }
        private ATNConditionWillSubjConditionVerbObjTransOrFinNode_v2 mSameNode;
        private InitATNConditionWillSubjConditionVerbObjTransOrFinNodeAction mInitAction;

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

