using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using eUseControl.Domain.Entities.Admin;
using eUseControl.Domain.Entities.User;

namespace eUseControl.BusinessLogic.DBModel.Seed
{
    class UserContext : DbContext
    {
        public UserContext() : base("name = eUseControl")
        {
            /*Database.SetInitializer<UserContext>(null);*/
        }
        public virtual DbSet<SessionsDbTable> Sessions { get; set; }
        public virtual DbSet<UDbTable> Users { get; set; }
        public virtual DbSet<Product> Products { get; set; }
    }
}
