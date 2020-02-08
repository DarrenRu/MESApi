using System;
using System.Collections.Generic;
using System.Linq;
using ITRI.Models;
using ITRI.Models.Entities;
using ITRI.Models.Helper;
using ITRI.Models.Interface;
using ITRI.Services.Interface;
using ITRI.ViewModels;
using Newtonsoft.Json.Linq;

namespace ITRI.Services
{
    public class AccountManageS : IAccountManageS
    {
        private readonly JWTSettings _jwtSettings;
        private readonly IRepository<Account> _repository = new Repository<Account>();

        public AccountManageS(JWTSettings jwtSettings)
        {
            jwtSettings = _jwtSettings;
        }
        public DatatablesVM<Account> GetAll(int start, int length)
        {
            var count = _repository.GetAll().Count();
            var data = _repository.GetAll().Skip(start).Take(length);
            var result = new DatatablesVM<Account>
            {
                recordsTotal = count,
                recordsFiltered = count,
                data = data,
            };
            return result;
        }
        public Account GetById(int id)
        {
            var account = _repository.Get(c => c.Id == id);
            return account;
        }
        public void Update(Account data)
        {
            var account = _repository.Get(c => c.Id == data.Id);

            account.Type = data.Type;
            account.UserName = data.UserName;
            account.Password = data.Password;
            account.NickName = data.NickName;
            account.Status = data.Status;
            _repository.Update(account);

        }


        public void Create(Account data)
        {
            // TODO: Exception
            _repository.Create(data);
        }
        public void Delete(int id)
        {
            // TODO: Exception
            var account = _repository.Get(c => c.Id == id);
            _repository.Delete(account);
        }

        public void TurnStatus(int id)
        {
            var account = _repository.Get(c => c.Id == id);
            account.Status = (account.Status == 0) ? Convert.ToByte(1) : Convert.ToByte(0);
            var result = account.Status;
            _repository.Update(account);


        }


        public void ChangePassword(int id, string password,string userName,string nickName)
        {
            var account = _repository.Get(c => c.Id == id);
            account.UserName = userName;
            account.NickName = nickName;
            account.Password = password;
            _repository.Update(account);
        }
    }
}
