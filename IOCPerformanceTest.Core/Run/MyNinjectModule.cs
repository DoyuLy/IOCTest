using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Ninject.Modules;

namespace IOCPerformanceTest.Core.Run
{
    public class MyNinjectModule : NinjectModule
    {
        private RunType _runType = RunType.Transient;

        public MyNinjectModule(RunType runType)
        {
            _runType = runType;
        }

        #region NinjectModule Member

        public override void Load()
        {
            if (_runType == RunType.Singleton)
            {
                Bind<DatabaseManager>().ToSelf().InSingletonScope();
                Bind<IDatabase>().To<SqlDatabase>().InSingletonScope();
            }
            else
            {
                Bind<DatabaseManager>().ToSelf();
                Bind<IDatabase>().To<SqlDatabase>();
            }
           
        }

        #endregion
    }
}
