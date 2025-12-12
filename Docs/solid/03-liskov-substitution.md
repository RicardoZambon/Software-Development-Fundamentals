# SOLID — Liskov Substitution Principle (LSP)

> **Objects of a superclass should be replaceable with objects of its subclasses without altering the correctness of the program.**

The Liskov Substitution Principle (LSP) ensures that **polymorphism is safe**.

If LSP is violated, code may compile but fail at runtime in subtle and dangerous ways.

---

## What LSP Really Means

LSP is not about syntax or inheritance alone.

It is about **behavioral contracts**.

If `Derived` extends `Base`, then:

* `Derived` must honor the expectations established by `Base`
* Callers should not need to know which concrete type they are using

> If you need to check the concrete type, LSP is already broken.

---

## Common Misunderstandings

### ❌ "LSP is only about inheritance"

Wrong. LSP applies to **interfaces, abstractions, and polymorphism in general**.

### ❌ "Throwing NotImplementedException is fine"

Usually false. If a method cannot be meaningfully implemented, the abstraction is wrong.

### ❌ "As long as it compiles, it's correct"

LSP violations often compile cleanly and fail only at runtime.

---

## Identifying LSP Violations (Smells)

Watch for these signs:

* Subclasses that override methods but change expected behavior
* Methods that throw exceptions "just for some implementations"
* Callers that must check concrete types
* Comments explaining why a subtype behaves differently

---

## ❌ Bad Example (LSP Violation)

```csharp
public abstract class Bird
{
    public abstract void Fly();
}

public class Sparrow : Bird
{
    public override void Fly()
    {
        // flies normally
    }
}

public class Penguin : Bird
{
    public override void Fly()
    {
        throw new NotSupportedException("Penguins can't fly");
    }
}
```

### Why this is a problem

* `Bird` promises that all birds can fly
* `Penguin` breaks that contract
* Any code using `Bird` polymorphically is now unsafe

---

## ✅ Good Example (LSP Applied)

```csharp
public abstract class Bird
{
    public abstract void Move();
}

public interface IFlyingBird
{
    void Fly();
}

public class Sparrow : Bird, IFlyingBird
{
    public override void Move() { /* walk or hop */ }
    public void Fly() { /* fly */ }
}

public class Penguin : Bird
{
    public override void Move() { /* swim or walk */ }
}
```

Now:

* All birds can `Move`
* Only flying birds implement `Fly`
* No runtime surprises

---

## LSP in Practice (Senior Perspective)

### LSP violations usually mean:

* The abstraction is wrong
* Responsibilities are mixed
* The model does not reflect reality

### Fixing LSP often requires:

* Rethinking the abstraction
* Splitting interfaces
* Favoring composition

> LSP is a modeling problem, not a coding problem.

---

## Testing Impact

LSP enables:

* Polymorphic tests
* Confidence that new implementations won't break callers

```csharp
Should_Process_All_Birds_Without_Exception()
```

---

## LSP in Frontend (Angular Example)

### ❌ Bad

A shared interface where some components throw errors or ignore inputs they "don't support".

### ✅ Better

* Smaller, role-based interfaces
* Components implement only what they truly support

---

## Key Takeaways

* LSP ensures safe polymorphism
* Subtypes must honor behavioral contracts
* If a subtype needs special handling, the abstraction is wrong

---

## Next Principle

➡️ **Interface Segregation Principle (ISP)**

Planned file:

```
docs/solid/04-interface-segregation.md
```
