using MyNPCLib.NLToCGParsing;
using System;
using System.Collections.Generic;
using System.Text;

namespace MyNPCLib.NLToCGParsing_v2.ATNNodes
{
    public delegate void InitATNConditionSubjVerbObjTransOrFinNodeAction(ATNConditionSubjVerbObjTransOrFinNode_v2 item);

    public class ATNConditionSubjVerbObjTransOrFinNodeFactory_v2: BaseATNNodeFactory_v2
    {
        public ATNConditionSubjVerbObjTransOrFinNodeFactory_v2(ATNConditionSubjVerbTransOrFinNode_v2 parentNode, ATNExtendedToken token)
        {
            mNumberOfConstructor = 1;
            mParentNode = parentNode;
            mToken = token;
        }

        public ATNConditionSubjVerbObjTransOrFinNodeFactory_v2(ATNConditionSubjVerbObjTransOrFinNode_v2 sameNode, ATNExtendedToken token, InitATNConditionSubjVerbObjTransOrFinNodeAction initAction)
        {
            mNumberOfConstructor = 2;
            mSameNode = sameNode;
            mToken = token;
            mInitAction = initAction;
        }

        private int mNumberOfConstructor;
        private ATNConditionSubjVerbTransOrFinNode_v2 mParentNode;
        private ATNConditionSubjVerbObjTransOrFinNode_v2 mSameNode;
        private ATNExtendedToken mToken;
        private InitATNConditionSubjVerbObjTransOrFinNodeAction mInitAction;

        public override BaseATNNode_v2 Create(ContextOfATNParsing_v2 context)
        {
            switch(mNumberOfConstructor)
            {
                case 1:
                    return new ATNConditionSubjVerbObjTransOrFinNode_v2(context, mParentNode, mToken);

                case 2:
                    return new ATNConditionSubjVerbObjTransOrFinNode_v2(context, mSameNode, mInitAction, mToken);

                default:
                    throw new ArgumentOutOfRangeException(nameof(mNumberOfConstructor), mNumberOfConstructor, null);
            }
        }
    }

/*Sub states:
    Condition_Subj_Verb_Obj_Condition_Fin
*/

    public class ATNConditionSubjVerbObjTransOrFinNode_v2: BaseATNNode_v2
    {
        public ATNConditionSubjVerbObjTransOrFinNode_v2(ContextOfATNParsing_v2 context, ATNConditionSubjVerbTransOrFinNode_v2 parentNode, ATNExtendedToken token)
            : base(context, token)
        {
            ParentNode = parentNode;
        }

        public ATNConditionSubjVerbObjTransOrFinNode_v2(ContextOfATNParsing_v2 context, ATNConditionSubjVerbObjTransOrFinNode_v2 sameNode, InitATNConditionSubjVerbObjTransOrFinNodeAction initAction, ATNExtendedToken token)
            : base(context, token)
        {
            mSameNode = sameNode;
            mInitAction = initAction;
            ParentNode = mSameNode.ParentNode;
            mInitAction?.Invoke(this);
        }

        public override StateOfATNParsing_v2 GlobalState => StateOfATNParsing_v2.Condition_Subj_Verb_Obj_TransOrFin;

        public ATNConditionSubjVerbTransOrFinNode_v2 ParentNode { get; private set; }
        private ATNConditionSubjVerbObjTransOrFinNode_v2 mSameNode;
        private InitATNConditionSubjVerbObjTransOrFinNodeAction mInitAction;

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

