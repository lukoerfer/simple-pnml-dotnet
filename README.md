# SimplePNML for .NET
Simple .NET implementation of the Petri Net Markup Language (PNML), limited to Place-Transition-(PT)-Nets

## Motivation
The [Petri Net Markup Language (PNML)](http://www.pnml.org/) was developed as an interchange format for petri nets and can describe the logical relations between the components as well as information required for visualization. It is highly extendable and provides support for a variety of different petri net types, which comes with the price of high complexity. Since most use cases and applications are focused on Place-Transition-(PT)-Nets, this library provides a simple way to access and modify this kind of petri nets programmatically.

## Installation

## Usage
Once the library is included into the project, you can use the static methods of the `PNML` class to either read existing petri nets (from a `string`, `Stream` or `FileInfo`) or create a new petri net container:

    PNML existing = PNML.Read(...);    
    PNML fresh = PNML.Create();

## License
The software is licensed under the [MIT license](https://github.com/lukoerfer/simple-pnml-dotnet/blob/master/LICENSE).
