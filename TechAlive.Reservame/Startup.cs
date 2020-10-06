using System;
using System.IO;
using System.Reflection;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.OpenApi.Models;
using TechAlive.Reservame.Core.DataAccess;
using TechAlive.Reservame.Core.SenderClient;
using TechAlive.Reservame.Core.Services;

namespace TechAlive.Reservame.Api
{
	public class Startup
	{
		public Startup(IConfiguration configuration)
		{
			Configuration = configuration;
		}

		public IConfiguration Configuration { get; }

		// This method gets called by the runtime. Use this method to add services to the container.
		public void ConfigureServices(IServiceCollection services)
		{
			services.AddSingleton<FirestoreClient>();
			services.AddTransient<ProductService>();
			services.AddTransient<RestaurantService>();
			services.AddTransient<UserService>();
			services.AddTransient<DeviceRequestService>();
			services.AddSingleton<FirebaseNotificationClient>();

			services.AddControllers();

			services.AddSwaggerGen(c =>
			{
				c.SwaggerDoc("v1", new OpenApiInfo
				{
					Title = "TechAlive Reservame API",
					Version = "v1.0"
				});
				c.IncludeXmlComments(Path.Combine(AppContext.BaseDirectory, $"{Assembly.GetExecutingAssembly().GetName().Name}.xml"));
			});
		}

		// This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
		public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
		{
			app.UseSwagger();
			app.UseSwaggerUI(c =>
			{
				c.SwaggerEndpoint("/swagger/v1/swagger.json", "TechAlive Reservame API v1.0");
				c.RoutePrefix = "";
			});

			if (env.IsDevelopment())
			{
				Environment.SetEnvironmentVariable("GOOGLE_APPLICATION_CREDENTIALS", "C:/AppEngine-ReservameApimodified-wonder-258716-4dc35ff2f93d.json");
				app.UseDeveloperExceptionPage();
			}

			app.UseHttpsRedirection();

			app.UseRouting();

			app.UseAuthorization();

			app.UseEndpoints(endpoints =>
			{
				endpoints.MapControllers();
			});
		}
	}
}
