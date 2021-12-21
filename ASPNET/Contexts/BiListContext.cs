using ASPNET.Models;
using Microsoft.EntityFrameworkCore;

namespace ASPNET.Contexts
{
    public class BiListContext : DbContext
    {

        public BiListContext(DbContextOptions<BiListContext> opt) : base(opt)
        {

        }
        public DbSet<BiList> BiLists { get; set; }

    }
}