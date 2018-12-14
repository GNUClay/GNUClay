using MyNPCLib.LogicalSoundModeling;
using System;
using System.Collections.Generic;
using System.Text;

namespace MyNPCLib
{
    public class SoundEventProcessOptions: IObjectToString
    {
        public string ActionName { get; set; }
        public KindOfSoundEvent Kind { get; set; } = KindOfSoundEvent.Unknown;

        public override string ToString()
        {
            return ToString(0u);
        }

        public string ToString(uint n)
        {
            return this.GetDefaultToStringInformation(n);
        }

        public string PropertiesToString(uint n)
        {
            var spaces = StringHelper.Spaces(n);
            var nextN = n + 4;
            var sb = new StringBuilder();
            sb.AppendLine($"{spaces}{nameof(ActionName)} = {ActionName}");
            sb.AppendLine($"{spaces}{nameof(Kind)} = {Kind}");
            return sb.ToString();
        }
    }
}
