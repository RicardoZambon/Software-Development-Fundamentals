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

- Single Responsibility
- Open/Closed
- Liskov Substitution
- Interface Segregation
- Dependency Inversion

> SOLID is about managing change, not academic purity.

📄 Docs: `docs/solid/`  
💻 Examples: `dotnet/solid/`

---

### DRY – Don’t Repeat Yourself
Avoid duplicating **knowledge**, not just code.

- Centralize business rules
- Share intent, not convenience
- Avoid premature abstraction

> Duplication is cheaper than the wrong abstraction.

📄 Docs: `docs/dry-vs-wet.md`  
💻 Examples: `dotnet/dry/`

---

### WET – Write Everything Twice (Intentionally)
A conscious decision to allow duplication when:
- Code is likely to diverge
- Abstraction would reduce clarity
- Readability is more important than reuse

> WET is a tool, not a failure.

📄 Docs: `docs/dry-vs-wet.md`

---

### KISS – Keep It Simple
Prefer:
- Clear solutions over clever ones
- Explicit code over magic
- Readability over micro-optimizations

> If it needs a comment to explain it, it’s probably too complex.

📄 Docs: `docs/kiss-yagni.md`

---

### YAGNI – You Aren’t Gonna Need It
Avoid building features or abstractions for hypothetical futures.

- Solve today’s problem
- Refactor when the need is real

> Today’s imaginary problem is tomorrow’s technical debt.

📄 Docs: `docs/kiss-yagni.md`

---

### Separation of Concerns
Each part of the system should have a **clear and focused responsibility**.

Examples:
- UI ≠ Business Logic ≠ Infrastructure
- Controllers ≠ Services ≠ Repositories

📄 Docs: `docs/architecture/separation-of-concerns.md`

---

### High Cohesion & Low Coupling
- Keep related behavior together
- Minimize dependencies between components

> Easier to test, refactor, and reason about.

📄 Docs: `docs/architecture/cohesion-coupling.md`

---

### Composition Over Inheritance
Prefer composing behavior through interfaces and services instead of deep inheritance hierarchies.

> Inheritance increases coupling. Composition increases flexibility.

📄 Docs: `docs/architecture/composition-vs-inheritance.md`

---

### Fail Fast
Detect errors early and explicitly.

- Clear exceptions
- Meaningful error messages
- Avoid hiding failures

📄 Docs: `docs/error-handling.md`  
💻 Examples: `dotnet/error-handling/`

---

## Repository Structure

```text
software-development-fundamentals/
│
├── README.md
├── docs/
│   ├── solid/
│   ├── dry-vs-wet.md
│   ├── kiss-yagni.md
│   ├── architecture/
│   └── error-handling.md
│
├── dotnet/
│   ├── solid/
│   ├── dry/
│   ├── error-handling/
│
├── angular/
│   ├── components/
│   ├── state-management/
│
└── LICENSE
