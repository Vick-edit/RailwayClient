using System;
using RailwayClient.DataAccess.Commands;
using RailwayClient.DataAccess.Queries;
using RailwayClient.DataAccess.SettingsEF;
using RailwayClient.Domain;
using RailwayClient.Tools;
using RailwayClient.View;
using RailwayClient.ViewModel;
using RestSharp.Serialization;
using SimpleInjector;
using SimpleInjector.Lifestyles;

namespace RailwayClient
{
    /// <summary>
    ///     Входная точка программы, используется вместо <see cref="App"/>, для внедрения <see cref="SimpleInjector"/>
    /// </summary>
    public class Program
    {
        [STAThread]
        public static void Main()
        {
            var container = SetupDependencies();

            // Any additional other configuration, e.g. of your desired MVVM toolkit.

            RunApplication(container);
        }

        private static void RunApplication(Container container)
        {
            try
            {
                var app = new App();
                var mainWindow = container.GetInstance<MainWindow>();
                app.Run(mainWindow);
            }
            catch (Exception error)
            {
                var logger = container?.GetInstance<IExceptionLogger>();
                logger?.Log(error);
                throw;
            }
        }

        private static Container SetupDependencies()
        {
            var container = new Container();
            container.Options.DefaultScopedLifestyle = new ThreadScopedLifestyle();

            container.Register<MainWindow>(Lifestyle.Transient);
            container.Register<MainWindowViewModel>(Lifestyle.Transient);
            container.Register<IServiceProvider>(() => container, Lifestyle.Singleton);

            container.Register<IUnitOfWork, RailwayContext>(Lifestyle.Scoped);
            container.Register<IExceptionLogger, TextExceptionLogger>(Lifestyle.Singleton);


            container.Register<IRestSerializer, JsonNetSerializer>(Lifestyle.Transient);
            container.Register<IRailwayRestClient, RailwayRestClient>(Lifestyle.Transient);
            container.Register<ICatalogueUpdater, CatalogueUpdater>(Lifestyle.Transient);
            container.Register<IExcelReporter, ExcelReporter>(Lifestyle.Transient);

            container.Register<IQueryBuilder, QueryBuilder>(Lifestyle.Transient);
            container.Register<ICommandBuilder, CommandBuilder>(Lifestyle.Transient);
            container.Register(typeof(IQuery<,>), typeof(IQuery<,>).Assembly, Lifestyle.Transient);
            container.Register(typeof(ICommand<>), typeof(ICommand<>).Assembly, Lifestyle.Transient);

            container.Verify();
            return container;
        }


    }
}