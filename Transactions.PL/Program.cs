using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Transactions.DAL.Data;

namespace Transactions.PL
{
	public class Program
	{
		public static async Task Main(string[] args)
		{
			var builder = WebApplication.CreateBuilder(args);

			#region Configure Services [Add To DI Container]
			// Add services to the container.
			builder.Services.AddControllersWithViews();

			builder.Services.AddDbContext<AppDbContext>(options =>
			{
				options.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection"));
			});

			#endregion

			var app = builder.Build();

			using var scope = app.Services.CreateScope();
			var services = scope.ServiceProvider;
			var loggerFactory = services.GetRequiredService<ILoggerFactory>();

			try
			{
				// Update Main Database
				var dbContext = services.GetRequiredService<AppDbContext>();
				await dbContext.Database.MigrateAsync();
			}
			catch (Exception ex)
			{
				var logger = loggerFactory.CreateLogger<Program>();
				logger.LogError(ex, "An Error Occurred During Appling The Migration");
			}

			#region Middlewares
			// Configure the HTTP request pipeline.
			if (!app.Environment.IsDevelopment())
			{
				app.UseExceptionHandler("/Home/Error");
				// The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
				app.UseHsts();
			}

			app.UseHttpsRedirection();
			app.UseStaticFiles();

			app.UseRouting();

			app.UseAuthorization();

			app.MapControllerRoute(
				name: "default",
				pattern: "{controller=Home}/{action=Index}/{id?}"); 
			#endregion

			app.Run();
		}
	}
}
