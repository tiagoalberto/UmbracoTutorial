using UmbracoTutorial.Models.Records;

namespace UmbracoTutorial.ViewModels;

public class ProductListingViewModel
{
    public List<ProductResponseItem> Products { get; set; } = new();
}