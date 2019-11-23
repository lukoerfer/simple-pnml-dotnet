# SimplePNML for .NET
[![License](https://img.shields.io/badge/License-MIT-yellow.svg)](https://github.com/lukoerfer/simple-pnml-dotnet/blob/master/LICENSE)
[![Build](https://github.com/lukoerfer/simple-pnml-dotnet/workflows/test/badge.svg)](https://github.com/lukoerfer/simple-pnml-dotnet/actions)
[![Coverage](https://img.shields.io/coveralls/github/lukoerfer/simple-pnml-dotnet)](https://coveralls.io/github/lukoerfer/simple-pnml-dotnet?branch=master)

Simple .NET implementation of the Petri Net Markup Language (PNML), limited to Place-Transition-(PT)-Nets

> Check out [SimplePNML for JVM](https://github.com/lukoerfer/simple-pnml-jvm) to handle PNML files from JVM languages like Java, Kotlin or Groovy!

## Motivation
The [Petri Net Markup Language (PNML)](http://www.pnml.org/) was developed as an interchange format for petri nets and can describe the logical relations between the components as well as information required for visualization. It is highly extendable and provides support for a variety of different petri net types, which comes with the price of high complexity. Since most use cases and applications are focused on Place-Transition-(PT)-Nets, this library provides a simple way to access and modify this kind of petri nets programmatically.

## Installation


## Usage
SimplePNML implements the elements and relations defined by the PNML specification as simple classes with their respective properties, as described in the following class diagram:


The additional class `Document` is a container that represents a PNML file and its content. The utility functions of the static class `PNML` can be used to read and write `Document` instances:

``` csharp
Document example = PNML.Read(new FileInfo("example.pnml"));

PNML.Write(example, Console.Out);
```

As an example, the following code can be used to print the identifiers of all places on the first page of the first net in a given `Document` called `example` (ignoring sub-pages):

``` csharp
example.Nets.First().Pages.First().Places
    .ForEach(place => Console.Out.WriteLine(place.Id));
```

To build new petri nets just create new instances of the PNML elements. It is not necessary to explicitly define identifiers for the instances, as they will be generated automatically (using `Guid.NewGuid().ToString()`).

``` csharp
// Create a place, a transition and an arc
Place place = new Place() 
{
    InitialMarking = 1
};
Transition transition = new Transition("my-id");
Arc arc = new Arc()
{
    Inscription = 1
};

// Let the arc connect the place and the transition
arc.Connect(place, transition);

// Add all the elements to a new page
Page page = new Page();
page.Places.Add(page);
page.Transitions.Add(transition);
page.Arcs.Add(arc);
```

SimplePNML also provides a fluent API to create petri nets. The same result as in the previous example can be achieved in the following way:

``` csharp
// Create place and transition beforehand to use the references when creating the arc
Place place = new Place().WithInitialMarking(1);
Transition transition = new Transition("my-id");

Page page = new Page()
    .WithPlaces(place)
    .WithTransitions(transition)
    .WithArcs(new Arc().WithInscription(1).Connecting(place, transition));
```

## Differences between .NET and JVM version

* The element relations are implemented via (auto-)properties in .NET and via fields with getters and optional setters in the JVM (with some help of Lombok).
* Some names are changed to follow language-specific naming conventions:
  * Methods are named using `PascalCase` in the .NET version, but using `camelCase` in the JVM version.
  * Enum members are named using `PascalCase` in the .NET version, but using `UPPER_CASE` in the JVM version.
* A lot more constructors and fluent methods are provided in the JVM version, because initialization blocks and optional or named parameters are not supported.
* `Label` instances for element names, inscriptions and initial markings must be constructed manually when using the JVM version, because implicit type conversion is not supported.
* The points of an `Edge` or the content of a `ToolData` element cannot be defined via tuples when using the JVM version.

## License
This software is licensed under the [MIT license](https://github.com/lukoerfer/simple-pnml-dotnet/blob/master/LICENSE).
