using MyNPCLib.NLToCGParsing;
using System;
using System.Collections.Generic;
using System.Text;

namespace MyNPCLib.NLToCGParsing_v2.ATNNodes
{
    public delegate void InitATNQWSubjFToBeBeingV3NoObjTransOrFinNodeAction(ATNQWSubjFToBeBeingV3NoObjTransOrFinNode_v2 item);

    public class ATNQWSubjFToBeBeingV3NoObjTransOrFinNodeFactory_v2: BaseATNNodeFactory_v2
    {
        public ATNQWSubjFToBeBeingV3NoObjTransOrFinNodeFactory_v2(ATNQWSubjFToBeBeingV3NoTransNode_v2 parentNode, ATNExtendedToken token)
        {
            mNumberOfConstructor = 1;
            mParentNode = parentNode;
            mToken = token;
        }

        public ATNQWSubjFToBeBeingV3NoObjTransOrFinNodeFactory_v2(ATNQWSubjFToBeBeingV3NoObjTransOrFinNode_v2 sameNode, ATNExtendedToken token, InitATNQWSubjFToBeBeingV3NoObjTransOrFinNodeAction initAction)
        {
            mNumberOfConstructor = 2;
            mSameNode = sameNode;
            mToken = token;
            mInitAction = initAction;
        }

        private int mNumberOfConstructor;
        private ATNQWSubjFToBeBeingV3NoTransNode_v2 mParentNode;
        private ATNQWSubjFToBeBeingV3NoObjTransOrFinNode_v2 mSameNode;
        private ATNExtendedToken mToken;
        private InitATNQWSubjFToBeBeingV3NoObjTransOrFinNodeAction mInitAction;

        public override BaseATNNode_v2 Create(ContextOfATNParsing_v2 context)
        {
            switch(mNumberOfConstructor)
            {
                case 1:
                    return new ATNQWSubjFToBeBeingV3NoObjTransOrFinNode_v2(context, mParentNode, mToken);

                case 2:
                    return new ATNQWSubjFToBeBeingV3NoObjTransOrFinNode_v2(context, mSameNode, mInitAction, mToken);

                default:
                    throw new ArgumentOutOfRangeException(nameof(mNumberOfConstructor), mNumberOfConstructor, null);
            }
        }
    }

/*Sub states:
    QWSubj_FToBe_Being_V3_No_Obj_Condition_Fin
*/

    public class ATNQWSubjFToBeBeingV3NoObjTransOrFinNode_v2: BaseATNNode_v2
    {
        public ATNQWSubjFToBeBeingV3NoObjTransOrFinNode_v2(ContextOfATNParsing_v2 context, ATNQWSubjFToBeBeingV3NoTransNode_v2 parentNode, ATNExtendedToken token)
            : base(context, token)
        {
            ParentNode = parentNode;
        }

        public ATNQWSubjFToBeBeingV3NoObjTransOrFinNode_v2(ContextOfATNParsing_v2 context, ATNQWSubjFToBeBeingV3NoObjTransOrFinNode_v2 sameNode, InitATNQWSubjFToBeBeingV3NoObjTransOrFinNodeAction initAction, ATNExtendedToken token)
            : base(context, token)
        {
            mSameNode = sameNode;
            mInitAction = initAction;
            ParentNode = mSameNode.ParentNode;
            mInitAction?.Invoke(this);
        }

        public override StateOfATNParsing_v2 GlobalState => StateOfATNParsing_v2.QWSubj_FToBe_Being_V3_No_Obj_TransOrFin;

        public ATNQWSubjFToBeBeingV3NoTransNode_v2 ParentNode { get; private set; }
        private ATNQWSubjFToBeBeingV3NoObjTransOrFinNode_v2 mSameNode;
        private InitATNQWSubjFToBeBeingV3NoObjTransOrFinNodeAction mInitAction;

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

