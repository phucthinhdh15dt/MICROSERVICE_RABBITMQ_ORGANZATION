using System;
using System.Collections.Generic;

namespace PlusTechPlusSystem.Data.Models
{
    public partial class Service
    {
        public Service()
        {
            OgranzitionService = new HashSet<OgranzitionService>();
        }

        public int Id { get; set; }
        public string IdService { get; set; }
        public string NameService { get; set; }
        public bool? Status { get; set; }

        public ICollection<OgranzitionService> OgranzitionService { get; set; }
    }
}
