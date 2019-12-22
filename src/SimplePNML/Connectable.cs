namespace SimplePNML
{
    /// <summary>
    /// Base of all elements in place/transition nets that can be connected via arcs
    /// </summary>
    public abstract class Connectable : Identifiable
    {
        /// <summary>
        /// Implicitly extracts the identifier from a connectable element
        /// </summary>
        /// <param name="connectable"></param>
        public static implicit operator string(Connectable connectable) => connectable.Id;
    }
}
