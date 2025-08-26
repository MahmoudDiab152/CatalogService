using Catalog.Application.DTOs;
using Catalog.Core.Specifications;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Catalog.Application.Interfaces
{
    public interface IExternalProductService
    {
        Task<Pagination<ProductDto>> GetProductsAsync(ProductSpecification specification = null!);
    }
}
