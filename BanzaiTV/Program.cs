using BanzaiTV.Database;
using BanzaiTV.Helper.AutoMapperCfg;
using BanzaiTV.Helper.Sessao;
using BanzaiTV.Interfaces;
using BanzaiTV.Repository;
using BanzaiTV.Services;
using BanzaiTV.ViewModelServices;
using Hangfire;
using Hangfire.PostgreSql;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;

var builder = WebApplication.CreateBuilder(args);

// Habilitar comportamento legado de timestamps
AppContext.SetSwitch("Npgsql.EnableLegacyTimestampBehavior", true);

// Add services to the container.
builder.Services.AddControllersWithViews();

// Configure Entity Framework
builder.Services.AddEntityFrameworkNpgsql()
    .AddDbContext<BancoContext>(options =>
        options.UseNpgsql(builder.Configuration.GetConnectionString("Database")));

// Configura Hangfire PostgreSQL
builder.Services.AddHangfire(configuration => configuration
    .SetDataCompatibilityLevel(CompatibilityLevel.Version_170)
    .UseSimpleAssemblyNameTypeSerializer()
    .UseRecommendedSerializerSettings()
    .UsePostgreSqlStorage(builder.Configuration.GetConnectionString("Database")));

builder.Services.AddSingleton<IHttpContextAccessor, HttpContextAccessor>();

builder.Services.AddScoped<IClienteRepository, ClienteRepository>();
builder.Services.AddScoped<IPlanoRepository, PlanoRepository>();
builder.Services.AddScoped<IClienteService, ClienteService>();
builder.Services.AddScoped<IPlanoService, PlanoService>();
builder.Services.AddScoped<IAdministradorRepository, AdministradorRepository>();
builder.Services.AddScoped<IAdministradorService, AdministradorService>();
builder.Services.AddScoped<IMensalidadeRepository, MensalidadeRepository>();
builder.Services.AddScoped<IMensalidadeService, MensalidadeService>();
builder.Services.AddScoped<ISessao, SessaoService>();
builder.Services.AddScoped<IClienteViewModelService, ClienteViewModelService>();
builder.Services.AddScoped<IMensalidadeViewModelService, MensalidadeViewModelService>();

builder.Services.AddAutoMapper(typeof(MappingProfile));
builder.Services.AddHangfireServer();
builder.Services.AddSingleton<BanzaiTV.Helper.HangfireCfg.Hangfire>();
builder.Services.AddHangfireServer();

builder.Services.AddSession(o =>
{
    o.Cookie.HttpOnly = true;
    o.Cookie.IsEssential = true;
});

var app = builder.Build();

app.UseHangfireDashboard();


var hangfire = app.Services.GetService<BanzaiTV.Helper.HangfireCfg.Hangfire>();

// Schedule the job to run daily
RecurringJob.AddOrUpdate(() => hangfire.UpdateMensalidade(), Cron.Daily);

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Home/Error");
    // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
    app.UseHsts();
}

app.UseHttpsRedirection();
app.UseStaticFiles();

app.UseRouting();

app.UseAuthorization();

app.UseSession();

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}");

app.Run();
