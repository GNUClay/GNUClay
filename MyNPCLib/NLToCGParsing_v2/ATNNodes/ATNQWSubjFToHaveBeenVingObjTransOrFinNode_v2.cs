using MyNPCLib.NLToCGParsing;
using System;
using System.Collections.Generic;
using System.Text;

namespace MyNPCLib.NLToCGParsing_v2.ATNNodes
{
    public delegate void InitATNQWSubjFToHaveBeenVingObjTransOrFinNodeAction(ATNQWSubjFToHaveBeenVingObjTransOrFinNode_v2 item);

    public class ATNQWSubjFToHaveBeenVingObjTransOrFinNodeFactory_v2: BaseATNNodeFactory_v2
    {
        public ATNQWSubjFToHaveBeenVingObjTransOrFinNodeFactory_v2(ATNQWSubjFToHaveBeenVingTransOrFinNode_v2 parentNode, ATNExtendedToken token)
        {
            mNumberOfConstructor = 1;
            mParentNode = parentNode;
            mToken = token;
        }

        public ATNQWSubjFToHaveBeenVingObjTransOrFinNodeFactory_v2(ATNQWSubjFToHaveBeenVingObjTransOrFinNode_v2 sameNode, ATNExtendedToken token, InitATNQWSubjFToHaveBeenVingObjTransOrFinNodeAction initAction)
        {
            mNumberOfConstructor = 2;
            mSameNode = sameNode;
            mToken = token;
            mInitAction = initAction;
        }

        private int mNumberOfConstructor;
        private ATNQWSubjFToHaveBeenVingTransOrFinNode_v2 mParentNode;
        private ATNQWSubjFToHaveBeenVingObjTransOrFinNode_v2 mSameNode;
        private ATNExtendedToken mToken;
        private InitATNQWSubjFToHaveBeenVingObjTransOrFinNodeAction mInitAction;

        public override BaseATNNode_v2 Create(ContextOfATNParsing_v2 context)
        {
            switch(mNumberOfConstructor)
            {
                case 1:
                    return new ATNQWSubjFToHaveBeenVingObjTransOrFinNode_v2(context, mParentNode, mToken);

                case 2:
                    return new ATNQWSubjFToHaveBeenVingObjTransOrFinNode_v2(context, mSameNode, mInitAction, mToken);

                default:
                    throw new ArgumentOutOfRangeException(nameof(mNumberOfConstructor), mNumberOfConstructor, null);
            }
        }
    }

/*Sub states:
    QWSubj_FToHave_Been_Ving_Obj_Condition_Fin
*/

    public class ATNQWSubjFToHaveBeenVingObjTransOrFinNode_v2: BaseATNNode_v2
    {
        public ATNQWSubjFToHaveBeenVingObjTransOrFinNode_v2(ContextOfATNParsing_v2 context, ATNQWSubjFToHaveBeenVingTransOrFinNode_v2 parentNode, ATNExtendedToken token)
            : base(context, token)
        {
            ParentNode = parentNode;
        }

        public ATNQWSubjFToHaveBeenVingObjTransOrFinNode_v2(ContextOfATNParsing_v2 context, ATNQWSubjFToHaveBeenVingObjTransOrFinNode_v2 sameNode, InitATNQWSubjFToHaveBeenVingObjTransOrFinNodeAction initAction, ATNExtendedToken token)
            : base(context, token)
        {
            mSameNode = sameNode;
            mInitAction = initAction;
            ParentNode = mSameNode.ParentNode;
            mInitAction?.Invoke(this);
        }

        public override StateOfATNParsing_v2 GlobalState => StateOfATNParsing_v2.QWSubj_FToHave_Been_Ving_Obj_TransOrFin;

        public ATNQWSubjFToHaveBeenVingTransOrFinNode_v2 ParentNode { get; private set; }
        private ATNQWSubjFToHaveBeenVingObjTransOrFinNode_v2 mSameNode;
        private InitATNQWSubjFToHaveBeenVingObjTransOrFinNodeAction mInitAction;

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

