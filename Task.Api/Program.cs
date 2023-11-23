
using Backup.Domain;
using Domain;
using Domain.Interfaces;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.Configure<ClincSettings>(builder.Configuration.GetSection("ConnectionDB"));


builder.Services.AddDbContext<ApplicationDBContext>(options => options.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection"),
    builder => builder.MigrationsAssembly(typeof(ApplicationDBContext).Assembly.FullName)));

builder.Services.AddDbContext<BackupDBContext>(options => options.UseSqlServer(builder.Configuration.GetConnectionString("BackupConnection"),
    builder => builder.MigrationsAssembly(typeof(BackupDBContext).Assembly.FullName)));
builder.Services.AddTransient(typeof(Domain.Interfaces.IRepositoryBase<>), typeof(Domain.Interfaces.ClinicBackupRepo<>));
builder.Services.AddTransient<IUnitOfWork, UnitOfWork>();
builder.Services.AddTransient<BackupDBContext, BackupDBContext>();



builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var app = builder.Build();
app.UseCors(x => x
   .AllowAnyOrigin()
   .AllowAnyMethod()
   .AllowAnyHeader());
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
