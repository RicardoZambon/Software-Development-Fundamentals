# Testing Fundamentals — Building Confidence in Software

> **Tests are not about catching bugs. They are about enabling change.**

Testing is a fundamental part of professional software development. Well-designed tests provide confidence to refactor, evolve architecture, and onboard new team members safely.

Poorly designed tests, however, slow teams down and become a maintenance burden.

This section focuses on **practical testing principles**, not testing dogma.

---

## Why We Test

The primary goals of tests are:

* Validate business behavior
* Protect against regressions
* Enable safe refactoring
* Document expected behavior

> If tests make change harder, they are failing their purpose.

---

## The Testing Pyramid (Practical View)

A healthy test suite is **unbalanced on purpose**:

* **Unit Tests** — many, fast, isolated
* **Integration Tests** — fewer, realistic
* **End-to-End Tests** — very few, critical paths only

> The higher the test level, the higher the cost.

---

## Unit Tests

### What Unit Tests Should Test

Unit tests should verify:

* Business rules
* Pure logic
* Decision-making
* Edge cases

They should **not** test:

* Framework behavior
* Infrastructure details
* Configuration

---

### Unit Test Characteristics

Good unit tests are:

* Fast
* Deterministic
* Isolated
* Easy to read

A good test name explains behavior:

```text
Should_Apply_Discount_When_Customer_Is_Premium
```

---

## ❌ Bad Example — Testing Implementation Details

```csharp
[Test]
public void Save_Should_Call_Repository_Save_Once()
{
    var repo = Substitute.For<IOrderRepository>();
    var service = new OrderService(repo);

    service.PlaceOrder(new Order());

    repo.Received(1).Save(Arg.Any<Order>());
}
```

### Why this is a problem

* Tests *how* the code works, not *what* it does
* Refactoring breaks tests unnecessarily
* Encourages brittle designs

---

## ✅ Good Example — Testing Behavior

```csharp
[Test]
public void PlaceOrder_Should_Save_Valid_Order()
{
    var repo = Substitute.For<IOrderRepository>();
    var service = new OrderService(repo);

    service.PlaceOrder(new Order { Total = 100 });

    repo.Received().Save(Arg.Is<Order>(o => o.Total == 100));
}
```

---

## Integration Tests

Integration tests verify that **multiple components work together correctly**.

They typically involve:

* Database
* File system
* External services (real or stubbed)

---

### When to Use Integration Tests

Use integration tests to validate:

* Database mappings
* Queries
* Serialization
* Configuration correctness

Avoid testing:

* All business rules again
* Edge cases already covered by unit tests

---

## End-to-End Tests (E2E)

E2E tests validate **critical user journeys** from start to finish.

They are:

* Slow
* Fragile
* Expensive

But sometimes necessary.

> E2E tests should be few and intentional.

---

## Test Smells

Watch for these warning signs:

* Tests that break often
* Large setup code
* Tests that are hard to understand
* Tests coupled to implementation

> If you don’t trust your tests, you won’t refactor.

---

## Testing and Architecture

Good architecture enables good testing:

* **SoC** allows isolated tests
* **DIP** enables mocking
* **Boundaries** define test scope
* **Cohesion** keeps tests focused

Tests are a reflection of design quality.

---

## Frontend Perspective (Angular)

### Unit Tests

* Test components in isolation
* Mock services
* Avoid DOM-heavy tests

### Integration Tests

* Test components with real templates
* Validate bindings and interactions

---

## Key Takeaways

* Tests enable change
* Favor unit tests, but don’t avoid integration tests
* Test behavior, not implementation
* Architecture and testing go hand in hand

---

## Next Steps

* Testing at Architectural Boundaries
* Test Data Builders & Fixtures
* Async and Time-Dependent Testing
