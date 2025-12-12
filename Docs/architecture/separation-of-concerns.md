# Architecture — Separation of Concerns (SoC)

> **Each part of the system should focus on a single concern and nothing more.**

Separation of Concerns (SoC) is an architectural principle that underpins maintainable systems. It reduces coupling, improves clarity, and allows teams to evolve different parts of the system independently.

SoC is not about adding layers for the sake of layers. It is about **clear ownership of responsibilities**.

---

## What Is a "Concern"?

A concern is a **distinct responsibility or reason to change**.

Common concerns in modern applications:

* Presentation (UI)
* Application orchestration
* Domain / business rules
* Persistence
* External integrations
* Cross-cutting concerns (logging, metrics, security)

> When a change touches multiple unrelated concerns, SoC is likely violated.

---

## Why Separation of Concerns Matters

Proper SoC enables:

* Independent evolution of features
* Easier testing (unit vs integration)
* Safer refactoring
* Clear mental models for developers

Poor SoC leads to:

* God classes and god services
* Ripple effects from small changes
* Hard-to-test code
* Fear-driven development ("don’t touch that")

---

## Common Misunderstandings

### ❌ "SoC means many layers"

Wrong. Layers are a tool, not the goal.

### ❌ "SoC requires a strict architecture"

Wrong. SoC can exist in simple systems with minimal structure.

### ❌ "Framework boundaries are concerns"

Wrong. Frameworks support concerns; they are not concerns themselves.

---

## Identifying SoC Violations (Smells)

Watch for these signs:

* Controllers with business logic
* Services performing persistence and formatting
* UI components making complex decisions
* Classes with many unrelated dependencies

---

## ❌ Bad Example — Mixed Concerns

```csharp
public class OrderController
{
    public IActionResult Create(OrderDto dto)
    {
        if (dto.Total <= 0)
            return BadRequest("Invalid total");

        var entity = new Order
        {
            Total = dto.Total,
            CreatedAt = DateTime.UtcNow
        };

        using var connection = new SqlConnection("connection-string");
        connection.Execute("INSERT INTO Orders ...", entity);

        _logger.LogInformation("Order created");

        return Ok();
    }
}
```

### Why this is a problem

* UI, business rules, persistence, and logging are mixed
* Hard to test without infrastructure
* Any change risks multiple concerns

---

## ✅ Good Example — Separated Concerns

```csharp
// Controller (Presentation)
public class OrderController
{
    private readonly IOrderService _orderService;

    public OrderController(IOrderService orderService)
    {
        _orderService = orderService;
    }

    public IActionResult Create(OrderDto dto)
    {
        _orderService.Create(dto);
        return Ok();
    }
}
```

```csharp
// Application Service (Orchestration)
public class OrderService : IOrderService
{
    private readonly IOrderRepository _repository;

    public OrderService(IOrderRepository repository)
    {
        _repository = repository;
    }

    public void Create(OrderDto dto)
    {
        if (dto.Total <= 0)
            throw new InvalidOperationException("Invalid total");

        var order = new Order(dto.Total);
        _repository.Save(order);
    }
}
```

```csharp
// Repository (Persistence)
public class SqlOrderRepository : IOrderRepository
{
    public void Save(Order order)
    {
        // SQL persistence logic
    }
}
```

---

## SoC and Testing

SoC enables:

* Unit tests for business rules
* Integration tests for persistence
* Minimal mocking

Each test targets **one concern at a time**.

---

## SoC in Frontend (Angular Perspective)

### ❌ Bad

A component that:

* Fetches data
* Applies business rules
* Formats values
* Manages UI state

### ✅ Better

* Component → rendering and user interaction
* Service → data access and orchestration
* Pipe / helper → formatting

---

## Relationship with Other Principles

* **SRP** applies SoC at the class level
* **DRY** prevents duplicated concerns
* **KISS** avoids unnecessary architectural complexity
* **DIP** enforces correct dependency direction

SoC is the **macro-level expression** of these principles.

---

## Key Takeaways

* Separate by responsibility, not by framework
* Changes should affect one concern at a time
* SoC enables safe evolution and clarity

---

## Next Steps

* Layered vs Modular Architecture
* High Cohesion & Low Coupling
* Boundaries and Ownership
