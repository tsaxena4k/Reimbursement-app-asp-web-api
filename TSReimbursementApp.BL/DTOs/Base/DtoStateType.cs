using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TSReimbursementApp.DAL.DTOs.Base
{
    public enum DtoStateType
    {
        /// <summary>
        /// The unchanged
        /// </summary>
        Unchanged,
        /// <summary>
        /// The added
        /// </summary>
        Added,
        /// <summary>
        /// The modified
        /// </summary>
        Modified,
        /// <summary>
        /// The deleted
        /// </summary>
        Deleted
    }
}
