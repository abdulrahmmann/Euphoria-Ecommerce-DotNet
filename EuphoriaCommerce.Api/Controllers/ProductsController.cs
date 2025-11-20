using Asp.Versioning;
using EuphoriaCommerce.Application.Caching;
using EuphoriaCommerce.Application.Common;
using EuphoriaCommerce.Application.Features.ProductsFeature.Commands.CreateProduct;
using EuphoriaCommerce.Application.Features.ProductsFeature.Commands.DeleteProduct;
using EuphoriaCommerce.Application.Features.ProductsFeature.Commands.RestoreProduct;
using EuphoriaCommerce.Application.Features.ProductsFeature.Commands.UpdateProduct;
using EuphoriaCommerce.Application.Features.ProductsFeature.DTOs;
using EuphoriaCommerce.Application.Features.ProductsFeature.Queries.GetProducts;
using EuphoriaCommerce.Domain.CQRS;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace Euphoria_ecommerce.Controllers
{
    [Authorize(Policy = "Admin")]
    [Route("api/v1/[controller]")]
    [ApiController]
    [ApiVersion("1.0")]
    public class ProductsController(Dispatcher dispatcher, IRedisCacheService cacheService) : AppControllerBase
    {
        #region HttpGet
        [HttpGet("list")]
        public async Task<IActionResult> GetProducts()
        {
            var cache = cacheService.GetData<BaseResponse<List<ProductDto>>>("products");
            
            if (cache is not null)
            {
                return NewResult(cache);
            }

            var query = new GetProductsQuery();
            var response = await dispatcher.SendQueryAsync<GetProductsQuery, BaseResponse<List<ProductDto>>>(query);
            
            cacheService.SetData("products", response);

            return NewResult(response);
        }
        #endregion
        
        #region HttpPost
        [HttpPost("create")]
        public async Task<IActionResult> CreateProduct([FromBody] CreateProductDto productDto, string? createdBy)
        {
            var command = new CreateProductCommand(productDto, createdBy);
            var response = await dispatcher.SendCommandAsync<CreateProductCommand, BaseResponse<string>>(command);
            return NewResult(response);
        }
        #endregion

        #region HttpPut
        [HttpPut("update/{productId:guid}")]
        public async Task<IActionResult> UpdateProduct([FromBody] UpdateProductDto productDto, Guid productId, string? modifyBy)
        {
            var command = new UpdateProductCommand(productId, productDto, modifyBy);
            var response = await dispatcher.SendCommandAsync<UpdateProductCommand, BaseResponse<string>>(command);
            return NewResult(response);
        }
        
        [HttpPut("restore/{productId:guid}")]
        public async Task<IActionResult> RestoreProduct(Guid productId, string? restoredBy)
        {
            var command = new RestoreProductCommand(productId, restoredBy);
            var response = await dispatcher.SendCommandAsync<RestoreProductCommand, BaseResponse<string>>(command);
            return NewResult(response);
        }
        #endregion
        
        #region HttpDelete
        [HttpDelete("delete/{productId:guid}")]
        public async Task<IActionResult> DeleteProduct(Guid productId, string? deletedBy)
        {
            var command = new DeleteProductCommand(productId, deletedBy);
            var response = await dispatcher.SendCommandAsync<DeleteProductCommand, BaseResponse<string>>(command);
            return NewResult(response);
        }
        #endregion
    }
}
