using MyNPCLib.NLToCGParsing;
using System;
using System.Collections.Generic;
using System.Text;

namespace MyNPCLib.NLToCGParsing_v2.ATNNodes
{
    public delegate void InitATNConditionSubjFToHaveNotBeenConditionVingObjTransOrFinNodeAction(ATNConditionSubjFToHaveNotBeenConditionVingObjTransOrFinNode_v2 item);

    public class ATNConditionSubjFToHaveNotBeenConditionVingObjTransOrFinNodeFactory_v2: BaseATNNodeFactory_v2
    {
        public ATNConditionSubjFToHaveNotBeenConditionVingObjTransOrFinNodeFactory_v2(ATNConditionSubjFToHaveNotBeenConditionVingTransOrFinNode_v2 parentNode, ATNExtendedToken token)
        {
            mNumberOfConstructor = 1;
            mParentNode = parentNode;
            mToken = token;
        }

        public ATNConditionSubjFToHaveNotBeenConditionVingObjTransOrFinNodeFactory_v2(ATNConditionSubjFToHaveNotBeenConditionVingObjTransOrFinNode_v2 sameNode, ATNExtendedToken token, InitATNConditionSubjFToHaveNotBeenConditionVingObjTransOrFinNodeAction initAction)
        {
            mNumberOfConstructor = 2;
            mSameNode = sameNode;
            mToken = token;
            mInitAction = initAction;
        }

        private int mNumberOfConstructor;
        private ATNConditionSubjFToHaveNotBeenConditionVingTransOrFinNode_v2 mParentNode;
        private ATNConditionSubjFToHaveNotBeenConditionVingObjTransOrFinNode_v2 mSameNode;
        private ATNExtendedToken mToken;
        private InitATNConditionSubjFToHaveNotBeenConditionVingObjTransOrFinNodeAction mInitAction;

        public override BaseATNNode_v2 Create(ContextOfATNParsing_v2 context)
        {
            switch(mNumberOfConstructor)
            {
                case 1:
                    return new ATNConditionSubjFToHaveNotBeenConditionVingObjTransOrFinNode_v2(context, mParentNode, mToken);

                case 2:
                    return new ATNConditionSubjFToHaveNotBeenConditionVingObjTransOrFinNode_v2(context, mSameNode, mInitAction, mToken);

                default:
                    throw new ArgumentOutOfRangeException(nameof(mNumberOfConstructor), mNumberOfConstructor, null);
            }
        }
    }

/*Sub states:
    Condition_Subj_FToHave_Not_Been_Condition_Ving_Obj_Condition_Fin
*/

    public class ATNConditionSubjFToHaveNotBeenConditionVingObjTransOrFinNode_v2: BaseATNNode_v2
    {
        public ATNConditionSubjFToHaveNotBeenConditionVingObjTransOrFinNode_v2(ContextOfATNParsing_v2 context, ATNConditionSubjFToHaveNotBeenConditionVingTransOrFinNode_v2 parentNode, ATNExtendedToken token)
            : base(context, token)
        {
            ParentNode = parentNode;
        }

        public ATNConditionSubjFToHaveNotBeenConditionVingObjTransOrFinNode_v2(ContextOfATNParsing_v2 context, ATNConditionSubjFToHaveNotBeenConditionVingObjTransOrFinNode_v2 sameNode, InitATNConditionSubjFToHaveNotBeenConditionVingObjTransOrFinNodeAction initAction, ATNExtendedToken token)
            : base(context, token)
        {
            mSameNode = sameNode;
            mInitAction = initAction;
            ParentNode = mSameNode.ParentNode;
            mInitAction?.Invoke(this);
        }

        public override StateOfATNParsing_v2 GlobalState => StateOfATNParsing_v2.Condition_Subj_FToHave_Not_Been_Condition_Ving_Obj_TransOrFin;

        public ATNConditionSubjFToHaveNotBeenConditionVingTransOrFinNode_v2 ParentNode { get; private set; }
        private ATNConditionSubjFToHaveNotBeenConditionVingObjTransOrFinNode_v2 mSameNode;
        private InitATNConditionSubjFToHaveNotBeenConditionVingObjTransOrFinNodeAction mInitAction;

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

