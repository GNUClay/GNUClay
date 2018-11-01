using MyNPCLib.NLToCGParsing;
using System;
using System.Collections.Generic;
using System.Text;

namespace MyNPCLib.NLToCGParsing_v2.ATNNodes
{
    public delegate void InitATNQWObjFToHaveSubjBeenVingTransOrFinNodeAction(ATNQWObjFToHaveSubjBeenVingTransOrFinNode_v2 item);

    public class ATNQWObjFToHaveSubjBeenVingTransOrFinNodeFactory_v2: BaseATNNodeFactory_v2
    {
        public ATNQWObjFToHaveSubjBeenVingTransOrFinNodeFactory_v2(ATNQWObjFToHaveSubjBeenTransNode_v2 parentNode, ATNExtendedToken token)
        {
            mNumberOfConstructor = 1;
            mParentNode = parentNode;
            mToken = token;
        }

        public ATNQWObjFToHaveSubjBeenVingTransOrFinNodeFactory_v2(ATNQWObjFToHaveSubjBeenVingTransOrFinNode_v2 sameNode, ATNExtendedToken token, InitATNQWObjFToHaveSubjBeenVingTransOrFinNodeAction initAction)
        {
            mNumberOfConstructor = 2;
            mSameNode = sameNode;
            mToken = token;
            mInitAction = initAction;
        }

        private int mNumberOfConstructor;
        private ATNQWObjFToHaveSubjBeenTransNode_v2 mParentNode;
        private ATNQWObjFToHaveSubjBeenVingTransOrFinNode_v2 mSameNode;
        private ATNExtendedToken mToken;
        private InitATNQWObjFToHaveSubjBeenVingTransOrFinNodeAction mInitAction;

        public override BaseATNNode_v2 Create(ContextOfATNParsing_v2 context)
        {
            switch(mNumberOfConstructor)
            {
                case 1:
                    return new ATNQWObjFToHaveSubjBeenVingTransOrFinNode_v2(context, mParentNode, mToken);

                case 2:
                    return new ATNQWObjFToHaveSubjBeenVingTransOrFinNode_v2(context, mSameNode, mInitAction, mToken);

                default:
                    throw new ArgumentOutOfRangeException(nameof(mNumberOfConstructor), mNumberOfConstructor, null);
            }
        }
    }

/*Sub states:
    QWObj_FToHave_Subj_Been_Ving_Condition_Fin
*/

    public class ATNQWObjFToHaveSubjBeenVingTransOrFinNode_v2: BaseATNNode_v2
    {
        public ATNQWObjFToHaveSubjBeenVingTransOrFinNode_v2(ContextOfATNParsing_v2 context, ATNQWObjFToHaveSubjBeenTransNode_v2 parentNode, ATNExtendedToken token)
            : base(context, token)
        {
            ParentNode = parentNode;
        }

        public ATNQWObjFToHaveSubjBeenVingTransOrFinNode_v2(ContextOfATNParsing_v2 context, ATNQWObjFToHaveSubjBeenVingTransOrFinNode_v2 sameNode, InitATNQWObjFToHaveSubjBeenVingTransOrFinNodeAction initAction, ATNExtendedToken token)
            : base(context, token)
        {
            mSameNode = sameNode;
            mInitAction = initAction;
            ParentNode = mSameNode.ParentNode;
            mInitAction?.Invoke(this);
        }

        public override StateOfATNParsing_v2 GlobalState => StateOfATNParsing_v2.QWObj_FToHave_Subj_Been_Ving_TransOrFin;

        public ATNQWObjFToHaveSubjBeenTransNode_v2 ParentNode { get; private set; }
        private ATNQWObjFToHaveSubjBeenVingTransOrFinNode_v2 mSameNode;
        private InitATNQWObjFToHaveSubjBeenVingTransOrFinNodeAction mInitAction;

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

