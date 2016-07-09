using GnuClay.CommonUtils.TypeHelpers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GnuClay.Engine.CGResolver.Implementations.FromECGToICG
{
    public class NodeNameInfo : IToStringData
    {
        /// <summary>
        /// Represents quantification in name
        /// </summary>
        public enum QuantificationInfo
        {
            /// <summary>
            /// None quantification.
            /// </summary>
            None,

            /// <summary>
            /// Existential quantification (∃).
            /// </summary>
            Existential,

            /// <summary>
            /// Universal quantification (∀).
            /// </summary>
            Universal
        }

        public bool HasQuestion
        {
            get
            {
                return HasClassQuestion || HasInstanceQuestion;
            }
        }

        public bool HasVar
        {
            get
            {
                return HasClassVar || HasInstanceVar;
            }
        }

        public bool HasClass { get; set; } = false;

        public string ClassName { get; set; } = string.Empty;

        public bool HasClassQuestion { get; set; } = false;

        public bool HasClassVar { get; set; } = false;

        public QuantificationInfo ClassQuantification { get; set; } = QuantificationInfo.None;

        public bool HasInstance { get; set; } = false;

        public bool HasInstanceQuestion { get; set; } = false;

        public bool HasInstanceVar { get; set; } = false;

        public string InstanceName { get; set; } = string.Empty;

        public QuantificationInfo InstanceQuantification { get; set; } = QuantificationInfo.None;

        public override string ToString()
        {
            return _ObjectHelper.PrintDefaultToStringInformation(this);
        }

        public string ToStringData()
        {
            var tmpSb = new StringBuilder();

            tmpSb.Append(nameof(HasQuestion));
            tmpSb.Append(" = ");
            tmpSb.AppendLine(HasQuestion.ToString());

            tmpSb.Append(nameof(HasVar));
            tmpSb.Append(" = ");
            tmpSb.AppendLine(HasVar.ToString());

            tmpSb.Append(nameof(HasClass));
            tmpSb.Append(" = ");
            tmpSb.AppendLine(HasClass.ToString());

            tmpSb.Append(nameof(ClassName));
            tmpSb.Append(" = ");
            tmpSb.AppendLine(ClassName);
            
            tmpSb.Append(nameof(HasClassQuestion));
            tmpSb.Append(" = ");
            tmpSb.AppendLine(HasClassQuestion.ToString());

            tmpSb.Append(nameof(HasClassVar));
            tmpSb.Append(" = ");
            tmpSb.AppendLine(HasClassVar.ToString());
            
            tmpSb.Append(nameof(ClassQuantification));
            tmpSb.Append(" = ");
            tmpSb.AppendLine(ClassQuantification.ToString());

            tmpSb.Append(nameof(HasInstance));
            tmpSb.Append(" = ");
            tmpSb.AppendLine(HasInstance.ToString());
            
            tmpSb.Append(nameof(HasInstanceQuestion));
            tmpSb.Append(" = ");
            tmpSb.AppendLine(HasInstanceQuestion.ToString());

            tmpSb.Append(nameof(HasInstanceVar));
            tmpSb.Append(" = ");
            tmpSb.AppendLine(HasInstanceVar.ToString());
            
            tmpSb.Append(nameof(InstanceName));
            tmpSb.Append(" = ");
            tmpSb.AppendLine(InstanceName);
            
            tmpSb.Append(nameof(InstanceQuantification));
            tmpSb.Append(" = ");
            tmpSb.AppendLine(InstanceQuantification.ToString());

            return tmpSb.ToString();
        }
    }
}
