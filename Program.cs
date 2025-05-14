using AgriEnergyConnect.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Http;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddControllersWithViews();

builder.Services.AddDbContext<AppDbContext>(options =>
    options.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection")));

builder.Services.AddSession();

// ✅ Add this line to enable injecting IHttpContextAccessor
builder.Services.AddHttpContextAccessor();

var app = builder.Build();

using (var scope = app.Services.CreateScope())
{
    var context = scope.ServiceProvider.GetRequiredService<AppDbContext>();

    if (!context.Farmers.Any())
    {
        var farmer1 = new Farmer { Name = "Thabo Mokoena", Email = "thabo@farm.co.za", Location = "Limpopo" };
        var farmer2 = new Farmer { Name = "Amina Patel", Email = "amina@farm.co.za", Location = "KwaZulu-Natal" };

        context.Farmers.AddRange(farmer1, farmer2);
        context.SaveChanges();

        context.Products.AddRange(
            new Product { Name = "Organic Tomatoes", Category = "Vegetables", ProductionDate = DateTime.Now.AddDays(-10), FarmerId = farmer1.FarmerId },
            new Product { Name = "Free-range Eggs", Category = "Poultry", ProductionDate = DateTime.Now.AddDays(-3), FarmerId = farmer2.FarmerId }
        );

        context.Users.AddRange(
            new User { Username = "farmer1", Password = "1234", Role = "Farmer", FarmerId = farmer1.FarmerId },
            new User { Username = "employee1", Password = "1234", Role = "Employee" }
        );

        context.SaveChanges();
    }
}



// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Home/Error");
    app.UseHsts();
}

app.UseHttpsRedirection();
app.UseStaticFiles();

app.UseRouting();
app.UseSession();

app.UseAuthorization();

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}");

app.Run();
