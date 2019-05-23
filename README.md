# SimplePNML for .NET
Simple .NET implementation of the Petri Net Markup Language (PNML), limited to Place-Transition-(PT)-Nets

> Check out [SimplePNML for JVM](https://github.com/lukoerfer/simple-pnml-jvm) to handle PNML files from JVM languages like Java, Kotlin or Groovy!

## Motivation
The [Petri Net Markup Language (PNML)](http://www.pnml.org/) was developed as an interchange format for petri nets and can describe the logical relations between the components as well as information required for visualization. It is highly extendable and provides support for a variety of different petri net types, which comes with the price of high complexity. Since most use cases and applications are focused on Place-Transition-(PT)-Nets, this library provides a simple way to access and modify this kind of petri nets programmatically.

## Installation

## Usage
Once the library is included into the project, the static methods of the `PNML` class can be used to either import existing petri nets (e.g. from a `string` or `FileInfo`) or to create a new container. Simply load a sample PT-net from [PNML.org](http://www.pnml.org/version-2009/version-2009.php) to get used to the API (and the PNML model in general).

The API mainly implements the elements defined by the PNML as simple classes with their respective properties. However, some additional features to improve the work flow are provided:

#### 1. Factory methods to create elements

    Net.Create(string id = null, string type = null)

    Page.Create(string id = null, Label name = null)
    
    Place.Create(string id = null, Graphics graphics = null, Label name = null, Label initialMarking = null)
    
    Transition.Create(string id = null, Graphics graphics = null, Label name = null)
    
    Arc.Create(string id = null, IConnectable source = null, IConnectable target = null, Label inscription = null)
    
    Label.Simple(string text)
    
    Label.Absolute(int x, int y, string text)
    
    Label.Relative(int x, int y, string text)
    
Of course, the elements can also be created using the respective constructors. The factory methods simply provide a clean and less verbose interface with automatic generation of IDs (via `Guid.NewGuid().ToString()`).
    
#### 2. Fluent methods to add sub elements

    pnml.WithNets(params Net[] nets)

    net.WithPages(params Page[] pages)
    
    page.WithPages(params Page[] pages)
    
    page.WithPlaces(params Place[] places)
    
    page.WithTransitions(params Transition[] transitions)
    
    page.WithArcs(params Arc[] arcs)

#### 3. Additional utility methods for `Arc` setup

    arc.SetSource(IConnectable source)
    
    arc.SetTarget(IConnectable target)
    
    arc.Connect(IConnectable source, IConnectable target)

## License
The software is licensed under the [MIT license](https://github.com/lukoerfer/simple-pnml-dotnet/blob/master/LICENSE).
