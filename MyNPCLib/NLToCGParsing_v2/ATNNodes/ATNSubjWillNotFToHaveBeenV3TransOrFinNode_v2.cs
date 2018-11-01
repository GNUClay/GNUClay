using MyNPCLib.NLToCGParsing;
using System;
using System.Collections.Generic;
using System.Text;

namespace MyNPCLib.NLToCGParsing_v2.ATNNodes
{
    public delegate void InitATNSubjWillNotFToHaveBeenV3TransOrFinNodeAction(ATNSubjWillNotFToHaveBeenV3TransOrFinNode_v2 item);

    public class ATNSubjWillNotFToHaveBeenV3TransOrFinNodeFactory_v2: BaseATNNodeFactory_v2
    {
        public ATNSubjWillNotFToHaveBeenV3TransOrFinNodeFactory_v2(ATNSubjWillNotFToHaveBeenTransNode_v2 parentNode, ATNExtendedToken token)
        {
            mNumberOfConstructor = 1;
            mParentNode = parentNode;
            mToken = token;
        }

        public ATNSubjWillNotFToHaveBeenV3TransOrFinNodeFactory_v2(ATNSubjWillNotFToHaveBeenV3TransOrFinNode_v2 sameNode, ATNExtendedToken token, InitATNSubjWillNotFToHaveBeenV3TransOrFinNodeAction initAction)
        {
            mNumberOfConstructor = 2;
            mSameNode = sameNode;
            mToken = token;
            mInitAction = initAction;
        }

        private int mNumberOfConstructor;
        private ATNSubjWillNotFToHaveBeenTransNode_v2 mParentNode;
        private ATNSubjWillNotFToHaveBeenV3TransOrFinNode_v2 mSameNode;
        private ATNExtendedToken mToken;
        private InitATNSubjWillNotFToHaveBeenV3TransOrFinNodeAction mInitAction;

        public override BaseATNNode_v2 Create(ContextOfATNParsing_v2 context)
        {
            switch(mNumberOfConstructor)
            {
                case 1:
                    return new ATNSubjWillNotFToHaveBeenV3TransOrFinNode_v2(context, mParentNode, mToken);

                case 2:
                    return new ATNSubjWillNotFToHaveBeenV3TransOrFinNode_v2(context, mSameNode, mInitAction, mToken);

                default:
                    throw new ArgumentOutOfRangeException(nameof(mNumberOfConstructor), mNumberOfConstructor, null);
            }
        }
    }

/*Sub states:
    Subj_Will_Not_FToHave_Been_V3_Obj_TransOrFin
    Subj_Will_Not_FToHave_Been_V3_Condition_Fin
*/

    public class ATNSubjWillNotFToHaveBeenV3TransOrFinNode_v2: BaseATNNode_v2
    {
        public ATNSubjWillNotFToHaveBeenV3TransOrFinNode_v2(ContextOfATNParsing_v2 context, ATNSubjWillNotFToHaveBeenTransNode_v2 parentNode, ATNExtendedToken token)
            : base(context, token)
        {
            ParentNode = parentNode;
        }

        public ATNSubjWillNotFToHaveBeenV3TransOrFinNode_v2(ContextOfATNParsing_v2 context, ATNSubjWillNotFToHaveBeenV3TransOrFinNode_v2 sameNode, InitATNSubjWillNotFToHaveBeenV3TransOrFinNodeAction initAction, ATNExtendedToken token)
            : base(context, token)
        {
            mSameNode = sameNode;
            mInitAction = initAction;
            ParentNode = mSameNode.ParentNode;
            mInitAction?.Invoke(this);
        }

        public override StateOfATNParsing_v2 GlobalState => StateOfATNParsing_v2.Subj_Will_Not_FToHave_Been_V3_TransOrFin;

        public ATNSubjWillNotFToHaveBeenTransNode_v2 ParentNode { get; private set; }
        private ATNSubjWillNotFToHaveBeenV3TransOrFinNode_v2 mSameNode;
        private InitATNSubjWillNotFToHaveBeenV3TransOrFinNodeAction mInitAction;

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

