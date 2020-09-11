namespace SimplePNML
{
    /// <summary>
    /// Marks all petri net elements that have a name
    /// </summary>
    public interface INamed
    {
        /// <summary>
        /// 
        /// </summary>
        Label Name { get; set; }
    }
}
