using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;
using PersonApi4.Models;

#nullable disable

namespace PersonApi4.Models.Contexts
{
    public partial class PersonDBContext : DbContext
    {
        public PersonDBContext()
        {
        }

        public PersonDBContext(DbContextOptions<PersonDBContext> options)
            : base(options)
        {
        }

        public virtual DbSet<Birthdate> Birthdates { get; set; }
        public virtual DbSet<IdentityType> IdentityTypes { get; set; }
        public virtual DbSet<IdentityValue> IdentityValues { get; set; }
        public virtual DbSet<Person> People { get; set; }
        public virtual DbSet<PersonBirthdate> PersonBirthdates { get; set; }
        public virtual DbSet<PersonIdentityValue> PersonIdentityValues { get; set; }
        public virtual DbSet<Rol> Rols { get; set; }
        public virtual DbSet<ViewFormattedPerson> ViewFormattedPeople { get; set; }
        public virtual DbSet<VwFormattedPerson> VwFormattedPeople { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see http://go.microsoft.com/fwlink/?LinkId=723263.
                optionsBuilder.UseSqlServer("Data Source=(local);Initial Catalog=PersonDB;integrated security=True;");
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.HasAnnotation("Relational:Collation", "SQL_Latin1_General_CP1_CI_AS");

            modelBuilder.Entity<Birthdate>(entity =>
            {
                entity.ToTable("birthdate");

                entity.Property(e => e.BirthdateId).HasColumnName("birthdate_id");

                entity.Property(e => e.Value)
                    .HasColumnType("date")
                    .HasColumnName("value");
            });

            modelBuilder.Entity<IdentityType>(entity =>
            {
                entity.ToTable("identity_type");

                entity.Property(e => e.IdentityTypeId).HasColumnName("identity_type_id");

                entity.Property(e => e.Value)
                    .IsRequired()
                    .HasMaxLength(30)
                    .IsUnicode(false)
                    .HasColumnName("value");
            });

            modelBuilder.Entity<IdentityValue>(entity =>
            {
                entity.ToTable("identity_value");

                entity.HasIndex(e => e.Value, "UQ__name__40BBEA3A613D4874")
                    .IsUnique();

                entity.Property(e => e.IdentityValueId).HasColumnName("identity_value_id");

                entity.Property(e => e.IdentityTypeId).HasColumnName("identity_type_id");

                entity.Property(e => e.PhoneticValue)
                    .HasMaxLength(6)
                    .IsUnicode(false)
                    .HasColumnName("phonetic_value");

                entity.Property(e => e.Value)
                    .IsRequired()
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasColumnName("value");

                entity.HasOne(d => d.IdentityType)
                    .WithMany(p => p.IdentityValues)
                    .HasForeignKey(d => d.IdentityTypeId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("identity_value_fk");
            });

            modelBuilder.Entity<Person>(entity =>
            {
                entity.ToTable("person");

                entity.Property(e => e.PersonId).HasColumnName("person_id");

                entity.Property(e => e.CreatedAt)
                    .HasColumnType("datetime")
                    .HasColumnName("created_at")
                    .HasDefaultValueSql("(getdate())");

                entity.Property(e => e.CreatedBy)
                    .HasMaxLength(30)
                    .IsUnicode(false)
                    .HasColumnName("created_by")
                    .HasDefaultValueSql("(user_name())");

                entity.Property(e => e.IsActive)
                    .HasColumnName("is_active")
                    .HasDefaultValueSql("((1))");
            });

            modelBuilder.Entity<PersonBirthdate>(entity =>
            {
                entity.ToTable("person_birthdate");

                entity.Property(e => e.PersonBirthdateId).HasColumnName("person_birthdate_id");

                entity.Property(e => e.BirthdateId).HasColumnName("birthdate_id");

                entity.Property(e => e.CreatedAt)
                    .HasColumnType("datetime")
                    .HasColumnName("created_at")
                    .HasDefaultValueSql("(getdate())");

                entity.Property(e => e.CreatedBy)
                    .HasMaxLength(30)
                    .IsUnicode(false)
                    .HasColumnName("created_by")
                    .HasDefaultValueSql("(user_name())");

                entity.Property(e => e.IsActive)
                    .HasColumnName("is_active")
                    .HasDefaultValueSql("((1))");

                entity.Property(e => e.PersonId).HasColumnName("person_id");

                entity.HasOne(d => d.Birthdate)
                    .WithMany(p => p.PersonBirthdates)
                    .HasForeignKey(d => d.BirthdateId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("person_birthdate_fk2");

                entity.HasOne(d => d.Person)
                    .WithMany(p => p.PersonBirthdates)
                    .HasForeignKey(d => d.PersonId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("person_birthdate_fk");
            });

            modelBuilder.Entity<PersonIdentityValue>(entity =>
            {
                entity.ToTable("person_identity_value");

                entity.Property(e => e.PersonIdentityValueId).HasColumnName("person_identity_value_id");

                entity.Property(e => e.IdentityValueId).HasColumnName("identity_value_id");

                entity.Property(e => e.OrderValue).HasColumnName("order_value");

                entity.Property(e => e.PersonId).HasColumnName("person_id");

                entity.HasOne(d => d.IdentityValue)
                    .WithMany(p => p.PersonIdentityValues)
                    .HasForeignKey(d => d.IdentityValueId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("person_identity_value_fk2");

                entity.HasOne(d => d.Person)
                    .WithMany(p => p.PersonIdentityValues)
                    .HasForeignKey(d => d.PersonId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("person_identity_value_fk");
            });

            modelBuilder.Entity<Rol>(entity =>
            {
                entity.ToTable("rol");

                entity.HasIndex(e => e.Name, "rol_name_IDX")
                    .IsUnique();

                entity.Property(e => e.RolId).HasColumnName("rol_id");

                entity.Property(e => e.CreatedAt)
                    .HasColumnName("created_at")
                    .HasDefaultValueSql("(getdate())");

                entity.Property(e => e.CreatedBy)
                    .HasMaxLength(100)
                    .IsUnicode(false)
                    .HasColumnName("created_by")
                    .HasDefaultValueSql("(user_name())");

                entity.Property(e => e.Description)
                    .HasColumnType("text")
                    .HasColumnName("description");

                entity.Property(e => e.IsActive)
                    .HasColumnName("is_active")
                    .HasDefaultValueSql("((1))");

                entity.Property(e => e.Name)
                    .HasMaxLength(55)
                    .IsUnicode(false)
                    .HasColumnName("name");
            });

            modelBuilder.Entity<ViewFormattedPerson>(entity =>
            {
                entity.HasNoKey();

                entity.ToView("view_formatted_people");

                entity.Property(e => e.Birthdate)
                    .HasMaxLength(30)
                    .IsUnicode(false)
                    .HasColumnName("birthdate");

                entity.Property(e => e.LastNames)
                    .HasMaxLength(150)
                    .IsUnicode(false)
                    .HasColumnName("last_names");

                entity.Property(e => e.Names)
                    .HasMaxLength(150)
                    .IsUnicode(false)
                    .HasColumnName("names");

                entity.Property(e => e.PersonId).HasColumnName("person_id");

                entity.Property(e => e.PhoneticValues)
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasColumnName("phonetic_values");
            });

            modelBuilder.Entity<VwFormattedPerson>(entity =>
            {
                entity.HasNoKey();

                entity.ToView("vw_formatted_people");

                entity.Property(e => e.Birthdate)
                    .HasColumnType("date")
                    .HasColumnName("birthdate");

                entity.Property(e => e.LastNames)
                    .HasMaxLength(150)
                    .IsUnicode(false)
                    .HasColumnName("last_names");

                entity.Property(e => e.Names)
                    .HasMaxLength(150)
                    .IsUnicode(false)
                    .HasColumnName("names");

                entity.Property(e => e.PersonId).HasColumnName("person_id");

                entity.Property(e => e.PhoneticValues)
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasColumnName("phonetic_values");
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
