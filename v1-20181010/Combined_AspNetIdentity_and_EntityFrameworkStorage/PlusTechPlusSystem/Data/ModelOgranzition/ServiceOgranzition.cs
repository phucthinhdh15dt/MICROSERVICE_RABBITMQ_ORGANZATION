using System;
using System.Collections.Generic;

namespace PlusTechPlusSystem.Data.ModelOgranzition
{
    public partial class ServiceOgranzition
    {
        public int Id { get; set; }
        public string IdService { get; set; }
        public string ServiceName { get; set; }
        public bool? ServerDefault { get; set; }
        public bool? Active { get; set; }
    }
}
