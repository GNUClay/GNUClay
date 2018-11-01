using MyNPCLib.NLToCGParsing;
using System;
using System.Collections.Generic;
using System.Text;

namespace MyNPCLib.NLToCGParsing_v2.ATNNodes
{
    public delegate void InitATNConditionSubjWillBeV3ObjTransOrFinNodeAction(ATNConditionSubjWillBeV3ObjTransOrFinNode_v2 item);

    public class ATNConditionSubjWillBeV3ObjTransOrFinNodeFactory_v2: BaseATNNodeFactory_v2
    {
        public ATNConditionSubjWillBeV3ObjTransOrFinNodeFactory_v2(ATNConditionSubjWillBeV3TransOrFinNode_v2 parentNode, ATNExtendedToken token)
        {
            mNumberOfConstructor = 1;
            mParentNode = parentNode;
            mToken = token;
        }

        public ATNConditionSubjWillBeV3ObjTransOrFinNodeFactory_v2(ATNConditionSubjWillBeV3ObjTransOrFinNode_v2 sameNode, ATNExtendedToken token, InitATNConditionSubjWillBeV3ObjTransOrFinNodeAction initAction)
        {
            mNumberOfConstructor = 2;
            mSameNode = sameNode;
            mToken = token;
            mInitAction = initAction;
        }

        private int mNumberOfConstructor;
        private ATNConditionSubjWillBeV3TransOrFinNode_v2 mParentNode;
        private ATNConditionSubjWillBeV3ObjTransOrFinNode_v2 mSameNode;
        private ATNExtendedToken mToken;
        private InitATNConditionSubjWillBeV3ObjTransOrFinNodeAction mInitAction;

        public override BaseATNNode_v2 Create(ContextOfATNParsing_v2 context)
        {
            switch(mNumberOfConstructor)
            {
                case 1:
                    return new ATNConditionSubjWillBeV3ObjTransOrFinNode_v2(context, mParentNode, mToken);

                case 2:
                    return new ATNConditionSubjWillBeV3ObjTransOrFinNode_v2(context, mSameNode, mInitAction, mToken);

                default:
                    throw new ArgumentOutOfRangeException(nameof(mNumberOfConstructor), mNumberOfConstructor, null);
            }
        }
    }

/*Sub states:
    Condition_Subj_Will_Be_V3_Obj_Condition_Fin
*/

    public class ATNConditionSubjWillBeV3ObjTransOrFinNode_v2: BaseATNNode_v2
    {
        public ATNConditionSubjWillBeV3ObjTransOrFinNode_v2(ContextOfATNParsing_v2 context, ATNConditionSubjWillBeV3TransOrFinNode_v2 parentNode, ATNExtendedToken token)
            : base(context, token)
        {
            ParentNode = parentNode;
        }

        public ATNConditionSubjWillBeV3ObjTransOrFinNode_v2(ContextOfATNParsing_v2 context, ATNConditionSubjWillBeV3ObjTransOrFinNode_v2 sameNode, InitATNConditionSubjWillBeV3ObjTransOrFinNodeAction initAction, ATNExtendedToken token)
            : base(context, token)
        {
            mSameNode = sameNode;
            mInitAction = initAction;
            ParentNode = mSameNode.ParentNode;
            mInitAction?.Invoke(this);
        }

        public override StateOfATNParsing_v2 GlobalState => StateOfATNParsing_v2.Condition_Subj_Will_Be_V3_Obj_TransOrFin;

        public ATNConditionSubjWillBeV3TransOrFinNode_v2 ParentNode { get; private set; }
        private ATNConditionSubjWillBeV3ObjTransOrFinNode_v2 mSameNode;
        private InitATNConditionSubjWillBeV3ObjTransOrFinNodeAction mInitAction;

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

