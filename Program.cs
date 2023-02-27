using AspTest.Domain;
using AspTest.Models.Offer;
using AspTest.Models.Utilities.Converters.StringModelConverter;
using AspTest.Models.Utilities.Converters.XmlModelConverter;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.EntityFrameworkCore;
using AspTest.Domain.Repositories;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddControllersWithViews();

builder.Services.AddDbContext<AppDataBaseContext>(options => 

    options.UseSqlServer(builder.Configuration.GetConnectionString("offersDB"))

);

builder.Services.AddSingleton<IXmlModelConverter<List<AspTest.Models.Offer.OfferModel>>, XmlToOffersConverter>();

builder.Services.AddScoped<IOffersRepository, OffersRepository>();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Home/Error");
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
