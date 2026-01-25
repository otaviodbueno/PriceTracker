using Microsoft.EntityFrameworkCore;
using PriceTracker.Data;
using PriceTracker.Service;

var builder = Host.CreateApplicationBuilder(args);

// =======================
// Database
// =======================

builder.Services.AddDbContext<PriceTrackerContext>(options =>
{
    options.UseSqlServer(
        builder.Configuration.GetConnectionString("DefaultConnection"));
});

// =======================
// Repositories
// =======================

builder.Services.AddScoped<IServicoRepository, ServicoRepository>();

 builder.Services.AddScoped(typeof(IRepository<>), typeof(Repository<>));

// =======================
// Job / Services
// =======================

builder.Services.AddScoped<IJobExecuter, JobExecuter>();

// Cada serviço executor entra aqui
builder.Services.AddScoped<IServicoExecutor, AmazonSearchItemPriceService>();
// builder.Services.AddScoped<IServicoExecutor, OutroServicoExecutor>();

// =======================
// Worker
// =======================

builder.Services.AddHostedService<Worker>();

// =======================
// Build & Run
// =======================

var host = builder.Build();
host.Run();
