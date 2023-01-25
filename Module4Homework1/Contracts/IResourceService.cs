
using Module4Homework1.Models;

namespace Module4Homework1.Contracts
{
    public interface IResourceService
    {
        Task<CollectionData<Resource>> GetListOfResourcesAsync();
        Task<Resource> GetSingleResourceAsync(int id);
    }
}
