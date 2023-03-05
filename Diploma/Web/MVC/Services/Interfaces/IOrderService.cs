namespace MVC.Services.Interfaces
{
    public interface IOrderService
    {
        Task PlaceOrder(int id, string firstName, string lastName);
    }
}
