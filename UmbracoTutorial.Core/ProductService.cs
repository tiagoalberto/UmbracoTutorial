using UmbracoTutorial.Core.Models;

namespace UmbracoTutorial.Core;

public class ProductService:IProductService
{
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
}