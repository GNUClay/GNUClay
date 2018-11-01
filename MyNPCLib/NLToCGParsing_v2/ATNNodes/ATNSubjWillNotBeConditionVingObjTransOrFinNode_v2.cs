using MyNPCLib.NLToCGParsing;
using System;
using System.Collections.Generic;
using System.Text;

namespace MyNPCLib.NLToCGParsing_v2.ATNNodes
{
    public delegate void InitATNSubjWillNotBeConditionVingObjTransOrFinNodeAction(ATNSubjWillNotBeConditionVingObjTransOrFinNode_v2 item);

    public class ATNSubjWillNotBeConditionVingObjTransOrFinNodeFactory_v2: BaseATNNodeFactory_v2
    {
        public ATNSubjWillNotBeConditionVingObjTransOrFinNodeFactory_v2(ATNSubjWillNotBeConditionVingTransOrFinNode_v2 parentNode, ATNExtendedToken token)
        {
            mNumberOfConstructor = 1;
            mParentNode = parentNode;
            mToken = token;
        }

        public ATNSubjWillNotBeConditionVingObjTransOrFinNodeFactory_v2(ATNSubjWillNotBeConditionVingObjTransOrFinNode_v2 sameNode, ATNExtendedToken token, InitATNSubjWillNotBeConditionVingObjTransOrFinNodeAction initAction)
        {
            mNumberOfConstructor = 2;
            mSameNode = sameNode;
            mToken = token;
            mInitAction = initAction;
        }

        private int mNumberOfConstructor;
        private ATNSubjWillNotBeConditionVingTransOrFinNode_v2 mParentNode;
        private ATNSubjWillNotBeConditionVingObjTransOrFinNode_v2 mSameNode;
        private ATNExtendedToken mToken;
        private InitATNSubjWillNotBeConditionVingObjTransOrFinNodeAction mInitAction;

        public override BaseATNNode_v2 Create(ContextOfATNParsing_v2 context)
        {
            switch(mNumberOfConstructor)
            {
                case 1:
                    return new ATNSubjWillNotBeConditionVingObjTransOrFinNode_v2(context, mParentNode, mToken);

                case 2:
                    return new ATNSubjWillNotBeConditionVingObjTransOrFinNode_v2(context, mSameNode, mInitAction, mToken);

                default:
                    throw new ArgumentOutOfRangeException(nameof(mNumberOfConstructor), mNumberOfConstructor, null);
            }
        }
    }

/*Sub states:
    Subj_Will_Not_Be_Condition_Ving_Obj_Condition_Fin
*/

    public class ATNSubjWillNotBeConditionVingObjTransOrFinNode_v2: BaseATNNode_v2
    {
        public ATNSubjWillNotBeConditionVingObjTransOrFinNode_v2(ContextOfATNParsing_v2 context, ATNSubjWillNotBeConditionVingTransOrFinNode_v2 parentNode, ATNExtendedToken token)
            : base(context, token)
        {
            ParentNode = parentNode;
        }

        public ATNSubjWillNotBeConditionVingObjTransOrFinNode_v2(ContextOfATNParsing_v2 context, ATNSubjWillNotBeConditionVingObjTransOrFinNode_v2 sameNode, InitATNSubjWillNotBeConditionVingObjTransOrFinNodeAction initAction, ATNExtendedToken token)
            : base(context, token)
        {
            mSameNode = sameNode;
            mInitAction = initAction;
            ParentNode = mSameNode.ParentNode;
            mInitAction?.Invoke(this);
        }

        public override StateOfATNParsing_v2 GlobalState => StateOfATNParsing_v2.Subj_Will_Not_Be_Condition_Ving_Obj_TransOrFin;

        public ATNSubjWillNotBeConditionVingTransOrFinNode_v2 ParentNode { get; private set; }
        private ATNSubjWillNotBeConditionVingObjTransOrFinNode_v2 mSameNode;
        private InitATNSubjWillNotBeConditionVingObjTransOrFinNodeAction mInitAction;

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

