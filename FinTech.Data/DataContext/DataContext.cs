using System.Collections.Generic;

namespace FinTech.Data
{
    public static class DataContext
    {
       public static List<User> Users { get; set; } = new List<User>();
       public static List<Account> Accounts { get; set; }= new List<Account>();
    }
}
