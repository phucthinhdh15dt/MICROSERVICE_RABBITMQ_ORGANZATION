using System;
using System.Collections.Generic;

namespace TemplateWebApiForMy.Data.ModelsProduct
{
    public partial class Product
    {
        public int Id { get; set; }
        public string IdProduct { get; set; }
        public string Name { get; set; }
        public decimal? Price { get; set; }
    }
}
