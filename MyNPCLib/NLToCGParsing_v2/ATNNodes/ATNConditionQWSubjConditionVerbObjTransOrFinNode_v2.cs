using MyNPCLib.NLToCGParsing;
using System;
using System.Collections.Generic;
using System.Text;

namespace MyNPCLib.NLToCGParsing_v2.ATNNodes
{
    public delegate void InitATNConditionQWSubjConditionVerbObjTransOrFinNodeAction(ATNConditionQWSubjConditionVerbObjTransOrFinNode_v2 item);

    public class ATNConditionQWSubjConditionVerbObjTransOrFinNodeFactory_v2: BaseATNNodeFactory_v2
    {
        public ATNConditionQWSubjConditionVerbObjTransOrFinNodeFactory_v2(ATNConditionQWSubjConditionVerbTransOrFinNode_v2 parentNode, ATNExtendedToken token)
        {
            mNumberOfConstructor = 1;
            mParentNode = parentNode;
            mToken = token;
        }

        public ATNConditionQWSubjConditionVerbObjTransOrFinNodeFactory_v2(ATNConditionQWSubjConditionVerbObjTransOrFinNode_v2 sameNode, ATNExtendedToken token, InitATNConditionQWSubjConditionVerbObjTransOrFinNodeAction initAction)
        {
            mNumberOfConstructor = 2;
            mSameNode = sameNode;
            mToken = token;
            mInitAction = initAction;
        }

        private int mNumberOfConstructor;
        private ATNConditionQWSubjConditionVerbTransOrFinNode_v2 mParentNode;
        private ATNConditionQWSubjConditionVerbObjTransOrFinNode_v2 mSameNode;
        private ATNExtendedToken mToken;
        private InitATNConditionQWSubjConditionVerbObjTransOrFinNodeAction mInitAction;

        public override BaseATNNode_v2 Create(ContextOfATNParsing_v2 context)
        {
            switch(mNumberOfConstructor)
            {
                case 1:
                    return new ATNConditionQWSubjConditionVerbObjTransOrFinNode_v2(context, mParentNode, mToken);

                case 2:
                    return new ATNConditionQWSubjConditionVerbObjTransOrFinNode_v2(context, mSameNode, mInitAction, mToken);

                default:
                    throw new ArgumentOutOfRangeException(nameof(mNumberOfConstructor), mNumberOfConstructor, null);
            }
        }
    }

/*Sub states:
    Condition_QWSubj_Condition_Verb_Obj_Condition_Fin
*/

    public class ATNConditionQWSubjConditionVerbObjTransOrFinNode_v2: BaseATNNode_v2
    {
        public ATNConditionQWSubjConditionVerbObjTransOrFinNode_v2(ContextOfATNParsing_v2 context, ATNConditionQWSubjConditionVerbTransOrFinNode_v2 parentNode, ATNExtendedToken token)
            : base(context, token)
        {
            ParentNode = parentNode;
        }

        public ATNConditionQWSubjConditionVerbObjTransOrFinNode_v2(ContextOfATNParsing_v2 context, ATNConditionQWSubjConditionVerbObjTransOrFinNode_v2 sameNode, InitATNConditionQWSubjConditionVerbObjTransOrFinNodeAction initAction, ATNExtendedToken token)
            : base(context, token)
        {
            mSameNode = sameNode;
            mInitAction = initAction;
            ParentNode = mSameNode.ParentNode;
            mInitAction?.Invoke(this);
        }

        public override StateOfATNParsing_v2 GlobalState => StateOfATNParsing_v2.Condition_QWSubj_Condition_Verb_Obj_TransOrFin;

        public ATNConditionQWSubjConditionVerbTransOrFinNode_v2 ParentNode { get; private set; }
        private ATNConditionQWSubjConditionVerbObjTransOrFinNode_v2 mSameNode;
        private InitATNConditionQWSubjConditionVerbObjTransOrFinNodeAction mInitAction;

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

