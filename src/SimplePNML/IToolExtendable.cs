﻿using System.Collections.Generic;

namespace SimplePNML
{
    /// <summary>
    /// 
    /// </summary>
    public interface IToolExtendable
    {
        /// <summary>
        /// 
        /// </summary>
        IList<ToolSpecific> ToolSpecifics { get; set; }
    }
}
