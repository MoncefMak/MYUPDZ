using MYUPDZ.Api;
using MYUPDZ.Application;
using MYUPDZ.Infrastructure;
using MYUPDZ.Infrastructure.Persistance;

var builder = WebApplication.CreateBuilder(args);
// Add services to the container.

builder.Services.AddControllers();
builder.Services.AddHttpContextAccessor();

// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services
    .AddApplication()
    .AddInfrastructure(builder.Configuration);

builder.Services.AddWebUIServices();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseOpenApi(); // Replace app.UseSwagger();
    app.UseSwaggerUi3(); // Replace app.UseSwaggerUi();

    // Initialise and seed database
    using (IServiceScope scope = app.Services.CreateScope())
    {
        DatabaseInitializer initialiser =
            scope.ServiceProvider.GetRequiredService<DatabaseInitializer>();
        await initialiser.InitializeAsync();
        await initialiser.TrySeedAsync();
    }

}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();