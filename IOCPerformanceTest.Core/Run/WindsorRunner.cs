using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Castle.Windsor;
using Castle.MicroKernel.Registration;

namespace IOCPerformanceTest.Core.Run
{
    public class WindsorRunner : IRunner
    {
        public string Name
        {
            get { return "Castle Windsor"; }
        }

        WindsorContainer container;
        public void Init(RunType runType)
        {
            container = new WindsorContainer();
            if (runType == RunType.Singleton)
            {
                container.Register(Component.For(typeof(DatabaseManager)).LifeStyle.Singleton);
                container.Register(Component.For(typeof(IDatabase)).ImplementedBy(typeof(SqlDatabase)).LifeStyle.Singleton);
            }
            else
            {
                container.Register(Component.For(typeof(DatabaseManager)).LifeStyle.Transient);
                container.Register(Component.For(typeof(IDatabase)).ImplementedBy(typeof(SqlDatabase)).LifeStyle.Transient);
            }
            var manager = container.Resolve<DatabaseManager>();
        }

        public void Start()
        {
            var manager = container.Resolve<DatabaseManager>();
            manager.Search("SELECT * FROM USER");
        }
    }
}
