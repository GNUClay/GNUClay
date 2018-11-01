using MyNPCLib.NLToCGParsing;
using System;
using System.Collections.Generic;
using System.Text;

namespace MyNPCLib.NLToCGParsing_v2.ATNNodes
{
    public delegate void InitATNConditionWillSubjVerbObjTransOrFinNodeAction(ATNConditionWillSubjVerbObjTransOrFinNode_v2 item);

    public class ATNConditionWillSubjVerbObjTransOrFinNodeFactory_v2: BaseATNNodeFactory_v2
    {
        public ATNConditionWillSubjVerbObjTransOrFinNodeFactory_v2(ATNConditionWillSubjVerbTransOrFinNode_v2 parentNode, ATNExtendedToken token)
        {
            mNumberOfConstructor = 1;
            mParentNode = parentNode;
            mToken = token;
        }

        public ATNConditionWillSubjVerbObjTransOrFinNodeFactory_v2(ATNConditionWillSubjVerbObjTransOrFinNode_v2 sameNode, ATNExtendedToken token, InitATNConditionWillSubjVerbObjTransOrFinNodeAction initAction)
        {
            mNumberOfConstructor = 2;
            mSameNode = sameNode;
            mToken = token;
            mInitAction = initAction;
        }

        private int mNumberOfConstructor;
        private ATNConditionWillSubjVerbTransOrFinNode_v2 mParentNode;
        private ATNConditionWillSubjVerbObjTransOrFinNode_v2 mSameNode;
        private ATNExtendedToken mToken;
        private InitATNConditionWillSubjVerbObjTransOrFinNodeAction mInitAction;

        public override BaseATNNode_v2 Create(ContextOfATNParsing_v2 context)
        {
            switch(mNumberOfConstructor)
            {
                case 1:
                    return new ATNConditionWillSubjVerbObjTransOrFinNode_v2(context, mParentNode, mToken);

                case 2:
                    return new ATNConditionWillSubjVerbObjTransOrFinNode_v2(context, mSameNode, mInitAction, mToken);

                default:
                    throw new ArgumentOutOfRangeException(nameof(mNumberOfConstructor), mNumberOfConstructor, null);
            }
        }
    }

/*Sub states:
    Condition_Will_Subj_Verb_Obj_Condition_Fin
*/

    public class ATNConditionWillSubjVerbObjTransOrFinNode_v2: BaseATNNode_v2
    {
        public ATNConditionWillSubjVerbObjTransOrFinNode_v2(ContextOfATNParsing_v2 context, ATNConditionWillSubjVerbTransOrFinNode_v2 parentNode, ATNExtendedToken token)
            : base(context, token)
        {
            ParentNode = parentNode;
        }

        public ATNConditionWillSubjVerbObjTransOrFinNode_v2(ContextOfATNParsing_v2 context, ATNConditionWillSubjVerbObjTransOrFinNode_v2 sameNode, InitATNConditionWillSubjVerbObjTransOrFinNodeAction initAction, ATNExtendedToken token)
            : base(context, token)
        {
            mSameNode = sameNode;
            mInitAction = initAction;
            ParentNode = mSameNode.ParentNode;
            mInitAction?.Invoke(this);
        }

        public override StateOfATNParsing_v2 GlobalState => StateOfATNParsing_v2.Condition_Will_Subj_Verb_Obj_TransOrFin;

        public ATNConditionWillSubjVerbTransOrFinNode_v2 ParentNode { get; private set; }
        private ATNConditionWillSubjVerbObjTransOrFinNode_v2 mSameNode;
        private InitATNConditionWillSubjVerbObjTransOrFinNodeAction mInitAction;

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

