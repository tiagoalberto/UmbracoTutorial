using UmbracoTutorial.Core.Models;
using UmbracoTutorial.Models.Records;

namespace UmbracoTutorial.Core;

public interface IProductService
{
    List<ProductDTO> GetAll();
    List<ProductResponseItem> GetUmbracoProducts(int number);
}