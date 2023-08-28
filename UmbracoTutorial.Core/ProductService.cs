using Umbraco.Cms.Core.Web;
using Umbraco.Extensions;
using UmbracoTutorial.Core.Models;
using UmbracoTutorial.Core.UmbracoModels;
using UmbracoTutorial.Models.Records;

namespace UmbracoTutorial.Core;

public class ProductService:IProductService
{
    private readonly IUmbracoContextFactory _umbracoContextFactory;

    public ProductService(IUmbracoContextFactory umbracoContextFactory)
    {
        _umbracoContextFactory = umbracoContextFactory;
    }
    public List<ProductDTO> GetAll()
    {
        return new List<ProductDTO>()
        {
            new ProductDTO(1, "Product name 1"),
            new ProductDTO(2, "Product name 2"),
            new ProductDTO(3, "Product name 3"),
            new ProductDTO(4, "Product name 4"),
            new ProductDTO(5, "Product name 5"),
        };
    }

    public List<ProductResponseItem> GetUmbracoProducts(int number)
    {
        var final = new List<ProductResponseItem>();

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
                    new ProductResponseItem(x.Id, x?.ProductName ?? x.Name, x?.Photos?.Url() ?? "#"))
                .ToList();
        }

        return final;
    }
}