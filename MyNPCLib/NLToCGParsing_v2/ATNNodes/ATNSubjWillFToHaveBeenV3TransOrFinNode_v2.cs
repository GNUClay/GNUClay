using MyNPCLib.NLToCGParsing;
using System;
using System.Collections.Generic;
using System.Text;

namespace MyNPCLib.NLToCGParsing_v2.ATNNodes
{
    public delegate void InitATNSubjWillFToHaveBeenV3TransOrFinNodeAction(ATNSubjWillFToHaveBeenV3TransOrFinNode_v2 item);

    public class ATNSubjWillFToHaveBeenV3TransOrFinNodeFactory_v2: BaseATNNodeFactory_v2
    {
        public ATNSubjWillFToHaveBeenV3TransOrFinNodeFactory_v2(ATNSubjWillFToHaveBeenTransNode_v2 parentNode, ATNExtendedToken token)
        {
            mNumberOfConstructor = 1;
            mParentNode = parentNode;
            mToken = token;
        }

        public ATNSubjWillFToHaveBeenV3TransOrFinNodeFactory_v2(ATNSubjWillFToHaveBeenV3TransOrFinNode_v2 sameNode, ATNExtendedToken token, InitATNSubjWillFToHaveBeenV3TransOrFinNodeAction initAction)
        {
            mNumberOfConstructor = 2;
            mSameNode = sameNode;
            mToken = token;
            mInitAction = initAction;
        }

        private int mNumberOfConstructor;
        private ATNSubjWillFToHaveBeenTransNode_v2 mParentNode;
        private ATNSubjWillFToHaveBeenV3TransOrFinNode_v2 mSameNode;
        private ATNExtendedToken mToken;
        private InitATNSubjWillFToHaveBeenV3TransOrFinNodeAction mInitAction;

        public override BaseATNNode_v2 Create(ContextOfATNParsing_v2 context)
        {
            switch(mNumberOfConstructor)
            {
                case 1:
                    return new ATNSubjWillFToHaveBeenV3TransOrFinNode_v2(context, mParentNode, mToken);

                case 2:
                    return new ATNSubjWillFToHaveBeenV3TransOrFinNode_v2(context, mSameNode, mInitAction, mToken);

                default:
                    throw new ArgumentOutOfRangeException(nameof(mNumberOfConstructor), mNumberOfConstructor, null);
            }
        }
    }

/*Sub states:
    Subj_Will_FToHave_Been_V3_Obj_TransOrFin
    Subj_Will_FToHave_Been_V3_No_Trans
    Subj_Will_FToHave_Been_V3_Condition_Fin
*/

    public class ATNSubjWillFToHaveBeenV3TransOrFinNode_v2: BaseATNNode_v2
    {
        public ATNSubjWillFToHaveBeenV3TransOrFinNode_v2(ContextOfATNParsing_v2 context, ATNSubjWillFToHaveBeenTransNode_v2 parentNode, ATNExtendedToken token)
            : base(context, token)
        {
            ParentNode = parentNode;
        }

        public ATNSubjWillFToHaveBeenV3TransOrFinNode_v2(ContextOfATNParsing_v2 context, ATNSubjWillFToHaveBeenV3TransOrFinNode_v2 sameNode, InitATNSubjWillFToHaveBeenV3TransOrFinNodeAction initAction, ATNExtendedToken token)
            : base(context, token)
        {
            mSameNode = sameNode;
            mInitAction = initAction;
            ParentNode = mSameNode.ParentNode;
            mInitAction?.Invoke(this);
        }

        public override StateOfATNParsing_v2 GlobalState => StateOfATNParsing_v2.Subj_Will_FToHave_Been_V3_TransOrFin;

        public ATNSubjWillFToHaveBeenTransNode_v2 ParentNode { get; private set; }
        private ATNSubjWillFToHaveBeenV3TransOrFinNode_v2 mSameNode;
        private InitATNSubjWillFToHaveBeenV3TransOrFinNodeAction mInitAction;

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

