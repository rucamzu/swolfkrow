# *Swolfkrow*

*Swolfkrow* (pronounced */ˈwɜː(r)kˌfləʊs/*) is a Domain Specific Language (DSL) designed to declaratively compose [asynchronous workflows](#asynchronous-workflows) through a fluent API.

## Asynchronous workflows

Asynchronous workflows are asynchronous computations that yield an stream of *events* signaling progress, outcomes, and errors.

In practice, asynchronous workflows are objects implementing the [`IAsyncEnumerable<out T>`][system.collections.generic.iasyncenumerable] interface, with a couple of particularities:

- The generic type `T`, named `TEvent` across the *Swolfkrow* library, represents the base type from which the types of all events potentially yielded by the asynchronous workflow derive.
- Yielded `TEvent` objects are meant to describe significant events occured during the workflow's execution.
- When enumerated, asynchronous workflows can execute arbitrary asynchronous logic in between yielded `TEvent` objects.

### The `Workflow<TEvent>` class

Swolfkrow represents asynchronous workflows with an explicit [`Workflow<TEvent>`][swolfkrow.workflow] class that implements the [`IAsyncEnumerable<out T>`][system.collections.generic.iasyncenumerable] interface.

The `Workflow<TEvent>` class exists both as a semantic anchor with a self-descriptive name, and as a convenient container for the fluent API. It is meaningful during the composition of asynchronous workflows, however the resulting workflow objects behave as expected from any object implementing the [`IAsyncEnumerable<out T>`][system.collections.generic.iasyncenumerable] interface, meaning they will execute their logic and yield events only when enumerated.


## Overview

The following subsections briefly describe the different types of asynchronous workflow compositions that can be performed through *Swolfkrow*'s fluent API operators.

### Initiations

The family of `Start` method overloads provides a single entry point to the DSL:

```csharp
record EventBase(string Description);

IAsyncEnumerable<EventBase> Step1() { ... }

IAsyncEnumerable<EventBase> ComposeWorkflow()
    => Workflow
        .Start(Step1);
```

### Continuations

Asynchronous workflows can be composed as sequences of simpler workflows, where one workflow starts when the previous one finishes yielding events:

```csharp
record EventBase(string Description);

IAsyncEnumerable<EventBase> Step1() { ... }
IAsyncEnumerable<EventBase> Step2() { ... }

IAsyncEnumerable<EventBase> ComposedWorkflow()
    => Workflow
        .Start(Step1)
        .Then(Step2);
```

### Stateful continuations

Workflow continuations can be based on state explicitly folded from the events yielded by the workflow:

```csharp
record EventBase(string Description);

IAsyncEnumerable<EventBase> Step1() { ... }
IAsyncEnumerable<EventBase> Step2(int someInfo) { ... }

IAsyncEnumerable<EventBase> ComposedWorkflow()
    => Workflow
        .Start(Step1)
        .Then(
            createContinuation: currentState => currentState * 2,
            computeNextState: (currentState, nextEvent) => currentState + 1,
            initialState: 0);
```

### Intercalations

Asynchronous workflows can be intercalated and executed in the middle of other asynchronous workflows, triggered by events of a specific type and/or satisfying a predicate:

```csharp
record EventBase(string Description);
record SomethingHappened(string Description) : EventBase(Description);

IAsyncEnumerable<EventBase> Step1() { ... }
IAsyncEnumerable<EventBase> Step2(SomethingHappened somethingHappened) { ... }

IAsyncEnumerable<EventBase> ComposedWorkflow()
    => Workflow
        .Start(Step1)
        .When<SomethingHappened>().Then(Step2);
```

### Side effects

Side effects can be deliberately injected into an asynchronous workflow:

```csharp
record EventBase(string Description);

IAsyncEnumerable<EventBase> Step1() { ... }
IAsyncEnumerable<EventBase> Step2() { ... }

void LogEvent(EventBase someEvent)
    => Console.WriteLine($"Something happened: {EventBase}")

IAsyncEnumerable<EventBase> ComposedWorkflow()
    => Workflow
        .Start(Step1)
        .Then(Step2)
        .Do(LogEvent);
```

### Interruptions

Asynchronous workflows can be interrupted based on a condition computed on each of the yielded events:

```csharp
public record EventBase(string Description);
public record SomeError(string Description, Exception Exception) : EventBase(Description);

IAsyncEnumerable<EventBase> Step1() { ... }
IAsyncEnumerable<EventBase> Step2(int someInfo) { ... }

bool IsError(EventBase nextEvent) => nextEvent is SomeError;

IAsyncEnumerable<EventBase> ComposedWorkflow()
    => Workflow
        .Start(Step1)
        .Then(Step2, 42)
        .Until(IsError);
```


[system.collections.generic.iasyncenumerable]: https://learn.microsoft.com/en-us/dotnet/api/system.collections.generic.iasyncenumerable-1

[swolfkrow.workflow]: ./src/Swolfkrow/Workflow.cs