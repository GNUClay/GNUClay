﻿using System;
using System.Collections.Generic;
using System.Text;

namespace GnuClay.Core.Interfaces
{
    public interface ICoreLoaderFromSourceCodeComponent: ICoreComponent
    {
        void LoadFromFile(string fileName);
    }
}
