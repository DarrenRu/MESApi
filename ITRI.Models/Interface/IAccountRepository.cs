using System;
using ITRI.Models.Entities;

namespace ITRI.Models.Interface
{
    public interface IAccountRepository : IRepository<Account>
    {
        Account Authenticate(string username, string password);
    }
}
