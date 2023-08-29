using Umbraco.Cms.Core.Models;
using Umbraco.Cms.Core.PublishedCache;
using Umbraco.Cms.Core.Strings;

namespace UmbracoTutorial.Routing;

public class ProductPageUrlSegmentProvider:IUrlSegmentProvider
{
    private readonly IUrlSegmentProvider _provider;
    private readonly IPublishedSnapshotAccessor _accessor;

    private readonly string _skuAlias;

    public ProductPageUrlSegmentProvider(IShortStringHelper stringHelper, IPublishedSnapshotAccessor accessor)
    {
        _provider = new DefaultUrlSegmentProvider(stringHelper);
        _accessor = accessor;

        _skuAlias = Core.UmbracoModels.Product.GetModelPropertyType(_accessor, x => x.Sku)!.Alias;
    }
    
    public string? GetUrlSegment(IContentBase content, string? culture = null)
    {
        // Only apply this rule for product pages
        if (content.ContentType.Alias != Core.UmbracoModels.Product.ModelTypeAlias)
        {
            return null;
        }

        var currentSegment = _provider.GetUrlSegment(content, culture);
        var productSku = content.GetValue<string>(_skuAlias)?.ToLower();

        return !string.IsNullOrEmpty(productSku) ? $"{currentSegment}--{productSku}" : currentSegment;

    }
}