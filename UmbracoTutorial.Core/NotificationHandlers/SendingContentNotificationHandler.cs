using Umbraco.Cms.Core.Events;
using Umbraco.Cms.Core.Models.ContentEditing;
using Umbraco.Cms.Core.Notifications;
using Umbraco.Cms.Core.Security;
using Umbraco.Extensions;
using UmbracoTutorial.Core.UmbracoModels;

namespace UmbracoTutorial.Core.NotificationHandlers;

public class SendingContentNotificationHandler:INotificationHandler<SendingContentNotification>
{
    private readonly IBackOfficeSecurityAccessor _securityAccessor;

    public SendingContentNotificationHandler(IBackOfficeSecurityAccessor securityAccessor)
    {
        _securityAccessor = securityAccessor;
    }
    
    public void Handle(SendingContentNotification notification)
    {
        var currentUser = _securityAccessor.BackOfficeSecurity.CurrentUser;
        if (!currentUser.Groups.Any(x => x.Alias == Umbraco.Cms.Core.Constants.Security.AdminGroupAlias))
        {
            // Umbraco Actions
            // update/save  A
            // publish      U
            // unpublish    Z
            // create       C   
            
            var actionsToRemove = new List<string>{"Z", "A"};
            
            notification.Content.AllowedActions =
                notification.Content.AllowedActions.Where(x => !actionsToRemove.Contains(x));
            notification.Content.AllowPreview = false;
        }
        
        SetDefaultValueForPublicationDate(notification);
    }

    private void SetDefaultValueForPublicationDate(SendingContentNotification notification)
    {
        if(notification.Content.ContentTypeAlias != Blogpost.ModelTypeAlias)
            return;

        foreach (var variant in notification.Content.Variants)
        {
            var publishedDateProperty = variant.Tabs.SelectMany(f => f.Properties)
                .FirstOrDefault(f => f.Alias.InvariantEquals("publicationDate"));
            
            if(variant.State != ContentSavedState.NotCreated)
                return;

            if (publishedDateProperty != null)
            {
                publishedDateProperty.Value = DateTime.Now;
            }
        }
    }
}