# Architecture — High Cohesion & Low Coupling

> **High cohesion keeps related things together. Low coupling keeps unrelated things apart.**

High Cohesion and Low Coupling are two sides of the same architectural goal: **systems that are easy to understand, change, and test**.

They are not abstract ideals — they are practical lenses for evaluating code, modules, and entire systems.

---

## Cohesion — How Well Things Belong Together

Cohesion measures how **closely related the responsibilities inside a module are**.

A highly cohesive module:

* Has a clear purpose
* Contains related behavior and data
* Changes for one primary reason

A low cohesive module:

* Does many unrelated things
* Mixes responsibilities
* Changes frequently for different reasons

> High cohesion makes code easier to reason about.

---

## Types of Cohesion (Practical View)

From weakest to strongest:

* **Coincidental** — unrelated things grouped together
* **Logical** — similar actions, different reasons (e.g., `Utils`)
* **Temporal** — things that happen at the same time (startup code)
* **Sequential** — output of one step feeds the next
* **Functional** — everything contributes to one clear task

Aim for **functional cohesion** whenever possible.

---

## Coupling — How Much Things Know About Each Other

Coupling measures how **dependent modules are on each other**.

Low coupling means:

* Modules interact through clear contracts
* Changes in one module rarely affect others
* Dependencies are explicit and minimal

High coupling means:

* Modules know internal details of others
* Small changes cause ripple effects
* Refactoring is risky

> Low coupling enables safe evolution.

---

## Common Coupling Smells

Watch for:

* Direct access to internal state of other modules
* Shared mutable state
* Static/global dependencies
* Large constructors with many unrelated dependencies

---

## ❌ Bad Example — Low Cohesion, High Coupling

```csharp
public class OrderManager
{
    public void CreateOrder(OrderDto dto)
    {
        Validate(dto);
        SaveToDatabase(dto);
        SendEmail(dto);
        GenerateReport(dto);
        UpdateDashboard(dto);
    }

    private void Validate(OrderDto dto) { }
    private void SaveToDatabase(OrderDto dto) { }
    private void SendEmail(OrderDto dto) { }
    private void GenerateReport(OrderDto dto) { }
    private void UpdateDashboard(OrderDto dto) { }
}
```

### Why this is a problem

* Many unrelated responsibilities
* High risk of change
* Tight coupling to infrastructure and UI concerns

---

## ✅ Good Example — High Cohesion, Low Coupling

```csharp
public class OrderService
{
    private readonly IOrderRepository _repository;

    public OrderService(IOrderRepository repository)
    {
        _repository = repository;
    }

    public void CreateOrder(Order order)
    {
        // Business rules only
        _repository.Save(order);
    }
}
```

```csharp
public class OrderNotificationService
{
    public void Notify(Order order)
    {
        // Notification responsibility only
    }
}
```

Each class:

* Has a single, clear purpose
* Depends only on what it needs

---

## Cohesion & Coupling in Practice (Senior Perspective)

### Increase cohesion by:

* Grouping related behavior
* Eliminating "utility" classes
* Aligning modules with business concepts

### Reduce coupling by:

* Depending on abstractions
* Avoiding shared mutable state
* Making dependencies explicit

> If a change requires touching many modules, coupling is too high.

---

## Frontend Perspective (Angular)

### ❌ Bad

A component that:

* Fetches data
* Applies business rules
* Formats values
* Manages UI state

### ✅ Better

* Component → rendering & interaction
* Service → data & orchestration
* Pipe → formatting

High cohesion in components leads to easier reuse and testing.

---

## Relationship with Other Principles

* **SRP** drives cohesion at class level
* **SoC** drives cohesion at architectural level
* **DIP** reduces coupling
* **KISS** prevents accidental coupling

---

## Key Takeaways

* High cohesion improves clarity
* Low coupling improves safety
* Both are required for maintainable systems

---

## Next Steps

* Layered vs Modular Architecture
* Defining Module Boundaries
* Managing Dependencies Over Time
