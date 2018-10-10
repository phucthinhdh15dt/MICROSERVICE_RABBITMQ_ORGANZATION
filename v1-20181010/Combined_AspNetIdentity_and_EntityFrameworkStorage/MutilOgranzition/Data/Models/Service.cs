using System;
using System.Collections.Generic;

namespace MutilOgranzition.Data.Models
{
    public partial class Service
    {
        public int Id { get; set; }
        public string IdService { get; set; }
        public string ServiceName { get; set; }
        public bool? ServerDefault { get; set; }
        public bool? Active { get; set; }
    }
}
