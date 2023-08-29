using Umbraco.Cms.Core;
using Umbraco.Cms.Core.Events;
using Umbraco.Cms.Core.Migrations;
using Umbraco.Cms.Core.Notifications;
using Umbraco.Cms.Core.Scoping;
using Umbraco.Cms.Core.Services;
using Umbraco.Cms.Infrastructure.Migrations;
using Umbraco.Cms.Infrastructure.Migrations.Upgrade;
using UmbracoTutorial.Core.Models.NPoco.Migrations;

namespace UmbracoTutorial.Core.NotificationHandlers;

public class RunContactRequestMigration:INotificationHandler<UmbracoApplicationStartingNotification>
{
    private readonly ICoreScopeProvider _scopeProvider;
    private readonly IMigrationPlanExecutor _migrationPlanExecutor;
    private readonly IKeyValueService _keyValueService;
    private readonly IRuntimeState _runtimeState;

    public RunContactRequestMigration(
        ICoreScopeProvider scopeProvider,
        IMigrationPlanExecutor migrationPlanExecutor,
        IKeyValueService keyValueService,
        IRuntimeState runtimeState
        )
    {
        _scopeProvider = scopeProvider;
        _migrationPlanExecutor = migrationPlanExecutor;
        _keyValueService = keyValueService;
        _runtimeState = runtimeState;
    }
    
    public void Handle(UmbracoApplicationStartingNotification notification)
    {
        if (_runtimeState.Level < RuntimeLevel.Run)
            return;

        var migrationPlan = new MigrationPlan("ContactRequests");

        migrationPlan.From(String.Empty)
            .To<AddContactRequestTable>("contactRequests-db");

        var upgrader = new Upgrader(migrationPlan);

        upgrader.Execute(_migrationPlanExecutor, _scopeProvider, _keyValueService);
    }
}