using System.Xml.Serialization;

namespace SimplePNML
{
    /// <summary>
    /// Stores absolute or relative position information
    /// </summary>
    public class Graphics
    {
        /// <summary>
        /// Gets or sets absolute coordinates
        /// </summary>
        [XmlElement("position")]
        public Coordinates Position { get; set; }

        /// <summary>
        /// Gets or sets relative coordinates
        /// </summary>
        [XmlElement("offset")]
        public Coordinates Offset { get; set; }

        /// <summary>
        /// Creates an absolute position information
        /// </summary>
        /// <param name="x">An absolute X coordinate</param>
        /// <param name="y">An absolute Y coordinate</param>
        /// <returns></returns>
        public static Graphics Absolute(int x, int y)
        {
            return new Graphics()
            {
                Position = new Coordinates(x, y)
            };
        }

        /// <summary>
        /// Creates a relative position information
        /// </summary>
        /// <param name="x">A relative X coordinate</param>
        /// <param name="y">A relative Y coordinate</param>
        /// <returns></returns>
        public static Graphics Relative(int x, int y)
        {
            return new Graphics()
            {
                Offset = new Coordinates(x, y)
            };
        }

    }
}
