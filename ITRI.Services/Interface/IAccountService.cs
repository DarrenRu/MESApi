using ITRI.Models.Entities;
using ITRI.ViewModels;

namespace ITRI.Services.Interface
{
    public interface IAccountService
    {

        Account GetById(int id);
        Account Login(string username, string password);

    }
}
