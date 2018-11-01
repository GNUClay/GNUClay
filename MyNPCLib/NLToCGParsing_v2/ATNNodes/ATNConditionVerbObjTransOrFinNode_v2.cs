using MyNPCLib.NLToCGParsing;
using System;
using System.Collections.Generic;
using System.Text;

namespace MyNPCLib.NLToCGParsing_v2.ATNNodes
{
    public delegate void InitATNConditionVerbObjTransOrFinNodeAction(ATNConditionVerbObjTransOrFinNode_v2 item);

    public class ATNConditionVerbObjTransOrFinNodeFactory_v2: BaseATNNodeFactory_v2
    {
        public ATNConditionVerbObjTransOrFinNodeFactory_v2(ATNConditionVerbTransOrFinNode_v2 parentNode, ATNExtendedToken token)
        {
            mNumberOfConstructor = 1;
            mParentNode = parentNode;
            mToken = token;
        }

        public ATNConditionVerbObjTransOrFinNodeFactory_v2(ATNConditionVerbObjTransOrFinNode_v2 sameNode, ATNExtendedToken token, InitATNConditionVerbObjTransOrFinNodeAction initAction)
        {
            mNumberOfConstructor = 2;
            mSameNode = sameNode;
            mToken = token;
            mInitAction = initAction;
        }

        private int mNumberOfConstructor;
        private ATNConditionVerbTransOrFinNode_v2 mParentNode;
        private ATNConditionVerbObjTransOrFinNode_v2 mSameNode;
        private ATNExtendedToken mToken;
        private InitATNConditionVerbObjTransOrFinNodeAction mInitAction;

        public override BaseATNNode_v2 Create(ContextOfATNParsing_v2 context)
        {
            switch(mNumberOfConstructor)
            {
                case 1:
                    return new ATNConditionVerbObjTransOrFinNode_v2(context, mParentNode, mToken);

                case 2:
                    return new ATNConditionVerbObjTransOrFinNode_v2(context, mSameNode, mInitAction, mToken);

                default:
                    throw new ArgumentOutOfRangeException(nameof(mNumberOfConstructor), mNumberOfConstructor, null);
            }
        }
    }

/*Sub states:
    Condition_Verb_Obj_Condition_Fin
*/

    public class ATNConditionVerbObjTransOrFinNode_v2: BaseATNNode_v2
    {
        public ATNConditionVerbObjTransOrFinNode_v2(ContextOfATNParsing_v2 context, ATNConditionVerbTransOrFinNode_v2 parentNode, ATNExtendedToken token)
            : base(context, token)
        {
            ParentNode = parentNode;
        }

        public ATNConditionVerbObjTransOrFinNode_v2(ContextOfATNParsing_v2 context, ATNConditionVerbObjTransOrFinNode_v2 sameNode, InitATNConditionVerbObjTransOrFinNodeAction initAction, ATNExtendedToken token)
            : base(context, token)
        {
            mSameNode = sameNode;
            mInitAction = initAction;
            ParentNode = mSameNode.ParentNode;
            mInitAction?.Invoke(this);
        }

        public override StateOfATNParsing_v2 GlobalState => StateOfATNParsing_v2.Condition_Verb_Obj_TransOrFin;

        public ATNConditionVerbTransOrFinNode_v2 ParentNode { get; private set; }
        private ATNConditionVerbObjTransOrFinNode_v2 mSameNode;
        private InitATNConditionVerbObjTransOrFinNodeAction mInitAction;

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

