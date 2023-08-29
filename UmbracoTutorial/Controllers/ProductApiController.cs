using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.AspNetCore.Mvc;
using OpenIddict.Validation.AspNetCore;
using Umbraco.Cms.Core.Mapping;
using Umbraco.Cms.Web.Common.Controllers;
using UmbracoTutorial.Core.Models.Records;
using UmbracoTutorial.Core.Repository;
using UmbracoTutorial.Core.UmbracoModels;
using UmbracoTutorial.ViewModels.Api;

namespace UmbracoTutorial.Controllers;

// /umbraco/api/productapi/{action} => Default route
[Route("api/products")]
[Authorize(AuthenticationSchemes = OpenIddictValidationAspNetCoreDefaults.AuthenticationScheme)]
public class ProductApiController:UmbracoApiController
{
    private readonly IProductRepository _productRepository;
    private readonly IUmbracoMapper _umbracoMapper;

    public ProductApiController(IProductRepository productRepository, IUmbracoMapper umbracoMapper)
    {
        _productRepository = productRepository;
        _umbracoMapper = umbracoMapper;
    }

    public record ProductReadRequest(string? productSKU, decimal? maxPrice);
    
    [HttpGet]
    public IActionResult Read([FromQuery] ProductReadRequest request)
    {
        var mapped = _umbracoMapper
            .MapEnumerable<Product, ProductApiResponseItem>(
                _productRepository.GetProducts(request.productSKU, request.maxPrice)
                );
        return Ok(mapped);
    }

    [HttpPost]
    public IActionResult Create([FromBody] ProductCreationItem request)
    {
        if (!ModelState.IsValid)
            return BadRequest(ModelState);

        var product = _productRepository.Create(request);

        return product == null ? 
            StatusCode(StatusCodes.Status500InternalServerError, "Error creating product") : 
            Ok(_umbracoMapper.Map<Product, ProductApiResponseItem>(product));
    }
    
    [HttpPut("{id:int}")]
    public IActionResult Update(int id, [FromBody] ProductUpdateItem request)
    {
        if (!ModelState.IsValid)
            return BadRequest(ModelState);

        if (_productRepository.Get(id) == null)
            return NotFound();

        var product = _productRepository.Update(id, request);
        
        return Ok(_umbracoMapper.Map<Product, ProductApiResponseItem>(product));
    }
    
    [HttpDelete("{id:int}")]
    public IActionResult Delete(int id)
    {
        if (_productRepository.Get(id) == null)
            return NotFound();
        
        var result = _productRepository.Delete(id);
        return result ? Ok() : StatusCode(StatusCodes.Status500InternalServerError,
            $"Error deleting product with id {id}");
    }
}