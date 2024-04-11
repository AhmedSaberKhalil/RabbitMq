
using Microsoft.EntityFrameworkCore;
using Microsoft.OpenApi.Models;
using RabbitMqProductApI.Data;
using RabbitMqProductApI.Models;
using RabbitMqProductApI.RabbitMQ;
using RabbitMqProductApI.Repository;

namespace RabbitMqProductApI
{
	public class Program
	{
		public static void Main(string[] args)
		{
			var builder = WebApplication.CreateBuilder(args);

			// Add services to the container.

			builder.Services.AddControllers();
			// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
			builder.Services.AddEndpointsApiExplorer();
			//builder.Services.AddSwaggerGen();
			builder.Services.AddSwaggerGen(c =>
			{
				c.SwaggerDoc("v1", new OpenApiInfo { Title = "Demo", Version = "v1" });
			});
			builder.Services.AddSwaggerGen(swagger =>
			{
				//This is to generate the Default UI of Swagger Documentation    
				swagger.SwaggerDoc("v2", new OpenApiInfo
				{
					Version = "v1",
					Title = "ASP.NET 7 Web API",
					Description = " ITI Projrcy"
				});
			});

			builder.Services.AddDbContext<RMQEntity>(options => {

				options.UseSqlServer(builder.Configuration.GetConnectionString("cs"));
			});
			builder.Services.AddScoped<IRepository<Product>, ProductRepository>();
			builder.Services.AddScoped<IRabitMQProducer, RabitMQProducer>();
			var app = builder.Build();

			// Configure the HTTP request pipeline.
			if (app.Environment.IsDevelopment())
			{
				app.UseSwagger();
				app.UseSwaggerUI();
			}

			app.UseHttpsRedirection();

			app.UseAuthorization();


			app.MapControllers();

			app.Run();
		}
	}
}
