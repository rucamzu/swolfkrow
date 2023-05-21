# Swolfkrow

Swolfkrow (pronounced */ˈwɜː(r)kˌfləʊs/*) is a DSL designed to declaratively compose asynchronous workflows based on the [`IAsyncEnumerable<out T>`][system.collections.generic.iasyncenumerable] interface.

## Workflows

In the context of this library, an asynchronous workflow is defined as a function that takes any number of parameters, executes arbitrary business logic, and returns an asynchronous stream of events signaling progress, outcomes, and errors.

## Usage

Asynchronous workflows can be composed as sequences of simpler workflows:

```csharp
IAsyncEnumerable<SomeEvent> Step1() { ... }
IAsyncEnumerable<SomeEvent> Step2(int someInfo) { ... }

IAsyncEnumerable<SomeEvent> ComposedWorkflow()
    => Workflow
        .Start(Step1)
        .Then(Step2, 42);
```

## License and copyright notice

This library is licensed under the [MIT](./LICENSE) license.

This library is copyright © Rubén Campos Zurriaga 2023. All rights reserved.


[system.collections.generic.iasyncenumerable]: https://learn.microsoft.com/en-us/dotnet/api/system.collections.generic.iasyncenumerable-1