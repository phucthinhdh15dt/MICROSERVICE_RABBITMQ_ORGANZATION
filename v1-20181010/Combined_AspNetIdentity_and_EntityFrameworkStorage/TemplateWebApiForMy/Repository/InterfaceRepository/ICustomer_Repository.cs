using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TemplateWebApiForMy.Data.Models;
using TemplateWebApiForMy.Data.ModelsProduct;

namespace TemplateWebApiForMy.Repository.InterfaceRepository
{
    public interface ICustomer_Repository
    {
         IEnumerable<Customer> get(Dictionary<string,string> condition);
        IEnumerable<Customer> getAll();
        IEnumerable<Product> getAllPro();
    }
}
