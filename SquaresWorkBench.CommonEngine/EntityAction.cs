using GnuClay.CommonUtils.TypeHelpers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SquaresWorkBench.CommonEngine
{
    public enum EntityActionState
    {
        Executing,
        EndSuccess,
        EndError
    }

    public class EntityAction : IToStringData
    {
        public EntityAction(Command command)
        {
            Command = command;
        }

        public Command Command { get; set; } = null;
        public EntityActionState State { get; set; } = EntityActionState.Executing;

        /// <summary>
        /// Converts the value of this instance to its equivalent string representation. Overrides (Object.ToString)
        /// </summary>
        /// <returns>The string representation of this instance.</returns>
        public override string ToString()
        {
            return _ObjectHelper.PrintDefaultToStringInformation(this);
        }

        /// <summary>
        /// Provides string data for method ToString.
        /// </summary>
        /// <returns>The string representation of this instance.</returns>
        public string ToStringData()
        {
            var tmpSb = new StringBuilder();

            tmpSb.AppendLine($"{nameof(State)} = {State}");

            return tmpSb.ToString();
        }

        public static EntityAction Create(Command command)
        {
            return new EntityAction(command);
        }

        public static EntityAction CreateSuccess(Command command)
        {
            var action = new EntityAction(command);
            action.State = EntityActionState.EndSuccess;
            return action;
        }

        public static EntityAction CreateError(Command command)
        {
            var action = new EntityAction(command);
            action.State = EntityActionState.EndError;
            return action;
        }
    }
}
