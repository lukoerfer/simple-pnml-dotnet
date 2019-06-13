namespace SimplePNML
{
    /// <summary>
    /// Encapsulates PNML elements that can be identified
    /// </summary>
    public interface IIdentifiable
    {
        /// <summary>
        /// Gets the identifier of this element
        /// </summary>
        string Id { get; }

    }
}
