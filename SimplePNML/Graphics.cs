using System.Xml.Serialization;

namespace SimplePNML
{
    /// <summary>
    /// 
    /// </summary>
    public class Graphics
    {
        /// <summary>
        /// 
        /// </summary>
        [XmlElement("position")]
        public Coordinates Position { get; set; }

        /// <summary>
        /// 
        /// </summary>
        [XmlElement("offset")]
        public Coordinates Offset { get; set; }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="x"></param>
        /// <param name="y"></param>
        /// <returns></returns>
        public static Graphics Absolute(int x, int y)
        {
            return new Graphics()
            {
                Position = new Coordinates(x, y)
            };
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="x"></param>
        /// <param name="y"></param>
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
