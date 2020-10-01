﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Xml.Serialization;

namespace SimplePNML
{
    /// <summary>
    /// Represents a PNML place
    /// </summary>
    [Equals(DoNotAddEqualityOperators = true)]
    [XmlType("place")]
    public class Place : IConnectable, ICollectable, INamed, INode, IToolExtendable
    {
        private string id;
        private List<ToolSpecific> toolSpecifics = new List<ToolSpecific>();

        [XmlElement("id")]
        public string Id
        {
            get => id ??= Guid.NewGuid().ToString();
            set => id = value;
        }

        /// <summary>
        /// Gets or sets a label containing the name of the place
        /// </summary>
        [XmlElement("name")]
        public Label Name { get; set; } = new Label();

        /// <summary>
        /// Gets or sets how to visualize this place
        /// </summary>
        [XmlElement("graphics")]
        public NodeGraphics Graphics { get; set; } = new NodeGraphics();

        /// <summary>
        /// Gets or sets a label defining the initial marking of the place
        /// </summary>
        /// <remarks>This label should contain a positive integer</remarks>
        [XmlElement("initialMarking")]
        public Label InitialMarking { get; set; } = new Label();

        /// <summary>
        /// 
        /// </summary>
        public List<ToolSpecific> ToolSpecifics
        {
            get => toolSpecifics;
            set => toolSpecifics = new List<ToolSpecific>(value);
        }

        /// <summary>
        /// Creates a new place
        /// </summary>
        public Place() { }

        /// <summary>
        /// Creates a new place
        /// </summary>
        /// <param name="id"></param>
        public Place(string id)
        {
            Id = id;
        }

        public IEnumerable<ICollectable> Collect()
        {
            return new Collector(this)
                .Include(Name)
                .Include(Graphics)
                .Include(InitialMarking)
                .Include(ToolSpecifics)
                .Collect();
        }

        [Browsable(false)]
        [EditorBrowsable(EditorBrowsableState.Never)]
        public bool ShouldSerializeName() => !Name.IsDefault();

        [Browsable(false)]
        [EditorBrowsable(EditorBrowsableState.Never)]
        public bool ShouldSerializeGraphics() => !Graphics.IsDefault();

        [Browsable(false)]
        [EditorBrowsable(EditorBrowsableState.Never)]
        public bool ShouldSerializeInitialMarking() => !InitialMarking.IsDefault();

    }
}
