using WebApplication1.Data.DataBase;
using WebApplication1.Data.Interfaces;
using WebApplication1.Data.Mocks;
using WebApplication1.Data.Models;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddTransient<ICategores, DBCategory>();
builder.Services.AddTransient<IItems, DBItems>();
builder.Services.AddMvc(option => option.EnableEndpointRouting = false);


var app = builder.Build();
app.UseDeveloperExceptionPage();
app.UseStatusCodePages();
app.UseStaticFiles();
app.UseMvcWithDefaultRoute();
app.Run();
public class Startup
{
    public static List<ItemBasket> BasketItem = new List<ItemBasket>();
}