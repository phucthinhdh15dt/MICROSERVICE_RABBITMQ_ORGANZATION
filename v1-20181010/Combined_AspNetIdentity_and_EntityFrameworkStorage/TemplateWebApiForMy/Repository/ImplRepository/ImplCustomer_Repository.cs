using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TemplateWebApiForMy.Data.Models;
using TemplateWebApiForMy.Data.ModelsProduct;
using TemplateWebApiForMy.Repository.InterfaceRepository;

namespace TemplateWebApiForMy.Repository.ImplRepository
{
    public class ImplCustomer_Repository : ICustomer_Repository
    {
        demoTemplateContext context = new demoTemplateContext();
        ModelsProductContext contextProduct = new ModelsProductContext();

        //"getAll","filter","paging","sortby","single"
        //+getall->sortby
        //filter -sortby
        //paging->sortbyc



        public IEnumerable<Customer> get(Dictionary<string, string> condition)
        {
            //if ((condition["getAll"] != null && condition["getAll"] != "") condition["getAll"])
            //{

            //}
            throw new NotImplementedException();
        }
        public IEnumerable<Customer> getAll()
        {
            return context.Customer.ToList();
        }
        public IEnumerable<Product> getAllPro()
        {
            return contextProduct.Product.ToList();
        }
    }
}
