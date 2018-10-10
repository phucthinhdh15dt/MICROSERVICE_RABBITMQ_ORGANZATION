using System;
using System.Collections.Generic;

namespace PlusTechPlusSystem.Data.Models
{
    public partial class Ogranzition
    {
        public Ogranzition()
        {
            OgranzitionService = new HashSet<OgranzitionService>();
            ProfileSystem = new HashSet<ProfileSystem>();
        }

        public int Id { get; set; }
        public string IdOgranzition { get; set; }
        public string NameOgranzition { get; set; }

        public ICollection<OgranzitionService> OgranzitionService { get; set; }
        public ICollection<ProfileSystem> ProfileSystem { get; set; }
    }
}
