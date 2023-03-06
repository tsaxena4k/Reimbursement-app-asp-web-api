using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TSReimbursementApp.DAL.Domain;

namespace TSReimbursementApp.DAL.DBContext
{
    public class ReimbursementContext: IdentityDbContext
    {
        public ReimbursementContext( DbContextOptions<ReimbursementContext> options):base(options)
        {
        }
        public DbSet<ReimbursementDomain> Reimbursements { get; set; }

        public DbSet<ApplicationUser> Users { get; set; }

        public DbSet<RefreshToken> RefreshTokens { get; set; }

    }
}
