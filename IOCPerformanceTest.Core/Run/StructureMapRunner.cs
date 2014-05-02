using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using StructureMap;

namespace IOCPerformanceTest.Core.Run
{
    public class StructureMapRunner : IRunner
    {
        public string Name
        {
            get { return "StructureMap"; }
        }

        public void Init(RunType runType)
        {
            ObjectFactory.Initialize(container =>
            {
                if (runType == RunType.Singleton)
                {
                    container.For<DatabaseManager>().Singleton();
                    container.For<IDatabase>().Singleton().Use<SqlDatabase>();
                }
                else
                {
                    container.For<DatabaseManager>();
                    container.For<IDatabase>().Use<SqlDatabase>();
                }

            });

            var manager = ObjectFactory.GetInstance<DatabaseManager>();
        }
        public void Start()
        {
            var manager = ObjectFactory.GetInstance<DatabaseManager>();
            manager.Search("SELECT * FROM USER");
        }
    }
}
