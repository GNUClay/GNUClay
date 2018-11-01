using MyNPCLib.NLToCGParsing;
using System;
using System.Collections.Generic;
using System.Text;

namespace MyNPCLib.NLToCGParsing_v2.ATNNodes
{
    public delegate void InitATNSubjWillNotBeConditionV3ObjTransOrFinNodeAction(ATNSubjWillNotBeConditionV3ObjTransOrFinNode_v2 item);

    public class ATNSubjWillNotBeConditionV3ObjTransOrFinNodeFactory_v2: BaseATNNodeFactory_v2
    {
        public ATNSubjWillNotBeConditionV3ObjTransOrFinNodeFactory_v2(ATNSubjWillNotBeConditionV3TransOrFinNode_v2 parentNode, ATNExtendedToken token)
        {
            mNumberOfConstructor = 1;
            mParentNode = parentNode;
            mToken = token;
        }

        public ATNSubjWillNotBeConditionV3ObjTransOrFinNodeFactory_v2(ATNSubjWillNotBeConditionV3ObjTransOrFinNode_v2 sameNode, ATNExtendedToken token, InitATNSubjWillNotBeConditionV3ObjTransOrFinNodeAction initAction)
        {
            mNumberOfConstructor = 2;
            mSameNode = sameNode;
            mToken = token;
            mInitAction = initAction;
        }

        private int mNumberOfConstructor;
        private ATNSubjWillNotBeConditionV3TransOrFinNode_v2 mParentNode;
        private ATNSubjWillNotBeConditionV3ObjTransOrFinNode_v2 mSameNode;
        private ATNExtendedToken mToken;
        private InitATNSubjWillNotBeConditionV3ObjTransOrFinNodeAction mInitAction;

        public override BaseATNNode_v2 Create(ContextOfATNParsing_v2 context)
        {
            switch(mNumberOfConstructor)
            {
                case 1:
                    return new ATNSubjWillNotBeConditionV3ObjTransOrFinNode_v2(context, mParentNode, mToken);

                case 2:
                    return new ATNSubjWillNotBeConditionV3ObjTransOrFinNode_v2(context, mSameNode, mInitAction, mToken);

                default:
                    throw new ArgumentOutOfRangeException(nameof(mNumberOfConstructor), mNumberOfConstructor, null);
            }
        }
    }

/*Sub states:
    Subj_Will_Not_Be_Condition_V3_Obj_Condition_Fin
*/

    public class ATNSubjWillNotBeConditionV3ObjTransOrFinNode_v2: BaseATNNode_v2
    {
        public ATNSubjWillNotBeConditionV3ObjTransOrFinNode_v2(ContextOfATNParsing_v2 context, ATNSubjWillNotBeConditionV3TransOrFinNode_v2 parentNode, ATNExtendedToken token)
            : base(context, token)
        {
            ParentNode = parentNode;
        }

        public ATNSubjWillNotBeConditionV3ObjTransOrFinNode_v2(ContextOfATNParsing_v2 context, ATNSubjWillNotBeConditionV3ObjTransOrFinNode_v2 sameNode, InitATNSubjWillNotBeConditionV3ObjTransOrFinNodeAction initAction, ATNExtendedToken token)
            : base(context, token)
        {
            mSameNode = sameNode;
            mInitAction = initAction;
            ParentNode = mSameNode.ParentNode;
            mInitAction?.Invoke(this);
        }

        public override StateOfATNParsing_v2 GlobalState => StateOfATNParsing_v2.Subj_Will_Not_Be_Condition_V3_Obj_TransOrFin;

        public ATNSubjWillNotBeConditionV3TransOrFinNode_v2 ParentNode { get; private set; }
        private ATNSubjWillNotBeConditionV3ObjTransOrFinNode_v2 mSameNode;
        private InitATNSubjWillNotBeConditionV3ObjTransOrFinNodeAction mInitAction;

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

