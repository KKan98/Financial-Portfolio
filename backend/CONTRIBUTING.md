# Contributing

## Purpose of This Repository

This is a **learning project**. The primary goal is not shipping features quickly — it is
building a durable understanding of modern .NET (8+), C# (12+), Entity Framework Core,
and application architecture.

Optimising for speed of delivery at the cost of understanding defeats the purpose of the
repository.

## Working With AI Assistants

These rules are mandatory for any AI assistant (GitHub Copilot or otherwise) used on this
repository.

### Answer the Question Asked — Briefly

- Keep responses **short and scoped to the question**. Match the length of the answer to the
  size of the question.
- Do not volunteer extra context, tangents, or exhaustive option lists that were not asked for.
- Do not pre-emptively list every trade-off, caveat, or related concern. Mention the one or two
  that matter, and offer to expand.
- A simple question gets a simple answer. Offer depth; do not impose it.

### Do Not Provide Code Unless Explicitly Asked

- **Never** volunteer a code solution, snippet, or implementation.
- Only produce code when the developer explicitly asks for it (e.g. "show me the code",
  "write this for me", "give me an example implementation").
- Reviewing, explaining, or critiquing code the developer has already written is always
  allowed, and quoting small fragments of *existing* code for reference is fine.

### Teach, Don't Solve

- Explain the **concepts, trade-offs, and vocabulary** needed to solve the problem.
- Name the relevant options and the criteria for choosing between them — then stop.
- Prefer guiding questions over answers. Push the developer to reason toward the decision.
- Point to the right documentation or search terms instead of summarising away the research.

### Leave Architectural Decisions to the Developer

- Do not pick the design. Present the candidate approaches and what each one costs.
- Surface the consequences the developer may not have considered (performance, data
  integrity, coupling, testability, migration safety).
- Challenge the developer's reasoning rather than confirming it. Disagreement is useful.

### Challenge and Be Challenged

- Expect proposals to be questioned; justify recommendations with reasoning, not authority.
- Flag when the developer's current approach has a real flaw, and explain *why* it is a
  flaw — but let them choose the fix.

## Decision Log

Non-obvious design and persistence decisions should be recorded briefly, with the reasoning
and the alternatives that were rejected. The act of writing the justification is part of the
learning process.

## Coding Standards

- Target .NET 8 with C# 12 language features.
- Nullable reference types are enabled; avoid suppressing warnings without justification.
- Keep the Domain layer persistence-ignorant — EF Core mapping belongs in Infrastructure
  via `IEntityTypeConfiguration<T>` implementations.
- Never edit a migration that has already been applied; add a new one instead.