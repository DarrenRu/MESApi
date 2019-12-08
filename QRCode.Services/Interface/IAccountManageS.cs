﻿using System.Collections.Generic;
using QRCode.Models.Entities;
using QRCode.ViewModels;
using Newtonsoft.Json.Linq;

namespace QRCode.Services.Interface
{
    public interface IAccountManageS
    {
        DatatablesVM<Account> GetAll(int start, int length);
        Account GetById(int id);
        void Update(Account data);
        void Create(Account data);
        void Delete(int id);
        void TurnStatus(int id);
        void ChangePassword(int id, string password, string userName, string nickName);
    }
}
