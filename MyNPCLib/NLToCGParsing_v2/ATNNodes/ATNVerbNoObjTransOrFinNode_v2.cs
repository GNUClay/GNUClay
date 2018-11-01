using MyNPCLib.NLToCGParsing;
using System;
using System.Collections.Generic;
using System.Text;

namespace MyNPCLib.NLToCGParsing_v2.ATNNodes
{
    public delegate void InitATNVerbNoObjTransOrFinNodeAction(ATNVerbNoObjTransOrFinNode_v2 item);

    public class ATNVerbNoObjTransOrFinNodeFactory_v2: BaseATNNodeFactory_v2
    {
        public ATNVerbNoObjTransOrFinNodeFactory_v2(ATNVerbNoTransNode_v2 parentNode, ATNExtendedToken token)
        {
            mNumberOfConstructor = 1;
            mParentNode = parentNode;
            mToken = token;
        }

        public ATNVerbNoObjTransOrFinNodeFactory_v2(ATNVerbNoObjTransOrFinNode_v2 sameNode, ATNExtendedToken token, InitATNVerbNoObjTransOrFinNodeAction initAction)
        {
            mNumberOfConstructor = 2;
            mSameNode = sameNode;
            mToken = token;
            mInitAction = initAction;
        }

        private int mNumberOfConstructor;
        private ATNVerbNoTransNode_v2 mParentNode;
        private ATNVerbNoObjTransOrFinNode_v2 mSameNode;
        private ATNExtendedToken mToken;
        private InitATNVerbNoObjTransOrFinNodeAction mInitAction;

        public override BaseATNNode_v2 Create(ContextOfATNParsing_v2 context)
        {
            switch(mNumberOfConstructor)
            {
                case 1:
                    return new ATNVerbNoObjTransOrFinNode_v2(context, mParentNode, mToken);

                case 2:
                    return new ATNVerbNoObjTransOrFinNode_v2(context, mSameNode, mInitAction, mToken);

                default:
                    throw new ArgumentOutOfRangeException(nameof(mNumberOfConstructor), mNumberOfConstructor, null);
            }
        }
    }

/*Sub states:
    Verb_No_Obj_Condition_Fin
*/

    public class ATNVerbNoObjTransOrFinNode_v2: BaseATNNode_v2
    {
        public ATNVerbNoObjTransOrFinNode_v2(ContextOfATNParsing_v2 context, ATNVerbNoTransNode_v2 parentNode, ATNExtendedToken token)
            : base(context, token)
        {
            ParentNode = parentNode;
        }

        public ATNVerbNoObjTransOrFinNode_v2(ContextOfATNParsing_v2 context, ATNVerbNoObjTransOrFinNode_v2 sameNode, InitATNVerbNoObjTransOrFinNodeAction initAction, ATNExtendedToken token)
            : base(context, token)
        {
            mSameNode = sameNode;
            mInitAction = initAction;
            ParentNode = mSameNode.ParentNode;
            mInitAction?.Invoke(this);
        }

        public override StateOfATNParsing_v2 GlobalState => StateOfATNParsing_v2.Verb_No_Obj_TransOrFin;

        public ATNVerbNoTransNode_v2 ParentNode { get; private set; }
        private ATNVerbNoObjTransOrFinNode_v2 mSameNode;
        private InitATNVerbNoObjTransOrFinNodeAction mInitAction;

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

