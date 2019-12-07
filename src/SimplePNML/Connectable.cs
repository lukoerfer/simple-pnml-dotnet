namespace SimplePNML
{
    /// <summary>
    /// Marks all elements in place/transition nets that can be connected via arcs
    /// </summary>
    public abstract class Connectable : Identifiable
    {
        /// <summary>
        /// Allows to directly provide a connectable element instead of its identifier
        /// </summary>
        /// <param name="connectable"></param>
        public static implicit operator string(Connectable connectable) => connectable.Id;
    }
}
