using Microsoft.AspNetCore.Mvc;
using Umbraco.Cms.Core.Web;
using Umbraco.Cms.Web.BackOffice.Controllers;
using UmbracoTutorial.Core.UmbracoModels;

namespace UmbracoTutorial.Controllers.Backoffice;

// /umbraco/backoffice/api/ProductListing/GetProducts?number=0
public class ProductListingController:UmbracoAuthorizedApiController
{
    private readonly IUmbracoContextFactory _umbracoContextFactory;

    public ProductListingController(IUmbracoContextFactory umbracoContextFactory)
    {
        _umbracoContextFactory = umbracoContextFactory;
    }

    private record ProductResponse(int id, string name, string imageUrl);
    
    public IActionResult GetProducts(int number)
    {
        var final = new List<ProductResponse>();

        using var cref = _umbracoContextFactory.EnsureUmbracoContext();

        var contentCache = cref.UmbracoContext.Content;

        var products = contentCache
            ?.GetAtRoot()
            ?.FirstOrDefault(x => x.ContentType.Alias == Home.ModelTypeAlias)
            ?.Descendant<Products>()
            ?.Children<Product>()
            ?.Take(number);

        if (products is not null && products.Any())
        {
            final = products.Select(x =>
                    new ProductResponse(x.Id, x?.ProductName ?? x.Name, x?.Photos?.Url() ?? "#"))
                .ToList();
        }

        return Ok(final);
    }
}