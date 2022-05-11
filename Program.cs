using ControleDeProdutos_API.Data;
using Microsoft.EntityFrameworkCore;


var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
// Serviço  -> Install-Package Pomelo.EntityFrameworkCore.MySql

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.AddDbContext<ControleDeProdutos_API.Data.AppContext>(options => 

options.UseLazyLoadingProxies(true)
       .UseMySql(builder.Configuration.GetConnectionString("ItemConnection"), new MySqlServerVersion(new Version(8, 0, 28))
));

//builder.Services.AddDbContext<ControleDeProdutos_API.Data.AppContext>((DbContextOptionsBuilder options) =>
//{
    //Instalar Entity Proxies
//    options.UseMySql(builder.Configuration.GetConnectionString("ItemConnection"), new MySqlServerVersion(new Version(8, 0, 28)));
//});

builder.Services.AddAutoMapper(AppDomain.CurrentDomain.GetAssemblies());
var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
