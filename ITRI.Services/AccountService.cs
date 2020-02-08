using System;
using ITRI.Models;
using ITRI.Models.Entities;
using ITRI.Models.Helper;
using ITRI.Models.Interface;
using ITRI.Services.Interface;
using ITRI.ViewModels;

namespace ITRI.Services
{
    public class AccountService : BaseService, IAccountService
    {
        private readonly JWTSettings _jwtSettings;
        private readonly IRepository<Account> _repository = new Repository<Account>();

        public AccountService(JWTSettings jwtSettings)
        {
            _jwtSettings = jwtSettings;
        }

        public Account GetById(int id)
        {
            var data = _repository.Get(c => c.Id == id);
            return data;
        }

        public Account Login(string username, string password)
        {
            System.Console.WriteLine("Username: " + username + ", Password: " + password);
            var data = _repository.Get(c => c.UserName == username && c.Password == password);
            if (data == null) return null;
            data.Token = GenerateToken(data.Id, "Account", _jwtSettings, data.Type);
            _repository.Update(data);
            System.Console.WriteLine("Login Success, Token: " + data.Token);
            return data;
        }

    }
}
