using System;
using FinTech.Common;

namespace FinTech.Data
{
    public class Account
    {
        public Guid ID { get; set; }
        public AccountType AccountType { get; set; }    
        public Guid UserID { get; set; }
    }
}
