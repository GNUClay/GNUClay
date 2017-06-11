using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GnuClay.CommonUtils.Actors
{
    public interface ICommand
    {
        string Name { get; set; }
        string Target { get; set; }
        Dictionary<string, object> Params { get; set; }
    }
}
