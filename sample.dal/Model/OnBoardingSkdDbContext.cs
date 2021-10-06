using Microsoft.EntityFrameworkCore;

namespace OB_Net_Core_Tutorial.Model
{
    public class OnBoardingSkdDbContext : DbContext
    {
        public OnBoardingSkdDbContext(DbContextOptions<OnBoardingSkdDbContext> options) : base(options) { }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            //builder.Entity<VisibilityTicket>().HasIndex(a => new { a.TicketTypeId, a.CallTypeId, a.SubCallTypeId }).IsUnique(true);
        }

        public DbSet<Book> Books { get; set; }
        //public DbSet<Author> Authors { get; set; }

    }
}

