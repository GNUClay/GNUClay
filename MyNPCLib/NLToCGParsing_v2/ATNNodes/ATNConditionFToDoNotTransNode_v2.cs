using MyNPCLib.NLToCGParsing;
using System;
using System.Collections.Generic;
using System.Text;

namespace MyNPCLib.NLToCGParsing_v2.ATNNodes
{
    public delegate void InitATNConditionFToDoNotTransNodeAction(ATNConditionFToDoNotTransNode_v2 item);

    public class ATNConditionFToDoNotTransNodeFactory_v2: BaseATNNodeFactory_v2
    {
        public ATNConditionFToDoNotTransNodeFactory_v2(ATNConditionFToDoTransNode_v2 parentNode, ATNExtendedToken token)
        {
            mNumberOfConstructor = 1;
            mParentNode = parentNode;
            mToken = token;
        }

        public ATNConditionFToDoNotTransNodeFactory_v2(ATNConditionFToDoNotTransNode_v2 sameNode, ATNExtendedToken token, InitATNConditionFToDoNotTransNodeAction initAction)
        {
            mNumberOfConstructor = 2;
            mSameNode = sameNode;
            mToken = token;
            mInitAction = initAction;
        }

        private int mNumberOfConstructor;
        private ATNConditionFToDoTransNode_v2 mParentNode;
        private ATNConditionFToDoNotTransNode_v2 mSameNode;
        private ATNExtendedToken mToken;
        private InitATNConditionFToDoNotTransNodeAction mInitAction;

        public override BaseATNNode_v2 Create(ContextOfATNParsing_v2 context)
        {
            switch(mNumberOfConstructor)
            {
                case 1:
                    return new ATNConditionFToDoNotTransNode_v2(context, mParentNode, mToken);

                case 2:
                    return new ATNConditionFToDoNotTransNode_v2(context, mSameNode, mInitAction, mToken);

                default:
                    throw new ArgumentOutOfRangeException(nameof(mNumberOfConstructor), mNumberOfConstructor, null);
            }
        }
    }

/*Sub states:
    Condition_FToDo_Not_Verb_TransOrFin
    Condition_FToDo_Not_Condition_Trans
*/

    public class ATNConditionFToDoNotTransNode_v2: BaseATNNode_v2
    {
        public ATNConditionFToDoNotTransNode_v2(ContextOfATNParsing_v2 context, ATNConditionFToDoTransNode_v2 parentNode, ATNExtendedToken token)
            : base(context, token)
        {
            ParentNode = parentNode;
        }

        public ATNConditionFToDoNotTransNode_v2(ContextOfATNParsing_v2 context, ATNConditionFToDoNotTransNode_v2 sameNode, InitATNConditionFToDoNotTransNodeAction initAction, ATNExtendedToken token)
            : base(context, token)
        {
            mSameNode = sameNode;
            mInitAction = initAction;
            ParentNode = mSameNode.ParentNode;
            mInitAction?.Invoke(this);
        }

        public override StateOfATNParsing_v2 GlobalState => StateOfATNParsing_v2.Condition_FToDo_Not_Trans;

        public ATNConditionFToDoTransNode_v2 ParentNode { get; private set; }
        private ATNConditionFToDoNotTransNode_v2 mSameNode;
        private InitATNConditionFToDoNotTransNodeAction mInitAction;

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

