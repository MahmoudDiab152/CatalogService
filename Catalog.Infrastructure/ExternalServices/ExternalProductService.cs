using Catalog.Application.DTOs;
using Catalog.Application.Interfaces;
using Catalog.Core.Specifications;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;

namespace Catalog.Infrastructure.ExternalServices
{
    public class ExternalProductService : IExternalProductService
    {
        private readonly HttpClient _httpClient;

        public ExternalProductService(HttpClient httpClient)
        {
            this._httpClient = httpClient;
        }

        public async Task<Pagination<ProductDto>> GetProductsAsync(ProductSpecification specifications = null!)
        {
            var response = await _httpClient.GetAsync("products");

            if (!response.IsSuccessStatusCode)
                return new Pagination<ProductDto>(specifications.PageIndex, specifications.PageSize, 0, new List<ProductDto>());

            var responseContent = await response.Content.ReadAsStringAsync();

            var products = JsonSerializer.Deserialize<List<ProductDto>>(responseContent, new JsonSerializerOptions
            {
                PropertyNameCaseInsensitive = true
            });
            if(!products.Any())
                return new Pagination<ProductDto>(specifications.PageIndex, specifications.PageSize, 0, new List<ProductDto>());

            if (!string.IsNullOrEmpty(specifications.Search))
            {
                products = products
                    .Where(p => p.Title.Contains(specifications.Search, StringComparison.OrdinalIgnoreCase))
                    .ToList();
            }
            if(!string.IsNullOrEmpty(specifications.Sort))
            products = specifications.Sort switch
            {
                ProductSort.PriceAsc => products.OrderBy(p => p.Price).ToList(),
                ProductSort.PriceDesc => products.OrderByDescending(p => p.Price).ToList(),
                ProductSort.TitleAsc => products.OrderBy(p => p.Title).ToList(),
                ProductSort.TitleDesc => products.OrderByDescending(p => p.Title).ToList(),
                _ => products
            };

            var count = products.Count;
            var data = products
                .Skip((specifications.PageIndex - 1) * specifications.PageSize)
                .Take(specifications.PageSize)
                .ToList();

            return new Pagination<ProductDto>(specifications.PageIndex, specifications.PageSize, count, data);

        }
    }

  
}
