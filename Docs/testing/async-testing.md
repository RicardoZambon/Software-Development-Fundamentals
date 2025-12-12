# Async & Time-Dependent Testing

> **Async code multiplies complexity. Tests must tame it.**

Modern applications are inherently asynchronous: APIs, databases, queues, timers, and UI interactions all rely on async behavior. Testing async and time-dependent code requires extra care to avoid flaky, slow, or misleading tests.

This document focuses on **practical techniques** to test async code reliably.

---

## Why Async Tests Fail

Common causes of flaky async tests:

* Awaiting the wrong thing
* Hidden background tasks
* Real time delays (`Task.Delay`, `setTimeout`)
* Race conditions
* Thread-safety assumptions

> If a test passes sometimes, it’s broken.

---

## Basic Rules for Async Testing

1. **Always await async methods**
2. **Never block on async code** (`.Result`, `.Wait()`)
3. **Avoid real time** in tests
4. **Control concurrency explicitly**

---

## ❌ Bad Example — Blocking Async Code

```csharp
[Test]
public void Process_Should_Save_Result()
{
    var service = new ProcessingService();

    service.ProcessAsync().Wait(); // ❌ blocks

    Assert.IsTrue(service.HasProcessed);
}
```

### Why this is a problem

* Can deadlock
* Hides timing issues
* Makes failures environment-dependent

---

## ✅ Good Example — Proper Async Test

```csharp
[Test]
public async Task Process_Should_Save_Result()
{
    var service = new ProcessingService();

    await service.ProcessAsync();

    Assert.IsTrue(service.HasProcessed);
}
```

---

## Time-Dependent Code Is the Real Enemy

Code that depends on:

* Current time (`DateTime.Now`)
* Delays (`Task.Delay`)
* Retries and backoff

is **hard to test reliably**.

---

## ❌ Bad Example — Using Real Time

```csharp
public async Task ExpireTokenAsync()
{
    await Task.Delay(TimeSpan.FromMinutes(5));
    _token.Expire();
}
```

Tests using this code will be:

* Slow
* Flaky
* Painful

---

## ✅ Good Example — Time Abstraction

```csharp
public interface IClock
{
    DateTime UtcNow { get; }
}

public class SystemClock : IClock
{
    public DateTime UtcNow => DateTime.UtcNow;
}
```

```csharp
public class TokenService
{
    private readonly IClock _clock;

    public TokenService(IClock clock)
    {
        _clock = clock;
    }

    public void ExpireIfNeeded(Token token)
    {
        if (token.ExpiresAt <= _clock.UtcNow)
            token.Expire();
    }
}
```

---

## Testing Time-Dependent Logic

```csharp
[Test]
public void Token_Should_Expire_When_Time_Passes()
{
    var fakeClock = Substitute.For<IClock>();
    fakeClock.UtcNow.Returns(new DateTime(2025, 1, 1));

    var token = new Token { ExpiresAt = new DateTime(2024, 12, 31) };
    var service = new TokenService(fakeClock);

    service.ExpireIfNeeded(token);

    Assert.IsTrue(token.IsExpired);
}
```

---

## Testing Concurrency

When testing concurrent behavior:

* Avoid timing assumptions
* Use synchronization primitives
* Test outcomes, not execution order

> Don’t test *how fast* something happens. Test *that* it happens.

---

## Frontend Perspective (Angular)

### Angular Async Testing Tools

* `fakeAsync` / `tick`
* `async` / `waitForAsync`
* `flush` / `flushMicrotasks`

Use them to:

* Control time
* Resolve promises deterministically

---

## Common Async Test Smells

Watch for:

* `Thread.Sleep`
* Long timeouts
* Random failures in CI
* Tests depending on execution order

> Flaky tests destroy trust.

---

## Relationship with Architecture

* **DIP** enables time abstraction
* **SoC** isolates async behavior
* **Boundaries** define what to await
* **KISS** keeps concurrency manageable

---

## Key Takeaways

* Always await async code
* Never depend on real time in tests
* Abstract clocks and delays
* Test behavior, not timing

---

## Next Steps

* Contract Testing
* Resilience & Retry Testing
* Property-Based Testing
