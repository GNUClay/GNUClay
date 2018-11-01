using MyNPCLib.NLToCGParsing;
using System;
using System.Collections.Generic;
using System.Text;

namespace MyNPCLib.NLToCGParsing_v2.ATNNodes
{
    public delegate void InitATNSubjWillFToHaveBeenV3NoTransNodeAction(ATNSubjWillFToHaveBeenV3NoTransNode_v2 item);

    public class ATNSubjWillFToHaveBeenV3NoTransNodeFactory_v2: BaseATNNodeFactory_v2
    {
        public ATNSubjWillFToHaveBeenV3NoTransNodeFactory_v2(ATNSubjWillFToHaveBeenV3TransOrFinNode_v2 parentNode, ATNExtendedToken token)
        {
            mNumberOfConstructor = 1;
            mParentNode = parentNode;
            mToken = token;
        }

        public ATNSubjWillFToHaveBeenV3NoTransNodeFactory_v2(ATNSubjWillFToHaveBeenV3NoTransNode_v2 sameNode, ATNExtendedToken token, InitATNSubjWillFToHaveBeenV3NoTransNodeAction initAction)
        {
            mNumberOfConstructor = 2;
            mSameNode = sameNode;
            mToken = token;
            mInitAction = initAction;
        }

        private int mNumberOfConstructor;
        private ATNSubjWillFToHaveBeenV3TransOrFinNode_v2 mParentNode;
        private ATNSubjWillFToHaveBeenV3NoTransNode_v2 mSameNode;
        private ATNExtendedToken mToken;
        private InitATNSubjWillFToHaveBeenV3NoTransNodeAction mInitAction;

        public override BaseATNNode_v2 Create(ContextOfATNParsing_v2 context)
        {
            switch(mNumberOfConstructor)
            {
                case 1:
                    return new ATNSubjWillFToHaveBeenV3NoTransNode_v2(context, mParentNode, mToken);

                case 2:
                    return new ATNSubjWillFToHaveBeenV3NoTransNode_v2(context, mSameNode, mInitAction, mToken);

                default:
                    throw new ArgumentOutOfRangeException(nameof(mNumberOfConstructor), mNumberOfConstructor, null);
            }
        }
    }

/*Sub states:
    Subj_Will_FToHave_Been_V3_No_Obj_TransOrFin
*/

    public class ATNSubjWillFToHaveBeenV3NoTransNode_v2: BaseATNNode_v2
    {
        public ATNSubjWillFToHaveBeenV3NoTransNode_v2(ContextOfATNParsing_v2 context, ATNSubjWillFToHaveBeenV3TransOrFinNode_v2 parentNode, ATNExtendedToken token)
            : base(context, token)
        {
            ParentNode = parentNode;
        }

        public ATNSubjWillFToHaveBeenV3NoTransNode_v2(ContextOfATNParsing_v2 context, ATNSubjWillFToHaveBeenV3NoTransNode_v2 sameNode, InitATNSubjWillFToHaveBeenV3NoTransNodeAction initAction, ATNExtendedToken token)
            : base(context, token)
        {
            mSameNode = sameNode;
            mInitAction = initAction;
            ParentNode = mSameNode.ParentNode;
            mInitAction?.Invoke(this);
        }

        public override StateOfATNParsing_v2 GlobalState => StateOfATNParsing_v2.Subj_Will_FToHave_Been_V3_No_Trans;

        public ATNSubjWillFToHaveBeenV3TransOrFinNode_v2 ParentNode { get; private set; }
        private ATNSubjWillFToHaveBeenV3NoTransNode_v2 mSameNode;
        private InitATNSubjWillFToHaveBeenV3NoTransNodeAction mInitAction;

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

