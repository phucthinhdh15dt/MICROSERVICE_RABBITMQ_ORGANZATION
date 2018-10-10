using System;
using System.Collections.Generic;

namespace PlusTechPlusSystem.Data.Models
{
    public partial class OgranzitionService
    {
        public int Id { get; set; }
        public string IdOgranzition { get; set; }
        public string IdService { get; set; }
        public DateTime? PaymentDate { get; set; }
        public DateTime? EffectiveDate { get; set; }
        public DateTime? ExpireDate { get; set; }
        public int? LincenseAmount { get; set; }
        public int? LicenseAvailable { get; set; }

        public Ogranzition IdOgranzitionNavigation { get; set; }
        public Service IdServiceNavigation { get; set; }
    }
}
