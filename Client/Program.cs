using Microsoft.AspNetCore.Components.Web;
using Microsoft.AspNetCore.Components.WebAssembly.Hosting;
using BlazorApp.Client;
using Blazorise;
using Blazorise.Bootstrap;
using Blazorise.Icons.FontAwesome;
using ErgastApi.Client;
using Plk.Blazor.DragDrop;
using Blazored.LocalStorage;
using BlazorApp.Client.Services;

var builder = WebAssemblyHostBuilder.CreateDefault(args);

builder.Services
      .AddBlazorise( options =>
      {
          options.ChangeTextOnKeyPress = true;
      } )
      .AddBootstrapProviders()
      .AddFontAwesomeIcons();

builder.Services.AddBlazoredLocalStorage();

builder.Services.AddBlazorDragDrop();

builder.RootComponents.Add<App>("#app");
builder.RootComponents.Add<HeadOutlet>("head::after");

builder.Services.AddScoped(sp => new HttpClient { BaseAddress = new Uri(builder.Configuration["API_Prefix"] ?? builder.HostEnvironment.BaseAddress) });

builder.Services.AddHttpClient("MotorsportNews", client => client.BaseAddress = new Uri("https://www.motorsport.com/rss/f1/news/"));

builder.Services.AddSingleton<IErgastClient, ErgastClient>();
builder.Services.AddScoped<ICircuitService, CircuitsService>();
builder.Services.AddScoped<IRaceService, RaceService>();
builder.Services.AddScoped<IDriverService, DriverService>();
builder.Services.AddScoped<IBettingService, BettingService>();

await builder.Build().RunAsync();
