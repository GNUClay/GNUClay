using MyNPCLib.NLToCGParsing;
using System;
using System.Collections.Generic;
using System.Text;

namespace MyNPCLib.NLToCGParsing_v2.ATNNodes
{
    public delegate void InitATNConditionQWSubjWillVerbObjTransOrFinNodeAction(ATNConditionQWSubjWillVerbObjTransOrFinNode_v2 item);

    public class ATNConditionQWSubjWillVerbObjTransOrFinNodeFactory_v2: BaseATNNodeFactory_v2
    {
        public ATNConditionQWSubjWillVerbObjTransOrFinNodeFactory_v2(ATNConditionQWSubjWillVerbTransOrFinNode_v2 parentNode, ATNExtendedToken token)
        {
            mNumberOfConstructor = 1;
            mParentNode = parentNode;
            mToken = token;
        }

        public ATNConditionQWSubjWillVerbObjTransOrFinNodeFactory_v2(ATNConditionQWSubjWillVerbObjTransOrFinNode_v2 sameNode, ATNExtendedToken token, InitATNConditionQWSubjWillVerbObjTransOrFinNodeAction initAction)
        {
            mNumberOfConstructor = 2;
            mSameNode = sameNode;
            mToken = token;
            mInitAction = initAction;
        }

        private int mNumberOfConstructor;
        private ATNConditionQWSubjWillVerbTransOrFinNode_v2 mParentNode;
        private ATNConditionQWSubjWillVerbObjTransOrFinNode_v2 mSameNode;
        private ATNExtendedToken mToken;
        private InitATNConditionQWSubjWillVerbObjTransOrFinNodeAction mInitAction;

        public override BaseATNNode_v2 Create(ContextOfATNParsing_v2 context)
        {
            switch(mNumberOfConstructor)
            {
                case 1:
                    return new ATNConditionQWSubjWillVerbObjTransOrFinNode_v2(context, mParentNode, mToken);

                case 2:
                    return new ATNConditionQWSubjWillVerbObjTransOrFinNode_v2(context, mSameNode, mInitAction, mToken);

                default:
                    throw new ArgumentOutOfRangeException(nameof(mNumberOfConstructor), mNumberOfConstructor, null);
            }
        }
    }

/*Sub states:
    Condition_QWSubj_Will_Verb_Obj_Condition_Fin
*/

    public class ATNConditionQWSubjWillVerbObjTransOrFinNode_v2: BaseATNNode_v2
    {
        public ATNConditionQWSubjWillVerbObjTransOrFinNode_v2(ContextOfATNParsing_v2 context, ATNConditionQWSubjWillVerbTransOrFinNode_v2 parentNode, ATNExtendedToken token)
            : base(context, token)
        {
            ParentNode = parentNode;
        }

        public ATNConditionQWSubjWillVerbObjTransOrFinNode_v2(ContextOfATNParsing_v2 context, ATNConditionQWSubjWillVerbObjTransOrFinNode_v2 sameNode, InitATNConditionQWSubjWillVerbObjTransOrFinNodeAction initAction, ATNExtendedToken token)
            : base(context, token)
        {
            mSameNode = sameNode;
            mInitAction = initAction;
            ParentNode = mSameNode.ParentNode;
            mInitAction?.Invoke(this);
        }

        public override StateOfATNParsing_v2 GlobalState => StateOfATNParsing_v2.Condition_QWSubj_Will_Verb_Obj_TransOrFin;

        public ATNConditionQWSubjWillVerbTransOrFinNode_v2 ParentNode { get; private set; }
        private ATNConditionQWSubjWillVerbObjTransOrFinNode_v2 mSameNode;
        private InitATNConditionQWSubjWillVerbObjTransOrFinNodeAction mInitAction;

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

