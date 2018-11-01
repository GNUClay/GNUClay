using MyNPCLib.NLToCGParsing;
using System;
using System.Collections.Generic;
using System.Text;

namespace MyNPCLib.NLToCGParsing_v2.ATNNodes
{
    public delegate void InitATNConditionQWObjTransNodeAction(ATNConditionQWObjTransNode_v2 item);

    public class ATNConditionQWObjTransNodeFactory_v2: BaseATNNodeFactory_v2
    {
        public ATNConditionQWObjTransNodeFactory_v2(ATNConditionTransNode_v2 parentNode, ATNExtendedToken token)
        {
            mNumberOfConstructor = 1;
            mParentNode = parentNode;
            mToken = token;
        }

        public ATNConditionQWObjTransNodeFactory_v2(ATNConditionQWObjTransNode_v2 sameNode, ATNExtendedToken token, InitATNConditionQWObjTransNodeAction initAction)
        {
            mNumberOfConstructor = 2;
            mSameNode = sameNode;
            mToken = token;
            mInitAction = initAction;
        }

        private int mNumberOfConstructor;
        private ATNConditionTransNode_v2 mParentNode;
        private ATNConditionQWObjTransNode_v2 mSameNode;
        private ATNExtendedToken mToken;
        private InitATNConditionQWObjTransNodeAction mInitAction;

        public override BaseATNNode_v2 Create(ContextOfATNParsing_v2 context)
        {
            switch(mNumberOfConstructor)
            {
                case 1:
                    return new ATNConditionQWObjTransNode_v2(context, mParentNode, mToken);

                case 2:
                    return new ATNConditionQWObjTransNode_v2(context, mSameNode, mInitAction, mToken);

                default:
                    throw new ArgumentOutOfRangeException(nameof(mNumberOfConstructor), mNumberOfConstructor, null);
            }
        }
    }

/*Sub states:
    Condition_QWObj_FToDo_Trans
    Condition_QWObj_Will_Trans
    Condition_QWObj_FToBe_Trans
    Condition_QWObj_FToHave_Trans
    Condition_QWObj_ModalVerb_Trans
*/

    public class ATNConditionQWObjTransNode_v2: BaseATNNode_v2
    {
        public ATNConditionQWObjTransNode_v2(ContextOfATNParsing_v2 context, ATNConditionTransNode_v2 parentNode, ATNExtendedToken token)
            : base(context, token)
        {
            ParentNode = parentNode;
        }

        public ATNConditionQWObjTransNode_v2(ContextOfATNParsing_v2 context, ATNConditionQWObjTransNode_v2 sameNode, InitATNConditionQWObjTransNodeAction initAction, ATNExtendedToken token)
            : base(context, token)
        {
            mSameNode = sameNode;
            mInitAction = initAction;
            ParentNode = mSameNode.ParentNode;
            mInitAction?.Invoke(this);
        }

        public override StateOfATNParsing_v2 GlobalState => StateOfATNParsing_v2.Condition_QWObj_Trans;

        public ATNConditionTransNode_v2 ParentNode { get; private set; }
        private ATNConditionQWObjTransNode_v2 mSameNode;
        private InitATNConditionQWObjTransNodeAction mInitAction;

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

