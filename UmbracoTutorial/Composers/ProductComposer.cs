using Umbraco.Cms.Core.Composing;
using Umbraco.Cms.Core.Mapping;
using Umbraco.Cms.Web.Common.ApplicationBuilder;
using UmbracoTutorial.Core.Repository;
using UmbracoTutorial.Core.Services;
using UmbracoTutorial.Mappings;
using UmbracoTutorial.Routing;

namespace UmbracoTutorial.Composers;

public class ProductComposer:IComposer
{
    public void Compose(IUmbracoBuilder builder)
    {
        builder.UrlSegmentProviders().Insert<ProductPageUrlSegmentProvider>();
        
        builder.Services.AddScoped<IProductService, ProductService>();

        builder.Services.Configure<UmbracoPipelineOptions>(options =>
        {
            options.AddFilter(new UmbracoPipelineFilter(
                "Product integration",
                appBuilder => {},
                appBuilder => {},
                appBuilder =>
                {
                    appBuilder.UseEndpoints(endpoints =>
                    {
                        endpoints.MapControllerRoute(
                            "Product custom route",
                            "product/{id}",
                            new
                            {
                                Controller = "Product",
                                Action = "Details"
                            }
                        );
                    });
                })
            );
        });
        
        builder.Services.AddScoped<IProductRepository, ProductRepository>();

        builder.WithCollectionBuilder<MapDefinitionCollectionBuilder>()
            .Add<ProductMapping>();
    }
}