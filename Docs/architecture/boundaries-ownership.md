# Architecture — Boundaries & Ownership

> **Architecture fails when boundaries are unclear and ownership is implicit.**

Boundaries define *where* responsibilities begin and end. Ownership defines *who* is responsible for decisions and changes within those boundaries.

Clear boundaries and explicit ownership are essential to prevent architectural erosion as systems and teams grow.

---

## What Is a Boundary?

A boundary is a **line that separates responsibilities**.

Boundaries can exist between:

* Modules or features
* Layers (API, domain, infrastructure)
* Bounded contexts
* Teams

A good boundary:

* Has a clear purpose
* Minimizes knowledge sharing
* Is enforced consistently

> Boundaries are about limiting blast radius.

---

## Ownership — The Missing Half

Ownership answers:

* Who can change this?
* Who reviews changes here?
* Who decides design trade-offs?

Without ownership:

* Everyone changes everything
* No one feels responsible
* Architecture decays silently

> Implicit ownership is no ownership.

---

## Boundary Smells

Watch for these warning signs:

* Cross-module references everywhere
* "Just this one exception" dependencies
* Shared utility projects growing endlessly
* Business rules duplicated across modules

---

## ❌ Bad Example — No Boundaries

```text
Orders → Users → Payments → Reporting
   ↖───────────────↴
```

Symptoms:

* Cyclic dependencies
* Changes ripple unpredictably
* No clear ownership

---

## ✅ Good Example — Clear Boundaries

```text
Orders
  ├── Api
  ├── Application
  ├── Domain
  └── Infrastructure

Payments
  ├── Api
  ├── Application
  ├── Domain
  └── Infrastructure
```

Rules:

* Modules communicate via contracts
* No direct infrastructure sharing
* Dependencies flow inward

---

## Dependency Direction Rules

To preserve boundaries:

* High-level policies should not depend on low-level details
* Modules should depend on contracts, not implementations
* Cross-module communication should be explicit

> If dependency direction is unclear, boundaries will erode.

---

## Enforcing Boundaries (Practical Strategies)

### Code-Level

* Internal access modifiers
* Separate projects/packages
* Explicit interfaces

### Process-Level

* Ownership defined per module
* Required reviewers per area
* Architectural decision records (ADRs)

### Tooling

* Static analysis rules
* Dependency graphs
* Build-time checks

---

## Frontend Perspective (Angular)

### ❌ Bad

* Shared services imported everywhere
* Global state mutated by any feature

### ✅ Better

* Feature modules own their state
* Explicit public APIs per module
* No deep imports across features

---

## Relationship with Other Principles

* **DIP** enforces boundary direction
* **SoC** defines what belongs where
* **Cohesion & Coupling** measure boundary health
* **KISS** prevents over-complicated boundaries

---

## Key Takeaways

* Boundaries protect architecture
* Ownership prevents erosion
* Rules must be explicit and enforced

---

## Next Steps

* Managing Dependencies Over Time
* Architectural Decision Records (ADRs)
* Testing at Boundaries
