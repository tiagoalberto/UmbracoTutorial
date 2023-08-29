using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;
using Microsoft.AspNetCore.Mvc.ViewEngines;
using Umbraco.Cms.Core.Models.PublishedContent;
using Umbraco.Cms.Core.Web;
using Umbraco.Cms.Web.Common.Controllers;
using UmbracoTutorial.Core.Services;
using UmbracoTutorial.ViewModels;

namespace UmbracoTutorial.Controllers;

// used for custom Routing
public class ProductController:UmbracoPageController,IVirtualPageController
{
    private readonly IProductService _productService;
    private readonly IUmbracoContextAccessor _umbracoContextAccessor;

    public ProductController(ILogger<UmbracoPageController> logger,
        ICompositeViewEngine compositeViewEngine,
        IProductService productService,
        IUmbracoContextAccessor umbracoContextAccessor) : base(logger,
        compositeViewEngine)
    {
        _productService = productService;
        _umbracoContextAccessor = umbracoContextAccessor;
    }

    public IActionResult Details(int id)
    {
        var product = _productService.GetAll().FirstOrDefault(p => p.Id == id);

        if (product == null || CurrentPage == null)
            return NotFound();

        var vm = new ProductViewModel(CurrentPage)
        {
            ProductName = product.Name
        };
        
        return View(vm);
    }

    public IPublishedContent? FindContent(ActionExecutingContext actionExecutingContext)
    {
        var homepage = _umbracoContextAccessor.GetRequiredUmbracoContext()?
            .Content?.GetAtRoot().FirstOrDefault();

        var productListingPage = homepage?.FirstChildOfType("products");

        return productListingPage ?? homepage;
    }
}