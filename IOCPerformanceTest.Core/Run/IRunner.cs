using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace IOCPerformanceTest.Core.Run
{
    public interface IRunner
    {
        string Name { get; }
        void Init(RunType runType);
        void Start();
    }
}
