using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Practices.Unity;

namespace IOCPerformanceTest.Core.Run
{
    public class UnityRunner : IRunner
    {
        public string Name
        {
            get { return "Unity"; }
        }

        UnityContainer container;
        public void Init(RunType runType)
        {
            container = new UnityContainer();
            if (runType == RunType.Singleton)
            {
                container.RegisterType<DatabaseManager>(new ContainerControlledLifetimeManager());
                container.RegisterType<IDatabase, SqlDatabase>(new ContainerControlledLifetimeManager());
            }
            else
            {
                container.RegisterType<DatabaseManager>(new TransientLifetimeManager());
                container.RegisterType<IDatabase, SqlDatabase>(new TransientLifetimeManager());
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
