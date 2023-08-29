using Umbraco.Cms.Core.Notifications;
using UmbracoTutorial.Core.NotificationHandlers;

namespace UmbracoTutorial.Extensions;

public static class UmbracoBuilderExtensions
{
    public static IUmbracoBuilder AddContactRequestTable(this IUmbracoBuilder builder)
    {
        builder.AddNotificationHandler<UmbracoApplicationStartingNotification, RunContactRequestMigration>();
        return builder;
    }
}