using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using GnuClay.Engine.CGResolver.Implementations.FromECGToICG.NodeNameLexer;
using GnuClay.Engine.ICG;

namespace GnuClay.Engine.CGResolver.Implementations.FromECGToICG.NodeNameParser
{
    public class NodeNameParserMainLeaf: NodeNameParserBaseLeaf
    {
        private enum State
        {
            Base,
            ClassName,
            ClassQuestion,
            ClassUniversum,
            ClassExistential,
            ClassVar,
            OpenedBracket,
            ClosedBracket,
            PreInstance,
            BeginInstanceId,
            InstanceId,
            InstanceQuestion,
            InstanceUniversum,
            InstanceExistential,
            InstanceVar
        }

        public NodeNameParserMainLeaf(NodeNameParserContext context)
            : base(context)
        {
        }

        private State mState = State.Base;

        private StringBuilder mNameBuffer = null;

        private int mBracketLevel = 0;

        protected override void ProcessToken(NodeNameToken token)
        {
            switch (mState)
            {
                case State.Base:
                    ProcessToken_InBase(token);
                    return;

                case State.ClassName:
                    ProcessToken_InClassName(token);
                    return;

                case State.OpenedBracket:
                    ProcessToken_InOpenedBracket(token);
                    return;

                case State.ClosedBracket:
                    ProcessToken_InClosedBracket(token);
                    return;

                case State.ClassQuestion:
                    ProcessToken_InClassQuestion(token);
                    return;

                case State.ClassUniversum:
                    ProcessToken_InClassUniversum(token);
                    return;

                case State.ClassExistential:
                    ProcessToken_InClassExistential(token);
                    return;

                case State.ClassVar:
                    ProcessToken_InClassVar(token);
                    return;

                case State.PreInstance:
                    ProcessToken_InPreInstance(token);
                    return;

                case State.BeginInstanceId:
                    ProcessToken_InBeginInstanceId(token);
                    return;

                case State.InstanceId:
                    ProcessToken_InInstanceId(token);
                    return;

                case State.InstanceQuestion:
                    ProcessToken_InInstanceQuestion(token);
                    return;

                case State.InstanceUniversum:
                    ProcessToken_InInstanceUniversum(token);
                    return;

                case State.InstanceExistential:
                    ProcessToken_InInstanceExistential(token);
                    return;

                case State.InstanceVar:
                    ProcessToken_InInstanceVar(token);
                    return;
            }

            throw CreateUnexpectedTokenException(token);
        }

        private void ProcessToken_InBase(NodeNameToken token)
        {
            switch(token.Kind)
            {
                case NodeNameTokenKind.Octothorpe:
                    mState = State.BeginInstanceId;
                    return;

                case NodeNameTokenKind.String:
                    CheckStringTokenContent(token.Content);

                    mState = State.ClassName;

                    Context.Result.HasClass = true;
                    Context.Result.ClassQuantification = QuantificationInfo.None;

                    mNameBuffer = new StringBuilder(token.Content);

                    return;

                case NodeNameTokenKind.UniversalQuantifier:
                    Context.Result.ClassQuantification = QuantificationInfo.Universal;

                    mState = State.ClassUniversum;

                    return;

                case NodeNameTokenKind.ExistentialQuantifier:
                    Context.Result.HasClass = true;
                    Context.Result.ClassQuantification = QuantificationInfo.Existential;

                    mState = State.ClassExistential;

                    return;

                case NodeNameTokenKind.Question:
                    mState = State.ClassQuestion;

                    Context.Result.HasClass = true;
                    Context.Result.HasClassQuestion = true;
                    return;
            }

            throw CreateUnexpectedTokenException(token);
        }

        private void ProcessToken_InClassName(NodeNameToken token)
        {
            switch (token.Kind)
            {
                case NodeNameTokenKind.String:
                    CheckStringTokenContent(token.Content);

                    mState = State.ClassName;

                    mNameBuffer.Append(" ");

                    mNameBuffer.Append(token.Content);

                    return;

                case NodeNameTokenKind.OpenRoundBracket:
                    mBracketLevel++;

                    mState = State.OpenedBracket;

                    mNameBuffer.Append("(");

                    return;

                case NodeNameTokenKind.CloseRoundBracket:
                    mBracketLevel--;

                    mState = State.ClosedBracket;

                    mNameBuffer.Append(")");

                    return;

                case NodeNameTokenKind.Colon:
                    mState = State.PreInstance;

                    Context.Result.ClassName = mNameBuffer.ToString().Trim();

                    return;
            }

            throw CreateUnexpectedTokenException(token);
        }

        private void ProcessToken_InOpenedBracket(NodeNameToken token)
        {
            switch(token.Kind)
            {
                case NodeNameTokenKind.String:
                    CheckStringTokenContent(token.Content);

                    mState = State.ClassName;

                    mNameBuffer.Append(token.Content);

                    return;
            }

            throw CreateUnexpectedTokenException(token);
        }

        private void ProcessToken_InClosedBracket(NodeNameToken token)
        {
            NLog.LogManager.GetCurrentClassLogger().Info("ProcessToken_InClosedBracket token = {0}", token);

            switch (token.Kind)
            {
                case NodeNameTokenKind.CloseRoundBracket:
                    mState = State.ClosedBracket;

                    mNameBuffer.Append(")");

                    mBracketLevel--;

                    return;

                case NodeNameTokenKind.Colon:
                    mState = State.PreInstance;

                    Context.Result.ClassName = mNameBuffer.ToString().Trim();

                    return;
            }

            throw CreateUnexpectedTokenException(token);
        }

        private void ProcessToken_InClassQuestion(NodeNameToken token)
        {
            switch (token.Kind)
            {
                case NodeNameTokenKind.UniversalQuantifier:
                    Context.Result.ClassQuantification = QuantificationInfo.Universal;

                    mState = State.ClassUniversum;
                    return;

                case NodeNameTokenKind.ExistentialQuantifier:
                    Context.Result.ClassQuantification = QuantificationInfo.Existential;

                    mState = State.ClassExistential;
                    return;

                case NodeNameTokenKind.String:
                    CheckStringTokenContent(token.Content);

                    Context.Result.ClassName = token.Content;
                    Context.Result.HasClassVar = true;

                    mState = State.ClassVar;

                    return;

                case NodeNameTokenKind.Colon:
                    mState = State.PreInstance;
                    return;
            }

            throw CreateUnexpectedTokenException(token);
        }

        private void ProcessToken_InClassUniversum(NodeNameToken token)
        {
            switch(token.Kind)
            {
                case NodeNameTokenKind.Colon:
                    mState = State.PreInstance;
                    return;

                case NodeNameTokenKind.String:
                    CheckStringTokenContent(token.Content);

                    mState = State.ClassVar;

                    Context.Result.ClassName = token.Content;
                    Context.Result.HasClass = true;
                    Context.Result.HasClassVar = true;
                    return;
            }

            throw CreateUnexpectedTokenException(token);
        }

        private void ProcessToken_InClassExistential(NodeNameToken token)
        {
            switch (token.Kind)
            {
                case NodeNameTokenKind.String:
                    CheckStringTokenContent(token.Content);

                    mState = State.ClassVar;

                    Context.Result.ClassName = token.Content;
                    Context.Result.HasClass = true;
                    Context.Result.HasClassVar = true;
                    return;

                case NodeNameTokenKind.Colon:
                    mState = State.PreInstance;
                    return;
            }

            throw CreateUnexpectedTokenException(token);
        }

        private void ProcessToken_InClassVar(NodeNameToken token)
        {
            switch (token.Kind)
            {
                case NodeNameTokenKind.Colon:
                    mState = State.PreInstance;
                    return;
            }

            throw CreateUnexpectedTokenException(token);
        }

        private void ProcessToken_InPreInstance(NodeNameToken token)
        {
            switch(token.Kind)
            {
                case NodeNameTokenKind.Octothorpe:
                    mState = State.BeginInstanceId;
                    return;

                case NodeNameTokenKind.UniversalQuantifier:
                    mState = State.InstanceUniversum;
                    return;

                case NodeNameTokenKind.ExistentialQuantifier:
                    mState = State.InstanceExistential;

                    Context.Result.HasInstance = true;
                    Context.Result.InstanceQuantification = QuantificationInfo.Existential;
                    return;

                case NodeNameTokenKind.Question:
                    mState = State.InstanceQuestion;

                    Context.Result.HasInstance = true;
                    Context.Result.HasInstanceQuestion = true;
                    return;
            }

            throw CreateUnexpectedTokenException(token);
        }

        private void ProcessToken_InBeginInstanceId(NodeNameToken token)
        {
            switch(token.Kind)
            {
                case NodeNameTokenKind.String:
                    CheckStringTokenContent(token.Content);

                    Context.Result.HasInstance = true;
                    Context.Result.InstanceName = token.Content;
                    Context.Result.InstanceQuantification = QuantificationInfo.None;

                    mState = State.InstanceId;

                    return;

                case NodeNameTokenKind.Question:
                    Context.Result.HasInstance = true;
                    Context.Result.HasInstanceQuestion = true;

                    mState = State.InstanceQuestion;

                    return;

                case NodeNameTokenKind.ExistentialQuantifier:
                    Context.Result.HasInstance = true;
                    Context.Result.InstanceQuantification = QuantificationInfo.Existential;

                    mState = State.InstanceExistential;

                    return;

                case NodeNameTokenKind.UniversalQuantifier:
                    Context.Result.InstanceQuantification = QuantificationInfo.Universal;

                    mState = State.InstanceUniversum;

                    return;
            }

            throw CreateUnexpectedTokenException(token);
        }

        private void ProcessToken_InInstanceId(NodeNameToken token)
        {
            throw CreateUnexpectedTokenException(token);
        }

        private void ProcessToken_InInstanceQuestion(NodeNameToken token)
        {
            switch (token.Kind)
            {
                case NodeNameTokenKind.String:
                    CheckStringTokenContent(token.Content);

                    Context.Result.HasInstance = true;
                    Context.Result.HasInstanceVar = true;
                    Context.Result.InstanceName = token.Content;

                    mState = State.InstanceVar;
                    return;

                case NodeNameTokenKind.ExistentialQuantifier:
                    Context.Result.HasInstance = true;
                    Context.Result.InstanceQuantification = QuantificationInfo.Existential;

                    mState = State.InstanceExistential;
                    return;

                case NodeNameTokenKind.UniversalQuantifier:
                    Context.Result.InstanceQuantification = QuantificationInfo.Universal;

                    mState = State.InstanceUniversum;
                    return;
            }

            throw CreateUnexpectedTokenException(token);
        }

        private void ProcessToken_InInstanceUniversum(NodeNameToken token)
        {
            switch (token.Kind)
            {
                case NodeNameTokenKind.String:
                    CheckStringTokenContent(token.Content);

                    Context.Result.HasInstance = true;
                    Context.Result.HasInstanceVar = true;
                    Context.Result.InstanceName = token.Content;

                    mState = State.InstanceVar;
                    return;
            }

            throw CreateUnexpectedTokenException(token);
        }

        private void ProcessToken_InInstanceExistential(NodeNameToken token)
        {
            switch (token.Kind)
            {
                case NodeNameTokenKind.String:
                    CheckStringTokenContent(token.Content);

                    Context.Result.HasInstance = true;
                    Context.Result.HasInstanceVar = true;
                    Context.Result.InstanceName = token.Content;

                    mState = State.InstanceVar;
                    return;
            }

            throw CreateUnexpectedTokenException(token);
        }

        private void ProcessToken_InInstanceVar(NodeNameToken token)
        {
            throw CreateUnexpectedTokenException(token);
        }

        protected override void OnExitIfEndOfString()
        {
            switch (mState)
            {
                case State.ClassName:
                    Context.Result.ClassName = mNameBuffer.ToString().Trim();
                    return;

                case State.ClosedBracket:
                    if(mBracketLevel == 0)
                    {
                        Context.Result.ClassName = mNameBuffer.ToString().Trim();
                        
                        return;
                    }
                    break;

                case State.ClassQuestion:    
                    return;

                case State.ClassUniversum:
                    return;

                case State.ClassExistential:
                    return;

                case State.ClassVar:
                    return;

                case State.InstanceId:
                    return;

                case State.InstanceQuestion:                 
                    return;

                case State.InstanceUniversum:           
                    return;

                case State.InstanceExistential:
                    return;

                case State.InstanceVar:               
                    return;
            }

            throw CreateAbnormallyTerminationException();
        }

        private Exception CreateAbnormallyTerminationException()
        {
            return new Exception("Abnormally terminated string");
        }

        private void CheckStringTokenContent(string content)
        {
            if(string.IsNullOrWhiteSpace(content))
            {
                throw new ArgumentNullException(nameof(content), "String token can not be null or empty");
            }
        }
    }
}
