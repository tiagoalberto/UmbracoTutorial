using UmbracoTutorial.Models.Records;

namespace UmbracoTutorial.ViewModels;

public class ProductListingBlockListViewModel
{
    public List<ProductResponseItem> Products { get; set; } = new();
}