using System;
using System.Collections.Generic;
using System.Text;

namespace MyNPCLib.NLToCGParsing_v2
{
    public enum StateOfATNSlaveNAPNode
    {
        Init,
        GotNoun,
        GotDeterminerWithoutNoun,
        GotAjectiveWithoutNoun
    }
}
