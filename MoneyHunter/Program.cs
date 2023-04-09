using MoneyHunter.DAL;
using MoneyHunter.DAL.Repository;
using MoneyHunter.DAL.Repository.Interface;
using MoneyHunter.Entities.Entities.BaseEntity;
using MoneyHunter.Service.Services.ReasonService;
using MoneyHunter.Service.Services.UserService;
using MoneyHunter.Service.Services.ValidateService;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddControllersWithViews();

builder.Services.AddScoped(typeof(IRepository<>), typeof(EfRepository<>));
builder.Services.AddScoped<IUserService, UserService>();
builder.Services.AddScoped<IValidateService, ValidateService>();
builder.Services.AddScoped<IReasonService, ReasonService>();

builder.Services.AddDbContext<AppDbContext>();

var app = builder.Build();

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

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}");

app.Run();
