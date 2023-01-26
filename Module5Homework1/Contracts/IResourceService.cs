using Module5Homework1.Models;

namespace Module5Homework1.Contracts
{
    public interface IResourceService
    {
        Task<CollectionData<Resource>> GetListOfResourcesAsync();
        Task<Resource> GetSingleResourceAsync(int id);
    }
}
