var config = new ConfigurationBuilder().AddJsonFile("appsettings.json").Build();
var env = config.GetSection("Env").Value;


var builder = WebApplication.CreateBuilder(args);

// Add Json files 
builder.Host.ConfigureAppConfiguration(config =>
{
    config.AddJsonFile("appsettings.json").AddJsonFile($"appsettings.{env}.json");
});



// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var app = builder.Build();


Directory.SetCurrentDirectory(builder.Environment.ContentRootPath);

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}



app.UseAuthorization();

app.MapControllers();



app.Run();
