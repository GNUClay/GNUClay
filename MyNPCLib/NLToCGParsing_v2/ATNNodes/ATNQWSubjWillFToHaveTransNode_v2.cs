using MyNPCLib.NLToCGParsing;
using System;
using System.Collections.Generic;
using System.Text;

namespace MyNPCLib.NLToCGParsing_v2.ATNNodes
{
    public delegate void InitATNQWSubjWillFToHaveTransNodeAction(ATNQWSubjWillFToHaveTransNode_v2 item);

    public class ATNQWSubjWillFToHaveTransNodeFactory_v2: BaseATNNodeFactory_v2
    {
        public ATNQWSubjWillFToHaveTransNodeFactory_v2(ATNQWSubjWillTransNode_v2 parentNode, ATNExtendedToken token)
        {
            mNumberOfConstructor = 1;
            mParentNode = parentNode;
            mToken = token;
        }

        public ATNQWSubjWillFToHaveTransNodeFactory_v2(ATNQWSubjWillFToHaveTransNode_v2 sameNode, ATNExtendedToken token, InitATNQWSubjWillFToHaveTransNodeAction initAction)
        {
            mNumberOfConstructor = 2;
            mSameNode = sameNode;
            mToken = token;
            mInitAction = initAction;
        }

        private int mNumberOfConstructor;
        private ATNQWSubjWillTransNode_v2 mParentNode;
        private ATNQWSubjWillFToHaveTransNode_v2 mSameNode;
        private ATNExtendedToken mToken;
        private InitATNQWSubjWillFToHaveTransNodeAction mInitAction;

        public override BaseATNNode_v2 Create(ContextOfATNParsing_v2 context)
        {
            switch(mNumberOfConstructor)
            {
                case 1:
                    return new ATNQWSubjWillFToHaveTransNode_v2(context, mParentNode, mToken);

                case 2:
                    return new ATNQWSubjWillFToHaveTransNode_v2(context, mSameNode, mInitAction, mToken);

                default:
                    throw new ArgumentOutOfRangeException(nameof(mNumberOfConstructor), mNumberOfConstructor, null);
            }
        }
    }

/*Sub states:
    QWSubj_Will_FToHave_V3_TransOrFin
    QWSubj_Will_FToHave_Been_Trans
    QWSubj_Will_FToHave_Condition_Trans
*/

    public class ATNQWSubjWillFToHaveTransNode_v2: BaseATNNode_v2
    {
        public ATNQWSubjWillFToHaveTransNode_v2(ContextOfATNParsing_v2 context, ATNQWSubjWillTransNode_v2 parentNode, ATNExtendedToken token)
            : base(context, token)
        {
            ParentNode = parentNode;
        }

        public ATNQWSubjWillFToHaveTransNode_v2(ContextOfATNParsing_v2 context, ATNQWSubjWillFToHaveTransNode_v2 sameNode, InitATNQWSubjWillFToHaveTransNodeAction initAction, ATNExtendedToken token)
            : base(context, token)
        {
            mSameNode = sameNode;
            mInitAction = initAction;
            ParentNode = mSameNode.ParentNode;
            mInitAction?.Invoke(this);
        }

        public override StateOfATNParsing_v2 GlobalState => StateOfATNParsing_v2.QWSubj_Will_FToHave_Trans;

        public ATNQWSubjWillTransNode_v2 ParentNode { get; private set; }
        private ATNQWSubjWillFToHaveTransNode_v2 mSameNode;
        private InitATNQWSubjWillFToHaveTransNodeAction mInitAction;

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

