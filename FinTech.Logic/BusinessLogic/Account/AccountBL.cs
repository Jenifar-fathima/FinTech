using FinTech.Data;
using System;

namespace FinTech.Logic
{
    public abstract class AccountBL
    {
        public  Account CreateAccount(User user)
        {
            Account account = new Account
            {
                ID = Guid.NewGuid(),
                UserID = user.UserID,
                AccountType = user.AccountType
            };

            DataContext.Accounts.Add(account);
            return account;
        }
    }
}