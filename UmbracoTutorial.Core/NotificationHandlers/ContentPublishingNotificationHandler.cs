using Microsoft.Extensions.Logging;
using Umbraco.Cms.Core.Events;
using Umbraco.Cms.Core.Notifications;

namespace UmbracoTutorial.Core.NotificationHandlers;

public class ContentPublishingNotificationHandler:INotificationHandler<ContentPublishingNotification>
{
    private readonly ILogger<ContentPublishingNotificationHandler> _logger;

    public ContentPublishingNotificationHandler(ILogger<ContentPublishingNotificationHandler> logger)
    {
        _logger = logger;
    }
    
    public void Handle(ContentPublishingNotification notification)
    {
        var publishingEntities = notification.PublishedEntities;

        foreach (var entity in publishingEntities)
        {
            _logger.LogInformation("Publishing node with id: {nodeId}", entity.Id);
        }
    }
}