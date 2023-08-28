using Microsoft.AspNetCore.Mvc;
using UmbracoTutorial.Core;
using UmbracoTutorial.ViewModels;

namespace UmbracoTutorial.ViewComponents;

public class ProductListingViewComponent:ViewComponent
{
    private readonly IProductService _productService;

    public ProductListingViewComponent(IProductService productService)
    {
        _productService = productService;
    }
    
    public IViewComponentResult Invoke(int number)
    {
        var vm = new ProductListingViewModel()
        {
            Products = _productService.GetUmbracoProducts(number)
        };

        return View(vm);
    }
}