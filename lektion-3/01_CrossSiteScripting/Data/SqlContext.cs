using _01_CrossSiteScripting.Models;
using Microsoft.EntityFrameworkCore;

namespace _01_CrossSiteScripting.Data
{
    public class SqlContext : DbContext
    {
        public SqlContext(DbContextOptions<SqlContext> options) : base(options)
        {
        }

        protected SqlContext()
        {
        }

        public virtual DbSet<Comment> Comments { get; set; }
    }
}
