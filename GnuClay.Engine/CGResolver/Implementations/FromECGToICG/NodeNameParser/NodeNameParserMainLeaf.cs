using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using GnuClay.Engine.CGResolver.Implementations.FromECGToICG.NodeNameLexer;

namespace GnuClay.Engine.CGResolver.Implementations.FromECGToICG.NodeNameParser
{
    public class NodeNameParserMainLeaf: NodeNameParserBaseLeaf
    {
        private enum State
        {
            Base,
            ClassName,
            NextClassName,
            ClassQuestion,
            ClassUniversum,
            ClassExistential,
            ClassVar,
            BeginQualification,
            InQualification,
            EndQualification,
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

        protected override void ProcessToken(NodeNameToken token)
        {
            switch(mState)
            {
                case State.Base:
                    ProcessToken_InBase(token);
                    return;

                case State.ClassName:
                    ProcessToken_InClassName(token);
                    return;

                case State.NextClassName:
                    ProcessToken_InNextClassName(token);
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

                case State.BeginQualification:
                    ProcessToken_InBeginQualification(token);
                    return;

                case State.InQualification:
                    ProcessToken_InInQualification(token);
                    return;

                case State.EndQualification:
                    ProcessToken_InEndQualification(token);
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
            NLog.LogManager.GetCurrentClassLogger().Info("ProcessToken_InBase token = {0}", token);

            throw CreateUnexpectedTokenException(token);
        }

        private void ProcessToken_InClassName(NodeNameToken token)
        {
            NLog.LogManager.GetCurrentClassLogger().Info("ProcessToken_InClassName token = {0}", token);

            throw CreateUnexpectedTokenException(token);
        }

        private void ProcessToken_InNextClassName(NodeNameToken token)
        {
            NLog.LogManager.GetCurrentClassLogger().Info("ProcessToken_InNextClassName token = {0}", token);

            throw CreateUnexpectedTokenException(token);
        }

        private void ProcessToken_InClassQuestion(NodeNameToken token)
        {
            NLog.LogManager.GetCurrentClassLogger().Info("ProcessToken_InClassQuestion token = {0}", token);

            throw CreateUnexpectedTokenException(token);
        }

        private void ProcessToken_InClassUniversum(NodeNameToken token)
        {
            NLog.LogManager.GetCurrentClassLogger().Info("ProcessToken_InClassUniversum token = {0}", token);

            throw CreateUnexpectedTokenException(token);
        }

        private void ProcessToken_InClassExistential(NodeNameToken token)
        {
            NLog.LogManager.GetCurrentClassLogger().Info("ProcessToken_InClassExistential token = {0}", token);

            throw CreateUnexpectedTokenException(token);
        }

        private void ProcessToken_InClassVar(NodeNameToken token)
        {
            NLog.LogManager.GetCurrentClassLogger().Info("ProcessToken_InClassVar token = {0}", token);

            throw CreateUnexpectedTokenException(token);
        }

        private void ProcessToken_InBeginQualification(NodeNameToken token)
        {
            NLog.LogManager.GetCurrentClassLogger().Info("ProcessToken_InBeginQualification token = {0}", token);

            throw CreateUnexpectedTokenException(token);
        }

        private void ProcessToken_InInQualification(NodeNameToken token)
        {
            NLog.LogManager.GetCurrentClassLogger().Info("ProcessToken_InInQualification token = {0}", token);

            throw CreateUnexpectedTokenException(token);
        }

        private void ProcessToken_InEndQualification(NodeNameToken token)
        {
            NLog.LogManager.GetCurrentClassLogger().Info("ProcessToken_InEndQualification token = {0}", token);

            throw CreateUnexpectedTokenException(token);
        }

        private void ProcessToken_InPreInstance(NodeNameToken token)
        {
            NLog.LogManager.GetCurrentClassLogger().Info("ProcessToken_InPreInstance token = {0}", token);

            throw CreateUnexpectedTokenException(token);
        }

        private void ProcessToken_InBeginInstanceId(NodeNameToken token)
        {
            NLog.LogManager.GetCurrentClassLogger().Info("ProcessToken_InBeginInstanceId token = {0}", token);

            throw CreateUnexpectedTokenException(token);
        }

        private void ProcessToken_InInstanceId(NodeNameToken token)
        {
            NLog.LogManager.GetCurrentClassLogger().Info("ProcessToken_InInstanceId token = {0}", token);

            throw CreateUnexpectedTokenException(token);
        }

        private void ProcessToken_InInstanceQuestion(NodeNameToken token)
        {
            NLog.LogManager.GetCurrentClassLogger().Info("ProcessToken_InInstanceQuestion token = {0}", token);

            throw CreateUnexpectedTokenException(token);
        }

        private void ProcessToken_InInstanceUniversum(NodeNameToken token)
        {
            NLog.LogManager.GetCurrentClassLogger().Info("ProcessToken_InInstanceUniversum token = {0}", token);

            throw CreateUnexpectedTokenException(token);
        }

        private void ProcessToken_InInstanceExistential(NodeNameToken token)
        {
            NLog.LogManager.GetCurrentClassLogger().Info("ProcessToken_InInstanceExistential token = {0}", token);

            throw CreateUnexpectedTokenException(token);
        }

        private void ProcessToken_InInstanceVar(NodeNameToken token)
        {
            NLog.LogManager.GetCurrentClassLogger().Info("ProcessToken_InInstanceVar token = {0}", token);

            throw CreateUnexpectedTokenException(token);
        }

        protected override void OnExit()
        {
            NLog.LogManager.GetCurrentClassLogger().Info("OnExit");
        }

        protected override void OnExitIfEndOfString()
        {
            NLog.LogManager.GetCurrentClassLogger().Info("OnExitIfEndOfString");
        }
    }
}
