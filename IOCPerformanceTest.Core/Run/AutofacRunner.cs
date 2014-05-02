using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Autofac.Configuration;
using Autofac;

namespace IOCPerformanceTest.Core.Run
{
    public class AutofacRunner :  IRunner
    {
        public string Name
        {
            get { return "Autofac"; }
        }

        IContainer container;
        public void Init(RunType runType)
        {
            var builder = new ContainerBuilder();

            if (runType == RunType.Singleton)
            {
                builder.RegisterType<DatabaseManager>().SingleInstance();
                builder.RegisterType<SqlDatabase>().As<IDatabase>().SingleInstance();
            }
            else
            {
                builder.RegisterType<DatabaseManager>();
                builder.RegisterType<SqlDatabase>().As<IDatabase>();
            }

            container = builder.Build();
            var manager = container.Resolve<DatabaseManager>();
        }

        public void Start()
        {
            var manager = container.Resolve<DatabaseManager>();
            manager.Search("SELECT * FROM USER");
        }
    }
}
