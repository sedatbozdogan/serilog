using Serilog;
 
try
{ 
    var builder = WebApplication.CreateBuilder(args);  
    builder.Host.UseSerilog();

    Log.Logger = new LoggerConfiguration()
        .ReadFrom.Configuration(builder.Configuration)
        .Enrich.FromLogContext()
        .CreateLogger();
     
    builder.Services.AddControllers(); 
    var app = builder.Build(); 
    app.UseAuthorization(); 
    app.MapControllers(); 
    app.Run(); 
}
catch (Exception ex)
{
    Log.Fatal(ex, "Application terminated unexpectedly");
}
finally
{
    Log.CloseAndFlush();
}
 



