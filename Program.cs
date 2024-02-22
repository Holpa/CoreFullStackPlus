using HeadlessServices;

var builder = WebApplication.CreateBuilder(args);

// Check for the 'no-webapi' command-line argument
bool includeWebApi = !args.Contains("no-webapi");

if (includeWebApi)
{
    // Add services for Web API
    builder.Services.AddEndpointsApiExplorer();
    builder.Services.AddSwaggerGen();
}

// Always add the WorkService unless the 'no-background-worker' argument is passed
bool includeBackgroundWorker = !args.Contains("no-background-worker");
if (includeBackgroundWorker)
{
    builder.Services.AddHostedService<WorkService>();
}

////DI for DB 
/// 
//// Getting the secret CLI connection string info check README.md
//// Building a ApplicationDBContext class, then include the name space in top
//var _connectionString = builder.Configuration.GetConnectionString("DefaultConnection");
//builder.Configuration.GetConnectionString("DefaultConnection")
//builder.Services.AddDbContext<ApplicationDBContext>(options => options.UseSqlServer(_connectionString));

var app = builder.Build();

if (includeWebApi)
{
    // Configure the HTTP request pipeline for Web API
    if (app.Environment.IsDevelopment())
    {
        app.UseSwagger();
        app.UseSwaggerUI();
    }
    app.UseDefaultFiles();
    app.UseStaticFiles();
    app.UseHttpsRedirection();

    var summaries = new[]
    {
        "Freezing", "Bracing", "Chilly", "Cool", "Mild",
        "Warm", "Balmy", "Hot", "Sweltering", "Scorching"
    };

    app.MapGet("/weatherforecast", () =>
    {
        var forecast = Enumerable.Range(1, 5).Select(index =>
            new WeatherForecast
            (
                DateOnly.FromDateTime(DateTime.Now.AddDays(index)),
                Random.Shared.Next(-20, 55),
                summaries[Random.Shared.Next(summaries.Length)]
            ))
            .ToArray();
        return forecast;
    })
    .WithName("GetWeatherForecast")
    .WithOpenApi();
}


app.Run();

record WeatherForecast(DateOnly Date, int TemperatureC, string? Summary)
{
    public int TemperatureF => 32 + (int)(TemperatureC / 0.5556);
}
