using _02_FileUploading.Models;
using Microsoft.EntityFrameworkCore;

namespace _02_FileUploading.Data
{
    public class SqlContext : DbContext
    {
        public SqlContext()
        {

        }

        public SqlContext(DbContextOptions<SqlContext> options) : base(options)
        {
        }

        public virtual DbSet<FileItem> Files { get; set; }
    }
}
