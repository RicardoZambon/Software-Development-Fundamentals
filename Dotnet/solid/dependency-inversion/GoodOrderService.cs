// ✅ GOOD EXAMPLE — Dependency Inversion Principle Applied
// High-level business logic depends on abstractions, not infrastructure details.

#region Domain

public class Order
{
    public int Id { get; set; }
    public decimal Total { get; set; }
}

#endregion

#region Abstractions (Owned by the domain / application layer)

public interface IOrderRepository
{
    void Save(Order order);
}

#endregion

#region Application Service (High-level policy)

public class OrderService
{
    private readonly IOrderRepository _repository;

    public OrderService(IOrderRepository repository)
    {
        _repository = repository;
    }

    public void PlaceOrder(Order order)
    {
        // Business rules would live here
        _repository.Save(order);
    }
}

#endregion

#region Infrastructure (Low-level details)

public class SqlOrderRepository : IOrderRepository
{
    public void Save(Order order)
    {
        // Simulated SQL persistence
        Console.WriteLine("Saving order to SQL Server");
    }
}

#endregion

// Benefits:
// - Business logic depends only on abstractions
// - Infrastructure can change without impacting domain logic
// - Easy to unit test using mocks or fakes
// - Proper architectural boundaries are enforced
// - DI is a consequence, not the goal
