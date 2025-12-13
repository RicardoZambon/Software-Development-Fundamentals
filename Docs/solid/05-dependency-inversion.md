# SOLID — Dependency Inversion Principle (DIP)

> **High-level modules should not depend on low-level modules. Both should depend on abstractions.**
> **Abstractions should not depend on details. Details should depend on abstractions.**

The Dependency Inversion Principle (DIP) is the **capstone of SOLID**. It enables testability, flexibility, and architectural boundaries by reversing traditional dependency direction.

DIP is **not** the same as Dependency Injection. DI is a tool; DIP is a design principle.

---

## What DIP Really Means

Traditional design:

* Business logic depends on infrastructure (databases, APIs, frameworks)

DIP design:

* Business logic depends on **abstractions**
* Infrastructure implements those abstractions

> Policies should not depend on details.

---

## Common Misunderstandings

### ❌ "Using a DI container means I follow DIP"

Wrong. You can use DI and still violate DIP if abstractions live in the wrong layer.

### ❌ "DIP means everything must be an interface"

Wrong. Abstractions can be interfaces **or** abstract classes, applied where change is expected.

### ❌ "DIP is only a backend concern"

Wrong. DIP applies equally to frontend architectures and services.

---

## Identifying DIP Violations (Smells)

Watch for these signs:

* Business logic referencing infrastructure frameworks directly
* Domain services instantiating concrete implementations (`new SqlRepository()`)
* Hard dependencies on external systems in core logic
* Tests that require real infrastructure to run

---

## ❌ Bad Example (DIP Violation)

```csharp
public class OrderService
{
    private readonly SqlOrderRepository _repository;

    public OrderService()
    {
        _repository = new SqlOrderRepository();
    }

    public void PlaceOrder(Order order)
    {
        _repository.Save(order);
    }
}
```

### Why this is a problem

* Business logic depends directly on infrastructure
* Hard to test without a database
* Changing persistence impacts business logic

---

## ✅ Good Example (DIP Applied)

```csharp
public interface IOrderRepository
{
    void Save(Order order);
}
```

```csharp
public class OrderService
{
    private readonly IOrderRepository _repository;

    public OrderService(IOrderRepository repository)
    {
        _repository = repository;
    }

    public void PlaceOrder(Order order)
    {
        _repository.Save(order);
    }
}
```

```csharp
public class SqlOrderRepository : IOrderRepository
{
    public void Save(Order order)
    {
        // SQL persistence logic
    }
}
```

Now:

* Business logic depends on an abstraction
* Infrastructure depends on the abstraction
* Direction of dependency is inverted

---

## DIP vs Dependency Injection (DI)

| DIP                                | DI                              |
| ---------------------------------- | ------------------------------- |
| Design principle                   | Implementation technique        |
| Decides *where* dependencies point | Decides *how* they are provided |
| Framework-agnostic                 | Often framework-based           |

> DI helps implement DIP, but does not guarantee it.

---

## DIP in Practice (Senior Perspective)

### Apply DIP when:

* Business rules must be protected
* Infrastructure may change
* Testability is important

### Avoid overusing DIP when:

* The dependency is stable and unlikely to change
* Abstraction adds indirection without value

> Abstractions should earn their place.

---

## Testing Impact

DIP enables:

* Pure unit tests
* Easy mocking or faking
* Fast feedback loops

```csharp
Should_Save_Order_Without_Database()
```

---

## DIP in Frontend (Angular Example)

### ❌ Bad

A component directly calling `HttpClient` and handling business rules.

### ✅ Better

* Component depends on an abstraction (service)
* Service hides infrastructure details
* Business logic remains testable

---

## Key Takeaways

* DIP protects business logic from infrastructure
* Abstractions define boundaries
* DI is a tool, DIP is the goal

---

## SOLID Recap

* **S**: One reason to change
* **O**: Extend without modifying
* **L**: Safe substitution
* **I**: Small, focused interfaces
* **D**: Depend on abstractions

Together, SOLID enables systems that are easier to understand, test, and evolve.

---

## Next Steps

* Explore concrete code examples: 💻 [Dotnet/solid/](../../Dotnet/solid/)
* Review architecture principles: 📄 [Docs/architecture/](../architecture/)
* Learn testing fundamentals: 📄 [Docs/testing/](../testing/)
