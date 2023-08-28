using Umbraco.Cms.Core.Composing;
using Umbraco.Cms.Web.Common.ApplicationBuilder;
using UmbracoTutorial.Core;

namespace UmbracoTutorial.Composers;

public class ProductComposer:IComposer
{
    public void Compose(IUmbracoBuilder builder)
    {
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
    }
}