﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace mko.Graphic
{
    public abstract class ContextCmdSetPen : ContextCmd
    {
        public Pen Pen { get; set; }
    }
}