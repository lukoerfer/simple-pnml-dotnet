using System.Runtime.Serialization;

namespace SimplePNML
{
    public enum LineShape
    {
        [EnumMember(Value = "line")]
        Line,
        [EnumMember(Value = "curve")]
        Curve
    }
}
