using System;
using System.Collections.Generic;
using System.Text;
using System.Text.Json;
using Astreiko.EntityFramework.Models;
using Microsoft.EntityFrameworkCore;

namespace Astreiko.EntityFramework.StrContext
{
	internal class StrContext : DbContext
	{
		private readonly string _connectionString;

		public StrContext(string connectionString = null)
		{
			_connectionString = connectionString;
		}

		public DbSet<Student> Students { get; set; }
		public DbSet<Homework> Homeworks { get; set; }

		protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
		{
			optionsBuilder.UseSqlServer(
				_connectionString ?? @"Data Source=.\SQLExpress;Initial Catalog=EntityFramStr;Integrated Security=True");
		}

		protected override void OnModelCreating(ModelBuilder modelBuilder)
		{
			modelBuilder.Entity<Homework>()
				.Property(h => h.Name)
				.HasMaxLength(500)
					.IsRequired();

			modelBuilder.Entity<Homework>()
				.Ignore(h => h.PullRequest);

			modelBuilder.Entity<Homework>()
				.Property(h => h.IsCompleted)
				.HasColumnName("IsComplete");

			modelBuilder.Entity<Homework>()
				.Property(h => h.Created)
				.HasDefaultValueSql("getdate()");

			//modelBuilder.Entity<Homework>()
			//	.Property(h => h.Mark)
			//	.HasDefaultValue(1);

			modelBuilder.Entity<Homework>()
				.HasOne(h => h.Student)
				.WithMany(s => s.Homeworks)
				.IsRequired()
				.HasForeignKey("NewStudentId")
				.OnDelete(DeleteBehavior.Restrict);

			modelBuilder.Entity<DiplomaWork>()
				//.HasBaseType((Type)null)
				.HasBaseType<Homework>();

			//modelBuilder.Entity<Homework>()
			//	.HasDiscriminator<string>("work_type")
			//	.HasValue<Homework>("regular")
			//	.HasValue<DiplomaWork>("diploma")
			//	.IsComplete(false);

			//modelBuilder.Entity<Homework>().ToTable("Homework");
			modelBuilder.Entity<DiplomaWork>()
				.ToTable("Diplomas");

			modelBuilder.Entity<Homework>()
			   .Property(e => e.Tags)
			   .HasConversion(
				   v => JsonSerializer.Serialize(v, null),
				   v => JsonSerializer.Deserialize<List<Tag>>(v, null));

			modelBuilder
			   .Entity<Homework>()
			   .Property(e => e.Type)
			   .HasConversion<string>();

			modelBuilder
				.Entity<Homework>()
				.Property(e => e.Mark)
				.HasConversion(
					v => v.Value,
					v => new Mark(v));

			modelBuilder.Entity<Student>(
				student =>
				{
					modelBuilder.Entity<Student>()
						.HasIndex(s => new { s.Name, s.LastName })
						.IncludeProperties(s => s.BirthDate)
						.IsUnique();

					student.HasOne(x => x.Avatar)
						   .WithOne(a => a.Student)
						   .HasForeignKey<StudentAvatar>("StudentId");

					student.Property(s => s.StudentId).ValueGeneratedOnAdd();
					student.HasKey(s => s.StudentId);
					student.Property(h => h.BirthDate).HasColumnType("nvarchar(150)");

					student.OwnsOne(p => p.Address);
				});

			//.ToTable("Home_Works");
			//modelBuilder.Ignore<Address>();

			modelBuilder.Entity<StudentHomeworksCount>(
					hc =>
					{
						hc.HasNoKey();
						hc.ToView("View_HomeworksCounts");

						hc.Property(v => v.StudentName).HasColumnName("Name");
					});
		}
	}
}
