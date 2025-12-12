# Test Data Builders & Fixtures

> **Readable tests depend on readable data setup.**

Test Data Builders and Fixtures are techniques to create test data **clearly, consistently, and with minimal noise**. They help teams avoid brittle tests and excessive setup code.

---

## The Problem with Test Setup

Common symptoms of poor test setup:

* Tests dominated by object construction
* Repeated setup logic across tests
* Hard-to-understand intent
* Small changes breaking many tests

> When setup hides intent, tests stop being documentation.

---

## ❌ Bad Example — Inline Setup Everywhere

```csharp
[Test]
public void PlaceOrder_Should_Apply_Discount_For_Premium_Customer()
{
    var order = new Order
    {
        Id = 1,
        Total = 200,
        Customer = new Customer
        {
            Id = 10,
            Name = "John",
            IsPremium = true,
            Address = new Address
            {
                Street = "Main St",
                City = "NY",
                ZipCode = "12345"
            }
        },
        CreatedAt = DateTime.UtcNow
    };

    var service = new OrderService();

    service.PlaceOrder(order);

    Assert.AreEqual(180, order.Total);
}
```

### Why this is a problem

* Setup overwhelms the test intent
* Repeated across many tests
* Changes in object structure ripple everywhere

---

## Test Data Builders

A **Test Data Builder** encapsulates object construction and provides a fluent, intention-revealing API.

---

## ✅ Good Example — Test Data Builder

```csharp
public class OrderBuilder
{
    private decimal _total = 100;
    private bool _isPremiumCustomer = false;

    public OrderBuilder WithTotal(decimal total)
    {
        _total = total;
        return this;
    }

    public OrderBuilder ForPremiumCustomer()
    {
        _isPremiumCustomer = true;
        return this;
    }

    public Order Build()
    {
        return new Order
        {
            Total = _total,
            Customer = new Customer
            {
                IsPremium = _isPremiumCustomer
            }
        };
    }
}
```

```csharp
[Test]
public void PlaceOrder_Should_Apply_Discount_For_Premium_Customer()
{
    var order = new OrderBuilder()
        .WithTotal(200)
        .ForPremiumCustomer()
        .Build();

    var service = new OrderService();

    service.PlaceOrder(order);

    Assert.AreEqual(180, order.Total);
}
```

### Why this is better

* Test intent is obvious
* Setup is reusable
* Changes are localized

---

## Object Mothers vs Builders

### Object Mother

* Provides pre-built objects
* Can become rigid

### Builder

* Flexible
* Intention-revealing
* Easier to extend

> Prefer builders for complex objects.

---

## Fixtures

Fixtures manage **shared setup** for test suites.

---

### ❌ Bad Fixture Usage

* Large, shared mutable state
* Hidden dependencies between tests

---

### ✅ Good Fixture Usage

* Immutable or reset per test
* Limited to infrastructure setup

Example:

```csharp
[TestFixture]
public class OrderRepositoryTests
{
    private DatabaseFixture _db;

    [SetUp]
    public void SetUp()
    {
        _db = new DatabaseFixture();
    }
}
```

---

## Builders and Architecture

Builders should:

* Live in test projects
* Respect architectural boundaries
* Avoid knowledge of infrastructure

They should **not**:

* Bypass domain rules
* Create invalid states silently

---

## Frontend Perspective (Angular)

### Test Builders

* Factory functions for test data
* Reduce boilerplate in component tests

Example:

```ts
const order = orderBuilder()
  .premium()
  .withTotal(200)
  .build();
```

---

## Key Takeaways

* Tests should read like specifications
* Builders reduce noise and duplication
* Fixtures must be used carefully

---

## Next Steps

* Async & Time-Dependent Testing
* Contract Testing
* Property-Based Testing
