using MyNPCLib.NLToCGParsing;
using System;
using System.Collections.Generic;
using System.Text;

namespace MyNPCLib.NLToCGParsing_v2.ATNNodes
{
    public delegate void InitATNQWSubjFToHaveBeenV3NoTransNodeAction(ATNQWSubjFToHaveBeenV3NoTransNode_v2 item);

    public class ATNQWSubjFToHaveBeenV3NoTransNodeFactory_v2: BaseATNNodeFactory_v2
    {
        public ATNQWSubjFToHaveBeenV3NoTransNodeFactory_v2(ATNQWSubjFToHaveBeenV3TransOrFinNode_v2 parentNode, ATNExtendedToken token)
        {
            mNumberOfConstructor = 1;
            mParentNode = parentNode;
            mToken = token;
        }

        public ATNQWSubjFToHaveBeenV3NoTransNodeFactory_v2(ATNQWSubjFToHaveBeenV3NoTransNode_v2 sameNode, ATNExtendedToken token, InitATNQWSubjFToHaveBeenV3NoTransNodeAction initAction)
        {
            mNumberOfConstructor = 2;
            mSameNode = sameNode;
            mToken = token;
            mInitAction = initAction;
        }

        private int mNumberOfConstructor;
        private ATNQWSubjFToHaveBeenV3TransOrFinNode_v2 mParentNode;
        private ATNQWSubjFToHaveBeenV3NoTransNode_v2 mSameNode;
        private ATNExtendedToken mToken;
        private InitATNQWSubjFToHaveBeenV3NoTransNodeAction mInitAction;

        public override BaseATNNode_v2 Create(ContextOfATNParsing_v2 context)
        {
            switch(mNumberOfConstructor)
            {
                case 1:
                    return new ATNQWSubjFToHaveBeenV3NoTransNode_v2(context, mParentNode, mToken);

                case 2:
                    return new ATNQWSubjFToHaveBeenV3NoTransNode_v2(context, mSameNode, mInitAction, mToken);

                default:
                    throw new ArgumentOutOfRangeException(nameof(mNumberOfConstructor), mNumberOfConstructor, null);
            }
        }
    }

/*Sub states:
    QWSubj_FToHave_Been_V3_No_Obj_TransOrFin
*/

    public class ATNQWSubjFToHaveBeenV3NoTransNode_v2: BaseATNNode_v2
    {
        public ATNQWSubjFToHaveBeenV3NoTransNode_v2(ContextOfATNParsing_v2 context, ATNQWSubjFToHaveBeenV3TransOrFinNode_v2 parentNode, ATNExtendedToken token)
            : base(context, token)
        {
            ParentNode = parentNode;
        }

        public ATNQWSubjFToHaveBeenV3NoTransNode_v2(ContextOfATNParsing_v2 context, ATNQWSubjFToHaveBeenV3NoTransNode_v2 sameNode, InitATNQWSubjFToHaveBeenV3NoTransNodeAction initAction, ATNExtendedToken token)
            : base(context, token)
        {
            mSameNode = sameNode;
            mInitAction = initAction;
            ParentNode = mSameNode.ParentNode;
            mInitAction?.Invoke(this);
        }

        public override StateOfATNParsing_v2 GlobalState => StateOfATNParsing_v2.QWSubj_FToHave_Been_V3_No_Trans;

        public ATNQWSubjFToHaveBeenV3TransOrFinNode_v2 ParentNode { get; private set; }
        private ATNQWSubjFToHaveBeenV3NoTransNode_v2 mSameNode;
        private InitATNQWSubjFToHaveBeenV3NoTransNodeAction mInitAction;

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

