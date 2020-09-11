namespace SimplePNML
{
    /// <summary>
    /// Marks elements that are graphically represented by an edge
    /// </summary>
    public interface IEdge
    {
        EdgeGraphics Graphics { get; set; }
    }
}
