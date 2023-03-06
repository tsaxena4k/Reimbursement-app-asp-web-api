using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TSReimbursementApp.DAL.DTOs.Base
{
    public abstract class DtoBase : IDto
    {
        public int Id { get; set; }
    }
}
