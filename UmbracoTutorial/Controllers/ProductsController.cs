using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.ViewEngines;
using Umbraco.Cms.Core.Models.PublishedContent;
using Umbraco.Cms.Core.Web;
using Umbraco.Cms.Web.Common.Controllers;
using UmbracoTutorial.Core.UmbracoModels;
using UmbracoTutorial.ViewModels.Umbraco;

namespace UmbracoTutorial.Controllers;

// The same name as docType
// Used ONLY for native Umbraco routing (route hijacking)
public class ProductsController : RenderController
{
    private readonly IPublishedValueFallback _publishedValueFallback;

    public ProductsController(ILogger<RenderController> logger,
        ICompositeViewEngine compositeViewEngine,
        IUmbracoContextAccessor umbracoContextAccessor,
        IPublishedValueFallback publishedValueFallback) : base(logger,
        compositeViewEngine,
        umbracoContextAccessor)
    {
        _publishedValueFallback = publishedValueFallback;
    }

    [HttpGet]
    public IActionResult Index([FromQuery(Name = "maxprice")] decimal? maxPrice)
    {
        var productsPage = (Products)CurrentPage!;

        var allProducts = productsPage.Children<Product>();
        
        if (maxPrice is decimal MaxPrice)
        {
            allProducts = allProducts.Where(x => x.Price <= MaxPrice);
        }

        var vm = new ProductListingViewModel(productsPage, _publishedValueFallback)
        {
            Products = allProducts.ToList()
        };

        return CurrentTemplate(vm);
    }
}