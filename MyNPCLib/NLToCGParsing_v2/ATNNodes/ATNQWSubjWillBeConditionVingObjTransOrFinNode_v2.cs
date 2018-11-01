using MyNPCLib.NLToCGParsing;
using System;
using System.Collections.Generic;
using System.Text;

namespace MyNPCLib.NLToCGParsing_v2.ATNNodes
{
    public delegate void InitATNQWSubjWillBeConditionVingObjTransOrFinNodeAction(ATNQWSubjWillBeConditionVingObjTransOrFinNode_v2 item);

    public class ATNQWSubjWillBeConditionVingObjTransOrFinNodeFactory_v2: BaseATNNodeFactory_v2
    {
        public ATNQWSubjWillBeConditionVingObjTransOrFinNodeFactory_v2(ATNQWSubjWillBeConditionVingTransOrFinNode_v2 parentNode, ATNExtendedToken token)
        {
            mNumberOfConstructor = 1;
            mParentNode = parentNode;
            mToken = token;
        }

        public ATNQWSubjWillBeConditionVingObjTransOrFinNodeFactory_v2(ATNQWSubjWillBeConditionVingObjTransOrFinNode_v2 sameNode, ATNExtendedToken token, InitATNQWSubjWillBeConditionVingObjTransOrFinNodeAction initAction)
        {
            mNumberOfConstructor = 2;
            mSameNode = sameNode;
            mToken = token;
            mInitAction = initAction;
        }

        private int mNumberOfConstructor;
        private ATNQWSubjWillBeConditionVingTransOrFinNode_v2 mParentNode;
        private ATNQWSubjWillBeConditionVingObjTransOrFinNode_v2 mSameNode;
        private ATNExtendedToken mToken;
        private InitATNQWSubjWillBeConditionVingObjTransOrFinNodeAction mInitAction;

        public override BaseATNNode_v2 Create(ContextOfATNParsing_v2 context)
        {
            switch(mNumberOfConstructor)
            {
                case 1:
                    return new ATNQWSubjWillBeConditionVingObjTransOrFinNode_v2(context, mParentNode, mToken);

                case 2:
                    return new ATNQWSubjWillBeConditionVingObjTransOrFinNode_v2(context, mSameNode, mInitAction, mToken);

                default:
                    throw new ArgumentOutOfRangeException(nameof(mNumberOfConstructor), mNumberOfConstructor, null);
            }
        }
    }

/*Sub states:
    QWSubj_Will_Be_Condition_Ving_Obj_Condition_Fin
*/

    public class ATNQWSubjWillBeConditionVingObjTransOrFinNode_v2: BaseATNNode_v2
    {
        public ATNQWSubjWillBeConditionVingObjTransOrFinNode_v2(ContextOfATNParsing_v2 context, ATNQWSubjWillBeConditionVingTransOrFinNode_v2 parentNode, ATNExtendedToken token)
            : base(context, token)
        {
            ParentNode = parentNode;
        }

        public ATNQWSubjWillBeConditionVingObjTransOrFinNode_v2(ContextOfATNParsing_v2 context, ATNQWSubjWillBeConditionVingObjTransOrFinNode_v2 sameNode, InitATNQWSubjWillBeConditionVingObjTransOrFinNodeAction initAction, ATNExtendedToken token)
            : base(context, token)
        {
            mSameNode = sameNode;
            mInitAction = initAction;
            ParentNode = mSameNode.ParentNode;
            mInitAction?.Invoke(this);
        }

        public override StateOfATNParsing_v2 GlobalState => StateOfATNParsing_v2.QWSubj_Will_Be_Condition_Ving_Obj_TransOrFin;

        public ATNQWSubjWillBeConditionVingTransOrFinNode_v2 ParentNode { get; private set; }
        private ATNQWSubjWillBeConditionVingObjTransOrFinNode_v2 mSameNode;
        private InitATNQWSubjWillBeConditionVingObjTransOrFinNodeAction mInitAction;

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

