using CargoFast.Api.Extensions;
using CargoFast.DataAccess.Context;
using Microsoft.EntityFrameworkCore;
using MongoDB.Driver;
var builder = WebApplication.CreateBuilder(args);
var connectionString = builder.Configuration.GetConnectionString("MongoConnection");
var databaseName = builder.Configuration.GetSection("ConnectionStrings:DatabaseName").Value;
if (string.IsNullOrEmpty(connectionString))
{
    throw new ArgumentNullException(nameof(connectionString), "Connection string cannot be null or empty.");
}
if (string.IsNullOrEmpty(databaseName))
{
    throw new ArgumentNullException(nameof(databaseName), "Database name cannot be null or empty.");
}
var mongoDatabase = new MongoClient(connectionString).GetDatabase(databaseName);

builder.Services.AddDbContext<CargoContext>(option =>
{
    option.UseMongoDB(mongoDatabase.Client, mongoDatabase.DatabaseNamespace.DatabaseName);
});
builder.Services.AddServiceExtension();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.AddControllers(); //Controllerların çalışması için.
var app = builder.Build();
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}
app.UseHttpsRedirection();
//app.UseAuthorization(); -- Kullanıcı oturum yapıları ile alakalı fonksiyon.
app.MapControllers();
app.Run();
