using Caliburn.Micro;
using RMWpfUI.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace RMWpfUI
{
    public class Bootstrapper : BootstrapperBase
    {
        public Bootstrapper()
        {
            Initialize();
        }

        protected override void OnStartup(object sender, StartupEventArgs e)
        {
            //base.OnStartup(sender, e);

            // OnStartup, launch ShellViewModel as our base view
            DisplayRootViewFor<ShellViewModel>();
        }
    }
}
