using System;
using System.Collections.Generic;
using System.Text;

namespace GnuClay.CommonClasses.CommonExceptions
{
    public class GnuClayImageNotFoundException: Exception
    {
        public GnuClayImageNotFoundException(string imageName)
            : base($"Gnu clay image `{imageName}` not found")
        {
        }
    }
}
