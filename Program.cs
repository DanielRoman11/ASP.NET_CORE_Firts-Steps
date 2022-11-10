using ContosoCraft.website.Models;
using ContosoCraft.website.Services;
using System.Net;
using System.Text.Json;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddRazorPages();
builder.Services.AddTransient<JsonFileProductService>();
builder.Services.AddControllers();

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

app.MapControllers();

//app.mapget("/products", (context) =>
//{
//    var products = app.services.getservice<jsonfileproductservice>().getproducts();
//    var json = jsonserializer.serialize<ienumerable<product>>(products);
//    return context.response.writeasync(json);
//});

app.Run();
