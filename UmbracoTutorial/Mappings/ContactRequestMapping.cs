using Umbraco.Cms.Core.Mapping;
using UmbracoTutorial.Core.Models.NPoco;
using UmbracoTutorial.ViewModels.Api;

namespace UmbracoTutorial.Mappings;

public class ContactRequestMapping:IMapDefinition
{
    public void DefineMaps(IUmbracoMapper mapper)
    {
        mapper.Define<ContactRequestDBModel, ContactRequestResponseItem>((source, context) => 
            new ContactRequestResponseItem(), Map);
    }

    private void Map(ContactRequestDBModel source, ContactRequestResponseItem target, MapperContext context)
    {
        target.Id = source.Id;
        target.Name = source.Name;
        target.Email = source.Email;
        target.Message = source.Message;
    }
}