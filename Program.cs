using Microsoft.EntityFrameworkCore;
using Nexus.Data;

var builder = WebApplication.CreateBuilder(args);

// 1. Veritabaný Baðlantýsýný (DbContext) Kaydet
builder.Services.AddDbContext<NexusDbContext>(options =>
    options.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection")));

// 2. MVC Controller ve View desteðini ekle
builder.Services.AddControllersWithViews();

var app = builder.Build();

// 3. Hata yönetimi ve HTTPS yönlendirmesi
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Home/Error");
    app.UseHsts();
}

app.UseHttpsRedirection();
app.UseStaticFiles(); // Resimler ve videolar için þart!

app.UseRouting();

app.UseAuthorization();

// 4. Sayfa Yönlendirme (Route) Ayarý
app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}");

app.Run();