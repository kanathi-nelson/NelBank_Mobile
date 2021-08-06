using System;
using System.Collections.Generic;
using System.Text;

namespace NelBank.Models
{
    public class AccountLoginResp
    {
        public string status { get; set; }
        public string message { get; set; }
        public int userId { get; set; }
        public int accountId { get; set; }
        public string fromAccount { get; set; }
        public string accountNo { get; set; }
        public string accountType { get; set; }
        public string accountBalance { get; set; }
        public string username { get; set; }
    }
}
