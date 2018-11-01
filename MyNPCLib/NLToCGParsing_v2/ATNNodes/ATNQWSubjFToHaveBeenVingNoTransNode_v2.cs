using MyNPCLib.NLToCGParsing;
using System;
using System.Collections.Generic;
using System.Text;

namespace MyNPCLib.NLToCGParsing_v2.ATNNodes
{
    public delegate void InitATNQWSubjFToHaveBeenVingNoTransNodeAction(ATNQWSubjFToHaveBeenVingNoTransNode_v2 item);

    public class ATNQWSubjFToHaveBeenVingNoTransNodeFactory_v2: BaseATNNodeFactory_v2
    {
        public ATNQWSubjFToHaveBeenVingNoTransNodeFactory_v2(ATNQWSubjFToHaveBeenVingTransOrFinNode_v2 parentNode, ATNExtendedToken token)
        {
            mNumberOfConstructor = 1;
            mParentNode = parentNode;
            mToken = token;
        }

        public ATNQWSubjFToHaveBeenVingNoTransNodeFactory_v2(ATNQWSubjFToHaveBeenVingNoTransNode_v2 sameNode, ATNExtendedToken token, InitATNQWSubjFToHaveBeenVingNoTransNodeAction initAction)
        {
            mNumberOfConstructor = 2;
            mSameNode = sameNode;
            mToken = token;
            mInitAction = initAction;
        }

        private int mNumberOfConstructor;
        private ATNQWSubjFToHaveBeenVingTransOrFinNode_v2 mParentNode;
        private ATNQWSubjFToHaveBeenVingNoTransNode_v2 mSameNode;
        private ATNExtendedToken mToken;
        private InitATNQWSubjFToHaveBeenVingNoTransNodeAction mInitAction;

        public override BaseATNNode_v2 Create(ContextOfATNParsing_v2 context)
        {
            switch(mNumberOfConstructor)
            {
                case 1:
                    return new ATNQWSubjFToHaveBeenVingNoTransNode_v2(context, mParentNode, mToken);

                case 2:
                    return new ATNQWSubjFToHaveBeenVingNoTransNode_v2(context, mSameNode, mInitAction, mToken);

                default:
                    throw new ArgumentOutOfRangeException(nameof(mNumberOfConstructor), mNumberOfConstructor, null);
            }
        }
    }

/*Sub states:
    QWSubj_FToHave_Been_Ving_No_Obj_TransOrFin
*/

    public class ATNQWSubjFToHaveBeenVingNoTransNode_v2: BaseATNNode_v2
    {
        public ATNQWSubjFToHaveBeenVingNoTransNode_v2(ContextOfATNParsing_v2 context, ATNQWSubjFToHaveBeenVingTransOrFinNode_v2 parentNode, ATNExtendedToken token)
            : base(context, token)
        {
            ParentNode = parentNode;
        }

        public ATNQWSubjFToHaveBeenVingNoTransNode_v2(ContextOfATNParsing_v2 context, ATNQWSubjFToHaveBeenVingNoTransNode_v2 sameNode, InitATNQWSubjFToHaveBeenVingNoTransNodeAction initAction, ATNExtendedToken token)
            : base(context, token)
        {
            mSameNode = sameNode;
            mInitAction = initAction;
            ParentNode = mSameNode.ParentNode;
            mInitAction?.Invoke(this);
        }

        public override StateOfATNParsing_v2 GlobalState => StateOfATNParsing_v2.QWSubj_FToHave_Been_Ving_No_Trans;

        public ATNQWSubjFToHaveBeenVingTransOrFinNode_v2 ParentNode { get; private set; }
        private ATNQWSubjFToHaveBeenVingNoTransNode_v2 mSameNode;
        private InitATNQWSubjFToHaveBeenVingNoTransNodeAction mInitAction;

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

