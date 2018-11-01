using MyNPCLib.NLToCGParsing;
using System;
using System.Collections.Generic;
using System.Text;

namespace MyNPCLib.NLToCGParsing_v2.ATNNodes
{
    public delegate void InitATNQWObjFToHaveSubjBeenTransNodeAction(ATNQWObjFToHaveSubjBeenTransNode_v2 item);

    public class ATNQWObjFToHaveSubjBeenTransNodeFactory_v2: BaseATNNodeFactory_v2
    {
        public ATNQWObjFToHaveSubjBeenTransNodeFactory_v2(ATNQWObjFToHaveSubjTransNode_v2 parentNode, ATNExtendedToken token)
        {
            mNumberOfConstructor = 1;
            mParentNode = parentNode;
            mToken = token;
        }

        public ATNQWObjFToHaveSubjBeenTransNodeFactory_v2(ATNQWObjFToHaveSubjBeenTransNode_v2 sameNode, ATNExtendedToken token, InitATNQWObjFToHaveSubjBeenTransNodeAction initAction)
        {
            mNumberOfConstructor = 2;
            mSameNode = sameNode;
            mToken = token;
            mInitAction = initAction;
        }

        private int mNumberOfConstructor;
        private ATNQWObjFToHaveSubjTransNode_v2 mParentNode;
        private ATNQWObjFToHaveSubjBeenTransNode_v2 mSameNode;
        private ATNExtendedToken mToken;
        private InitATNQWObjFToHaveSubjBeenTransNodeAction mInitAction;

        public override BaseATNNode_v2 Create(ContextOfATNParsing_v2 context)
        {
            switch(mNumberOfConstructor)
            {
                case 1:
                    return new ATNQWObjFToHaveSubjBeenTransNode_v2(context, mParentNode, mToken);

                case 2:
                    return new ATNQWObjFToHaveSubjBeenTransNode_v2(context, mSameNode, mInitAction, mToken);

                default:
                    throw new ArgumentOutOfRangeException(nameof(mNumberOfConstructor), mNumberOfConstructor, null);
            }
        }
    }

/*Sub states:
    QWObj_FToHave_Subj_Been_Ving_TransOrFin
    QWObj_FToHave_Subj_Been_V3_TransOrFin
    QWObj_FToHave_Subj_Been_Condition_Trans
*/

    public class ATNQWObjFToHaveSubjBeenTransNode_v2: BaseATNNode_v2
    {
        public ATNQWObjFToHaveSubjBeenTransNode_v2(ContextOfATNParsing_v2 context, ATNQWObjFToHaveSubjTransNode_v2 parentNode, ATNExtendedToken token)
            : base(context, token)
        {
            ParentNode = parentNode;
        }

        public ATNQWObjFToHaveSubjBeenTransNode_v2(ContextOfATNParsing_v2 context, ATNQWObjFToHaveSubjBeenTransNode_v2 sameNode, InitATNQWObjFToHaveSubjBeenTransNodeAction initAction, ATNExtendedToken token)
            : base(context, token)
        {
            mSameNode = sameNode;
            mInitAction = initAction;
            ParentNode = mSameNode.ParentNode;
            mInitAction?.Invoke(this);
        }

        public override StateOfATNParsing_v2 GlobalState => StateOfATNParsing_v2.QWObj_FToHave_Subj_Been_Trans;

        public ATNQWObjFToHaveSubjTransNode_v2 ParentNode { get; private set; }
        private ATNQWObjFToHaveSubjBeenTransNode_v2 mSameNode;
        private InitATNQWObjFToHaveSubjBeenTransNodeAction mInitAction;

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

