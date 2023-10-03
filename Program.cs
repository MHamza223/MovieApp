using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;

namespace YourNamespace
{
    public class Program
    {
        public static void Main(string[] args)
        {
            CreateHostBuilder(args).Build().Run();
        }

        public static IHostBuilder CreateHostBuilder(string[] args) =>
            Host.CreateDefaultBuilder(args)
                .ConfigureWebHostDefaults(webBuilder =>
                {
                    webBuilder.ConfigureServices(services =>
                    {
                        // Register the MovieApiService as a transient service.
                        services.AddTransient<MovieApiService>();

                        // Add RazorPages as a service.
                        services.AddRazorPages();
                    });

                    webBuilder.Configure(app =>
                    {
                        // Configure the HTTP request pipeline.
                        if (!app.ApplicationServices.GetRequiredService<IWebHostEnvironment>().IsDevelopment())
                        {
                            app.UseExceptionHandler("/Error");
                            // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
                            app.UseHsts();
                        }

                        app.UseHttpsRedirection();
                        app.UseStaticFiles();

                        app.UseRouting();

                        app.UseAuthorization();

                        app.UseEndpoints(endpoints =>
                        {
                            // Set your new landing page as the default.
                            endpoints.MapRazorPages();
                            endpoints.MapDefaultControllerRoute(); // Add this line
                        });
                    });
                });
    }
}
