using Asp.Versioning;
using Catalog.Application.DTOs;
using Catalog.Application.Interfaces;
using Catalog.Core.Specifications;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Net;

namespace Catalog.API.Controllers
{
    [ApiController]
    public class ProductsController : BaseApiController
    {
        private readonly IExternalProductService _externalProductService;

        public ProductsController(IExternalProductService externalProductService)
        {
            this._externalProductService = externalProductService;
        }
        /// <summary>
        /// Sorting options: "priceAsc", "priceDesc", "titleAsc", "titleDesc"
        /// </summary>
        /// <returns></returns>
        [HttpGet]
        [Route("[action]", Name = "GetAllProducts")]
        [ProducesResponseType(typeof(Pagination<ProductDto>), StatusCodes.Status200OK)]
        public async Task<ActionResult<Pagination<ProductDto>>> GetAllProducts([FromQuery] ProductSpecification specifications)
        {
            var products = await _externalProductService.GetProductsAsync(specifications);
            return Ok(products);

        }
    }
}
