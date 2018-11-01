using MyNPCLib.NLToCGParsing;
using System;
using System.Collections.Generic;
using System.Text;

namespace MyNPCLib.NLToCGParsing_v2.ATNNodes
{
    public delegate void InitATNConditionQWSubjVerbNoTransNodeAction(ATNConditionQWSubjVerbNoTransNode_v2 item);

    public class ATNConditionQWSubjVerbNoTransNodeFactory_v2: BaseATNNodeFactory_v2
    {
        public ATNConditionQWSubjVerbNoTransNodeFactory_v2(ATNConditionQWSubjVerbTransOrFinNode_v2 parentNode, ATNExtendedToken token)
        {
            mNumberOfConstructor = 1;
            mParentNode = parentNode;
            mToken = token;
        }

        public ATNConditionQWSubjVerbNoTransNodeFactory_v2(ATNConditionQWSubjVerbNoTransNode_v2 sameNode, ATNExtendedToken token, InitATNConditionQWSubjVerbNoTransNodeAction initAction)
        {
            mNumberOfConstructor = 2;
            mSameNode = sameNode;
            mToken = token;
            mInitAction = initAction;
        }

        private int mNumberOfConstructor;
        private ATNConditionQWSubjVerbTransOrFinNode_v2 mParentNode;
        private ATNConditionQWSubjVerbNoTransNode_v2 mSameNode;
        private ATNExtendedToken mToken;
        private InitATNConditionQWSubjVerbNoTransNodeAction mInitAction;

        public override BaseATNNode_v2 Create(ContextOfATNParsing_v2 context)
        {
            switch(mNumberOfConstructor)
            {
                case 1:
                    return new ATNConditionQWSubjVerbNoTransNode_v2(context, mParentNode, mToken);

                case 2:
                    return new ATNConditionQWSubjVerbNoTransNode_v2(context, mSameNode, mInitAction, mToken);

                default:
                    throw new ArgumentOutOfRangeException(nameof(mNumberOfConstructor), mNumberOfConstructor, null);
            }
        }
    }

/*Sub states:
    Condition_QWSubj_Verb_No_Obj_TransOrFin
*/

    public class ATNConditionQWSubjVerbNoTransNode_v2: BaseATNNode_v2
    {
        public ATNConditionQWSubjVerbNoTransNode_v2(ContextOfATNParsing_v2 context, ATNConditionQWSubjVerbTransOrFinNode_v2 parentNode, ATNExtendedToken token)
            : base(context, token)
        {
            ParentNode = parentNode;
        }

        public ATNConditionQWSubjVerbNoTransNode_v2(ContextOfATNParsing_v2 context, ATNConditionQWSubjVerbNoTransNode_v2 sameNode, InitATNConditionQWSubjVerbNoTransNodeAction initAction, ATNExtendedToken token)
            : base(context, token)
        {
            mSameNode = sameNode;
            mInitAction = initAction;
            ParentNode = mSameNode.ParentNode;
            mInitAction?.Invoke(this);
        }

        public override StateOfATNParsing_v2 GlobalState => StateOfATNParsing_v2.Condition_QWSubj_Verb_No_Trans;

        public ATNConditionQWSubjVerbTransOrFinNode_v2 ParentNode { get; private set; }
        private ATNConditionQWSubjVerbNoTransNode_v2 mSameNode;
        private InitATNConditionQWSubjVerbNoTransNodeAction mInitAction;

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

