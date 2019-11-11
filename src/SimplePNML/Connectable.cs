namespace SimplePNML
{
    /// <summary>
    /// Marks all elements that can be connected via arcs
    /// </summary>
    public abstract class Connectable : Identifiable
    {
        /// <summary>
        /// 
        /// </summary>
        /// <param name="connectable"></param>
        public static implicit operator string(Connectable connectable) => connectable.Id;
    }
}
