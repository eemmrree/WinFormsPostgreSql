using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PostgreSQLEntityFramework.Model
{
    public class Context: DbContext
    {
        public Context() : base("name=Context")
        {

        }

        public DbSet<Birim> Birims { get; set; }
        public DbSet<Personel> Personels { get; set; }
    }
}
