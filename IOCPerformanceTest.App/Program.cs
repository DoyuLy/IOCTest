using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using IOCPerformanceTest.Core;
using IOCPerformanceTest.Core.Run;

namespace IOCPerformanceTest.App
{
    public class Program
    {
        static void Main(string[] args)
        {
            
            CodeTimer.Initialize();

            Console.WriteLine("IOC - Singleton");
            // Autofac Singleton
            RunManager.Start(new AutofacRunner(), RunType.Singleton);
            // Castle Windsor
            RunManager.Start(new WindsorRunner(), RunType.Singleton);
            // Unity
            RunManager.Start(new UnityRunner(), RunType.Singleton);
            // Spring.NET
            RunManager.Start(new SpringRunner(), RunType.Singleton);
            // StructureMap
            RunManager.Start(new StructureMapRunner(), RunType.Singleton);
            // Ninject
            RunManager.Start(new NinjectRunner(), RunType.Singleton);
            // NLite
            RunManager.Start(new NLiteRunner(), RunType.Singleton);


            Console.WriteLine("===================================");
            Console.WriteLine("IOC - Transient");
            // Autofac Singleton
            RunManager.Start(new AutofacRunner(), RunType.Transient);
            // Castle Windsor
            RunManager.Start(new WindsorRunner(), RunType.Transient);
            // Unity
            RunManager.Start(new UnityRunner(), RunType.Transient);
            // Spring.NET
            RunManager.Start(new SpringRunner(), RunType.Transient);
            // StructureMap
            RunManager.Start(new StructureMapRunner(), RunType.Transient);
            // Ninject
            RunManager.Start(new NinjectRunner(), RunType.Transient);
            // NLite
            RunManager.Start(new NLiteRunner(), RunType.Transient);
            Console.Read();
        }
     
    }
}
