﻿using System;
using System.Collections.Generic;
using System.Text;

namespace SwapiCL.Model
{
    public class RootObject<T>
    {
        public int count { get; set; }
        public string next { get; set; }
        public object previous { get; set; }
        public List<T> results { get; set; }
    }
}
