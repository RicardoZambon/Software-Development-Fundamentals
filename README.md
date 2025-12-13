# Software Development Fundamentals

A practical, senior-level guide to **core software development principles**, with real-world examples using **.NET (C#)**, **Angular**, and **SQL**.

This repository is not about frameworks or trends — it focuses on the **fundamentals that remain relevant across languages, stacks, and years of experience**.

The goal is to document **why** these principles matter, **how** to apply them in day-to-day work, and **what happens when they are ignored**.

---

## Who This Repository Is For

- Senior Software Engineers and Tech Leads
- Developers transitioning from Mid → Senior
- Engineers who want to **strengthen fundamentals**, not memorize patterns
- Teams looking for a shared baseline of coding principles

---

## Core Principles Summary

### SOLID
A set of design principles focused on **maintainability, testability, and safe change**.

- [Single Responsibility](Docs/solid/01-single-responsibility.md)
- [Open/Closed](Docs/solid/02-open-closed.md)
- [Liskov Substitution](Docs/solid/03-liskov-substitution.md)
- [Interface Segregation](Docs/solid/04-interface-segregation.md)
- [Dependency Inversion](Docs/solid/05-dependency-inversion.md)

> SOLID is about managing change, not academic purity.

📄 Docs: [Docs/solid/](Docs/solid/)  
💻 Examples: [Dotnet/solid/](Dotnet/solid/)

---

### DRY – Don’t Repeat Yourself
Avoid duplicating **knowledge**, not just code.

- Centralize business rules
- Share intent, not convenience
- Avoid premature abstraction

> Duplication is cheaper than the wrong abstraction.

📄 Docs: [Docs/dry-vs-wet.md](Docs/dry-vs-wet.md)  
💻 Examples: [Dotnet/dry/](Dotnet/dry/)

---

### WET – Write Everything Twice (Intentionally)
A conscious decision to allow duplication when:
- Code is likely to diverge
- Abstraction would reduce clarity
- Readability is more important than reuse

> WET is a tool, not a failure.

📄 Docs: [Docs/dry-vs-wet.md](Docs/dry-vs-wet.md)

---

### KISS – Keep It Simple
Prefer:
- Clear solutions over clever ones
- Explicit code over magic
- Readability over micro-optimizations

> If it needs a comment to explain it, it’s probably too complex.

📄 Docs: [Docs/kiss-yagni.md](Docs/kiss-yagni.md)  
💻 Examples: [Dotnet/kiss-yagni/](Dotnet/kiss-yagni/)

---

### YAGNI – You Aren’t Gonna Need It
Avoid building features or abstractions for hypothetical futures.

- Solve today’s problem
- Refactor when the need is real

> Today’s imaginary problem is tomorrow’s technical debt.

📄 Docs: [Docs/kiss-yagni.md](Docs/kiss-yagni.md)  
💻 Examples: [Dotnet/kiss-yagni/](Dotnet/kiss-yagni/)

---

### Separation of Concerns
Each part of the system should have a **clear and focused responsibility**.

Examples:
- UI ≠ Business Logic ≠ Infrastructure
- Controllers ≠ Services ≠ Repositories

📄 Docs: [Docs/architecture/separation-of-concerns.md](Docs/architecture/separation-of-concerns.md)

---

### High Cohesion & Low Coupling
- Keep related behavior together
- Minimize dependencies between components

> Easier to test, refactor, and reason about.

📄 Docs: [Docs/architecture/cohesion-coupling.md](Docs/architecture/cohesion-coupling.md)

---

### Layered vs Modular Architecture
Choose the right organizational approach for your system's complexity.

- Layered: organized by technical responsibility
- Modular: organized by business capability
- Hybrid: modules with internal layering

> Architecture is about making change safe.

📄 Docs: [Docs/architecture/layered-vs-modular.md](Docs/architecture/layered-vs-modular.md)

---

### Boundaries & Ownership
Define clear lines of responsibility and explicit ownership.

- Minimize knowledge sharing between modules
- Establish clear ownership per area
- Enforce boundaries consistently

> Boundaries are about limiting blast radius.

📄 Docs: [Docs/architecture/boundaries-ownership.md](Docs/architecture/boundaries-ownership.md)

---

### Architecture Decision Records (ADRs)
Capture significant architectural decisions and their reasoning.

- Preserve context and reasoning
- Reduce tribal knowledge
- Improve onboarding and consistency

> If you can't explain why a decision was made, it will be questioned again.

📄 Docs: [Docs/architecture/architecture-decision-records.md](Docs/architecture/architecture-decision-records.md)

---

### Testing Fundamentals
Tests enable change by providing confidence in software evolution.

- Focus on behavior, not implementation
- Follow the testing pyramid (unit → integration → E2E)
- Tests are about enabling change, not catching bugs

> If tests make change harder, they are failing their purpose.

📄 Docs: [Docs/testing/testing-fundamentals.md](Docs/testing/testing-fundamentals.md)

---

### Testing at Boundaries
Validate behavior without breaking encapsulation.

- Test through public interfaces
- Respect architectural boundaries
- Avoid coupling to implementation details

> Tests should respect the same boundaries as the architecture.

📄 Docs: [Docs/testing/testing-at-boundaries.md](Docs/testing/testing-at-boundaries.md)

---

### Test Data Builders
Create test data clearly and consistently with minimal noise.

- Reduce setup boilerplate
- Make test intent obvious
- Centralize object construction

> Readable tests depend on readable data setup.

📄 Docs: [Docs/testing/test-data-builders.md](Docs/testing/test-data-builders.md)

---

### Async & Time-Dependent Testing
Test asynchronous code reliably without flaky tests.

- Always await async methods
- Abstract time dependencies
- Control concurrency explicitly

> Async code multiplies complexity. Tests must tame it.

📄 Docs: [Docs/testing/async-testing.md](Docs/testing/async-testing.md)

---

## Repository Structure

```text
software-development-fundamentals/
│
├── README.md
├── Docs/
│   ├── solid/
│   │   ├── 01-single-responsibility.md
│   │   ├── 02-open-closed.md
│   │   ├── 03-liskov-substitution.md
│   │   ├── 04-interface-segregation.md
│   │   └── 05-dependency-inversion.md
│   ├── architecture/
│   │   ├── separation-of-concerns.md
│   │   ├── cohesion-coupling.md
│   │   ├── layered-vs-modular.md
│   │   ├── boundaries-ownership.md
│   │   └── architecture-decision-records.md
│   ├── testing/
│   │   ├── testing-fundamentals.md
│   │   ├── testing-at-boundaries.md
│   │   ├── test-data-builders.md
│   │   └── async-testing.md
│   ├── dry-vs-wet.md
│   └── kiss-yagni.md
│
├── Dotnet/
│   ├── solid/
│   │   ├── single-responsibility/
│   │   │   ├── BadInvoiceService.cs
│   │   │   └── GoodInvoiceService.cs
│   │   ├── open-closed/
│   │   │   ├── BadPaymentProcessor.cs
│   │   │   └── GoodPaymentProcessor.cs
│   │   ├── liskov-substitution/
│   │   │   ├── BadBirdExample.cs
│   │   │   └── GoodBirdExample.cs
│   │   ├── interface-segregation/
│   │   │   ├── BadUserService.cs
│   │   │   └── GoodUserService.cs
│   │   └── dependency-inversion/
│   │       ├── BadOrderService.cs
│   │       └── GoodOrderService.cs
│   ├── dry/
│   │   ├── BadOverAbstractedDiscount.cs
│   │   └── GoodExplicitDiscounts.cs
│   └── kiss-yagni/
│       ├── BadOverEngineeredSolution.cs
│       └── GoodSimpleSolution.cs
│
└── LICENSE
