using Web.Extensions;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
IConfiguration configuration = builder.Configuration;

//IdentityModelEventSource.ShowPII = true;
builder.Services.AddHealthChecks();
builder.AddTokenValidation(configuration);
builder.Services.AddEndpointsApiExplorer();

builder.AddSwaggerSettings();
builder.Services.AddInfrastructureLayer(configuration);
builder.Services.AddApplicationLayer(configuration);

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment() || app.Environment.EnvironmentName == "Local")
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();
app.MapHealthChecks("/health");
app.Run();

