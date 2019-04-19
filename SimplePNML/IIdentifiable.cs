namespace SimplePNML
{
    /// <summary>
    /// Encapsulates PNML elements that can be identified
    /// </summary>
    public interface IIdentifiable
    {
        /// <summary>
        /// Returns an (at best unique) identifier
        /// </summary>
        string Id { get; }
    }
}
