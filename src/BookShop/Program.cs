using NLog;
using BookShop.Extensions;
using Data.Identity.SeedIdentity;
using Data.Interfaces;

var builder = WebApplication.CreateBuilder(args);
LogManager.LoadConfiguration(string.Concat(Directory.GetCurrentDirectory(), "/nlog.config"));

// Add services to the container.
builder.Services.AddControllersWithViews();
builder.Services.AddAutoMapper(typeof(Program));
builder.Services.ConfigureLoggerService();
builder.Services.ConfigureRepositoryManager();
builder.Services.ConfigureServiceManager();
builder.Services.ConfigureSqlContext(builder.Configuration);
builder.Services.AddAuthentication();
builder.Services.ConfigureIdentity();

var app = builder.Build();

var scopeFactory = app.Services.GetRequiredService<IServiceScopeFactory>();
var logger = app.Services.GetRequiredService<ILoggerManager>();
using (var scope = scopeFactory.CreateScope())
{
    await SeedContext.SeedSuperAdminAsync(scope.ServiceProvider);
    await SeedContext.SeedAdminAsync(scope.ServiceProvider);
    await SeedContext.SeedBasicAsync(scope.ServiceProvider);
}

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Home/Error");
    // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
    app.UseHsts();
    app.UseHttpsRedirection();
}


app.UseStaticFiles();

app.UseRouting();

app.UseAuthentication();
app.UseAuthorization();

app.MapControllerRoute(
    name: "filter",
    pattern: "{controller}/{action}/filter/{filterterms}/{pagenumber?}/{pagesize?}/{orderby?}"
);

app.MapControllerRoute(

    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}");
logger.LogInfo("app running");
app.Run();
