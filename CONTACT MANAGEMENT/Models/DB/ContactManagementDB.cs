using System;
using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity;
using System.Linq;

namespace CONTACT_MANAGEMENT.Models.DB
{
    public partial class ContactManagementDB : DbContext
    {
        public ContactManagementDB()
            : base("name=ContactManagementDB")
        {
        }

        public virtual DbSet<ContactManagement> ContactManagements { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
        }
    }
}
