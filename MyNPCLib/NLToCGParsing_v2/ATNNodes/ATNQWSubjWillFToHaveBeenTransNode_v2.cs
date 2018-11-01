using MyNPCLib.NLToCGParsing;
using System;
using System.Collections.Generic;
using System.Text;

namespace MyNPCLib.NLToCGParsing_v2.ATNNodes
{
    public delegate void InitATNQWSubjWillFToHaveBeenTransNodeAction(ATNQWSubjWillFToHaveBeenTransNode_v2 item);

    public class ATNQWSubjWillFToHaveBeenTransNodeFactory_v2: BaseATNNodeFactory_v2
    {
        public ATNQWSubjWillFToHaveBeenTransNodeFactory_v2(ATNQWSubjWillFToHaveTransNode_v2 parentNode, ATNExtendedToken token)
        {
            mNumberOfConstructor = 1;
            mParentNode = parentNode;
            mToken = token;
        }

        public ATNQWSubjWillFToHaveBeenTransNodeFactory_v2(ATNQWSubjWillFToHaveBeenTransNode_v2 sameNode, ATNExtendedToken token, InitATNQWSubjWillFToHaveBeenTransNodeAction initAction)
        {
            mNumberOfConstructor = 2;
            mSameNode = sameNode;
            mToken = token;
            mInitAction = initAction;
        }

        private int mNumberOfConstructor;
        private ATNQWSubjWillFToHaveTransNode_v2 mParentNode;
        private ATNQWSubjWillFToHaveBeenTransNode_v2 mSameNode;
        private ATNExtendedToken mToken;
        private InitATNQWSubjWillFToHaveBeenTransNodeAction mInitAction;

        public override BaseATNNode_v2 Create(ContextOfATNParsing_v2 context)
        {
            switch(mNumberOfConstructor)
            {
                case 1:
                    return new ATNQWSubjWillFToHaveBeenTransNode_v2(context, mParentNode, mToken);

                case 2:
                    return new ATNQWSubjWillFToHaveBeenTransNode_v2(context, mSameNode, mInitAction, mToken);

                default:
                    throw new ArgumentOutOfRangeException(nameof(mNumberOfConstructor), mNumberOfConstructor, null);
            }
        }
    }

/*Sub states:
    QWSubj_Will_FToHave_Been_Ving_TransOrFin
    QWSubj_Will_FToHave_Been_V3_TransOrFin
    QWSubj_Will_FToHave_Been_Condition_Trans
*/

    public class ATNQWSubjWillFToHaveBeenTransNode_v2: BaseATNNode_v2
    {
        public ATNQWSubjWillFToHaveBeenTransNode_v2(ContextOfATNParsing_v2 context, ATNQWSubjWillFToHaveTransNode_v2 parentNode, ATNExtendedToken token)
            : base(context, token)
        {
            ParentNode = parentNode;
        }

        public ATNQWSubjWillFToHaveBeenTransNode_v2(ContextOfATNParsing_v2 context, ATNQWSubjWillFToHaveBeenTransNode_v2 sameNode, InitATNQWSubjWillFToHaveBeenTransNodeAction initAction, ATNExtendedToken token)
            : base(context, token)
        {
            mSameNode = sameNode;
            mInitAction = initAction;
            ParentNode = mSameNode.ParentNode;
            mInitAction?.Invoke(this);
        }

        public override StateOfATNParsing_v2 GlobalState => StateOfATNParsing_v2.QWSubj_Will_FToHave_Been_Trans;

        public ATNQWSubjWillFToHaveTransNode_v2 ParentNode { get; private set; }
        private ATNQWSubjWillFToHaveBeenTransNode_v2 mSameNode;
        private InitATNQWSubjWillFToHaveBeenTransNodeAction mInitAction;

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

