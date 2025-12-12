# DRY vs WET — Don’t Repeat Yourself (and When to)

> **DRY is about avoiding duplication of knowledge, not duplication of code.**

DRY (Don’t Repeat Yourself) is one of the most misunderstood principles in software development. Applied correctly, it reduces bugs and centralizes business rules. Applied blindly, it creates rigid, over-abstracted systems that are hard to understand and evolve.

WET (Write Everything Twice) exists as a **deliberate counterbalance** to DRY.

---

## What DRY Really Means

DRY states that:

> *Every piece of knowledge should have a single, authoritative representation within a system.*

"Knowledge" refers to:

* Business rules
* Invariants
* Algorithms
* Policies

It does **not** mean:

* No duplicated lines of code
* No similar-looking logic
* One abstraction for everything

---

## What DRY Does NOT Mean

### ❌ "Any duplication is bad"

Duplication can be cheaper than abstraction when:

* Code is small
* Behavior may diverge
* Contexts are different

### ❌ "Helpers everywhere"

Large helper or utility classes often hide:

* Multiple responsibilities
* Leaky abstractions
* Implicit coupling

---

## WET — Write Everything Twice (Intentionally)

WET is not laziness. It is a **design decision**.

WET accepts that:

* Duplication can be temporary
* Clarity beats reuse
* Abstraction should earn its place

> Duplication is often cheaper than the wrong abstraction.

---

## DRY Smells (Over-Abstraction)

Watch for these warning signs:

* Helper methods with many parameters
* Generic methods that try to serve unrelated cases
* Code that is hard to read without jumping files
* Changes in one place breaking unrelated behavior

---

## ❌ Bad Example — Over-DRY

```csharp
public static class DiscountHelper
{
    public static decimal CalculateDiscount(
        decimal amount,
        bool isPremium,
        bool isHoliday,
        bool isEmployee)
    {
        if (isEmployee)
            return amount * 0.30m;

        if (isPremium && isHoliday)
            return amount * 0.20m;

        if (isPremium)
            return amount * 0.10m;

        return 0m;
    }
}
```

### Why this is a problem

* Business rules are compressed into flags
* Context is lost at call sites
* Every new rule modifies this method
* Violates SRP and OCP

---

## ✅ Good Example — Intentional WET

```csharp
public class HolidayDiscountService
{
    public decimal Calculate(decimal amount)
        => amount * 0.20m;
}

public class PremiumDiscountService
{
    public decimal Calculate(decimal amount)
        => amount * 0.10m;
}

public class EmployeeDiscountService
{
    public decimal Calculate(decimal amount)
        => amount * 0.30m;
}
```

### Why this is better

* Each rule is explicit
* Behavior can evolve independently
* Easier to test
* Abstraction can be introduced later if needed

---

## DRY in Practice (Senior Perspective)

### Apply DRY when:

* The same business rule appears in multiple places
* Changes must be consistent everywhere
* Divergence would be a bug

### Prefer WET when:

* Contexts differ
* Rules may evolve independently
* Abstraction would hide intent

> DRY is about correctness. WET is about clarity.

---

## Relationship with SOLID

* **SRP** prevents DRY from becoming god-objects
* **OCP** allows DRY abstractions to evolve safely
* **ISP** avoids fat DRY interfaces
* **DIP** ensures shared knowledge lives in the right layer

DRY without SOLID leads to rigid systems.
SOLID without DRY leads to duplication.

---

## Key Takeaways

* DRY avoids duplication of *knowledge*, not code
* Over-DRY is a common senior-level mistake
* WET is sometimes the correct choice
* Abstractions should be earned, not assumed

---

## Next Steps

* Add DRY/WET code examples under `dotnet/dry/`
* Explore refactoring paths from WET → DRY
* Compare backend and frontend scenarios
