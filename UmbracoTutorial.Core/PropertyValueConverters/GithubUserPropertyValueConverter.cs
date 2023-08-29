using System.Text.Json;
using Umbraco.Cms.Core.Models.PublishedContent;
using Umbraco.Cms.Core.PropertyEditors;
using UmbracoTutorial.Core.Models;

namespace UmbracoTutorial.Core.PropertyValueConverters;

public class GithubUserPropertyValueConverter:PropertyValueConverterBase
{
    public override bool IsConverter(IPublishedPropertyType propertyType) =>
        propertyType.EditorAlias.Equals("gitHubUser");

    public override object? ConvertIntermediateToObject(IPublishedElement owner, IPublishedPropertyType propertyType,
        PropertyCacheLevel referenceCacheLevel, object? inter, bool preview)
    {
        if (inter == null)
            return null;

        return JsonSerializer.Deserialize<GithubUserDTO>((string) inter);
    }
}