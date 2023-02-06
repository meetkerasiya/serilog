using Serilog;
using Serilog.Formatting.Json;



//Log.Logger = new LoggerConfiguration()
//    .WriteTo.Console()
//  //  .WriteTo.Console(new JsonFormatter())
//    //.WriteTo.Seq("http://localhost:5341")
//    .CreateLogger();


try
{
    var builder = WebApplication.CreateBuilder(args);

    builder.Host.UseSerilog((context, config) =>
    {
        config.WriteTo.Console();
       // config.WriteTo.Console(new JsonFormatter());
    });
    // Add services to the container.
    builder.Services.AddRazorPages();

    var app = builder.Build();

    // Configure the HTTP request pipeline.
    if (!app.Environment.IsDevelopment())
    {
        app.UseExceptionHandler("/Error");
        // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
        app.UseHsts();
    }

    app.UseHttpsRedirection();
    app.UseStaticFiles();

    app.UseRouting();

    app.UseAuthorization();

    app.MapRazorPages();

    app.Run();
}
catch (Exception ex)
{
    Log.Fatal(ex, "Host terminated unexpextedly");

}
finally
{
    Log.CloseAndFlush();
}
