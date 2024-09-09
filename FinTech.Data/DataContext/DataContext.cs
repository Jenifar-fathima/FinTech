using System.Collections.Generic;

namespace FinTech.Data
{
    public static class DataContext
    {
       public static List<User> User { get; set; } = new List<User>();
       public static List<Account> Account { get; set; }= new List<Account>();
    }
}
