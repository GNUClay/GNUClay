using MyNPCLib.NLToCGParsing;
using System;
using System.Collections.Generic;
using System.Text;

namespace MyNPCLib.NLToCGParsing_v2.ATNNodes
{
    public delegate void InitATNConditionSubjWillNotBeConditionVingObjTransOrFinNodeAction(ATNConditionSubjWillNotBeConditionVingObjTransOrFinNode_v2 item);

    public class ATNConditionSubjWillNotBeConditionVingObjTransOrFinNodeFactory_v2: BaseATNNodeFactory_v2
    {
        public ATNConditionSubjWillNotBeConditionVingObjTransOrFinNodeFactory_v2(ATNConditionSubjWillNotBeConditionVingTransOrFinNode_v2 parentNode, ATNExtendedToken token)
        {
            mNumberOfConstructor = 1;
            mParentNode = parentNode;
            mToken = token;
        }

        public ATNConditionSubjWillNotBeConditionVingObjTransOrFinNodeFactory_v2(ATNConditionSubjWillNotBeConditionVingObjTransOrFinNode_v2 sameNode, ATNExtendedToken token, InitATNConditionSubjWillNotBeConditionVingObjTransOrFinNodeAction initAction)
        {
            mNumberOfConstructor = 2;
            mSameNode = sameNode;
            mToken = token;
            mInitAction = initAction;
        }

        private int mNumberOfConstructor;
        private ATNConditionSubjWillNotBeConditionVingTransOrFinNode_v2 mParentNode;
        private ATNConditionSubjWillNotBeConditionVingObjTransOrFinNode_v2 mSameNode;
        private ATNExtendedToken mToken;
        private InitATNConditionSubjWillNotBeConditionVingObjTransOrFinNodeAction mInitAction;

        public override BaseATNNode_v2 Create(ContextOfATNParsing_v2 context)
        {
            switch(mNumberOfConstructor)
            {
                case 1:
                    return new ATNConditionSubjWillNotBeConditionVingObjTransOrFinNode_v2(context, mParentNode, mToken);

                case 2:
                    return new ATNConditionSubjWillNotBeConditionVingObjTransOrFinNode_v2(context, mSameNode, mInitAction, mToken);

                default:
                    throw new ArgumentOutOfRangeException(nameof(mNumberOfConstructor), mNumberOfConstructor, null);
            }
        }
    }

/*Sub states:
    Condition_Subj_Will_Not_Be_Condition_Ving_Obj_Condition_Fin
*/

    public class ATNConditionSubjWillNotBeConditionVingObjTransOrFinNode_v2: BaseATNNode_v2
    {
        public ATNConditionSubjWillNotBeConditionVingObjTransOrFinNode_v2(ContextOfATNParsing_v2 context, ATNConditionSubjWillNotBeConditionVingTransOrFinNode_v2 parentNode, ATNExtendedToken token)
            : base(context, token)
        {
            ParentNode = parentNode;
        }

        public ATNConditionSubjWillNotBeConditionVingObjTransOrFinNode_v2(ContextOfATNParsing_v2 context, ATNConditionSubjWillNotBeConditionVingObjTransOrFinNode_v2 sameNode, InitATNConditionSubjWillNotBeConditionVingObjTransOrFinNodeAction initAction, ATNExtendedToken token)
            : base(context, token)
        {
            mSameNode = sameNode;
            mInitAction = initAction;
            ParentNode = mSameNode.ParentNode;
            mInitAction?.Invoke(this);
        }

        public override StateOfATNParsing_v2 GlobalState => StateOfATNParsing_v2.Condition_Subj_Will_Not_Be_Condition_Ving_Obj_TransOrFin;

        public ATNConditionSubjWillNotBeConditionVingTransOrFinNode_v2 ParentNode { get; private set; }
        private ATNConditionSubjWillNotBeConditionVingObjTransOrFinNode_v2 mSameNode;
        private InitATNConditionSubjWillNotBeConditionVingObjTransOrFinNodeAction mInitAction;

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

