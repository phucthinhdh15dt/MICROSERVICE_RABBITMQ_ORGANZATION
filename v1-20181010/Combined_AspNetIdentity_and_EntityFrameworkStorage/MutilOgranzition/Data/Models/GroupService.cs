using System;
using System.Collections.Generic;

namespace MutilOgranzition.Data.Models
{
    public partial class GroupService
    {
        public int Id { get; set; }
        public string IdGroup { get; set; }
        public string IdService { get; set; }
        public DateTime? PaymentDate { get; set; }
    }
}
