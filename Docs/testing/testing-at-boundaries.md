# Testing at Architectural Boundaries

> **Tests should respect the same boundaries as the architecture.**

Testing at architectural boundaries means validating behavior **without breaking encapsulation** or coupling tests to internal implementation details.

Well-designed tests reinforce architecture. Poorly designed tests slowly destroy it.

---

## What Is a Boundary in Testing?

A testing boundary aligns with architectural boundaries such as:

* Modules
* Layers
* Services
* Public APIs

A boundary defines:

* What is visible to tests
* What should be mocked or replaced
* What must remain internal

> If tests need to reach inside a module, the boundary is wrong — or the test is.

---

## Why Testing at Boundaries Matters

Testing at boundaries:

* Preserves encapsulation
* Enables refactoring
* Prevents test brittleness
* Keeps responsibilities clear

Violating boundaries leads to:

* Fragile tests
* Fear of refactoring
* Architecture erosion

---

## Unit Tests and Boundaries

### What Unit Tests Should See

Unit tests should interact with:

* Public methods
* Public interfaces
* Observable behavior

They should **not**:

* Access private methods
* Assert internal state
* Depend on implementation details

---

## ❌ Bad Example — Breaking Boundaries

```csharp
[Test]
public void Validate_Should_Set_Internal_Flag()
{
    var service = new OrderService();

    service.Validate(new Order());

    Assert.IsTrue(service._isValid); // private field
}
```

### Why this is a problem

* Test depends on internal structure
* Refactoring breaks tests
* Boundary is violated

---

## ✅ Good Example — Testing Behavior

```csharp
[Test]
public void PlaceOrder_Should_Throw_When_Total_Is_Invalid()
{
    var repo = Substitute.For<IOrderRepository>();
    var service = new OrderService(repo);

    Assert.Throws<InvalidOperationException>(() =>
        service.PlaceOrder(new Order { Total = 0 })
    );
}
```

---

## Integration Tests and Boundaries

Integration tests validate **contracts between components**.

They should:

* Use real infrastructure when possible
* Interact through public APIs
* Avoid reaching into internals

---

### Example — Repository Integration Test

```csharp
[Test]
public async Task Save_Should_Persist_Order()
{
    var repository = new SqlOrderRepository(_connectionString);
    var order = new Order { Total = 100 };

    await repository.Save(order);

    var saved = await repository.GetById(order.Id);
    Assert.AreEqual(100, saved.Total);
}
```

---

## Contract Tests

Contract tests validate **agreements between modules or services**.

They ensure:

* Inputs and outputs remain stable
* Breaking changes are detected early

Useful when:

* Multiple teams work independently
* APIs are shared

---

## Frontend Perspective (Angular)

### Component Tests

* Test inputs, outputs, and rendered behavior
* Avoid accessing component internals

### Service Tests

* Test public methods
* Mock HTTP or external dependencies

---

## Common Boundary Testing Smells

Watch for:

* Tests accessing private members
* Excessive use of reflection
* Tests that break after refactors
* Tests that mirror implementation structure

> Tests should describe behavior, not structure.

---

## Relationship with Architecture

* **SoC** defines what to test
* **Boundaries & Ownership** define test scope
* **DIP** enables clean mocking
* **Cohesion** keeps tests focused

Good tests reinforce good architecture.

---

## Key Takeaways

* Test at public boundaries
* Avoid leaking internals into tests
* Let architecture guide test design

---

## Next Steps

* Test Data Builders & Fixtures
* Async and Time-Based Testing
* Contract Testing in Practice
