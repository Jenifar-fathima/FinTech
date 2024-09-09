using System;
using FinTech.Common;

namespace FinTech.Data
{
    public class Account
    {
        public Guid AccountID { get; set; }
        public AccountType AccountType { get; set; }
        public Guid UserID { get; set; }

        public Account(AccountDTO accountdto)
        {
            AccountID = Guid.NewGuid();
            AccountType = accountdto.AccountType;
            UserID = accountdto.UserID;
        }
    }
}