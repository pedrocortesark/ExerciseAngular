
using System;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using ExerciseAngular.Data.Models.Base;
using ExerciseAngular.Infraestructure.Service;
using Microsoft.EntityFrameworkCore.ChangeTracking;

namespace ExerciseAngular.Data
{

    using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
    using Microsoft.EntityFrameworkCore;
    using Models;

    public class CatstagramDbContext : IdentityDbContext<User>
    {
        private readonly ICurrentUserService currentUser;

        public CatstagramDbContext(DbContextOptions<CatstagramDbContext> options, ICurrentUserService currentUser)
            : base(options)
        {
            this.currentUser = currentUser;
        }

        public DbSet<Cat> Cats { get; set; }


        public override int SaveChanges(bool acceptAllChangesOnSuccess)
        {
            this.ApplyAuditInformation();
            return base.SaveChanges(acceptAllChangesOnSuccess);
        }

        public override Task<int> SaveChangesAsync(bool acceptAllChangesOnSuccess, CancellationToken cancellationToken = new CancellationToken())
        {
            this.ApplyAuditInformation();
            return base.SaveChangesAsync(acceptAllChangesOnSuccess, cancellationToken);
        }

       
        protected override void OnModelCreating(ModelBuilder builder)
        {
            builder
                .Entity<Cat>()
                .HasQueryFilter(c=> !c.IsDeleted)
                .HasOne(c => c.User)
                .WithMany(u => u.Cats)
                .HasForeignKey(c => c.UserId)
                .OnDelete(DeleteBehavior.Restrict);
                


            base.OnModelCreating(builder);
        }

        private void ApplyAuditInformation()
        {
            this.ChangeTracker
                .Entries()
                .ToList()
                .ForEach(entry =>
                {
                    var userName = this.currentUser.GetUserName();

                    if (entry.Entity is IDeleteableEntity deleteableEntity)
                    {
                        if (entry.State == EntityState.Deleted)
                        {
                            deleteableEntity.DeletedOn = DateTime.UtcNow;
                            deleteableEntity.DeletedBy = userName;
                            deleteableEntity.IsDeleted = true;

                            entry.State = EntityState.Modified;
                        }
                    }
                    else if (entry.Entity is IEntity entity)
                    {
                        if (entry.State == EntityState.Added)
                        {
                            entity.CreatedOn = DateTime.UtcNow;
                            entity.CreatedBy = userName;
                        }
                        else if (entry.State == EntityState.Modified)
                        {
                            entity.ModifyOn = DateTime.UtcNow;
                            entity.ModifyBy = userName;
                        }
                    }
                });


        }
    }
}
