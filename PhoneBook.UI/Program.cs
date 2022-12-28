using PhoneBook.UI.Models;
using PhoneBook.UI.Services;

var builder = WebApplication.CreateBuilder(args);

builder.Services.Configure<PhoneBookDatabaseSettings>(
    builder.Configuration.GetSection("PhoneBookDatabase"));
// Add services to the container.
builder.Services.AddControllersWithViews();
builder.Services.AddSingleton<PhoneBookService>();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Home/Error");
}
app.UseStaticFiles();

app.UseRouting();

app.UseAuthorization();

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}");

app.Run();
