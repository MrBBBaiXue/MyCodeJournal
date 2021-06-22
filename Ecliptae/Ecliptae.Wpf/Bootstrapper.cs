using Ecliptae.Wpf.ViewModels;
using Stylet;
using System.Windows;
using System.Windows.Threading;

namespace Ecliptae.Wpf
{
    public class Bootstrapper : Bootstrapper<MainViewModel>
    {

        protected override void OnStart()
        {

            // This is called just after the application is started, but before the IoC container is set up.
            // Set up things like logging, etc
        }

        protected override void Configure()
        {
            // ToDo : Add more function to Configure IOC.
            // Configure ViewModels.

            // This is called after Stylet has created the IoC container, so this.Container exists, but before the
            // Root ViewModel is launched.
            // Configure your services, etc, in here
        }

        protected override void OnLaunch()
        {
            // This is called just after the root ViewModel has been launched
            // Something like a version check that displays a dialog might be launched from here
        }

        protected override void OnExit(ExitEventArgs e)
        {
            // Called on Application.Exit

        }

        protected override void OnUnhandledException(DispatcherUnhandledExceptionEventArgs e)
        {
            // Called on Application.DispatcherUnhandledException
        }
    }
}
