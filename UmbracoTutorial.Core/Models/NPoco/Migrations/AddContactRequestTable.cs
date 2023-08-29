using Microsoft.Extensions.Logging;
using Umbraco.Cms.Infrastructure.Migrations;

namespace UmbracoTutorial.Core.Models.NPoco.Migrations;

public class AddContactRequestTable:MigrationBase
{
    public AddContactRequestTable(IMigrationContext context) : base(context)
    {
    }

    protected override void Migrate()
    {
        if (!TableExists("ContactRequest"))
        {
            Create.Table<ContactRequestDBModel>().Do();
            
            Logger.LogDebug("Database table {DbTable} migrated successfully", "ContactRequest");
        }
    }
}