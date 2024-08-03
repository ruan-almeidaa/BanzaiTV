using BanzaiTV.Database;
using BanzaiTV.Helper.AutoMapperCfg;
using BanzaiTV.Helper.HangfireCfg;
using BanzaiTV.Helper.Sessao;
using BanzaiTV.Interfaces.IRepository;
using BanzaiTV.Interfaces.IService;
using BanzaiTV.Interfaces.IViewModelService;
using BanzaiTV.Repository;
using BanzaiTV.Services;
using BanzaiTV.ViewModelServices;
using Hangfire;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddControllersWithViews();

//Entity Framework
builder.Services.AddDbContext<BancoContext>(options =>
    options.UseSqlServer(builder.Configuration.GetConnectionString("Database"), sqlServerOptions =>
    {
        sqlServerOptions.CommandTimeout(60); // Tempo limite de comando em segundos
        sqlServerOptions.EnableRetryOnFailure(1); // Tenta novamente 1 vez em caso de falha
    }));


// Configura Hangfire sql server
builder.Services.AddHangfire(config =>
{
    config.SetDataCompatibilityLevel(CompatibilityLevel.Version_170)
        .UseSimpleAssemblyNameTypeSerializer()
    .UseRecommendedSerializerSettings()
          .UseSqlServerStorage(builder.Configuration.GetConnectionString("Database"));
    // Configurações adicionais aqui
});
builder.Services.AddHangfireServer();
builder.Services.AddSingleton<BanzaiTV.Helper.HangfireCfg.Hangfire>();

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
builder.Services.AddScoped<IOrquestracaoService, OrquestracaoService>();
builder.Services.AddScoped<IVisaoGeralViewModelService, VisaoGeralViewModelService>();

builder.Services.AddAutoMapper(typeof(MappingProfile));

builder.Services.AddSingleton<BanzaiTV.Helper.HangfireCfg.Hangfire>();

builder.Services.AddSession(o =>
{
    o.Cookie.HttpOnly = true;
    o.Cookie.IsEssential = true;
});

var app = builder.Build();

app.UseAuthorization();
app.UseSession();

app.UseHangfireDashboard("/hangfire", new DashboardOptions
{
    Authorization = new[] { new HangfireAuthorizationFilter() }
});


var hangfire = app.Services.GetService<BanzaiTV.Helper.HangfireCfg.Hangfire>();

// Uma vez ao dia, o Hangfire reliza update nas mensalidades atrasadas.
RecurringJob.AddOrUpdate(() => hangfire.AtualizarStatusMensalidadesAtrasadas(), Cron.Daily);
//Uma vez ao mês, o Hangfire realiza update atualizando o status dos clientes que precisam de renovação.
RecurringJob.AddOrUpdate(() => hangfire.AtualizarStatusRenovacaoClientes(), Cron.Monthly);

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

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}");

app.Run();
