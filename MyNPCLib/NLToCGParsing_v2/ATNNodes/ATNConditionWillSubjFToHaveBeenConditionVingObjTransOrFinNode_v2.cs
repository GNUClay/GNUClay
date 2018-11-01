using MyNPCLib.NLToCGParsing;
using System;
using System.Collections.Generic;
using System.Text;

namespace MyNPCLib.NLToCGParsing_v2.ATNNodes
{
    public delegate void InitATNConditionWillSubjFToHaveBeenConditionVingObjTransOrFinNodeAction(ATNConditionWillSubjFToHaveBeenConditionVingObjTransOrFinNode_v2 item);

    public class ATNConditionWillSubjFToHaveBeenConditionVingObjTransOrFinNodeFactory_v2: BaseATNNodeFactory_v2
    {
        public ATNConditionWillSubjFToHaveBeenConditionVingObjTransOrFinNodeFactory_v2(ATNConditionWillSubjFToHaveBeenConditionVingTransOrFinNode_v2 parentNode, ATNExtendedToken token)
        {
            mNumberOfConstructor = 1;
            mParentNode = parentNode;
            mToken = token;
        }

        public ATNConditionWillSubjFToHaveBeenConditionVingObjTransOrFinNodeFactory_v2(ATNConditionWillSubjFToHaveBeenConditionVingObjTransOrFinNode_v2 sameNode, ATNExtendedToken token, InitATNConditionWillSubjFToHaveBeenConditionVingObjTransOrFinNodeAction initAction)
        {
            mNumberOfConstructor = 2;
            mSameNode = sameNode;
            mToken = token;
            mInitAction = initAction;
        }

        private int mNumberOfConstructor;
        private ATNConditionWillSubjFToHaveBeenConditionVingTransOrFinNode_v2 mParentNode;
        private ATNConditionWillSubjFToHaveBeenConditionVingObjTransOrFinNode_v2 mSameNode;
        private ATNExtendedToken mToken;
        private InitATNConditionWillSubjFToHaveBeenConditionVingObjTransOrFinNodeAction mInitAction;

        public override BaseATNNode_v2 Create(ContextOfATNParsing_v2 context)
        {
            switch(mNumberOfConstructor)
            {
                case 1:
                    return new ATNConditionWillSubjFToHaveBeenConditionVingObjTransOrFinNode_v2(context, mParentNode, mToken);

                case 2:
                    return new ATNConditionWillSubjFToHaveBeenConditionVingObjTransOrFinNode_v2(context, mSameNode, mInitAction, mToken);

                default:
                    throw new ArgumentOutOfRangeException(nameof(mNumberOfConstructor), mNumberOfConstructor, null);
            }
        }
    }

/*Sub states:
    Condition_Will_Subj_FToHave_Been_Condition_Ving_Obj_Condition_Fin
*/

    public class ATNConditionWillSubjFToHaveBeenConditionVingObjTransOrFinNode_v2: BaseATNNode_v2
    {
        public ATNConditionWillSubjFToHaveBeenConditionVingObjTransOrFinNode_v2(ContextOfATNParsing_v2 context, ATNConditionWillSubjFToHaveBeenConditionVingTransOrFinNode_v2 parentNode, ATNExtendedToken token)
            : base(context, token)
        {
            ParentNode = parentNode;
        }

        public ATNConditionWillSubjFToHaveBeenConditionVingObjTransOrFinNode_v2(ContextOfATNParsing_v2 context, ATNConditionWillSubjFToHaveBeenConditionVingObjTransOrFinNode_v2 sameNode, InitATNConditionWillSubjFToHaveBeenConditionVingObjTransOrFinNodeAction initAction, ATNExtendedToken token)
            : base(context, token)
        {
            mSameNode = sameNode;
            mInitAction = initAction;
            ParentNode = mSameNode.ParentNode;
            mInitAction?.Invoke(this);
        }

        public override StateOfATNParsing_v2 GlobalState => StateOfATNParsing_v2.Condition_Will_Subj_FToHave_Been_Condition_Ving_Obj_TransOrFin;

        public ATNConditionWillSubjFToHaveBeenConditionVingTransOrFinNode_v2 ParentNode { get; private set; }
        private ATNConditionWillSubjFToHaveBeenConditionVingObjTransOrFinNode_v2 mSameNode;
        private InitATNConditionWillSubjFToHaveBeenConditionVingObjTransOrFinNodeAction mInitAction;

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

