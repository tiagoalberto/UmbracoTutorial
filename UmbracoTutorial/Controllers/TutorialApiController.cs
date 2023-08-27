using Microsoft.AspNetCore.Mvc;
using Umbraco.Cms.Web.Common.Controllers;

namespace UmbracoTutorial.Controllers;

public class TutorialApiController:UmbracoApiController
{
    // /umbraco/api/tutorialapi/getproducts
    public IActionResult GetProducts()
    {
        var products = new List<SimpleProduct>()
        {
            new SimpleProduct("abd", "Product Title"),
            new SimpleProduct("def", "Product Title 2")
        };

        return Ok(products);
    }

    private record SimpleProduct(string id, string title);
}