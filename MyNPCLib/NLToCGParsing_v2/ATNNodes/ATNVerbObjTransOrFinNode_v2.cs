using MyNPCLib.NLToCGParsing;
using System;
using System.Collections.Generic;
using System.Text;

namespace MyNPCLib.NLToCGParsing_v2.ATNNodes
{
    public delegate void InitATNVerbObjTransOrFinNodeAction(ATNVerbObjTransOrFinNode_v2 item);

    public class ATNVerbObjTransOrFinNodeFactory_v2: BaseATNNodeFactory_v2
    {
        public ATNVerbObjTransOrFinNodeFactory_v2(ATNVerbTransOrFinNode_v2 parentNode, ATNExtendedToken token)
        {
            mNumberOfConstructor = 1;
            mParentNode = parentNode;
            mToken = token;
        }

        public ATNVerbObjTransOrFinNodeFactory_v2(ATNVerbObjTransOrFinNode_v2 sameNode, ATNExtendedToken token, InitATNVerbObjTransOrFinNodeAction initAction)
        {
            mNumberOfConstructor = 2;
            mSameNode = sameNode;
            mToken = token;
            mInitAction = initAction;
        }

        private int mNumberOfConstructor;
        private ATNVerbTransOrFinNode_v2 mParentNode;
        private ATNVerbObjTransOrFinNode_v2 mSameNode;
        private ATNExtendedToken mToken;
        private InitATNVerbObjTransOrFinNodeAction mInitAction;

        public override BaseATNNode_v2 Create(ContextOfATNParsing_v2 context)
        {
            switch(mNumberOfConstructor)
            {
                case 1:
                    return new ATNVerbObjTransOrFinNode_v2(context, mParentNode, mToken);

                case 2:
                    return new ATNVerbObjTransOrFinNode_v2(context, mSameNode, mInitAction, mToken);

                default:
                    throw new ArgumentOutOfRangeException(nameof(mNumberOfConstructor), mNumberOfConstructor, null);
            }
        }
    }

/*Sub states:
    Verb_Obj_Condition_Fin
*/

    public class ATNVerbObjTransOrFinNode_v2: BaseATNNode_v2
    {
        public ATNVerbObjTransOrFinNode_v2(ContextOfATNParsing_v2 context, ATNVerbTransOrFinNode_v2 parentNode, ATNExtendedToken token)
            : base(context, token)
        {
            ParentNode = parentNode;
        }

        public ATNVerbObjTransOrFinNode_v2(ContextOfATNParsing_v2 context, ATNVerbObjTransOrFinNode_v2 sameNode, InitATNVerbObjTransOrFinNodeAction initAction, ATNExtendedToken token)
            : base(context, token)
        {
            mSameNode = sameNode;
            mInitAction = initAction;
            ParentNode = mSameNode.ParentNode;
            mInitAction?.Invoke(this);
        }

        public override StateOfATNParsing_v2 GlobalState => StateOfATNParsing_v2.Verb_Obj_TransOrFin;

        public ATNVerbTransOrFinNode_v2 ParentNode { get; private set; }
        private ATNVerbObjTransOrFinNode_v2 mSameNode;
        private InitATNVerbObjTransOrFinNodeAction mInitAction;

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

