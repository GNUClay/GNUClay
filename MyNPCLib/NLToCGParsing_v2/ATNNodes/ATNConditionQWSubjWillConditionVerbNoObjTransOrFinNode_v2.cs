using MyNPCLib.NLToCGParsing;
using System;
using System.Collections.Generic;
using System.Text;

namespace MyNPCLib.NLToCGParsing_v2.ATNNodes
{
    public delegate void InitATNConditionQWSubjWillConditionVerbNoObjTransOrFinNodeAction(ATNConditionQWSubjWillConditionVerbNoObjTransOrFinNode_v2 item);

    public class ATNConditionQWSubjWillConditionVerbNoObjTransOrFinNodeFactory_v2: BaseATNNodeFactory_v2
    {
        public ATNConditionQWSubjWillConditionVerbNoObjTransOrFinNodeFactory_v2(ATNConditionQWSubjWillConditionVerbNoTransNode_v2 parentNode, ATNExtendedToken token)
        {
            mNumberOfConstructor = 1;
            mParentNode = parentNode;
            mToken = token;
        }

        public ATNConditionQWSubjWillConditionVerbNoObjTransOrFinNodeFactory_v2(ATNConditionQWSubjWillConditionVerbNoObjTransOrFinNode_v2 sameNode, ATNExtendedToken token, InitATNConditionQWSubjWillConditionVerbNoObjTransOrFinNodeAction initAction)
        {
            mNumberOfConstructor = 2;
            mSameNode = sameNode;
            mToken = token;
            mInitAction = initAction;
        }

        private int mNumberOfConstructor;
        private ATNConditionQWSubjWillConditionVerbNoTransNode_v2 mParentNode;
        private ATNConditionQWSubjWillConditionVerbNoObjTransOrFinNode_v2 mSameNode;
        private ATNExtendedToken mToken;
        private InitATNConditionQWSubjWillConditionVerbNoObjTransOrFinNodeAction mInitAction;

        public override BaseATNNode_v2 Create(ContextOfATNParsing_v2 context)
        {
            switch(mNumberOfConstructor)
            {
                case 1:
                    return new ATNConditionQWSubjWillConditionVerbNoObjTransOrFinNode_v2(context, mParentNode, mToken);

                case 2:
                    return new ATNConditionQWSubjWillConditionVerbNoObjTransOrFinNode_v2(context, mSameNode, mInitAction, mToken);

                default:
                    throw new ArgumentOutOfRangeException(nameof(mNumberOfConstructor), mNumberOfConstructor, null);
            }
        }
    }

/*Sub states:
    Condition_QWSubj_Will_Condition_Verb_No_Obj_Condition_Fin
*/

    public class ATNConditionQWSubjWillConditionVerbNoObjTransOrFinNode_v2: BaseATNNode_v2
    {
        public ATNConditionQWSubjWillConditionVerbNoObjTransOrFinNode_v2(ContextOfATNParsing_v2 context, ATNConditionQWSubjWillConditionVerbNoTransNode_v2 parentNode, ATNExtendedToken token)
            : base(context, token)
        {
            ParentNode = parentNode;
        }

        public ATNConditionQWSubjWillConditionVerbNoObjTransOrFinNode_v2(ContextOfATNParsing_v2 context, ATNConditionQWSubjWillConditionVerbNoObjTransOrFinNode_v2 sameNode, InitATNConditionQWSubjWillConditionVerbNoObjTransOrFinNodeAction initAction, ATNExtendedToken token)
            : base(context, token)
        {
            mSameNode = sameNode;
            mInitAction = initAction;
            ParentNode = mSameNode.ParentNode;
            mInitAction?.Invoke(this);
        }

        public override StateOfATNParsing_v2 GlobalState => StateOfATNParsing_v2.Condition_QWSubj_Will_Condition_Verb_No_Obj_TransOrFin;

        public ATNConditionQWSubjWillConditionVerbNoTransNode_v2 ParentNode { get; private set; }
        private ATNConditionQWSubjWillConditionVerbNoObjTransOrFinNode_v2 mSameNode;
        private InitATNConditionQWSubjWillConditionVerbNoObjTransOrFinNodeAction mInitAction;

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

