namespace SimplePNML
{
    /// <summary>
    /// Marks the elements that have their graphics described by a node
    /// </summary>
    public interface INode
    {
        NodeGraphics Graphics { get; set; }
    }
}
