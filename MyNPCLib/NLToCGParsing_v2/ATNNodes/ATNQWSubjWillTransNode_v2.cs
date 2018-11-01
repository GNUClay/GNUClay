using MyNPCLib.NLToCGParsing;
using System;
using System.Collections.Generic;
using System.Text;

namespace MyNPCLib.NLToCGParsing_v2.ATNNodes
{
    public delegate void InitATNQWSubjWillTransNodeAction(ATNQWSubjWillTransNode_v2 item);

    public class ATNQWSubjWillTransNodeFactory_v2: BaseATNNodeFactory_v2
    {
        public ATNQWSubjWillTransNodeFactory_v2(ATNQWSubjTransNode_v2 parentNode, ATNExtendedToken token)
        {
            mNumberOfConstructor = 1;
            mParentNode = parentNode;
            mToken = token;
        }

        public ATNQWSubjWillTransNodeFactory_v2(ATNQWSubjWillTransNode_v2 sameNode, ATNExtendedToken token, InitATNQWSubjWillTransNodeAction initAction)
        {
            mNumberOfConstructor = 2;
            mSameNode = sameNode;
            mToken = token;
            mInitAction = initAction;
        }

        private int mNumberOfConstructor;
        private ATNQWSubjTransNode_v2 mParentNode;
        private ATNQWSubjWillTransNode_v2 mSameNode;
        private ATNExtendedToken mToken;
        private InitATNQWSubjWillTransNodeAction mInitAction;

        public override BaseATNNode_v2 Create(ContextOfATNParsing_v2 context)
        {
            switch(mNumberOfConstructor)
            {
                case 1:
                    return new ATNQWSubjWillTransNode_v2(context, mParentNode, mToken);

                case 2:
                    return new ATNQWSubjWillTransNode_v2(context, mSameNode, mInitAction, mToken);

                default:
                    throw new ArgumentOutOfRangeException(nameof(mNumberOfConstructor), mNumberOfConstructor, null);
            }
        }
    }

/*Sub states:
    QWSubj_Will_Verb_TransOrFin
    QWSubj_Will_Be_Trans
    QWSubj_Will_FToHave_Trans
    QWSubj_Will_Condition_Trans
*/

    public class ATNQWSubjWillTransNode_v2: BaseATNNode_v2
    {
        public ATNQWSubjWillTransNode_v2(ContextOfATNParsing_v2 context, ATNQWSubjTransNode_v2 parentNode, ATNExtendedToken token)
            : base(context, token)
        {
            ParentNode = parentNode;
        }

        public ATNQWSubjWillTransNode_v2(ContextOfATNParsing_v2 context, ATNQWSubjWillTransNode_v2 sameNode, InitATNQWSubjWillTransNodeAction initAction, ATNExtendedToken token)
            : base(context, token)
        {
            mSameNode = sameNode;
            mInitAction = initAction;
            ParentNode = mSameNode.ParentNode;
            mInitAction?.Invoke(this);
        }

        public override StateOfATNParsing_v2 GlobalState => StateOfATNParsing_v2.QWSubj_Will_Trans;

        public ATNQWSubjTransNode_v2 ParentNode { get; private set; }
        private ATNQWSubjWillTransNode_v2 mSameNode;
        private InitATNQWSubjWillTransNodeAction mInitAction;

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

