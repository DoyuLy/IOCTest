using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace IOCPerformanceTest.Core.Run
{
    public class RunManager
    {
        public static void Start(IRunner runner)
        {
            Start(runner, RunType.Transient);
        }

        public static void Start(IRunner runner, RunType runType)
        {
            runner.Init(runType);
            CodeTimer.Time(
                runner.Name
                , Convert.ToInt32(System.Configuration.ConfigurationSettings.AppSettings["Iteration"] ?? "10000")
                , ()=>runner.Start());
        }
    }
}
