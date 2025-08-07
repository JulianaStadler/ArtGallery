using Microsoft.EntityFrameworkCore;
using GaleriaDeArte.Models;

var builder = WebApplication.CreateBuilder(args);
builder.Services.AddDbContext<GaleriaDeArteDbContext>(options => {
    var sqlConn = Environment.GetEnvironmentVariable("SQL_CONNECTION");
    options.UseSqlServer(sqlConn);
});

//sem isso o codigo nao vai funcionar
var app = builder.Build();
app.Run();