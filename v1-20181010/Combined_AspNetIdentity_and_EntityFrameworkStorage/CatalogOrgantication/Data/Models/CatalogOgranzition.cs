using System;
using System.Collections.Generic;

namespace CatalogOrgantication.Data.Models
{
    public partial class CatalogOgranzition
    {
        public int Id { get; set; }
        public string IdOgranzition { get; set; }
        public string NameOgranzition { get; set; }
        public bool? Status { get; set; }
    }
}
