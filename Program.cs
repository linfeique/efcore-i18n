using I18N.Infra;
using Mapster;
using Microsoft.EntityFrameworkCore;
using System.Reflection;

var builder = WebApplication.CreateBuilder(args);

var assembly = Assembly.GetAssembly(typeof(Program));

builder.Services.AddControllers().AddNewtonsoftJson(op =>
{
    op.SerializerSettings.ReferenceLoopHandling = Newtonsoft.Json.ReferenceLoopHandling.Ignore;
});

builder.Services.AddDbContext<Db>(options =>
{
    options.UseSqlServer("Data Source=127.0.0.1;User ID=sa;Password=dspL79cDs9gK%n%z;Initial Catalog=inter;Trusted_Connection=False; TrustServerCertificate=True;");
});

TypeAdapterConfig.GlobalSettings.Scan(assembly);

var app = builder.Build();

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
