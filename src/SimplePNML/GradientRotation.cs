using System.Runtime.Serialization;

namespace SimplePNML
{
    public enum Gradient
    {
        [EnumMember(Value = "vertical")]
        Vertical,
        [EnumMember(Value = "horizontal")]
        Horizontal,
        [EnumMember(Value = "diagonal")]
        Diagonal
    }
}
