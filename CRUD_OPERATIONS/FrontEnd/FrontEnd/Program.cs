using BlazorBootstrap;
using Blazorise;
using Blazorise.Icons.FontAwesome;
using CurrieTechnologies.Razor.SweetAlert2;
using FrontEnd;
using FrontEnd.Application.Interfaces;
using FrontEnd.Application.Services;
using Microsoft.AspNetCore.Components.Web;
using Microsoft.AspNetCore.Components.WebAssembly.Hosting;

var builder = WebAssemblyHostBuilder.CreateDefault(args);
builder.RootComponents.Add<App>("#app");
builder.RootComponents.Add<HeadOutlet>("head::after");

builder.Services.AddAutoMapper(AppDomain.CurrentDomain.GetAssemblies());
builder.Services.AddBlazorBootstrap();
builder.Services.AddBlazorise();
builder.Services.AddFontAwesomeIcons();


builder.Services.AddScoped(sp => new HttpClient { BaseAddress = new Uri("https://localhost:7044") });

//builder.Services.AddScoped(sp => new HttpClient { BaseAddress = new Uri("https://crudapi20240227170805.azurewebsites.net") });

builder.Services.AddScoped<IUsersService, UsersService>();

builder.Services.AddSweetAlert2();

await builder.Build().RunAsync();
