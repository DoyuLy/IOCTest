﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace IOCPerformanceTest.Core
{
    public class User : Identity
    {
        public int Id { get; set; }
        public string Name { get; set; }
    }
}
