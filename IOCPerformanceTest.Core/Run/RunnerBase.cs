using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace IOCPerformanceTest.Core.Run
{
    public abstract class RunnerBase
    {
        private int _iteration = Convert.ToInt32(System.Configuration.ConfigurationSettings.AppSettings["Iteration"] ?? "10000");
        internal int Iteration
        {
            get { return _iteration; }
        }

        internal void Time(Action action)
        {
            CodeTimer.Time(Name, Iteration, action);
        }

        public virtual void Init(RunType runType) { }
        protected abstract string Name { get; }
    }
}
