using System.Linq;
using Google.Apis.Auth.OAuth2;
using Google.Cloud.Firestore;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Options;
using TechAlive.Reservame.Core;
using TechAlive.Reservame.Core.DataAccess;

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
			// requires using Microsoft.Extensions.Options
			services.Configure<DatabaseSettings>(Configuration.GetSection(nameof(DatabaseSettings)));
			services.AddSingleton<IDatabaseSettings>(sp => sp.GetRequiredService<IOptions<DatabaseSettings>>().Value);
			services.AddSingleton<FirestoreClient>();
			services.AddSingleton<ProductService>();

			//var projectId = "reservame-f3adc";
			//System.Environment.SetEnvironmentVariable("GOOGLE_APPLICATION_CREDENTIALS", "C:/reservame-f3adc-firebase-adminsdk-btm0v-f166c8d858.json");

			//GoogleCredential.GetApplicationDefault();
			//var db = FirestoreDb.CreateAsync(projectId).Result;

			//CollectionReference userCollection = db.Collection("users");
			//var userDocument = userCollection.AddAsync(new { Name = new { First = "Ada", Last = "Lovelace" }, Born = 1815 }).Result;

			// A DocumentReference doesn't contain the data - it's just a path.
			// Let's fetch the current document.
			//var userSnapshot = userDocument.GetSnapshotAsync().Result;

			//var productsCollection = db.Collection("Products");
			//var products  = productsCollection.GetSnapshotAsync().Result;
			//var docs = products.Documents;

			services.AddControllers();
		}

		// This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
		public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
		{
			if (env.IsDevelopment())
			{
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
