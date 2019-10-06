using System.Runtime.Serialization;

namespace SimplePNML
{
    public enum FontDecoration
    {
        [EnumMember(Value = "underline")]
        Underline,
        [EnumMember(Value = "overline")]
        Overline,
        [EnumMember(Value = "line-through")]
        LineThrough
    }
}
