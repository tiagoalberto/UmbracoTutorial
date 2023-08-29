using Umbraco.Cms.Core.Composing;
using UmbracoTutorial.Routing;

namespace UmbracoTutorial.Composers;

public class ContentPagesComposer:IComposer
{
    public void Compose(IUmbracoBuilder builder)
    {
        builder.ContentFinders().Append<FindContentByOldUrl>();
    }
}