# SOLID — Interface Segregation Principle (ISP)

> **Clients should not be forced to depend on interfaces they do not use.**

The Interface Segregation Principle (ISP) promotes **small, focused, role-based interfaces** instead of large, generic ones.

ISP reduces coupling, improves readability, and prevents accidental misuse of abstractions.

---

## What ISP Really Means

ISP is about **protecting clients**, not about creating many interfaces for their own sake.

A client should:

* Depend only on the methods it actually needs
* Not be affected by changes to unrelated behavior

> Fat interfaces create fragile systems.

---

## Common Misunderstandings

### ❌ "ISP means one interface per method"

Wrong. Interfaces should be **cohesive**, not microscopic.

### ❌ "Generic interfaces are always bad"

Wrong. Generic interfaces are fine when **all consumers truly need all methods**.

### ❌ "ISP causes interface explosion"

Only when responsibilities are poorly understood.

---

## Identifying ISP Violations (Smells)

Watch for these signs:

* Interfaces with many unrelated methods
* Implementations throwing `NotImplementedException`
* Clients forced to mock unused methods in tests
* Changes in one method impacting many consumers

---

## ❌ Bad Example (ISP Violation)

```csharp
public interface IUserService
{
    User GetById(int id);
    void Create(User user);
    void Update(User user);
    void Delete(int id);
    void SendPasswordResetEmail(User user);
    void GenerateUserReport(int userId);
}
```

### Why this is a problem

* Not all consumers need all methods
* Reporting or email changes impact CRUD consumers
* Testing requires mocking irrelevant behavior

---

## ✅ Good Example (ISP Applied)

```csharp
public interface IUserReader
{
    User GetById(int id);
}

public interface IUserWriter
{
    void Create(User user);
    void Update(User user);
    void Delete(int id);
}

public interface IUserNotifier
{
    void SendPasswordResetEmail(User user);
}

public interface IUserReporting
{
    void GenerateUserReport(int userId);
}
```

Each client depends only on what it needs.

---

## ISP in Practice (Senior Perspective)

### ISP helps when:

* Different clients have different needs
* Interfaces grow over time
* Changes ripple unexpectedly

### ISP should be applied carefully when:

* All consumers truly use all methods
* Splitting reduces clarity

> ISP is about intent, not quantity.

---

## Testing Impact

ISP leads to:

* Smaller, focused mocks
* Clearer test intent
* Less brittle tests

```csharp
Should_Send_Password_Reset_Email()
```

---

## ISP in Frontend (Angular Example)

### ❌ Bad

A service that:

* Handles HTTP calls
* Manages UI state
* Formats values

### ✅ Better

* API service (data access)
* State service (state management)
* Utility or pipe (formatting)

---

## Key Takeaways

* Clients should depend only on what they use
* Fat interfaces increase coupling and fragility
* ISP complements SRP and LSP

---

## Next Principle

➡️ **Dependency Inversion Principle (DIP)**

Planned file:

```
Docs/solid/05-dependency-inversion.md
```
