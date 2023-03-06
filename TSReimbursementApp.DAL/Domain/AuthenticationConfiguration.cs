using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TSReimbursementApp.DAL.Domain
{
    public class AuthenticationConfiguration
    {
        public string JWT_Secret { get; set; }
        public string Client_URL { get; set; }
    }
}
