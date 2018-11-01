using MyNPCLib.NLToCGParsing;
using System;
using System.Collections.Generic;
using System.Text;

namespace MyNPCLib.NLToCGParsing_v2.ATNNodes
{
    public delegate void InitATNQWSubjWillBeVingObjTransOrFinNodeAction(ATNQWSubjWillBeVingObjTransOrFinNode_v2 item);

    public class ATNQWSubjWillBeVingObjTransOrFinNodeFactory_v2: BaseATNNodeFactory_v2
    {
        public ATNQWSubjWillBeVingObjTransOrFinNodeFactory_v2(ATNQWSubjWillBeVingTransOrFinNode_v2 parentNode, ATNExtendedToken token)
        {
            mNumberOfConstructor = 1;
            mParentNode = parentNode;
            mToken = token;
        }

        public ATNQWSubjWillBeVingObjTransOrFinNodeFactory_v2(ATNQWSubjWillBeVingObjTransOrFinNode_v2 sameNode, ATNExtendedToken token, InitATNQWSubjWillBeVingObjTransOrFinNodeAction initAction)
        {
            mNumberOfConstructor = 2;
            mSameNode = sameNode;
            mToken = token;
            mInitAction = initAction;
        }

        private int mNumberOfConstructor;
        private ATNQWSubjWillBeVingTransOrFinNode_v2 mParentNode;
        private ATNQWSubjWillBeVingObjTransOrFinNode_v2 mSameNode;
        private ATNExtendedToken mToken;
        private InitATNQWSubjWillBeVingObjTransOrFinNodeAction mInitAction;

        public override BaseATNNode_v2 Create(ContextOfATNParsing_v2 context)
        {
            switch(mNumberOfConstructor)
            {
                case 1:
                    return new ATNQWSubjWillBeVingObjTransOrFinNode_v2(context, mParentNode, mToken);

                case 2:
                    return new ATNQWSubjWillBeVingObjTransOrFinNode_v2(context, mSameNode, mInitAction, mToken);

                default:
                    throw new ArgumentOutOfRangeException(nameof(mNumberOfConstructor), mNumberOfConstructor, null);
            }
        }
    }

/*Sub states:
    QWSubj_Will_Be_Ving_Obj_Condition_Fin
*/

    public class ATNQWSubjWillBeVingObjTransOrFinNode_v2: BaseATNNode_v2
    {
        public ATNQWSubjWillBeVingObjTransOrFinNode_v2(ContextOfATNParsing_v2 context, ATNQWSubjWillBeVingTransOrFinNode_v2 parentNode, ATNExtendedToken token)
            : base(context, token)
        {
            ParentNode = parentNode;
        }

        public ATNQWSubjWillBeVingObjTransOrFinNode_v2(ContextOfATNParsing_v2 context, ATNQWSubjWillBeVingObjTransOrFinNode_v2 sameNode, InitATNQWSubjWillBeVingObjTransOrFinNodeAction initAction, ATNExtendedToken token)
            : base(context, token)
        {
            mSameNode = sameNode;
            mInitAction = initAction;
            ParentNode = mSameNode.ParentNode;
            mInitAction?.Invoke(this);
        }

        public override StateOfATNParsing_v2 GlobalState => StateOfATNParsing_v2.QWSubj_Will_Be_Ving_Obj_TransOrFin;

        public ATNQWSubjWillBeVingTransOrFinNode_v2 ParentNode { get; private set; }
        private ATNQWSubjWillBeVingObjTransOrFinNode_v2 mSameNode;
        private InitATNQWSubjWillBeVingObjTransOrFinNodeAction mInitAction;

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

