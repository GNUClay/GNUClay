using MyNPCLib.NLToCGParsing;
using System;
using System.Collections.Generic;
using System.Text;

namespace MyNPCLib.NLToCGParsing_v2.ATNNodes
{
    public delegate void InitATNConditionWillSubjBeConditionVingObjTransOrFinNodeAction(ATNConditionWillSubjBeConditionVingObjTransOrFinNode_v2 item);

    public class ATNConditionWillSubjBeConditionVingObjTransOrFinNodeFactory_v2: BaseATNNodeFactory_v2
    {
        public ATNConditionWillSubjBeConditionVingObjTransOrFinNodeFactory_v2(ATNConditionWillSubjBeConditionVingTransOrFinNode_v2 parentNode, ATNExtendedToken token)
        {
            mNumberOfConstructor = 1;
            mParentNode = parentNode;
            mToken = token;
        }

        public ATNConditionWillSubjBeConditionVingObjTransOrFinNodeFactory_v2(ATNConditionWillSubjBeConditionVingObjTransOrFinNode_v2 sameNode, ATNExtendedToken token, InitATNConditionWillSubjBeConditionVingObjTransOrFinNodeAction initAction)
        {
            mNumberOfConstructor = 2;
            mSameNode = sameNode;
            mToken = token;
            mInitAction = initAction;
        }

        private int mNumberOfConstructor;
        private ATNConditionWillSubjBeConditionVingTransOrFinNode_v2 mParentNode;
        private ATNConditionWillSubjBeConditionVingObjTransOrFinNode_v2 mSameNode;
        private ATNExtendedToken mToken;
        private InitATNConditionWillSubjBeConditionVingObjTransOrFinNodeAction mInitAction;

        public override BaseATNNode_v2 Create(ContextOfATNParsing_v2 context)
        {
            switch(mNumberOfConstructor)
            {
                case 1:
                    return new ATNConditionWillSubjBeConditionVingObjTransOrFinNode_v2(context, mParentNode, mToken);

                case 2:
                    return new ATNConditionWillSubjBeConditionVingObjTransOrFinNode_v2(context, mSameNode, mInitAction, mToken);

                default:
                    throw new ArgumentOutOfRangeException(nameof(mNumberOfConstructor), mNumberOfConstructor, null);
            }
        }
    }

/*Sub states:
    Condition_Will_Subj_Be_Condition_Ving_Obj_Condition_Fin
*/

    public class ATNConditionWillSubjBeConditionVingObjTransOrFinNode_v2: BaseATNNode_v2
    {
        public ATNConditionWillSubjBeConditionVingObjTransOrFinNode_v2(ContextOfATNParsing_v2 context, ATNConditionWillSubjBeConditionVingTransOrFinNode_v2 parentNode, ATNExtendedToken token)
            : base(context, token)
        {
            ParentNode = parentNode;
        }

        public ATNConditionWillSubjBeConditionVingObjTransOrFinNode_v2(ContextOfATNParsing_v2 context, ATNConditionWillSubjBeConditionVingObjTransOrFinNode_v2 sameNode, InitATNConditionWillSubjBeConditionVingObjTransOrFinNodeAction initAction, ATNExtendedToken token)
            : base(context, token)
        {
            mSameNode = sameNode;
            mInitAction = initAction;
            ParentNode = mSameNode.ParentNode;
            mInitAction?.Invoke(this);
        }

        public override StateOfATNParsing_v2 GlobalState => StateOfATNParsing_v2.Condition_Will_Subj_Be_Condition_Ving_Obj_TransOrFin;

        public ATNConditionWillSubjBeConditionVingTransOrFinNode_v2 ParentNode { get; private set; }
        private ATNConditionWillSubjBeConditionVingObjTransOrFinNode_v2 mSameNode;
        private InitATNConditionWillSubjBeConditionVingObjTransOrFinNodeAction mInitAction;

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

