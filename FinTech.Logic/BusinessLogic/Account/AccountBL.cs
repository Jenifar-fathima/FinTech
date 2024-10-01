using FinTech.Data;
using FinTech.Common;

namespace FinTech.Logic
{
    public abstract class AccountBL
    {
        public Account Create(AccountDTO accountdto)
        {
            Account account = new Account(accountdto);
            DataContext.Account.Add(account);
            return account;
        }
    }
}