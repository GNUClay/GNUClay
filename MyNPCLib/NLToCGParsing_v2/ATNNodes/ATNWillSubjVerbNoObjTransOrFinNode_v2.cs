using MyNPCLib.NLToCGParsing;
using System;
using System.Collections.Generic;
using System.Text;

namespace MyNPCLib.NLToCGParsing_v2.ATNNodes
{
    public delegate void InitATNWillSubjVerbNoObjTransOrFinNodeAction(ATNWillSubjVerbNoObjTransOrFinNode_v2 item);

    public class ATNWillSubjVerbNoObjTransOrFinNodeFactory_v2: BaseATNNodeFactory_v2
    {
        public ATNWillSubjVerbNoObjTransOrFinNodeFactory_v2(ATNWillSubjVerbNoTransNode_v2 parentNode, ATNExtendedToken token)
        {
            mNumberOfConstructor = 1;
            mParentNode = parentNode;
            mToken = token;
        }

        public ATNWillSubjVerbNoObjTransOrFinNodeFactory_v2(ATNWillSubjVerbNoObjTransOrFinNode_v2 sameNode, ATNExtendedToken token, InitATNWillSubjVerbNoObjTransOrFinNodeAction initAction)
        {
            mNumberOfConstructor = 2;
            mSameNode = sameNode;
            mToken = token;
            mInitAction = initAction;
        }

        private int mNumberOfConstructor;
        private ATNWillSubjVerbNoTransNode_v2 mParentNode;
        private ATNWillSubjVerbNoObjTransOrFinNode_v2 mSameNode;
        private ATNExtendedToken mToken;
        private InitATNWillSubjVerbNoObjTransOrFinNodeAction mInitAction;

        public override BaseATNNode_v2 Create(ContextOfATNParsing_v2 context)
        {
            switch(mNumberOfConstructor)
            {
                case 1:
                    return new ATNWillSubjVerbNoObjTransOrFinNode_v2(context, mParentNode, mToken);

                case 2:
                    return new ATNWillSubjVerbNoObjTransOrFinNode_v2(context, mSameNode, mInitAction, mToken);

                default:
                    throw new ArgumentOutOfRangeException(nameof(mNumberOfConstructor), mNumberOfConstructor, null);
            }
        }
    }

/*Sub states:
    Will_Subj_Verb_No_Obj_Condition_Fin
*/

    public class ATNWillSubjVerbNoObjTransOrFinNode_v2: BaseATNNode_v2
    {
        public ATNWillSubjVerbNoObjTransOrFinNode_v2(ContextOfATNParsing_v2 context, ATNWillSubjVerbNoTransNode_v2 parentNode, ATNExtendedToken token)
            : base(context, token)
        {
            ParentNode = parentNode;
        }

        public ATNWillSubjVerbNoObjTransOrFinNode_v2(ContextOfATNParsing_v2 context, ATNWillSubjVerbNoObjTransOrFinNode_v2 sameNode, InitATNWillSubjVerbNoObjTransOrFinNodeAction initAction, ATNExtendedToken token)
            : base(context, token)
        {
            mSameNode = sameNode;
            mInitAction = initAction;
            ParentNode = mSameNode.ParentNode;
            mInitAction?.Invoke(this);
        }

        public override StateOfATNParsing_v2 GlobalState => StateOfATNParsing_v2.Will_Subj_Verb_No_Obj_TransOrFin;

        public ATNWillSubjVerbNoTransNode_v2 ParentNode { get; private set; }
        private ATNWillSubjVerbNoObjTransOrFinNode_v2 mSameNode;
        private InitATNWillSubjVerbNoObjTransOrFinNodeAction mInitAction;

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

