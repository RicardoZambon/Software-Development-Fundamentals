# Architecture Decision Records (ADRs)

> **Architecture is a series of decisions. ADRs capture the why.**

Architecture Decision Records (ADRs) are short documents that record **significant architectural decisions**, their context, and their consequences.

ADRs are not bureaucracy. They are a lightweight tool to:

* Preserve reasoning
* Reduce tribal knowledge
* Improve onboarding
* Avoid repeating the same debates

---

## What Is an ADR?

An ADR answers four simple questions:

1. **Context** — What problem are we solving?
2. **Decision** — What did we decide?
3. **Status** — Proposed / Accepted / Superseded
4. **Consequences** — What are the trade-offs?

> If you can’t explain *why* a decision was made, it will be questioned again.

---

## When Should You Write an ADR?

Write an ADR when:

* Introducing a new architectural pattern
* Choosing a framework or major dependency
* Defining module boundaries
* Making a trade-off with long-term impact

Do **not** write ADRs for:

* Formatting rules
* Minor refactors
* Temporary experiments

---

## ADR Format (Recommended)

Keep ADRs short and consistent.

```markdown
# ADR-001: Use Modular Architecture for Backend Services

## Status
Accepted

## Context
The system has grown in size and business complexity, making a pure layered architecture hard to evolve.

## Decision
We will organize backend code by business modules (Orders, Payments, Users), each with internal layering.

## Consequences
- Increased cohesion within modules
- Clear ownership boundaries
- Slightly higher onboarding cost
```

---

## Naming and Organization

Recommended conventions:

* Prefix with incremental number: `ADR-001`
* Short, descriptive title
* Store under:

```text
docs/architecture/adr/
```

Example:

```text
docs/architecture/adr/
├── ADR-001-modular-architecture.md
├── ADR-002-database-access-strategy.md
```

---

## Status Lifecycle

Common statuses:

* **Proposed** — Under discussion
* **Accepted** — Decision is active
* **Superseded** — Replaced by a newer ADR

Never delete ADRs. History matters.

---

## ❌ Bad Practice — No ADRs

Symptoms:

* Repeated discussions
* Conflicting implementations
* “Why are we doing this?” questions
* Architecture drifting silently

---

## ✅ Good Practice — Living ADRs

Benefits:

* Clear historical context
* Faster onboarding
* Better architectural consistency
* Safer refactoring

---

## ADRs in Practice (Senior Perspective)

Tips:

* Keep them short (1–2 pages max)
* Focus on *why*, not implementation details
* Capture trade-offs honestly
* Update status when superseded

> ADRs are about communication, not control.

---

## Relationship with Other Architecture Concepts

* **Boundaries & Ownership** — ADRs clarify responsibility
* **Layered vs Modular** — Captures structural decisions
* **DIP** — Documents dependency direction choices
* **KISS & YAGNI** — Justifies simplicity and restraint

---

## Key Takeaways

* ADRs capture architectural intent
* They prevent knowledge loss
* They enable consistent evolution

---

## Next Steps

* Create your first ADR
* Establish a lightweight ADR process
* Review ADRs periodically
