# Swolfkrow

Swolfkrow (pronounced */ˈwɜː(r)kˌfləʊs/*) is a DSL designed to declaratively compose asynchronous workflows based on the [`IAsyncEnumerable<out T>`][system.collections.generic.iasyncenumerable] interface.

## Workflows

In the context of this library, an asynchronous workflow is defined as a function that takes any number of parameters, executes arbitrary business logic, and returns an asynchronous stream of events signaling progress, outcomes, and errors.

## Usage

### Workflow continuations

Asynchronous workflows can be composed as sequences of simpler workflows, where one workflow is continued by another:

```csharp
public record SomeEvent(string Description);

IAsyncEnumerable<SomeEvent> Step1() { ... }
IAsyncEnumerable<SomeEvent> Step2(int someInfo) { ... }

IAsyncEnumerable<SomeEvent> ComposedWorkflow()
    => Workflow
        .Start(Step1)
        .Then(Step2, 42);
```

### Stateful continuations

Workflow continuations can be based on state explicitly folded from the events yielded by the workflow:

```csharp
public record SomeEvent(string Description);

IAsyncEnumerable<SomeEvent> Step1() { ... }
IAsyncEnumerable<SomeEvent> Step2(int someInfo) { ... }

IAsyncEnumerable<SomeEvent> ComposedWorkflow()
    => Workflow
        .Start(Step1)
        .Then(
            createContinuation: currentState => currentState * 2,
            computeNextState: (currentState, nextEvent) => currentState + 1,
            initialState: 0);
```

### Event continuations

Individual events yielded by an asynchronous workflow can be continued by other workflows that are intercalated right after:

```csharp
public record SomeEvent(string Description);

IAsyncEnumerable<SomeEvent> Step1() { ... }
IAsyncEnumerable<SomeEvent> Step2(SomeEvent someEvent) { ... }

IAsyncEnumerable<SomeEvent> ComposedWorkflow()
    => Workflow
        .Start(Step1)
        .ThenForEach(Step2);
```

Optionally, it is possible to continue only events of a specific sub-type and/or that satisfy a predicate:

```csharp
public record SomeEvent(string Description);
public record SomeSpecificEvent(string Description, ...) : SomeEvent(Description);

IAsyncEnumerable<SomeEvent> Step1() { ... }
IAsyncEnumerable<SomeEvent> Step2(SomeSpecificEvent someSpecificEvent) { ... }

bool ContinueIf(SomeSpecificEvent someSpecificEvent) { ... }

IAsyncEnumerable<SomeEvent> ComposedWorkflow()
    => Workflow
        .Start(Step1)
        .ThenForEach(Step2, ContinueIf);
```

### Side effects

Side effects can be deliberately injected into an asynchronous workflow:

```csharp
public record SomeEvent(string Description);

IAsyncEnumerable<SomeEvent> Step1() { ... }
IAsyncEnumerable<SomeEvent> Step2(int someInfo) { ... }

void LogEvent(SomeEvent someEvent)
    => Console.WriteLine($"Something happened: {SomeEvent}")

IAsyncEnumerable<SomeEvent> ComposedWorkflow()
    => Workflow
        .Start(Step1)
        .Then(Step2, 42)
        .WithSideEffect(LogEvent);
```

### Interruptions

Asynchronous workflows can be interrupted based on a condition computed on each of the yielded events:

```csharp
public record SomeEvent(string Description);
public record SomeError(string Description, Exception Exception) : SomeEvent(Description);

IAsyncEnumerable<SomeEvent> Step1() { ... }
IAsyncEnumerable<SomeEvent> Step2(int someInfo) { ... }

bool IsError(SomeEvent nextEvent) => nextEvent is SomeError;

IAsyncEnumerable<SomeEvent> ComposedWorkflow()
    => Workflow
        .Start(Step1)
        .Then(Step2, 42)
        .Until(IsError);
```


[system.collections.generic.iasyncenumerable]: https://learn.microsoft.com/en-us/dotnet/api/system.collections.generic.iasyncenumerable-1