using System.Collections.Generic;

namespace SimplePNML
{
    public interface IToolExtendable
    {
        List<ToolSpecific> ToolSpecificData { get; set; }
    }
}
