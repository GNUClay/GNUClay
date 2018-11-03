using MyNPCLib.NLToCGParsing;
using System;
using System.Collections.Generic;
using System.Text;

namespace MyNPCLib.NLToCGParsing_v2.ATNNodes
{
    public delegate void InitATNSubjVerbObjTransOrFinNodeAction(ATNSubjVerbObjTransOrFinNode_v2 item);

    public class ATNSubjVerbObjTransOrFinNodeFactory_v2: BaseATNNodeFactory_v2
    {
        public ATNSubjVerbObjTransOrFinNodeFactory_v2(ATNSubjVerbTransOrFinNode_v2 parentNode, ATNExtendedToken token)
        {
            mNumberOfConstructor = 1;
            mParentNode = parentNode;
            mToken = token;
        }

        public ATNSubjVerbObjTransOrFinNodeFactory_v2(ATNSubjVerbObjTransOrFinNode_v2 sameNode, ATNExtendedToken token, InitATNSubjVerbObjTransOrFinNodeAction initAction)
        {
            mNumberOfConstructor = 2;
            mSameNode = sameNode;
            mToken = token;
            mInitAction = initAction;
        }

        private int mNumberOfConstructor;
        private ATNSubjVerbTransOrFinNode_v2 mParentNode;
        private ATNSubjVerbObjTransOrFinNode_v2 mSameNode;
        private ATNExtendedToken mToken;
        private InitATNSubjVerbObjTransOrFinNodeAction mInitAction;

        public override BaseATNNode_v2 Create(ContextOfATNParsing_v2 context)
        {
            switch(mNumberOfConstructor)
            {
                case 1:
                    return new ATNSubjVerbObjTransOrFinNode_v2(context, mParentNode, mToken);

                case 2:
                    return new ATNSubjVerbObjTransOrFinNode_v2(context, mSameNode, mInitAction, mToken);

                default:
                    throw new ArgumentOutOfRangeException(nameof(mNumberOfConstructor), mNumberOfConstructor, null);
            }
        }
    }

/*Sub states:
    Subj_Verb_Obj_Condition_Fin
*/

    public class ATNSubjVerbObjTransOrFinNode_v2: BaseATNNode_v2
    {
        public enum State
        {
            Init
        }

        public ATNSubjVerbObjTransOrFinNode_v2(ContextOfATNParsing_v2 context, ATNSubjVerbTransOrFinNode_v2 parentNode, ATNExtendedToken token)
            : base(context, token)
        {
            ParentNode = parentNode;
        }

        public ATNSubjVerbObjTransOrFinNode_v2(ContextOfATNParsing_v2 context, ATNSubjVerbObjTransOrFinNode_v2 sameNode, InitATNSubjVerbObjTransOrFinNodeAction initAction, ATNExtendedToken token)
            : base(context, token)
        {
            mSameNode = sameNode;
            mInitAction = initAction;
            ParentNode = mSameNode.ParentNode;
            mInitAction?.Invoke(this);
        }

        public override StateOfATNParsing_v2 GlobalState => StateOfATNParsing_v2.Subj_Verb_Obj_TransOrFin;

        public ATNSubjVerbTransOrFinNode_v2 ParentNode { get; private set; }
        private ATNSubjVerbObjTransOrFinNode_v2 mSameNode;
        private InitATNSubjVerbObjTransOrFinNodeAction mInitAction;

        public State InternalState = State.Init;

        protected override void ImplementGoalToken()
        {
#if DEBUG
            LogInstance.Log($"InternalState = {InternalState}");
            LogInstance.Log($"Token = {Token}");
            LogInstance.Log($"Context = {Context}");
#endif

            switch (InternalState)
            {
                case State.Init:
                    {
                        var partOfSpeech = Token.PartOfSpeech;

                        switch(partOfSpeech)
                        {
                            default:
                                throw new ArgumentOutOfRangeException(nameof(partOfSpeech), partOfSpeech, null);
                        }
                    }
                    break;

                default:
                    throw new ArgumentOutOfRangeException(nameof(InternalState), InternalState, null);
            }
        }

        protected override void ProcessNextToken()
        {
            throw new NotImplementedException();
        }
    }
}

