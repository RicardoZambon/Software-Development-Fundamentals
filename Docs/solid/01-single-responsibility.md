# SOLID — Single Responsibility Principle (SRP)

> **A class should have one, and only one, reason to change.**

The Single Responsibility Principle (SRP) is the foundation of SOLID. If SRP is violated, the remaining principles become harder (or impossible) to apply correctly.

SRP is **not** about limiting a class to a single method. It is about **owning a single responsibility**, usually aligned with a **business capability or concern**.

---

## What SRP Really Means

A responsibility is a **reason to change**.

If a class changes because of:

* Business rules
* Infrastructure concerns
* Formatting / presentation
* Persistence
* External integrations

…and **more than one of those applies**, SRP is likely violated.

> SRP is about managing change safely.

---

## Common Misunderstandings

### ❌ "A class must have only one method"

Wrong. A class may have many methods as long as they serve the **same responsibility**.

### ❌ "SRP is about code size"

Wrong. Small classes can still violate SRP if they mix concerns.

### ❌ "SRP makes code over-engineered"

Usually false. SRP often *reduces* complexity by isolating change.

---

## Identifying SRP Violations (Smells)

Watch for these signs:

* A class has many unrelated reasons to change
* `if/else` branching based on "type" or "mode"
* Changes in one area break behavior in another
* Unit tests are hard to write or require heavy mocking

---

## ❌ Bad Example (SRP Violation)

```csharp
public class InvoiceService
{
    public void CreateInvoice(Invoice invoice)
    {
        Validate(invoice);
        SaveToDatabase(invoice);
        SendEmail(invoice);
        Log(invoice);
    }

    private void Validate(Invoice invoice) { /* business rules */ }
    private void SaveToDatabase(Invoice invoice) { /* persistence */ }
    private void SendEmail(Invoice invoice) { /* infrastructure */ }
    private void Log(Invoice invoice) { /* logging */ }
}
```

### Why this is a problem

This class has **multiple reasons to change**:

* Business validation rules
* Database changes
* Email infrastructure changes
* Logging strategy changes

A change in *any* of these forces a modification to `InvoiceService`.

---

## ✅ Good Example (SRP Applied)

```csharp
public class InvoiceService
{
    private readonly IInvoiceValidator _validator;
    private readonly IInvoiceRepository _repository;
    private readonly IInvoiceNotifier _notifier;

    public InvoiceService(
        IInvoiceValidator validator,
        IInvoiceRepository repository,
        IInvoiceNotifier notifier)
    {
        _validator = validator;
        _repository = repository;
        _notifier = notifier;
    }

    public void CreateInvoice(Invoice invoice)
    {
        _validator.Validate(invoice);
        _repository.Save(invoice);
        _notifier.Notify(invoice);
    }
}
```

Each dependency owns **one responsibility**:

* `IInvoiceValidator` → business rules
* `IInvoiceRepository` → persistence
* `IInvoiceNotifier` → external communication

---

## SRP in Practice (Senior Perspective)

### SRP does NOT mean:

* One class per method
* One class per file
* Extreme fragmentation

### SRP DOES mean:

* Clear ownership of behavior
* Isolated reasons to change
* Easier testing and refactoring

---

## Testing Impact

SRP leads to:

* Smaller, focused unit tests
* Less mocking per test
* Clear test intent

```csharp
// Test reads like a sentence
Should_Reject_Invoice_When_Total_Is_Negative()
```

---

## SRP in Frontend (Angular Example)

### ❌ Bad

A component that:

* Fetches data
* Transforms business rules
* Manages UI state
* Formats values

### ✅ Better

* Component: UI rendering
* Service: business logic
* Mapper / Pipe: formatting

---

## Key Takeaways

* SRP is about **reasons to change**, not method count
* Violating SRP increases coupling and risk
* SRP enables better testing, readability, and evolution

---

## Next Principle

➡️ **Open/Closed Principle (OCP)**

📄 [Docs/solid/02-open-closed.md](02-open-closed.md)
