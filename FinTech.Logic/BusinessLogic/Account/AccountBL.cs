using FinTech.Data;
using FinTech.Common;

namespace FinTech.Logic
{
    public abstract class AccountBL
    {
        public  Account Create(UserDTO userdto)
        {
            Account account = new Account(userdto);
            DataContext.Account.Add(account);
            return account;
        }
    }
}