using UmbracoTutorial.Core.Models;

namespace UmbracoTutorial.Core;

public interface IProductService
{
    List<ProductDTO> GetAll();
}