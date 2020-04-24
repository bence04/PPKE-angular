using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

using System.Diagnostics.CodeAnalysis;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

using TanulmanyiRendszer.Domain;

namespace TanulmanyiRendszer.DAL
{
    public class ApplicationDbContext : IdentityDbContext<Felhasznalo>
    {
        public ApplicationDbContext([NotNull] DbContextOptions options)
            : base(options)
        {
        }

        public DbSet<Szemeszter> Szemeszterek { get; set; }

        public override Task<int> SaveChangesAsync(bool acceptAllChangesOnSuccess, CancellationToken cancellationToken = default)
        {
            ChangeTracker.DetectChanges();

            var isDeletedName = nameof(EntityBase.IsDeleted);

            var entriesToDelete = ChangeTracker.Entries()
                .Where(x => x.State == EntityState.Deleted);

            foreach (var entry in entriesToDelete)
            {
                switch (entry.State)
                {
                    case EntityState.Added:
                        entry.CurrentValues[isDeletedName] = false;
                        break;

                    case EntityState.Deleted:
                        entry.State = EntityState.Modified;
                        entry.CurrentValues[isDeletedName] = true;
                        break;
                }
            }

            return base.SaveChangesAsync(acceptAllChangesOnSuccess, cancellationToken);
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Szemeszter>().HasQueryFilter(p => !p.IsDeleted);

            base.OnModelCreating(modelBuilder);
        }
    }
}