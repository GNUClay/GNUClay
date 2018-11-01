using MyNPCLib.NLToCGParsing;
using System;
using System.Collections.Generic;
using System.Text;

namespace MyNPCLib.NLToCGParsing_v2.ATNNodes
{
    public delegate void InitATNConditionQWSubjWillBeConditionV3ObjTransOrFinNodeAction(ATNConditionQWSubjWillBeConditionV3ObjTransOrFinNode_v2 item);

    public class ATNConditionQWSubjWillBeConditionV3ObjTransOrFinNodeFactory_v2: BaseATNNodeFactory_v2
    {
        public ATNConditionQWSubjWillBeConditionV3ObjTransOrFinNodeFactory_v2(ATNConditionQWSubjWillBeConditionV3TransOrFinNode_v2 parentNode, ATNExtendedToken token)
        {
            mNumberOfConstructor = 1;
            mParentNode = parentNode;
            mToken = token;
        }

        public ATNConditionQWSubjWillBeConditionV3ObjTransOrFinNodeFactory_v2(ATNConditionQWSubjWillBeConditionV3ObjTransOrFinNode_v2 sameNode, ATNExtendedToken token, InitATNConditionQWSubjWillBeConditionV3ObjTransOrFinNodeAction initAction)
        {
            mNumberOfConstructor = 2;
            mSameNode = sameNode;
            mToken = token;
            mInitAction = initAction;
        }

        private int mNumberOfConstructor;
        private ATNConditionQWSubjWillBeConditionV3TransOrFinNode_v2 mParentNode;
        private ATNConditionQWSubjWillBeConditionV3ObjTransOrFinNode_v2 mSameNode;
        private ATNExtendedToken mToken;
        private InitATNConditionQWSubjWillBeConditionV3ObjTransOrFinNodeAction mInitAction;

        public override BaseATNNode_v2 Create(ContextOfATNParsing_v2 context)
        {
            switch(mNumberOfConstructor)
            {
                case 1:
                    return new ATNConditionQWSubjWillBeConditionV3ObjTransOrFinNode_v2(context, mParentNode, mToken);

                case 2:
                    return new ATNConditionQWSubjWillBeConditionV3ObjTransOrFinNode_v2(context, mSameNode, mInitAction, mToken);

                default:
                    throw new ArgumentOutOfRangeException(nameof(mNumberOfConstructor), mNumberOfConstructor, null);
            }
        }
    }

/*Sub states:
    Condition_QWSubj_Will_Be_Condition_V3_Obj_Condition_Fin
*/

    public class ATNConditionQWSubjWillBeConditionV3ObjTransOrFinNode_v2: BaseATNNode_v2
    {
        public ATNConditionQWSubjWillBeConditionV3ObjTransOrFinNode_v2(ContextOfATNParsing_v2 context, ATNConditionQWSubjWillBeConditionV3TransOrFinNode_v2 parentNode, ATNExtendedToken token)
            : base(context, token)
        {
            ParentNode = parentNode;
        }

        public ATNConditionQWSubjWillBeConditionV3ObjTransOrFinNode_v2(ContextOfATNParsing_v2 context, ATNConditionQWSubjWillBeConditionV3ObjTransOrFinNode_v2 sameNode, InitATNConditionQWSubjWillBeConditionV3ObjTransOrFinNodeAction initAction, ATNExtendedToken token)
            : base(context, token)
        {
            mSameNode = sameNode;
            mInitAction = initAction;
            ParentNode = mSameNode.ParentNode;
            mInitAction?.Invoke(this);
        }

        public override StateOfATNParsing_v2 GlobalState => StateOfATNParsing_v2.Condition_QWSubj_Will_Be_Condition_V3_Obj_TransOrFin;

        public ATNConditionQWSubjWillBeConditionV3TransOrFinNode_v2 ParentNode { get; private set; }
        private ATNConditionQWSubjWillBeConditionV3ObjTransOrFinNode_v2 mSameNode;
        private InitATNConditionQWSubjWillBeConditionV3ObjTransOrFinNodeAction mInitAction;

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

