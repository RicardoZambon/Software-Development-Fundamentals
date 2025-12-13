# SOLID — Open/Closed Principle (OCP)

> **Software entities should be open for extension, but closed for modification.**

The Open/Closed Principle (OCP) states that you should be able to **add new behavior** to a system **without changing existing, stable code**.

OCP reduces the risk of regressions and makes systems safer to evolve over time.

---

## What OCP Really Means

OCP does **not** mean that code never changes.

It means:

* Stable, tested code should not need to be modified for every new requirement
* New behavior should be introduced through **extension**, not **rewriting**

> OCP is about protecting working code from constant churn.

---

## Common Misunderstandings

### ❌ "OCP means no if/else statements"

Wrong. Conditionals are fine. OCP is violated when **every new feature requires editing the same conditional block**.

### ❌ "OCP requires heavy abstractions everywhere"

Wrong. OCP should be applied **where change is expected**, not everywhere.

### ❌ "OCP is only about inheritance"

Wrong. OCP is more commonly achieved through **composition and polymorphism**.

---

## Identifying OCP Violations (Smells)

Watch for these signs:

* Large `switch` or `if/else` blocks growing over time
* The same class being modified for unrelated features
* Fear of touching a class because it breaks existing behavior
* Multiple PRs changing the same file for different reasons

---

## ❌ Bad Example (OCP Violation)

```csharp
public class PaymentProcessor
{
    public decimal CalculateFee(Payment payment)
    {
        if (payment.Method == PaymentMethod.CreditCard)
            return payment.Amount * 0.03m;

        if (payment.Method == PaymentMethod.PayPal)
            return payment.Amount * 0.05m;

        if (payment.Method == PaymentMethod.Pix)
            return 0;

        throw new NotSupportedException();
    }
}
```

### Why this is a problem

* Every new payment method requires modifying this class
* Existing logic is at risk of regression
* The class becomes a hotspot for changes

---

## ✅ Good Example (OCP Applied)

```csharp
public interface IPaymentFeeStrategy
{
    decimal Calculate(Payment payment);
}

public class CreditCardFeeStrategy : IPaymentFeeStrategy
{
    public decimal Calculate(Payment payment) => payment.Amount * 0.03m;
}

public class PayPalFeeStrategy : IPaymentFeeStrategy
{
    public decimal Calculate(Payment payment) => payment.Amount * 0.05m;
}

public class PixFeeStrategy : IPaymentFeeStrategy
{
    public decimal Calculate(Payment payment) => 0;
}
```

```csharp
public class PaymentProcessor
{
    private readonly IDictionary<PaymentMethod, IPaymentFeeStrategy> _strategies;

    public PaymentProcessor(IEnumerable<IPaymentFeeStrategy> strategies)
    {
        _strategies = strategies.ToDictionary(s => s.Method());
    }

    public decimal CalculateFee(Payment payment)
    {
        if (!_strategies.TryGetValue(payment.Method, out var strategy))
            throw new NotSupportedException();

        return strategy.Calculate(payment);
    }
}
```

New payment methods can now be added **without modifying** `PaymentProcessor`.

---

## OCP in Practice (Senior Perspective)

### Apply OCP when:

* Business rules change frequently
* New variants are expected
* You want to isolate risk

### Avoid OCP when:

* The logic is unlikely to change
* Abstractions reduce clarity
* Duplication would be cheaper

> OCP is a tool, not a rule.

---

## Testing Impact

OCP enables:

* Independent testing of each strategy
* No need to rewrite existing tests for new behavior

```csharp
Should_Calculate_CreditCard_Fee_Correctly()
Should_Calculate_Pix_Fee_As_Zero()
```

---

## OCP in Frontend (Angular Example)

### ❌ Bad

A component with a growing `switch` to handle multiple UI behaviors.

### ✅ Better

* Strategy services per behavior
* Component delegates behavior

---

## Key Takeaways

* OCP protects stable code
* New behavior should be added through extension
* Polymorphism and composition are key enablers

---

## Next Principle

➡️ **Liskov Substitution Principle (LSP)**

Planned file:

```
Docs/solid/03-liskov-substitution.md
```
