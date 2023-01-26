using Module5Homework1.Models;

namespace Module5Homework1.Contracts
{
    public interface IUserService
    {
        Task<CollectionData<User>> GetListOfUsersByPageAsync(int page);
        Task<CollectionData<User>> GetListOfUsersByDelayAsync(int delay);
        Task<User> GetSingleUserAsync(int id);
        Task<Employee> CreateUserAsync(string name, string job);
        Task<Employee> UpdateUserAsync(int id ,string name, string job);
        Task<VoidResult> DeleteUserAsync(int id);
    }
}
