using Caliburn.Micro;
using RMWpfUI.Helpers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RMWpfUI.ViewModels
{
    public class LoginViewModel : Screen
    {
		private string _userName;
		private string _password;
		private IAPIHelper _apiHelper;

		public LoginViewModel(IAPIHelper apiHelper)
		{
			this._apiHelper = apiHelper;
		}
		
		public string txtUserName
		{
			get { return _userName; }
			set 
			{ 	
				_userName = value;
				NotifyOfPropertyChange(() => txtUserName);     // To Notify the UI when the value is changed
				NotifyOfPropertyChange(() => CanbtnLogin);
			}
		}

		
		public string  txtPassword
		{
			get { return _password; }
			set 
			{ 
				_password = value;
				NotifyOfPropertyChange(() => txtPassword);
				NotifyOfPropertyChange(() => CanbtnLogin);
			}
		}

		public bool CanbtnLogin
		{
			get
			{
				bool isValid = false;
				if (txtUserName?.Length > 0 && txtPassword?.Length > 0)
				{
					isValid = true;
				}

				return isValid;
			}
		}

		public async Task btnLogin()
		{
			try
			{
				var result = await _apiHelper.Authenticate(txtUserName, txtPassword);
			}
			catch (Exception ex)
			{

				Console.WriteLine(ex.Message);
			}
		}

	}
}
