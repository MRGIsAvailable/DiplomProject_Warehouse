using ConstructionWarehouse_Web;
using ConstructionWarehouse_Web.Services;
using ConstructionWarehouse_Web.Services.IServices;
using Microsoft.AspNetCore.Authentication.Cookies;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddControllersWithViews();
builder.Services.AddAutoMapper(typeof(MappingConfig));

builder.Services.AddHttpClient<IOrderService, OrderService>();
builder.Services.AddScoped<IOrderService, OrderService>();

builder.Services.AddHttpClient<IProductService, ProductService>();
builder.Services.AddScoped<IProductService, ProductService>();

builder.Services.AddHttpClient<IInventoryService, InventoryService>();
builder.Services.AddScoped<IInventoryService, InventoryService>();

builder.Services.AddHttpClient<ISupplierService, SupplierService>();
builder.Services.AddScoped<ISupplierService, SupplierService>();

builder.Services.AddHttpClient<ISupplierProductService, SupplierProductService>();
builder.Services.AddScoped<ISupplierProductService, SupplierProductService>();

builder.Services.AddHttpClient<ICategoryService, CategoryService>();
builder.Services.AddScoped<ICategoryService, CategoryService>();

builder.Services.AddHttpClient<IStatusService, StatusService>();
builder.Services.AddScoped<IStatusService, StatusService>();

builder.Services.AddHttpClient<IUserService, UserService>();
builder.Services.AddScoped<IUserService, UserService>();

builder.Services.AddHttpClient<IPremiseService, PremiseService>();
builder.Services.AddScoped<IPremiseService, PremiseService>();

builder.Services.AddSingleton<IHttpContextAccessor, HttpContextAccessor>();

builder.Services.AddHttpClient<IAuthService, AuthService>();
builder.Services.AddScoped<IAuthService, AuthService>();

builder.Services.AddDistributedMemoryCache();

builder.Services.AddAuthentication(CookieAuthenticationDefaults.AuthenticationScheme)
    .AddCookie(options =>
    {
        options.Cookie.HttpOnly = true;
        options.ExpireTimeSpan = TimeSpan.FromMinutes(30);
        options.LoginPath = "/Auth/Login";
        options.AccessDeniedPath = "/Auth/AccessDenided";
        options.SlidingExpiration = true;
    });

builder.Services.AddSession(options =>
{
    options.IdleTimeout = TimeSpan.FromMinutes(100);
    options.Cookie.HttpOnly = true;
    options.Cookie.IsEssential = true;
});

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

app.UseSession();

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Auth}/{action=Login}/{id?}");

app.Run();
