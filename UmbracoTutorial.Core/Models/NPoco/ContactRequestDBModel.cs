using NPoco;
using Umbraco.Cms.Infrastructure.Persistence.DatabaseAnnotations;

namespace UmbracoTutorial.Core.Models.NPoco;

[TableName("ContactRequest")]
[PrimaryKey("Id", AutoIncrement = true)]
[ExplicitColumns]
public class ContactRequestDBModel
{
    [PrimaryKeyColumn(AutoIncrement = true, IdentitySeed = 1)]
    [Column("Id")]
    public int Id { get; set; }
    
    [Column("Name")]
    public string Name { get; set; }
    
    [Column("Email")]
    public string Email { get; set; }
    
    [Column("Message")]
    [SpecialDbType(SpecialDbTypes.NVARCHARMAX)]
    public string Message { get; set; }
}