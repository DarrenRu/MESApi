using System;
using QRCode.Models.Entities;

namespace QRCode.Models.Interface
{
    public interface IAccountRepository : IRepository<Account>
    {
        Account Authenticate(string username, string password);
    }
}
