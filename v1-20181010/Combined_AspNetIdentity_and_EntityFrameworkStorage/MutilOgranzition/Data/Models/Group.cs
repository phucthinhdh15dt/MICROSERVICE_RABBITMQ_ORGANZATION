using System;
using System.Collections.Generic;

namespace MutilOgranzition.Data.Models
{
    public partial class Group
    {
        public int Id { get; set; }
        public string IdGroup { get; set; }
        public string GroupName { get; set; }
        public string GroupChildren { get; set; }
    }
}
