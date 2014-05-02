using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using NLite;
using NLite.Mini;

namespace IOCPerformanceTest.Core.Run
{
    public class NLiteRunner : IRunner
    {
        public string Name
        {
            get { return "NLite"; }
        }

        Kernel container;
        public void Init(RunType runType)
        {
            container = new NLite.Mini.Kernel();
            if (runType == RunType.Singleton)
                container
                    .Register(f => f.To<DatabaseManager>().Singleton())
                    .Register(f => f.Bind<IDatabase>().To<SqlDatabase>().Singleton());
            else
                container
                        .Register(f => f.To<DatabaseManager>().Transient())
                        .Register(f => f.Bind<IDatabase>().To<SqlDatabase>().Transient());
            var manager = container.Get<DatabaseManager>();

        }
        public void Start()
        {
            var manager = container.Get<DatabaseManager>();
            manager.Search("SELECT * FROM USER");
        }
    }
}
