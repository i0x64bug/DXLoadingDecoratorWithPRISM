using DevExpress.Xpf.Core;
using DevExpress.Xpf.Docking;
using DevExpress.Xpf.Prism;
using LoadingDecoratorWithPrism.Core.RegionAdapters;
using LoadingDecoratorWithPrism.ViewModels;
using LoadingDecoratorWithPrism.Views;
using Prism.Ioc;
using Prism.Regions;
using Prism.Unity;
using System.Windows;
using System.Windows.Threading;

namespace LoadingDecoratorWithPrism
{
    public partial class App : PrismApplication
    {
        public App()
        {
            Dispatcher.UnhandledException += OnDispatcherUnhandledException;
        }

        protected override Window CreateShell()
        {
            App.Current.MainWindow = new MainWindow
            {
                DataContext = new MainWindowViewModel()
            };
            return App.Current.MainWindow;
        }

        protected override void InitializeShell(Window shell)
        {
            base.InitializeShell(shell);
            IRegionManager rm0 = Container.Resolve<IRegionManager>();

            FirstView firstView = new FirstView()
            {
                DataContext = new FirstViewModel()
            };

            SecondView secondView = new SecondView()
            {
                DataContext = new SecondViewModel()
            };

            ThirdView thirdView = new ThirdView()
            {
                DataContext = new ThirdViewModel()
            };

            var rm1 = rm0.AddToRegion("FirstRegionKey", firstView);
            var rm2 = rm1.AddToRegion("SecondRegionKey", secondView);
            //.AddToRegion("ThirdRegionKey", thirdView);
        }

        private void OnDispatcherUnhandledException(object sender, DispatcherUnhandledExceptionEventArgs e)
        {
            MessageBox.Show(e.Exception.ToString());

            e.Handled = true;
            Application.Current.MainWindow.Close();
        }

        protected override void RegisterTypes(IContainerRegistry containerRegistry)
        {
            containerRegistry.Register<LoadingDecoratorRegionAdapter>();
        }

        protected override void ConfigureRegionAdapterMappings(RegionAdapterMappings regionAdapterMappings)
        {
            base.ConfigureRegionAdapterMappings(regionAdapterMappings);

            regionAdapterMappings.RegisterMapping(typeof(LoadingDecorator), Container.Resolve<LoadingDecoratorRegionAdapter>());

            IRegionBehaviorFactory factory = Container.Resolve<IRegionBehaviorFactory>();
            regionAdapterMappings.RegisterMapping(typeof(LayoutPanel), AdapterFactory.Make<RegionAdapterBase<LayoutPanel>>(factory));
            regionAdapterMappings.RegisterMapping(typeof(LayoutGroup), AdapterFactory.Make<RegionAdapterBase<LayoutGroup>>(factory));
            regionAdapterMappings.RegisterMapping(typeof(TabbedGroup), AdapterFactory.Make<RegionAdapterBase<TabbedGroup>>(factory));
            regionAdapterMappings.RegisterMapping(typeof(DocumentGroup), AdapterFactory.Make<RegionAdapterBase<DocumentGroup>>(factory));
        }
    }
}