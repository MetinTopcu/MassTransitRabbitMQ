﻿using Shared;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Consumer1
{
    public class Message : IMessage
    {
        public string Text { get; set; }
    }
}
