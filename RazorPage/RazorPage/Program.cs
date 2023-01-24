using Microsoft.EntityFrameworkCore;
using RazorPage.Interfaceses;
using RazorPage.Models.Context;
using RazorPage.Services;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddRazorPages();
builder.Services.AddControllersWithViews();
builder.Services.AddScoped<IBook, BookServices>();

//DataBaseConfig
builder.Services.AddDbContext<ApplicationDbContext>(option =>
{
    option.UseSqlServer(builder.Configuration.GetConnectionString("RazorConnection"));
});

var app = builder.Build();

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Error");
    // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
    app.UseHsts();
}

app.UseHttpsRedirection();
app.UseStaticFiles();

app.UseRouting();

app.UseAuthorization();

app.MapRazorPages();
app.UseEndpoints(endpoint =>
{
    endpoint.MapControllers();
    endpoint.MapRazorPages();
});
app.Run();



// app.UseEndpoints(endpoints =>
// {
//     endpoints.MapControllerRoute(
//         name: "areas",
//         pattern: "{area:exists}/{controller=Home}/{action=Index}/{id?}"
//     );
//
//     endpoints.MapControllerRoute(
//         name: "default",
//         pattern: "{controller=Home}/{action=Index}/{id?}");
// });