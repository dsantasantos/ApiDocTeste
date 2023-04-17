var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();

    app.UseReDoc(c =>
    {
        c.DocumentTitle = "REDOC API Documentation";
        c.SpecUrl = "/swagger/v1/swagger.json";
    });
}
else
{
    var port = Environment.GetEnvironmentVariable("PORT") ?? "8080";

    var url = new[] { string.Concat("http://0.0.0.0:", port) };
    builder.WebHost.UseUrls(url);
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
