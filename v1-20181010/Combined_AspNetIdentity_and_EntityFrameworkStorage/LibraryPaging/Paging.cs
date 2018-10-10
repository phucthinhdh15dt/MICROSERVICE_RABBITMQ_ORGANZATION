using System;
using System.Collections.Generic;

namespace LibraryPaging
{
    public class Paging
    {
        //    public IEnumerable<Object> PaginationGeneral(int sizePagination, int nowPagination, bool dest, string filter, ProductOderDemoContext db)
        //    {
        //    //    List<Object> listProduct = new List<Object>();
        //    //    ProductOderDemoContext categoriesContext = db;


        //    //    using (categoriesContext = new ProductOderDemoContext())
        //    //    {

        //    //        int totalRecords = categoriesContext.Product.Count();
        //    //        int skipRow = (nowPagination - 1) * sizePagination;
        //    //        if (dest)
        //    //        {
        //    //            listProduct = categoriesContext.RefProductCategories
        //    //            .Skip(skipRow).Take(sizePagination)
        //    //            .ToList();
        //    //        }
        //    //        if (filter != null && filter != "")
        //    //        {

        //    //            if (sizePagination != 0 && nowPagination != 0)
        //    //            {
        //    //                if (!filter.Equals("") || filter != null)
        //    //                {
        //    //                    if (filter.Equals("ALL"))
        //    //                    {
        //    //                        return categoriesContext.RefProductCategories
        //    //                                .Skip(skipRow).Take(sizePagination)
        //    //                                .ToList();
        //    //                    }
        //    //                    else
        //    //                    {
        //    //                        return categoriesContext.RefProductCategories
        //    //                                .Where(p => p.ProductCategoryCode.Contains(filter) || p.ProductCategoryDescription.Contains(filter)


        //    //                                )
        //    //                                .Skip(skipRow).Take(sizePagination)
        //    //                                .ToList();
        //    //                    }
        //    //                }



        //    //            }
        //    //            if (sizePagination == 0 && nowPagination == 0 && filter.Equals("ALL"))
        //    //            {
        //    //                return categoriesContext.RefProductCategories.ToList();
        //    //            }
        //    //            else
        //    //            {
        //    //                return new List<Object>();
        //    //            }

        //    //        }

        //    //    }
        //    //    return listProduct;
        //    //}

        //}
    }
}
