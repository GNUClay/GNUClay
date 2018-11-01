using MyNPCLib.NLToCGParsing;
using System;
using System.Collections.Generic;
using System.Text;

namespace MyNPCLib.NLToCGParsing_v2.ATNNodes
{
    public delegate void InitATNConditionSubjFToHaveBeenConditionVingObjTransOrFinNodeAction(ATNConditionSubjFToHaveBeenConditionVingObjTransOrFinNode_v2 item);

    public class ATNConditionSubjFToHaveBeenConditionVingObjTransOrFinNodeFactory_v2: BaseATNNodeFactory_v2
    {
        public ATNConditionSubjFToHaveBeenConditionVingObjTransOrFinNodeFactory_v2(ATNConditionSubjFToHaveBeenConditionVingTransOrFinNode_v2 parentNode, ATNExtendedToken token)
        {
            mNumberOfConstructor = 1;
            mParentNode = parentNode;
            mToken = token;
        }

        public ATNConditionSubjFToHaveBeenConditionVingObjTransOrFinNodeFactory_v2(ATNConditionSubjFToHaveBeenConditionVingObjTransOrFinNode_v2 sameNode, ATNExtendedToken token, InitATNConditionSubjFToHaveBeenConditionVingObjTransOrFinNodeAction initAction)
        {
            mNumberOfConstructor = 2;
            mSameNode = sameNode;
            mToken = token;
            mInitAction = initAction;
        }

        private int mNumberOfConstructor;
        private ATNConditionSubjFToHaveBeenConditionVingTransOrFinNode_v2 mParentNode;
        private ATNConditionSubjFToHaveBeenConditionVingObjTransOrFinNode_v2 mSameNode;
        private ATNExtendedToken mToken;
        private InitATNConditionSubjFToHaveBeenConditionVingObjTransOrFinNodeAction mInitAction;

        public override BaseATNNode_v2 Create(ContextOfATNParsing_v2 context)
        {
            switch(mNumberOfConstructor)
            {
                case 1:
                    return new ATNConditionSubjFToHaveBeenConditionVingObjTransOrFinNode_v2(context, mParentNode, mToken);

                case 2:
                    return new ATNConditionSubjFToHaveBeenConditionVingObjTransOrFinNode_v2(context, mSameNode, mInitAction, mToken);

                default:
                    throw new ArgumentOutOfRangeException(nameof(mNumberOfConstructor), mNumberOfConstructor, null);
            }
        }
    }

/*Sub states:
    Condition_Subj_FToHave_Been_Condition_Ving_Obj_Condition_Fin
*/

    public class ATNConditionSubjFToHaveBeenConditionVingObjTransOrFinNode_v2: BaseATNNode_v2
    {
        public ATNConditionSubjFToHaveBeenConditionVingObjTransOrFinNode_v2(ContextOfATNParsing_v2 context, ATNConditionSubjFToHaveBeenConditionVingTransOrFinNode_v2 parentNode, ATNExtendedToken token)
            : base(context, token)
        {
            ParentNode = parentNode;
        }

        public ATNConditionSubjFToHaveBeenConditionVingObjTransOrFinNode_v2(ContextOfATNParsing_v2 context, ATNConditionSubjFToHaveBeenConditionVingObjTransOrFinNode_v2 sameNode, InitATNConditionSubjFToHaveBeenConditionVingObjTransOrFinNodeAction initAction, ATNExtendedToken token)
            : base(context, token)
        {
            mSameNode = sameNode;
            mInitAction = initAction;
            ParentNode = mSameNode.ParentNode;
            mInitAction?.Invoke(this);
        }

        public override StateOfATNParsing_v2 GlobalState => StateOfATNParsing_v2.Condition_Subj_FToHave_Been_Condition_Ving_Obj_TransOrFin;

        public ATNConditionSubjFToHaveBeenConditionVingTransOrFinNode_v2 ParentNode { get; private set; }
        private ATNConditionSubjFToHaveBeenConditionVingObjTransOrFinNode_v2 mSameNode;
        private InitATNConditionSubjFToHaveBeenConditionVingObjTransOrFinNodeAction mInitAction;

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

