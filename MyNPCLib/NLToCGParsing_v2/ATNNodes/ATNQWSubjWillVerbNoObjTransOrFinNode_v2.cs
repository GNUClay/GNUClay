using MyNPCLib.NLToCGParsing;
using System;
using System.Collections.Generic;
using System.Text;

namespace MyNPCLib.NLToCGParsing_v2.ATNNodes
{
    public delegate void InitATNQWSubjWillVerbNoObjTransOrFinNodeAction(ATNQWSubjWillVerbNoObjTransOrFinNode_v2 item);

    public class ATNQWSubjWillVerbNoObjTransOrFinNodeFactory_v2: BaseATNNodeFactory_v2
    {
        public ATNQWSubjWillVerbNoObjTransOrFinNodeFactory_v2(ATNQWSubjWillVerbNoTransNode_v2 parentNode, ATNExtendedToken token)
        {
            mNumberOfConstructor = 1;
            mParentNode = parentNode;
            mToken = token;
        }

        public ATNQWSubjWillVerbNoObjTransOrFinNodeFactory_v2(ATNQWSubjWillVerbNoObjTransOrFinNode_v2 sameNode, ATNExtendedToken token, InitATNQWSubjWillVerbNoObjTransOrFinNodeAction initAction)
        {
            mNumberOfConstructor = 2;
            mSameNode = sameNode;
            mToken = token;
            mInitAction = initAction;
        }

        private int mNumberOfConstructor;
        private ATNQWSubjWillVerbNoTransNode_v2 mParentNode;
        private ATNQWSubjWillVerbNoObjTransOrFinNode_v2 mSameNode;
        private ATNExtendedToken mToken;
        private InitATNQWSubjWillVerbNoObjTransOrFinNodeAction mInitAction;

        public override BaseATNNode_v2 Create(ContextOfATNParsing_v2 context)
        {
            switch(mNumberOfConstructor)
            {
                case 1:
                    return new ATNQWSubjWillVerbNoObjTransOrFinNode_v2(context, mParentNode, mToken);

                case 2:
                    return new ATNQWSubjWillVerbNoObjTransOrFinNode_v2(context, mSameNode, mInitAction, mToken);

                default:
                    throw new ArgumentOutOfRangeException(nameof(mNumberOfConstructor), mNumberOfConstructor, null);
            }
        }
    }

/*Sub states:
    QWSubj_Will_Verb_No_Obj_Condition_Fin
*/

    public class ATNQWSubjWillVerbNoObjTransOrFinNode_v2: BaseATNNode_v2
    {
        public ATNQWSubjWillVerbNoObjTransOrFinNode_v2(ContextOfATNParsing_v2 context, ATNQWSubjWillVerbNoTransNode_v2 parentNode, ATNExtendedToken token)
            : base(context, token)
        {
            ParentNode = parentNode;
        }

        public ATNQWSubjWillVerbNoObjTransOrFinNode_v2(ContextOfATNParsing_v2 context, ATNQWSubjWillVerbNoObjTransOrFinNode_v2 sameNode, InitATNQWSubjWillVerbNoObjTransOrFinNodeAction initAction, ATNExtendedToken token)
            : base(context, token)
        {
            mSameNode = sameNode;
            mInitAction = initAction;
            ParentNode = mSameNode.ParentNode;
            mInitAction?.Invoke(this);
        }

        public override StateOfATNParsing_v2 GlobalState => StateOfATNParsing_v2.QWSubj_Will_Verb_No_Obj_TransOrFin;

        public ATNQWSubjWillVerbNoTransNode_v2 ParentNode { get; private set; }
        private ATNQWSubjWillVerbNoObjTransOrFinNode_v2 mSameNode;
        private InitATNQWSubjWillVerbNoObjTransOrFinNodeAction mInitAction;

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

