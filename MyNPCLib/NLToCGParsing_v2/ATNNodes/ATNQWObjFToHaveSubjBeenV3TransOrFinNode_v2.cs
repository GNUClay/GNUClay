using MyNPCLib.NLToCGParsing;
using System;
using System.Collections.Generic;
using System.Text;

namespace MyNPCLib.NLToCGParsing_v2.ATNNodes
{
    public delegate void InitATNQWObjFToHaveSubjBeenV3TransOrFinNodeAction(ATNQWObjFToHaveSubjBeenV3TransOrFinNode_v2 item);

    public class ATNQWObjFToHaveSubjBeenV3TransOrFinNodeFactory_v2: BaseATNNodeFactory_v2
    {
        public ATNQWObjFToHaveSubjBeenV3TransOrFinNodeFactory_v2(ATNQWObjFToHaveSubjBeenTransNode_v2 parentNode, ATNExtendedToken token)
        {
            mNumberOfConstructor = 1;
            mParentNode = parentNode;
            mToken = token;
        }

        public ATNQWObjFToHaveSubjBeenV3TransOrFinNodeFactory_v2(ATNQWObjFToHaveSubjBeenV3TransOrFinNode_v2 sameNode, ATNExtendedToken token, InitATNQWObjFToHaveSubjBeenV3TransOrFinNodeAction initAction)
        {
            mNumberOfConstructor = 2;
            mSameNode = sameNode;
            mToken = token;
            mInitAction = initAction;
        }

        private int mNumberOfConstructor;
        private ATNQWObjFToHaveSubjBeenTransNode_v2 mParentNode;
        private ATNQWObjFToHaveSubjBeenV3TransOrFinNode_v2 mSameNode;
        private ATNExtendedToken mToken;
        private InitATNQWObjFToHaveSubjBeenV3TransOrFinNodeAction mInitAction;

        public override BaseATNNode_v2 Create(ContextOfATNParsing_v2 context)
        {
            switch(mNumberOfConstructor)
            {
                case 1:
                    return new ATNQWObjFToHaveSubjBeenV3TransOrFinNode_v2(context, mParentNode, mToken);

                case 2:
                    return new ATNQWObjFToHaveSubjBeenV3TransOrFinNode_v2(context, mSameNode, mInitAction, mToken);

                default:
                    throw new ArgumentOutOfRangeException(nameof(mNumberOfConstructor), mNumberOfConstructor, null);
            }
        }
    }

/*Sub states:
    QWObj_FToHave_Subj_Been_V3_Condition_Fin
*/

    public class ATNQWObjFToHaveSubjBeenV3TransOrFinNode_v2: BaseATNNode_v2
    {
        public ATNQWObjFToHaveSubjBeenV3TransOrFinNode_v2(ContextOfATNParsing_v2 context, ATNQWObjFToHaveSubjBeenTransNode_v2 parentNode, ATNExtendedToken token)
            : base(context, token)
        {
            ParentNode = parentNode;
        }

        public ATNQWObjFToHaveSubjBeenV3TransOrFinNode_v2(ContextOfATNParsing_v2 context, ATNQWObjFToHaveSubjBeenV3TransOrFinNode_v2 sameNode, InitATNQWObjFToHaveSubjBeenV3TransOrFinNodeAction initAction, ATNExtendedToken token)
            : base(context, token)
        {
            mSameNode = sameNode;
            mInitAction = initAction;
            ParentNode = mSameNode.ParentNode;
            mInitAction?.Invoke(this);
        }

        public override StateOfATNParsing_v2 GlobalState => StateOfATNParsing_v2.QWObj_FToHave_Subj_Been_V3_TransOrFin;

        public ATNQWObjFToHaveSubjBeenTransNode_v2 ParentNode { get; private set; }
        private ATNQWObjFToHaveSubjBeenV3TransOrFinNode_v2 mSameNode;
        private InitATNQWObjFToHaveSubjBeenV3TransOrFinNodeAction mInitAction;

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

