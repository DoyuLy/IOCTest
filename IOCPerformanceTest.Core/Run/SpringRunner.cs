using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Spring.Context.Support;
using Spring.Context;

namespace IOCPerformanceTest.Core.Run
{
    public class SpringRunner : IRunner
    {
        public string Name
        {
            get { return "Spring.NET"; }
        }

        IApplicationContext context;
        string databaseManagerName;

        public void Init(RunType runType)
        {
           
            if (runType == RunType.Singleton)
                databaseManagerName = "DatabaseManager_Singleton";
            else
                databaseManagerName = "DatabaseManager_Transient";
            context = ContextRegistry.GetContext();
            var manager = (DatabaseManager)context.GetObject(databaseManagerName);

        }
        public void Start()
        {
            var manager = (DatabaseManager)context.GetObject(databaseManagerName);
            manager.Search("SELECT * FROM USER");
        }
    }
}
