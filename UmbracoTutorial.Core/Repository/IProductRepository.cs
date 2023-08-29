using UmbracoTutorial.Core.Models.Records;
using UmbracoTutorial.Core.UmbracoModels;

namespace UmbracoTutorial.Core.Repository;

public interface IProductRepository
{
    List<Product> GetProducts(string? productSKU, decimal? maxPrice);
    Product Get(int id);
    bool Delete(int id);

    Product Create(ProductCreationItem product);
    Product Update(int id, ProductUpdateItem product);
}