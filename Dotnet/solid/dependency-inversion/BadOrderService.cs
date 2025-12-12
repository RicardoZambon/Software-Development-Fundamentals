// ❌ BAD EXAMPLE — Dependency Inversion Principle Violation
// High-level business logic depends directly on low-level infrastructure details.

#region Domain

public class Order
{
    public int Id { get; set; }
    public decimal Total { get; set; }
}

#endregion

#region Infrastructure (Low-level)

public class SqlOrderRepository
{
    public void Save(Order order)
    {
        // Simulated SQL persistence
        Console.WriteLine("Saving order to SQL Server");
    }
}

#endregion

#region Application Service

public class OrderService
{
    private readonly SqlOrderRepository _repository;

    public OrderService()
    {
        // ❌ Direct dependency on infrastructure
        _repository = new SqlOrderRepository();
    }

    public void PlaceOrder(Order order)
    {
        // Business rules would live here
        _repository.Save(order);
    }
}

#endregion

// Problems:
// - Business logic depends on concrete infrastructure
// - Impossible to test without database concerns
// - Changing persistence forces changes in business code
// - Violates architectural boundaries
