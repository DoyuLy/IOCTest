using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace IOCPerformanceTest.Core.Run
{
    /// <summary>
    /// 运行状态
    /// </summary>
    public enum RunType
    {
        /// <summary>
        /// 单例
        /// </summary>
        Singleton,

        /// <summary>
        /// 瞬时
        /// </summary>
        Transient
    }
}
