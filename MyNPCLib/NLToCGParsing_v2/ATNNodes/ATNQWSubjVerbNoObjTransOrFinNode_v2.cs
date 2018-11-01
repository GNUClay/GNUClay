using MyNPCLib.NLToCGParsing;
using System;
using System.Collections.Generic;
using System.Text;

namespace MyNPCLib.NLToCGParsing_v2.ATNNodes
{
    public delegate void InitATNQWSubjVerbNoObjTransOrFinNodeAction(ATNQWSubjVerbNoObjTransOrFinNode_v2 item);

    public class ATNQWSubjVerbNoObjTransOrFinNodeFactory_v2: BaseATNNodeFactory_v2
    {
        public ATNQWSubjVerbNoObjTransOrFinNodeFactory_v2(ATNQWSubjVerbNoTransNode_v2 parentNode, ATNExtendedToken token)
        {
            mNumberOfConstructor = 1;
            mParentNode = parentNode;
            mToken = token;
        }

        public ATNQWSubjVerbNoObjTransOrFinNodeFactory_v2(ATNQWSubjVerbNoObjTransOrFinNode_v2 sameNode, ATNExtendedToken token, InitATNQWSubjVerbNoObjTransOrFinNodeAction initAction)
        {
            mNumberOfConstructor = 2;
            mSameNode = sameNode;
            mToken = token;
            mInitAction = initAction;
        }

        private int mNumberOfConstructor;
        private ATNQWSubjVerbNoTransNode_v2 mParentNode;
        private ATNQWSubjVerbNoObjTransOrFinNode_v2 mSameNode;
        private ATNExtendedToken mToken;
        private InitATNQWSubjVerbNoObjTransOrFinNodeAction mInitAction;

        public override BaseATNNode_v2 Create(ContextOfATNParsing_v2 context)
        {
            switch(mNumberOfConstructor)
            {
                case 1:
                    return new ATNQWSubjVerbNoObjTransOrFinNode_v2(context, mParentNode, mToken);

                case 2:
                    return new ATNQWSubjVerbNoObjTransOrFinNode_v2(context, mSameNode, mInitAction, mToken);

                default:
                    throw new ArgumentOutOfRangeException(nameof(mNumberOfConstructor), mNumberOfConstructor, null);
            }
        }
    }

/*Sub states:
    QWSubj_Verb_No_Obj_Condition_Fin
*/

    public class ATNQWSubjVerbNoObjTransOrFinNode_v2: BaseATNNode_v2
    {
        public ATNQWSubjVerbNoObjTransOrFinNode_v2(ContextOfATNParsing_v2 context, ATNQWSubjVerbNoTransNode_v2 parentNode, ATNExtendedToken token)
            : base(context, token)
        {
            ParentNode = parentNode;
        }

        public ATNQWSubjVerbNoObjTransOrFinNode_v2(ContextOfATNParsing_v2 context, ATNQWSubjVerbNoObjTransOrFinNode_v2 sameNode, InitATNQWSubjVerbNoObjTransOrFinNodeAction initAction, ATNExtendedToken token)
            : base(context, token)
        {
            mSameNode = sameNode;
            mInitAction = initAction;
            ParentNode = mSameNode.ParentNode;
            mInitAction?.Invoke(this);
        }

        public override StateOfATNParsing_v2 GlobalState => StateOfATNParsing_v2.QWSubj_Verb_No_Obj_TransOrFin;

        public ATNQWSubjVerbNoTransNode_v2 ParentNode { get; private set; }
        private ATNQWSubjVerbNoObjTransOrFinNode_v2 mSameNode;
        private InitATNQWSubjVerbNoObjTransOrFinNodeAction mInitAction;

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

