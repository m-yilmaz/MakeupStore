using ApplicationCore.Entities;
using Ardalis.Specification;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ApplicationCore.Specifications
{
    public class ProductsFilterSpecification : Specification<Product>
    {
        public ProductsFilterSpecification(int? brandId, int? categoryId)
        {
            if (brandId.HasValue)
                Query.Where(x => x.BrandId == brandId);
            if (categoryId.HasValue)
                Query.Where(x => x.CategoryId == categoryId);
        }
        public ProductsFilterSpecification(int? brandId, int? categoryId, int skip, int take) : this(brandId, categoryId)
        {
            Query.Skip(skip).Take(take);
        }
    }


}
