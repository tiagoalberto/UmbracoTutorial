using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.ViewEngines;
using Umbraco.Cms.Core.Web;
using Umbraco.Cms.Web.Common.Controllers;

namespace UmbracoTutorial.Controllers;

// The same name as docType
// Used ONLY for native Umbraco routing (route hijacking)
public class ProductsController:RenderController
{
    public ProductsController(ILogger<RenderController> logger, ICompositeViewEngine compositeViewEngine, IUmbracoContextAccessor umbracoContextAccessor) : base(logger, compositeViewEngine, umbracoContextAccessor)
    {
    }

    public override IActionResult Index()
    {
        var currentPage = CurrentPage;
        return CurrentTemplate(currentPage);
    }
}