using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Ninject;

namespace IOCPerformanceTest.Core.Run
{
    public class NinjectRunner :  IRunner
    {
        public string Name
        {
            get { return "Ninject"; }
        }

        IKernel kernel;
        public void Init(RunType runType)
        {
            kernel = new StandardKernel(new MyNinjectModule(runType));
            var manager = kernel.Get<DatabaseManager>();
        }
        public void Start()
        {
            var manager = kernel.Get<DatabaseManager>();
            manager.Search("SELECT * FROM USER");
        }
    }
}
