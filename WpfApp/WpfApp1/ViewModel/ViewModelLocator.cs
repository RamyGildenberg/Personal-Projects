/*
  In App.xaml:
  <Application.Resources>
      <vm:ViewModelLocator xmlns:vm="clr-namespace:WpfApp1"
                           x:Key="Locator" />
  </Application.Resources>
  
  In the View:
  DataContext="{Binding Source={StaticResource Locator}, Path=ViewModelName}"

  You can also use Blend to do all this with the tool's support.
  See http://www.galasoft.ch/mvvm
*/

using CommonServiceLocator;
using GalaSoft.MvvmLight.Ioc;
using GalaSoft.MvvmLight.Messaging;
using System.Windows;
using WpfApp1.ViewModel;
namespace WpfApp1.ViewModel
{


    /*
    namespace WpfApp1.ViewModel
    {
    /// <summary>
    /// This class contains static references to all the view models in the
    /// application and provides an entry point for the bindings.
    /// </summary>
    public class ViewModelLocator
    {
    /// <summary>
    /// Initializes a new instance of the ViewModelLocator class.
    /// </summary>
    public ViewModelLocator()
    {
    ServiceLocator.SetLocatorProvider(() => SimpleIoc.Default);

    ////if (ViewModelBase.IsInDesignModeStatic)
    ////{
    ////    // Create design time view services and models
    ////    SimpleIoc.Default.Register<IDataService, DesignDataService>();
    ////}
    ////else
    ////{
    ////    // Create run time view services and models
    ////    SimpleIoc.Default.Register<IDataService, DataService>();
    ////}

    SimpleIoc.Default.Register<MainViewModel>();
    }

    public MainViewModel Main
    {
    get
    {
    return ServiceLocator.Current.GetInstance<MainViewModel>();
    }
    }

    public static void Cleanup()
    {
    // TODO Clear the ViewModels
    }
    }
    }
    */
    public class ViewModelLocator
    {
        public ViewModelLocator()
        {
            ServiceLocator.SetLocatorProvider(() => SimpleIoc.Default);

            SimpleIoc.Default.Register<WpfApp1.ViewModel.MainViewModel>();
            Messenger.Default.Register<NotificationMessage>(this, NotifyUserMethod);
        }

        public WpfApp1.ViewModel.MainViewModel MainViewModel
        {
            get
            {
                return ServiceLocator.Current.GetInstance<WpfApp1.ViewModel.MainViewModel>();
            }
        }

        private void NotifyUserMethod(NotificationMessage message)
        {
            MessageBox.Show(message.Notification);
        }
    }
}

