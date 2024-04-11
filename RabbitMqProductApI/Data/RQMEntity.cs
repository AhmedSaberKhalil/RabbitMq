using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using RabbitMqProductApI.Models;

namespace RabbitMqProductApI.Data
{
	public class RMQEntity : IdentityDbContext<IdentityUser>
	{
		public RMQEntity(DbContextOptions<RMQEntity> options) : base(options)
		{

		}
		public RMQEntity()
		{

		}
		public DbSet<Product> Product { get; set; }
	}
}
