using MyNPCLib.NLToCGParsing;
using System;
using System.Collections.Generic;
using System.Text;

namespace MyNPCLib.NLToCGParsing_v2.ATNNodes
{
    public delegate void InitATNQWSubjWillConditionVerbObjTransOrFinNodeAction(ATNQWSubjWillConditionVerbObjTransOrFinNode_v2 item);

    public class ATNQWSubjWillConditionVerbObjTransOrFinNodeFactory_v2: BaseATNNodeFactory_v2
    {
        public ATNQWSubjWillConditionVerbObjTransOrFinNodeFactory_v2(ATNQWSubjWillConditionVerbTransOrFinNode_v2 parentNode, ATNExtendedToken token)
        {
            mNumberOfConstructor = 1;
            mParentNode = parentNode;
            mToken = token;
        }

        public ATNQWSubjWillConditionVerbObjTransOrFinNodeFactory_v2(ATNQWSubjWillConditionVerbObjTransOrFinNode_v2 sameNode, ATNExtendedToken token, InitATNQWSubjWillConditionVerbObjTransOrFinNodeAction initAction)
        {
            mNumberOfConstructor = 2;
            mSameNode = sameNode;
            mToken = token;
            mInitAction = initAction;
        }

        private int mNumberOfConstructor;
        private ATNQWSubjWillConditionVerbTransOrFinNode_v2 mParentNode;
        private ATNQWSubjWillConditionVerbObjTransOrFinNode_v2 mSameNode;
        private ATNExtendedToken mToken;
        private InitATNQWSubjWillConditionVerbObjTransOrFinNodeAction mInitAction;

        public override BaseATNNode_v2 Create(ContextOfATNParsing_v2 context)
        {
            switch(mNumberOfConstructor)
            {
                case 1:
                    return new ATNQWSubjWillConditionVerbObjTransOrFinNode_v2(context, mParentNode, mToken);

                case 2:
                    return new ATNQWSubjWillConditionVerbObjTransOrFinNode_v2(context, mSameNode, mInitAction, mToken);

                default:
                    throw new ArgumentOutOfRangeException(nameof(mNumberOfConstructor), mNumberOfConstructor, null);
            }
        }
    }

/*Sub states:
    QWSubj_Will_Condition_Verb_Obj_Condition_Fin
*/

    public class ATNQWSubjWillConditionVerbObjTransOrFinNode_v2: BaseATNNode_v2
    {
        public ATNQWSubjWillConditionVerbObjTransOrFinNode_v2(ContextOfATNParsing_v2 context, ATNQWSubjWillConditionVerbTransOrFinNode_v2 parentNode, ATNExtendedToken token)
            : base(context, token)
        {
            ParentNode = parentNode;
        }

        public ATNQWSubjWillConditionVerbObjTransOrFinNode_v2(ContextOfATNParsing_v2 context, ATNQWSubjWillConditionVerbObjTransOrFinNode_v2 sameNode, InitATNQWSubjWillConditionVerbObjTransOrFinNodeAction initAction, ATNExtendedToken token)
            : base(context, token)
        {
            mSameNode = sameNode;
            mInitAction = initAction;
            ParentNode = mSameNode.ParentNode;
            mInitAction?.Invoke(this);
        }

        public override StateOfATNParsing_v2 GlobalState => StateOfATNParsing_v2.QWSubj_Will_Condition_Verb_Obj_TransOrFin;

        public ATNQWSubjWillConditionVerbTransOrFinNode_v2 ParentNode { get; private set; }
        private ATNQWSubjWillConditionVerbObjTransOrFinNode_v2 mSameNode;
        private InitATNQWSubjWillConditionVerbObjTransOrFinNodeAction mInitAction;

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

