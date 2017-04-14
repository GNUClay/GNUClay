using GnuClay.CommonUtils.TypeHelpers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SquaresWorkBench.CommonEngine
{
    public enum EntityActionStatus
    {
        Running,
        Completed,
        Faulted
    }

    public class EntityAction : IToStringData
    {
        public EntityAction(Command command)
        {
            Command = command;
        }

        public Command Command { get; set; } = null;
        public EntityActionStatus Status { get; set; } = EntityActionStatus.Running;

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

            tmpSb.AppendLine($"{nameof(Status)} = {Status}");

            return tmpSb.ToString();
        }

        public static EntityAction Create(Command command)
        {
            return new EntityAction(command);
        }

        public static EntityAction CreateSuccess(Command command)
        {
            var action = new EntityAction(command);
            action.Status = EntityActionStatus.Completed;
            return action;
        }

        public static EntityAction CreateError(Command command)
        {
            var action = new EntityAction(command);
            action.Status = EntityActionStatus.Faulted;
            return action;
        }
    }
}
