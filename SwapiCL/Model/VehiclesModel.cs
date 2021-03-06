﻿using System;
using System.Collections.Generic;
using System.Text;

namespace SwapiCL.Model
{
    public class VehiclesModel: BaseModel
    {
        public string name { get; set; }
        public string model { get; set; }
        public string manufacturer { get; set; }
        public string cost_in_credits { get; set; }
        public string length { get; set; }
        public string max_atmosphering_speed { get; set; }
        public string crew { get; set; }
        public string passengers { get; set; }
        public string cargo_capacity { get; set; }
        public string consumables { get; set; }
        public string vehicle_class { get; set; }
        public List<object> pilots { get; set; }
        public List<string> films { get; set; }
    }
}
