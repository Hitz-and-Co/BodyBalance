using Prometheus;

public class Startup
{
    public void ConfigureServices(IServiceCollection services)
    {
        services.AddControllersWithViews();
    }

    public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
    {
        app.UseRouting();

        // Fügen Sie Prometheus-Metriken-Endpunkt hinzu
        app.UseEndpoints(endpoints =>
        {
            endpoints.MapMetrics();  // Dies stellt /metrics als Endpunkt bereit
            endpoints.MapControllerRoute(
                name: "default",
                pattern: "{controller=Home}/{action=Index}/{id?}");
        });
    }
}
