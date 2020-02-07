using Caliburn.Micro;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RMWpfUI.ViewModels
{
    public class ShellViewModel : Conductor<Object>
    {
        private LoginViewModel _loginVM;
        public ShellViewModel(LoginViewModel loginVM)
        {
            this._loginVM = loginVM;
            ActivateItem(_loginVM);
        }
    }
}
