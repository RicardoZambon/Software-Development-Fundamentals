# Architecture — Layered vs Modular Architecture

> **Architecture is about making change safe.**

Layered and Modular architectures are two common ways of organizing systems. Both can work well — or fail badly — depending on how they are applied.

This document focuses on **practical trade-offs**, not dogma.

---

## Layered Architecture

Layered architecture organizes code by **technical responsibility**.

Typical layers:

* Presentation (UI / API)
* Application / Services
* Domain / Business Logic
* Infrastructure / Persistence

Dependencies usually flow **top → down**.

---

## When Layered Architecture Works Well

Layered architecture is effective when:

* The system is small to medium
* Business rules are simple
* The team is small
* Clear technical boundaries are needed

Benefits:

* Easy to understand
* Familiar to most developers
* Straightforward onboarding

---

## Problems with Layered Architecture

Common failure modes:

* **Layered monolith** — everything depends on everything
* Business logic leaks into controllers
* Infrastructure concerns leak upward
* Cross-cutting changes affect many layers

> Layers without discipline are just folders.

---

## ❌ Bad Example — Anemic Layered Design

```text
Controllers → Services → Repositories
```

Symptoms:

* Services are pass-throughs
* Business rules scattered
* Domain objects are just data bags

---

## Modular Architecture

Modular architecture organizes code by **business capability or feature**.

Example modules:

* Orders
* Payments
* Users
* Reporting

Each module may internally contain:

* API
* Domain logic
* Persistence

---

## When Modular Architecture Works Well

Modular architecture shines when:

* The system is large
* Business complexity is high
* Teams scale independently
* Features evolve at different speeds

Benefits:

* High cohesion within modules
* Clear ownership
* Reduced ripple effects

---

## Problems with Modular Architecture

Common failure modes:

* Over-fragmentation
* Inconsistent patterns between modules
* Cross-module duplication
* Premature microservice thinking

> Modules are not microservices.

---

## ❌ Bad Example — Pseudo-Modular

```text
Orders
Payments
Users
```

But:

* Shared infrastructure everywhere
* Cross-module references
* No real boundaries

---

## Layered vs Modular — Side by Side

| Concern      | Layered    | Modular  |
| ------------ | ---------- | -------- |
| Organization | Technical  | Business |
| Cohesion     | Medium     | High     |
| Coupling     | Often high | Lower    |
| Scalability  | Limited    | Better   |
| Onboarding   | Easier     | Moderate |

---

## Hybrid Approach (Recommended)

In practice, most successful systems use a **hybrid approach**:

* Modules by business capability
* Internal layering inside each module

Example:

```text
Orders
  ├── Api
  ├── Application
  ├── Domain
  └── Infrastructure
```

This balances:

* Clarity
* Cohesion
* Evolution

---

## Frontend Perspective (Angular)

### ❌ Pure Layered

```text
components
services
models
```

Leads to:

* Large shared services
* Tight coupling

### ✅ Feature-Based Modules

```text
orders
payments
users
```

Each feature owns its components, services, and state.

---

## Relationship with Other Principles

* **SoC** defines responsibilities
* **Cohesion & Coupling** guide grouping
* **DIP** enforces boundaries
* **KISS & YAGNI** prevent over-architecture

---

## Key Takeaways

* Architecture is contextual
* Layered is simpler, modular is stronger
* Hybrid models often work best
* Boundaries matter more than folders

---

## Next Steps

* Defining Boundaries & Ownership
* Managing Dependencies Between Modules
* Preventing Architectural Erosion
