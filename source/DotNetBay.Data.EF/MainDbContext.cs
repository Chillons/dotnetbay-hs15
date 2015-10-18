using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DotNetBay.Data.EF
{
    public class MainDbContext : DbContext
    {
        public MainDbContext() : base("DatabaseConnection")
        {
            
        }
    }
}
