# SimplePNML for .NET
Simple .NET implementation of the Petri Net Markup Language (PNML), limited to Place-Transition-(PT)-Nets

## Motivation
The [Petri Net Markup Language (PNML)](http://www.pnml.org/) was developed as an interchange format for petri nets and can describe the logical relations between the components as well as information required for visualization. It is highly extendable and provides support for a variety of different petri net types, which comes with the price of high complexity. Since most use cases and applications are focused on Place-Transition-(PT)-Nets, this library provides a simple way to access and modify this kind of petri nets programmatically.

## Installation

## Usage
Once the library is included into the project, you can use the static methods of the `PNML` class to either import existing petri nets (e.g. from a `string` or `FileInfo`) or to create a new container.


The API provides some features to improve the work flow when building new petri nets. This includes factory methods to create various net elements:

    Net.Create(string id = null, string type = null)

    Page.Create(string id = null, Label name = null)
    
    Place.Create(string id = null, Graphics graphics = null, Label name = null, Label initialMarking = null)
    
    Transition.Create(string id = null, Graphics graphics = null, Label name = null)
    
    Arc.Create(string id = null, IConnectable source = null, IConnectable target = null, Label inscription = null)
    
    Label.Absolute(int x, int y, string text)
    
    Label.Relative(int x, int y, string text)
    
> Of course, the elements can also be created using the respective constructors. The factory methods simply provide a clean and less verbose API with automatic generation of IDs (via `Guid.NewGuid().ToString()`).
    
In addition, the API provides fluent methods (with prefix `With`) to add sub elements:

    pnml.WithNets(params Net[] nets)

    net.WithPages(params Page[] pages)
    
    page.WithPages(params Page[] pages)
    
    page.WithPlaces(params Place[] places)
    
    page.WithTransitions(params Transition[] transitions)
    
    page.WithArcs(params Arc[] arcs)

## License
The software is licensed under the [MIT license](https://github.com/lukoerfer/simple-pnml-dotnet/blob/master/LICENSE).
