using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TSReimbursementApp.DAL.Domain
{
    public class AccessToken
    {
        public string Value { get; set; }
        public DateTime? ExpirationTime { get; set; }
    }
}
