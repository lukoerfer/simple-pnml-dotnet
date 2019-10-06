using System.Runtime.Serialization;

namespace SimplePNML
{
    public enum LineStyle
    {
        [EnumMember(Value = "solid")]
        Solid,
        [EnumMember(Value = "dash")]
        Dash,
        [EnumMember(Value = "dot")]
        Dot
    }
}
