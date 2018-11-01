using MyNPCLib.NLToCGParsing;
using System;
using System.Collections.Generic;
using System.Text;

namespace MyNPCLib.NLToCGParsing_v2.ATNNodes
{
    public delegate void InitATNQWSubjWillVerbNoTransNodeAction(ATNQWSubjWillVerbNoTransNode_v2 item);

    public class ATNQWSubjWillVerbNoTransNodeFactory_v2: BaseATNNodeFactory_v2
    {
        public ATNQWSubjWillVerbNoTransNodeFactory_v2(ATNQWSubjWillVerbTransOrFinNode_v2 parentNode, ATNExtendedToken token)
        {
            mNumberOfConstructor = 1;
            mParentNode = parentNode;
            mToken = token;
        }

        public ATNQWSubjWillVerbNoTransNodeFactory_v2(ATNQWSubjWillVerbNoTransNode_v2 sameNode, ATNExtendedToken token, InitATNQWSubjWillVerbNoTransNodeAction initAction)
        {
            mNumberOfConstructor = 2;
            mSameNode = sameNode;
            mToken = token;
            mInitAction = initAction;
        }

        private int mNumberOfConstructor;
        private ATNQWSubjWillVerbTransOrFinNode_v2 mParentNode;
        private ATNQWSubjWillVerbNoTransNode_v2 mSameNode;
        private ATNExtendedToken mToken;
        private InitATNQWSubjWillVerbNoTransNodeAction mInitAction;

        public override BaseATNNode_v2 Create(ContextOfATNParsing_v2 context)
        {
            switch(mNumberOfConstructor)
            {
                case 1:
                    return new ATNQWSubjWillVerbNoTransNode_v2(context, mParentNode, mToken);

                case 2:
                    return new ATNQWSubjWillVerbNoTransNode_v2(context, mSameNode, mInitAction, mToken);

                default:
                    throw new ArgumentOutOfRangeException(nameof(mNumberOfConstructor), mNumberOfConstructor, null);
            }
        }
    }

/*Sub states:
    QWSubj_Will_Verb_No_Obj_TransOrFin
*/

    public class ATNQWSubjWillVerbNoTransNode_v2: BaseATNNode_v2
    {
        public ATNQWSubjWillVerbNoTransNode_v2(ContextOfATNParsing_v2 context, ATNQWSubjWillVerbTransOrFinNode_v2 parentNode, ATNExtendedToken token)
            : base(context, token)
        {
            ParentNode = parentNode;
        }

        public ATNQWSubjWillVerbNoTransNode_v2(ContextOfATNParsing_v2 context, ATNQWSubjWillVerbNoTransNode_v2 sameNode, InitATNQWSubjWillVerbNoTransNodeAction initAction, ATNExtendedToken token)
            : base(context, token)
        {
            mSameNode = sameNode;
            mInitAction = initAction;
            ParentNode = mSameNode.ParentNode;
            mInitAction?.Invoke(this);
        }

        public override StateOfATNParsing_v2 GlobalState => StateOfATNParsing_v2.QWSubj_Will_Verb_No_Trans;

        public ATNQWSubjWillVerbTransOrFinNode_v2 ParentNode { get; private set; }
        private ATNQWSubjWillVerbNoTransNode_v2 mSameNode;
        private InitATNQWSubjWillVerbNoTransNodeAction mInitAction;

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

