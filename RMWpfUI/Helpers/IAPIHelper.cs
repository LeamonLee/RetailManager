using RMWpfUI.Models;
using System.Threading.Tasks;

namespace RMWpfUI.Helpers
{
    public interface IAPIHelper
    {
        Task<AuthenticatedUserInfo> Authenticate(string strUsername, string strPassword);
    }
}