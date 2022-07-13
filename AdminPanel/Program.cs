using AdminPanel.Identity;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddControllersWithViews();

#region Veritaban� Connection Kodumuz ve AddDbContext Veritaban�n� Tan�mlama. Ve Veri Atma Kodlar�m�z
var connection = builder.Configuration["Ayarlar:BaglantiSatirim"];
builder.Services.AddDbContext<AdminPanelContext>(options => options.UseSqlServer(connection));

#endregion


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
