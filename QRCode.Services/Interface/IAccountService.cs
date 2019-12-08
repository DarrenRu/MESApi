using QRCode.Models.Entities;
using QRCode.ViewModels;

namespace QRCode.Services.Interface
{
    public interface IAccountService
    {

        Account GetById(int id);
        Account Login(string username, string password);

    }
}
