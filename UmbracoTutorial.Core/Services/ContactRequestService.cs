using Umbraco.Cms.Infrastructure.Scoping;
using UmbracoTutorial.Core.Models.NPoco;

namespace UmbracoTutorial.Core.Services;

public class ContactRequestService:IContactRequestService
{
    private readonly IScopeProvider _scopeProvider;

    public ContactRequestService(IScopeProvider scopeProvider)
    {
        _scopeProvider = scopeProvider;
    }
    
    public async Task<int> SaveContactRequest(string name, string email, string message)
    {
        var contactRequest = new ContactRequestDBModel()
        {
            Name = name,
            Email = email,
            Message = message
        };

        using var scope = _scopeProvider.CreateScope();

        var result = await scope.Database.InsertAsync<ContactRequestDBModel>(contactRequest);
        scope.Complete();

        return contactRequest.Id;
    }

    public async Task<ContactRequestDBModel?> GetById(int id)
    {
        using var scope = _scopeProvider.CreateScope();

        return await scope.Database.FirstOrDefaultAsync<ContactRequestDBModel>(
            "SELECT * FROM ContactRequest WHERE ID=@0", id);
    }

    public async Task<int> GetTotalNumber()
    {
        using var scope = _scopeProvider.CreateScope(autoComplete: true);

        return await scope.Database.ExecuteScalarAsync<int>("SELECT COUNT(*) FROM ContactRequest");
    }

    public async Task<List<ContactRequestDBModel>> GetAll()
    {
        using var scope = _scopeProvider.CreateScope(autoComplete: true);

        return await scope.Database.FetchAsync<ContactRequestDBModel>("SELECT * FROM ContactRequest");
    }
}